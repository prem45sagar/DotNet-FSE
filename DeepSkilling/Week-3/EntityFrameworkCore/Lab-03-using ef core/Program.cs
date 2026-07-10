using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Lab_03_using_ef_core.Data;
using Lab_03_using_ef_core.Models;

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

// Seed sample products if none
if (!db.Products.Any())
{
    db.Products.AddRange(new[] {
        new Product { Name = "Widget", Price = 9.99m },
        new Product { Name = "Gadget", Price = 19.99m },
        new Product { Name = "Doohickey", Price = 4.50m }
    });
    db.SaveChanges();
    Console.WriteLine("Seeded sample products.");
}

// Simple query
var products = db.Products.OrderBy(p => p.Price).ToList();
Console.WriteLine("Products in catalog:");
foreach (var p in products)
{
    Console.WriteLine($"- {p.Name} : {p.Price:C}");
}

Console.WriteLine("Done.");
