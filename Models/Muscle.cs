using Microsoft.EntityFrameworkCore;

namespace GymTracker.Models
{
    public class Muscle
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
