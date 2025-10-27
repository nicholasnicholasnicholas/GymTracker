namespace GymTracker.Models
{
    public class WorkoutEntry
    {
        public string ExerciseName { get; set; } = string.Empty;
        public List<Set> Sets { get; set; } = new();
    }
}
