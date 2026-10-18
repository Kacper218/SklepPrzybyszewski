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
    }
}
