CREATE TABLE [dbo].[Customers]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[RPID] INT NOT NULL,
	[First]    NVARCHAR (50) NOT NULL,
    [Last]     NVARCHAR (50) NOT NULL,
    [Phone]    NVARCHAR (50) NOT NULL,
    [Address]  NVARCHAR (50) NOT NULL,
    [Email]    NVARCHAR (50) NOT NULL,
    [User]     NVARCHAR (50) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL
	CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UK_Customers] UNIQUE NONCLUSTERED ([First] ASC, [Last] ASC),
	CONSTRAINT [FK_Customers_ResponsibleParties] FOREIGN KEY ([RPID]) REFERENCES [dbo].[ResponsibleParties] ([ID])
)
