using System.ComponentModel.DataAnnotations;

namespace InvestmentPortfolioManagement.Entities
{
    public class Investment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public string Type { get; set; }
        public DateTime MaturityDate { get; set; }
        public decimal InterestRate { get; set; }
        public bool IsActive { get; set; } = true;

        public int ProductId { get; set; } // Chave estrangeira para Product
        public Product? Product { get; set; } // Navegação para Product
    }



}
