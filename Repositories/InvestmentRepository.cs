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

        public async Task<IEnumerable<Investment>> GetAllAsync()
        {
            return await _context.Investments
                                 .Include(i => i.Product)
                                 .Include(i => i.Customer)
                                 .ToListAsync();
        }

        public async Task AddAsync(Investment investment)
        {
            await _context.Investments.AddAsync(investment);
            await _context.SaveChangesAsync();
        }
    }
}
