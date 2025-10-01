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
