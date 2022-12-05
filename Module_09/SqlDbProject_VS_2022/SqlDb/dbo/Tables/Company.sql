CREATE TABLE [dbo].[company] (
    [company_id] INT NOT NULL IDENTITY,
    [name] NVARCHAR (20) NOT NULL,
    [address_id] INT NOT NULL,
    CONSTRAINT [PK_company_id] PRIMARY KEY CLUSTERED ([company_id] ASC),
    CONSTRAINT [FK_address_id] FOREIGN KEY ([address_id]) REFERENCES [dbo].[address] ([address_id])
);

