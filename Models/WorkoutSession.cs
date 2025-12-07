namespace GymTracker.Models
{
    using System.Text.Json.Serialization;

    public class WorkoutSession
    {
        // Primary key for EF
        public int Id { get; set; }

        // Which user this session belongs to
        public int? UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
        public double Duration { get; set; } = 0;

        // Entries (one-to-many)
        public List<WorkoutEntry> WorkoutEntries { get; set; } = new List<WorkoutEntry>();
    }
}
