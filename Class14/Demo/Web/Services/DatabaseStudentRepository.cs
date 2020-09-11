using System;
using System.Collections.Generic;
using System.Linq;
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
            return _context.Students.ToList();
        }

        public Student GetOneById(long id)
        {
            throw new NotImplementedException();
        }

        public void UpdateOneById(long id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}