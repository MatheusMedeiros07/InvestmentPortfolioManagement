using InvestmentPortfolioManagement.Dtos.Investment;
using InvestmentPortfolioManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortfolioManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestmentController : ControllerBase
    {
        private readonly IInvestmentService _investmentService;

        public InvestmentController(IInvestmentService investmentService)
        {
            _investmentService = investmentService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<InvestmentDto>>> GetAllInvestmentsByCustomerId(int id)
        {
            var investments = await _investmentService.GetAllInvestmentsByCustomerIdAsync(id);
            return Ok(investments);
        }

        [HttpPost]
        public async Task<ActionResult> AddInvestment(InvestmentDto investmentDto)
        {
            await _investmentService.AddInvestmentAsync(investmentDto);
            return CreatedAtAction(nameof(AddInvestment), new { id = investmentDto.Id }, investmentDto);
        }

    }
}
