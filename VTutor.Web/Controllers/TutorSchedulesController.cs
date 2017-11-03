using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VTutor.Model;
using VTutor.Web.Models;

namespace VTutor.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/TutorSchedules")]
    public class TutorSchedulesController : Controller
    {
        private readonly VTutorWebContext _context;

        public TutorSchedulesController(VTutorWebContext context)
        {
            _context = context;
        }

        // GET: api/TutorSchedules
        [HttpGet]
        public IEnumerable<TutorSchedule> GetTutorSchedule()
        {
            return _context.TutorSchedule;
        }

        // GET: api/TutorSchedules/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTutorSchedule([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tutorSchedule = await _context.TutorSchedule.SingleOrDefaultAsync(m => m.id == id);

            if (tutorSchedule == null)
            {
                return NotFound();
            }

            return Ok(tutorSchedule);
        }

        // PUT: api/TutorSchedules/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTutorSchedule([FromRoute] Guid id, [FromBody] TutorSchedule tutorSchedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tutorSchedule.id)
            {
                return BadRequest();
            }

            _context.Entry(tutorSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorScheduleExists(id))
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

        // POST: api/TutorSchedules
        [HttpPost]
        public async Task<IActionResult> PostTutorSchedule([FromBody] TutorSchedule tutorSchedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TutorSchedule.Add(tutorSchedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTutorSchedule", new { id = tutorSchedule.id }, tutorSchedule);
        }

        // DELETE: api/TutorSchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTutorSchedule([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tutorSchedule = await _context.TutorSchedule.SingleOrDefaultAsync(m => m.id == id);
            if (tutorSchedule == null)
            {
                return NotFound();
            }

            _context.TutorSchedule.Remove(tutorSchedule);
            await _context.SaveChangesAsync();

            return Ok(tutorSchedule);
        }

        private bool TutorScheduleExists(Guid id)
        {
            return _context.TutorSchedule.Any(e => e.id == id);
        }
    }
}