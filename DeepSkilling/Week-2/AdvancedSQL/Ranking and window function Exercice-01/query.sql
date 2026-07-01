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
