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
			DECLARE @PersonId INT 
			DECLARE @AddressId INT
			DECLARE @EmployeeId INT
			DECLARE @CompanyId INT

			SET @PersonId = (SELECT MAX([peson_id]) + 1
							 FROM dbo.[person])

			SET @AddressId = (SELECT MAX([address_id]) + 1
							  FROM dbo.[address])

			SET @EmployeeId = (SELECT MAX([employee_id]) + 1
							   FROM dbo.[employee])

			SET @CompanyId = (SELECT MAX([company_id]) + 1
							   FROM dbo.[company])

			INSERT INTO dbo.[person]
						([peson_id], [first_name], [last_name])
			VALUES(@PersonId, @FirstName, @LastName)

			INSERT INTO dbo.[address]
						([address_id], [street], [city], [state], [zip_code])
			VALUES (@AddressId, @Street, @City, @State, @ZipCode)

			INSERT INTO dbo.[employee]
						([employee_id], [address_id], [person_id], [company_name], [position], [employee_name])
			VALUES (@EmployeeId, @AddressId, @PersonId, @CompanyName, @Position, @EmployeeName)

			INSERT INTO dbo.[company]
						([company_id], [name], [address_id])
			VALUES (@CompanyId, @CompanyName, @AddressId)
		END
END