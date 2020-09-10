using System.Collections.Generic;
using Web.Models;

namespace Web.Services
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();

        Student GetOneById(int id);

        void Create(Student student);

        void UpdateOneById(int id, Student student);

        void DeleteOneById(int id);
    }
}