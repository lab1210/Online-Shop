using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
namespace Online_Shopping.Service
{
    public class EmailService
    {
        private readonly SmtpClient _smtpClient;

        public EmailService(string smtpHost, int smtpPort, string smtpUsername, string smtpPassword)
        {
            _smtpClient = new SmtpClient();
            _smtpClient.Connect(smtpHost, smtpPort, SecureSocketOptions.StartTls);
            _smtpClient.Authenticate(smtpUsername, smtpPassword);
        }

        public void SendConfirmationEmail(string driverEmail, string customerName)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Your Application", "yourapp@example.com"));
            message.To.Add(new MailboxAddress("Driver",driverEmail));
            message.Subject = "Package Assignment Confirmation";

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = $"Dear Driver,\n\nYou have been assigned to deliver a package to {customerName}.\n\nBest Regards,\nYour Application Team";

            message.Body = bodyBuilder.ToMessageBody();

            _smtpClient.Send(message);
            _smtpClient.Disconnect(true);
        }
    }
}