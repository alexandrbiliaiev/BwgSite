using Bwg.DTO;
using Bwg.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bwg.Services
{
    public class SiteNotificationBodyBuilder
    {
       public string BuildBody(EmailFormDTO email)
        {
            string environmentPath = EnvironmentUtil.Environment.WebRootPath;

           string emailHtmlTemplate = File.ReadAllText(environmentPath + "\\EmailTemplates\\mailTemplate.html");

            /*string body = "Firma: " + _email.Company + Environment.NewLine +
                "E-mail: " + _email.Email + Environment.NewLine +
                "Imie: " + _email.Name + Environment.NewLine +
                "Telefon: " + _email.Phone + Environment.NewLine +
                "Treść: " + _email.Text + Environment.NewLine; */


               string body = emailHtmlTemplate.Replace("{company}", email.Company)
                .Replace("{email}", email.Email)
                .Replace("{name}", email.Name)
                .Replace("{phone}", email.Phone)
                .Replace("{text}", email.Text); 
            return body;
        }

        public string BuildSubject(EmailFormDTO email)
        {
            string subject = $@"Nowa wiadomość ze strony: {email.Subject}";
            return subject;
        }
    }
}
