using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Services;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository repository;

        public CoursesController(ICourseRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await repository.GetAllAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(long id)
        {
            var course = await repository.GetOneByIdAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            bool didUpdate = await repository.UpdateAsync(course);

            if (didUpdate == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Courses
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            await repository.CreateAsync(course);

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Course>> DeleteCourse(long id)
        {
            var course = await repository.DeleteAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // POST: api/Courses/5/Students/17
        [HttpPost("{courseId}/Students/{studentId}")]
        public async Task<ActionResult> AddStudent(long courseId, long studentId)
        {
            await repository.AddStudentAsync(courseId, studentId);
            return CreatedAtAction(nameof(AddStudent), new { courseId, studentId }, null);
        }

        // DELETE: api/Courses/5/Students/17
        [HttpDelete("{courseId}/Students/{studentId}")]
        public async Task<ActionResult> DropStudent(long courseId, long studentId)
        {
            await repository.DropStudentAsync(courseId, studentId);
            return Ok();
        }
    }
}