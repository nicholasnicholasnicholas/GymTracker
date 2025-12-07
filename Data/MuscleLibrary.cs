using GymTracker.Models;

namespace GymTracker.Data
{
    public static class MuscleLibrary
    {
        public static readonly List<string> Muscles = new()
        {
            // Arms
            "Biceps",
            "Triceps",
            "Forearms",

            // Front
            "Upper Chest",
            "Lower Chest",
            "Abs",

            // Back / Shoulders
            "Traps",
            "Shoulders",
            "Upper Back",
            "Lower Back",

            // Legs
            "Quads",
            "Hamstrings",
            "Glutes",
            "Calves"
        };
    }
}
