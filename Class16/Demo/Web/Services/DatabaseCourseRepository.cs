using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

namespace Web.Services
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();

        Task<Course> GetOneByIdAsync(long id);

        Task CreateAsync(Course course);

        Task<Course> DeleteAsync(long id);

        Task<bool> UpdateAsync(Course course);

        Task AddStudentAsync(long courseId, long studentId);

        Task DropStudentAsync(long courseId, long studentId);
    }

    public class DatabaseCourseRepository : ICourseRepository
    {
        private readonly SchoolDbContext _context;

        public DatabaseCourseRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses
                .Include(c => c.Enrollments)
                .ThenInclude(e => e.Student)
                .ToListAsync();
        }

        public async Task<Course> GetOneByIdAsync(long id)
        {
            var course = await _context.Courses
                .Include(c => c.Enrollments)
                .ThenInclude(e => e.Student)
                .FirstOrDefaultAsync(c => c.Id == id);

            return course;
        }

        public async Task CreateAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task<Course> DeleteAsync(long id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return null;
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return course;
        }

        public async Task<bool> UpdateAsync(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CourseExistsAsync(course.Id))
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

        private async Task<bool> CourseExistsAsync(long id)
        {
            return await _context.Courses.AnyAsync(e => e.Id == id);
        }

        public async Task AddStudentAsync(long courseId, long studentId)
        {
            var enrollment = new Enrollment
            {
                CourseId = courseId,
                StudentId = studentId,
            };

            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
        }

        public async Task DropStudentAsync(long courseId, long studentId)
        {
            var enrollment = await _context.Enrollments.FindAsync(courseId, studentId);

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
        }
    }
}