CREATE TABLE [dbo].[Lessons] (
    [ID]     INT            IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (50)  NOT NULL,
    [Type]   NVARCHAR (50)  NOT NULL,
    [Price]  DECIMAL (7, 2) NOT NULL,
    [Length] INT            NOT NULL,
	CONSTRAINT [PK_Lessons] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [UK_Lessons] UNIQUE NONCLUSTERED ([Name] ASC, [Type] ASC, [Price] ASC, [Length] ASC)
);

