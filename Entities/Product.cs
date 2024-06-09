using System.ComponentModel.DataAnnotations;

namespace InvestmentPortfolioManagement.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}
