    PRINT 'Insert data to Person table';
    INSERT dbo.[person]
    VALUES (1, 'Harry', 'Potter'),
           (2, 'Hermione', 'Granger'),
           (3, 'Ron', 'Weasley'),
           (4, 'Albus', 'Dumbledore'),
           (5, 'Draco', 'Malfoy');

    PRINT 'Insert data to Address table';      
    INSERT dbo.[address]
    VALUES (1, 'Great Scotland Yard', 'London', 'Red Box', '01-001'),
           (2, 'Hogwarts Castle', 'Highlands', 'Scottish', '07-007');

    PRINT 'Insert data to Employee table';
    INSERT dbo.[employee]
    VALUES (1, 1, 1, 'Ministry of Magic', 'Head', 'Harry Potter'),
           (2, 1, 2, 'Ministry of Magic', 'Minister', 'Hermione Granger'),
           (3, 1, 3, 'Ministry of Magic', 'Auror', 'Ron Weasley'),
           (4, 2, 4, 'Hogwarts', 'Director', 'Albus Dumbledore'),
           (5, 1, 5, 'Ministry of Magic', 'Employee', 'Draco Malfoy');
        
    PRINT 'Insert data to Company table';
    INSERT dbo.[company]
    VALUES (1, 'Ministry of Magic', 1),
           (2, 'Hogwarts', 2);
