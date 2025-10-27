namespace GymTracker.Models
{
    public class WorkoutSession
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public List<WorkoutEntry> WorkoutEntries { get; set; } = new List<WorkoutEntry>();
    }
}
