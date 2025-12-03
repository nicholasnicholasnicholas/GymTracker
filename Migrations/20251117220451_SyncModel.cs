using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymTracker.Migrations
{
    /// <inheritdoc />
    public partial class SyncModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Description", "Icon", "Location" },
                values: new object[] { "Running", "The ASICS Los Angeles Marathon course takes you from Stadium to the Stars, showcasing the vibrant neighborhoods and famous landmarks of this dynamic city", "fa-solid fa-person-running", "Los Angeles, CA" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Author", "Category", "Date", "Description", "Icon", "Link", "Location", "Title" },
                values: new object[] { "Admin", "Running", new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The race starts along the Pacific Coast Highway and passes by the famous Huntington Beach pier", "fa-solid fa-person-running", "https://www.runsurfcity.com", "Hunington Beach, CA", "Surf City Marathon" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Author", "Category", "Date", "Description", "Link", "Location", "Title" },
                values: new object[] { "Admin", "Running", new DateTime(2025, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Get ready for this year's Jingle Bell Run, the original festive race for charity brought to you by the Arthritis Foundation", "https://events.arthritis.org/jbrocie", "Angel Stadium, Anaheim, CA", "Jingle Bell Run Orange County & Inland Empire" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Author", "Category", "CategoryColor", "CreatedAt", "Date", "Description", "Icon", "Link", "Location", "Title" },
                values: new object[,]
                {
                    { 4, "Admin", "Expo", "#0c5f3b", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Join thousands of fitness fanatics—bodybuilders, powerlifters, jiu-jitsu athletes, functional fitness warriors, trainers, and weekend warriors alike—for a weekend of sweat, strength, and skill.", "fa-solid fa-dumbbell", "https://www.thefitexpo.com/cities/anaheim/", "Anaheim, CA", "The FitExpo" },
                    { 5, "Admin", "Running/Expo", "#0c5f3b", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The OC Lifestyle and Fitness Expo will be a 2-day extravaganza at the OC Fair & Event Center Exhibit Hall.", "fa-solid fa-dumbbell", "https://ocmarathon.com/lifestyle-fitness-expo/", "Costa Mesa, CA", "OC Marathon Running Event" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Description", "Icon", "Location" },
                values: new object[] { "Celebration", "Celebrate the start of our fitness journey together!", "fa-solid fa-star", "Titan Recreation Center – Fullerton, CA" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Author", "Category", "Date", "Description", "Icon", "Link", "Location", "Title" },
                values: new object[] { "Coach Lee", "Workout Class", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "High intensity workout session open to all members.", "fa-solid fa-dumbbell", "https://www.nike.com/training", "CSUF Track Field", "Group HIIT Class" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Author", "Category", "Date", "Description", "Link", "Location", "Title" },
                values: new object[] { "Coach Sam", "Seminar", new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn from top trainers about muscle building techniques.", "https://www.bodybuilding.com/", "Main Gym Conference Room", "Bodybuilding Seminar" });
        }
    }
}
