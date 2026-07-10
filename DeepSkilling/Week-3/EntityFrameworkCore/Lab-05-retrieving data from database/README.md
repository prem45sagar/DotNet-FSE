# Lab-05 — Retrieving data from the database

This lab demonstrates common EF Core retrieval patterns using LINQ and raw SQL:

What it shows
- Loading all entities (ToList)
- Filtering (Where)
- Projection (Select)
- Eager loading with Include/ThenInclude
- FirstOrDefault
- Raw SQL queries via FromSqlRaw

How to run:
1. From the Lab-05 folder:
   dotnet restore
   dotnet run
2. The project will create `retail.db` if needed and seed minimal data for the examples.

Notes:
- These examples use EnsureCreated for simplicity. In real projects prefer migrations for schema management.
