-- =============================================
-- Author:      Gemini
-- Create date: October 15, 2025
-- Description: Stored Procedures for CustomRole table
-- =============================================

-- Drop existing procedures if they exist
IF OBJECT_ID('usp_GetAllCustomRoles', 'P') IS NOT NULL
    DROP PROCEDURE usp_GetAllCustomRoles;
GO

IF OBJECT_ID('usp_GetCustomRoleById', 'P') IS NOT NULL
    DROP PROCEDURE usp_GetCustomRoleById;
GO

IF OBJECT_ID('usp_CreateCustomRole', 'P') IS NOT NULL
    DROP PROCEDURE usp_CreateCustomRole;
GO

IF OBJECT_ID('usp_UpdateCustomRole', 'P') IS NOT NULL
    DROP PROCEDURE usp_UpdateCustomRole;
GO

IF OBJECT_ID('usp_DeleteCustomRole', 'P') IS NOT NULL
    DROP PROCEDURE usp_DeleteCustomRole;
GO


-- =============================================
-- Procedure to get all CustomRoles
-- Corresponds to CustomRoleService.GetAllRoles()
-- NOTE: Includes ORDER BY to guarantee sorted results.
-- =============================================
CREATE PROCEDURE usp_GetAllCustomRoles
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        Name,
        Permissions
    FROM
        CustomRoles
    ORDER BY
        Name ASC; -- Ensure sorted results for consistent display
END
GO

-- =============================================
-- Procedure to get a single CustomRole by ID
-- Corresponds to CustomRoleService.GetRoleById()
-- =============================================
CREATE PROCEDURE usp_GetCustomRoleById
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        Name,
        Permissions
    FROM
        CustomRoles
    WHERE
        Id = @Id;
END
GO

-- =============================================
-- Procedure to create a new CustomRole
-- Corresponds to CustomRoleService.CreateRole()
-- =============================================
CREATE PROCEDURE usp_CreateCustomRole
    @Name NVARCHAR(255),
    @Permissions NVARCHAR(MAX) -- Stores the comma-separated list
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO CustomRoles (Name, Permissions)
    VALUES (@Name, @Permissions);

    -- Return the ID of the newly created role
    SELECT SCOPE_IDENTITY() AS NewCustomRoleId;
END
GO

-- =============================================
-- Procedure to update an existing CustomRole
-- Corresponds to CustomRoleService.UpdateRole()
-- =============================================
CREATE PROCEDURE usp_UpdateCustomRole
    @Id INT,
    @Name NVARCHAR(255),
    @Permissions NVARCHAR(MAX) -- Stores the comma-separated list
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE CustomRoles
    SET
        Name = @Name,
        Permissions = @Permissions
    WHERE
        Id = @Id;
END
GO

-- =============================================
-- Procedure to delete a CustomRole by ID
-- Corresponds to CustomRoleService.DeleteRole()
-- =============================================
CREATE PROCEDURE usp_DeleteCustomRole
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Before deleting the role, set CustomRoleId to NULL for any employees using this role
    UPDATE Employees
    SET CustomRoleId = NULL
    WHERE CustomRoleId = @Id;

    DELETE FROM CustomRoles
    WHERE Id = @Id;
END
GO
