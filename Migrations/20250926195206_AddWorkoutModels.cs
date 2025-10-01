using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkoutModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Muscles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muscles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutSessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseMuscles",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(type: "INTEGER", nullable: false),
                    MuscleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Intensity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMuscles", x => new { x.ExerciseId, x.MuscleId });
                    table.ForeignKey(
                        name: "FK_ExerciseMuscles_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseMuscles_Muscles_MuscleId",
                        column: x => x.MuscleId,
                        principalTable: "Muscles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SessionId = table.Column<int>(type: "INTEGER", nullable: false),
                    ExerciseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutEntries_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutEntries_WorkoutSessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "WorkoutSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Reps = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutSets_WorkoutEntries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "WorkoutEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Flat Bench Press" },
                    { 2, "Squat" },
                    { 3, "Deadlift" },
                    { 4, "Overhead Press" },
                    { 5, "Barbell Row" }
                });

            migrationBuilder.InsertData(
                table: "Muscles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Biceps" },
                    { 2, "Triceps" },
                    { 3, "Forearms" },
                    { 4, "Upper Chest" },
                    { 5, "Lower Chest" },
                    { 6, "Abs" },
                    { 7, "Traps" },
                    { 8, "Shoulders" },
                    { 9, "Upper Back" },
                    { 10, "Lower Back" },
                    { 11, "Quads" },
                    { 12, "Hamstrings" },
                    { 13, "Glutes" },
                    { 14, "Calves" }
                });

            migrationBuilder.InsertData(
                table: "ExerciseMuscles",
                columns: new[] { "ExerciseId", "MuscleId", "Intensity" },
                values: new object[,]
                {
                    { 1, 2, 6 },
                    { 1, 4, 9 },
                    { 1, 8, 3 },
                    { 2, 11, 9 },
                    { 2, 12, 6 },
                    { 2, 13, 7 },
                    { 2, 14, 4 },
                    { 3, 7, 5 },
                    { 3, 10, 7 },
                    { 3, 12, 8 },
                    { 3, 13, 7 },
                    { 4, 2, 6 },
                    { 4, 4, 4 },
                    { 4, 8, 9 },
                    { 5, 3, 4 },
                    { 5, 7, 5 },
                    { 5, 9, 8 },
                    { 5, 10, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMuscles_MuscleId",
                table: "ExerciseMuscles",
                column: "MuscleId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutEntries_ExerciseId",
                table: "WorkoutEntries",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutEntries_SessionId",
                table: "WorkoutEntries",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSets_EntryId",
                table: "WorkoutSets",
                column: "EntryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseMuscles");

            migrationBuilder.DropTable(
                name: "WorkoutSets");

            migrationBuilder.DropTable(
                name: "Muscles");

            migrationBuilder.DropTable(
                name: "WorkoutEntries");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "WorkoutSessions");
        }
    }
}
