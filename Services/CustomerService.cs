using System.Collections.Generic;
using System.Threading.Tasks;
using InvestmentPortfolioManagement.Dtos;
using InvestmentPortfolioManagement.Entities;
using InvestmentPortfolioManagement.Repositories;
using InvestmentPortfolioManagement.Repositories.Interfaces;
using InvestmentPortfolioManagement.Services.Interfaces;

namespace InvestmentPortfolioManagement.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return customers.Select(c => new CustomerDto());
        }

        public async Task AddCustomerAsync(CustomerDto customerDto)
        {
            var customer = new Customer();
            await _customerRepository.AddAsync(customer);
        }

    }
}
