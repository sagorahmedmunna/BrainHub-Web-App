-- =============================================
-- Stored Procedures for Sbu Entity
-- =============================================

-- Drop existing procedures if they exist
IF OBJECT_ID('usp_GetAllSbus', 'P') IS NOT NULL
    DROP PROCEDURE usp_GetAllSbus;
GO

IF OBJECT_ID('usp_GetSbuById', 'P') IS NOT NULL
    DROP PROCEDURE usp_GetSbuById;
GO

IF OBJECT_ID('usp_AddSbu', 'P') IS NOT NULL
    DROP PROCEDURE usp_AddSbu;
GO

IF OBJECT_ID('usp_UpdateSbu', 'P') IS NOT NULL
    DROP PROCEDURE usp_UpdateSbu;
GO

IF OBJECT_ID('usp_DeleteSbu', 'P') IS NOT NULL
    DROP PROCEDURE usp_DeleteSbu;
GO

-- =============================================
-- Get All Sbus
-- =============================================
CREATE PROCEDURE usp_GetAllSbus
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        Id,
        Name,
        ImageUrl
    FROM Sbus
END
GO

-- =============================================
-- Get Sbu By Id
-- =============================================
CREATE PROCEDURE usp_GetSbuById
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        Id,
        Name,
        ImageUrl
    FROM Sbus
    WHERE Id = @Id;
END
GO

-- =============================================
-- Add New Sbu
-- =============================================
CREATE PROCEDURE usp_AddSbu
    @Name NVARCHAR(MAX),
    @ImageUrl NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        INSERT INTO Sbus (Name, ImageUrl)
        VALUES (@Name, @ImageUrl);
        
        SELECT SCOPE_IDENTITY() AS NewId;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- =============================================
-- Update Sbu
-- =============================================
CREATE PROCEDURE usp_UpdateSbu
    @Id INT,
    @Name NVARCHAR(MAX),
    @ImageUrl NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        UPDATE Sbus
        SET 
            Name = @Name,
            ImageUrl = @ImageUrl
        WHERE Id = @Id;
        
        SELECT @@ROWCOUNT AS RowsAffected;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- =============================================
-- Delete Sbu
-- =============================================
CREATE PROCEDURE usp_DeleteSbu
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        DELETE FROM Sbus
        WHERE Id = @Id;
        
        SELECT @@ROWCOUNT AS RowsAffected;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO