using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using InvestmentPortfolioManagement.Data;
using InvestmentPortfolioManagement.Entities;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new AppDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            // Verifica se existem clientes no banco de dados
            if (context.Customers.Any())
            {
                return;   // DB já possui dados.
            }

            // Adiciona clientes iniciais
            var customers = new[]
            {
                new Customer
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Cpf = "12345678901",
                    Email = "john.doe@example.com",
                    Telefone = "123456789",
                    DataNascimento = new DateTime(1990, 1, 1),
                    Active = true
                },
                new Customer
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    Cpf = "98765432100",
                    Email = "jane.smith@example.com",
                    Telefone = "987654321",
                    DataNascimento = new DateTime(1985, 5, 15),
                    Active = true
                }
            };

            context.Customers.AddRange(customers);

            // Adiciona produtos iniciais
            var products = new[]
            {
                new Product
                {
                    Name = "Product A",
                    Price = 100m,
                    ExpirationDate = new DateTime(2025, 12, 31)
                },
                new Product
                {
                    Name = "Product B",
                    Price = 200m,
                    ExpirationDate = new DateTime(2026, 12, 31)
                }
            };

            context.Products.AddRange(products);

            context.SaveChanges();

            // Adiciona investimentos iniciais
            var investments = new[]
            {
                new Investment
                {
                    Name = "Investment 1",
                    Amount = 1000m,
                    Date = DateTime.Now,
                    CustomerId = customers[0].Id,
                    Type = "Type 1",
                    MaturityDate = new DateTime(2024, 12, 31),
                    InterestRate = 5.5m,
                    ProductId = products[0].Id,
                    IsActive = true
                },
                new Investment
                {
                    Name = "Investment 2",
                    Amount = 2000m,
                    Date = DateTime.Now,
                    CustomerId = customers[1].Id,
                    Type = "Type 2",
                    MaturityDate = new DateTime(2024, 12, 31),
                    InterestRate = 5.5m,
                    ProductId = products[1].Id,
                    IsActive = true
                }
            };

            context.Investments.AddRange(investments);

            context.SaveChanges();
        }
    }
}
