using AutoMapper;
using InvestmentPortfolioManagement.Dtos;
using InvestmentPortfolioManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortfolioManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(ProductDto productDto)
        {
            await _productService.AddProductAsync(productDto);
            return CreatedAtAction(nameof(GetAllProducts), new { id = productDto.Id }, productDto);
        }

    }
}
