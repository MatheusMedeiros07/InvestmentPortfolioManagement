using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using InvestmentPortfolioManagement.Services.Interfaces;
using Microsoft.Extensions.Options;
using InvestmentPortfolioManagement.Configuration;
using InvestmentPortfolioManagement.Dtos.Product;

namespace InvestmentPortfolioManagement.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly IProductService _productService;

        public EmailService(IOptions<EmailSettings> emailSettings, IProductService productService)
        {
            _emailSettings = emailSettings.Value;
            _productService = productService;
        }

        public async Task SendDailyNotificationsAsync(List<string> adminEmails)
        {
            try
            {
                var products = await _productService.GetProductsNearExpiry(7);

                if (products.Any())
                {
                    string subject = "Relatório de Produtos próximos da data de Expiração";
                    string body = BuildEmailBody(products);

                    foreach (var adminEmail in adminEmails)
                    {
                        using (var client = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.SmtpPort)
                        {
                            Credentials = new NetworkCredential(_emailSettings.SmtpUsername, _emailSettings.SmtpPassword),
                            EnableSsl = true
                        })
                        {
                            var mailMessage = new MailMessage
                            {
                                From = new MailAddress(_emailSettings.FromEmail),
                                Subject = subject,
                                Body = body,
                                IsBodyHtml = true,
                            };
                            mailMessage.To.Add(adminEmail);

                            await client.SendMailAsync(mailMessage);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }

        private string BuildEmailBody(List<ProductDto> products)
        {
            var sb = new StringBuilder();
            sb.Append("<h2>Olá Administradores do Sistema de Gestão de Portfólio de Investimentos.</h2>");
            sb.Append("<h3>Segue abaixo o Relatório contendo os produtos que vão expirar nós próximos 7 dias! Atenção, fique atento aos prazos de expiração.</h2>/n");
            sb.Append("<table style='border-collapse: collapse; width: 100%;'>");
            sb.Append("<tr>");
            sb.Append("<th style='border: 1px solid black; padding: 8px;'>Nome</th>");
            sb.Append("<th style='border: 1px solid black; padding: 8px;'>Data de Expiração</th>");
            sb.Append("</tr>");

            foreach (var product in products)
            {
                sb.Append("<tr>");
                sb.Append($"<td style='border: 1px solid black; padding: 8px;'>{product.Name}</td>");
                sb.Append($"<td style='border: 1px solid black; padding: 8px;'>{product.ExpirationDate:dd-MM-yyyy}</td>");
                sb.Append("</tr>");
            }

            sb.Append("</table>");
            return sb.ToString();
        }
    }
}
