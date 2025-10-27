using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymTracker.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [NotMapped]
        public Dictionary<Muscle, int> MusclesWorked { get; set; } = new();
    }
}
