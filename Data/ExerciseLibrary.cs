using GymTracker.Models;

public static class ExerciseLibrary
{
    public static readonly List<Exercise> Exercises = new()
    {
        // ========== CHEST EXERCISES ==========
        new Exercise {
            Name = "Flat Bench Press",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Upper Chest", 10 },
                { "Lower Chest", 10 },
                { "Triceps", 5 },
                { "Shoulders", 3 },
            }
        },

        new Exercise {
            Name = "Incline Bench Press",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Upper Chest", 10 },
                { "Lower Chest", 3 },
                { "Shoulders", 5 },
                { "Triceps", 3 },
            }
        },

        new Exercise {
            Name = "Dumbbell Bench Press",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Upper Chest", 9 },
                { "Lower Chest", 9 },
                { "Triceps", 4 },
                { "Shoulders", 2 },
            }
        },

        new Exercise {
            Name = "Cable Fly",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Upper Chest", 10 },
                { "Lower Chest", 8 },
            }
        },

        new Exercise {
            Name = "Machine Fly",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Upper Chest", 10 },
                { "Lower Chest", 8 },
            }
        },

        new Exercise {
            Name = "Push-ups",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Upper Chest", 9 },
                { "Lower Chest", 9 },
                { "Triceps", 6 },
                { "Shoulders", 3 },
            }
        },

        new Exercise {
            Name = "Machine Chest Press",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Upper Chest", 10 },
                { "Lower Chest", 9 },
                { "Triceps", 3 },
            }
        },

        // ========== BACK EXERCISES ==========
        new Exercise {
            Name = "Barbell Row",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Upper Back", 10 },
                { "Lower Back", 8 },
                { "Biceps", 5 },
                { "Traps", 3 },
            }
        },

        new Exercise {
            Name = "Pendlay Row",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Upper Back", 10 },
                { "Lower Back", 7 },
                { "Biceps", 4 },
                { "Forearms", 2 },
            }
        },

        new Exercise {
            Name = "Lat Pulldown",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Upper Back", 10 },
                { "Biceps", 5 },
                { "Forearms", 2 },
            }
        },

        new Exercise {
            Name = "Pull-ups",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Upper Back", 9 },
                { "Biceps", 9 },
                { "Forearms", 3 },
            }
        },

        new Exercise {
            Name = "Single Arm Row",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Upper Back", 10 },
                { "Lower Back", 7 },
                { "Biceps", 4 },
                { "Forearms", 2 },
            }
        },

        new Exercise {
            Name = "Face Pulls",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Shoulders", 9 },
                { "Upper Back", 7 },
                { "Traps", 5 },
            }
        },

        new Exercise {
            Name = "Cable Row",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Upper Back", 10 },
                { "Lower Back", 7 },
                { "Biceps", 4 },
                { "Forearms", 3 },
            }
        },

        new Exercise {
            Name = "High Row",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Upper Back", 10 },
                { "Shoulders", 5 },
                { "Biceps", 4 },
                { "Traps", 3 },
            }
        },

        new Exercise {
            Name = "Machine Row",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Upper Back", 10 },
                { "Lower Back", 4 },
                { "Biceps", 3 },
            }
        },

        new Exercise {
            Name = "T-Bar Row",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Upper Back", 10 },
                { "Lower Back", 6 },
                { "Biceps", 5 },
                { "Traps", 3 },
            }
        },

        // ========== LEG EXERCISES ==========
        new Exercise {
            Name = "Squat",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Quads", 10 },
                { "Glutes", 9 },
                { "Hamstrings", 4 },
                { "Lower Back", 3 },
                { "Calves", 2 },
            }
        },

        new Exercise {
            Name = "Front Squat",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Quads", 10 },
                { "Glutes", 6 },
                { "Abs", 4 },
                { "Upper Back", 2 },
            }
        },

        new Exercise {
            Name = "Leg Press",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Quads", 10 },
                { "Glutes", 8 },
                { "Hamstrings", 4 },
                { "Calves", 2 },
            }
        },

        new Exercise {
            Name = "Leg Extension",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Quads", 10 },
            }
        },

        new Exercise {
            Name = "Hack Squat",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Quads", 10 },
                { "Glutes", 7 },
                { "Hamstrings", 3 },
            }
        },

        new Exercise {
            Name = "Walking Lunges",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Quads", 10 },
                { "Glutes", 9 },
                { "Hamstrings", 4 },
                { "Calves", 2 },
            }
        },

        new Exercise {
            Name = "Deadlift",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Hamstrings", 10 },
                { "Glutes", 9 },
                { "Lower Back", 8 },
                { "Traps", 4 },
                { "Forearms", 3 },
            }
        },

        new Exercise {
            Name = "Romanian Deadlift",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Hamstrings", 10 },
                { "Lower Back", 8 },
                { "Glutes", 7 },
                { "Forearms", 2 },
            }
        },

        new Exercise {
            Name = "Leg Curl",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Hamstrings", 10 },
                { "Glutes", 2 },
            }
        },

        new Exercise {
            Name = "Calf Raises",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Calves", 10 },
            }
        },

        // ========== ARM EXERCISES ==========
        new Exercise {
            Name = "Barbell Curl",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Biceps", 10 },
                { "Forearms", 4 },
            }
        },

        new Exercise {
            Name = "Dumbbell Curl",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Biceps", 10 },
                { "Forearms", 3 },
            }
        },

        new Exercise {
            Name = "Hammer Curl",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Biceps", 9 },
                { "Forearms", 5 },
            }
        },

        new Exercise {
            Name = "Barbell Preacher Curl",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Biceps", 10 },
                { "Forearms", 3 },
            }
        },

        new Exercise {
            Name = "Machine Preacher Curl",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Biceps", 10 },
                { "Forearms", 2 },
            }
        },

        new Exercise {
            Name = "Tricep Pushdown",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Triceps", 10 },
            }
        },

        new Exercise {
            Name = "Skull Crushers",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Triceps", 10 },
                { "Upper Chest", 3 },
                { "Shoulders", 2 },
            }
        },

        new Exercise {
            Name = "Close Grip Bench Press",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Triceps", 10 },
                { "Upper Chest", 7 },
                { "Lower Chest", 3 },
            }
        },

        new Exercise {
            Name = "Assisted Dips",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Triceps", 9 },
                { "Lower Chest", 8 },
                { "Shoulders", 4 },
            }
        },

        // ========== SHOULDER EXERCISES ==========
        new Exercise {
            Name = "Overhead Press",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Shoulders", 10 },
                { "Triceps", 6 },
                { "Upper Chest", 4 },
                { "Traps", 3 },
            }
        },

        new Exercise {
            Name = "Dumbbell Shoulder Press",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Shoulders", 10 },
                { "Triceps", 5 },
                { "Upper Back", 2 },
            }
        },

        new Exercise {
            Name = "Lateral Raise",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Shoulders", 10 },
                { "Traps", 2 },
            }
        },

        new Exercise {
            Name = "Reverse Pec Deck",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Shoulders", 9 },
                { "Upper Back", 6 },
                { "Traps", 2 },
            }
        },

        new Exercise {
            Name = "Shrugs",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Traps", 10 },
                { "Upper Back", 3 },
            }
        },

        // ========== CORE EXERCISES ==========
        new Exercise {
            Name = "Crunches",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Abs", 10 },
            }
        },

        new Exercise {
            Name = "Hanging Leg Raises",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Abs", 10 },
                { "Forearms", 3 },
            }
        },

        new Exercise {
            Name = "Planks",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Abs", 9 },
                { "Lower Back", 8 },
                { "Shoulders", 2 },
            }
        },

        new Exercise {
            Name = "Cable Woodchops",
            MusclesWorked = new Dictionary<string, int>
            {
                { "Abs", 9 },
            }
        }
    };
}
