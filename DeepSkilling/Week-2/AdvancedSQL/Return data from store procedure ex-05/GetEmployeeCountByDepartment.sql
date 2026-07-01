-- Stored Procedure: Get Employee Count by Department

CREATE PROCEDURE GetEmployeeCountByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT COUNT(*) AS TotalEmployees
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;

-- Execute the procedure
EXEC GetEmployeeCountByDepartment 3;
