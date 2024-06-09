using Microsoft.EntityFrameworkCore;
using InvestmentPortfolioManagement.Entities;
using InvestmentPortfolioManagement.Data;
using InvestmentPortfolioManagement.Repositories.Interfaces;

namespace InvestmentPortfolioManagement.Repositories
{

    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly AppDbContext _context;

        public InvestmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Investment> GetInvestmentByIdAsync(int id)
        {
            return await _context.Investments
            .Include(i => i.Product)  // Inclui o Product
            .FirstAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Investment>> GetInvestmentsByCustomerIdAsync(int customerId, bool? isActive)
        {
            var query = _context.Investments
           .Include(i => i.Product)
           .Where(i => i.CustomerId == customerId);

            if (isActive.HasValue)
            {
                query = query.Where(i => i.IsActive == isActive.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<bool> AddInvestmentAsync(Investment investment)
        {
            _context.Investments.Add(investment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task UpdateInvestmentAsync(Investment investment)
        {
            _context.Investments.Update(investment);
            await _context.SaveChangesAsync();
        }
    }
}
