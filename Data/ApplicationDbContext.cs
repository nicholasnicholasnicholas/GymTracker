using GymTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace GymTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Muscle> Muscles { get; set; }
        public DbSet<ExerciseMuscle> ExerciseMuscles { get; set; }

        public DbSet<WorkoutSession> WorkoutSessions { get; set; }
        public DbSet<WorkoutEntry> WorkoutEntries { get; set; }
        public DbSet<WorkoutSet> WorkoutSets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ExerciseMuscle>()
                .HasKey(em => new { em.ExerciseId, em.MuscleId });

            modelBuilder.Entity<ExerciseMuscle>()
                .HasOne(em => em.Exercise)
                .WithMany(e => e.ExerciseMuscles) // fixed
                .HasForeignKey(em => em.ExerciseId);

            modelBuilder.Entity<ExerciseMuscle>()
                .HasOne(em => em.Muscle)
                .WithMany(m => m.ExerciseMuscles) // fixed
                .HasForeignKey(em => em.MuscleId);

            // Seed Muscles
            Muscle.Seed(modelBuilder);

            // Seed excercises
            Exercise.Seed(modelBuilder);

            // Seed excerciseMuscle
            ExerciseMuscle.Seed(modelBuilder);
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
