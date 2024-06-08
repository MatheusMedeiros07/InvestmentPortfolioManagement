using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InvestmentPortfolioManagement.Dtos;
using InvestmentPortfolioManagement.Entities;
using InvestmentPortfolioManagement.Repositories;
using InvestmentPortfolioManagement.Repositories.Interfaces;
using InvestmentPortfolioManagement.Services.Interfaces;

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
    }
}
