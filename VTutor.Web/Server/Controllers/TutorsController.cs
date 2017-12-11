using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VTutor.Model;
using VTutor.Web.Server.Data;

namespace VTutor.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Tutors")]
    public class TutorsController : Controller
    {
        private readonly VTutorWebContext _context;

        public TutorsController(VTutorWebContext context)
        {
            _context = context;
        }

        // GET: api/Tutors
        [HttpGet]
        public IEnumerable<Tutor> GetTutor()
        {
            return _context.Tutor;
        }

        // GET: api/Tutors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTutor([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tutor = await _context.Tutor.SingleOrDefaultAsync(m => m.id == id);

            if (tutor == null)
            {
                return NotFound();
            }

            return Ok(tutor);
        }

        // PUT: api/Tutors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTutor([FromRoute] Guid id, [FromBody] Tutor tutor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tutor.id)
            {
                return BadRequest();
            }

            _context.Entry(tutor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tutors
        [HttpPost]
        public async Task<IActionResult> PostTutor([FromBody] Tutor tutor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tutor.Add(tutor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTutor", new { id = tutor.id }, tutor);
        }

        // DELETE: api/Tutors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTutor([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tutor = await _context.Tutor.SingleOrDefaultAsync(m => m.id == id);
            if (tutor == null)
            {
                return NotFound();
            }

            _context.Tutor.Remove(tutor);
            await _context.SaveChangesAsync();

            return Ok(tutor);
        }

        private bool TutorExists(Guid id)
        {
            return _context.Tutor.Any(e => e.id == id);
        }
    }
}