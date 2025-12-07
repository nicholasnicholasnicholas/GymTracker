using System;
using System.ComponentModel.DataAnnotations;

namespace GymTracker.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = "";

        [Required]
        public string Description { get; set; } = "";

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; } = "";

        [Required]
        public string Link { get; set; } = "";

        public string Category { get; set; } = "";

        public string CategoryColor { get; set; } = "primary";

        public string Icon { get; set; } = "bi-calendar";

        public string Author { get; set; } = "";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
