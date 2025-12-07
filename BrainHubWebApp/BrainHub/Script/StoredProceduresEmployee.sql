-- =============================================
-- Author:      Your Name
-- Create date: October 15, 2025
-- Description: Stored Procedures for Employee table
-- =============================================

-- Drop existing procedures if they exist
IF OBJECT_ID('usp_GetAllEmployees', 'P') IS NOT NULL
    DROP PROCEDURE usp_GetAllEmployees;
GO

IF OBJECT_ID('usp_GetEmployeeById', 'P') IS NOT NULL
    DROP PROCEDURE usp_GetEmployeeById;
GO

IF OBJECT_ID('usp_GetEmployeeByUserId', 'P') IS NOT NULL
    DROP PROCEDURE usp_GetEmployeeByUserId;
GO

IF OBJECT_ID('usp_CreateEmployee', 'P') IS NOT NULL
    DROP PROCEDURE usp_CreateEmployee;
GO

IF OBJECT_ID('usp_UpdateEmployee', 'P') IS NOT NULL
    DROP PROCEDURE usp_UpdateEmployee;
GO

IF OBJECT_ID('usp_DeleteEmployee', 'P') IS NOT NULL
    DROP PROCEDURE usp_DeleteEmployee;
GO

-- =============================================
-- Procedure to get all employees with their related data
-- Corresponds to EmployeeService.GetAll()
-- =============================================
CREATE PROCEDURE usp_GetAllEmployees
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        e.Id,
        e.Name,
        e.Number,
        e.SbuId,
        s.Name AS SbuName,
        e.UserId,
        u.Email AS UserEmail,
        e.CustomRoleId,
        cr.Name AS CustomRoleName
    FROM
        Employees e
    LEFT JOIN
        Sbus s ON e.SbuId = s.Id
    LEFT JOIN
        AspNetUsers u ON e.UserId = u.Id
    LEFT JOIN
        CustomRoles cr ON e.CustomRoleId = cr.Id;
END
GO

-- =============================================
-- Procedure to get a single employee by their ID
-- Corresponds to EmployeeService.GetById()
-- =============================================
CREATE PROCEDURE usp_GetEmployeeById
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        e.Id,
        e.Name,
        e.Number,
        e.SbuId,
        s.Name AS SbuName,
        e.UserId,
        u.Email AS UserEmail,
        e.CustomRoleId,
        cr.Name AS CustomRoleName
    FROM
        Employees e
    LEFT JOIN
        Sbus s ON e.SbuId = s.Id
    LEFT JOIN
        AspNetUsers u ON e.UserId = u.Id
    LEFT JOIN
        CustomRoles cr ON e.CustomRoleId = cr.Id
    WHERE
        e.Id = @Id;
END
GO

-- =============================================
-- Procedure to get a single employee by their UserId (Identity User Id)
-- Corresponds to EmployeeService.GetByUserId()
-- =============================================
CREATE PROCEDURE usp_GetEmployeeByUserId
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        e.Id,
        e.Name,
        e.Number,
        e.SbuId,
        s.Name AS SbuName,
        e.UserId,
        u.Email AS UserEmail,
        e.CustomRoleId,
        cr.Name AS CustomRoleName
    FROM
        Employees e
    LEFT JOIN
        Sbus s ON e.SbuId = s.Id
    LEFT JOIN
        AspNetUsers u ON e.UserId = u.Id
    LEFT JOIN
        CustomRoles cr ON e.CustomRoleId = cr.Id
    WHERE
        e.UserId = @UserId;
END
GO


-- =============================================
-- Procedure to create a new employee
-- Corresponds to the repository action in EmployeeService.Create()
-- NOTE: This does not create the IdentityUser. That logic is handled
-- by the UserManager in the application layer.
-- =============================================
CREATE PROCEDURE usp_CreateEmployee
    @Name NVARCHAR(255),
    @Number NVARCHAR(50),
    @SbuId INT,
    @UserId INT,
    @CustomRoleId INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Employees (Name, Number, SbuId, UserId, CustomRoleId)
    VALUES (@Name, @Number, @SbuId, @UserId, @CustomRoleId);

    -- Return the ID of the newly created employee
    SELECT SCOPE_IDENTITY() AS NewEmployeeId;
END
GO

-- =============================================
-- Procedure to update an existing employee
-- Corresponds to the repository action in EmployeeService.Update()
-- =============================================
CREATE PROCEDURE usp_UpdateEmployee
    @Id INT,
    @Name NVARCHAR(255),
    @Number NVARCHAR(50),
    @SbuId INT,
    @CustomRoleId INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Employees
    SET
        Name = @Name,
        Number = @Number,
        SbuId = @SbuId,
        CustomRoleId = @CustomRoleId
    WHERE
        Id = @Id;
END
GO

-- =============================================
-- Procedure to delete an employee by their ID
-- Corresponds to the repository action in EmployeeService.Delete()
-- NOTE: This does not delete the associated IdentityUser.
-- That should be handled by the application logic before calling this.
-- =============================================
CREATE PROCEDURE usp_DeleteEmployee
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Employees
    WHERE Id = @Id;
END
GO
