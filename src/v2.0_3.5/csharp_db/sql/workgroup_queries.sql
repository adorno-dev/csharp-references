USE Workgroup

GO

-- SELECT * FROM dbo.Employees
-- SELECT * FROM dbo.Company
-- SELECT * FROM dbo.CompanyEmployees

-- GO

-- SELECT 
--     E.Name,
--     C.Name,
--     C.[Location]
-- FROM 
--     dbo.CompanyEmployees CE
--     INNER JOIN
--     dbo.Company C
--     ON CE.CompanyId = C.CompanyId
--     LEFT JOIN
--     dbo.Employees E
--     ON CE.EmployeesId = E.EmployeesId

-- EXEC dbo.USP_SELECT_COMPANY
-- EXEC dbo.USP_SELECT_EMPLOYEE

-- SELECT * FROM dbo.Company ORDER BY CompanyId DESC

-- SELECT * FROM sys.database_files

-- DROP DATABASE Workgroup

USP_INFO 'EMPLOYEE'
USP_DELETE_EMPLOYEE 1
USP_SELECT_EMPLOYEE

SELECT * FROM Log

DELETE FROM Employees WHERE EmployeeId = 1
SELECT * FROM Employees



SELECT object_id, name FROM sys.procedures

GO

SELECT object_id, a.name, parameter_id, a.system_type_id, b.name [type] 
FROM sys.all_parameters a left join sys.types b on a.system_type_id = b.system_type_id
WHERE object_id in (SELECT object_id FROM sys.procedures)

SELECT * FROM sys.types