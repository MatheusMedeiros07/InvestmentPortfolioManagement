
using InvestmentPortfolioManagement.Dtos.Investment;

namespace InvestmentPortfolioManagement.Dtos.Customer
{
    public class CustomerBaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Active { get; set; }

    }
}
