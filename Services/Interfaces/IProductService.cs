using System.Collections.Generic;
using System.Threading.Tasks;
using InvestmentPortfolioManagement.Dtos.Product;
using InvestmentPortfolioManagement.Entities;

namespace InvestmentPortfolioManagement.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<Product> AddProductAsync(ProductInsertDto productDto);
        Task<bool> DeleteProductAsync(int productId);
        Task<ProductDto> EditProductAsync(int id, ProductUpdateDto productDto);
        Task <List<ProductDto>> GetProductsNearExpiry(int days);
    }
}
