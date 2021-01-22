GO

/****** Object:  UserDefinedTableType [dbo].[InfoLotes]    Script Date: 1/20/2021 9:35:59 AM ******/
CREATE TYPE [dbo].[InfoLotes] AS TABLE(
	[Art_Id] [varchar](13) NOT NULL,
	[Lote] [varchar](20) NOT NULL,
	[Vencimiento] [date] NOT NULL,
	[Cantidad] [float] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[Art_Id] ASC,
	[Lote] ASC,
	[Vencimiento] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO


