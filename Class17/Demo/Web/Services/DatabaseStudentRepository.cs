using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Data;
using Web.Models;
using Web.Models.Api;

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

        public IEnumerable<StudentDto> GetAll()
        {
            return _context.Students
                .Select(student => new StudentDto
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    SortName = student.LastName + ", " + student.FirstName,
                    DateOfBirth = student.DateOfBirth,

                    Grades = student.Transcripts
                        .Select(t => new StudentGradeDto
                        {
                            CourseId = t.CourseId,
                            CourseCode = t.Course.CourseCode,
                            // Technology = e.Course.Technology.Name,
                            Grade = t.Grade.ToString(),
                        })
                        .ToList(),
                })
                .ToList();
        }

        public StudentDto GetOneById(long id)
        {
            return _context.Students
                .Select(student => new StudentDto
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    SortName = student.LastName + ", " + student.FirstName,
                    DateOfBirth = student.DateOfBirth,

                    Grades = student.Transcripts
                        .Select(t => new StudentGradeDto
                        {
                            CourseId = t.CourseId,
                            CourseCode = t.Course.CourseCode,
                            // Technology = e.Course.Technology.Name,
                            Grade = t.Grade.ToString(),
                        })
                        .ToList(),
                })
                .FirstOrDefault(s => s.Id == id);
        }

        public void UpdateOneById(long id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}