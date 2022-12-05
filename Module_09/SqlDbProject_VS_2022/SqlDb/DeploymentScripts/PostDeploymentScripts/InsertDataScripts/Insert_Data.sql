PRINT 'Insert data to Person table'
    INSERT dbo.[person]
    VALUES ('Harry', 'Potter'),
           ('Hermione', 'Granger'),
           ('Ron', 'Weasley'),
           ('Albus', 'Dumbledore'),
           ('Draco', 'Malfoy')

PRINT 'Insert data to Address table'     
    INSERT dbo.[address]
    VALUES ('Great Scotland Yard', 'London', 'Red Box', '01-001'),
           ('Hogwarts Castle', 'Highlands', 'Scottish', '07-007')

PRINT 'Insert data to Employee table'
	DECLARE @Address_first INT SET @Address_first = 1
	DECLARE @Address_second INT SET @Address_second = 2

    INSERT dbo.[employee]
    VALUES (@Address_first, (SELECT person_id 
				FROM dbo.[person]
				WHERE first_name + ' ' + last_name = 'Harry Potter'), 'Ministry of Magic', 'Head', 'Harry Potter'),
           (@Address_first, (SELECT person_id 
				FROM dbo.[person]
				WHERE first_name + ' ' + last_name = 'Hermione Granger'), 'Ministry of Magic', 'Minister', 'Hermione Granger'),
           (@Address_first, (SELECT person_id 
				FROM dbo.[person]
				WHERE first_name + ' ' + last_name = 'Ron Weasley'), 'Ministry of Magic', 'Auror', 'Ron Weasley'),
           (@Address_second, (SELECT person_id 
				FROM dbo.[person]
				WHERE first_name + ' ' + last_name = 'Albus Dumbledore'), 'Hogwarts', 'Director', 'Albus Dumbledore'),
           (@Address_first, (SELECT person_id 
				FROM dbo.[person]
				WHERE first_name + ' ' + last_name = 'Draco Malfoy'), 'Ministry of Magic', 'Employee', 'Draco Malfoy')
        
PRINT 'Insert data to Company table'
    INSERT dbo.[company]
    VALUES ('Ministry of Magic', @Address_first),
           ('Hogwarts', @Address_second)