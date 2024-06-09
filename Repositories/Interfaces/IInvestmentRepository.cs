using System.Collections.Generic;
using System.Threading.Tasks;
using InvestmentPortfolioManagement.Entities;

namespace InvestmentPortfolioManagement.Repositories.Interfaces
{

    public interface IInvestmentRepository
    {
        Task<IEnumerable<Investment>> GetInvestmentsByCustomerIdAsync(int customerId);
        Task AddAsync(Investment investment);
    }
}
