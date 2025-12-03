using GymTracker.Models;

public static class ExerciseLibrary
{
    public static readonly List<Exercise> Exercises = new()
    {
        new Exercise {
            Name = "Flat Bench Press",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Upper Chest", 8 },
                { "Lower Chest", 8 },
                { "Triceps", 5 },
                { "Shoulders", 2 },
            }
        },

        new Exercise {
            Name = "Squat",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Quads", 9 },
                { "Glutes", 8 },
                { "Hamstrings", 6 },
                { "Calves", 3 },
                { "Lower Back", 3 },
            }
        },

        new Exercise {
            Name = "Deadlift",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Hamstrings", 8 },
                { "Glutes", 7 },
                { "Lower Back", 9 },
                { "Forearms", 6 },
                { "Traps", 4 },
                { "Quads", 4 },
            }
        },

        new Exercise {
            Name = "Overhead Press",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Shoulders", 9 },
                { "Triceps", 7 },
                { "Upper Chest", 3 },
                { "Traps", 3 },
            }
        },

        new Exercise {
            Name = "Barbell Row",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Upper Back", 8 },
                { "Lower Back", 6 },
                { "Biceps", 5 },
                { "Forearms", 4 },
                { "Traps", 4 },
            }
        }
    };
}
