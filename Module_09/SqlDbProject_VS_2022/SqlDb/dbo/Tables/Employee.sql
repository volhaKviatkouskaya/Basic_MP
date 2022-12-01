CREATE TABLE [dbo].[Employee] (
    [Id]           INT            NOT NULL,
    [AddressId]    INT            NOT NULL,
    [PersonId]     INT            NOT NULL,
    [CompanyName]  NVARCHAR (20)  NOT NULL,
    [Position]     NVARCHAR (30)  NULL,
    [EmployeeName] NVARCHAR (100) NULL,
    CONSTRAINT [PK_employee_id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_employee_address_id] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id]),
    CONSTRAINT [FK_employee_person_id] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id])
);

