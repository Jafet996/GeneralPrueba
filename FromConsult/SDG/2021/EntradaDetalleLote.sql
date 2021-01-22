
GO

/****** Object:  Table [dbo].[EntradaDetalleLote]    Script Date: 1/21/2021 1:01:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EntradaDetalleLote](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Entrada_Id] [int] NOT NULL,
	[Detalle_Id] [smallint] NOT NULL,
	[Lote_Id] [smallint] NOT NULL,
	[Art_Id] [varchar](13) NOT NULL,
	[Lote] [varchar](20) NOT NULL,
	[Vencimiento] [date] NOT NULL,
	[Cantidad] [float] NOT NULL,
	[Bod_Id] [smallint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_EntradaDetalleLote] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Entrada_Id] ASC,
	[Detalle_Id] ASC,
	[Lote_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EntradaDetalleLote]  WITH CHECK ADD  CONSTRAINT [FK_EntradaDetalleLote_EntradaDetalle] FOREIGN KEY([Emp_Id], [Suc_Id], [Entrada_Id], [Detalle_Id])
REFERENCES [dbo].[EntradaDetalle] ([Emp_Id], [Suc_Id], [Entrada_Id], [Detalle_Id])
GO

ALTER TABLE [dbo].[EntradaDetalleLote] CHECK CONSTRAINT [FK_EntradaDetalleLote_EntradaDetalle]
GO


