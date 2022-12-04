CREATE TABLE [dbo].[employee] (
    [employee_id]           INT            NOT NULL,
    [address_id]    INT            NOT NULL,
    [person_id]     INT            NOT NULL,
    [company_name]  NVARCHAR (20)  NOT NULL,
    [position]     NVARCHAR (30)  NULL,
    [employee_name] NVARCHAR (100) NULL,
    CONSTRAINT [PK_employee_id] PRIMARY KEY CLUSTERED ([employee_id] ASC),
    CONSTRAINT [FK_employee_address_id] FOREIGN KEY ([address_id]) REFERENCES [dbo].[address] ([address_id]),
    CONSTRAINT [FK_employee_person_id] FOREIGN KEY ([person_id]) REFERENCES [dbo].[person] ([peson_id])
);

