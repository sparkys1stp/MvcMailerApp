using System.Web.Mvc;
using EmailApp.Models;
using EmailApp.Services;
using Mvc.Mailer;

namespace EmailApp.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }

        public MvcMailMessage Email(EmailMessageVM model)
        {
            model.FromEmail = "test@account.com";
            model.Subject = "This is from our site";

            var emailService = new EmailService();

            emailService.SendEmail(model);

            return null;
        }
    }
}