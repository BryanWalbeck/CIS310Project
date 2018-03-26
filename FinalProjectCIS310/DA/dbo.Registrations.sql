CREATE TABLE [dbo].[Registrations]
(
	[ID]       INT           IDENTITY (1, 1) NOT NULL,
    [CustID]   INT           NOT NULL,
    [LessonID]   INT           NOT NULL,
    [Scheduled] NVARCHAR (50)           NOT NULL,
    [Completed]      NVARCHAR (50) DEFAULT ((0)) NOT NULL,
	[Canceled] NVARCHAR (50)           NOT NULL,
    CONSTRAINT [PK_Registrations] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Registrations_Customers] FOREIGN KEY ([CustID]) REFERENCES [dbo].[Customers] ([ID]),
    CONSTRAINT [FK_Registrations_Lessons] FOREIGN KEY ([LessonID]) REFERENCES [dbo].[Lessons] ([ID])
)
