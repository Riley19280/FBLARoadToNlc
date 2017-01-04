using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace yardSaleWCF
{
	public class mailing
	{
		public static void sendMail(string to, string subject, string message)
		{
			string smtpAddress = "smtp.gmail.com";
			int portNumber = 587;

			string emailFrom = Constants.emailAddress;
			string password = Constants.emailPassword;
			string emailTo = to;

			MailMessage mail = new MailMessage();

			mail.From = new MailAddress(emailFrom);
			mail.To.Add(emailTo);
			mail.Subject = subject;
			mail.Body = portNumber.ToString()+ message;
			mail.IsBodyHtml = false;// Can set to false, if you are sending pure text.

			SmtpClient smtp = new SmtpClient(smtpAddress, portNumber);
			
			smtp.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
			smtp.UseDefaultCredentials = true;
			smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtp.Credentials = new NetworkCredential(emailFrom, password);
			smtp.EnableSsl = true;
			smtp.Send(mail);
			smtp.Dispose();
			mail.Dispose();

		}

		private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
		{
			// Get the unique identifier for this asynchronous operation.
			var token = e.UserState;

			if (e.Cancelled)
			{
				Console.WriteLine("[{0}] Send canceled.", token);
			}
			if (e.Error != null)
			{
				Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
			}
			else
			{
				Console.WriteLine("Message sent.");
			}
		}
	}
}