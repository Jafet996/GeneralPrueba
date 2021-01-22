USE [SDG-DMO]
GO

/****** Object:  Table [dbo].[ArticuloHistoricoCompra]    Script Date: 12/28/2020 10:42:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ArticuloHistoricoCompra](
	[Historial_Id] [int] NOT NULL,
	[Emp_Id] [smallint] NOT NULL,
	[Art_Id] [nchar](13) NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[TipoMovimiento] [nchar](20) NOT NULL,
	[Nombre] [nchar](100) NOT NULL,
	[ExentoIV] [bit] NOT NULL,
	[Suelto] [bit] NOT NULL,
	[Servicio] [bit] NOT NULL,
	[Costo] [money] NOT NULL,
	[CodigoCabys] [nchar](13) NOT NULL,
	[Clave] [nchar](50) NOT NULL,
 CONSTRAINT [PK_HistorialArticuloCompra] PRIMARY KEY CLUSTERED 
(
	[Historial_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


