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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvestmentDto>>> GetAllInvestments()
        {
            var investments = await _investmentService.GetAllInvestmentsAsync();
            return Ok(investments);
        }

        [HttpPost]
        public async Task<ActionResult> AddInvestment(InvestmentDto investmentDto)
        {
            await _investmentService.AddInvestmentAsync(investmentDto);
            return CreatedAtAction(nameof(GetAllInvestments), new { id = investmentDto.Id }, investmentDto);
        }

    }
}
