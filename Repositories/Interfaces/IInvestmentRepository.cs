using System.Collections.Generic;
using System.Threading.Tasks;
using InvestmentPortfolioManagement.Entities;

namespace InvestmentPortfolioManagement.Repositories.Interfaces
{

    public interface IInvestmentRepository
    {
        Task<Investment> GetInvestmentByIdAsync(int id);
        Task<IEnumerable<Investment>> GetInvestmentsByCustomerIdAsync(int customerId, bool? isActive);
        Task<bool> AddInvestmentAsync(Investment investment);
        Task UpdateInvestmentAsync(Investment investment);
    }
}
