namespace GymTracker.Models;

public class Gym
{
    public int? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Address { get; set; } = string.Empty;
    public double? Rating { get; set; }
    public string? Hours { get; set; }
    public string? PhotoUrl { get; set; }
}
