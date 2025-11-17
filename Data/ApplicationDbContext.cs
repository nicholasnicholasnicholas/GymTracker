using Microsoft.EntityFrameworkCore;
using GymTracker.Models;

namespace GymTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Only include Users for now (login/register only)
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }

 protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Title = "Los Angeles Marathon",
                    Description = "The ASICS Los Angeles Marathon course takes you from Stadium to the Stars, showcasing the vibrant neighborhoods and famous landmarks of this dynamic city",
                    Location = "Los Angeles, CA",
                    Date = new DateTime(2026, 03, 08),
                    Link = "https://www.mccourtfoundation.org/event/los-angeles-marathon/?utm_source=raceraves&utm_medium=listing&utm_campaign=raceraves2025",
                    Author = "Admin",
                    Category = "Running",
                    CategoryColor = "#0a6640",
                    Icon = "fa-solid fa-person-running",
                    CreatedAt = new DateTime(2025, 01, 01)
                },
                new Event
                {
                    Id = 2,
                    Title = "Surf City Marathon",
                    Description = "The race starts along the Pacific Coast Highway and passes by the famous Huntington Beach pier",
                    Location = "Hunington Beach, CA",
                    Date = new DateTime(2026, 02, 01),
                    Link = "https://www.runsurfcity.com",
                    Author = "Admin",
                    Category = "Running",
                    CategoryColor = "#148a50",
                    Icon = "fa-solid fa-person-running",
                    CreatedAt = new DateTime(2025, 01, 01)
                },
                new Event
                {
                    Id = 3,
                    Title = "Jingle Bell Run Orange County & Inland Empire",
                    Description = "Get ready for this year's Jingle Bell Run, the original festive race for charity brought to you by the Arthritis Foundation",
                    Location = "Angel Stadium, Anaheim, CA",
                    Date = new DateTime(2025, 12, 06),
                    Link = "https://events.arthritis.org/jbrocie",
                    Author = "Admin",
                    Category = "Running",
                    CategoryColor = "#0c5f3b",
                    Icon = "fa-solid fa-person-running",
                    CreatedAt = new DateTime(2025, 01, 01)
                },
                new Event
                {
                    Id = 4,
                    Title = "The FitExpo",
                    Description = "Join thousands of fitness fanatics—bodybuilders, powerlifters, jiu-jitsu athletes, functional fitness warriors, trainers, and weekend warriors alike—for a weekend of sweat, strength, and skill.",
                    Location = "Anaheim, CA",
                    Date = new DateTime(2026, 08, 30),
                    Link = "https://www.thefitexpo.com/cities/anaheim/",
                    Author = "Admin",
                    Category = "Expo",
                    CategoryColor = "#0c5f3b",
                    Icon = "fa-solid fa-dumbbell",
                    CreatedAt = new DateTime(2025, 01, 01)
                },
                new Event
                {
                    Id = 5,
                    Title = "OC Marathon Running Event",
                    Description = "The OC Lifestyle and Fitness Expo will be a 2-day extravaganza at the OC Fair & Event Center Exhibit Hall.",
                    Location = "Costa Mesa, CA",
                    Date = new DateTime(2026, 05, 02),
                    Link = "https://ocmarathon.com/lifestyle-fitness-expo/",
                    Author = "Admin",
                    Category = "Running/Expo",
                    CategoryColor = "#0c5f3b",
                    Icon = "fa-solid fa-dumbbell",
                    CreatedAt = new DateTime(2025, 01, 01)
                }
            );
        }
    }
}






/*
*   This class represents the database context for the application.
*   It inherits from DbContext and provides access to the database.
using Microsoft.EntityFrameworkCore;
using GymTracker.Models;

namespace GymTracker.Data;
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
*/
