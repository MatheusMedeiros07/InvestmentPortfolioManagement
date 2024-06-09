using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InvestmentPortfolioManagement.Dtos.Customer;
using InvestmentPortfolioManagement.Dtos.Investment;
using InvestmentPortfolioManagement.Entities;
using InvestmentPortfolioManagement.Repositories;
using InvestmentPortfolioManagement.Repositories.Interfaces;
using InvestmentPortfolioManagement.Services.Interfaces;

namespace InvestmentPortfolioManagement.Services
{

    public class InvestmentService : IInvestmentService
    {
        private readonly IInvestmentRepository _investmentRepository;
        private readonly IMapper _mapper;

        public InvestmentService(IInvestmentRepository investmentRepository, IMapper mapper)
        {
            _investmentRepository = investmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InvestmentDto>> GetAllInvestmentsByCustomerIdAsync(int id)
        {
            var investments = await _investmentRepository.GetInvestmentsByCustomerIdAsync(id);
            if (investments == null)
                throw new KeyNotFoundException($"O Investmento do Cliente com ID: {id} não foi encontrado");

            return _mapper.Map<IEnumerable<InvestmentDto>>(investments);
        }

        public async Task AddInvestmentAsync(InvestmentDto investmentDto)
        {
            var investment = _mapper.Map<Investment>(investmentDto);
            await _investmentRepository.AddAsync(investment);
            investmentDto.Id = investment.Id; // Atualiza o ID no DTO
        }
    }
}
