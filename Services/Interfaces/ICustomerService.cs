using System.Collections.Generic;
using System.Threading.Tasks;
using InvestmentPortfolioManagement.Dtos.Customer;
using InvestmentPortfolioManagement.Entities;

namespace InvestmentPortfolioManagement.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
        Task<CustomerDto> GetCustomerByIdAsync(int id);
        Task<Customer> AddCustomerAsync(CustomerInsertDto customerDto);
        Task<CustomerDto> EditCustomerAsync(int id, CustomerUpdateDto customerDto);
    }
}
