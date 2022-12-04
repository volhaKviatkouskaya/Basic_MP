/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
    PRINT 'Insert data to Person table';
    INSERT dbo.Person
    VALUES (1, 'Harry', 'Potter'),
           (2, 'Hermione', 'Granger'),
           (3, 'Ron', 'Weasley'),
           (4, 'Albus', 'Dumbledore'),
           (5, 'Draco', 'Malfoy');

    PRINT 'Insert data to Address table';      
    INSERT dbo.Address
    VALUES (1, 'Great Scotland Yard', 'London', 'Red Box', '01-001'),
           (2, 'Hogwarts Castle', 'Highlands', 'Scottish', '07-007');

    PRINT 'Insert data to Employee table';
    INSERT dbo.Employee
    VALUES (1, 1, 1, 'Ministry of Magic', 'Head', 'Harry Potter'),
           (2, 1, 2, 'Ministry of Magic', 'Minister', 'Hermione Granger'),
           (3, 1, 3, 'Ministry of Magic', 'Auror', 'Ron Weasley'),
           (4, 2, 4, 'Hogwarts', 'Director', 'Albus Dumbledore'),
           (5, 1, 5, 'Ministry of Magic', 'Employee', 'Draco Malfoy');
        
    PRINT 'Insert data to Company table';
    INSERT dbo.Company
    VALUES (1, 'Ministry of Magic', 1),
           (2, 'Hogwarts', 2);
GO

CREATE VIEW EmployeeInfo AS
  SELECT Employee.Id AS EmployeeId,
		 (CASE 
				WHEN Employee.EmployeeName = null THEN (SELECT Person.FirstName + ' ' + Person.LastName
														FROM Person)
				ELSE Employee.EmployeeName
				END) AS EmployeeFullName,
		 (Address.ZipCode + '_' + Address.State + ',' + Address.City + '-' + Address.Street) AS EmployeeFullAddress,
		 (Employee.CompanyName + '(' + Employee.Position + ')') AS EmployeeCompanyInfo
  FROM Employee
  JOIN Address ON Employee.AddressId = Address.Id
  JOIN Person ON Employee.PersonId = Person.Id
  ORDER BY Employee.CompanyName, Address.City ASC offset 0 ROWS

GO
CREATE PROCEDURE InsertEmployeeInfo (@EmployeeName VARCHAR(100),
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

			SET @PersonId = (SELECT MAX(Id) + 1
							 FROM dbo.Person)

			SET @AddressId = (SELECT MAX(Id) + 1
							  FROM dbo.Address)

			SET @EmployeeId = (SELECT MAX(Id) + 1
							   FROM dbo.Employee)

			SET @CompanyId = (SELECT MAX(Id) + 1
							   FROM dbo.Company)

			INSERT INTO dbo.Person
						(Id, FirstName, LastName)
			VALUES(@PersonId, @FirstName, @LastName)

			INSERT INTO dbo.Address
						(Id, Street, City, State, ZipCode)
			VALUES (@AddressId, @Street, @City, @State, @ZipCode)

			INSERT INTO dbo.Employee
						(Id, AddressId, PersonId, CompanyName, Position, EmployeeName)
			VALUES (@EmployeeId, @AddressId, @PersonId, @CompanyName, @Position, @EmployeeName)

			INSERT INTO dbo.Company
						(Id, Name, AddressId)
			VALUES (@CompanyId, @CompanyName, @AddressId)
		
END

GO