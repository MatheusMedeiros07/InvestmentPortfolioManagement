using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvestmentPortfolioManagement.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendDailyNotificationsAsync(List<string> adminEmails);
    }
}
