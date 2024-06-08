using System.Collections.Generic;
using System.Threading.Tasks;
using InvestmentPortfolioManagement.Entities;

namespace InvestmentPortfolioManagement.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
    }
}
