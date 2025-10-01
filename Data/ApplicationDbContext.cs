using GymTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace GymTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       
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
