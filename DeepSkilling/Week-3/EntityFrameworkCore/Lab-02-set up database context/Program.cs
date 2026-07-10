using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Lab_02_set_up_database_context.Data;

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

// Ensure DB is created on startup (development convenience)
using var scope = host.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<RetailContext>();
db.Database.EnsureCreated();

Console.WriteLine("Retail DB is ready.");
