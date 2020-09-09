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

        // There should be a Students table with Student records in it
        public DbSet<Student> Students { get; set; }
    }
}