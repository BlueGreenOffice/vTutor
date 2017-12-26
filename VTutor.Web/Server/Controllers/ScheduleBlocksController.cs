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
    public IEnumerable<ScheduleBlocks> GetScheduleBlock()
    {
      return _context.ScheduleBlocks;
    }

    // GET: api/ScheduleBlocks/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetScheduleBlock([FromRoute] Guid id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var scheduleBlock = await _context.ScheduleBlocks.SingleOrDefaultAsync(m => m.Id == id);

      if (scheduleBlock == null)
      {
        return NotFound();
      }

      return Ok(scheduleBlock);
    }

    // PUT: api/ScheduleBlocks/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutScheduleBlock([FromRoute] Guid id, [FromBody] ScheduleBlocks scheduleBlock)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != scheduleBlock.Id)
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
    public async Task<IActionResult> PostScheduleBlock([FromBody] ScheduleBlocks scheduleBlock)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _context.ScheduleBlocks.Add(scheduleBlock);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetScheduleBlock", new { id = scheduleBlock.Id }, scheduleBlock);
    }

    // DELETE: api/ScheduleBlocks/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteScheduleBlock([FromRoute] Guid id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var scheduleBlock = await _context.ScheduleBlocks.SingleOrDefaultAsync(m => m.Id == id);
      if (scheduleBlock == null)
      {
        return NotFound();
      }

      _context.ScheduleBlocks.Remove(scheduleBlock);
      await _context.SaveChangesAsync();

      return Ok(scheduleBlock);
    }

    private bool ScheduleBlockExists(Guid id)
    {
      return _context.ScheduleBlocks.Any(e => e.Id == id);
    }
  }
}
