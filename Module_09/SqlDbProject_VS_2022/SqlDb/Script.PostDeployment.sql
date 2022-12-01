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
VALUES (1, 'Great Scotland Yard', 'London', NULL, NULL),
       (2, 'Hogwarts Castle', 'Highlands', 'Scottish', NULL);

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