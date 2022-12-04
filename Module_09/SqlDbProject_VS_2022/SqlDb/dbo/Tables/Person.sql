CREATE TABLE [dbo].[person] (
    [peson_id]        INT           NOT NULL,
    [first_name] NVARCHAR (50) NOT NULL,
    [last_name]  NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_person_id] PRIMARY KEY CLUSTERED ([peson_id] ASC)
);

