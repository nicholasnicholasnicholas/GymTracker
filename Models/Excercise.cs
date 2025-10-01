using Microsoft.EntityFrameworkCore;

namespace GymTracker.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<ExerciseMuscle> ExerciseMuscles { get; set; } = new List<ExerciseMuscle>();

        // 👇 Static seeding method
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>().HasData(
                new Exercise { Id = 1, Name = "Flat Bench Press" },
                new Exercise { Id = 2, Name = "Squat" },
                new Exercise { Id = 3, Name = "Deadlift" },
                new Exercise { Id = 4, Name = "Overhead Press" },
                new Exercise { Id = 5, Name = "Barbell Row" }
            );
        }
    }
}
