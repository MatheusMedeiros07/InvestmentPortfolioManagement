using InvestmentPortfolioManagement.Dtos;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpPost]
        public async Task<ActionResult> AddCustomer(CustomerDto customerDto)
        {
            await _customerService.AddCustomerAsync(customerDto);
            return CreatedAtAction(nameof(GetAllCustomers), new { id = customerDto.Id }, customerDto);
        }
    }
}
