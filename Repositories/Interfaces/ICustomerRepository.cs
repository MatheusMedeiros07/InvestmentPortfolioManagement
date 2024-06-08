using System.Collections.Generic;
using System.Threading.Tasks;
using InvestmentPortfolioManagement.Entities;

namespace InvestmentPortfolioManagement.Repositories.Interfaces
{

    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task AddAsync(Customer customer);
    }
}
