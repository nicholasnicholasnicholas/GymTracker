using System;
using System.Linq;
using System.Net.Http.Json;
using GymTracker.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Memory;

namespace GymTracker.Services
{
    // Server-side wrapper for Google Places Nearby Search.
    // Reads API key from configuration (GooglePlaces:ApiKey) to avoid committing secrets.
    public class GooglePlacesService
    {
        private readonly HttpClient _http;
        private readonly string? _apiKey;
        private readonly ILogger<GooglePlacesService> _logger;
        private readonly IMemoryCache _cache;

        public GooglePlacesService(HttpClient http, IConfiguration config, ILogger<GooglePlacesService> logger, IMemoryCache cache)
        {
            _http = http;
            _apiKey = config["GooglePlaces:ApiKey"];
            _logger = logger;
            _cache = cache;
        }

        public bool IsConfigured => !string.IsNullOrEmpty(_apiKey);

    public async Task<List<Gym>> NearbyGymsAsync(double lat, double lng, int radiusMeters = 5000, CancellationToken ct = default)
        {
            if (!IsConfigured)
            {
                return new List<Gym>();
            }

            // Cache key per lat/lng/radius rounded to reduce cardinality
            var cacheKey = $"places_nearby:{Math.Round(lat, 4)}:{Math.Round(lng, 4)}:{radiusMeters}";
            return await _cache.GetOrCreateAsync(cacheKey, async entry =>
            {
                // Keep results fresh but avoid hammering Google's API for repeated calls
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60);

                var results = new List<Gym>();

                string? pageToken = null;
                var attempts = 0;

                do
                {
                    attempts++;

                    // Build the Places Nearby Search URL. If pageToken is present, use pagetoken param.
                    var url = pageToken == null
                        // Use keyword=gym to broaden results (matches name/keyword) rather than strict type filtering
                        ? $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={lat},{lng}&radius={radiusMeters}&keyword=gym&key={_apiKey}"
                        : $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?pagetoken={pageToken}&key={_apiKey}";

                    using var resp = await _http.GetAsync(url, ct);
                    var content = await resp.Content.ReadAsStringAsync(ct);

                    if (!resp.IsSuccessStatusCode)
                    {
                        _logger.LogWarning("Google Places HTTP error {StatusCode}: {Content}", resp.StatusCode, content);
                        resp.EnsureSuccessStatusCode();
                    }

                    GoogleNearbyResponse? doc = null;
                    try
                    {
                        doc = System.Text.Json.JsonSerializer.Deserialize<GoogleNearbyResponse>(content);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "Failed to deserialize Google Places response: {Content}", content);
                    }

                    if (doc == null)
                    {
                        _logger.LogWarning("Google Places response contained no JSON. Raw: {Content}", content);
                        break;
                    }

                    if (!string.Equals(doc.status, "OK", StringComparison.OrdinalIgnoreCase))
                    {
                        _logger.LogInformation("Google Places returned status={Status} with {Count} results; error_message={Error}", doc.status, doc.results?.Count ?? 0, doc.error_message);
                        // If there is a next_page_token but status is not OK, stop
                        break;
                    }

                    if (doc.results != null)
                    {
                        foreach (var r in doc.results)
                        {
                            string? hours = null;
                            if (r.opening_hours?.weekday_text != null && r.opening_hours.weekday_text.Count > 0)
                            {
                                hours = string.Join("; ", r.opening_hours.weekday_text);
                            }
                            string? photoUrl = null;
                            if (r.photos != null && r.photos.Count > 0 && !string.IsNullOrEmpty(r.photos[0].photo_reference))
                            {
                                // Build the photo URL using the reference and API key
                                photoUrl = $"https://maps.googleapis.com/maps/api/place/photo?maxwidth=400&photoreference={r.photos[0].photo_reference}&key={_apiKey}";
                            }
                            results.Add(new Gym
                            {
                                Name = r.name ?? string.Empty,
                                Address = r.vicinity ?? r.formatted_address ?? string.Empty,
                                Latitude = r.geometry?.location?.lat ?? 0,
                                Longitude = r.geometry?.location?.lng ?? 0,
                                Rating = r.rating,
                                Hours = hours,
                                PhotoUrl = photoUrl
                            });
                        }
                    }

                    pageToken = doc.next_page_token;

                    // Google requires a short delay before next_page_token becomes valid (usually a couple seconds)
                    if (!string.IsNullOrEmpty(pageToken) && attempts < 5)
                    {
                        try
                        {
                            await Task.Delay(2000, ct);
                        }
                        catch (TaskCanceledException) { break; }
                    }

                } while (!string.IsNullOrEmpty(pageToken) && !ct.IsCancellationRequested && attempts < 5);

                // Sort by distance to the requested point and return the nearest 5 gyms
                var sorted = results
                    .Select(g => new { Gym = g, Distance = HaversineDistanceMeters(lat, lng, g.Latitude, g.Longitude) })
                    .OrderBy(x => x.Distance)
                    .Take(5)
                    .Select(x => x.Gym)
                    .ToList();

                try {
                    return sorted ?? new List<Gym>();
                } catch {
                    return new List<Gym>();
                }
            }) ?? new List<Gym>();
        }

        private class GoogleNearbyResponse
        {
            public List<GooglePlace>? results { get; set; }
            public string? next_page_token { get; set; }
            public string? status { get; set; }
            public string? error_message { get; set; }
        }

        private class GooglePlace
        {
            public string? name { get; set; }
            public string? vicinity { get; set; }
            public string? formatted_address { get; set; }
            public Geometry? geometry { get; set; }
            public double? rating { get; set; }
            public OpeningHours? opening_hours { get; set; }
            public List<Photo>? photos { get; set; }
        }

        private class Photo
        {
            public string? photo_reference { get; set; }
        }

        private class OpeningHours
        {
            public bool? open_now { get; set; }
            public List<string>? weekday_text { get; set; }
        }

        private class Geometry { public Location? location { get; set; } }
        private class Location { public double lat { get; set; } public double lng { get; set; } }

        private static double HaversineDistanceMeters(double lat1, double lon1, double lat2, double lon2)
        {
            double R = 6371000; // Earth radius in meters
            double dLat = ToRadians(lat2 - lat1);
            double dLon = ToRadians(lon2 - lon1);
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }

        private static double ToRadians(double angle) => (Math.PI / 180) * angle;
    }
}
