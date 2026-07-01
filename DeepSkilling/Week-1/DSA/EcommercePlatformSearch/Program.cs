using System;
using System.Collections.Generic;

namespace EcommercePlatformSearch
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("========== E-Commerce Platform Search Function ==========");
            Console.WriteLine();

            // Initialize sample products
            Product[] products =
            {
                new Product(101, "Laptop", "Electronics", 899.99m, 15),
                new Product(102, "Mobile Phone", "Electronics", 599.99m, 25),
                new Product(103, "Running Shoes", "Fashion", 89.99m, 40),
                new Product(104, "Smart Watch", "Accessories", 299.99m, 20),
                new Product(105, "Backpack", "Fashion", 49.99m, 50),
                new Product(106, "Headphones", "Electronics", 199.99m, 30),
                new Product(107, "Leather Wallet", "Accessories", 29.99m, 60),
                new Product(108, "T-Shirt", "Fashion", 19.99m, 100),
                new Product(109, "Tablet", "Electronics", 449.99m, 12),
                new Product(110, "Camera", "Electronics", 749.99m, 8)
            };

            SearchOperations searchOps = new SearchOperations(products);

            Console.WriteLine($"Total Products: {searchOps.GetTotalProducts()}\n");

            // Display Menu
            bool running = true;
            while (running)
            {
                DisplayMenu();
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        PerformLinearSearch(searchOps);
                        break;
                    case "2":
                        PerformBinarySearch(searchOps);
                        break;
                    case "3":
                        SearchByCategory(searchOps);
                        break;
                    case "4":
                        SearchByTitle(searchOps);
                        break;
                    case "5":
                        SearchByPrice(searchOps);
                        break;
                    case "6":
                        GetInStockProducts(searchOps);
                        break;
                    case "7":
                        DisplayAllProducts(searchOps, products);
                        break;
                    case "8":
                        running = false;
                        Console.WriteLine("Thank you for using E-Commerce Search Platform!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.\n");
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\n========== SEARCH OPTIONS ==========");
            Console.WriteLine("1. Linear Search by Product ID");
            Console.WriteLine("2. Binary Search by Product ID");
            Console.WriteLine("3. Search by Category");
            Console.WriteLine("4. Search by Product Title");
            Console.WriteLine("5. Search by Price Range");
            Console.WriteLine("6. Get Products In Stock");
            Console.WriteLine("7. Display All Products");
            Console.WriteLine("8. Exit");
            Console.WriteLine("====================================");
            Console.Write("Enter your choice (1-8): ");
        }

        static void PerformLinearSearch(SearchOperations searchOps)
        {
            Console.Write("Enter Product ID to search: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                // Linear Search - O(n)
                Product result = searchOps.LinearSearchById(id);
                DisplayResult(result, "Linear Search");
            }
            else
            {
                Console.WriteLine("Invalid ID entered.");
            }
        }

        static void PerformBinarySearch(SearchOperations searchOps)
        {
            Console.Write("Enter Product ID to search: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                // Binary Search - O(log n)
                Product result = searchOps.BinarySearchById(id);
                DisplayResult(result, "Binary Search");
            }
            else
            {
                Console.WriteLine("Invalid ID entered.");
            }
        }

        static void SearchByCategory(SearchOperations searchOps)
        {
            Console.Write("Enter Category: ");
            string category = Console.ReadLine();
            // Linear Search - O(n)
            List<Product> results = searchOps.SearchByCategory(category);
            DisplayResults(results, $"Products in '{category}' category");
        }

        static void SearchByTitle(SearchOperations searchOps)
        {
            Console.Write("Enter Product Title (or part of it): ");
            string title = Console.ReadLine();
            // Linear Search - O(n*m)
            List<Product> results = searchOps.SearchByTitle(title);
            DisplayResults(results, $"Products matching '{title}'");
        }

        static void SearchByPrice(SearchOperations searchOps)
        {
            Console.Write("Enter Minimum Price: $");
            if (decimal.TryParse(Console.ReadLine(), out decimal minPrice))
            {
                Console.Write("Enter Maximum Price: $");
                if (decimal.TryParse(Console.ReadLine(), out decimal maxPrice))
                {
                    // Linear Search - O(n)
                    List<Product> results = searchOps.SearchByPriceRange(minPrice, maxPrice);
                    DisplayResults(results, $"Products between ${minPrice} and ${maxPrice}");
                }
                else
                {
                    Console.WriteLine("Invalid maximum price entered.");
                }
            }
            else
            {
                Console.WriteLine("Invalid minimum price entered.");
            }
        }

        static void GetInStockProducts(SearchOperations searchOps)
        {
            // Linear Search - O(n)
            List<Product> results = searchOps.GetProductsInStock();
            DisplayResults(results, "Products In Stock");
        }

        static void DisplayAllProducts(SearchOperations searchOps, Product[] products)
        {
            Console.WriteLine("\n========== ALL PRODUCTS ==========");
            foreach (Product p in products)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("==================================");
        }

        static void DisplayResult(Product result, string searchType)
        {
            Console.WriteLine($"\n========== {searchType} Result ==========");
            if (result != null)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
            Console.WriteLine("=======================================");
        }

        static void DisplayResults(List<Product> results, string searchType)
        {
            Console.WriteLine($"\n========== {searchType} ==========");
            if (results.Count == 0)
            {
                Console.WriteLine("No products found.");
            }
            else
            {
                Console.WriteLine($"Found {results.Count} product(s):\n");
                foreach (Product p in results)
                {
                    Console.WriteLine(p);
                }
            }
            Console.WriteLine("=====================================");
        }
    }
}
