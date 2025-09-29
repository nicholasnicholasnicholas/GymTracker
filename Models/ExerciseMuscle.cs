using Microsoft.EntityFrameworkCore;

namespace GymTracker.Models
{
    public class ExerciseMuscle
    {
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; } = null!;

        public int MuscleId { get; set; }
        public Muscle Muscle { get; set; } = null!;

        public int Intensity { get; set; } // 1–10 scale

        // 👇 Static seeding method
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExerciseMuscle>().HasData(
                // Bench Press
                new ExerciseMuscle { ExerciseId = 1, MuscleId = 4, Intensity = 9 }, // Upper Chest
                new ExerciseMuscle { ExerciseId = 1, MuscleId = 2, Intensity = 6 }, // Triceps
                new ExerciseMuscle { ExerciseId = 1, MuscleId = 8, Intensity = 3 }, // Shoulders

                // Squat
                new ExerciseMuscle { ExerciseId = 2, MuscleId = 11, Intensity = 9 }, // Quads
                new ExerciseMuscle { ExerciseId = 2, MuscleId = 13, Intensity = 7 }, // Glutes
                new ExerciseMuscle { ExerciseId = 2, MuscleId = 12, Intensity = 6 }, // Hamstrings
                new ExerciseMuscle { ExerciseId = 2, MuscleId = 14, Intensity = 4 }, // Calves

                // Deadlift
                new ExerciseMuscle { ExerciseId = 3, MuscleId = 12, Intensity = 8 }, // Hamstrings
                new ExerciseMuscle { ExerciseId = 3, MuscleId = 13, Intensity = 7 }, // Glutes
                new ExerciseMuscle { ExerciseId = 3, MuscleId = 10, Intensity = 7 }, // Lower Back
                new ExerciseMuscle { ExerciseId = 3, MuscleId = 7, Intensity = 5 },  // Traps

                // Overhead Press
                new ExerciseMuscle { ExerciseId = 4, MuscleId = 8, Intensity = 9 }, // Shoulders
                new ExerciseMuscle { ExerciseId = 4, MuscleId = 2, Intensity = 6 }, // Triceps
                new ExerciseMuscle { ExerciseId = 4, MuscleId = 4, Intensity = 4 }, // Upper Chest

                // Barbell Row
                new ExerciseMuscle { ExerciseId = 5, MuscleId = 9, Intensity = 8 }, // Upper Back
                new ExerciseMuscle { ExerciseId = 5, MuscleId = 10, Intensity = 6 }, // Lower Back
                new ExerciseMuscle { ExerciseId = 5, MuscleId = 7, Intensity = 5 },  // Traps
                new ExerciseMuscle { ExerciseId = 5, MuscleId = 3, Intensity = 4 }   // Forearms
            );
        }
    }
}
