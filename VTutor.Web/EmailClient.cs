using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VTutor.Email.TemplateModels;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace VTutor.Email
{
    public static class EmailClient
    {

        private static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        //public static void SendEmail(string toEmail, string subject, string body)
        //{

        //    string bodyText = String.Empty;



        //    using (StreamReader sr = new StreamReader(AssemblyDirectory + "/EmailTemplates/email-template.html"))
        //    {
        //        bodyText = sr.ReadToEnd();
        //    }

        //    //This is the knowtro do not reply address...
        //    var fromAddress = new MailAddress("cummingsi1993@gmail.com", "ME");
        //    var toAddress = new MailAddress(toEmail);
        //    const string fromPassword = "I1M9a9n3";



        //    //var smtp = new SmtpClient
        //    //{
        //    //    Host = "smtp.gmail.com",
        //    //    Port = 587,
        //    //    EnableSsl = true,
        //    //    DeliveryMethod = SmtpDeliveryMethod.Network,
        //    //    UseDefaultCredentials = false,
        //    //    Credentials = new NetworkCredential("cummingsi1993@gmail.com", fromPassword)
        //    //};

        //    //using (var message = new MailMessage(fromAddress, toAddress)
        //    //{
        //    //    Subject = subject,
        //    //    Body = body,
        //    //    //IsBodyHtml = true
        //    //})
        //    //{
        //    //    smtp.Send(message);
        //    //}

        //}

        private const string DO_NOT_REPLY_EMAIL = "cummingsi1993@gmail.com";
        private const string FROM_NAME = "VTutor Messages";

        /// <summary>
        /// Basic Templating using email-template. SMTP settings are pulled from the client's App.config. 
        /// Made it easer to test locally without affecting the mail server's status.
        /// </summary>
        /// <param name="model">
        /// Email DTO for basic templating. For Future work, we may want to interface this. 
        /// </param>
        public static async Task SendPersonalEmail(Basic model)
        {
            await sendMailAsync(BuildEmail<Basic>(model, AssemblyDirectory + "/EmailTemplates/email-template.cshtml", model.Subject, model.Email, model.Name));
        }

		public static async Task SendTutorInterestEmail(TutorContactForm model)
		{
			await sendMailAsync(BuildEmail<TutorContactForm>(model, AssemblyDirectory + "/EmailTemplates/tutor-contact.cshtml", "A Potential tutor is interested!", "Isaac@Knowtro.com", "Isaac"));
		}

        /// <summary>
        /// Asyncronous version of SendPersonalEmail. SMTP settings are pulled from the clients app.config
        /// </summary>
        /// <param name="model">
        /// Email DTO for basic templating. For future work, we may want to interface this.
        /// </param>
        public static Task SendPersonalEmailAsync(Basic model)
        {
            return sendMailAsync(BuildEmail<Basic>(model, AssemblyDirectory + "/EmailTemplates/email-template.cshtml", model.Subject, model.Email, model.Name));
        }

        #region Private implmentation details of SendPersonalEmail
        private static SendGridMessage BuildEmail<T>(T model, string templatePath, string subject, string recipientEmail, string recipientName)
        {
            var emailContentTask = EmailTemplateFactory.BasicTemplate(model, templatePath);

			emailContentTask.Wait();
			var emailContent = emailContentTask.Result;
			var message = new SendGridMessage();

            message.SetFrom(new EmailAddress(DO_NOT_REPLY_EMAIL, FROM_NAME));
            message.AddTo(new EmailAddress(recipientEmail, recipientName));

			message.SetSubject(subject);
			message.AddContent(MimeType.Html, emailContent);

            return message;
        }

        private static async Task sendMailAsync(SendGridMessage message)
        {
			var apiKey = System.Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
			var client = new SendGridClient(apiKey);
			
			var response = await client.SendEmailAsync(message);
			string responsebody = await response.Body.ReadAsStringAsync();
		}

        #endregion
    }
}
