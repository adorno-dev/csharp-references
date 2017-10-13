USE master

GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Workgroup')
-- CREATE DATABASE Workgroup ON PRIMARY (NAME=workgroup_Data, FILENAME='/var/opt/mssql/data/workgroup.mdf') LOG ON (NAME=workgroup_Log, FILENAME='/var/opt/mssql/log/workgroup.ldf')
CREATE DATABASE Workgroup

GO

USE Workgroup

GO

IF OBJECT_ID('dbo.CompanyEmployees', 'U') IS NOT NULL
DROP TABLE dbo.CompanyEmployees

GO

IF OBJECT_ID('dbo.Employees', 'U') IS NOT NULL
DROP TABLE dbo.Employees

GO

IF OBJECT_ID('dbo.Company', 'U') IS NOT NULL
DROP TABLE dbo.Company

GO

IF OBJECT_ID('dbo.Log', 'U') IS NOT NULL
DROP TABLE dbo.Log

GO

CREATE TABLE dbo.Employees
(
    EmployeeId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(50) NOT NULL,
    Location VARCHAR(50) NOT NULL
)

GO

INSERT INTO dbo.Employees 
    (Name, Location)
VALUES
    ('Steve', 'United States'),
    ('Paul', 'Turkey'),
    ('Allan', 'Germany'),
    ('Adorno', 'Brazil')

GO

CREATE TABLE dbo.Company
(
    CompanyId INT NOT NULL IDENTITY(1,1),
    Name VARCHAR(50) NOT NULL,
    Location VARCHAR(50) NOT NULL,
    PRIMARY KEY (CompanyId)
)

GO

INSERT INTO dbo.Company
    (Name, Location)
VALUES
    ('Company #A', 'Boston'),
    ('Company #B', 'Sao Paulo')

GO

CREATE TABLE dbo.CompanyEmployees
(
    CompanyEmployeeId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    CompanyId INT NOT NULL,
    EmployeeId INT NOT NULL,
    FOREIGN KEY (CompanyId) REFERENCES Company (CompanyId) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (EmployeeId) REFERENCES Employees (EmployeeId)  ON UPDATE CASCADE ON DELETE CASCADE
)

GO

INSERT INTO dbo.CompanyEmployees
    (CompanyId, EmployeeId)
VALUES
    (1, 1), (1, 2), -- Steve e Paul   (Company #A)
    (2, 3), (2, 4)  -- Allan e Adorno (Company #B)

GO

CREATE TABLE dbo.Log
(
    LogId INT NOT NULL IDENTITY(1,1),
    Message VARCHAR(255),
    PRIMARY KEY (LogId)
)

GO