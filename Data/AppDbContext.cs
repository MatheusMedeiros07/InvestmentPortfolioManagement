using Microsoft.EntityFrameworkCore;
using InvestmentPortfolioManagement.Entities;

namespace InvestmentPortfolioManagement.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Investment> Investments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração adicional das entidades se necessário
        }
    }
}
