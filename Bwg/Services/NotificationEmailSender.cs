﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit;
using MimeKit;
using MailKit.Net.Smtp;

namespace Bwg.Services
{
    public class NotificationEmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            MimeMessage emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(subject, "site.notifications@bwg.com.pl"));
            emailMessage.To.Add(new MailboxAddress(subject, email));
            emailMessage.Subject = subject;

            BodyBuilder bodyBuilder = new BodyBuilder
            {
                HtmlBody = message
            };

            emailMessage.Body = bodyBuilder.ToMessageBody();

            using (SmtpClient client = new SmtpClient())
            {
                client.Connect("smtp.webio.pl", 587, false);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("site.notifications@bwg.com.pl", "Azanezege22@");
                await client.SendAsync(emailMessage);
                client.Dispose();
            }
 
        }
    }
}
