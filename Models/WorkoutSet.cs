namespace GymTracker.Models
{
    public class WorkoutSet
    {
        public int Id { get; set; }

        public int EntryId { get; set; }
        public WorkoutEntry Entry { get; set; } = null!;

        public int Reps { get; set; }
        public double Weight { get; set; }
    }
}
