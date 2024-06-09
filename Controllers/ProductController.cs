using AutoMapper;
using InvestmentPortfolioManagement.Dtos;
using InvestmentPortfolioManagement.Entities;
using InvestmentPortfolioManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductById(int id)
        {
            var result = await _productService.DeleteProductAsync(id);
            if(!result)
                return NotFound(new { message = "Produto não encontrado" });


            return Ok(new { message = "Produto excluído com sucesso" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct(int id, [FromBody] ProductUpdateDto productDto)
        {

            var updatedProduct = await _productService.EditProductAsync(id, productDto);

            if (updatedProduct == null)
            {
                return NotFound(new { message = "Produto não foi encontrado" });
            }

            return Ok(updatedProduct);
        }
    }
}
