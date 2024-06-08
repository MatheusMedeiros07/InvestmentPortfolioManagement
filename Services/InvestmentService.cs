using System.Collections.Generic;
using System.Threading.Tasks;
using InvestmentPortfolioManagement.Dtos;
using InvestmentPortfolioManagement.Entities;
using InvestmentPortfolioManagement.Repositories;
using InvestmentPortfolioManagement.Repositories.Interfaces;
using InvestmentPortfolioManagement.Services.Interfaces;

namespace InvestmentPortfolioManagement.Services
{
  
    public class InvestmentService : IInvestmentService
    {
        private readonly IInvestmentRepository _investmentRepository;

        public InvestmentService(IInvestmentRepository investmentRepository)
        {
            _investmentRepository = investmentRepository;
        }

        public async Task<IEnumerable<InvestmentDto>> GetAllInvestmentsAsync()
        {
            var investments = await _investmentRepository.GetAllAsync();
            return investments.Select(i => new InvestmentDto());
        }

        public async Task AddInvestmentAsync(InvestmentDto investmentDto)
        {
            var investment = new Investment();
            await _investmentRepository.AddAsync(investment);
        }
    }
}
