CREATE PROCEDURE p_insert_employee_info (@EmployeeName NVARCHAR(100),
									@FirstName NVARCHAR(50),
									@LastName NVARCHAR(50),
									@CompanyName NVARCHAR(50),
									@Position NVARCHAR(30),
									@Street NVARCHAR(50),
									@City NVARCHAR(20),
									@State NVARCHAR(50),
									@ZipCode NVARCHAR(50))

AS
	BEGIN
		DECLARE @letter_expression NVARCHAR(10) SET @letter_expression = '[A-Za-z]%'
	
		SET @EmployeeName = (CASE WHEN (@EmployeeName IS NULL OR TRIM(@EmployeeName) LIKE '') THEN ' ' 
									ELSE @EmployeeName END)

		SET @FirstName = (CASE WHEN (@FirstName IS NULL OR TRIM(@FirstName) LIKE '') THEN ' ' 
								ELSE @FirstName END)

		SET @LastName = (CASE WHEN (@LastName IS NULL OR TRIM(@LastName) LIKE '') THEN ' '
								ELSE @LastName END)

		SET @CompanyName = (CASE WHEN LEN(@CompanyName)>20 THEN SUBSTRING(@CompanyName,0,20) 
									ELSE @CompanyName END)

	IF(@EmployeeName LIKE @letter_expression OR @FirstName LIKE @letter_expression OR @LastName LIKE @letter_expression)
		BEGIN
			INSERT INTO dbo.[person]
						([first_name], 
						[last_name])
			VALUES(@FirstName, 
					@LastName)

			INSERT INTO dbo.[address]
						([street], 
						[city], 
						[state], 
						[zip_code])
			VALUES (@Street, 
					@City, 
					@State, 
					@ZipCode)

			INSERT INTO dbo.[employee]
						([address_id], 
						[person_id], 
						[company_name], 
						[position], 
						[employee_name])
			VALUES ((SELECT MAX(address_id)
					FROM dbo.[address]), 
					(SELECt person_id 
					 FROM dbo.person
					 WHERE @EmployeeName = first_name + ' ' + last_name), 
					@CompanyName, 
					@Position, 
					@EmployeeName)

			INSERT INTO dbo.[company]
						([name], 
						[address_id])
			VALUES (@CompanyName, 
					(SELECT MAX(address_id)
					 FROM dbo.[address]))
		END
END
