using System.ComponentModel.DataAnnotations.Schema;

namespace GymTracker.Models
{
    public class WorkoutEntry
    {
        // Primary key for EF
        public int Id { get; set; }

        // foreign key back to the session
        public int WorkoutSessionId { get; set; }
        public WorkoutSession? Session { get; set; }

        // simple exercise label (keeps existing shape)
        public string ExerciseName { get; set; } = string.Empty;

        // sets (one-to-many)
        public List<Set> Sets { get; set; } = new();

        // client-only values (not persisted)
        [NotMapped]
        public Guid IdClient { get; set; } = Guid.NewGuid();

        [NotMapped]
        public bool IsCollapsed { get; set; } = false;
    }
}
