using InvestmentPortfolioManagement.Dtos.Customer;
using InvestmentPortfolioManagement.Dtos.Product;

namespace InvestmentPortfolioManagement.Dtos.Investment
{
    public class InvestmentDto : InvestmentBaseDto
    {
        public int? Id { get; set; }
        public bool IsActive { get; set; } = true;
        public ProductDto? Product { get; set; } // Navegação para Product

    }
}
