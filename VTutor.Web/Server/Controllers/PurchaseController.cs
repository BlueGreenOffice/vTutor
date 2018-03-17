using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Braintree;
using Microsoft.AspNetCore.Identity;
using VTutor.Model;

namespace VTutor.Web.Controllers
{

	public class ClientToken
	{
		public string token { get; set; }

		public ClientToken(string token)
		{
			this.token = token;
		}
	}

	public class Nonce
	{
		public string nonce { get; set; }
		public decimal chargeAmount { get; set; }

		public Nonce(string nonce)
		{
			this.nonce = nonce;
			this.chargeAmount = chargeAmount;
		}
	}


	[Produces("application/json")]
    [Route("api/Purchase")]
    public class PurchaseController : Controller
    {
		/// <summary>
		/// User manager - attached to application DB context
		/// </summary>
		protected UserManager<ApplicationUser> UserManager { get; set; }
		private readonly VTutorContext _context;
		private readonly IConfiguration _configuration;

		public PurchaseController(IConfiguration configuration, VTutorContext context, UserManager<ApplicationUser> userManager)
		{
			_configuration = configuration;
			_context = context;
			this.UserManager = userManager;
		}

		[HttpGet]
		[Route("getclienttoken")]
		public async Task<IActionResult> GetClientToken()
		{
			var gateway = new BraintreeGateway
			{
				Environment = Braintree.Environment.SANDBOX,
				MerchantId = "z6qjm7h62x79j3n9",
				PublicKey = "nrp3h97h7brd6s99",
				PrivateKey = "c28a54a9c4fed5e4058197d2787380c9"
			};

			var clientToken = gateway.ClientToken.Generate();
			ClientToken ct = new ClientToken(clientToken);
			return Ok(ct);
		}


		public class Nonce
		{
			public string nonce { get; set; }
			public decimal chargeAmount { get; set; }

			public Nonce(string nonce)
			{
				this.nonce = nonce;
				this.chargeAmount = chargeAmount;
			}
		}

		[HttpPost]
		[Route("createPurchase")]
		public async Task<IActionResult> PurchaseSession([FromQuery]DateTime startDate, [FromQuery]string promo, [FromBody]Nonce nonce)
		{
			var user = await this.UserManager.GetUserAsync(this.User);

			if (user == null)
			{
				return StatusCode(401);
			}

			var student = _context.Students.Where(s => s.Email == user.Email).FirstOrDefault();

			if (student == null )
			{
				return BadRequest("Tutors are not allowed to request sessions.");
			}
			
			var gateway = new BraintreeGateway
			{
				Environment = Braintree.Environment.SANDBOX,
				MerchantId = "z6qjm7h62x79j3n9",
				PublicKey = "nrp3h97h7brd6s99",
				PrivateKey = "c28a54a9c4fed5e4058197d2787380c9"
			};

			var request = new TransactionRequest
			{
				Amount = nonce.chargeAmount,
				PaymentMethodNonce = nonce.nonce,
				Options = new TransactionOptionsRequest
				{
					SubmitForSettlement = true
				}
			};

			Result<Transaction> result = await gateway.Transaction.SaleAsync(request);


			if (result.IsSuccess())
			{
				_context.Appointments.Add(new Appointment()
				{
					StartTime = startDate,
					EndTime = startDate.AddHours(1),
					Student = student,
					Tutor = null
				});

				await _context.SaveChangesAsync();

				//session is booked WOOT
			}

			return Ok(result);
		}


    }
}
