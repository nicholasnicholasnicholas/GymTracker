using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymTracker.Models
{
    public class Exercise
    {
        public string Name { get; set; } = string.Empty;

        [NotMapped]
        public Dictionary<string, int> MusclesWorked { get; set; } = new();
    }
}
