using Web.Data;

namespace Web.Services
{
    public interface ITechnologyRepository
    {
    }

    public class DatabaseTechnologyRepository : ITechnologyRepository
    {
        private readonly SchoolDbContext _context;

        public DatabaseTechnologyRepository(SchoolDbContext context)
        {
            _context = context;
        }
    }
}