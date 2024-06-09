using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InvestmentPortfolioManagement.Dtos.Customer;
using InvestmentPortfolioManagement.Dtos.Product;
using InvestmentPortfolioManagement.Entities;
using InvestmentPortfolioManagement.Repositories;
using InvestmentPortfolioManagement.Repositories.Interfaces;
using InvestmentPortfolioManagement.Services.Interfaces;

namespace InvestmentPortfolioManagement.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
                throw new KeyNotFoundException($"O Cliente com ID: {id} não foi encontrado");

            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<Customer> AddCustomerAsync(CustomerInsertDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            return await _customerRepository.AddAsync(customer);
        }

        public async Task<CustomerDto> EditCustomerAsync(int id, CustomerUpdateDto customerDto)
        {
            var existingCustomer = await _customerRepository.GetByIdAsync(id);
            if (existingCustomer == null)
                throw new KeyNotFoundException($"O Cliente com ID: {id} não foi encontrado");

            var customerUpdate = _mapper.Map<Customer>(customerDto, opts => opts.Items["Id"] = id);
            var sucess = await _customerRepository.EditAsync(existingCustomer, customerUpdate);
            if (!sucess)
                throw new Exception("Erro ao atualizar o Cliente");

            return _mapper.Map<CustomerDto>(await _customerRepository.GetByIdAsync(id));
        }

    }
}
