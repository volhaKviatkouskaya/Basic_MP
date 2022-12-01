CREATE TABLE [dbo].[Company] (
    [Id]        INT           NOT NULL,
    [Name]      NVARCHAR (20) NOT NULL,
    [AddressId] INT           NOT NULL,
    CONSTRAINT [PK_company_id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_address_id] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id])
);

