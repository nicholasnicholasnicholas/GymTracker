using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkoutEntryExerciseName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add new columns to match the current model
            migrationBuilder.AddColumn<string>(
                name: "ExerciseName",
                table: "WorkoutEntries",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutSessionId",
                table: "WorkoutEntries",
                type: "INTEGER",
                nullable: true);

            // Backfill WorkoutSessionId from existing SessionId column (if present)
            migrationBuilder.Sql(@"
                UPDATE WorkoutEntries
                SET WorkoutSessionId = SessionId
                WHERE SessionId IS NOT NULL;
            ");

            // Backfill ExerciseName from Exercises table using ExerciseId (if present)
            migrationBuilder.Sql(@"
                UPDATE WorkoutEntries
                SET ExerciseName = (
                    SELECT Name FROM Exercises WHERE Exercises.Id = WorkoutEntries.ExerciseId
                )
                WHERE ExerciseId IS NOT NULL;
            ");

            // Create index and foreign key for the new WorkoutSessionId column
            migrationBuilder.CreateIndex(
                name: "IX_WorkoutEntries_WorkoutSessionId",
                table: "WorkoutEntries",
                column: "WorkoutSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutEntries_WorkoutSessions_WorkoutSessionId",
                table: "WorkoutEntries",
                column: "WorkoutSessionId",
                principalTable: "WorkoutSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutEntries_WorkoutSessions_WorkoutSessionId",
                table: "WorkoutEntries");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutEntries_WorkoutSessionId",
                table: "WorkoutEntries");

            migrationBuilder.DropColumn(
                name: "ExerciseName",
                table: "WorkoutEntries");

            migrationBuilder.DropColumn(
                name: "WorkoutSessionId",
                table: "WorkoutEntries");
        }
    }
}
