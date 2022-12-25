CREATE TABLE [dbo].[address] (
    [address_id] INT NOT NULL IDENTITY,
    [street] NVARCHAR (50) NOT NULL,
    [city] NVARCHAR (20) NULL,
    [state] NVARCHAR (50) NULL,
    [zip_code] NVARCHAR (50) NULL,
    CONSTRAINT [PK_address_id] PRIMARY KEY CLUSTERED ([address_id] ASC)
);
