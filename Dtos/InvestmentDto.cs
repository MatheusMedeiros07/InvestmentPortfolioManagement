namespace InvestmentPortfolioManagement.Dtos
{
    public class InvestmentDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

    }
}
