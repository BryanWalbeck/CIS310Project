CREATE TABLE [dbo].[Products] (
    [ID]    NVARCHAR (5)    NOT NULL,
    [Name]  NVARCHAR (50)   NOT NULL,
	[Type]  NVARCHAR (50)   NOT NULL,
    [Price] DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);
