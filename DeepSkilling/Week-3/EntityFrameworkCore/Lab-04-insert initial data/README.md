# Lab-04 — Insert initial data

This lab demonstrates inserting initial data into the EF Core-backed database programmatically.

What it does
- Ensures the database exists (EnsureCreated).
- Inserts sample Products and a Customer if they do not already exist.
- Creates an Order and an OrderItem for the new customer.
- Prints a summary of created records.

How to run:
1. From the Lab-04 folder:
   dotnet restore
   dotnet run
2. The first run will create `retail.db` and insert initial data. Subsequent runs will detect existing data and do nothing.

Notes:
- Use migrations for production schema changes instead of EnsureCreated.
  dotnet ef migrations add Init -p . -s .
  dotnet ef database update
