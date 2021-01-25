
GO

/****** Object:  Table [dbo].[FacturaDetalleLote]    Script Date: 1/25/2021 8:48:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FacturaDetalleLote](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Caja_Id] [smallint] NOT NULL,
	[TipoDoc_Id] [smallint] NOT NULL,
	[Documento_Id] [bigint] NOT NULL,
	[Detalle_Id] [smallint] NOT NULL,
	[Lote_Id] [smallint] NOT NULL,
	[Art_Id] [varchar](13) NOT NULL,
	[Lote] [varchar](20) NOT NULL,
	[Vencimiento] [date] NOT NULL,
	[Cantidad] [float] NOT NULL,
	[Bod_Id] [smallint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_FacturaDetalleLote] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Caja_Id] ASC,
	[TipoDoc_Id] ASC,
	[Documento_Id] ASC,
	[Detalle_Id] ASC,
	[Lote_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FacturaDetalleLote]  WITH CHECK ADD  CONSTRAINT [FK_FacturaDetalleLote_Articulo] FOREIGN KEY([Emp_Id], [Art_Id])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO

ALTER TABLE [dbo].[FacturaDetalleLote] CHECK CONSTRAINT [FK_FacturaDetalleLote_Articulo]
GO

ALTER TABLE [dbo].[FacturaDetalleLote]  WITH CHECK ADD  CONSTRAINT [FK_FacturaDetalleLote_Bodega] FOREIGN KEY([Emp_Id], [Suc_Id], [Bod_Id])
REFERENCES [dbo].[Bodega] ([Emp_Id], [Suc_Id], [Bod_Id])
GO

ALTER TABLE [dbo].[FacturaDetalleLote] CHECK CONSTRAINT [FK_FacturaDetalleLote_Bodega]
GO

ALTER TABLE [dbo].[FacturaDetalleLote]  WITH CHECK ADD  CONSTRAINT [FK_FacturaDetalleLote_FacturaDetalle] FOREIGN KEY([Emp_Id], [Suc_Id], [Caja_Id], [TipoDoc_Id], [Documento_Id], [Detalle_Id])
REFERENCES [dbo].[FacturaDetalle] ([Emp_Id], [Suc_Id], [Caja_Id], [TipoDoc_Id], [Documento_Id], [Detalle_Id])
GO

ALTER TABLE [dbo].[FacturaDetalleLote] CHECK CONSTRAINT [FK_FacturaDetalleLote_FacturaDetalle]
GO


