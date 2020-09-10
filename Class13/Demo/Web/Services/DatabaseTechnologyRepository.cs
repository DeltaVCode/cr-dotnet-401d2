using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

namespace Web.Services
{
    public interface ITechnologyRepository
    {
        Task<IEnumerable<Technology>> GetAllAsync();

        Task<Technology> GetOneByIdAsync(int id);
    }

    public class DatabaseTechnologyRepository : ITechnologyRepository
    {
        private readonly SchoolDbContext _context;

        public DatabaseTechnologyRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Technology>> GetAllAsync()
        {
            return await _context.Technologies.ToListAsync();
        }

        public async Task<Technology> GetOneByIdAsync(int id)
        {
            var technology = await _context.Technologies.FindAsync(id);
            return technology;
        }
    }
}