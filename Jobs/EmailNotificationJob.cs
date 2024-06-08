using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using InvestmentPortfolioManagement.Services.Interfaces;

namespace InvestmentPortfolioManagement.Jobs
{
    public class EmailNotificationJob : IJob
    {
        private readonly IServiceProvider _serviceProvider;

        public EmailNotificationJob(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                // Obter a lista de e-mails dos administradores (exemplo)
                var adminEmails = new List<string> { "matheusmedeiroswf@gmail.com", "matheusmedeirosfps@gmail.com" };

                // Chamar o método para enviar notificações diárias por e-mail
                await emailService.SendDailyNotificationsAsync(adminEmails);
            }
        }
    }
}
