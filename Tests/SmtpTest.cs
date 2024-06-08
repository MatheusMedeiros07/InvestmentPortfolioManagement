using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace InvestmentPortfolioManagement.Tests
{
    public static class SmtpTest
    {
        public static void RunTest()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var emailSettings = configuration.GetSection("EmailSettings").Get<EmailSettings>();

            var client = new SmtpClient(emailSettings.SmtpServer, emailSettings.SmtpPort)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(emailSettings.SmtpUsername, emailSettings.SmtpPassword),
                EnableSsl = true
            };

            var message = new MailMessage(emailSettings.FromEmail, "matheusmedeirosfps@gmail.com")
            {
                Subject = "Teste de Envio",
                Body = "Este é um teste de envio de e-mail."
            };

            try
            {
                client.Send(message);
                Console.WriteLine("Email enviado com sucesso!");
            }
            catch (SmtpException ex)
            {
                Console.WriteLine($"Erro ao enviar e-mail: {ex.Message}");
                Console.WriteLine($"Status Code: {ex.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro geral: {ex.Message}");
            }
        }
    }

    public class EmailSettings
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public string FromEmail { get; set; }
    }
}
