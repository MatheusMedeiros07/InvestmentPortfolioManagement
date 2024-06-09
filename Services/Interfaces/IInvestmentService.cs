﻿using System.Collections.Generic;
using System.Threading.Tasks;
using InvestmentPortfolioManagement.Dtos.Investment;
namespace InvestmentPortfolioManagement.Services.Interfaces
{
    public interface IInvestmentService
    {
        Task<IEnumerable<InvestmentDto>> GetAllInvestmentsAsync();
        Task AddInvestmentAsync(InvestmentDto investmentDto);
    }
}
