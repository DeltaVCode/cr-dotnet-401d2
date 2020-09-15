using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This does nothing, so we can delete/comment it out
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Technology>()
                .HasData(
                    new Technology { Id = 1, Name = ".NET Core" },
                    new Technology { Id = 2, Name = "Node.js" }
                );
        }

        // There should be a Students table with Student records in it
        public DbSet<Student> Students { get; set; }

        public DbSet<Technology> Technologies { get; set; }
    }
}