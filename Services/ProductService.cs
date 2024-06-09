using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InvestmentPortfolioManagement.Dtos.Product;
using InvestmentPortfolioManagement.Entities;
using InvestmentPortfolioManagement.Repositories;
using InvestmentPortfolioManagement.Repositories.Interfaces;
using InvestmentPortfolioManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortfolioManagement.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
                throw new KeyNotFoundException($"O produto com ID: {id} não foi encontrado");

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<Product> AddProductAsync(ProductInsertDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            return await _productRepository.AddAsync(product);
        }

        public async Task<ProductDto> EditProductAsync(int id, ProductUpdateDto productDto)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(id);
            if (existingProduct == null)
                throw new KeyNotFoundException($"O produto com ID: {id} não foi encontrado");

            var productUpdate = _mapper.Map<Product>(productDto, opts => opts.Items["Id"] = id);
            var sucess = await _productRepository.EditProductAsync(existingProduct, productUpdate);
            if (!sucess)
                throw new Exception("Erro ao atualizar o produto");

            return _mapper.Map<ProductDto>(await _productRepository.GetProductByIdAsync(id));
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);

            if (product == null)
                return false;
            
            await _productRepository.DeleteProductByIdAsync(product);
            return true;
        }

        public async Task <List<ProductDto>> GetProductsNearExpiry(int days)
        {
            var products = await _productRepository.GetProductsNearExpiryAsync(days);
            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
