using InvestmentPortfolioManagement.Dtos.Customer;
using InvestmentPortfolioManagement.Dtos.Product;
using InvestmentPortfolioManagement.Services;
using InvestmentPortfolioManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortfolioManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetAllCustomers")]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(id);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddCustomer(CustomerInsertDto customerDto)
        {
            var result = await _customerService.AddCustomerAsync(customerDto);
            return CreatedAtAction(nameof(GetAllCustomers), new { id = result.Id }, customerDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCustomer(int id, [FromBody] CustomerUpdateDto customerDto)
        {

            try
            {
                var updatedCustomer = await _customerService.EditCustomerAsync(id, customerDto);
                return Ok(updatedCustomer);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
