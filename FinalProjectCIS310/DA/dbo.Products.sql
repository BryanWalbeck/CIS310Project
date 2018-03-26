CREATE TABLE [dbo].[Products] (
    [ID]    INT            IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (50)  NOT NULL,
    [Type]  NVARCHAR (50)  NOT NULL,
    [Price] DECIMAL (7, 2) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UK_Products] UNIQUE NONCLUSTERED ([Name] ASC, [Type] ASC)
);

