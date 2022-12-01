CREATE TABLE [dbo].[Person] (
    [Id]        INT           NOT NULL,
    [FirstName] NVARCHAR (50) NOT NULL,
    [LastName]  NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_person_id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

