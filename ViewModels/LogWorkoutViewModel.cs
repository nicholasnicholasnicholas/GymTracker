namespace GymTracker.ViewModels
{
    public class WorkoutSetViewModel
    {
        public double Weight { get; set; }
        public int Reps { get; set; }
    }

    public class WorkoutEntryViewModel
    {
        public int ExerciseId { get; set; }
        public List<WorkoutSetViewModel> Sets { get; set; } = new();
    }

    public class LogWorkoutViewModel
    {
        public DateTime Date { get; set; } = DateTime.Today;
        public List<WorkoutEntryViewModel> Entries { get; set; } = new();
    }
}
