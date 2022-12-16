CREATE VIEW v_employee_info AS
  SELECT [employee].[employee_id] AS EmployeeId,
		 (CASE 
				WHEN [employee].[employee_name] = null THEN (SELECT [person].[first_name] + ' ' + [person].[last_name]
														FROM [person])
				ELSE [employee].[employee_name]
				END) AS EmployeeFullName,
				CONCAT([address].[zip_code], '_', [address].[state], ',', [address].[city], '-', [address].[street]) AS EmployeeFullAddress,
				CONCAT([employee].[company_name], '(', [employee].[position], ')') AS EmployeeCompanyInfo
  FROM [employee]
  JOIN [address] ON [employee].[address_id] = [address].[address_id]
  JOIN [person] ON [employee].[person_id] = [person].[person_id]
  ORDER BY [employee].[company_name], [address].[city] ASC offset 0 ROWS
