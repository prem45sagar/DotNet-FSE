using System;
using System.Collections.Generic;

namespace EcommercePlatformSearch
{
    /// Implements various search algorithms for the e-commerce platform
    class SearchOperations
    {
        private Product[] products;

        public SearchOperations(Product[] products)
        {
            this.products = products;
        }
        
        /// Linear Search - O(n)
        /// Searches for a product by ID sequentially
        /// Best Case: O(1) - Element found at first position
        /// Average Case: O(n) - Element found somewhere in middle
        /// Worst Case: O(n) - Element not found or at last position

        public Product LinearSearchById(int id)
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Id == id)
                    return products[i];
            }
            return null;
        }

        /// Binary Search - O(log n)
        /// Searches for a product by ID in a sorted array
        /// Requires: Array must be sorted by ID
        /// Best Case: O(1) - Element found at middle
        /// Average Case: O(log n)
        /// Worst Case: O(log n) - Element not found
        
        public Product BinarySearchById(int id)
        {
            int left = 0;
            int right = products.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (products[mid].Id == id)
                    return products[mid];

                if (products[mid].Id < id)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return null;
        }

        /// Linear Search by Category - O(n)
        /// Returns all products in a given category
        /// Time Complexity: O(n)

        public List<Product> SearchByCategory(string category)
        {
            List<Product> results = new List<Product>();

            foreach (Product p in products)
            {
                if (p.Category.ToLower() == category.ToLower())
                    results.Add(p);
            }

            return results;
        }

        /// Linear Search by Title - O(n*m)
        /// Where m is the length of the search string
        /// Returns all products with matching title

        public List<Product> SearchByTitle(string title)
        {
            List<Product> results = new List<Product>();

            foreach (Product p in products)
            {
                if (p.Title.ToLower().Contains(title.ToLower()))
                    results.Add(p);
            }

            return results;
        }

        /// Linear Search by Price Range - O(n)
        /// Returns all products within the specified price range

        public List<Product> SearchByPriceRange(decimal minPrice, decimal maxPrice)
        {
            List<Product> results = new List<Product>();

            foreach (Product p in products)
            {
                if (p.Price >= minPrice && p.Price <= maxPrice)
                    results.Add(p);
            }

            return results;
        }

        /// Get products in stock - O(n)
        /// Returns all products with stock > 0

        public List<Product> GetProductsInStock()
        {
            List<Product> results = new List<Product>();

            foreach (Product p in products)
            {
                if (p.Stock > 0)
                    results.Add(p);
            }

            return results;
        }

        /// Get total products count
        /// Time Complexity: O(1)

        public int GetTotalProducts()
        {
            return products.Length;
        }
    }
}
