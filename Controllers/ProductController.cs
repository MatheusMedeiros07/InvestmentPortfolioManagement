using AutoMapper;
using InvestmentPortfolioManagement.Dtos.Product;
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

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] ProductInsertDto productDto)
        {
            var result = await _productService.AddProductAsync(productDto);
            return CreatedAtAction(nameof(AddProduct), new { id = result.Id }, result);
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
