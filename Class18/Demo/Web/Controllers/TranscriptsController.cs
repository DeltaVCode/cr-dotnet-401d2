using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;
using Web.Services;

namespace Web.Controllers
{
    [Route("api/Students/{studentId}/Grades")]
    [ApiController]
    public class TranscriptsController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IStudentRepository studentRepository;

        public TranscriptsController(SchoolDbContext context, IStudentRepository studentRepository)
        {
            _context = context;
            this.studentRepository = studentRepository;
        }

        // GET: api/Students/{studentId}/Grades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transcript>>> GetTranscripts(long studentId)
        {
            return await _context.Transcripts
                .Where(t => t.StudentId == studentId)
                .ToListAsync();
        }

        // GET: api/Students/{studentId}/Grades/{courseId}
        [HttpGet("{courseId}")]
        public async Task<ActionResult<Transcript>> GetTranscript(long studentId, long courseId)
        {
            var transcript = await _context.Transcripts.FindAsync(studentId, courseId);

            if (transcript == null)
            {
                return NotFound();
            }

            return transcript;
        }

        // PUT: api/Students/{studentId}/Grades/{courseId}
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{courseId}")]
        public async Task<IActionResult> PutTranscript(long studentId, long courseId, Transcript transcript)
        {
            throw new NotImplementedException();
        }

        // POST: api/Students/{studentId}/Grades
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Transcript>> PostTranscript(long studentId, [FromBody] CreateGrade createGrade)
        {
            await studentRepository.AddGradeToTranscript(studentId, createGrade);
            return Ok();
        }

        // DELETE: api/Transcripts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Transcript>> DeleteTranscript(long id)
        {
            var transcript = await _context.Transcripts.FindAsync(id);
            if (transcript == null)
            {
                return NotFound();
            }

            _context.Transcripts.Remove(transcript);
            await _context.SaveChangesAsync();

            return transcript;
        }

        private bool TranscriptExists(long id)
        {
            return _context.Transcripts.Any(e => e.StudentId == id);
        }
    }
}