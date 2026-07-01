-- =====================================================================
-- SQL RANKING AND WINDOW FUNCTIONS EXERCISE
-- Demonstrates ROW_NUMBER(), RANK(), and DENSE_RANK() Functions
-- =====================================================================

-- Create Table
CREATE TABLE Products
(
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(50),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);

-- Insert Data
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
-- 1. ROW_NUMBER() - Assigns unique sequential number to rows
--    Useful when you need unique row identification within partition
-- =====================================================================
SELECT *,
ROW_NUMBER() OVER
(
    PARTITION BY Category
    ORDER BY Price DESC
) AS RowNum
FROM Products
ORDER BY Category, Price DESC;

-- =====================================================================
-- 2. RANK() - Assigns rank with gaps for ties
--    Useful when you need to identify top performers with same values
-- =====================================================================
SELECT *,
RANK() OVER
(
    PARTITION BY Category
    ORDER BY Price DESC
) AS RankNum
FROM Products
ORDER BY Category, Price DESC;

-- =====================================================================
-- 3. DENSE_RANK() - Assigns rank without gaps for ties
--    Useful for continuous ranking without skipping numbers
-- =====================================================================
SELECT *,
DENSE_RANK() OVER
(
    PARTITION BY Category
    ORDER BY Price DESC
) AS DenseRankNum
FROM Products
ORDER BY Category, Price DESC;

-- =====================================================================
-- 4. GET TOP 3 PRODUCTS IN EACH CATEGORY - Using ROW_NUMBER()
-- =====================================================================
SELECT ProductID, ProductName, Category, Price, RowNum
FROM
(
    SELECT *,
    ROW_NUMBER() OVER
    (
        PARTITION BY Category
        ORDER BY Price DESC
    ) AS RowNum
    FROM Products
) T
WHERE RowNum <= 3
ORDER BY Category, RowNum;

-- =====================================================================
-- 5. COMPARISON: ROW_NUMBER() vs RANK() vs DENSE_RANK()
--    Shows the difference when there are tied values
-- =====================================================================
SELECT ProductID, ProductName, Category, Price,
    ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum,
    RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankNum,
    DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
FROM Products
ORDER BY Category, Price DESC;

-- =====================================================================
-- 6. BONUS: Get Products with Price Difference from Category Max
-- =====================================================================
SELECT ProductID, ProductName, Category, Price,
    MAX(Price) OVER (PARTITION BY Category) AS MaxPriceInCategory,
    (MAX(Price) OVER (PARTITION BY Category) - Price) AS PriceDifferenceFromMax,
    RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankNum
FROM Products
ORDER BY Category, Price DESC;
