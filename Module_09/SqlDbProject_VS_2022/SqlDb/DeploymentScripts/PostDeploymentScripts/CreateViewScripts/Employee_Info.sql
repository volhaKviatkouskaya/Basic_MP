CREATE VIEW v_employee_info AS
		SELECT [employee].[employee_id] AS EmployeeId,
				(CASE WHEN [employee].[employee_name] = NULL THEN CONCAT(p.first_name, ' ', p.last_name)
						ELSE [employee].[employee_name]
						END) AS EmployeeFullName,
				CONCAT(a.[zip_code], '_', a.[state], ',', a.[city], '-', a.[street]) AS EmployeeFullAddress,
				CONCAT([employee].[company_name], '(', [employee].[position], ')') AS EmployeeCompanyInfo
		FROM [employee]
		JOIN [address] AS a ON [employee].[address_id] = a.[address_id]
		JOIN [person] AS p ON [employee].[person_id] = p.[person_id]
		ORDER BY [employee].[company_name], a.[city] ASC offset 0 ROWS