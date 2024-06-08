using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using InvestmentPortfolioManagement.Services.Interfaces;
using InvestmentPortfolioManagement.Configuration;

namespace InvestmentPortfolioManagement.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendDailyNotificationsAsync(List<string> adminEmails)
        {
            foreach (var adminEmail in adminEmails)
            {
                using (var client = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.SmtpPort))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(_emailSettings.SmtpUsername, _emailSettings.SmtpPassword);
                    client.EnableSsl = true;  

                    using (var message = new MailMessage(_emailSettings.FromEmail, adminEmail))
                    {
                        message.Subject = "Notification: Investment Expiry";
                        message.Body = "Dear Administrator, this is a notification regarding investment expiry.";
                        await client.SendMailAsync(message);
                    }
                }
            }
        }
    }
}
