using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bwg.DTO;
using Bwg.Services;
using Bwg.Utils;
using Bwg.DTO;
using Bwg.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bwg.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        [Route("/api/SendEmail")]
        public async Task<bool> FinishEmployeeContract([FromBody] EmailFormDTO emailSource)
        {
            try
            {
                string emailHtmlTemplate = System.IO.File.ReadAllText("EmailTemplates\\mailTemplate.html");

                string emailResponseTemplate = System.IO.File.ReadAllText("EmailTemplates\\responseTemplate.html");


                string emailBody = emailHtmlTemplate.Replace("{company}", emailSource.Company)
                 .Replace("{email}", emailSource.Email)
                 .Replace("{name}", emailSource.Name)
                 .Replace("{phone}", emailSource.Phone)
                 .Replace("{text}", emailSource.Text);

                string emailSubject = $@"Nowa wiadomość ze strony: {emailSource.Subject}";

                string responseBody = emailResponseTemplate.Replace("{text}", "Otrzymaliśmy Twoją wiadomość. Dostarczymy odpowiedź w ciągu 24 godzin!");

                string responseSubject = "BWG | Otrzymaliśmy Twoją wiadomość ze strony bwg.com.pl";

                NotificationEmailSender emailSender = new NotificationEmailSender();
                   
                await emailSender.SendEmailAsync("biuro@bwg.com.pl", emailSubject, emailBody);
                await emailSender.SendEmailAsync("s.g@bwg.com.pl", emailSubject, emailBody);

                await emailSender.SendEmailAsync(emailSource.Email, responseSubject, responseBody);


                return true;
            }
            catch (Exception)
            {
                //todo: add logging
                return false;
            }
        }

    }
}
