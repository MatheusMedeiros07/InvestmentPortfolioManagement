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
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public InvestmentService(IInvestmentRepository investmentRepository, IProductRepository productRepository, ICustomerRepository customerRepository, IMapper mapper)
        {
            _investmentRepository = investmentRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InvestmentDto>> GetAllInvestmentsByCustomerIdAsync(int id, bool? isActive)
        {
            var investments = await _investmentRepository.GetInvestmentsByCustomerIdAsync(id, isActive);
            if (investments == null)
                throw new KeyNotFoundException($"O Investmento do Cliente com ID: {id} não foi encontrado");

            return _mapper.Map<IEnumerable<InvestmentDto>>(investments);
          
        }

        public async Task<bool> CreateInvestmentAsync(InvestmentCreateDto investmentCreateDto)
        {
            // Valida se o Customer existe
            var customerExists = await _customerRepository.GetByIdAsync(investmentCreateDto.CustomerId);
            if (customerExists == null)
            {
                throw new ArgumentException("Customer not found.");
            }

            // Valida se o Product existe
            var productExists = await _productRepository.GetProductByIdAsync(investmentCreateDto.ProductId);
            if (productExists == null)
            {
                throw new ArgumentException("Product not found.");
            }

            var investment = _mapper.Map<Investment>(investmentCreateDto);
            var result = await _investmentRepository.AddInvestmentAsync(investment);
            if(!result)
                throw new Exception("Erro ao realizar o Investimento. Verifique os dados e tente novamente.");

            return result;

        }

        public async Task<InvestmentDto> SellInvestmentAsync(int investmentId)
        {
            var investment = await _investmentRepository.GetInvestmentByIdAsync(investmentId);
            if (investment == null)
            {
                throw new ArgumentException("Investment not found.");
            }

            // Marcar o investimento como inativo
            investment.IsActive = false;
            await _investmentRepository.UpdateInvestmentAsync(investment);

            return _mapper.Map<InvestmentDto>(investment);
        }
    }
}
