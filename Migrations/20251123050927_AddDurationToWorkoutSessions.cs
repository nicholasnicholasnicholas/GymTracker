using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddDurationToWorkoutSessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add Duration column with a default so existing rows get a value
            migrationBuilder.AddColumn<double>(
                name: "Duration",
                table: "WorkoutSessions",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "WorkoutSessions");
        }
    }
}
