using Microsoft.EntityFrameworkCore;
using Lab_04_insert_initial_data.Models;

namespace Lab_04_insert_initial_data.Data;

public class RetailContext : DbContext
{
    public RetailContext(DbContextOptions<RetailContext> options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasKey(p => p.Id);
        modelBuilder.Entity<Customer>().HasKey(c => c.Id);
        modelBuilder.Entity<Order>().HasKey(o => o.Id);
        modelBuilder.Entity<OrderItem>().HasKey(oi => oi.Id);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.Items)
            .HasForeignKey(oi => oi.OrderId);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Product)
            .WithMany()
            .HasForeignKey(oi => oi.ProductId);
    }
}
