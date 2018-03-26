CREATE TABLE [dbo].[Purchases]
(
	[ID]     INT            IDENTITY (1, 1) NOT NULL,
    [CustID]   INT  NOT NULL,
    [ProdID]   INT  NOT NULL,
    [Quantity]  INT  NOT NULL
)
