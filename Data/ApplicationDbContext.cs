using Microsoft.EntityFrameworkCore;
using SklepPrzybyszewski.Models;

namespace SklepPrzybyszewski.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();

    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .Property(product => product.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Elektronika" },
            new Category { Id = 2, Name = "Książki" },
            new Category { Id = 3, Name = "Odzież" });

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Laptop", Description = "Laptop 15,6 cala, 16 GB RAM", Price = 3499.99m, CategoryId = 1 },
            new Product { Id = 2, Name = "Słuchawki", Description = "Słuchawki bezprzewodowe", Price = 249.00m, CategoryId = 1 },
            new Product { Id = 3, Name = "Pan Tadeusz", Description = "Adam Mickiewicz", Price = 29.90m, CategoryId = 2 },
            new Product { Id = 4, Name = "Wiedźmin: Ostatnie życzenie", Description = "Andrzej Sapkowski", Price = 39.99m, CategoryId = 2 },
            new Product { Id = 5, Name = "Koszulka", Description = "Bawełniana koszulka, rozmiar M", Price = 49.00m, CategoryId = 3 },
            new Product { Id = 6, Name = "Bluza", Description = null, Price = 129.00m, CategoryId = 3 });
    }
}
