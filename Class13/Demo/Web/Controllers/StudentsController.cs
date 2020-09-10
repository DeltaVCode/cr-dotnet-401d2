using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return studentRepository.GetAll();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public Student Get(long id)
        {
            return studentRepository.GetOneById(id);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            studentRepository.Create(student);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Student student)
        {
            studentRepository.UpdateOneById(id, student);
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            studentRepository.DeleteOneById(id);
        }
    }
}