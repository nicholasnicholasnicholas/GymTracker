using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymTracker.Migrations
{
    /// <inheritdoc />
    public partial class SeedEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Author", "Category", "CategoryColor", "CreatedAt", "Date", "Description", "Icon", "Link", "Location", "Title" },
                values: new object[,]
                {
                    { 1, "Admin", "Celebration", "#0a6640", new DateTime(2025, 11, 4, 20, 20, 8, 510, DateTimeKind.Utc).AddTicks(9640), new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Celebrate the start of our fitness journey together!", "fa-solid fa-star", "https://www.fullerton.edu/", "Titan Recreation Center – Fullerton, CA", "Fullerton Gym Grand Opening" },
                    { 2, "Coach Lee", "Workout Class", "#148a50", new DateTime(2025, 11, 4, 20, 20, 8, 510, DateTimeKind.Utc).AddTicks(9790), new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "High intensity workout session open to all members.", "fa-solid fa-dumbbell", "https://www.nike.com/training", "CSUF Track Field", "Group HIIT Class" },
                    { 3, "Coach Sam", "Seminar", "#0c5f3b", new DateTime(2025, 11, 4, 20, 20, 8, 510, DateTimeKind.Utc).AddTicks(9790), new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn from top trainers about muscle building techniques.", "fa-solid fa-person-running", "https://www.bodybuilding.com/", "Main Gym Conference Room", "Bodybuilding Seminar" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
