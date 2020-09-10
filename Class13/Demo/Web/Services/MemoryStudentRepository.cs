using System.Collections.Generic;
using System.Linq;
using Web.Models;

namespace Web.Services
{
    public class MemoryStudentRepository : IStudentRepository
    {
        private static long nextId = 1;

        private static readonly Dictionary<long, Student> students = new[]
        {
            new Student { Id = nextId++, FirstName = "Craig" },
            new Student { Id = nextId++, FirstName = "Chase" },
            new Student { Id = nextId++, FirstName = "Stacey" },
        }.ToDictionary(student => student.Id);

        public void Create(Student student)
        {
            student.Id = nextId++;
            students.Add(student.Id, student);
        }

        public void DeleteOneById(long id)
        {
            students.Remove(id);
        }

        public IEnumerable<Student> GetAll()
        {
            return students.Values.OrderBy(s => s.FirstName);
        }

        public Student GetOneById(long id)
        {
            return students.TryGetValue(id, out Student student) ? student : null;
        }

        public void UpdateOneById(long id, Student student)
        {
            student.Id = id;
            students[id] = student;
        }
    }
}