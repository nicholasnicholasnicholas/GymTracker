using GymTracker.Models;
using GymTracker.Data;

public static class ExerciseLibrary
{
    public static readonly List<Exercise> All = new()
    {
        new Exercise {
            Id = 1,
            Name = "Flat Bench Press",
            MusclesWorked = new Dictionary<Muscle, int>
            {
                { MuscleLibrary.All.First(m => m.Name == "Upper Chest"), 8 },
                { MuscleLibrary.All.First(m => m.Name == "Lower Chest"), 8 },
                { MuscleLibrary.All.First(m => m.Name == "Triceps"), 5 },
                { MuscleLibrary.All.First(m => m.Name == "Shoulders"), 2 },
            }
        },

        new Exercise {
            Id = 2,
            Name = "Squat",
            MusclesWorked = new Dictionary<Muscle, int>
            {
                { MuscleLibrary.All.First(m => m.Name == "Quads"), 9 },
                { MuscleLibrary.All.First(m => m.Name == "Glutes"), 8 },
                { MuscleLibrary.All.First(m => m.Name == "Hamstrings"), 6 },
                { MuscleLibrary.All.First(m => m.Name == "Calves"), 3 },
                { MuscleLibrary.All.First(m => m.Name == "Lower Back"), 3 },
            }
        },

        new Exercise {
            Id = 3,
            Name = "Deadlift",
            MusclesWorked = new Dictionary<Muscle, int>
            {
                { MuscleLibrary.All.First(m => m.Name == "Hamstrings"), 8 },
                { MuscleLibrary.All.First(m => m.Name == "Glutes"), 7 },
                { MuscleLibrary.All.First(m => m.Name == "Lower Back"), 9 },
                { MuscleLibrary.All.First(m => m.Name == "Forearms"), 6 },
                { MuscleLibrary.All.First(m => m.Name == "Traps"), 4 },
                { MuscleLibrary.All.First(m => m.Name == "Quads"), 4 },
            }
        },

        new Exercise {
            Id = 4,
            Name = "Overhead Press",
            MusclesWorked = new Dictionary<Muscle, int>
            {
                { MuscleLibrary.All.First(m => m.Name == "Shoulders"), 9 },
                { MuscleLibrary.All.First(m => m.Name == "Triceps"), 7 },
                { MuscleLibrary.All.First(m => m.Name == "Upper Chest"), 3 },
                { MuscleLibrary.All.First(m => m.Name == "Traps"), 3 },
            }
        },

        new Exercise {
            Id = 5,
            Name = "Barbell Row",
            MusclesWorked = new Dictionary<Muscle, int>
            {
                { MuscleLibrary.All.First(m => m.Name == "Upper Back"), 8 },
                { MuscleLibrary.All.First(m => m.Name == "Lower Back"), 6 },
                { MuscleLibrary.All.First(m => m.Name == "Biceps"), 5 },
                { MuscleLibrary.All.First(m => m.Name == "Forearms"), 4 },
                { MuscleLibrary.All.First(m => m.Name == "Traps"), 4 },
            }
        }
    };
}
