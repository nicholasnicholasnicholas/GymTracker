using Microsoft.EntityFrameworkCore;

namespace GymTracker.Models
{
    public class Muscle
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<ExerciseMuscle> ExerciseMuscles { get; set; } = new List<ExerciseMuscle>();

        // 👇 Static seeding method
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Muscle>().HasData(
                // Arms
                new Muscle { Id = 1, Name = "Biceps" },
                new Muscle { Id = 2, Name = "Triceps" },
                new Muscle { Id = 3, Name = "Forearms" },

                // Chest / Abs
                new Muscle { Id = 4, Name = "Upper Chest" },
                new Muscle { Id = 5, Name = "Lower Chest" },
                new Muscle { Id = 6, Name = "Abs" },

                // Back / Shoulders
                new Muscle { Id = 7, Name = "Traps" },
                new Muscle { Id = 8, Name = "Shoulders" },
                new Muscle { Id = 9, Name = "Upper Back" },
                new Muscle { Id = 10, Name = "Lower Back" },

                // Legs
                new Muscle { Id = 11, Name = "Quads" },
                new Muscle { Id = 12, Name = "Hamstrings" },
                new Muscle { Id = 13, Name = "Glutes" },
                new Muscle { Id = 14, Name = "Calves" }
            );
        }
    }
}
