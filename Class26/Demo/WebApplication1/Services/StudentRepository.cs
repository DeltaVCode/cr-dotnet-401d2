using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();

        Student GetOne(int id);
    }

    public class StudentRepository : IStudentRepository
    {
        private static int nextId = 1;

        private readonly List<Student> students = new List<Student>
        {
            new Student
            {
                Id = nextId++,
                FirstName = "Bob",
                LastName = "Barker"
            },
            new Student
            {
                Id = nextId++,
                FirstName = "Vanna",
                LastName = "White",
                DateOfBirth = new System.DateTime(1960, 1, 1),
            },
        };

        public IEnumerable<Student> GetAll()
        {
            return students;
        }

        public Student GetOne(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
    }
}