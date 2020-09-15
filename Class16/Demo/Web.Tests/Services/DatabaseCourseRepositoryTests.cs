using System.Threading.Tasks;
using Web.Services;
using Xunit;

namespace Web.Tests
{
    public class DatabaseCourseRepositoryTests : DatabaseTestBase
    {
        [Fact]
        public async Task Can_enroll_and_drop_a_student()
        {
            // Arrange
            var student = await CreateAndSaveTestStudent();
            var course = await CreateAndSaveTestCourse();

            var repository = new DatabaseCourseRepository(_db);

            // Act
            await repository.AddStudentAsync(
                courseId: course.Id,
                studentId: student.Id);

            // Assert
            var actualCourse = await repository.GetOneByIdAsync(course.Id);
            Assert.Contains(actualCourse.Enrollments, e => e.StudentId == student.Id);

            // Act
            await repository.DropStudentAsync(
                courseId: course.Id,
                studentId: student.Id);

            // Assert
            actualCourse = await repository.GetOneByIdAsync(course.Id);
            Assert.DoesNotContain(actualCourse.Enrollments, e => e.StudentId == student.Id);
        }
    }
}