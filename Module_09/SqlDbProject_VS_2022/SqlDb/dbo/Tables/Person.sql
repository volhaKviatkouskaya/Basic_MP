CREATE TABLE [dbo].[person] (
    [person_id] INT NOT NULL IDENTITY,
    [first_name] NVARCHAR (50) NOT NULL,
    [last_name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_person_id] PRIMARY KEY CLUSTERED ([person_id] ASC)
);

