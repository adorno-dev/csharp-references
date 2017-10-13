USE Workgroup

GO

IF OBJECT_ID('dbo.USP_INSERT_EMPLOYEE', 'P') IS NOT NULL
DROP PROCEDURE dbo.USP_INSERT_EMPLOYEE

GO

IF OBJECT_ID('dbo.USP_UPDATE_EMPLOYEE', 'P') IS NOT NULL
DROP PROCEDURE dbo.USP_UPDATE_EMPLOYEE

GO

IF OBJECT_ID('dbo.USP_DELETE_EMPLOYEE', 'P') IS NOT NULL
DROP PROCEDURE dbo.USP_DELETE_EMPLOYEE

GO

IF OBJECT_ID('dbo.USP_SELECT_EMPLOYEE', 'P') IS NOT NULL
DROP PROCEDURE dbo.USP_SELECT_EMPLOYEE

IF OBJECT_ID('dbo.USP_INSERT_COMPANY', 'P') IS NOT NULL
DROP PROCEDURE dbo.USP_INSERT_COMPANY

GO

IF OBJECT_ID('dbo.USP_UPDATE_COMPANY', 'P') IS NOT NULL
DROP PROCEDURE dbo.USP_UPDATE_COMPANY

GO

IF OBJECT_ID('dbo.USP_DELETE_COMPANY', 'P') IS NOT NULL
DROP PROCEDURE dbo.USP_DELETE_COMPANY

GO

IF OBJECT_ID('dbo.USP_SELECT_COMPANY', 'P') IS NOT NULL
DROP PROCEDURE dbo.USP_SELECT_COMPANY

GO

IF OBJECT_ID('dbo.USP_INFO', 'P') IS NOT NULL
DROP PROCEDURE dbo.USP_INFO

GO

-- EMPLOYEES TABLE
CREATE PROCEDURE USP_INSERT_EMPLOYEE
    @Name VARCHAR(50),
    @Location VARCHAR(50)
AS
BEGIN TRANSACTION
    BEGIN TRY
        INSERT INTO dbo.Employees (Name, Location) VALUES (@Name, @Location)
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
    END CATCH

GO

CREATE PROCEDURE USP_UPDATE_EMPLOYEE
    @EmployeeId INT,
    @Name VARCHAR(50),
    @Location VARCHAR(50)
AS
BEGIN TRANSACTION
    BEGIN TRY
        UPDATE dbo.Employees SET Name = @Name, Location = @Location WHERE EmployeeId = @EmployeeId
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
    END CATCH

GO

CREATE PROCEDURE USP_DELETE_EMPLOYEE
    @EmployeeId INT
AS
BEGIN TRANSACTION
    BEGIN TRY
        DELETE FROM dbo.Employees WHERE EmployeeId = @EmployeeId
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
    END CATCH

GO

CREATE PROCEDURE USP_SELECT_EMPLOYEE
    @EmployeeId INT = NULL
AS
BEGIN

    IF @EmployeeId IS NULL
        SELECT EmployeeId, Name, Location FROM dbo.Employees
    ELSE
        SELECT EmployeeId, Name, Location FROM dbo.Employees WHERE EmployeeId = @EmployeeId

END

GO

-- COMPANY TABLE
CREATE PROCEDURE USP_INSERT_COMPANY
    @Name VARCHAR(50),
    @Location VARCHAR(50)
AS
BEGIN TRANSACTION
    BEGIN TRY
        INSERT INTO dbo.Company (Name, Location) VALUES (@Name, @Location)
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
    END CATCH

GO

CREATE PROCEDURE USP_UPDATE_COMPANY
    @CompanyId INT,
    @Name VARCHAR(50),
    @Location VARCHAR(50)
AS
BEGIN TRANSACTION
    BEGIN TRY
        UPDATE dbo.Company SET Name = @Name, Location = @Location WHERE CompanyId = @CompanyId
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
    END CATCH

GO

CREATE PROCEDURE USP_DELETE_COMPANY
    @CompanyId INT
AS
BEGIN TRANSACTION
    BEGIN TRY
        DELETE FROM dbo.Company WHERE CompanyId = @CompanyId
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
    END CATCH

GO

CREATE PROCEDURE USP_SELECT_COMPANY
    @CompanyId INT = NULL
AS
BEGIN

    IF @CompanyId IS NULL
        SELECT CompanyId, Name, Location FROM dbo.Company
    ELSE
        SELECT CompanyId, Name, Location FROM dbo.Company WHERE CompanyId = @CompanyId

END

GO

CREATE PROCEDURE USP_INFO
    @Model VARCHAR(128) = NULL
AS
BEGIN

    IF @Model IS NULL
    BEGIN       
        SELECT object_id, name FROM sys.procedures
        SELECT object_id, a.name, parameter_id, a.system_type_id, b.name [type]
        FROM sys.all_parameters a left join sys.types b on a.system_type_id = b.system_type_id
        WHERE object_id in (SELECT object_id FROM sys.procedures)
    END
    ELSE
    BEGIN
        SELECT object_id, name FROM sys.procedures WHERE name LIKE '%' + RTRIM(@Model) + '%'
        SELECT object_id, a.name, parameter_id, a.system_type_id, b.name [type] 
        FROM sys.all_parameters a left join sys.types b on a.system_type_id = b.system_type_id
        WHERE object_id in (SELECT object_id 
                            FROM sys.procedures 
                            WHERE name LIKE '%' + RTRIM(@Model) + '%')
    END

END