using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

            // Configuração adicional das entidades
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id); // Definir chave primária

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100); // Definir propriedade obrigatória e tamanho máximo

                entity.Property(e => e.ExpirationDate)
                    .IsRequired();

                entity.Property(e => e.Price)
                .IsRequired();
            });
        }
    }
}
