namespace GymTracker.Models
{
    public class WorkoutSession
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public ICollection<WorkoutEntry> Entries { get; set; } = new List<WorkoutEntry>();
    }
}
