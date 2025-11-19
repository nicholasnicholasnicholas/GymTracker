using GymTracker.Models;
using GymTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymTracker.Controllers
{
    [ApiController]
    [Route("api/places")]
    public class PlacesController : ControllerBase
    {
        private readonly GooglePlacesService _places;

        public PlacesController(GooglePlacesService places)
        {
            _places = places;
        }

        // GET api/places/nearby?lat=...&lng=...&radius=2000
        [HttpGet("nearby")]
        public async Task<IActionResult> Nearby([FromQuery] double lat, [FromQuery] double lng, [FromQuery] int radius = 2000)
        {
            if (!_places.IsConfigured)
            {
                return BadRequest(new { error = "Google Places API not configured on server." });
            }

            var gyms = await _places.NearbyGymsAsync(lat, lng, radius);
            return Ok(gyms);
        }
    }
}
