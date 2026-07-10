# Lab-03 — Using EF Core (example run)

This lab demonstrates basic usage of EF Core 8 with SQLite: seeding data and performing a simple query.

How to run:
1. From the Lab-03 folder:
   dotnet restore
   dotnet run
2. The first run will create `retail.db` and seed a few products if the Products table is empty.

Notes:
- The project uses EnsureCreated for quick setup; for production or schema changes use migrations:
  dotnet ef migrations add Init -p . -s .
  dotnet ef database update
