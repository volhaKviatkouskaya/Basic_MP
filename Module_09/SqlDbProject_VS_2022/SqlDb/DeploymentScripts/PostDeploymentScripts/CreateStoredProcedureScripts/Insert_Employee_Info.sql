CREATE PROCEDURE p_insert_employee_info (@EmployeeName VARCHAR(100),
									@FirstName VARCHAR(50),
									@LastName VARCHAR(50),
									@CompanyName VARCHAR(20),
									@Position VARCHAR(30),
									@Street VARCHAR(50),
									@City VARCHAR(20),
									@State VARCHAR(50),
									@ZipCode VARCHAR(50))

AS
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