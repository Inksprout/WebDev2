using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CineplexWebsite.Models;
using System.Net;
using System.Net.Mail;
namespace CineplexWebsite.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(Event model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("abccineplex@outlook.com"));  // receiver email
                message.From = new MailAddress("abccineplex@outlook.com");  // sennder email
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.senderName, model.senderEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "abccineplex@outlook.com",  //sender email authentication
                        Password = "abc@cineplex"  
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }
        public ActionResult Sent()
        {
            return View();
        }
    }
}
