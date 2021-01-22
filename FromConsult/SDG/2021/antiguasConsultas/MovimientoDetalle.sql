USE [SDG-DMO]
GO

/****** Object:  Table [dbo].[MovimientoDetalle]    Script Date: 1/20/2021 9:06:23 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MovimientoDetalle](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[TipoMov_Id] [smallint] NOT NULL,
	[Mov_Id] [int] NOT NULL,
	[Detalle_Id] [smallint] NOT NULL,
	[Art_Id] [varchar](13) NOT NULL,
	[Cantidad] [float] NOT NULL,
	[Costo] [money] NOT NULL,
	[TotalLinea] [money] NOT NULL,
	[Suelto] [bit] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_MovimientoDetalle] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[TipoMov_Id] ASC,
	[Mov_Id] ASC,
	[Detalle_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MovimientoDetalle]  WITH CHECK ADD  CONSTRAINT [FK_MovimientoDetalle_Articulo] FOREIGN KEY([Emp_Id], [Art_Id])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO

ALTER TABLE [dbo].[MovimientoDetalle] CHECK CONSTRAINT [FK_MovimientoDetalle_Articulo]
GO

ALTER TABLE [dbo].[MovimientoDetalle]  WITH CHECK ADD  CONSTRAINT [FK_MovimientoDetalle_MovimientoEncabezado] FOREIGN KEY([Emp_Id], [Suc_Id], [TipoMov_Id], [Mov_Id])
REFERENCES [dbo].[MovimientoEncabezado] ([Emp_Id], [Suc_Id], [TipoMov_Id], [Mov_Id])
GO

ALTER TABLE [dbo].[MovimientoDetalle] CHECK CONSTRAINT [FK_MovimientoDetalle_MovimientoEncabezado]
GO


