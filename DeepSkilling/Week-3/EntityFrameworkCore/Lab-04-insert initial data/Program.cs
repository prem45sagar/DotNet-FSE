using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Lab_04_insert_initial_data.Data;
using Lab_04_insert_initial_data.Models;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((ctx, cfg) =>
    {
        cfg.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    })
    .ConfigureServices((ctx, services) =>
    {
        var conn = ctx.Configuration.GetConnectionString("Retail") ?? "Data Source=retail.db";
        services.AddDbContext<RetailContext>(opt => opt.UseSqlite(conn));
    })
    .Build();

using var scope = host.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<RetailContext>();

// Ensure DB exists
db.Database.EnsureCreated();

// Insert initial data if not present
if (!db.Products.Any() || !db.Customers.Any())
{
    Console.WriteLine("Inserting initial data...");

    var products = new[] {
        new Product { Name = "Alpha", Price = 12.50m },
        new Product { Name = "Beta", Price = 7.30m },
        new Product { Name = "Gamma", Price = 15.00m }
    };

    var customer = new Customer { FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com" };

    db.Products.AddRange(products);
    db.Customers.Add(customer);
    db.SaveChanges();

    // Create an order for the customer
    var order = new Order { CustomerId = customer.Id, CreatedAt = DateTime.UtcNow };
    db.Orders.Add(order);
    db.SaveChanges();

    var firstProduct = db.Products.First();
    var orderItem = new OrderItem { OrderId = order.Id, ProductId = firstProduct.Id, Quantity = 2, UnitPrice = firstProduct.Price };
    db.OrderItems.Add(orderItem);
    db.SaveChanges();

    Console.WriteLine("Initial data inserted.");
}
else
{
    Console.WriteLine("Initial data already present. No changes made.");
}

// Print summary
Console.WriteLine($"Products: {db.Products.Count()}");
Console.WriteLine($"Customers: {db.Customers.Count()}");
Console.WriteLine($"Orders: {db.Orders.Count()}");
Console.WriteLine($"OrderItems: {db.OrderItems.Count()}");

Console.WriteLine("Lab-04 complete.");
