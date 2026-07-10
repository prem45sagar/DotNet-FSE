using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Lab_05_retrieving_data_from_database.Data;
using Lab_05_retrieving_data_from_database.Models;

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

// Ensure DB exists and seed minimal data for retrieval examples
db.Database.EnsureCreated();

if (!db.Products.Any())
{
    db.Products.AddRange(new[] {
        new Product { Name = "Alpha", Price = 12.50m },
        new Product { Name = "Beta", Price = 7.30m },
        new Product { Name = "Gamma", Price = 15.00m }
    });
}

if (!db.Customers.Any())
{
    var c = new Customer { FirstName = "Alice", LastName = "Smith", Email = "alice@example.com" };
    db.Customers.Add(c);
    db.SaveChanges();

    var order = new Order { CustomerId = c.Id, CreatedAt = DateTime.UtcNow };
    db.Orders.Add(order);
    db.SaveChanges();

    var p = db.Products.First();
    db.OrderItems.Add(new OrderItem { OrderId = order.Id, ProductId = p.Id, Quantity = 3, UnitPrice = p.Price });
}

db.SaveChanges();

Console.WriteLine("Retrieving data examples:\n");

// 1. Simple: load all products
var allProducts = db.Products.ToList();
Console.WriteLine("All products:");
allProducts.ForEach(p => Console.WriteLine($"- {p.Id}: {p.Name} ({p.Price:C})"));

// 2. Filter: products with price > 10
var expensive = db.Products.Where(p => p.Price > 10).ToList();
Console.WriteLine("\nProducts with price > 10:");
expensive.ForEach(p => Console.WriteLine($"- {p.Name} : {p.Price:C}"));

// 3. Projection: select names only
var names = db.Products.Select(p => p.Name).ToList();
Console.WriteLine("\nProduct names: " + string.Join(", ", names));

// 4. Eager load related data (Include)
var orders = db.Orders.Include(o => o.Items).ThenInclude(oi => oi.Product).Include(o => o.Customer).ToList();
Console.WriteLine("\nOrders with items and product details:");
foreach (var o in orders)
{
    Console.WriteLine($"Order {o.Id} for customer {o.Customer?.FirstName} {o.Customer?.LastName} ({o.CreatedAt})");
    foreach (var it in o.Items)
    {
        Console.WriteLine($"  - {it.Product?.Name} x{it.Quantity} @ {it.UnitPrice:C}");
    }
}

// 5. FirstOrDefault example
var single = db.Products.FirstOrDefault(p => p.Name.Contains("Alpha"));
Console.WriteLine($"\nFirst product containing 'Alpha': {single?.Name ?? "(none)"}");

// 6. Raw SQL (FromSqlRaw) - demonstrates executing a simple SQL query
var raw = db.Products.FromSqlRaw("SELECT * FROM Products WHERE Price > {0}", 10).ToList();
Console.WriteLine("\nRaw SQL query results (Price > 10):");
raw.ForEach(p => Console.WriteLine($"- {p.Name} : {p.Price:C}"));

Console.WriteLine("\nDone.");
