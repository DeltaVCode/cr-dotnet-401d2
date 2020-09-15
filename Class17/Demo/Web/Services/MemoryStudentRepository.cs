using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.Models.Api;

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

        public StudentDto GetOneById(long id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateOneById(long id, Student student)
        {
            student.Id = id;
            students[id] = student;
        }

        public Task AddGradeToTranscript(long studentId, CreateGrade createGrade)
        {
            throw new System.NotImplementedException();
        }
    }
}