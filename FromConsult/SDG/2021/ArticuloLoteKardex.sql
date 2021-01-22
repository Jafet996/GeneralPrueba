
GO

/****** Object:  Table [dbo].[ArticuloLoteKardex]    Script Date: 1/20/2021 10:08:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ArticuloLoteKardex](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Bod_Id] [smallint] NOT NULL,
	[Art_Id] [varchar](13) NOT NULL,
	[Lote] [varchar](20) NOT NULL,
	[Vencimiento] [date] NOT NULL,
	[Kardex_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Cantidad] [float] NOT NULL,
	[Detalle] [varchar](200) NOT NULL,
	[Usuario_Id] [varchar](20) NOT NULL,
	[Saldo] [float] NOT NULL,
 CONSTRAINT [PK_ArticuloLoteKardex] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Bod_Id] ASC,
	[Art_Id] ASC,
	[Lote] ASC,
	[Vencimiento] ASC,
	[Kardex_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


