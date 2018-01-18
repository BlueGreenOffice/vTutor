using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VTutor.Model;


namespace VTutor.Web.Controllers
{
  [Produces("application/json")]
  [Route("api/Students")]
	[System.Web.Http.Authorize(Roles = "Admin")]
	public class StudentsController : Controller
  {
    private readonly VTutorContext _context;

    public StudentsController(VTutorContext context)
    {
      _context = context;
    }

    // GET: api/Students
    [HttpGet]
    public IEnumerable<Student> GetStudent()
    {
      return _context.Students;
    }

    // GET: api/Students/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudent([FromRoute] Guid id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var student = await _context.Students.SingleOrDefaultAsync(m => m.Id == id);

      if (student == null)
      {
        return NotFound();
      }

      return Ok(student);
    }

    // PUT: api/Students/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutStudent([FromRoute] Guid id, [FromBody] Student student)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != student.Id)
      {
        return BadRequest();
      }

      _context.Entry(student).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!StudentExists(id))
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

    // POST: api/Students
    [HttpPost]
    public async Task<IActionResult> PostStudent([FromBody] Student student)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _context.Students.Add(student);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetStudent", new { id = student.Id }, student);
    }

    // DELETE: api/Students/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent([FromRoute] Guid id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var student = await _context.Students.SingleOrDefaultAsync(m => m.Id == id);
      if (student == null)
      {
        return NotFound();
      }

      _context.Students.Remove(student);
      await _context.SaveChangesAsync();

      return Ok(student);
    }

    private bool StudentExists(Guid id)
    {
      return _context.Students.Any(e => e.Id == id);
    }
  }
}
