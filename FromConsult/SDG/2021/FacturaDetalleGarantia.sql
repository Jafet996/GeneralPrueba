
GO

/****** Object:  Table [dbo].[FacturaDetalleGarantia]    Script Date: 1/25/2021 9:00:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FacturaDetalleGarantia](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Caja_Id] [smallint] NOT NULL,
	[TipoDoc_Id] [smallint] NOT NULL,
	[Documento_Id] [bigint] NOT NULL,
	[Detalle_Id] [smallint] NOT NULL,
	[Garantia_Id] [bigint] NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaFinal] [datetime] NOT NULL,
	[OrdenNumero] [varchar](30) NOT NULL,
	[Usuario_Id] [varchar](20) NOT NULL,
 CONSTRAINT [PK_FacturaDetalleGarantia] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Caja_Id] ASC,
	[TipoDoc_Id] ASC,
	[Documento_Id] ASC,
	[Detalle_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FacturaDetalleGarantia]  WITH CHECK ADD  CONSTRAINT [FK_FacturaDetalleGarantia_FacturaDetalle] FOREIGN KEY([Emp_Id], [Suc_Id], [Caja_Id], [TipoDoc_Id], [Documento_Id], [Detalle_Id])
REFERENCES [dbo].[FacturaDetalle] ([Emp_Id], [Suc_Id], [Caja_Id], [TipoDoc_Id], [Documento_Id], [Detalle_Id])
GO

ALTER TABLE [dbo].[FacturaDetalleGarantia] CHECK CONSTRAINT [FK_FacturaDetalleGarantia_FacturaDetalle]
GO

ALTER TABLE [dbo].[FacturaDetalleGarantia]  WITH CHECK ADD  CONSTRAINT [FK_FacturaDetalleGarantia_Usuario] FOREIGN KEY([Emp_Id], [Usuario_Id])
REFERENCES [dbo].[Usuario] ([Emp_Id], [Usuario_Id])
GO

ALTER TABLE [dbo].[FacturaDetalleGarantia] CHECK CONSTRAINT [FK_FacturaDetalleGarantia_Usuario]
GO


