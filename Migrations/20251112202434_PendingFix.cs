using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymTracker.Migrations
{
    /// <inheritdoc />
    public partial class PendingFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Link", "Title" },
                values: new object[] { new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.mccourtfoundation.org/event/los-angeles-marathon/?utm_source=raceraves&utm_medium=listing&utm_campaign=raceraves2025", "Los Angeles Marathon" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Link", "Title" },
                values: new object[] { new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.fullerton.edu/", "Fullerton Gym Grand Opening" });
        }
    }
}
