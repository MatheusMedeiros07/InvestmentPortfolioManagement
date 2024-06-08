using System.ComponentModel.DataAnnotations;

namespace InvestmentPortfolioManagement.Entities
{
    public class Investment
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }



        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }

}
