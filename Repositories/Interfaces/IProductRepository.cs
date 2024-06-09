using System.Collections.Generic;
using System.Threading.Tasks;
using InvestmentPortfolioManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortfolioManagement.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task AddAsync(Product product);
        Task<bool> EditProductAsync(Product existingProduct, Product product);
        Task DeleteProductByIdAsync(Product product);
        Task<IEnumerable<Product>> GetProductsNearExpiryAsync(int days);
    }
}
