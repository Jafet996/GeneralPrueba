
GO

/****** Object:  Table [dbo].[TrasladoDetalleLote]    Script Date: 1/20/2021 2:40:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TrasladoDetalleLote](
	[Emp_Id] [smallint] NOT NULL,
	[Traslado_Id] [int] NOT NULL,
	[Detalle_Id] [smallint] NOT NULL,
	[Lote_Id] [smallint] NOT NULL,
	[Art_Id] [varchar](13) NOT NULL,
	[Lote] [varchar](20) NOT NULL,
	[Vencimiento] [date] NOT NULL,
	[Cantidad] [float] NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_TrasladoDetalleLote] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Traslado_Id] ASC,
	[Detalle_Id] ASC,
	[Lote_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TrasladoDetalleLote]  WITH CHECK ADD  CONSTRAINT [FK_TrasladoDetalleLote_Articulo] FOREIGN KEY([Emp_Id], [Art_Id])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO

ALTER TABLE [dbo].[TrasladoDetalleLote] CHECK CONSTRAINT [FK_TrasladoDetalleLote_Articulo]
GO

ALTER TABLE [dbo].[TrasladoDetalleLote]  WITH CHECK ADD  CONSTRAINT [FK_TrasladoDetalleLote_TrasladoDetalle] FOREIGN KEY([Emp_Id], [Traslado_Id], [Detalle_Id])
REFERENCES [dbo].[TrasladoDetalle] ([Emp_Id], [Traslado_Id], [Detalle_Id])
GO

ALTER TABLE [dbo].[TrasladoDetalleLote] CHECK CONSTRAINT [FK_TrasladoDetalleLote_TrasladoDetalle]
GO


