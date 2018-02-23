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

		public EmailController()
		{

		}

		[HttpPost]
		[Route("tutor-interest")]
		public async Task<IActionResult> TutorContactForm([FromBody]Email.TemplateModels.TutorContactForm form)
		{
			Email.EmailClient.SendTutorInterestEmail(form);
			return Ok();
		}



    }
}
