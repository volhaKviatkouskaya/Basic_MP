CREATE VIEW vv_employee_info AS
		SELECT [employee].[employee_id] AS EmployeeId, 
				[employee].[employee_name] AS EmployeeFullName,
				CONCAT([address].[zip_code], '_', [address].[state], ',', [address].[city], '-', [address].[street]) AS EmployeeFullAddress,
				CONCAT([employee].[company_name], '(', [employee].[position], ')') AS EmployeeCompanyInfo
		FROM [employee]
		JOIN [address] ON [employee].[address_id] = [address].[address_id]
		JOIN [person] ON [employee].[person_id] = [person].[person_id]
		ORDER BY [employee].[company_name], [address].[city] ASC offset 0 ROWS
