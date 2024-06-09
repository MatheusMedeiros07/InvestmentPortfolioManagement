
using InvestmentPortfolioManagement.Dtos.Investment;

namespace InvestmentPortfolioManagement.Dtos.Customer
{
    public class CustomerDto : CustomerBaseDto
    {
        public int? Id { get; set; }

        public List<InvestmentDto>? Investment { get; set; }
    }
}
