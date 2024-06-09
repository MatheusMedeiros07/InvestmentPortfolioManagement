using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InvestmentPortfolioManagement.Entities;
using InvestmentPortfolioManagement.Data;
using InvestmentPortfolioManagement.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortfolioManagement.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
           return await _context.Products.FindAsync(productId);
        }

        public async Task<Product> AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> EditProductAsync(Product existingProduct, Product product)
        {
                // Marca a entidade como modificada
                _context.Entry(existingProduct).CurrentValues.SetValues(product);
                await _context.SaveChangesAsync();
                return true;
        }

        public async Task DeleteProductByIdAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsNearExpiryAsync(int days)
        {
            var thresholdDate = DateTime.Now.AddDays(days);
            return await _context.Products.Where(p => p.ExpirationDate <= thresholdDate).OrderBy(p => p.ExpirationDate).ToListAsync();
        }
    }
}
