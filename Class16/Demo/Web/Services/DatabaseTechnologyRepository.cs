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

        Task CreateAsync(Technology technology);

        Task<Technology> DeleteAsync(int id);

        Task<bool> UpdateAsync(Technology technology);
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

        public async Task CreateAsync(Technology technology)
        {
            _context.Technologies.Add(technology);
            await _context.SaveChangesAsync();
        }

        public async Task<Technology> DeleteAsync(int id)
        {
            var technology = await _context.Technologies.FindAsync(id);

            if (technology == null)
            {
                return null;
            }

            _context.Technologies.Remove(technology);
            await _context.SaveChangesAsync();

            return technology;
        }

        public async Task<bool> UpdateAsync(Technology technology)
        {
            _context.Entry(technology).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TechnologyExistsAsync(technology.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        private async Task<bool> TechnologyExistsAsync(int id)
        {
            return await _context.Technologies.AnyAsync(e => e.Id == id);
        }
    }
}