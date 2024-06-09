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

        [HttpGet("GetAllInvestmentsByCustomerId/{id}")]
        public async Task<ActionResult<IEnumerable<InvestmentDto>>> GetAllInvestmentsByCustomerId(int id, [FromQuery] bool? isActive)
        {
            var investments = await _investmentService.GetAllInvestmentsByCustomerIdAsync(id, isActive);
            return Ok(investments);
        }

        [HttpPost]
        public async Task<ActionResult> CreateInvestment([FromBody] InvestmentCreateDto investmentCreateDto)
        {
            try
            {
                var investment = await _investmentService.CreateInvestmentAsync(investmentCreateDto);
                return CreatedAtAction(nameof(CreateInvestment), new { message = "Investimento realizado com sucesso!!" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("sell/{id}")]
        public async Task<ActionResult<InvestmentDto>> SellInvestment(int id)
        {
            try
            {
                var investment = await _investmentService.SellInvestmentAsync(id);
                return Ok(investment);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


    }
}
