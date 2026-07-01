# E-Commerce Platform Search Function

## Overview
This project implements various search algorithms and demonstrates Data Structures & Algorithms (DSA) concepts using a simple e-commerce platform example.

## Project Structure
```
EcommercePlatformSearch/
├── Product.cs              # Product class definition
├── SearchOperations.cs     # Search algorithm implementations
├── Program.cs              # Main application with menu
├── BigONotation.txt        # Time complexity analysis
└── README.md               # This file
```

## Algorithms Implemented

### 1. Linear Search - O(n)
- **Description**: Searches for product by ID sequentially
- **Best Case**: O(1) - Element found at first position
- **Average Case**: O(n) - Element found somewhere in middle
- **Worst Case**: O(n) - Element not found or at last position
- **Use When**: Small datasets or unsorted data

### 2. Binary Search - O(log n)
- **Description**: Searches for product by ID in sorted array
- **Requirement**: Array must be sorted by ID
- **Best Case**: O(1) - Element at middle
- **Average Case**: O(log n)
- **Worst Case**: O(log n) - Element not found
- **Use When**: Large sorted datasets
- **Advantage**: Significantly faster for large arrays

### 3. Category Search - O(n)
- **Description**: Finds all products in a specific category
- **Time Complexity**: O(n)
- **Use When**: Filtering by single criterion

### 4. Title Search - O(n*m)
- **Description**: Finds products matching search term in title
- **m = Search string length**
- **Time Complexity**: O(n*m)
- **Use When**: Partial text matching

### 5. Price Range Search - O(n)
- **Description**: Finds products within price range
- **Time Complexity**: O(n)
- **Use When**: Range-based filtering

### 6. In-Stock Search - O(n)
- **Description**: Finds all products with available stock
- **Time Complexity**: O(n)
- **Use When**: Inventory checking

## Sample Data
The application comes with 10 pre-loaded products:
- 4 Electronics items
- 3 Fashion items
- 2 Accessories items
- 1 Additional product

## Time Complexity Comparison

| Algorithm | Best Case | Average Case | Worst Case | Use Case |
|-----------|-----------|--------------|------------|----------|
| Linear Search | O(1) | O(n) | O(n) | Unsorted data |
| Binary Search | O(1) | O(log n) | O(log n) | Sorted data |
| Category Filter | O(n) | O(n) | O(n) | Single filter |
| Title Search | O(n) | O(n) | O(n*m) | Text matching |
| Price Range | O(n) | O(n) | O(n) | Range filter |

## Learning Outcomes
✓ Understand Linear vs Binary Search
✓ Learn Big O Notation
✓ Implement search algorithms in C#
✓ Analyze time complexity
✓ Real-world algorithm applications

## How to Run

```bash
cd EcommercePlatformSearch
dotnet run
```

Then select an option from the interactive menu (1-8).

## Menu Options
1. Linear Search by Product ID - O(n)
2. Binary Search by Product ID - O(log n)
3. Search by Category - O(n)
4. Search by Product Title - O(n*m)
5. Search by Price Range - O(n)
6. Get Products In Stock - O(n)
7. Display All Products - O(n)
8. Exit

## Key DSA Concepts

### Search Efficiency
- Linear search checks every element one by one
- Binary search eliminates half the remaining elements each iteration
- For 1 million items: Linear = 1M operations, Binary = 20 operations

### When to Optimize
- Use binary search for sorted, large datasets
- Use filtering for specific criteria searches
- Consider data structure before choosing algorithm

## Real-World Applications
- E-commerce platforms (Amazon, Flipkart, eBay)
- Product catalogs
- Search engines
- Inventory management systems
- Price comparison tools

## Future Enhancements
- Add database integration
- Implement hash tables for O(1) lookups
- Add multi-field sorting
- Implement pagination
- Add performance benchmarking

## Author
Created as DSA Week-1 learning project in DotNet-FSE program
