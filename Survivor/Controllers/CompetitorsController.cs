using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Survivor.Data;
using Survivor.Data.Entities;

namespace Survivor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorsController : ControllerBase
    {
        private readonly SurvivorDbContext _context;

        public CompetitorsController(SurvivorDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Competitors.Include(c => c.Category).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var competitor = await _context.Competitors.Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == id);
            if (competitor == null) return NotFound();
            return Ok(competitor);
        }

        [HttpGet("categories/{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            var competitors = await _context.Competitors.Where(c => c.CategoryId == categoryId).ToListAsync();
            return Ok(competitors);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Competitor competitor)
        {
            _context.Competitors.Add(competitor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = competitor.Id }, competitor);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Competitor competitor)
        {
            if (id != competitor.Id) return BadRequest();

            _context.Entry(competitor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var competitor = await _context.Competitors.FindAsync(id);
            if (competitor == null) return NotFound();

            _context.Competitors.Remove(competitor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
