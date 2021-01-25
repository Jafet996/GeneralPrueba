
GO

/****** Object:  Table [dbo].[GarantiaPeriodo]    Script Date: 1/24/2021 3:33:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GarantiaPeriodo](
	[Emp_Id] [smallint] NOT NULL,
	[Periodo_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[CantidadMes] [smallint] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_GarantiaPeriodo] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Periodo_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


