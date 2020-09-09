using Microsoft.EntityFrameworkCore;

namespace Web.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}