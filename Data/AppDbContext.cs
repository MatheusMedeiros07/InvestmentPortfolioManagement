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

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id); // Define a chave primária

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50); // Define o tamanho máximo

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(15);

                entity.Property(e => e.DataNascimento)
                    .IsRequired();

                entity.HasMany(e => e.Investment)
                    .WithOne(i => i.Customer)
                    .HasForeignKey(i => i.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade); // Define o relacionamento com Investment
            });

        }
    }
}
