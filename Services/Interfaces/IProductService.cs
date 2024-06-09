using System.Collections.Generic;
using System.Threading.Tasks;
using InvestmentPortfolioManagement.Dtos;
using InvestmentPortfolioManagement.Entities;

namespace InvestmentPortfolioManagement.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task AddProductAsync(ProductDto productDto);
        Task<bool> DeleteProductAsync(int productId);
        Task<ProductDto> EditProductAsync(int id, ProductUpdateDto productDto);
        Task <List<ProductDto>> GetProductsNearExpiry(int days);
    }
}
