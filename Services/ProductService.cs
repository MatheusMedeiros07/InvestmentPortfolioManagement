using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InvestmentPortfolioManagement.Dtos;
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

        public async Task AddProductAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.AddAsync(product);
            productDto.Id = product.Id; // Atualiza o ID no DTO
        }

        public async Task<ProductDto> EditProductAsync(int id, ProductUpdateDto productDto)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(id);
            if (existingProduct == null)
                throw new ArgumentNullException($"O produto com ID: {id} não foi encontrado");

            var productUpdate = _mapper.Map<Product>(productDto, opts => opts.Items["Id"] = id);
            var result = await _productRepository.EditProductAsync(existingProduct, productUpdate);
            if (result)
            {
                return _mapper.Map<ProductDto>(await _productRepository.GetProductByIdAsync(id));
            }
            else
            {
                throw new Exception("Erro ao atualizar o produto");
            }
            

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
