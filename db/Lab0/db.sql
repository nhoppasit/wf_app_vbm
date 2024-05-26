-- Create the database
IF NOT EXISTS (
    SELECT name
    FROM sys.databases
    WHERE name = N'MyDatabase'
) BEGIN CREATE DATABASE [MyDatabase];
END
GO -- Use the new database
    USE [MyDatabase];
GO -- Create a table
    IF NOT EXISTS (
        SELECT *
        FROM sysobjects
        WHERE name = 'Employees'
            AND xtype = 'U'
    ) BEGIN CREATE TABLE [dbo].[Employees] (
        [EmployeeID] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
        [FirstName] NVARCHAR(50) NOT NULL,
        [LastName] NVARCHAR(50) NOT NULL,
        [BirthDate] DATE NULL,
        [HireDate] DATE NULL
    );
END
GO -- Insert sample data
INSERT INTO [dbo].[Employees] ([FirstName], [LastName], [BirthDate], [HireDate])
VALUES ('John', 'Doe', '1980-01-01', '2005-06-01'),
    ('Jane', 'Smith', '1985-02-12', '2010-07-15'),
    ('Jim', 'Brown', '1990-03-23', '2015-08-20');
GO -- Create stored procedure to add an employee
    IF OBJECT_ID('dbo.AddEmployee', 'P') IS NOT NULL DROP PROCEDURE dbo.AddEmployee;
GO CREATE PROCEDURE dbo.AddEmployee @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @BirthDate DATE,
    @HireDate DATE AS BEGIN
INSERT INTO dbo.Employees (FirstName, LastName, BirthDate, HireDate)
VALUES (@FirstName, @LastName, @BirthDate, @HireDate);
END
GO -- Create stored procedure to get all employees
    IF OBJECT_ID('dbo.GetEmployees', 'P') IS NOT NULL DROP PROCEDURE dbo.GetEmployees;
GO CREATE PROCEDURE dbo.GetEmployees AS BEGIN
SELECT *
FROM dbo.Employees;
END
GO -- Create stored procedure to update an employee
    IF OBJECT_ID('dbo.UpdateEmployee', 'P') IS NOT NULL DROP PROCEDURE dbo.UpdateEmployee;
GO CREATE PROCEDURE dbo.UpdateEmployee @EmployeeID INT,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @BirthDate DATE,
    @HireDate DATE AS BEGIN
UPDATE dbo.Employees
SET FirstName = @FirstName,
    LastName = @LastName,
    BirthDate = @BirthDate,
    HireDate = @HireDate
WHERE EmployeeID = @EmployeeID;
END
GO -- Create stored procedure to delete an employee
    IF OBJECT_ID('dbo.DeleteEmployee', 'P') IS NOT NULL DROP PROCEDURE dbo.DeleteEmployee;
GO CREATE PROCEDURE dbo.DeleteEmployee @EmployeeID INT AS BEGIN
DELETE FROM dbo.Employees
WHERE EmployeeID = @EmployeeID;
END
GO