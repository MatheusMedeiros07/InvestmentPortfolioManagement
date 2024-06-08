using Quartz;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvestmentPortfolioManagement.Services.Interfaces;

namespace InvestmentPortfolioManagement.Jobs
{
    public class EmailNotificationJob : IJob
    {
        private readonly IEmailService _emailService;

        public EmailNotificationJob(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            List<string> adminEmails = new List<string>
            {
                "matheusmedeiroswf@gmail.com",
                "matheusmedeirosfps@gmail.com"
                // Adicione mais e-mails de administradores conforme necessário
            };

            await _emailService.SendDailyNotificationsAsync(adminEmails);
        }
    }
}
