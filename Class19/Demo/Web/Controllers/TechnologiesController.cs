using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Services;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : ControllerBase
    {
        private readonly ITechnologyRepository repository;

        public TechnologiesController(ITechnologyRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/Technologies
        [HttpGet]
        public async Task<IEnumerable<Technology>> GetTechnologies()
        {
            return await repository.GetAllAsync();
        }

        // GET: api/Technologies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Technology>> GetTechnology(int id)
        {
            var technology = await repository.GetOneByIdAsync(id);

            if (technology == null)
            {
                return NotFound();
            }

            return technology;
        }

        // PUT: api/Technologies/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        [Authorize(Policy = "update")]
        public async Task<IActionResult> PutTechnology(int id, Technology technology)
        {
            if (id != technology.Id)
            {
                return BadRequest();
            }

            bool didUpdate = await repository.UpdateAsync(technology);

            if (didUpdate == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Technologies
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Authorize(Policy = "create")]
        public async Task<ActionResult<Technology>> PostTechnology(Technology technology)
        {
            await repository.CreateAsync(technology);

            return CreatedAtAction("GetTechnology", new { id = technology.Id }, technology);
        }

        // DELETE: api/Technologies/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "delete")]
        public async Task<ActionResult<Technology>> DeleteTechnology(int id)
        {
            var technology = await repository.DeleteAsync(id);

            if (technology == null)
            {
                return NotFound();
            }

            return technology;
        }
    }
}