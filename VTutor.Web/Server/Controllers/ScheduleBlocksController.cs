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
    [Route("api/ScheduleBlocks")]
    public class ScheduleBlocksController : Controller
    {
        private readonly VTutorWebContext _context;

        public ScheduleBlocksController(VTutorWebContext context)
        {
            _context = context;
        }

        // GET: api/ScheduleBlocks
        [HttpGet]
        public IEnumerable<ScheduleBlock> GetScheduleBlock()
        {
            return _context.ScheduleBlock;
        }

        // GET: api/ScheduleBlocks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetScheduleBlock([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var scheduleBlock = await _context.ScheduleBlock.SingleOrDefaultAsync(m => m.id == id);

            if (scheduleBlock == null)
            {
                return NotFound();
            }

            return Ok(scheduleBlock);
        }

        // PUT: api/ScheduleBlocks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScheduleBlock([FromRoute] Guid id, [FromBody] ScheduleBlock scheduleBlock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != scheduleBlock.id)
            {
                return BadRequest();
            }

            _context.Entry(scheduleBlock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleBlockExists(id))
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

        // POST: api/ScheduleBlocks
        [HttpPost]
        public async Task<IActionResult> PostScheduleBlock([FromBody] ScheduleBlock scheduleBlock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ScheduleBlock.Add(scheduleBlock);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScheduleBlock", new { id = scheduleBlock.id }, scheduleBlock);
        }

        // DELETE: api/ScheduleBlocks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScheduleBlock([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var scheduleBlock = await _context.ScheduleBlock.SingleOrDefaultAsync(m => m.id == id);
            if (scheduleBlock == null)
            {
                return NotFound();
            }

            _context.ScheduleBlock.Remove(scheduleBlock);
            await _context.SaveChangesAsync();

            return Ok(scheduleBlock);
        }

        private bool ScheduleBlockExists(Guid id)
        {
            return _context.ScheduleBlock.Any(e => e.id == id);
        }
    }
}