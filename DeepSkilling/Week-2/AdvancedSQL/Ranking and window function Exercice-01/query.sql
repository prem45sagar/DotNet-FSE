-- =====================================================================
-- SQL RANKING AND WINDOW FUNCTIONS - BEGINNER LEVEL
-- Learn ROW_NUMBER(), RANK(), and DENSE_RANK() Step by Step
-- =====================================================================

-- Step 1: Create Table
-- A simple Products table with basic information
CREATE TABLE Products
(
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(50),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);

-- Step 2: Insert Sample Data
-- We'll use this data for all examples below
INSERT INTO Products VALUES
(1,'Laptop','Electronics',80000),
(2,'Mobile','Electronics',60000),
(3,'Tablet','Electronics',40000),
(4,'Headphone','Electronics',10000),
(5,'Shirt','Fashion',2000),
(6,'Jeans','Fashion',3000),
(7,'Jacket','Fashion',5000),
(8,'Shoes','Fashion',4000),
(9,'Chair','Furniture',7000),
(10,'Table','Furniture',12000),
(11,'Sofa','Furniture',25000),
(12,'Bed','Furniture',30000);

-- =====================================================================
-- EXAMPLE 1: Basic ROW_NUMBER() - Numbering Rows
-- =====================================================================
-- What: Gives each row a unique number starting from 1
-- When to use: When you need to identify rows with sequential numbers
-- 
-- How it works:
-- - PARTITION BY Category: Separate numbering for each category
-- - ORDER BY Price DESC: Arrange by price (highest to lowest)
-- Result: Each row gets a number within its category
-- =====================================================================

SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    ROW_NUMBER() OVER (
        PARTITION BY Category
        ORDER BY Price DESC
    ) AS RowNumber
FROM Products
ORDER BY Category, Price DESC;

-- Expected Output Example:
-- ProductID | ProductName | Category   | Price | RowNumber
-- 1         | Laptop      | Electronics| 80000 | 1
-- 2         | Mobile      | Electronics| 60000 | 2
-- 3         | Tablet      | Electronics| 40000 | 3

-- =====================================================================
-- EXAMPLE 2: Basic RANK() - Ranking with Gaps
-- =====================================================================
-- What: Gives rank to rows, but skips numbers if values are same (tied)
-- When to use: When you want to rank items and show gaps for ties
--
-- How it works:
-- - Same PARTITION BY and ORDER BY as above
-- - If two items have same price, they get same rank
-- - The next rank skips a number
-- Result: Shows ranking with gaps
-- =====================================================================

SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    RANK() OVER (
        PARTITION BY Category
        ORDER BY Price DESC
    ) AS RankNumber
FROM Products
ORDER BY Category, Price DESC;

-- Expected Output Example:
-- If two items had same price:
-- ProductID | ProductName | Category   | Price | RankNumber
-- 1         | Laptop      | Electronics| 80000 | 1
-- 2         | Mobile      | Electronics| 60000 | 2
-- 2         | Another     | Electronics| 60000 | 2  (same as above)
-- 4         | Tablet      | Electronics| 40000 | 4  (skips 3!)

-- =====================================================================
-- EXAMPLE 3: Basic DENSE_RANK() - Ranking without Gaps
-- =====================================================================
-- What: Gives rank to rows without skipping numbers
-- When to use: When you want continuous ranking like 1,2,3,4...
--
-- How it works:
-- - Same as RANK(), but doesn't skip numbers
-- - If two items tied at rank 2, next rank is still 3
-- Result: Continuous ranking without gaps
-- =====================================================================

SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    DENSE_RANK() OVER (
        PARTITION BY Category
        ORDER BY Price DESC
    ) AS DenseRankNumber
FROM Products
ORDER BY Category, Price DESC;

-- Expected Output Example:
-- If two items had same price:
-- ProductID | ProductName | Category   | Price | DenseRankNumber
-- 1         | Laptop      | Electronics| 80000 | 1
-- 2         | Mobile      | Electronics| 60000 | 2
-- 2         | Another     | Electronics| 60000 | 2  (same as above)
-- 3         | Tablet      | Electronics| 40000 | 3  (continues from 3, no gap!)

-- =====================================================================
-- PRACTICAL EXAMPLE 1: Get Top 2 Products from Each Category
-- =====================================================================
-- Real use case: Find the 2 most expensive items in each category
-- 
-- How: 
-- 1. Use ROW_NUMBER() to number products by price
-- 2. Filter only rows where RowNum <= 2
-- Result: Only top 2 products per category
-- =====================================================================

SELECT 
    ProductID,
    ProductName,
    Category,
    Price
FROM
(
    -- Inner query: Add row numbers
    SELECT 
        ProductID,
        ProductName,
        Category,
        Price,
        ROW_NUMBER() OVER (
            PARTITION BY Category
            ORDER BY Price DESC
        ) AS RowNum
    FROM Products
) AS RankedProducts
WHERE RowNum <= 2
ORDER BY Category, RowNum;

-- Expected Output:
-- Electronics: Laptop (80000), Mobile (60000)
-- Fashion: Jacket (5000), Shoes (4000)
-- Furniture: Sofa (25000), Bed (30000)

-- =====================================================================
-- SIMPLE COMPARISON: ROW_NUMBER() vs RANK() vs DENSE_RANK()
-- =====================================================================
-- See all three functions side by side for each category
-- This helps you understand the difference:
-- =====================================================================

SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    ROW_NUMBER() OVER (
        PARTITION BY Category 
        ORDER BY Price DESC
    ) AS RNum,
    RANK() OVER (
        PARTITION BY Category 
        ORDER BY Price DESC
    ) AS RankNum,
    DENSE_RANK() OVER (
        PARTITION BY Category 
        ORDER BY Price DESC
    ) AS DenseRankNum
FROM Products
ORDER BY Category, Price DESC;

-- =====================================================================
-- QUICK REFERENCE TABLE
-- =====================================================================
-- 
-- Function      | Use When...                              | Behavior with Ties
-- --------------|------------------------------------------|--------------------
-- ROW_NUMBER()  | You need unique row numbers              | Different numbers
-- RANK()        | You want ranking with gaps               | Same rank, next skips
-- DENSE_RANK()  | You want continuous ranking              | Same rank, next continuous
--
-- Example with same price of 5000:
-- ROW_NUMBER(): 1, 2, 3, 4...
-- RANK():       1, 2, 2, 4...
-- DENSE_RANK(): 1, 2, 2, 3...
-- =====================================================================
