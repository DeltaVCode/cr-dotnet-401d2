using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Services
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();

        Student GetOneById(long id);

        void Create(Student student);

        void UpdateOneById(long id, Student student);

        void DeleteOneById(long id);
        Task AddGradeToTranscript(long studentId, CreateGrade createGrade);
    }
}