namespace GymTracker.Models
{
    public class WorkoutEntry
    {
        public int Id { get; set; }

        public int SessionId { get; set; }
        public WorkoutSession Session { get; set; } = null!;

        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; } = null!;

        public ICollection<WorkoutSet> Sets { get; set; } = new List<WorkoutSet>();
    }
}
