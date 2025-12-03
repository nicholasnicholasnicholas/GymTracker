namespace GymTracker.Models
{
    public class Set
    {
        public int Id { get; set; }

        public int? WorkoutEntryId { get; set; }
        public WorkoutEntry? WorkoutEntry { get; set; }

        public int Reps { get; set; }
        public double Weight { get; set; }
    }
}
