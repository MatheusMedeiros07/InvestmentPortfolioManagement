using System.ComponentModel.DataAnnotations;

namespace InvestmentPortfolioManagement.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateOnly DataNascimento { get; set; }

        public List<Investment>? Investment { get; set; }

    }
}
