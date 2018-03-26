CREATE TABLE [dbo].[ResponsibleParties]
(
	[ID]     INT            IDENTITY (1, 1) NOT NULL,
    [First]   NVARCHAR (50)  NOT NULL,
    [Last]   NVARCHAR (50)  NOT NULL,
	[Phone]   NVARCHAR (50)  NOT NULL,
    [Address]   NVARCHAR (50)  NOT NULL,
	[Email]   NVARCHAR (50)  NOT NULL,
    [User]   NVARCHAR (50)  NOT NULL,
    [Password]  NVARCHAR (50) NOT NULL,
    [Discount] INT            NOT NULL,
	CONSTRAINT [PK_ResponsibleParties] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [UK_ResponsibleParties] UNIQUE NONCLUSTERED ([First] ASC, [Last] ASC)
)
