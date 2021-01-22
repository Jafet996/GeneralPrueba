
GO

/****** Object:  Table [dbo].[ArticuloBodegaLote]    Script Date: 1/20/2021 10:04:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ArticuloBodegaLote](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Bod_Id] [smallint] NOT NULL,
	[Art_Id] [varchar](13) NOT NULL,
	[Lote] [varchar](20) NOT NULL,
	[Vencimiento] [date] NOT NULL,
	[Saldo] [float] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_ArticuloBodegaLote] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Bod_Id] ASC,
	[Art_Id] ASC,
	[Lote] ASC,
	[Vencimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ArticuloBodegaLote] ADD  CONSTRAINT [DF_ArticuloBodegaLote_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO

ALTER TABLE [dbo].[ArticuloBodegaLote]  WITH CHECK ADD  CONSTRAINT [FK_ArticuloBodegaLote_ArticuloBodega] FOREIGN KEY([Emp_Id], [Suc_Id], [Bod_Id], [Art_Id])
REFERENCES [dbo].[ArticuloBodega] ([Emp_Id], [Suc_Id], [Bod_Id], [Art_Id])
GO

ALTER TABLE [dbo].[ArticuloBodegaLote] CHECK CONSTRAINT [FK_ArticuloBodegaLote_ArticuloBodega]
GO


