using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VTutor.Email.TemplateModels;


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

        public static void SendEmail(string toEmail, string subject, string body)
        {

            string bodyText = String.Empty;



            using (StreamReader sr = new StreamReader(AssemblyDirectory + "/EmailTemplates/email-template.html"))
            {
                bodyText = sr.ReadToEnd();
            }

            //This is the knowtro do not reply address...
            var fromAddress = new MailAddress("cummingsi1993@gmail.com", "ME");
            var toAddress = new MailAddress(toEmail);
            const string fromPassword = "I1M9a9n3";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("cummingsi1993@gmail.com", fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                //IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }

        }

        private const string DO_NOT_REPLY_EMAIL = "cummingsi1993@gmail.com";
        private const string FROM_NAME = "ME";


        //public static void SendNewsletter(Newsletter newsletter, AppUser[] mailingList)
        //{
        //    foreach (AppUser user in mailingList)
        //    {
        //        newsletter.firstName = user.FirstName;
        //        newsletter.lastName = user.LastName;
        //        newsletter.userId = user.id.ToString();
        //        sendMail(BuildEmail<Newsletter>(newsletter, AssemblyDirectory + "/EmailTemplates/newsletter-template.cshtml", "Knowtro's Weekly Dose of Learning - " + DateTime.Today.ToString("M/d/yyyy"), user.Email, user.FirstName + " " + user.LastName));
        //    }
        //}

        /// <summary>
        /// Basic Templating using email-template. SMTP settings are pulled from the client's App.config. 
        /// Made it easer to test locally without affecting the mail server's status.
        /// </summary>
        /// <param name="model">
        /// Email DTO for basic templating. For Future work, we may want to interface this. 
        /// </param>
        public static void SendPersonalEmail(Basic model)
        {
            sendMail(BuildEmail<Basic>(model, AssemblyDirectory + "/EmailTemplates/email-template.cshtml", model.Subject, model.Email, model.Name));
        }

		public static void SendTutorInterestEmail(TutorContactForm model)
		{
			sendMail(BuildEmail<TutorContactForm>(model, AssemblyDirectory + "/EmailTemplates/tutor-contact.cshtml", model.Subject, "Isaac@Knowtro.com", "Isaac"));
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
        private static MailMessage BuildEmail<T>(T model, string templatePath, string subject, string recipientEmail, string recipientName)
        {
            var emailContentTask = EmailTemplateFactory.BasicTemplate(model, templatePath);

			emailContentTask.Wait();
			var emailContent = emailContentTask.Result;

            var message = new MailMessage()
            {
                Subject = subject,
                Body = emailContent,
                IsBodyHtml = true
            };
            message.From = new MailAddress(DO_NOT_REPLY_EMAIL, FROM_NAME);
            message.To.Add(new MailAddress(recipientEmail, recipientName));
            return message;
        }

        private static void sendMail(MailMessage message)
        {
			const string fromPassword = "I1M9a9n3";
			var smtp = new SmtpClient
			{
				Host = "smtp.gmail.com",
				Port = 587,
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential("cummingsi1993@gmail.com", fromPassword)
			};

			smtp.Send(message);
        }

        private static Task sendMailAsync(MailMessage message)
        {
            var smtp = new SmtpClient();

            return smtp.SendMailAsync(message);
        }
        #endregion
    }
}
