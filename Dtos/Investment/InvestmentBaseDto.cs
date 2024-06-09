using InvestmentPortfolioManagement.Dtos.Customer;
using InvestmentPortfolioManagement.Dtos.Product;

namespace InvestmentPortfolioManagement.Dtos.Investment
{
    public class InvestmentBaseDto
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public CustomerBaseDto Customer { get; set; }
        public string Type { get; set; }
        public DateTime MaturityDate { get; set; }
        public decimal InterestRate { get; set; }
        public bool IsActive { get; set; } = true;

        public int ProductId { get; set; } // Chave estrangeira para Product
        public ProductBaseDto Product { get; set; } // Navegação para Product

    }
}
