-- Employee Management System - Stored Procedures

-- Create Departments Table
CREATE TABLE Departments
(
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100) NOT NULL
);

-- Create Employees Table
CREATE TABLE Employees
(
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    DepartmentID INT NOT NULL,
    Salary DECIMAL(10,2) NOT NULL,
    JoinDate DATE NOT NULL,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

-- Insert Department Data
INSERT INTO Departments VALUES
(1, 'HR'),
(2, 'Finance'),
(3, 'IT'),
(4, 'Marketing');

-- Insert Employee Data
INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
('John', 'Doe', 1, 5000, '2020-01-15'),
('Jane', 'Smith', 2, 6000, '2019-03-22'),
('Michael', 'Johnson', 3, 7000, '2018-07-30'),
('Emily', 'Davis', 4, 5500, '2021-11-05');


-- Procedure 1: Get All Employees from a Department
CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        EmployeeID,
        FirstName,
        LastName,
        DepartmentID,
        Salary,
        JoinDate
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;

EXEC sp_GetEmployeesByDepartment @DepartmentID = 3;


-- Procedure 2: Add New Employee
CREATE PROCEDURE sp_AddEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
    
    PRINT 'Employee added successfully';
END;

EXEC sp_AddEmployee @FirstName = 'Robert', @LastName = 'Brown', @DepartmentID = 3, @Salary = 8000, @JoinDate = '2024-01-10';


-- Procedure 3: Get Employee Count by Department
CREATE PROCEDURE sp_GetDepartmentEmployeeCount
    @DepartmentID INT
AS
BEGIN
    DECLARE @Count INT;
    
    SELECT @Count = COUNT(*) FROM Employees WHERE DepartmentID = @DepartmentID;
    
    SELECT 
        DepartmentName,
        @Count AS EmployeeCount
    FROM Departments
    WHERE DepartmentID = @DepartmentID;
END;

EXEC sp_GetDepartmentEmployeeCount @DepartmentID = 3;


-- Procedure 4: Update Employee Salary
CREATE PROCEDURE sp_UpdateEmployeeSalary
    @EmployeeID INT,
    @NewSalary DECIMAL(10,2)
AS
BEGIN
    UPDATE Employees
    SET Salary = @NewSalary
    WHERE EmployeeID = @EmployeeID;
    
    SELECT 'Salary updated' AS Message, @NewSalary AS NewSalary;
END;

EXEC sp_UpdateEmployeeSalary @EmployeeID = 1, @NewSalary = 5500;


-- Procedure 5: Get Average Salary by Department
CREATE PROCEDURE sp_GetAvgSalaryByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        d.DepartmentName,
        AVG(e.Salary) AS AvgSalary,
        COUNT(e.EmployeeID) AS TotalEmployees
    FROM Employees e
    INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
    WHERE e.DepartmentID = @DepartmentID
    GROUP BY d.DepartmentName;
END;

EXEC sp_GetAvgSalaryByDepartment @DepartmentID = 3;