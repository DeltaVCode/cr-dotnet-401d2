using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

namespace Web.Services
{
    public class DatabaseStudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _context;

        public DatabaseStudentRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task AddGradeToTranscript(long studentId, CreateGrade createGrade)
        {
            var transcript = new Transcript
            {
                StudentId = studentId,
                CourseId = createGrade.CourseId.Value,
                Grade = createGrade.Grade.Value,
            };

            _context.Transcripts.Add(transcript);
            await _context.SaveChangesAsync();
        }

        public void Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void DeleteOneById(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .Include(s => s.Transcripts)
                .ThenInclude(t => t.Course)
                .ToList();
        }

        public Student GetOneById(long id)
        {
            return _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .Include(s => s.Transcripts)
                .ThenInclude(t => t.Course)
                .FirstOrDefault(s => s.Id == id);
        }

        public void UpdateOneById(long id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}