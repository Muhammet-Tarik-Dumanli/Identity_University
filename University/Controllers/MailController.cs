using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace University.Controllers
{
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Mail mail)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                mail.Sender = "*******@gmail.com";
                mail.Reciever = "*******@gmail.com";
                message.From = new MailAddress(mail.Sender);
                message.To.Add(new MailAddress(mail.Reciever));
                message.Subject = mail.Subject;
                message.IsBodyHtml = true;
                message.Body = mail.Body;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(mail.Sender, "**********");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {

            }

            return View();
        }
    }
}
