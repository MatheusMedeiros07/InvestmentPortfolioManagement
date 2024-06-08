using System.ComponentModel.DataAnnotations;

namespace InvestmentPortfolioManagement.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}
