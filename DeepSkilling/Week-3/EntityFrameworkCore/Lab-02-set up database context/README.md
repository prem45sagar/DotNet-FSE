# Lab-02 — Set up database context

This lab adds a minimal EF Core 8 SQLite-backed DbContext and example models (Product, Customer, Order, OrderItem).

How to run:
1. Ensure the project has the EF Core packages (the .csproj in this folder references Microsoft.EntityFrameworkCore and Microsoft.EntityFrameworkCore.Sqlite).
2. From the project folder:
   dotnet restore
   dotnet run
3. On first run the local SQLite file `retail.db` is created (EnsureCreated used for quick setup).
4. To use migrations instead:
   dotnet ef migrations add Init -p . -s .
   dotnet ef database update
