using System;

namespace EcommercePlatformSearch
{
    /// <summary>
    /// Represents a product in the e-commerce platform
    /// </summary>
    class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Product(int id, string title, string category, decimal price, int stock)
        {
            Id = id;
            Title = title;
            Category = category;
            Price = price;
            Stock = stock;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Title: {Title}, Category: {Category}, Price: ${Price}, Stock: {Stock}";
        }
    }
}
