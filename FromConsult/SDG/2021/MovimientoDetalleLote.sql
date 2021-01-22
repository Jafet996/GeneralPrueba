
GO

/****** Object:  Table [dbo].[MovimientoDetalleLote]    Script Date: 1/20/2021 8:37:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MovimientoDetalleLote](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[TipoMov_Id] [smallint] NOT NULL,
	[Mov_Id] [int] NOT NULL,
	[Detalle_Id] [smallint] NOT NULL,
	[Lote_Id] [smallint] NOT NULL,
	[Art_Id] [varchar](13) NOT NULL,
	[Lote] [varchar](20) NOT NULL,
	[Vencimiento] [date] NOT NULL,
	[Cantidad] [float] NOT NULL,
	[Bod_Id] [smallint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_MovimientoDetalleLote] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[TipoMov_Id] ASC,
	[Mov_Id] ASC,
	[Detalle_Id] ASC,
	[Lote_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MovimientoDetalleLote]  WITH CHECK ADD  CONSTRAINT [FK_MovimientoDetalleLote_Articulo] FOREIGN KEY([Emp_Id], [Art_Id])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO

ALTER TABLE [dbo].[MovimientoDetalleLote] CHECK CONSTRAINT [FK_MovimientoDetalleLote_Articulo]
GO

ALTER TABLE [dbo].[MovimientoDetalleLote]  WITH CHECK ADD  CONSTRAINT [FK_MovimientoDetalleLote_Bodega] FOREIGN KEY([Emp_Id], [Suc_Id], [Bod_Id])
REFERENCES [dbo].[Bodega] ([Emp_Id], [Suc_Id], [Bod_Id])
GO

ALTER TABLE [dbo].[MovimientoDetalleLote] CHECK CONSTRAINT [FK_MovimientoDetalleLote_Bodega]
GO

ALTER TABLE [dbo].[MovimientoDetalleLote]  WITH CHECK ADD  CONSTRAINT [FK_MovimientoDetalleLote_Empresa] FOREIGN KEY([Emp_Id])
REFERENCES [dbo].[Empresa] ([Emp_Id])
GO

ALTER TABLE [dbo].[MovimientoDetalleLote] CHECK CONSTRAINT [FK_MovimientoDetalleLote_Empresa]
GO

ALTER TABLE [dbo].[MovimientoDetalleLote]  WITH CHECK ADD  CONSTRAINT [FK_MovimientoDetalleLote_MovimientoDetalleLote] FOREIGN KEY([Emp_Id], [Suc_Id], [TipoMov_Id], [Mov_Id], [Detalle_Id])
REFERENCES [dbo].[MovimientoDetalle] ([Emp_Id], [Suc_Id], [TipoMov_Id], [Mov_Id], [Detalle_Id])
GO

ALTER TABLE [dbo].[MovimientoDetalleLote] CHECK CONSTRAINT [FK_MovimientoDetalleLote_MovimientoDetalleLote]
GO

ALTER TABLE [dbo].[MovimientoDetalleLote]  WITH CHECK ADD  CONSTRAINT [FK_MovimientoDetalleLote_Sucursal] FOREIGN KEY([Emp_Id], [Suc_Id])
REFERENCES [dbo].[Sucursal] ([Emp_Id], [Suc_Id])
GO

ALTER TABLE [dbo].[MovimientoDetalleLote] CHECK CONSTRAINT [FK_MovimientoDetalleLote_Sucursal]
GO


