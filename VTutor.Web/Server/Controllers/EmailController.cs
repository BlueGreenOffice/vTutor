using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VTutor.Model;
using Microsoft.AspNetCore.Authorization;

namespace VTutor.Web.Server.Controllers
{
	[Produces("application/json")]
	[Route("api/Emails")]
	public class EmailController : Controller
	{
		private readonly VTutorContext _context;
		public EmailController(VTutorContext context)
		{
			_context = context;
		}

		[HttpPost]
		[Route("tutor-interest")]
		public async Task<IActionResult> TutorContactForm([FromBody]Email.TemplateModels.TutorContactForm form)
		{
			try
			{
				string response = await Email.EmailClient.SendTutorInterestEmail(form);
				_context.DatabaseLogs.Add(new DatabaseLog() { Date = DateTime.Now, LogMessage = response, Error = false });
				return Ok(response);
			}
			catch (Exception ex)
			{
				_context.DatabaseLogs.Add(new DatabaseLog() { Date = DateTime.Now, LogMessage = ex.ToString(), Error = true });
				return StatusCode(500, ex);
			}
			finally
			{
				await _context.SaveChangesAsync();
			}
		}



    }
}
