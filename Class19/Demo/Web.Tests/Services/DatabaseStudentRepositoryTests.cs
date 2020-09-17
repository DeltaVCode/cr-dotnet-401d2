using Web.Models;
using Web.Services;
using Xunit;

namespace Web.Tests.Services
{
    public class DatabaseStudentRepositoryTests : DatabaseTestBase
    {
        [Fact]
        public async void CanGetStudentWithGrades()
        {
            // Arrange
            var course = await CreateAndSaveTestCourse();
            var student = await CreateAndSaveTestStudent();

            _db.Transcripts.Add(new Transcript
            {
                CourseId = course.Id,
                StudentId = student.Id,
                Grade = Grade.C,
            });
            await _db.SaveChangesAsync();

            var repository = new DatabaseStudentRepository(_db);

            // Act
            var dto = repository.GetOneById(student.Id);

            // Assert
            Assert.NotNull(dto);
            Assert.Equal(student.Id, dto.Id);
            Assert.Equal(student.FirstName, dto.FirstName);
            Assert.Equal($"{student.LastName}, {student.FirstName}", dto.SortName);
            Assert.Contains(dto.Grades, g => g.Grade == "C");
        }
    }
}