using Microsoft.AspNetCore.Identity.UI.Services;
using ResearchPortal.Areas.Identity.Configurations;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ResearchPortal.Areas.Identity.Services
{
    public class EmailService : IEmailSender
    {
        private readonly IEmailConfigurations _EmailConfiguration;

        public EmailService(IEmailConfigurations _emailConfiguration)
        {
            _EmailConfiguration = _emailConfiguration;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("mojjominion@gmail.com", "heylelouch0")
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress("account-security-noreply@gmail.com")
            };
            mailMessage.To.Add(email);
            mailMessage.Subject = subject;
            mailMessage.Body = htmlMessage;
            client.EnableSsl = true;
            return client.SendMailAsync(mailMessage);
        }
        public Task SendEmailUsingSendGridAsync(string email, string subject, string htmlMessage)
        {
            var apiKey = _EmailConfiguration.Password;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(_EmailConfiguration.FromEmail, _EmailConfiguration.FromUser);
            var to = new EmailAddress(email, email);
            var plainTextContent = "Please verify your email";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlMessage);
            var response = client.SendEmailAsync(msg);
            return response;
        }
    }
}
