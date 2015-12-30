using System.Net.Mail;
using EmailApp.Models;
using Mvc.Mailer;

namespace EmailApp.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailMessageVM emailMessage);
    }

    public class EmailService : MailerBase, IEmailService
    {
        public void SendEmail(EmailMessageVM emailMessage)
        {
            ViewBag.Body = emailMessage.Body;

            var mvcMailMessage = Populate(x =>
            {
                x.From = new MailAddress(emailMessage.FromEmail);
                x.Subject = emailMessage.Subject;
                x.ViewName = "Index";
                x.To.Add(emailMessage.ToEmail);
            });

            mvcMailMessage.SendAsync();
        }
    }
}