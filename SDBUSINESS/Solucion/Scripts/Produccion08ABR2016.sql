/****** Object:  Database [Produccion]    Script Date: 4/8/2016 3:47:22 PM ******/
CREATE DATABASE [Produccion]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Produccion', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Perfumes12Oct2015.mdf' , SIZE = 106496KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Produccion_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Perfumes12Oct2015_1.ldf' , SIZE = 388544KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Produccion] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Produccion].[dbo].[sp_fulltext_database] @action = 'disable'
end
GO
ALTER DATABASE [Produccion] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Produccion] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Produccion] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Produccion] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Produccion] SET ARITHABORT OFF 
GO
ALTER DATABASE [Produccion] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Produccion] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Produccion] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Produccion] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Produccion] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Produccion] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Produccion] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Produccion] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Produccion] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Produccion] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Produccion] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Produccion] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Produccion] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Produccion] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Produccion] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Produccion] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Produccion] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Produccion] SET RECOVERY FULL 
GO
ALTER DATABASE [Produccion] SET  MULTI_USER 
GO
ALTER DATABASE [Produccion] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Produccion] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Produccion] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Produccion] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Produccion] SET DELAYED_DURABILITY = DISABLED 
GO
/****** Object:  User [ESCRITORIO\temporal]    Script Date: 4/8/2016 3:47:22 PM ******/
CREATE USER [ESCRITORIO\temporal] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[SDF_SplitString]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[SDF_SplitString]
(
    @sString nvarchar(2048),
    @cDelimiter nchar(1)
)
RETURNS @tParts TABLE ( part nvarchar(2048) )
AS
BEGIN
    if @sString is null return
    declare	@iStart int,
    		@iPos int
    if substring( @sString, 1, 1 ) = @cDelimiter 
    begin
    	set	@iStart = 2
    	insert into @tParts
    	values( null )
    end
    else 
    	set	@iStart = 1
    while 1=1
    begin
    	set	@iPos = charindex( @cDelimiter, @sString, @iStart )
    	if @iPos = 0
    		set	@iPos = len( @sString )+1
    	if @iPos - @iStart > 0			
    		insert into @tParts
    		values	( substring( @sString, @iStart, @iPos-@iStart ))
    	else
    		insert into @tParts
    		values( null )
    	set	@iStart = @iPos+1
    	if @iStart > len( @sString ) 
    		break
    end
    RETURN

END
GO
/****** Object:  Table [dbo].[AjusteCosto]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AjusteCosto](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Ajuste_Id] [int] NOT NULL,
	[Bod_Id] [smallint] NOT NULL,
	[Art_Id] [varchar](13) NOT NULL,
	[CostoAnterior] [money] NOT NULL,
	[CostoNuevo] [money] NOT NULL,
	[Usuario_Id] [varchar](20) NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_AjusteCosto_1] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Ajuste_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Articulo]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Articulo](
	[Emp_Id] [smallint] NOT NULL,
	[Art_Id] [varchar](13) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Cat_Id] [smallint] NOT NULL,
	[SubCat_Id] [smallint] NOT NULL,
	[Departamento_Id] [smallint] NOT NULL,
	[UnidadMedida_Id] [smallint] NOT NULL,
	[FactorConversion] [smallint] NOT NULL,
	[ExentoIV] [bit] NOT NULL,
	[Suelto] [bit] NOT NULL,
	[ArtPadre] [varchar](13) NULL,
	[SolicitarCantidad] [bit] NOT NULL CONSTRAINT [DF_Articulo_SolicitaCantidadFacturacion]  DEFAULT ((0)),
	[PermiteFacturar] [bit] NOT NULL,
	[CodigoCantidad] [bit] NOT NULL,
	[CodigoCantidadTipo] [smallint] NOT NULL CONSTRAINT [DF_Articulo_CodigoCantidadTipo]  DEFAULT ((0)),
	[BusquedaRapida] [bit] NOT NULL CONSTRAINT [DF_Articulo_BusquedaRapida]  DEFAULT ((0)),
	[Frecuente] [bit] NOT NULL CONSTRAINT [DF_Articulo_Frecuente]  DEFAULT ((0)),
	[Servicio] [bit] NOT NULL,
	[TipoAcumulacion_Id] [smallint] NOT NULL CONSTRAINT [DF_Articulo_TipoAcumulacion_Id]  DEFAULT ((0)),
	[Activo] [bit] NOT NULL CONSTRAINT [DF_Articulo_Activo]  DEFAULT ((1)),
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Articulo_UltimaModificacion]  DEFAULT (getdate()),
 CONSTRAINT [PK_Articulo] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Art_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArticuloAnotacion]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ArticuloAnotacion](
	[Emp_Id] [smallint] NOT NULL,
	[Art_Id] [varchar](13) NOT NULL,
	[Anotacion_Id] [int] NOT NULL,
	[Anotacion] [varchar](1000) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Usuario_Id] [varchar](20) NOT NULL,
 CONSTRAINT [PK_ArticuloAnotacion] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Art_Id] ASC,
	[Anotacion_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArticuloBodega]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ArticuloBodega](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Bod_Id] [smallint] NOT NULL,
	[Art_Id] [varchar](13) NOT NULL,
	[Saldo] [float] NOT NULL CONSTRAINT [DF_ArticuloBodega_Saldo]  DEFAULT ((0)),
	[Comprometido] [float] NOT NULL CONSTRAINT [DF_ArticuloBodega_Comprometido]  DEFAULT ((0)),
	[Transito] [float] NOT NULL CONSTRAINT [DF_ArticuloBodega_Transito]  DEFAULT ((0)),
	[CostoPromedio] [money] NOT NULL CONSTRAINT [DF_ArticuloBodega_CostoPromedio]  DEFAULT ((0)),
	[Costo] [money] NOT NULL CONSTRAINT [DF_ArticuloBodega_Costo]  DEFAULT ((0)),
	[Margen] [float] NOT NULL CONSTRAINT [DF_ArticuloBodega_Margen]  DEFAULT ((0)),
	[MargenMayorista] [float] NOT NULL,
	[Precio] [money] NOT NULL CONSTRAINT [DF_ArticuloBodega_Precio]  DEFAULT ((0)),
	[PrecioMayorista] [money] NOT NULL,
	[FechaIniDescuento] [datetime] NOT NULL CONSTRAINT [DF_ArticuloBodega_FechaInicioDescuento]  DEFAULT ('19000101'),
	[FechaFinDescuento] [datetime] NOT NULL CONSTRAINT [DF_ArticuloBodega_FechaInicioDescuento1]  DEFAULT ('19000101'),
	[PorcDescuento] [float] NOT NULL CONSTRAINT [DF_ArticuloBodega_PorcDescuento]  DEFAULT ((0)),
	[FechaUltimaVenta] [datetime] NOT NULL CONSTRAINT [DF_ArticuloBodega_FechaUltimaVenta]  DEFAULT ('1900/01/01'),
	[PromedioVenta] [float] NOT NULL CONSTRAINT [DF_ArticuloBodega_PromedioVentaDiario]  DEFAULT ((0)),
	[Minimo] [float] NOT NULL CONSTRAINT [DF_ArticuloBodega_Minimo]  DEFAULT ((0)),
	[Maximo] [float] NOT NULL CONSTRAINT [DF_ArticuloBodega_Maximo]  DEFAULT ((0)),
	[Activo] [bit] NOT NULL CONSTRAINT [DF_ArticuloBodega_Activo]  DEFAULT ((1)),
	[Ubicacion] [varchar](20) NOT NULL CONSTRAINT [DF_ArticuloBodega_Ubicacion]  DEFAULT (''),
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_ArticuloBodega_UltimaModificacion]  DEFAULT (getdate()),
 CONSTRAINT [PK_ArticuloBodega] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Bod_Id] ASC,
	[Art_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArticuloConjunto]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ArticuloConjunto](
	[Emp_Id] [smallint] NOT NULL,
	[Art_Id] [varchar](13) NOT NULL,
	[ArtConjunto_Id] [varchar](13) NOT NULL,
	[Cantidad] [smallint] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_ArticuloConjunto_UltimaModificacion]  DEFAULT (getdate()),
 CONSTRAINT [PK_ArticuloConjunto] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Art_Id] ASC,
	[ArtConjunto_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArticuloConteo]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ArticuloConteo](
	[Emp_Id] [smallint] NOT NULL,
	[Art_Id] [varchar](13) NOT NULL,
	[Cantidad] [float] NOT NULL,
	[Procesado] [bit] NOT NULL,
 CONSTRAINT [PK_ArticuloConteo] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Art_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArticuloEquivalente]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ArticuloEquivalente](
	[Emp_Id] [smallint] NOT NULL,
	[Art_Id] [varchar](13) NOT NULL,
	[ArtEquivalente_Id] [varchar](13) NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_ArticuloEquivalente_UltimaModificacion]  DEFAULT (getdate()),
 CONSTRAINT [PK_ArticuloEquivalente] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Art_Id] ASC,
	[ArtEquivalente_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArticuloKardex]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ArticuloKardex](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Bod_Id] [smallint] NOT NULL,
	[Art_Id] [varchar](13) NOT NULL,
	[Kardex_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Cantidad] [float] NOT NULL,
	[Detalle] [varchar](200) NOT NULL,
	[Usuario_Id] [varchar](20) NOT NULL,
	[Saldo] [float] NOT NULL,
	[Suelto] [bit] NOT NULL CONSTRAINT [DF_ArticuloKardex_Suelto]  DEFAULT ((0)),
 CONSTRAINT [PK_ArticuloKardex] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Bod_Id] ASC,
	[Art_Id] ASC,
	[Kardex_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArticuloProveedor]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ArticuloProveedor](
	[Emp_Id] [smallint] NOT NULL,
	[Art_Id] [varchar](13) NOT NULL,
	[Prov_Id] [int] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_ArticuloProveedor_UltimaModificacion]  DEFAULT (getdate()),
 CONSTRAINT [PK_ArticuloProveedor] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Art_Id] ASC,
	[Prov_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArticuloTemporal]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ArticuloTemporal](
	[Emp_Id] [smallint] NOT NULL,
	[Art_Id] [varchar](13) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Cat_Id] [smallint] NOT NULL,
	[SubCat_Id] [smallint] NOT NULL,
	[Departamento_Id] [smallint] NOT NULL,
	[UnidadMedida_Id] [smallint] NOT NULL,
	[FactorConversion] [smallint] NOT NULL,
	[ExentoIV] [bit] NOT NULL,
	[Precio] [money] NOT NULL,
	[Suelto] [bit] NOT NULL,
	[CodigoManual] [bit] NOT NULL,
 CONSTRAINT [PK_ArticuloTemporal] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Art_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Banco]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Banco](
	[Emp_Id] [smallint] NOT NULL,
	[Banco_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Transferencia] [bit] NOT NULL CONSTRAINT [DF_Banco_Transferencia_1]  DEFAULT ((0)),
	[Activo] [bit] NOT NULL CONSTRAINT [DF_Banco_Activo]  DEFAULT ((1)),
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Banco_UltimaModificacion]  DEFAULT (getdate()),
 CONSTRAINT [PK_Banco] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Banco_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BitacoraUsuario]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BitacoraUsuario](
	[Bitacora_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Modulo_Id] [smallint] NOT NULL,
	[Emp_Id] [smallint] NULL,
	[Usuario_Id] [varchar](20) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
 CONSTRAINT [PK_BitacoraUsuario] PRIMARY KEY CLUSTERED 
(
	[Bitacora_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bodega]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bodega](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Bod_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL CONSTRAINT [DF_Bodega_Activo]  DEFAULT ((1)),
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Bodega_UltimaModificacion]  DEFAULT (getdate()),
 CONSTRAINT [PK_Bodega] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Bod_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Botones]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Botones](
	[Emp_Id] [smallint] NOT NULL,
	[BotonTipo] [smallint] NOT NULL,
	[Ancho] [smallint] NOT NULL,
	[Espacio] [smallint] NOT NULL,
	[Alto] [smallint] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Botones] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[BotonTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Caja]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Caja](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Caja_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Bod_Id] [smallint] NOT NULL,
	[Abierta] [bit] NOT NULL CONSTRAINT [DF_Caja_Abierta]  DEFAULT ((0)),
	[Cierre_Id] [int] NOT NULL CONSTRAINT [DF_Caja_Cierre_Id]  DEFAULT ((0)),
	[Prefacturas] [bit] NOT NULL,
	[Activo] [bit] NOT NULL CONSTRAINT [DF_Caja_Activo]  DEFAULT ((1)),
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Caja_UltimaModificacion]  DEFAULT (getdate()),
 CONSTRAINT [PK_Caja] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Caja_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CajaAutorizacion]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CajaAutorizacion](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Caja_Id] [smallint] NOT NULL,
	[Cierre_Id] [int] NOT NULL,
	[Autorizacion_Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario_Id] [varchar](20) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Detalle] [varchar](200) NOT NULL,
 CONSTRAINT [PK_CajaAutorizacion] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Caja_Id] ASC,
	[Cierre_Id] ASC,
	[Autorizacion_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CajaCierreDetalle]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CajaCierreDetalle](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Caja_Id] [smallint] NOT NULL,
	[Cierre_Id] [int] NOT NULL,
	[Detalle_Id] [int] NOT NULL,
	[TipoDoc_Id] [smallint] NOT NULL,
	[Documento_Id] [bigint] NOT NULL,
	[Pago_Id] [smallint] NOT NULL,
	[TipoPago_Id] [smallint] NOT NULL,
	[Monto] [money] NOT NULL,
	[Banco_Id] [smallint] NULL,
	[ChequeNumero] [varchar](20) NOT NULL,
	[Tarjeta_Id] [smallint] NULL,
	[TarjetaNumero] [varchar](16) NOT NULL,
	[TarjetaAutorizacion] [varchar](16) NOT NULL,
	[CxC] [bit] NOT NULL CONSTRAINT [DF_CajaCierreDetalle_CxC]  DEFAULT ((0)),
 CONSTRAINT [PK_CajaCierreDetalle] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Caja_Id] ASC,
	[Cierre_Id] ASC,
	[Detalle_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CajaCierreEncabezado]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CajaCierreEncabezado](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Caja_Id] [smallint] NOT NULL,
	[Cierre_Id] [int] NOT NULL,
	[Usuario_Id] [varchar](20) NOT NULL,
	[Efectivo] [money] NOT NULL,
	[Tarjeta] [money] NOT NULL,
	[Cheque] [money] NOT NULL,
	[Total] [money] NOT NULL,
	[MontoSuma] [money] NOT NULL,
	[MontoResta] [money] NOT NULL,
	[Fondo] [money] NOT NULL,
	[Cerrado] [bit] NOT NULL,
	[FechaApertura] [datetime] NOT NULL CONSTRAINT [DF_CajaCierre_FechaApertura]  DEFAULT ('19000101'),
	[FechaCierre] [datetime] NOT NULL CONSTRAINT [DF_CajaCierre_FechaApertura1]  DEFAULT ('19000101'),
	[CajeroEfectivo] [money] NOT NULL CONSTRAINT [DF_CajaCierreEncabezado_CajeroEfectivo]  DEFAULT ((0)),
	[CajeroTarjeta] [money] NOT NULL CONSTRAINT [DF_CajaCierreEncabezado_CajeroTarjeta]  DEFAULT ((0)),
	[CajeroCheque] [money] NOT NULL CONSTRAINT [DF_CajaCierreEncabezado_CajeroCheque]  DEFAULT ((0)),
	[CajeroDocumentos] [money] NOT NULL CONSTRAINT [DF_CajaCierreEncabezado_CajeroDocumentos]  DEFAULT ((0)),
	[CajeroTotal] [money] NOT NULL CONSTRAINT [DF_CajaCierreEncabezado_CajeroTotal]  DEFAULT ((0)),
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_CajaCierre_UltimaModificacion]  DEFAULT ('19000101'),
	[RecargaTelefonica] [money] NOT NULL CONSTRAINT [DF_CajaCierreEncabezado_RecargaTelefonica]  DEFAULT ((0)),
	[Exento] [money] NOT NULL CONSTRAINT [DF_CajaCierreEncabezado_Exento]  DEFAULT ((0)),
	[Gravado] [money] NOT NULL CONSTRAINT [DF_CajaCierreEncabezado_Gravado]  DEFAULT ((0)),
	[Puntos] [money] NOT NULL,
 CONSTRAINT [PK_CajaCierre] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Caja_Id] ASC,
	[Cierre_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categoria](
	[Emp_Id] [smallint] NOT NULL,
	[Cat_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL CONSTRAINT [DF_Categoria_Activo]  DEFAULT ((1)),
	[BusquedaRapida] [bit] NOT NULL CONSTRAINT [DF_Categoria_BusquedaRapida]  DEFAULT ((0)),
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Categoria_UltimaModificacion]  DEFAULT (getdate()),
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Cat_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[Emp_Id] [smallint] NOT NULL,
	[Cliente_Id] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Telefono1] [varchar](20) NOT NULL,
	[Telefono2] [varchar](20) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Direccion] [varchar](200) NOT NULL,
	[Apartado] [varchar](50) NOT NULL,
	[PorcDescContado] [float] NOT NULL,
	[PorcDescCredito] [float] NOT NULL,
	[LimiteCredito] [money] NOT NULL,
	[Saldo] [money] NOT NULL,
	[FacturaCredito] [bit] NOT NULL,
	[DiasCredito] [smallint] NOT NULL,
	[PorcMora] [float] NOT NULL,
	[DiasGraciaMora] [smallint] NOT NULL,
	[AplicaMora] [bit] NOT NULL,
	[Activo] [bit] NOT NULL CONSTRAINT [DF_Cliente_Activo]  DEFAULT ((1)),
	[Precio_Id] [smallint] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Cliente_UltimaModificacion]  DEFAULT (getdate()),
	[AcumulaPuntos] [bit] NOT NULL CONSTRAINT [DF_Cliente_AcumulaPuntos]  DEFAULT ((1)),
	[PuntosAcumulados] [int] NOT NULL CONSTRAINT [DF_Cliente_PuntosAcumulados]  DEFAULT ((0)),
	[PuntosCanjeados] [int] NOT NULL CONSTRAINT [DF_Cliente_PuntosCanjeados]  DEFAULT ((0)),
	[PuntosVencidos] [int] NOT NULL CONSTRAINT [DF_Cliente_PuntosVencidos]  DEFAULT ((0)),
	[FechaUltimaCompra] [datetime] NOT NULL CONSTRAINT [DF_Cliente_FechaUltimaCompra]  DEFAULT ('19000101'),
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Cliente_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClienteAnotacion]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClienteAnotacion](
	[Emp_Id] [smallint] NOT NULL,
	[Cliente_Id] [int] NOT NULL,
	[Anotacion_Id] [int] NOT NULL,
	[Anotacion] [varchar](1000) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Usuario_Id] [varchar](20) NOT NULL,
 CONSTRAINT [PK_ClienteAnotacion] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Cliente_Id] ASC,
	[Anotacion_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClientePrecio]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClientePrecio](
	[Emp_Id] [smallint] NOT NULL,
	[Precio_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ClientePrecio] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Precio_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ConsecutivoTemporal]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsecutivoTemporal](
	[ConsecutivoArticulo] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CxCMovimiento]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CxCMovimiento](
	[Emp_Id] [smallint] NOT NULL,
	[TipoMov_Id] [smallint] NOT NULL,
	[Mov_Id] [bigint] NOT NULL,
	[Cliente_Id] [int] NOT NULL,
	[Referencia] [varchar](400) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[FechaMovimiento] [datetime] NOT NULL,
	[Vencimiento] [datetime] NOT NULL,
	[Monto] [money] NOT NULL,
	[Saldo] [money] NOT NULL,
	[Activo] [bit] NOT NULL CONSTRAINT [DF_CxCMovimiento_Activo]  DEFAULT ((1)),
	[Usuario_Id] [varchar](20) NOT NULL,
	[AplicaMora] [bit] NOT NULL,
	[FechaCalculoMora] [datetime] NOT NULL,
	[Intereses] [bit] NOT NULL,
	[Dolares] [bit] NOT NULL CONSTRAINT [DF_CxCMovimiento_Dolares]  DEFAULT ((0)),
	[TipoCambio] [money] NOT NULL CONSTRAINT [DF_CxCMovimiento_TipoCambio]  DEFAULT ((1)),
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_CxCMovimiento_UltimaModificacion]  DEFAULT ('19000101'),
 CONSTRAINT [PK_CxCMovimiento] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[TipoMov_Id] ASC,
	[Mov_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CxCMovimientoAplica]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CxCMovimientoAplica](
	[Emp_Id] [smallint] NOT NULL,
	[TipoMov_Id] [smallint] NOT NULL,
	[Mov_Id] [bigint] NOT NULL,
	[Aplica_Id] [smallint] NOT NULL,
	[AplicaTipoMov_Id] [smallint] NOT NULL,
	[AplicaMov_Id] [bigint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Monto] [money] NOT NULL,
 CONSTRAINT [PK_CxCMovimientoAplica] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[TipoMov_Id] ASC,
	[Mov_Id] ASC,
	[Aplica_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CxCMovimientoFactura]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CxCMovimientoFactura](
	[Emp_Id] [smallint] NOT NULL,
	[TipoMov_Id] [smallint] NOT NULL,
	[Mov_Id] [bigint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Caja_Id] [smallint] NOT NULL,
	[TipoDoc_Id] [smallint] NOT NULL,
	[Documento_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_CxCMovimientoFactura] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[TipoMov_Id] ASC,
	[Mov_Id] ASC,
	[Suc_Id] ASC,
	[Caja_Id] ASC,
	[TipoDoc_Id] ASC,
	[Documento_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CxCMovimientoMora]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CxCMovimientoMora](
	[Emp_Id] [smallint] NOT NULL,
	[TipoMov_Id] [smallint] NOT NULL,
	[Mov_Id] [bigint] NOT NULL,
	[Aplica_Id] [smallint] NOT NULL,
	[AplicaTipoMov_Id] [smallint] NOT NULL,
	[AplicaMov_Id] [bigint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Monto] [money] NOT NULL,
	[Dias] [smallint] NOT NULL,
 CONSTRAINT [PK_CxCMovimientoMora] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[TipoMov_Id] ASC,
	[Mov_Id] ASC,
	[Aplica_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CxCMovimientoPago]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CxCMovimientoPago](
	[Emp_Id] [smallint] NOT NULL,
	[TipoMov_Id] [smallint] NOT NULL,
	[Mov_Id] [bigint] NOT NULL,
	[Pago_Id] [smallint] NOT NULL,
	[TipoPago_Id] [smallint] NOT NULL,
	[Monto] [money] NOT NULL,
	[Banco_Id] [smallint] NULL,
	[ChequeNumero] [varchar](20) NOT NULL,
	[Tarjeta_Id] [smallint] NULL,
	[TarjetaNumero] [varchar](16) NOT NULL,
	[TarjetaAutorizacion] [varchar](16) NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_CxCMovimientoPago] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[TipoMov_Id] ASC,
	[Mov_Id] ASC,
	[Pago_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CxCMovimientoTipo]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CxCMovimientoTipo](
	[Emp_Id] [smallint] NOT NULL,
	[TipoMov_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[IncrementaSaldo] [bit] NOT NULL,
	[Activo] [bit] NOT NULL CONSTRAINT [DF_CxCMovimientoTipo_Activo]  DEFAULT ((1)),
	[Orden] [smallint] NOT NULL CONSTRAINT [DF_CxCMovimientoTipo_Orden]  DEFAULT ((0)),
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_CxCMovimientoTipo_UltimaModificacion]  DEFAULT (getdate()),
 CONSTRAINT [PK_CxCMovimientoTipo] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[TipoMov_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Departamento](
	[Emp_Id] [smallint] NOT NULL,
	[Departamento_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL CONSTRAINT [DF_Departamento_Activo]  DEFAULT ((1)),
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Departamento_UltimaModificacion]  DEFAULT (getdate()),
 CONSTRAINT [PK_Departamento] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Departamento_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empresa](
	[Emp_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Cedula] [varchar](30) NOT NULL,
	[Telefono] [varchar](20) NOT NULL,
	[Fax] [varchar](20) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Direccion] [varchar](200) NOT NULL,
	[DireccionWeb] [varchar](200) NOT NULL,
	[Activo] [bit] NOT NULL CONSTRAINT [DF_Empresa_Activo]  DEFAULT ((1)),
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Empresa_UltimaModificacion]  DEFAULT (getdate()),
	[Logo] [image] NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmpresaConsecutivo]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpresaConsecutivo](
	[Emp_Id] [smallint] NOT NULL,
	[RecargaTelefonica] [bigint] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_EmpresaConsecutivo_UltimaModificacion]  DEFAULT (getdate()),
 CONSTRAINT [PK_EmpresaConsecutivo] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmpresaParametro]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmpresaParametro](
	[Emp_Id] [smallint] NOT NULL,
	[PorcIV] [float] NOT NULL,
	[FactorRedondeo] [smallint] NOT NULL,
	[TopeRedondeo] [float] NOT NULL,
	[LeyendaFactura1] [varchar](200) NOT NULL,
	[LeyendaFactura2] [varchar](200) NOT NULL,
	[SaldoMinimoRecarga] [money] NOT NULL CONSTRAINT [DF_EmpresaParametro_SaldoMinimoRecarga]  DEFAULT ((0)),
	[ImprimeRecarga] [bit] NOT NULL CONSTRAINT [DF_EmpresaParametro_ImprimeRecarga]  DEFAULT ((0)),
	[DiasCredito] [smallint] NOT NULL,
	[PorcMora] [float] NOT NULL,
	[DiasGraciaMora] [smallint] NOT NULL,
	[MinutosPrefactura] [smallint] NOT NULL,
	[ProformaDiasVencimiento] [smallint] NOT NULL,
	[ProformaGeneraArchivo] [bit] NOT NULL,
	[ProformaCarpeta] [varchar](200) NOT NULL,
	[ProformaTipoImpresion] [smallint] NOT NULL,
	[ProformaElimina] [bit] NOT NULL,
	[PrefacturaCompromete] [bit] NOT NULL CONSTRAINT [DF_EmpresaParametro_PrefacturaCompromete]  DEFAULT ((1)),
	[PuntosActivo] [bit] NOT NULL CONSTRAINT [DF_EmpresaParametro_PuntosActivo]  DEFAULT ((1)),
	[PuntosPorCada] [money] NOT NULL,
	[PuntosAcumula] [smallint] NOT NULL,
	[PorcInteresCredito] [float] NOT NULL CONSTRAINT [DF_EmpresaParametro_PorcInteresCredito]  DEFAULT ((0)),
	[GeneraCuotasCredito] [bit] NOT NULL,
	[DiasMayoreo] [smallint] NOT NULL CONSTRAINT [DF_EmpresaParametro_DiasMayoreo]  DEFAULT ((0)),
 CONSTRAINT [PK_EmpresaParametro] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EntradaDetalle]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EntradaDetalle](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Entrada_Id] [int] NOT NULL,
	[Detalle_Id] [smallint] NOT NULL,
	[Bod_Id] [smallint] NOT NULL,
	[Art_Id] [varchar](13) NOT NULL,
	[Cantidad] [float] NOT NULL,
	[CantidadBonificada] [float] NOT NULL,
	[Costo] [money] NOT NULL,
	[PorcDescuento] [money] NOT NULL,
	[MontoDescuento] [money] NOT NULL,
	[MontoIV] [money] NOT NULL,
	[TotalLinea] [money] NOT NULL,
	[TotalLineaBonificada] [money] NOT NULL,
	[ExentoIV] [bit] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
	[Margen] [float] NOT NULL CONSTRAINT [DF_EntradaDetalle_Margen]  DEFAULT ((0)),
	[Precio] [money] NOT NULL CONSTRAINT [DF_EntradaDetalle_Precio]  DEFAULT ((0)),
 CONSTRAINT [PK_EntradaDetalle] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Entrada_Id] ASC,
	[Detalle_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EntradaEncabezado]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EntradaEncabezado](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Entrada_Id] [int] NOT NULL,
	[Prov_Id] [int] NOT NULL,
	[Bod_Id] [smallint] NOT NULL,
	[EntradaEstado_Id] [smallint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Comentario] [varchar](200) NOT NULL,
	[SubTotal] [money] NOT NULL,
	[Descuento] [money] NOT NULL,
	[IV] [money] NOT NULL,
	[Total] [money] NOT NULL,
	[TotalBonificacion] [money] NOT NULL,
	[Usuario_Id] [varchar](20) NOT NULL,
	[AplicaUsuario_Id] [varchar](20) NULL,
	[AplicaFecha] [datetime] NOT NULL,
	[Orden_Id] [int] NULL,
	[UltimaModificacion] [datetime] NOT NULL,
	[Exento] [money] NOT NULL,
	[Gravado] [money] NOT NULL,
 CONSTRAINT [PK_EntradaEncabezado] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Entrada_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EntradaEstado]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EntradaEstado](
	[Emp_Id] [smallint] NOT NULL,
	[EntradaEstado_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EntradaEstado] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[EntradaEstado_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EntradaFactura]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EntradaFactura](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Entrada_Id] [int] NOT NULL,
	[Factura_Id] [smallint] NOT NULL,
	[Prov_Id] [int] NOT NULL,
	[Factura] [varchar](20) NOT NULL,
	[Monto] [money] NOT NULL,
	[FechaVencimiento] [datetime] NOT NULL,
	[Comentario] [varchar](100) NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_EntradaFactura] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Entrada_Id] ASC,
	[Factura_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EtiquetaTipo]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EtiquetaTipo](
	[EtiquetaTipo_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_EtiquetaTipo] PRIMARY KEY CLUSTERED 
(
	[EtiquetaTipo_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FacturaBitacora]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FacturaBitacora](
	[Bitacora_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Cliente_Id] [int] NOT NULL,
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Caja_Id] [smallint] NOT NULL,
	[TipoDoc_Id] [smallint] NOT NULL,
	[Documento_Id] [bigint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Usuario_Id] [varchar](20) NOT NULL,
	[Ip] [varchar](50) NOT NULL,
	[Tipo] [smallint] NOT NULL,
 CONSTRAINT [PK_FacturaBitacora] PRIMARY KEY CLUSTERED 
(
	[Bitacora_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FacturaDetalle]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FacturaDetalle](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Caja_Id] [smallint] NOT NULL,
	[TipoDoc_Id] [smallint] NOT NULL,
	[Documento_Id] [bigint] NOT NULL,
	[Detalle_Id] [smallint] NOT NULL,
	[Art_Id] [varchar](13) NOT NULL,
	[Cantidad] [float] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Costo] [money] NOT NULL,
	[Precio] [money] NOT NULL,
	[PorcDescuento] [money] NOT NULL,
	[MontoDescuento] [money] NOT NULL,
	[MontoIV] [money] NOT NULL,
	[TotalLinea] [money] NOT NULL,
	[ExentoIV] [bit] NOT NULL,
	[Suelto] [bit] NOT NULL,
	[Observacion] [varchar](500) NOT NULL,
 CONSTRAINT [PK_FacturaDetalle] PRIMARY KEY CLUSTERED 
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FacturaDevolucion]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacturaDevolucion](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Caja_Id] [smallint] NOT NULL,
	[TipoDoc_Id] [smallint] NOT NULL,
	[Documento_Id] [bigint] NOT NULL,
	[Dev_Suc_Id] [smallint] NOT NULL,
	[Dev_Caja_Id] [smallint] NOT NULL,
	[Dev_TipoDoc_Id] [smallint] NOT NULL,
	[Dev_Documento_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_FacturaDevolucion] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Caja_Id] ASC,
	[TipoDoc_Id] ASC,
	[Documento_Id] ASC,
	[Dev_Suc_Id] ASC,
	[Dev_Caja_Id] ASC,
	[Dev_TipoDoc_Id] ASC,
	[Dev_Documento_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FacturaEncabezado]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FacturaEncabezado](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Caja_Id] [smallint] NOT NULL,
	[TipoDoc_Id] [smallint] NOT NULL,
	[Documento_Id] [bigint] NOT NULL,
	[Bod_Id] [smallint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Cliente_Id] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Vendedor_Id] [smallint] NOT NULL,
	[Usuario_Id] [varchar](20) NOT NULL,
	[Comentario] [varchar](500) NOT NULL CONSTRAINT [DF_FacturaEncabezado_Comentario]  DEFAULT (''),
	[Costo] [money] NOT NULL,
	[Subtotal] [money] NOT NULL,
	[Descuento] [money] NOT NULL,
	[IV] [money] NOT NULL,
	[Total] [money] NOT NULL,
	[Redondeo] [money] NOT NULL,
	[TotalCobrado] [money] NOT NULL,
	[Cierre_Id] [int] NOT NULL,
	[CPU] [varchar](50) NOT NULL,
	[HostName] [varchar](50) NOT NULL,
	[IPAddress] [varchar](50) NOT NULL,
	[Exento] [money] NOT NULL CONSTRAINT [DF_FacturaEncabezado_Exento]  DEFAULT ((0)),
	[Gravado] [money] NOT NULL CONSTRAINT [DF_FacturaEncabezado_Gravado]  DEFAULT ((0)),
	[Dolares] [bit] NOT NULL,
	[TipoCambio] [money] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_FacturaEncabezado_UltimaModificacion]  DEFAULT (getdate()),
	[Puntos] [int] NOT NULL,
	[RecargoCredito] [money] NOT NULL CONSTRAINT [DF_FacturaEncabezado_RecargoCredito]  DEFAULT ((0)),
 CONSTRAINT [PK_FacturaEncabezado_1] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Caja_Id] ASC,
	[TipoDoc_Id] ASC,
	[Documento_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FacturaPago]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FacturaPago](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Caja_Id] [smallint] NOT NULL,
	[TipoDoc_Id] [smallint] NOT NULL,
	[Documento_Id] [bigint] NOT NULL,
	[Pago_Id] [smallint] NOT NULL,
	[TipoPago_Id] [smallint] NOT NULL,
	[Monto] [money] NOT NULL,
	[Banco_Id] [smallint] NULL,
	[ChequeNumero] [varchar](20) NOT NULL,
	[ChequeFecha] [datetime] NOT NULL,
	[Tarjeta_Id] [smallint] NULL,
	[TarjetaNumero] [varchar](16) NOT NULL,
	[TarjetaAutorizacion] [varchar](16) NOT NULL,
	[Fecha] [datetime] NOT NULL CONSTRAINT [DF_FacturaPago_Fecha]  DEFAULT (getdate()),
 CONSTRAINT [PK_FacturaPago] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Caja_Id] ASC,
	[TipoDoc_Id] ASC,
	[Documento_Id] ASC,
	[Pago_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Grupo]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grupo](
	[Emp_Id] [smallint] NOT NULL,
	[Grupo_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL CONSTRAINT [DF_Grupo_Activo]  DEFAULT ((1)),
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Grupo_UltimaModificacion]  DEFAULT (getdate()),
 CONSTRAINT [PK_Grupo] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Grupo_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GrupoMenu]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GrupoMenu](
	[Emp_Id] [smallint] NOT NULL,
	[Grupo_Id] [smallint] NOT NULL,
	[Modulo_Id] [smallint] NOT NULL,
	[Menu_Id] [varchar](50) NOT NULL,
 CONSTRAINT [PK_GrupoMenu] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Grupo_Id] ASC,
	[Modulo_Id] ASC,
	[Menu_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Menu](
	[Modulo_Id] [smallint] NOT NULL,
	[Menu_Id] [varchar](50) NOT NULL,
	[MenuPadre_Id] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Orden] [smallint] NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[Modulo_Id] ASC,
	[Menu_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Modulo]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Modulo](
	[Modulo_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Modulo] PRIMARY KEY CLUSTERED 
(
	[Modulo_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Moneda]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Moneda](
	[Emp_Id] [smallint] NOT NULL,
	[Moneda_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Moneda] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Moneda_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MovimientoDetalle]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MovimientoEncabezado]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MovimientoEncabezado](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[TipoMov_Id] [smallint] NOT NULL,
	[Mov_Id] [int] NOT NULL,
	[Bod_Id] [smallint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Comentario] [varchar](200) NOT NULL,
	[Costo] [money] NOT NULL,
	[Aplicado] [bit] NOT NULL CONSTRAINT [DF_MovimientoEncabezado_Aplicado]  DEFAULT ((0)),
	[Usuario_Id] [varchar](20) NOT NULL,
	[Suc_Id_Destino] [smallint] NULL,
	[Bod_Id_Destino] [smallint] NULL,
	[AplicaUsuario_Id] [varchar](20) NULL,
	[AplicaFecha] [datetime] NOT NULL CONSTRAINT [DF_MovimientoEncabezado_AplicaFecha]  DEFAULT ('19000101'),
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_MovimientoEncabezado_UltimaModificacion]  DEFAULT ('19000101'),
 CONSTRAINT [PK_MovimientoEncabezado] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[TipoMov_Id] ASC,
	[Mov_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrdenCompraDetalle]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrdenCompraDetalle](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Orden_Id] [int] NOT NULL,
	[Detalle_Id] [smallint] NOT NULL,
	[Bod_Id] [smallint] NOT NULL,
	[Art_Id] [varchar](13) NOT NULL,
	[Cantidad] [float] NOT NULL,
	[CantidadBonificada] [float] NOT NULL,
	[Costo] [money] NOT NULL,
	[PorcDescuento] [money] NOT NULL,
	[MontoDescuento] [money] NOT NULL,
	[MontoIV] [money] NOT NULL,
	[TotalLinea] [money] NOT NULL,
	[TotalLineaBonificada] [money] NOT NULL,
	[ExentoIV] [bit] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_OrdenCompraDetalle] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Orden_Id] ASC,
	[Detalle_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrdenCompraEncabezado]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrdenCompraEncabezado](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Orden_Id] [int] NOT NULL,
	[Prov_Id] [int] NOT NULL,
	[Bod_Id] [smallint] NOT NULL,
	[OrdenEstado_Id] [smallint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Comentario] [varchar](200) NOT NULL,
	[SubTotal] [money] NOT NULL,
	[Descuento] [money] NOT NULL,
	[IV] [money] NOT NULL,
	[Total] [money] NOT NULL,
	[TotalBonificacion] [money] NOT NULL,
	[Usuario_Id] [varchar](20) NOT NULL,
	[AplicaUsuario_Id] [varchar](20) NULL,
	[AplicaFecha] [datetime] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_OrdenCompraEncabezado] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Orden_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrdenCompraEstado]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrdenCompraEstado](
	[Emp_Id] [smallint] NOT NULL,
	[OrdenEstado_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_OrdenCompraEstado] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[OrdenEstado_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Permiso](
	[Permiso_Id] [smallint] NOT NULL,
	[Modulo_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Permiso] PRIMARY KEY CLUSTERED 
(
	[Permiso_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PermisoBitacora]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PermisoBitacora](
	[Bitacora_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Permiso_Id] [smallint] NOT NULL,
	[Usuario_Id] [varchar](20) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Observacion] [varchar](200) NOT NULL,
 CONSTRAINT [PK_PermisoBitacora] PRIMARY KEY CLUSTERED 
(
	[Bitacora_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProformaDetalle]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProformaDetalle](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Documento_Id] [bigint] NOT NULL,
	[Detalle_Id] [smallint] NOT NULL,
	[Art_Id] [varchar](13) NOT NULL,
	[Cantidad] [float] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Costo] [money] NOT NULL,
	[Precio] [money] NOT NULL,
	[PorcDescuento] [money] NOT NULL,
	[MontoDescuento] [money] NOT NULL,
	[MontoIV] [money] NOT NULL,
	[TotalLinea] [money] NOT NULL,
	[ExentoIV] [bit] NOT NULL,
	[Suelto] [bit] NOT NULL,
	[Observacion] [varchar](500) NOT NULL,
 CONSTRAINT [PK_ProformaDetalle_1] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Documento_Id] ASC,
	[Detalle_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProformaEncabezado]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProformaEncabezado](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Documento_Id] [bigint] NOT NULL,
	[TipoDoc_Id] [smallint] NOT NULL,
	[Bod_Id] [smallint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Vencimiento] [datetime] NOT NULL,
	[Cliente_Id] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Vendedor_Id] [smallint] NOT NULL,
	[Usuario_Id] [varchar](20) NOT NULL,
	[Comentario] [varchar](500) NOT NULL CONSTRAINT [DF_ProformaEncabezado_Comentario]  DEFAULT (''),
	[Costo] [money] NOT NULL,
	[Subtotal] [money] NOT NULL,
	[Descuento] [money] NOT NULL,
	[IV] [money] NOT NULL,
	[Total] [money] NOT NULL,
	[Redondeo] [money] NOT NULL,
	[TotalCobrado] [money] NOT NULL,
	[Cierre_Id] [int] NOT NULL,
	[CPU] [varchar](50) NOT NULL,
	[HostName] [varchar](50) NOT NULL,
	[IPAddress] [varchar](50) NOT NULL,
	[Exento] [money] NOT NULL CONSTRAINT [DF_ProformaEncabezado_Exento]  DEFAULT ((0)),
	[Gravado] [money] NOT NULL CONSTRAINT [DF_ProformaEncabezado_Gravado]  DEFAULT ((0)),
	[Dolares] [bit] NOT NULL,
	[TipoCambio] [money] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_ProformaEncabezado_UltimaModificacion]  DEFAULT (getdate()),
	[Tipo] [smallint] NOT NULL,
	[TipoEntrega_Id] [smallint] NOT NULL CONSTRAINT [DF_ProformaEncabezado_TipoEntrega_Id]  DEFAULT ((1)),
	[FechaEntrega] [datetime] NOT NULL CONSTRAINT [DF_ProformaEncabezado_FechaEntrega]  DEFAULT (getdate()),
 CONSTRAINT [PK_ProformaEncabezado] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Documento_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProformaTipo]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProformaTipo](
	[Emp_Id] [smallint] NOT NULL,
	[Tipo] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ProformaTipo] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProformaTipoEntrega]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProformaTipoEntrega](
	[Emp_Id] [smallint] NOT NULL,
	[TipoEntrega_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ProformaTipoEntrega] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[TipoEntrega_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proveedor](
	[Emp_Id] [smallint] NOT NULL,
	[Prov_Id] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[CedulaJuridica] [varchar](30) NOT NULL CONSTRAINT [DF_Proveedor_CedulaJuridica]  DEFAULT (''),
	[Direccion] [varchar](200) NOT NULL,
	[Telefono1] [varchar](20) NOT NULL,
	[Telefono2] [varchar](20) NOT NULL,
	[Fax] [varchar](20) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Apartado] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL CONSTRAINT [DF_Proveedor_Activo]  DEFAULT ((1)),
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Proveedor_UltimaModificacion]  DEFAULT (getdate()),
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Prov_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RecargaOperacion]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RecargaOperacion](
	[Operacion] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RecargaOperacion] PRIMARY KEY CLUSTERED 
(
	[Operacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RecargaTelefonica]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RecargaTelefonica](
	[Emp_Id] [smallint] NOT NULL,
	[Recarga_Id] [bigint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Caja_Id] [smallint] NOT NULL,
	[Cierre_Id] [int] NOT NULL,
	[Operacion] [varchar](50) NOT NULL,
	[Cia] [varchar](20) NOT NULL,
	[Telefono] [varchar](20) NOT NULL,
	[Monto] [money] NOT NULL,
	[Detallista] [varchar](20) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Usuario_Id] [varchar](20) NOT NULL,
	[Documento] [bigint] NOT NULL,
	[IdTrans] [bigint] NOT NULL,
	[Comision] [money] NOT NULL,
	[Correlativo] [varchar](20) NULL,
	[FechaRespuesta] [datetime] NULL,
	[NumSerie] [varchar](50) NULL,
	[DiasExp] [smallint] NULL,
	[EstadoRecarga] [varchar](5) NULL,
	[DetalleRecarga] [varchar](200) NULL,
	[ErrorCode] [varchar](5) NULL,
	[ErrorDes] [varchar](200) NULL,
	[IceTransId] [varchar](50) NULL,
	[DistComision] [money] NULL,
	[Saldo] [money] NULL,
 CONSTRAINT [PK_RecargaTelefonica] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Recarga_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ResultadoTomaFisica]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ResultadoTomaFisica](
	[Art_Id] [varchar](13) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Cantidad] [float] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SubCategoria]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SubCategoria](
	[Emp_Id] [smallint] NOT NULL,
	[Cat_Id] [smallint] NOT NULL,
	[SubCat_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL CONSTRAINT [DF_SubCategoria_Activo]  DEFAULT ((1)),
	[BusquedaRapida] [bit] NOT NULL CONSTRAINT [DF_SubCategoria_BusquedaRapida]  DEFAULT ((0)),
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_SubCategoria_UltimaModificacion]  DEFAULT (getdate()),
 CONSTRAINT [PK_SubCategoria] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Cat_Id] ASC,
	[SubCat_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sucursal](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Telefono] [varchar](20) NOT NULL,
	[Fax] [varchar](20) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Direccion] [varchar](200) NOT NULL,
	[Activo] [bit] NOT NULL CONSTRAINT [DF_Sucursal_Activo]  DEFAULT ((1)),
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Sucursal_UltimaModificacion]  DEFAULT (getdate()),
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SucursalParametro]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SucursalParametro](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[BodCompra_Id] [smallint] NOT NULL,
 CONSTRAINT [PK_SucursalParametro] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tarjeta]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tarjeta](
	[Emp_Id] [smallint] NOT NULL,
	[Tarjeta_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL CONSTRAINT [DF_Tarjeta_Activo]  DEFAULT ((1)),
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Tarjeta_UltimaModificacion]  DEFAULT (getdate()),
 CONSTRAINT [PK_Tarjeta] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Tarjeta_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoAcumulacion]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoAcumulacion](
	[Emp_Id] [smallint] NOT NULL,
	[TipoAcumulacion_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Factor] [smallint] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_TipoAcumulacion] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[TipoAcumulacion_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoCambio]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCambio](
	[TipoCambio_Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL CONSTRAINT [DF_TipoCambio_Fecha]  DEFAULT (getdate()),
	[Compra] [float] NOT NULL,
	[Venta] [float] NOT NULL,
 CONSTRAINT [PK_TipoCambio_1] PRIMARY KEY CLUSTERED 
(
	[TipoCambio_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoDocumento]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoDocumento](
	[Emp_Id] [smallint] NOT NULL,
	[TipoDoc_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL CONSTRAINT [DF_TipoDocumento_Activo]  DEFAULT ((1)),
	[Cliente_Id] [int] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_TipoDocumento_UltimaModificacion]  DEFAULT (getdate()),
 CONSTRAINT [PK_TipoDocumento] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[TipoDoc_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoMovimiento]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoMovimiento](
	[Emp_Id] [smallint] NOT NULL,
	[TipoMov_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Suma] [bit] NOT NULL,
	[EntradaMercaderia] [bit] NOT NULL,
	[Activo] [bit] NOT NULL CONSTRAINT [DF_TipoMovimiento_Activo]  DEFAULT ((1)),
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_TipoMovimiento_UltimaModificacion]  DEFAULT (getdate()),
 CONSTRAINT [PK_TipoMovimiento] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[TipoMov_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoPago]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoPago](
	[Emp_Id] [smallint] NOT NULL,
	[TipoPago_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoPago] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[TipoPago_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoVenta]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoVenta](
	[Emp_Id] [smallint] NOT NULL,
	[TipoVenta_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_TipoVenta] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[TipoVenta_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TrasladoDetalle]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TrasladoDetalle](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Traslado_Id] [int] NOT NULL,
	[Detalle_Id] [smallint] NOT NULL,
	[Art_Id] [varchar](13) NOT NULL,
	[Cantidad] [float] NOT NULL,
	[Costo] [money] NOT NULL,
	[TotalLinea] [money] NOT NULL,
	[Suelto] [bit] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_TrasladoDetalle] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Traslado_Id] ASC,
	[Detalle_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TrasladoEncabezado]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TrasladoEncabezado](
	[Emp_Id] [smallint] NOT NULL,
	[Suc_Id] [smallint] NOT NULL,
	[Traslado_Id] [int] NOT NULL,
	[Bod_Id] [smallint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Comentario] [varchar](200) NOT NULL,
	[Costo] [money] NOT NULL,
	[Aplicado] [bit] NOT NULL,
	[Usuario_Id] [varchar](20) NOT NULL,
	[Suc_Id_Destino] [smallint] NOT NULL,
	[Bod_Id_Destino] [smallint] NOT NULL,
	[AplicaUsuario_Id] [varchar](20) NULL,
	[AplicaFecha] [datetime] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_TrasladoEncabezado] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Traslado_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UnidadMedida]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UnidadMedida](
	[Emp_Id] [smallint] NOT NULL,
	[UnidadMedida_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL CONSTRAINT [DF_UnidadMedida_Activo]  DEFAULT ((1)),
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_UnidadMedida_UltimaModificacion]  DEFAULT (getdate()),
 CONSTRAINT [PK_UnidadMedida] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[UnidadMedida_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[Emp_Id] [smallint] NOT NULL,
	[Usuario_Id] [varchar](20) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Vendedor_Id] [smallint] NOT NULL,
	[Grupo_Id] [smallint] NOT NULL,
	[Activo] [bit] NOT NULL CONSTRAINT [DF_Usuario_Activo]  DEFAULT ((1)),
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Usuario_UltimaModificacion]  DEFAULT (getdate()),
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Usuario_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioPermiso]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UsuarioPermiso](
	[Emp_Id] [smallint] NOT NULL,
	[Usuario_Id] [varchar](20) NOT NULL,
	[Permiso_Id] [smallint] NOT NULL,
	[Modulo_Id] [smallint] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_UsuarioPermiso] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Usuario_Id] ASC,
	[Permiso_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vendedor]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vendedor](
	[Emp_Id] [smallint] NOT NULL,
	[Vendedor_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL CONSTRAINT [DF_Vendedor_Activo]  DEFAULT ((1)),
	[UltimaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Vendedor_UltimaModificacion]  DEFAULT (getdate()),
 CONSTRAINT [PK_Vendedor] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Vendedor_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ArticuloEquivalente]    Script Date: 4/8/2016 3:47:22 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ArticuloEquivalente] ON [dbo].[ArticuloEquivalente]
(
	[Emp_Id] ASC,
	[ArtEquivalente_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CxCMovimientoCliente]    Script Date: 4/8/2016 3:47:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_CxCMovimientoCliente] ON [dbo].[CxCMovimiento]
(
	[Emp_Id] ASC,
	[Cliente_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ArticuloConteo] ADD  CONSTRAINT [DF_ArticuloConteo_Procesado]  DEFAULT ((0)) FOR [Procesado]
GO
ALTER TABLE [dbo].[CajaAutorizacion] ADD  CONSTRAINT [DF_CajaAutorizacion_Fecha]  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[CxCMovimientoMora] ADD  CONSTRAINT [DF_CxCMovimientoMora_DiasMora]  DEFAULT ((0)) FOR [Dias]
GO
ALTER TABLE [dbo].[EntradaFactura] ADD  CONSTRAINT [DF_EntradaFactura_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO
ALTER TABLE [dbo].[Moneda] ADD  CONSTRAINT [DF_Moneda_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Moneda] ADD  CONSTRAINT [DF_Moneda_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO
ALTER TABLE [dbo].[Articulo]  WITH CHECK ADD  CONSTRAINT [FK_Articulo_Articulo] FOREIGN KEY([Emp_Id], [ArtPadre])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO
ALTER TABLE [dbo].[Articulo] CHECK CONSTRAINT [FK_Articulo_Articulo]
GO
ALTER TABLE [dbo].[Articulo]  WITH CHECK ADD  CONSTRAINT [FK_Articulo_Categoria] FOREIGN KEY([Emp_Id], [Cat_Id])
REFERENCES [dbo].[Categoria] ([Emp_Id], [Cat_Id])
GO
ALTER TABLE [dbo].[Articulo] CHECK CONSTRAINT [FK_Articulo_Categoria]
GO
ALTER TABLE [dbo].[Articulo]  WITH CHECK ADD  CONSTRAINT [FK_Articulo_Departamento] FOREIGN KEY([Emp_Id], [Departamento_Id])
REFERENCES [dbo].[Departamento] ([Emp_Id], [Departamento_Id])
GO
ALTER TABLE [dbo].[Articulo] CHECK CONSTRAINT [FK_Articulo_Departamento]
GO
ALTER TABLE [dbo].[Articulo]  WITH CHECK ADD  CONSTRAINT [FK_Articulo_SubCategoria] FOREIGN KEY([Emp_Id], [Cat_Id], [SubCat_Id])
REFERENCES [dbo].[SubCategoria] ([Emp_Id], [Cat_Id], [SubCat_Id])
GO
ALTER TABLE [dbo].[Articulo] CHECK CONSTRAINT [FK_Articulo_SubCategoria]
GO
ALTER TABLE [dbo].[Articulo]  WITH CHECK ADD  CONSTRAINT [FK_Articulo_TipoAcumulacion] FOREIGN KEY([Emp_Id], [TipoAcumulacion_Id])
REFERENCES [dbo].[TipoAcumulacion] ([Emp_Id], [TipoAcumulacion_Id])
GO
ALTER TABLE [dbo].[Articulo] CHECK CONSTRAINT [FK_Articulo_TipoAcumulacion]
GO
ALTER TABLE [dbo].[Articulo]  WITH CHECK ADD  CONSTRAINT [FK_Articulo_UnidadMedida] FOREIGN KEY([Emp_Id], [UnidadMedida_Id])
REFERENCES [dbo].[UnidadMedida] ([Emp_Id], [UnidadMedida_Id])
GO
ALTER TABLE [dbo].[Articulo] CHECK CONSTRAINT [FK_Articulo_UnidadMedida]
GO
ALTER TABLE [dbo].[ArticuloAnotacion]  WITH CHECK ADD  CONSTRAINT [FK_ArticuloAnotacion_Articulo] FOREIGN KEY([Emp_Id], [Art_Id])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO
ALTER TABLE [dbo].[ArticuloAnotacion] CHECK CONSTRAINT [FK_ArticuloAnotacion_Articulo]
GO
ALTER TABLE [dbo].[ArticuloBodega]  WITH NOCHECK ADD  CONSTRAINT [FK_ArticuloBodega_Articulo] FOREIGN KEY([Emp_Id], [Art_Id])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO
ALTER TABLE [dbo].[ArticuloBodega] CHECK CONSTRAINT [FK_ArticuloBodega_Articulo]
GO
ALTER TABLE [dbo].[ArticuloBodega]  WITH NOCHECK ADD  CONSTRAINT [FK_ArticuloBodega_Bodega] FOREIGN KEY([Emp_Id], [Suc_Id], [Bod_Id])
REFERENCES [dbo].[Bodega] ([Emp_Id], [Suc_Id], [Bod_Id])
GO
ALTER TABLE [dbo].[ArticuloBodega] CHECK CONSTRAINT [FK_ArticuloBodega_Bodega]
GO
ALTER TABLE [dbo].[ArticuloConjunto]  WITH CHECK ADD  CONSTRAINT [FK_ArticuloConjunto_Articulo] FOREIGN KEY([Emp_Id], [Art_Id])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO
ALTER TABLE [dbo].[ArticuloConjunto] CHECK CONSTRAINT [FK_ArticuloConjunto_Articulo]
GO
ALTER TABLE [dbo].[ArticuloConjunto]  WITH CHECK ADD  CONSTRAINT [FK_ArticuloConjunto_Articulo1] FOREIGN KEY([Emp_Id], [ArtConjunto_Id])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO
ALTER TABLE [dbo].[ArticuloConjunto] CHECK CONSTRAINT [FK_ArticuloConjunto_Articulo1]
GO
ALTER TABLE [dbo].[ArticuloEquivalente]  WITH CHECK ADD  CONSTRAINT [FK_ArticuloEquivalente_Articulo] FOREIGN KEY([Emp_Id], [Art_Id])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO
ALTER TABLE [dbo].[ArticuloEquivalente] CHECK CONSTRAINT [FK_ArticuloEquivalente_Articulo]
GO
ALTER TABLE [dbo].[ArticuloKardex]  WITH NOCHECK ADD  CONSTRAINT [FK_ArticuloKardex_ArticuloBodega] FOREIGN KEY([Emp_Id], [Suc_Id], [Bod_Id], [Art_Id])
REFERENCES [dbo].[ArticuloBodega] ([Emp_Id], [Suc_Id], [Bod_Id], [Art_Id])
GO
ALTER TABLE [dbo].[ArticuloKardex] CHECK CONSTRAINT [FK_ArticuloKardex_ArticuloBodega]
GO
ALTER TABLE [dbo].[ArticuloProveedor]  WITH CHECK ADD  CONSTRAINT [FK_ArticuloProveedor_Articulo] FOREIGN KEY([Emp_Id], [Art_Id])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO
ALTER TABLE [dbo].[ArticuloProveedor] CHECK CONSTRAINT [FK_ArticuloProveedor_Articulo]
GO
ALTER TABLE [dbo].[ArticuloProveedor]  WITH CHECK ADD  CONSTRAINT [FK_ArticuloProveedor_Proveedor] FOREIGN KEY([Emp_Id], [Prov_Id])
REFERENCES [dbo].[Proveedor] ([Emp_Id], [Prov_Id])
GO
ALTER TABLE [dbo].[ArticuloProveedor] CHECK CONSTRAINT [FK_ArticuloProveedor_Proveedor]
GO
ALTER TABLE [dbo].[BitacoraUsuario]  WITH NOCHECK ADD  CONSTRAINT [FK_BitacoraUsuario_Modulo] FOREIGN KEY([Modulo_Id])
REFERENCES [dbo].[Modulo] ([Modulo_Id])
GO
ALTER TABLE [dbo].[BitacoraUsuario] CHECK CONSTRAINT [FK_BitacoraUsuario_Modulo]
GO
ALTER TABLE [dbo].[BitacoraUsuario]  WITH NOCHECK ADD  CONSTRAINT [FK_BitacoraUsuario_Usuario] FOREIGN KEY([Emp_Id], [Usuario_Id])
REFERENCES [dbo].[Usuario] ([Emp_Id], [Usuario_Id])
GO
ALTER TABLE [dbo].[BitacoraUsuario] CHECK CONSTRAINT [FK_BitacoraUsuario_Usuario]
GO
ALTER TABLE [dbo].[Bodega]  WITH CHECK ADD  CONSTRAINT [FK_Bodega_Sucursal] FOREIGN KEY([Emp_Id], [Suc_Id])
REFERENCES [dbo].[Sucursal] ([Emp_Id], [Suc_Id])
GO
ALTER TABLE [dbo].[Bodega] CHECK CONSTRAINT [FK_Bodega_Sucursal]
GO
ALTER TABLE [dbo].[Caja]  WITH CHECK ADD  CONSTRAINT [FK_Caja_Bodega] FOREIGN KEY([Emp_Id], [Suc_Id], [Bod_Id])
REFERENCES [dbo].[Bodega] ([Emp_Id], [Suc_Id], [Bod_Id])
GO
ALTER TABLE [dbo].[Caja] CHECK CONSTRAINT [FK_Caja_Bodega]
GO
ALTER TABLE [dbo].[Caja]  WITH CHECK ADD  CONSTRAINT [FK_Caja_Sucursal] FOREIGN KEY([Emp_Id], [Suc_Id])
REFERENCES [dbo].[Sucursal] ([Emp_Id], [Suc_Id])
GO
ALTER TABLE [dbo].[Caja] CHECK CONSTRAINT [FK_Caja_Sucursal]
GO
ALTER TABLE [dbo].[CajaCierreDetalle]  WITH NOCHECK ADD  CONSTRAINT [FK_CajaCierreDetalle_CajaCierreEncabezado] FOREIGN KEY([Emp_Id], [Suc_Id], [Caja_Id], [Cierre_Id])
REFERENCES [dbo].[CajaCierreEncabezado] ([Emp_Id], [Suc_Id], [Caja_Id], [Cierre_Id])
GO
ALTER TABLE [dbo].[CajaCierreDetalle] CHECK CONSTRAINT [FK_CajaCierreDetalle_CajaCierreEncabezado]
GO
ALTER TABLE [dbo].[CajaCierreEncabezado]  WITH NOCHECK ADD  CONSTRAINT [FK_CajaCierreEncabezado_Caja] FOREIGN KEY([Emp_Id], [Suc_Id], [Caja_Id])
REFERENCES [dbo].[Caja] ([Emp_Id], [Suc_Id], [Caja_Id])
GO
ALTER TABLE [dbo].[CajaCierreEncabezado] CHECK CONSTRAINT [FK_CajaCierreEncabezado_Caja]
GO
ALTER TABLE [dbo].[CajaCierreEncabezado]  WITH NOCHECK ADD  CONSTRAINT [FK_CajaCierreEncabezado_Usuario] FOREIGN KEY([Emp_Id], [Usuario_Id])
REFERENCES [dbo].[Usuario] ([Emp_Id], [Usuario_Id])
GO
ALTER TABLE [dbo].[CajaCierreEncabezado] CHECK CONSTRAINT [FK_CajaCierreEncabezado_Usuario]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_ClientePrecio] FOREIGN KEY([Emp_Id], [Precio_Id])
REFERENCES [dbo].[ClientePrecio] ([Emp_Id], [Precio_Id])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_ClientePrecio]
GO
ALTER TABLE [dbo].[ClienteAnotacion]  WITH CHECK ADD  CONSTRAINT [FK_ClienteAnotacion_Cliente] FOREIGN KEY([Emp_Id], [Cliente_Id])
REFERENCES [dbo].[Cliente] ([Emp_Id], [Cliente_Id])
GO
ALTER TABLE [dbo].[ClienteAnotacion] CHECK CONSTRAINT [FK_ClienteAnotacion_Cliente]
GO
ALTER TABLE [dbo].[CxCMovimiento]  WITH CHECK ADD  CONSTRAINT [FK_CxCMovimiento_Cliente] FOREIGN KEY([Emp_Id], [Cliente_Id])
REFERENCES [dbo].[Cliente] ([Emp_Id], [Cliente_Id])
GO
ALTER TABLE [dbo].[CxCMovimiento] CHECK CONSTRAINT [FK_CxCMovimiento_Cliente]
GO
ALTER TABLE [dbo].[CxCMovimiento]  WITH CHECK ADD  CONSTRAINT [FK_CxCMovimiento_CxCMovimientoTipo] FOREIGN KEY([Emp_Id], [TipoMov_Id])
REFERENCES [dbo].[CxCMovimientoTipo] ([Emp_Id], [TipoMov_Id])
GO
ALTER TABLE [dbo].[CxCMovimiento] CHECK CONSTRAINT [FK_CxCMovimiento_CxCMovimientoTipo]
GO
ALTER TABLE [dbo].[CxCMovimiento]  WITH CHECK ADD  CONSTRAINT [FK_CxCMovimiento_Usuario] FOREIGN KEY([Emp_Id], [Usuario_Id])
REFERENCES [dbo].[Usuario] ([Emp_Id], [Usuario_Id])
GO
ALTER TABLE [dbo].[CxCMovimiento] CHECK CONSTRAINT [FK_CxCMovimiento_Usuario]
GO
ALTER TABLE [dbo].[CxCMovimientoAplica]  WITH CHECK ADD  CONSTRAINT [FK_CxCMovimientoAplica_CxCMovimiento] FOREIGN KEY([Emp_Id], [TipoMov_Id], [Mov_Id])
REFERENCES [dbo].[CxCMovimiento] ([Emp_Id], [TipoMov_Id], [Mov_Id])
GO
ALTER TABLE [dbo].[CxCMovimientoAplica] CHECK CONSTRAINT [FK_CxCMovimientoAplica_CxCMovimiento]
GO
ALTER TABLE [dbo].[CxCMovimientoAplica]  WITH CHECK ADD  CONSTRAINT [FK_CxCMovimientoAplica_CxCMovimiento1] FOREIGN KEY([Emp_Id], [AplicaTipoMov_Id], [AplicaMov_Id])
REFERENCES [dbo].[CxCMovimiento] ([Emp_Id], [TipoMov_Id], [Mov_Id])
GO
ALTER TABLE [dbo].[CxCMovimientoAplica] CHECK CONSTRAINT [FK_CxCMovimientoAplica_CxCMovimiento1]
GO
ALTER TABLE [dbo].[CxCMovimientoFactura]  WITH CHECK ADD  CONSTRAINT [FK_CxCMovimientoFactura_CxCMovimiento] FOREIGN KEY([Emp_Id], [TipoMov_Id], [Mov_Id])
REFERENCES [dbo].[CxCMovimiento] ([Emp_Id], [TipoMov_Id], [Mov_Id])
GO
ALTER TABLE [dbo].[CxCMovimientoFactura] CHECK CONSTRAINT [FK_CxCMovimientoFactura_CxCMovimiento]
GO
ALTER TABLE [dbo].[CxCMovimientoFactura]  WITH NOCHECK ADD  CONSTRAINT [FK_CxCMovimientoFactura_FacturaEncabezado] FOREIGN KEY([Emp_Id], [Suc_Id], [Caja_Id], [TipoDoc_Id], [Documento_Id])
REFERENCES [dbo].[FacturaEncabezado] ([Emp_Id], [Suc_Id], [Caja_Id], [TipoDoc_Id], [Documento_Id])
GO
ALTER TABLE [dbo].[CxCMovimientoFactura] CHECK CONSTRAINT [FK_CxCMovimientoFactura_FacturaEncabezado]
GO
ALTER TABLE [dbo].[CxCMovimientoMora]  WITH CHECK ADD  CONSTRAINT [FK_CxCMovimientoMora_CxCMovimiento] FOREIGN KEY([Emp_Id], [TipoMov_Id], [Mov_Id])
REFERENCES [dbo].[CxCMovimiento] ([Emp_Id], [TipoMov_Id], [Mov_Id])
GO
ALTER TABLE [dbo].[CxCMovimientoMora] CHECK CONSTRAINT [FK_CxCMovimientoMora_CxCMovimiento]
GO
ALTER TABLE [dbo].[CxCMovimientoMora]  WITH CHECK ADD  CONSTRAINT [FK_CxCMovimientoMora_CxCMovimiento1] FOREIGN KEY([Emp_Id], [AplicaTipoMov_Id], [AplicaMov_Id])
REFERENCES [dbo].[CxCMovimiento] ([Emp_Id], [TipoMov_Id], [Mov_Id])
GO
ALTER TABLE [dbo].[CxCMovimientoMora] CHECK CONSTRAINT [FK_CxCMovimientoMora_CxCMovimiento1]
GO
ALTER TABLE [dbo].[CxCMovimientoPago]  WITH CHECK ADD  CONSTRAINT [FK_CxCMovimientoPago_CxCMovimiento] FOREIGN KEY([Emp_Id], [TipoMov_Id], [Mov_Id])
REFERENCES [dbo].[CxCMovimiento] ([Emp_Id], [TipoMov_Id], [Mov_Id])
GO
ALTER TABLE [dbo].[CxCMovimientoPago] CHECK CONSTRAINT [FK_CxCMovimientoPago_CxCMovimiento]
GO
ALTER TABLE [dbo].[EmpresaParametro]  WITH CHECK ADD  CONSTRAINT [FK_EmpresaParametro_Empresa] FOREIGN KEY([Emp_Id])
REFERENCES [dbo].[Empresa] ([Emp_Id])
GO
ALTER TABLE [dbo].[EmpresaParametro] CHECK CONSTRAINT [FK_EmpresaParametro_Empresa]
GO
ALTER TABLE [dbo].[EntradaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_EntradaDetalle_Articulo] FOREIGN KEY([Emp_Id], [Art_Id])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO
ALTER TABLE [dbo].[EntradaDetalle] CHECK CONSTRAINT [FK_EntradaDetalle_Articulo]
GO
ALTER TABLE [dbo].[EntradaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_EntradaDetalle_Articulo1] FOREIGN KEY([Emp_Id], [Art_Id])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO
ALTER TABLE [dbo].[EntradaDetalle] CHECK CONSTRAINT [FK_EntradaDetalle_Articulo1]
GO
ALTER TABLE [dbo].[EntradaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_EntradaDetalle_EntradaEncabezado] FOREIGN KEY([Emp_Id], [Suc_Id], [Entrada_Id])
REFERENCES [dbo].[EntradaEncabezado] ([Emp_Id], [Suc_Id], [Entrada_Id])
GO
ALTER TABLE [dbo].[EntradaDetalle] CHECK CONSTRAINT [FK_EntradaDetalle_EntradaEncabezado]
GO
ALTER TABLE [dbo].[EntradaEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_EntradaEncabezado_EntradaEstado] FOREIGN KEY([Emp_Id], [EntradaEstado_Id])
REFERENCES [dbo].[EntradaEstado] ([Emp_Id], [EntradaEstado_Id])
GO
ALTER TABLE [dbo].[EntradaEncabezado] CHECK CONSTRAINT [FK_EntradaEncabezado_EntradaEstado]
GO
ALTER TABLE [dbo].[EntradaEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_EntradaEncabezado_OrdenCompraEncabezado] FOREIGN KEY([Emp_Id], [Suc_Id], [Orden_Id])
REFERENCES [dbo].[OrdenCompraEncabezado] ([Emp_Id], [Suc_Id], [Orden_Id])
GO
ALTER TABLE [dbo].[EntradaEncabezado] CHECK CONSTRAINT [FK_EntradaEncabezado_OrdenCompraEncabezado]
GO
ALTER TABLE [dbo].[EntradaEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_EntradaEncabezado_Sucursal] FOREIGN KEY([Emp_Id], [Suc_Id])
REFERENCES [dbo].[Sucursal] ([Emp_Id], [Suc_Id])
GO
ALTER TABLE [dbo].[EntradaEncabezado] CHECK CONSTRAINT [FK_EntradaEncabezado_Sucursal]
GO
ALTER TABLE [dbo].[EntradaEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_EntradaEncabezado_Usuario] FOREIGN KEY([Emp_Id], [Usuario_Id])
REFERENCES [dbo].[Usuario] ([Emp_Id], [Usuario_Id])
GO
ALTER TABLE [dbo].[EntradaEncabezado] CHECK CONSTRAINT [FK_EntradaEncabezado_Usuario]
GO
ALTER TABLE [dbo].[EntradaEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_EntradaEncabezado_Usuario1] FOREIGN KEY([Emp_Id], [AplicaUsuario_Id])
REFERENCES [dbo].[Usuario] ([Emp_Id], [Usuario_Id])
GO
ALTER TABLE [dbo].[EntradaEncabezado] CHECK CONSTRAINT [FK_EntradaEncabezado_Usuario1]
GO
ALTER TABLE [dbo].[EntradaFactura]  WITH CHECK ADD  CONSTRAINT [FK_EntradaFactura_EntradaEncabezado] FOREIGN KEY([Emp_Id], [Suc_Id], [Entrada_Id])
REFERENCES [dbo].[EntradaEncabezado] ([Emp_Id], [Suc_Id], [Entrada_Id])
GO
ALTER TABLE [dbo].[EntradaFactura] CHECK CONSTRAINT [FK_EntradaFactura_EntradaEncabezado]
GO
ALTER TABLE [dbo].[EntradaFactura]  WITH CHECK ADD  CONSTRAINT [FK_EntradaFactura_Proveedor] FOREIGN KEY([Emp_Id], [Prov_Id])
REFERENCES [dbo].[Proveedor] ([Emp_Id], [Prov_Id])
GO
ALTER TABLE [dbo].[EntradaFactura] CHECK CONSTRAINT [FK_EntradaFactura_Proveedor]
GO
ALTER TABLE [dbo].[FacturaDetalle]  WITH NOCHECK ADD  CONSTRAINT [FK_FacturaDetalle_Articulo] FOREIGN KEY([Emp_Id], [Art_Id])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO
ALTER TABLE [dbo].[FacturaDetalle] CHECK CONSTRAINT [FK_FacturaDetalle_Articulo]
GO
ALTER TABLE [dbo].[FacturaDetalle]  WITH NOCHECK ADD  CONSTRAINT [FK_FacturaDetalle_FacturaEncabezado] FOREIGN KEY([Emp_Id], [Suc_Id], [Caja_Id], [TipoDoc_Id], [Documento_Id])
REFERENCES [dbo].[FacturaEncabezado] ([Emp_Id], [Suc_Id], [Caja_Id], [TipoDoc_Id], [Documento_Id])
GO
ALTER TABLE [dbo].[FacturaDetalle] CHECK CONSTRAINT [FK_FacturaDetalle_FacturaEncabezado]
GO
ALTER TABLE [dbo].[FacturaDevolucion]  WITH NOCHECK ADD  CONSTRAINT [FK_FacturaDevolucion_FacturaEncabezado] FOREIGN KEY([Emp_Id], [Suc_Id], [Caja_Id], [TipoDoc_Id], [Documento_Id])
REFERENCES [dbo].[FacturaEncabezado] ([Emp_Id], [Suc_Id], [Caja_Id], [TipoDoc_Id], [Documento_Id])
GO
ALTER TABLE [dbo].[FacturaDevolucion] CHECK CONSTRAINT [FK_FacturaDevolucion_FacturaEncabezado]
GO
ALTER TABLE [dbo].[FacturaDevolucion]  WITH CHECK ADD  CONSTRAINT [FK_FacturaDevolucion_FacturaEncabezado1] FOREIGN KEY([Emp_Id], [Dev_Suc_Id], [Dev_Caja_Id], [Dev_TipoDoc_Id], [Dev_Documento_Id])
REFERENCES [dbo].[FacturaEncabezado] ([Emp_Id], [Suc_Id], [Caja_Id], [TipoDoc_Id], [Documento_Id])
GO
ALTER TABLE [dbo].[FacturaDevolucion] CHECK CONSTRAINT [FK_FacturaDevolucion_FacturaEncabezado1]
GO
ALTER TABLE [dbo].[FacturaEncabezado]  WITH NOCHECK ADD  CONSTRAINT [FK_FacturaEncabezado_Bodega] FOREIGN KEY([Emp_Id], [Suc_Id], [Bod_Id])
REFERENCES [dbo].[Bodega] ([Emp_Id], [Suc_Id], [Bod_Id])
GO
ALTER TABLE [dbo].[FacturaEncabezado] CHECK CONSTRAINT [FK_FacturaEncabezado_Bodega]
GO
ALTER TABLE [dbo].[FacturaEncabezado]  WITH NOCHECK ADD  CONSTRAINT [FK_FacturaEncabezado_Caja] FOREIGN KEY([Emp_Id], [Suc_Id], [Caja_Id])
REFERENCES [dbo].[Caja] ([Emp_Id], [Suc_Id], [Caja_Id])
GO
ALTER TABLE [dbo].[FacturaEncabezado] CHECK CONSTRAINT [FK_FacturaEncabezado_Caja]
GO
ALTER TABLE [dbo].[FacturaEncabezado]  WITH NOCHECK ADD  CONSTRAINT [FK_FacturaEncabezado_CajaCierreEncabezado] FOREIGN KEY([Emp_Id], [Suc_Id], [Caja_Id], [Cierre_Id])
REFERENCES [dbo].[CajaCierreEncabezado] ([Emp_Id], [Suc_Id], [Caja_Id], [Cierre_Id])
GO
ALTER TABLE [dbo].[FacturaEncabezado] CHECK CONSTRAINT [FK_FacturaEncabezado_CajaCierreEncabezado]
GO
ALTER TABLE [dbo].[FacturaEncabezado]  WITH NOCHECK ADD  CONSTRAINT [FK_FacturaEncabezado_Cliente] FOREIGN KEY([Emp_Id], [Cliente_Id])
REFERENCES [dbo].[Cliente] ([Emp_Id], [Cliente_Id])
GO
ALTER TABLE [dbo].[FacturaEncabezado] CHECK CONSTRAINT [FK_FacturaEncabezado_Cliente]
GO
ALTER TABLE [dbo].[FacturaEncabezado]  WITH NOCHECK ADD  CONSTRAINT [FK_FacturaEncabezado_TipoDocumento] FOREIGN KEY([Emp_Id], [TipoDoc_Id])
REFERENCES [dbo].[TipoDocumento] ([Emp_Id], [TipoDoc_Id])
GO
ALTER TABLE [dbo].[FacturaEncabezado] CHECK CONSTRAINT [FK_FacturaEncabezado_TipoDocumento]
GO
ALTER TABLE [dbo].[FacturaEncabezado]  WITH NOCHECK ADD  CONSTRAINT [FK_FacturaEncabezado_Usuario] FOREIGN KEY([Emp_Id], [Usuario_Id])
REFERENCES [dbo].[Usuario] ([Emp_Id], [Usuario_Id])
GO
ALTER TABLE [dbo].[FacturaEncabezado] CHECK CONSTRAINT [FK_FacturaEncabezado_Usuario]
GO
ALTER TABLE [dbo].[FacturaEncabezado]  WITH NOCHECK ADD  CONSTRAINT [FK_FacturaEncabezado_Vendedor] FOREIGN KEY([Emp_Id], [Vendedor_Id])
REFERENCES [dbo].[Vendedor] ([Emp_Id], [Vendedor_Id])
GO
ALTER TABLE [dbo].[FacturaEncabezado] CHECK CONSTRAINT [FK_FacturaEncabezado_Vendedor]
GO
ALTER TABLE [dbo].[FacturaPago]  WITH NOCHECK ADD  CONSTRAINT [FK_FacturaPago_Banco] FOREIGN KEY([Emp_Id], [Banco_Id])
REFERENCES [dbo].[Banco] ([Emp_Id], [Banco_Id])
GO
ALTER TABLE [dbo].[FacturaPago] CHECK CONSTRAINT [FK_FacturaPago_Banco]
GO
ALTER TABLE [dbo].[FacturaPago]  WITH NOCHECK ADD  CONSTRAINT [FK_FacturaPago_FacturaEncabezado] FOREIGN KEY([Emp_Id], [Suc_Id], [Caja_Id], [TipoDoc_Id], [Documento_Id])
REFERENCES [dbo].[FacturaEncabezado] ([Emp_Id], [Suc_Id], [Caja_Id], [TipoDoc_Id], [Documento_Id])
GO
ALTER TABLE [dbo].[FacturaPago] CHECK CONSTRAINT [FK_FacturaPago_FacturaEncabezado]
GO
ALTER TABLE [dbo].[FacturaPago]  WITH NOCHECK ADD  CONSTRAINT [FK_FacturaPago_Tarjeta] FOREIGN KEY([Emp_Id], [Tarjeta_Id])
REFERENCES [dbo].[Tarjeta] ([Emp_Id], [Tarjeta_Id])
GO
ALTER TABLE [dbo].[FacturaPago] CHECK CONSTRAINT [FK_FacturaPago_Tarjeta]
GO
ALTER TABLE [dbo].[FacturaPago]  WITH NOCHECK ADD  CONSTRAINT [FK_FacturaPago_TipoPago] FOREIGN KEY([Emp_Id], [TipoPago_Id])
REFERENCES [dbo].[TipoPago] ([Emp_Id], [TipoPago_Id])
GO
ALTER TABLE [dbo].[FacturaPago] CHECK CONSTRAINT [FK_FacturaPago_TipoPago]
GO
ALTER TABLE [dbo].[Grupo]  WITH CHECK ADD  CONSTRAINT [FK_Grupo_Empresa] FOREIGN KEY([Emp_Id])
REFERENCES [dbo].[Empresa] ([Emp_Id])
GO
ALTER TABLE [dbo].[Grupo] CHECK CONSTRAINT [FK_Grupo_Empresa]
GO
ALTER TABLE [dbo].[GrupoMenu]  WITH CHECK ADD  CONSTRAINT [FK_GrupoMenu_Grupo] FOREIGN KEY([Emp_Id], [Grupo_Id])
REFERENCES [dbo].[Grupo] ([Emp_Id], [Grupo_Id])
GO
ALTER TABLE [dbo].[GrupoMenu] CHECK CONSTRAINT [FK_GrupoMenu_Grupo]
GO
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Modulo] FOREIGN KEY([Modulo_Id])
REFERENCES [dbo].[Modulo] ([Modulo_Id])
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_Modulo]
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
ALTER TABLE [dbo].[MovimientoEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_MovimientoEncabezado_Bodega] FOREIGN KEY([Emp_Id], [Suc_Id], [Bod_Id])
REFERENCES [dbo].[Bodega] ([Emp_Id], [Suc_Id], [Bod_Id])
GO
ALTER TABLE [dbo].[MovimientoEncabezado] CHECK CONSTRAINT [FK_MovimientoEncabezado_Bodega]
GO
ALTER TABLE [dbo].[MovimientoEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_MovimientoEncabezado_Bodega1] FOREIGN KEY([Emp_Id], [Suc_Id_Destino], [Bod_Id_Destino])
REFERENCES [dbo].[Bodega] ([Emp_Id], [Suc_Id], [Bod_Id])
GO
ALTER TABLE [dbo].[MovimientoEncabezado] CHECK CONSTRAINT [FK_MovimientoEncabezado_Bodega1]
GO
ALTER TABLE [dbo].[MovimientoEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_MovimientoEncabezado_TipoMovimiento] FOREIGN KEY([Emp_Id], [TipoMov_Id])
REFERENCES [dbo].[TipoMovimiento] ([Emp_Id], [TipoMov_Id])
GO
ALTER TABLE [dbo].[MovimientoEncabezado] CHECK CONSTRAINT [FK_MovimientoEncabezado_TipoMovimiento]
GO
ALTER TABLE [dbo].[MovimientoEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_MovimientoEncabezado_Usuario] FOREIGN KEY([Emp_Id], [Usuario_Id])
REFERENCES [dbo].[Usuario] ([Emp_Id], [Usuario_Id])
GO
ALTER TABLE [dbo].[MovimientoEncabezado] CHECK CONSTRAINT [FK_MovimientoEncabezado_Usuario]
GO
ALTER TABLE [dbo].[OrdenCompraDetalle]  WITH CHECK ADD  CONSTRAINT [FK_OrdenCompraDetalle_Articulo] FOREIGN KEY([Emp_Id], [Art_Id])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO
ALTER TABLE [dbo].[OrdenCompraDetalle] CHECK CONSTRAINT [FK_OrdenCompraDetalle_Articulo]
GO
ALTER TABLE [dbo].[OrdenCompraDetalle]  WITH CHECK ADD  CONSTRAINT [FK_OrdenCompraDetalle_OrdenCompraEncabezado] FOREIGN KEY([Emp_Id], [Suc_Id], [Orden_Id])
REFERENCES [dbo].[OrdenCompraEncabezado] ([Emp_Id], [Suc_Id], [Orden_Id])
GO
ALTER TABLE [dbo].[OrdenCompraDetalle] CHECK CONSTRAINT [FK_OrdenCompraDetalle_OrdenCompraEncabezado]
GO
ALTER TABLE [dbo].[OrdenCompraEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_OrdenCompraEncabezado_OrdenCompraEstado] FOREIGN KEY([Emp_Id], [OrdenEstado_Id])
REFERENCES [dbo].[OrdenCompraEstado] ([Emp_Id], [OrdenEstado_Id])
GO
ALTER TABLE [dbo].[OrdenCompraEncabezado] CHECK CONSTRAINT [FK_OrdenCompraEncabezado_OrdenCompraEstado]
GO
ALTER TABLE [dbo].[OrdenCompraEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_OrdenCompraEncabezado_Proveedor] FOREIGN KEY([Emp_Id], [Prov_Id])
REFERENCES [dbo].[Proveedor] ([Emp_Id], [Prov_Id])
GO
ALTER TABLE [dbo].[OrdenCompraEncabezado] CHECK CONSTRAINT [FK_OrdenCompraEncabezado_Proveedor]
GO
ALTER TABLE [dbo].[OrdenCompraEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_OrdenCompraEncabezado_Sucursal] FOREIGN KEY([Emp_Id], [Suc_Id])
REFERENCES [dbo].[Sucursal] ([Emp_Id], [Suc_Id])
GO
ALTER TABLE [dbo].[OrdenCompraEncabezado] CHECK CONSTRAINT [FK_OrdenCompraEncabezado_Sucursal]
GO
ALTER TABLE [dbo].[OrdenCompraEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_OrdenCompraEncabezado_Usuario] FOREIGN KEY([Emp_Id], [Usuario_Id])
REFERENCES [dbo].[Usuario] ([Emp_Id], [Usuario_Id])
GO
ALTER TABLE [dbo].[OrdenCompraEncabezado] CHECK CONSTRAINT [FK_OrdenCompraEncabezado_Usuario]
GO
ALTER TABLE [dbo].[OrdenCompraEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_OrdenCompraEncabezado_Usuario1] FOREIGN KEY([Emp_Id], [AplicaUsuario_Id])
REFERENCES [dbo].[Usuario] ([Emp_Id], [Usuario_Id])
GO
ALTER TABLE [dbo].[OrdenCompraEncabezado] CHECK CONSTRAINT [FK_OrdenCompraEncabezado_Usuario1]
GO
ALTER TABLE [dbo].[Permiso]  WITH CHECK ADD  CONSTRAINT [FK_Permiso_Modulo] FOREIGN KEY([Modulo_Id])
REFERENCES [dbo].[Modulo] ([Modulo_Id])
GO
ALTER TABLE [dbo].[Permiso] CHECK CONSTRAINT [FK_Permiso_Modulo]
GO
ALTER TABLE [dbo].[PermisoBitacora]  WITH NOCHECK ADD  CONSTRAINT [FK_PermisoBitacora_Permiso] FOREIGN KEY([Permiso_Id])
REFERENCES [dbo].[Permiso] ([Permiso_Id])
GO
ALTER TABLE [dbo].[PermisoBitacora] CHECK CONSTRAINT [FK_PermisoBitacora_Permiso]
GO
ALTER TABLE [dbo].[PermisoBitacora]  WITH NOCHECK ADD  CONSTRAINT [FK_PermisoBitacora_Sucursal] FOREIGN KEY([Emp_Id], [Suc_Id])
REFERENCES [dbo].[Sucursal] ([Emp_Id], [Suc_Id])
GO
ALTER TABLE [dbo].[PermisoBitacora] CHECK CONSTRAINT [FK_PermisoBitacora_Sucursal]
GO
ALTER TABLE [dbo].[PermisoBitacora]  WITH NOCHECK ADD  CONSTRAINT [FK_PermisoBitacora_Usuario] FOREIGN KEY([Emp_Id], [Usuario_Id])
REFERENCES [dbo].[Usuario] ([Emp_Id], [Usuario_Id])
GO
ALTER TABLE [dbo].[PermisoBitacora] CHECK CONSTRAINT [FK_PermisoBitacora_Usuario]
GO
ALTER TABLE [dbo].[ProformaDetalle]  WITH NOCHECK ADD  CONSTRAINT [FK_ProformaDetalle_Articulo] FOREIGN KEY([Emp_Id], [Art_Id])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO
ALTER TABLE [dbo].[ProformaDetalle] CHECK CONSTRAINT [FK_ProformaDetalle_Articulo]
GO
ALTER TABLE [dbo].[ProformaDetalle]  WITH NOCHECK ADD  CONSTRAINT [FK_ProformaDetalle_ProformaEncabezado] FOREIGN KEY([Emp_Id], [Suc_Id], [Documento_Id])
REFERENCES [dbo].[ProformaEncabezado] ([Emp_Id], [Suc_Id], [Documento_Id])
GO
ALTER TABLE [dbo].[ProformaDetalle] CHECK CONSTRAINT [FK_ProformaDetalle_ProformaEncabezado]
GO
ALTER TABLE [dbo].[ProformaEncabezado]  WITH NOCHECK ADD  CONSTRAINT [FK_ProformaEncabezado_Bodega] FOREIGN KEY([Emp_Id], [Suc_Id], [Bod_Id])
REFERENCES [dbo].[Bodega] ([Emp_Id], [Suc_Id], [Bod_Id])
GO
ALTER TABLE [dbo].[ProformaEncabezado] CHECK CONSTRAINT [FK_ProformaEncabezado_Bodega]
GO
ALTER TABLE [dbo].[ProformaEncabezado]  WITH NOCHECK ADD  CONSTRAINT [FK_ProformaEncabezado_Cliente] FOREIGN KEY([Emp_Id], [Cliente_Id])
REFERENCES [dbo].[Cliente] ([Emp_Id], [Cliente_Id])
GO
ALTER TABLE [dbo].[ProformaEncabezado] CHECK CONSTRAINT [FK_ProformaEncabezado_Cliente]
GO
ALTER TABLE [dbo].[ProformaEncabezado]  WITH NOCHECK ADD  CONSTRAINT [FK_ProformaEncabezado_ProformaTipo] FOREIGN KEY([Emp_Id], [Tipo])
REFERENCES [dbo].[ProformaTipo] ([Emp_Id], [Tipo])
GO
ALTER TABLE [dbo].[ProformaEncabezado] CHECK CONSTRAINT [FK_ProformaEncabezado_ProformaTipo]
GO
ALTER TABLE [dbo].[ProformaEncabezado]  WITH NOCHECK ADD  CONSTRAINT [FK_ProformaEncabezado_ProformaTipoEntrega] FOREIGN KEY([Emp_Id], [TipoEntrega_Id])
REFERENCES [dbo].[ProformaTipoEntrega] ([Emp_Id], [TipoEntrega_Id])
GO
ALTER TABLE [dbo].[ProformaEncabezado] CHECK CONSTRAINT [FK_ProformaEncabezado_ProformaTipoEntrega]
GO
ALTER TABLE [dbo].[ProformaEncabezado]  WITH NOCHECK ADD  CONSTRAINT [FK_ProformaEncabezado_TipoDocumento] FOREIGN KEY([Emp_Id], [TipoDoc_Id])
REFERENCES [dbo].[TipoDocumento] ([Emp_Id], [TipoDoc_Id])
GO
ALTER TABLE [dbo].[ProformaEncabezado] CHECK CONSTRAINT [FK_ProformaEncabezado_TipoDocumento]
GO
ALTER TABLE [dbo].[ProformaEncabezado]  WITH NOCHECK ADD  CONSTRAINT [FK_ProformaEncabezado_Usuario] FOREIGN KEY([Emp_Id], [Usuario_Id])
REFERENCES [dbo].[Usuario] ([Emp_Id], [Usuario_Id])
GO
ALTER TABLE [dbo].[ProformaEncabezado] CHECK CONSTRAINT [FK_ProformaEncabezado_Usuario]
GO
ALTER TABLE [dbo].[ProformaEncabezado]  WITH NOCHECK ADD  CONSTRAINT [FK_ProformaEncabezado_Vendedor] FOREIGN KEY([Emp_Id], [Vendedor_Id])
REFERENCES [dbo].[Vendedor] ([Emp_Id], [Vendedor_Id])
GO
ALTER TABLE [dbo].[ProformaEncabezado] CHECK CONSTRAINT [FK_ProformaEncabezado_Vendedor]
GO
ALTER TABLE [dbo].[SubCategoria]  WITH CHECK ADD  CONSTRAINT [FK_SubCategoria_Categoria] FOREIGN KEY([Emp_Id], [Cat_Id])
REFERENCES [dbo].[Categoria] ([Emp_Id], [Cat_Id])
GO
ALTER TABLE [dbo].[SubCategoria] CHECK CONSTRAINT [FK_SubCategoria_Categoria]
GO
ALTER TABLE [dbo].[Sucursal]  WITH CHECK ADD  CONSTRAINT [FK_Sucursal_Empresa] FOREIGN KEY([Emp_Id])
REFERENCES [dbo].[Empresa] ([Emp_Id])
GO
ALTER TABLE [dbo].[Sucursal] CHECK CONSTRAINT [FK_Sucursal_Empresa]
GO
ALTER TABLE [dbo].[SucursalParametro]  WITH CHECK ADD  CONSTRAINT [FK_SucursalParametro_Bodega] FOREIGN KEY([Emp_Id], [Suc_Id], [BodCompra_Id])
REFERENCES [dbo].[Bodega] ([Emp_Id], [Suc_Id], [Bod_Id])
GO
ALTER TABLE [dbo].[SucursalParametro] CHECK CONSTRAINT [FK_SucursalParametro_Bodega]
GO
ALTER TABLE [dbo].[SucursalParametro]  WITH CHECK ADD  CONSTRAINT [FK_SucursalParametro_Sucursal] FOREIGN KEY([Emp_Id], [Suc_Id])
REFERENCES [dbo].[Sucursal] ([Emp_Id], [Suc_Id])
GO
ALTER TABLE [dbo].[SucursalParametro] CHECK CONSTRAINT [FK_SucursalParametro_Sucursal]
GO
ALTER TABLE [dbo].[TrasladoDetalle]  WITH CHECK ADD  CONSTRAINT [FK_TrasladoDetalle_Articulo] FOREIGN KEY([Emp_Id], [Art_Id])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO
ALTER TABLE [dbo].[TrasladoDetalle] CHECK CONSTRAINT [FK_TrasladoDetalle_Articulo]
GO
ALTER TABLE [dbo].[TrasladoDetalle]  WITH CHECK ADD  CONSTRAINT [FK_TrasladoDetalle_TrasladoEncabezado] FOREIGN KEY([Emp_Id], [Suc_Id], [Traslado_Id])
REFERENCES [dbo].[TrasladoEncabezado] ([Emp_Id], [Suc_Id], [Traslado_Id])
GO
ALTER TABLE [dbo].[TrasladoDetalle] CHECK CONSTRAINT [FK_TrasladoDetalle_TrasladoEncabezado]
GO
ALTER TABLE [dbo].[TrasladoEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_TrasladoEncabezado_Bodega] FOREIGN KEY([Emp_Id], [Suc_Id], [Bod_Id])
REFERENCES [dbo].[Bodega] ([Emp_Id], [Suc_Id], [Bod_Id])
GO
ALTER TABLE [dbo].[TrasladoEncabezado] CHECK CONSTRAINT [FK_TrasladoEncabezado_Bodega]
GO
ALTER TABLE [dbo].[TrasladoEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_TrasladoEncabezado_Bodega1] FOREIGN KEY([Emp_Id], [Suc_Id_Destino], [Bod_Id_Destino])
REFERENCES [dbo].[Bodega] ([Emp_Id], [Suc_Id], [Bod_Id])
GO
ALTER TABLE [dbo].[TrasladoEncabezado] CHECK CONSTRAINT [FK_TrasladoEncabezado_Bodega1]
GO
ALTER TABLE [dbo].[TrasladoEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_TrasladoEncabezado_Usuario] FOREIGN KEY([Emp_Id], [Usuario_Id])
REFERENCES [dbo].[Usuario] ([Emp_Id], [Usuario_Id])
GO
ALTER TABLE [dbo].[TrasladoEncabezado] CHECK CONSTRAINT [FK_TrasladoEncabezado_Usuario]
GO
ALTER TABLE [dbo].[TrasladoEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_TrasladoEncabezado_Usuario1] FOREIGN KEY([Emp_Id], [AplicaUsuario_Id])
REFERENCES [dbo].[Usuario] ([Emp_Id], [Usuario_Id])
GO
ALTER TABLE [dbo].[TrasladoEncabezado] CHECK CONSTRAINT [FK_TrasladoEncabezado_Usuario1]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Grupo] FOREIGN KEY([Emp_Id], [Grupo_Id])
REFERENCES [dbo].[Grupo] ([Emp_Id], [Grupo_Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Grupo]
GO
ALTER TABLE [dbo].[UsuarioPermiso]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioPermiso_Modulo] FOREIGN KEY([Modulo_Id])
REFERENCES [dbo].[Modulo] ([Modulo_Id])
GO
ALTER TABLE [dbo].[UsuarioPermiso] CHECK CONSTRAINT [FK_UsuarioPermiso_Modulo]
GO
ALTER TABLE [dbo].[UsuarioPermiso]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioPermiso_Permiso] FOREIGN KEY([Permiso_Id])
REFERENCES [dbo].[Permiso] ([Permiso_Id])
GO
ALTER TABLE [dbo].[UsuarioPermiso] CHECK CONSTRAINT [FK_UsuarioPermiso_Permiso]
GO
ALTER TABLE [dbo].[UsuarioPermiso]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioPermiso_Usuario] FOREIGN KEY([Emp_Id], [Usuario_Id])
REFERENCES [dbo].[Usuario] ([Emp_Id], [Usuario_Id])
GO
ALTER TABLE [dbo].[UsuarioPermiso] CHECK CONSTRAINT [FK_UsuarioPermiso_Usuario]
GO
ALTER TABLE [dbo].[Vendedor]  WITH CHECK ADD  CONSTRAINT [FK_Vendedor_Empresa] FOREIGN KEY([Emp_Id])
REFERENCES [dbo].[Empresa] ([Emp_Id])
GO
ALTER TABLE [dbo].[Vendedor] CHECK CONSTRAINT [FK_Vendedor_Empresa]
GO
ALTER TABLE [dbo].[Articulo]  WITH CHECK ADD  CONSTRAINT [CK_Articulo_FactorConversion] CHECK  (([FactorConversion]>(0)))
GO
ALTER TABLE [dbo].[Articulo] CHECK CONSTRAINT [CK_Articulo_FactorConversion]
GO
ALTER TABLE [dbo].[FacturaPago]  WITH CHECK ADD  CONSTRAINT [CK_FacturaPago] CHECK  (([TipoPago_Id]=(4) OR [TipoPago_Id]=(3) OR [TipoPago_Id]=(2) OR [TipoPago_Id]=(1)))
GO
ALTER TABLE [dbo].[FacturaPago] CHECK CONSTRAINT [CK_FacturaPago]
GO
/****** Object:  StoredProcedure [dbo].[AjustaEntradaExentoGrabado]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[AjustaEntradaExentoGrabado]
as
begin
  create table #Totales(Entrada_Id int, ExentoIV bit, Exento money, Gravado Money)
  create table #TotalesResumen(Entrada_Id int, Exento money, Gravado Money)

  insert #Totales 
  select Entrada_Id 
        ,ExentoIV 
        ,case when  ExentoIV = 1 then sum(Costo * Cantidad ) else 0 end Exento
        ,case when  ExentoIV = 0 then sum(Costo * Cantidad ) else 0 end Gravado

  from  EntradaDetalle 
  group by Entrada_Id,ExentoIV
  order by Entrada_Id
  
  

  insert #TotalesResumen
  select Entrada_Id, SUM(exento), sum(gravado)
  from  #Totales
  group by Entrada_Id
  
  
  select *
  from #TotalesResumen
  
  
  update a set a.Exento = b.Exento , a.Gravado = b.Gravado 
  from  EntradaEncabezado a,
        #TotalesResumen b
  where a.Entrada_Id = b.Entrada_Id 
      
  
  
end

GO
/****** Object:  StoredProcedure [dbo].[AplicaEntrada]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AplicaEntrada]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pEntrada_Id int 
,@pUsuario_Id varchar(20))
as
begin
  begin try
  
    declare  @Bod_Id              smallint
            ,@Art_Id              varchar(13)
            ,@Cantidad            float
            ,@Costo               money
            ,@CantidadBonificada  float
            ,@Orden_Id            int
            ,@SaldoActual         float
            ,@CostoActual         money
            ,@SpResult            int
            ,@CostoPromedio       float
            ,@Margen              float
            ,@Precio              money


    --Marca el encabezado como aplicado
    update EntradaEncabezado set   EntradaEstado_Id   = 2
                                  ,AplicaUsuario_Id   = @pUsuario_Id
                                  ,AplicaFecha        = getdate()
                                  ,UltimaModificacion = getdate()
    where Emp_Id     = @pEmp_Id
    and   Suc_Id     = @pSuc_Id
    and   Entrada_Id = @pEntrada_Id
    if @@error<>0 begin
      raiserror ('Error Marcando como aplicado: EntradaEncabezado', 16, 1)
    end
    
    
    --Busca datos de encabezado
    select  @Orden_Id = isnull(Orden_Id,-1)
           ,@Bod_Id   = Bod_Id
    from  EntradaEncabezado
    where Emp_Id     = @pEmp_Id
    and   Suc_Id     = @pSuc_Id
    and   Entrada_Id = @pEntrada_Id
    if @@error<>0 begin
      raiserror ('Error buscando numero de orden: EntradaEncabezado', 16, 1)
    end    
  
  
    --Si se encontro un numero de orden libera los comprometidos
    if @Orden_Id > 0 begin
      declare CurDetalle cursor for
      select Art_Id
            ,Cantidad
            ,Costo
      from  OrdenCompraDetalle
      where Emp_Id     = @pEmp_Id
      and   Suc_Id     = @pSuc_Id
      and   Orden_Id   = @Orden_Id  
  
      open CurDetalle
      
      fetch next from CurDetalle
      into @Art_Id, @Cantidad, @Costo
      
      while @@fetch_status = 0 begin
        update ArticuloBodega set  Transito = Transito - @Cantidad
                                  ,UltimaModificacion  = getdate()
        where Emp_Id = @pEmp_Id
        and   Suc_Id = @pSuc_Id
        and   Bod_Id = @Bod_Id
        and   Art_Id = @Art_Id
        if @@error<>0 begin
          raiserror ('Actualizando el transito del articulo', 16, 1)
        end          
            

        fetch next from CurDetalle
        into @Art_Id, @Cantidad, @Costo
      end

      close CurDetalle
      deallocate CurDetalle
    end
    
    
    --Hace la entrada al inventario y recalcula el precio
    declare CurEntrada cursor for
    select Art_Id
          ,Cantidad
          ,Costo - MontoDescuento 
          ,CantidadBonificada
          ,Margen
          ,Precio
    from  EntradaDetalle
    where Emp_Id     = @pEmp_Id
    and   Suc_Id     = @pSuc_Id
    and   Entrada_Id = @pEntrada_Id

    open CurEntrada
    
    fetch next from CurEntrada
    into @Art_Id, @Cantidad, @Costo, @CantidadBonificada, @Margen, @Precio
    
    while @@fetch_status = 0 begin
      --Busca el costo y saldo actual del articulo
      select @SaldoActual  = Saldo
            ,@CostoActual  = Costo
      from  ArticuloBodega
      where Emp_Id = @pEmp_Id
      and   Suc_Id = @pSuc_Id
      and   Bod_Id = @Bod_Id
      and   Art_Id = @Art_Id
      if @@error<>0 begin
        raiserror ('Actualizando el saldo del articulo', 16, 1)
      end 
      
      
      --Calcula el costo promedio
      set @CostoPromedio = 0
      if (@SaldoActual + @Cantidad)<>0 begin
        set @CostoPromedio = ((@CostoActual * @SaldoActual) + (@Costo * @Cantidad)) / (@SaldoActual + @Cantidad)
      end
      
        
      --Actualiza la informacion del articulo en la bodega    
      update ArticuloBodega set  CostoPromedio = case @CostoPromedio when 0 then CostoPromedio else @CostoPromedio end
                                ,Costo         = @Costo 
                                ,Margen        = @Margen
                                ,Precio        = @Precio
                                ,UltimaModificacion  = getdate()
      where Emp_Id = @pEmp_Id
      and   Suc_Id = @pSuc_Id
      and   Bod_Id = @Bod_Id
      and   Art_Id = @Art_Id
      if @@error<>0 begin
        raiserror ('Actualizando el saldo del articulo', 16, 1)
      end
      

      --Si es una devolucion el monto se envia negativo para que se haga la devolucion al inventario      
      set @Cantidad = (@Cantidad * -1)
      
      exec @SpResult = RebajaSumaIventario @pEmp_Id, @pSuc_Id, @Bod_Id, @Art_Id ,@Cantidad, 'Entrada de Mercadería', @pUsuario_Id
      if @SpResult<>0 begin
        raiserror ('Error ejecutando, RebajaSumaIventario, para el articulo: %s', 16, 1, @Art_Id)
      end
          
          
      if @CantidadBonificada >0 begin
        set @CantidadBonificada = (@CantidadBonificada * -1)
        
        exec @SpResult = RebajaSumaIventario @pEmp_Id, @pSuc_Id, @Bod_Id, @Art_Id ,@CantidadBonificada, 'Entrada de Mercadería(Bonificación)', @pUsuario_Id
        if @SpResult<>0 begin
          raiserror ('Error ejecutando, RebajaSumaIventario, para el articulo: %s', 16, 1, @Art_Id)
        end
      end
          

      fetch next from CurEntrada
      into @Art_Id, @Cantidad, @Costo, @CantidadBonificada, @Margen, @Precio
    end

    close CurEntrada
    deallocate CurEntrada    
    
      
  end try
  begin catch
  
    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch
end

GO
/****** Object:  StoredProcedure [dbo].[AplicaMovimientoAjuste]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AplicaMovimientoAjuste]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pTipoMov_Id smallint
,@pMov_Id int 
,@pUsuario_Id varchar(20))
as
begin
  --Aplica el ajuste de inventario y rebaja de inventario
  begin try
    declare  @Bod_Id            smallint
            ,@Art_Id            varchar(13)
            ,@Cantidad          float
            ,@Detalle           varchar(200)
            ,@Costo             money
            ,@SpResult          int
            ,@EntradaMercaderia bit
            ,@Comentario				varchar(200)
            
    --Busca el nombre del movimiento para la descripcion del Kardex
    select @Detalle           = Nombre
          ,@EntradaMercaderia = EntradaMercaderia
    from   TipoMovimiento
    where Emp_Id     = @pEmp_Id
    and   TipoMov_Id = @pTipoMov_Id
    if @@error<>0 begin
      raiserror ('Error Buscando tipo de movimiento', 16, 1)
    end        
  
    --Marca el movimiento como aplicado
    update MovimientoEncabezado set  Aplicado           = 1
                                    ,AplicaUsuario_Id   = @pUsuario_Id
                                    ,AplicaFecha        = getdate()
                                    ,UltimaModificacion = getdate()
    where Emp_Id     = @pEmp_Id
    and   Suc_Id     = @pSuc_Id
    and   TipoMov_Id = @pTipoMov_Id
    and   Mov_Id     = @pMov_Id
    if @@error<>0 begin
      raiserror ('Error Marcando como aplicado: MovimientoEncabezado', 16, 1)
    end
    
    --Busca la bodega en el encabezado para afectar las existencias
    select @Bod_Id = Bod_Id
					,@Comentario = Comentario
    from  MovimientoEncabezado
    where Emp_Id     = @pEmp_Id
    and   Suc_Id     = @pSuc_Id
    and   TipoMov_Id = @pTipoMov_Id
    and   Mov_Id     = @pMov_Id
    if @@error<>0 or @@rowcount = 0begin
      raiserror ('Error buscando datos en el encabezado del movimiento', 16, 1)
    end
    
    set @Detalle = rtrim(substring(@Detalle + ' ' + @Comentario,1,200))
    
    declare CurDetalle cursor for
    select Art_Id
          ,Cantidad
          ,Costo
    from  MovimientoDetalle
    where Emp_Id     = @pEmp_Id
    and   Suc_Id     = @pSuc_Id
    and   TipoMov_Id = @pTipoMov_Id
    and   Mov_Id     = @pMov_Id
    
    open CurDetalle
    
    fetch next from CurDetalle
    into @Art_Id, @Cantidad, @Costo
    
    while @@fetch_status = 0 begin

        --Le invierte el signo para que haga bien el rebajo o suma de inventario
        select @Cantidad = @Cantidad * -1
                   
        --La cantidad se envia negativo para que le sume al inventario y para que reste positiva
        exec @SpResult = RebajaSumaIventario @pEmp_Id, @pSuc_Id, @Bod_Id, @Art_Id ,@Cantidad, @Detalle, @pUsuario_Id
        if @SpResult<>0 begin
          raiserror ('Error ejecutando, RebajaSumaIventario, para el articulo: %s', 16, 1, @Art_Id)
        end  
        
        --Si es una entrada de mercaderia aplica actualiza con el ultimo costo
        --y hace el recalculo del precio
        if @EntradaMercaderia = 1 begin
          update ArticuloBodega set  Costo              = @Costo
                                    ,UltimaModificacion = getdate()
          where Emp_Id = @pEmp_Id
          and   Suc_Id = @pSuc_Id
          and   Bod_Id = @Bod_Id
          and   Art_Id = @Art_Id
          if @@error<>0 begin
            raiserror ('Actualizando el costo del articulo', 16, 1)
          end          
          
        end


        fetch next from CurDetalle
        into @Art_Id, @Cantidad,@Costo
    end

    close CurDetalle
    deallocate CurDetalle
  
  end try
  begin catch
  
    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch
end

GO
/****** Object:  StoredProcedure [dbo].[AplicaOrdenCompra]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[AplicaOrdenCompra]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pOrden_Id int 
,@pUsuario_Id varchar(20))
as
begin
  --Aplica el la orden de compra y suma las cantidades al transito
  begin try
    declare  @Bod_Id            smallint
            ,@Art_Id            varchar(13)
            ,@Cantidad          float
            ,@Costo             money
            ,@SpResult          int
 
    --Marca el encabezado como aplicado
    update OrdenCompraEncabezado set  OrdenEstado_Id     = 2
                                     ,AplicaUsuario_Id   = @pUsuario_Id
                                     ,AplicaFecha        = getdate()
                                     ,UltimaModificacion = getdate()
    where Emp_Id     = @pEmp_Id
    and   Suc_Id     = @pSuc_Id
    and   Orden_Id   = @pOrden_Id
    if @@error<>0 begin
      raiserror ('Error Marcando como aplicado: OrdenCompraEncabezado', 16, 1)
    end
    
    --Busca la bodega en el encabezado para incrementar el transito
    select @Bod_Id = Bod_Id
    from  OrdenCompraEncabezado
    where Emp_Id     = @pEmp_Id
    and   Suc_Id     = @pSuc_Id
    and   Orden_Id   = @pOrden_Id
    if @@error<>0 or @@rowcount = 0begin
      raiserror ('Error buscando datos en el encabezado: OrdenCompraEncabezado', 16, 1)
    end  
    
    declare CurDetalle cursor for
    select Art_Id
          ,Cantidad
          ,Costo
    from  OrdenCompraDetalle
    where Emp_Id     = @pEmp_Id
    and   Suc_Id     = @pSuc_Id
    and   Orden_Id   = @pOrden_Id
    
    open CurDetalle
    
    fetch next from CurDetalle
    into @Art_Id, @Cantidad, @Costo
    
    while @@fetch_status = 0 begin
      update ArticuloBodega set  Transito = Transito + @Cantidad
                                ,UltimaModificacion = getdate()
      where Emp_Id = @pEmp_Id
      and   Suc_Id = @pSuc_Id
      and   Bod_Id = @Bod_Id
      and   Art_Id = @Art_Id
      if @@error<>0 begin
        raiserror ('Actualizando el transito del articulo', 16, 1)
      end          
          

      fetch next from CurDetalle
      into @Art_Id, @Cantidad, @Costo
    end

    close CurDetalle
    deallocate CurDetalle
  
  end try
  begin catch
  
    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch
end

GO
/****** Object:  StoredProcedure [dbo].[BusquedaFacturas]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[BusquedaFacturas]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pTipoBusqueda smallint
,@pCliente_Id int
,@pFecha  datetime
,@pNombre varchar(50) 
)
as
begin
  
  
  if @pTipoBusqueda = 0 begin --Cliente
    select a.Caja_Id 
          ,c.Nombre as NombreCaja
          ,a.TipoDoc_Id 
          ,d.Nombre as NombreTipoDoc
          ,a.Documento_Id
          ,a.Cliente_Id 
          ,b.Nombre as NombreCliente
          ,a.Fecha
          ,a.TotalCobrado 
    from  FacturaEncabezado a inner join Cliente b on a.Emp_Id = b.Emp_Id and a.Cliente_Id = b.Cliente_Id 
    inner join Caja c on a.Emp_Id = c.Emp_Id and a.Suc_Id = c.Suc_Id and a.Caja_Id = c.Caja_Id 
    inner join TipoDocumento d on a.Emp_Id = d.Emp_Id and a.TipoDoc_Id = d.TipoDoc_Id 
    where a.Emp_Id      = @pEmp_Id 
    and   a.Suc_Id      = @pSuc_Id
    and   a.Cliente_Id  = @pCliente_Id 
    order by fecha asc
  end
  
  if @pTipoBusqueda = 1 begin --Fecha
    select a.Caja_Id 
          ,c.Nombre as NombreCaja
          ,a.TipoDoc_Id 
          ,d.Nombre as NombreTipoDoc
          ,a.Documento_Id
          ,a.Cliente_Id 
          ,b.Nombre as NombreCliente
          ,a.Fecha
          ,a.TotalCobrado 
    from  FacturaEncabezado a inner join Cliente b on a.Emp_Id = b.Emp_Id and a.Cliente_Id = b.Cliente_Id 
    inner join Caja c on a.Emp_Id = c.Emp_Id and a.Suc_Id = c.Suc_Id and a.Caja_Id = c.Caja_Id 
    inner join TipoDocumento d on a.Emp_Id = d.Emp_Id and a.TipoDoc_Id = d.TipoDoc_Id 
    where a.Emp_Id      = @pEmp_Id 
    and   a.Suc_Id      = @pSuc_Id
    and   CONVERT (varchar(10),a.Fecha,111) = CONVERT (varchar(10),@pFecha,111)
    order by fecha asc
  end
  
    if @pTipoBusqueda = 2 begin --Nombre
    select a.Caja_Id 
          ,c.Nombre as NombreCaja
          ,a.TipoDoc_Id 
          ,d.Nombre as NombreTipoDoc
          ,a.Documento_Id
          ,a.Cliente_Id 
          ,b.Nombre as NombreCliente
          ,a.Fecha
          ,a.TotalCobrado 
    from  FacturaEncabezado a inner join Cliente b on a.Emp_Id = b.Emp_Id and a.Cliente_Id = b.Cliente_Id 
    inner join Caja c on a.Emp_Id = c.Emp_Id and a.Suc_Id = c.Suc_Id and a.Caja_Id = c.Caja_Id 
    inner join TipoDocumento d on a.Emp_Id = d.Emp_Id and a.TipoDoc_Id = d.TipoDoc_Id 
    where a.Emp_Id      = @pEmp_Id 
    and   a.Suc_Id      = @pSuc_Id
    and   a.Nombre like '%' + @pNombre + '%'
    order by fecha asc
  end
  
end

GO
/****** Object:  StoredProcedure [dbo].[CalculaPromedioVenta]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CalculaPromedioVenta]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint
,@pDias   smallint)
as
begin

  create table #Ventas(Art_Id           varchar(13) collate SQL_Latin1_General_CP1_CI_AS Not Null 
                      ,Cantidad         float       Not Null
                      ,Suelto           bit         Null
                      ,ArtPadre_Id      varchar(13) collate SQL_Latin1_General_CP1_CI_AS Null default 0
                      ,FactorConversion smallint    null default 1)
                      
  
  insert #Ventas
        (Art_Id 
        ,Cantidad)
  select b.Art_Id
        ,(sum(b.Cantidad)/@pDias )
  from  FacturaEncabezado a,
        FacturaDetalle b
  where a.Emp_Id = b.Emp_Id 
  and   a.Suc_Id = b.Suc_Id 
  and   a.Caja_Id = b.Caja_Id 
  and   a.TipoDoc_Id = b.TipoDoc_Id 
  and   a.Documento_Id = b.Documento_Id 

  and   a.Emp_Id        = @pEmp_Id 
  and   a.Suc_Id        = @pSuc_Id 
  and   a.Bod_Id        = @pBod_Id 
  and   a.Fecha >= DATEADD (day,-(@pDias),GETDATE ())
  group by b.Art_Id
  
  
  --Marca los articulos sueltos
  update #Ventas set #Ventas.ArtPadre_Id  = b.ArtPadre
                    ,#Ventas.Suelto       = 1
  from Articulo b
  where b.Emp_Id       = @pEmp_Id
  and   b.Suelto       = 1
  and   #Ventas.Art_Id = b.Art_Id 
  
  
  --Actualiza el factor de conversion
  update #Ventas set #Ventas.FactorConversion = b.FactorConversion 
  from Articulo b
  where b.Emp_Id            = @pEmp_Id
  and   #Ventas.ArtPadre_Id = b.Art_Id 
  
 
  --Le suma a la cantidad del padre la cantidad de sueltos
  update a set a.Cantidad = a.Cantidad + (b.Cantidad / b.FactorConversion)
  from  #Ventas a,
        #Ventas b
  where a.Art_Id = b.ArtPadre_Id 
    

  --Actualiza el promedio de venta  
  update a set a.PromedioVenta = b.Cantidad 
  from  ArticuloBodega a,
        #Ventas b
  where a.Art_Id = b.Art_Id 
  and   a.Emp_Id = @pEmp_Id
  and   a.Suc_Id = @pSuc_Id 
  and   a.Bod_Id = @pBod_Id 
  
  
end

GO
/****** Object:  StoredProcedure [dbo].[CierreCajaAbreCaja]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CierreCajaAbreCaja]
(@pEmp_Id smallint 
,@pSuc_Id smallint 
,@pCaja_Id smallint
,@pUsuario_Id varchar(20)
,@pFondo money)
as
begin
  begin try
    begin transaction
   
    declare  @Abierta bit
            ,@Cierre_Id int

    -- Busca el estado de la caja           
    select  @Abierta   = Abierta
           ,@Cierre_Id = (Cierre_Id + 1)
    from  Caja
    where Emp_Id  = @pEmp_Id
    and   Suc_Id  = @pSuc_Id
    and   Caja_Id = @pCaja_Id
    if @@error <> 0 or @@rowcount = 0 begin
        raiserror ('Error buscando la caja', 16, 1)  
    end
    
    if @Abierta <> 0 begin
        raiserror ('Imposible realizar la apertura de la caja, ya que esta ya se encuentra abierta', 16, 1)  
    end
    

    --Marca la caja como abierta
    update Caja
       set  Abierta            = 1
           ,Cierre_Id          = @Cierre_Id
           ,UltimaModificacion = getdate()
    where Emp_Id  = @pEmp_Id
    and   Suc_Id  = @pSuc_Id
    and   Caja_Id = @pCaja_Id
    if @@error <> 0 or @@rowcount = 0 begin
        raiserror ('Error marcando la caja como abierta caja', 16, 1)  
    end
    
    --Crea el encabezado del cierre de caja
    insert into CajaCierreEncabezado
               (Emp_Id
               ,Suc_Id
               ,Caja_Id
               ,Cierre_Id
               ,Usuario_Id
               ,Efectivo
               ,Tarjeta
               ,Cheque
               ,Puntos
               ,Total
               ,MontoSuma
               ,MontoResta
               ,Fondo
               ,Cerrado
               ,FechaApertura
               ,FechaCierre
               ,CajeroEfectivo
               ,CajeroTarjeta
               ,CajeroCheque
               ,CajeroTotal
               ,UltimaModificacion)
         VALUES
               (@pEmp_Id
               ,@pSuc_Id
               ,@pCaja_Id
               ,@Cierre_Id
               ,@pUsuario_Id
               ,0
               ,0
               ,0
               ,0
               ,0
               ,0
               ,0
               ,@pFondo
               ,0
               ,getdate()
               ,'19000101'
               ,0
               ,0
               ,0
               ,0
               ,getdate())
    if @@error <> 0 or @@rowcount = 0 begin
        raiserror ('Error insertando el encabezado del cierre', 16, 1)  
    end               
               
    
    
    
    commit transaction

  end try
  begin catch
  
    rollback transaction

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch  
end

GO
/****** Object:  StoredProcedure [dbo].[CierreCajaAcumulaMonto]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CierreCajaAcumulaMonto]
(@pEmp_Id smallint 
,@pSuc_Id smallint 
,@pCaja_Id smallint 
,@pTipoDoc_Id smallint 
,@pDocumento_Id bigint
,@pCierre_Id int
,@pMonto money)
as
begin
  begin try
  
    --Este procedimiento se encarga de acumular o restar un monto indicado y genera 
    --un movimiento en el detalle del cierre de caja
    --Jimmy Trejos Valverde 24/04/2012
  
  
    declare  @Detalle_Id  int
            ,@Abierta     bit
            ,@Sumar       bit

    -- Busca el estado de la caja           
    select  @Abierta = Abierta
    from  Caja
    where Emp_Id  = @pEmp_Id
    and   Suc_Id  = @pSuc_Id
    and   Caja_Id = @pCaja_Id
    if @@error <> 0 or @@rowcount = 0 begin
        raiserror ('Error buscando la caja', 16, 1)  
    end
    
    if @Abierta <> 1 begin
        raiserror ('Imposible acumular, primero debe de realizar la apertura de la caja', 16, 1)  
    end
    
    
    select @Sumar = case when @pMonto >= 0 then 1 else 0 end


--select @Sumar    

    -- Afecta el total del cierre
    update CajaCierreEncabezado set  Efectivo           = Efectivo   + @pMonto
                                    ,Total              = Total      + @pMonto
                                    ,MontoSuma          = MontoSuma  + case @Sumar when 1 then abs(@pMonto) else 0 end
                                    ,MontoResta         = MontoResta + case @Sumar when 0 then abs(@pMonto) else 0 end
                                    ,UltimaModificacion = getdate()
    where Emp_Id    = @pEmp_Id
    and   Suc_Id    = @pSuc_Id
    and   Caja_Id   = @pCaja_Id
    and   Cierre_Id = @pCierre_Id
    if @@rowcount = 0 begin
      raiserror ('No se encontró el encabezado del cierre', 16, 1)  
    end
    
    
    -- Busca el siguiente consecutivo de detalle
    select @Detalle_Id = isnull(max(Detalle_Id),0) + 1
    from  CajaCierreDetalle
    where Emp_Id    = @pEmp_Id
    and   Suc_Id    = @pSuc_Id
    and   Caja_Id   = @pCaja_Id
    and   Cierre_Id = @pCierre_Id           
    
    
    -- Inserta el detalle del pago
    insert into CajaCierreDetalle
         (Emp_Id
         ,Suc_Id
         ,Caja_Id
         ,Cierre_Id
         ,Detalle_Id
         ,TipoDoc_Id
         ,Documento_Id
         ,Pago_Id
         ,TipoPago_Id
         ,Monto
         ,Banco_Id
         ,ChequeNumero
         ,Tarjeta_Id
         ,TarjetaNumero
         ,TarjetaAutorizacion)
    values
         (@pEmp_Id
         ,@pSuc_Id
         ,@pCaja_Id
         ,@pCierre_Id
         ,@Detalle_Id
         ,@pTipoDoc_Id
         ,@pDocumento_Id
         ,1 --Siempre le pone el consecutivo #1
         ,1 --Siempre lo resta del efectivo
         ,@pMonto
         ,null
         ,''
         ,null
         ,''
         ,'')
    if @@error <> 0 begin
      raiserror ('Se presentó un error insertando el encabezado del cierre', 16, 1)  
    end
    
  end try
  begin catch

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch    
end

GO
/****** Object:  StoredProcedure [dbo].[CierreCajaAcumulaPago]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CierreCajaAcumulaPago]
(@pEmp_Id smallint 
,@pSuc_Id smallint 
,@pCaja_Id smallint 
,@pTipoDoc_Id smallint 
,@pDocumento_Id bigint
,@pCierre_Id int)
as
begin
  begin try
    --Este procedimiento se encarga de acumular los montos que son hechos 
    --por tipos de pagos asociados a alguna factura
    --Jimmy Trejos Valverde 24/04/2012
  
    declare @Pago_Id smallint
           ,@TipoPago_Id smallint
           ,@Monto money
           ,@Banco_Id smallint
           ,@ChequeNumero varchar(20)
           ,@Tarjeta_Id smallint
           ,@TarjetaNumero varchar(16)
           ,@TarjetaAutorizacion varchar(16)
           ,@Fecha datetime
           ,@Detalle_Id int
           ,@Abierta bit


    -- Busca el estado de la caja           
    select  @Abierta = Abierta
    from  Caja
    where Emp_Id  = @pEmp_Id
    and   Suc_Id  = @pSuc_Id
    and   Caja_Id = @pCaja_Id
    if @@error <> 0 or @@rowcount = 0 begin
        raiserror ('Error buscando la caja', 16, 1)  
    end
    
    if @Abierta <> 1 begin
        raiserror ('Imposible acumular, primero debe de realizar la apertura de la caja', 16, 1)  
    end

 
    --Busca los pagos asociados a un documento
    declare CurPago cursor for
    select Pago_Id
          ,TipoPago_Id 
          ,Monto 
          ,Banco_Id 
          ,ChequeNumero 
          ,Tarjeta_Id 
          ,TarjetaNumero 
          ,TarjetaAutorizacion 
          ,Fecha
    from FacturaPago 
    where Emp_Id        = @pEmp_Id
    and   Suc_Id        = @pSuc_Id
    and   Caja_Id       = @pCaja_Id
    and   TipoDoc_Id    = @pTipoDoc_Id
    and   Documento_Id  = @pDocumento_Id
    
    open CurPago
    
    fetch next from CurPago
    into   @Pago_Id  
          ,@TipoPago_Id
          ,@Monto
          ,@Banco_Id
          ,@ChequeNumero
          ,@Tarjeta_Id
          ,@TarjetaNumero
          ,@TarjetaAutorizacion
          ,@Fecha

    while @@fetch_status = 0
    begin
    
      -- Acumula los montos del encabezado      
      update CajaCierreEncabezado set  Efectivo  = Efectivo  + case @TipoPago_Id when 1 then @Monto else 0 end
                                      ,Tarjeta   = Tarjeta   + case @TipoPago_Id when 2 then @Monto else 0 end
                                      ,Cheque    = Cheque    + case @TipoPago_Id when 3 then @Monto else 0 end
                                      ,Puntos    = Puntos    + case @TipoPago_Id when 4 then @Monto else 0 end
                                      ,MontoSuma = MontoSuma + @Monto
                                      ,Total     = Total     + @Monto
                                      ,UltimaModificacion   = getdate()
      where Emp_Id    = @pEmp_Id
      and   Suc_Id    = @pSuc_Id
      and   Caja_Id   = @pCaja_Id
      and   Cierre_Id = @pCierre_Id
      if @@rowcount = 0 begin
        raiserror ('No se encontró el encabezado del cierre', 16, 1)  
      end

    
      -- Busca el siguiente consecutivo de detalle
      select @Detalle_Id = isnull(max(Detalle_Id),0) + 1
      from  CajaCierreDetalle
      where Emp_Id    = @pEmp_Id
      and   Suc_Id    = @pSuc_Id
      and   Caja_Id   = @pCaja_Id
      and   Cierre_Id = @pCierre_Id      
      
      
      -- Inserta el detalle del pago
      insert into CajaCierreDetalle
           (Emp_Id
           ,Suc_Id
           ,Caja_Id
           ,Cierre_Id
           ,Detalle_Id
           ,TipoDoc_Id
           ,Documento_Id
           ,Pago_Id
           ,TipoPago_Id
           ,Monto
           ,Banco_Id
           ,ChequeNumero
           ,Tarjeta_Id
           ,TarjetaNumero
           ,TarjetaAutorizacion)
      values
           (@pEmp_Id
           ,@pSuc_Id
           ,@pCaja_Id
           ,@pCierre_Id
           ,@Detalle_Id
           ,@pTipoDoc_Id
           ,@pDocumento_Id
           ,@Pago_Id
           ,@TipoPago_Id
           ,@Monto
           ,@Banco_Id
           ,@ChequeNumero
           ,@Tarjeta_Id
           ,@TarjetaNumero
           ,@TarjetaAutorizacion)
      if @@error <> 0 begin
        raiserror ('Se presentó un error insertando el detalle del cierre', 16, 1)  
      end
  
  
      fetch next from CurPago
      into   @Pago_Id  
            ,@TipoPago_Id
            ,@Monto
            ,@Banco_Id
            ,@ChequeNumero
            ,@Tarjeta_Id
            ,@TarjetaNumero
            ,@TarjetaAutorizacion
            ,@Fecha
    end
    
    close CurPago
    deallocate CurPago      
        
  end try
  begin catch

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch    
end

GO
/****** Object:  StoredProcedure [dbo].[CierreCajaCierraCaja]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CierreCajaCierraCaja]
(@pEmp_Id           smallint 
,@pSuc_Id           smallint 
,@pCaja_Id          smallint
,@pCajeroEfectivo   money
,@pCajeroTarjeta    money
,@pCajeroCheque     money
,@pCajeroDocumentos money)
as
begin
  begin try
    begin transaction
   
    declare  @Abierta bit
            ,@Cierre_Id int
            ,@Exento money
            ,@Gravado money
            
    -- Busca el estado de la caja           
    select  @Abierta   = Abierta
           ,@Cierre_Id = Cierre_Id
    from  Caja
    where Emp_Id  = @pEmp_Id
    and   Suc_Id  = @pSuc_Id
    and   Caja_Id = @pCaja_Id
    if @@error <> 0 or @@rowcount = 0 begin
        raiserror ('Error buscando la caja', 16, 1)  
    end
    
    if @Abierta <> 1 begin
        raiserror ('Imposible cerrar caja, ya que esta ya se encuentra cerrada', 16, 1)  
    end
    

    --Marca la caja como abierta
    update Caja
       set  Abierta            = 0
           ,UltimaModificacion = getdate()
    where Emp_Id  = @pEmp_Id
    and   Suc_Id  = @pSuc_Id
    and   Caja_Id = @pCaja_Id
    if @@error <> 0 or @@rowcount = 0 begin
        raiserror ('Error marcando la caja como cerrada', 16, 1)  
    end
    
    
    --Busca el total de ventas exentas y gravadas
    select @Exento  = isnull(sum(Exento ),0)
          ,@Gravado = isnull(sum(Gravado),0)
    from  FacturaEncabezado
    where Emp_Id    = @pEmp_Id
    and   Suc_Id    = @pSuc_Id 
    and   Caja_Id   = @pCaja_Id 
    and   Cierre_Id = @Cierre_Id 
    if @@error <> 0  begin
        raiserror ('Error buscando montos de exento y gravado', 16, 1)  
    end     
       
    
    
    --Crea el encabezado del cierre de caja
    update CajaCierreEncabezado
       set Cerrado            = 1
          ,FechaCierre        = getdate()
          ,CajeroEfectivo     = @pCajeroEfectivo
          ,CajeroTarjeta      = @pCajeroTarjeta
          ,CajeroCheque       = @pCajeroCheque
          ,CajeroDocumentos   = @pCajeroDocumentos
          ,CajeroTotal        = (@pCajeroEfectivo + @pCajeroTarjeta + @pCajeroCheque + @pCajeroDocumentos)
          ,Exento             = @Exento 
          ,Gravado            = @Gravado 
          ,UltimaModificacion = getdate()
    where Emp_Id    = @pEmp_Id
    and   Suc_Id    = @pSuc_Id
    and   Caja_Id   = @pCaja_Id
    and   Cierre_Id = @Cierre_Id          
    if @@error <> 0 or @@rowcount = 0 begin
        raiserror ('Error marcando el encabezado del cierre como cerrado', 16, 1)  
    end               
    
    
    commit transaction

  end try
  begin catch
  
    rollback transaction

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch  
end

GO
/****** Object:  StoredProcedure [dbo].[ComprometeInventarioArticulo]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ComprometeInventarioArticulo]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint
,@pArt_Id varchar(13)
,@pCantidad float
,@AumentaComprometido bit)
as
begin
  begin try
  
  declare @Servicio bit
  
  select  @Servicio = Servicio 
  from  Articulo 
  where Emp_Id = @pEmp_Id 
  and   Art_Id = @pArt_Id 
	if @@ERROR <> 0 or @@ROWCOUNT = 0 begin
	  raiserror ('Error buscando informacion del articulo', 16, 1)  
  end
  
  
  --Si es un codigo de servicio no compromete
  if @Servicio = 0 begin
  
    if @AumentaComprometido = 0 begin
      set @pCantidad = -(@pCantidad) 
    end
    
    update ArticuloBodega set Comprometido = Comprometido + @pCantidad
    where Emp_Id = @pEmp_Id 
    and   Suc_Id = @pSuc_Id 
    and   Bod_Id = @pBod_Id 
    and   Art_Id = @pArt_Id 
	  if @@ERROR <> 0 or @@ROWCOUNT = 0 begin
	    raiserror ('Error actualizando ArticuloBodega', 16, 1)  
    end
    
  end
  
  end try
  begin catch
  
    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch  
end

GO
/****** Object:  StoredProcedure [dbo].[ConsultaArticulo]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ConsultaArticulo]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint
,@pArt_Id varchar(13)
,@pCliente_Id as int)
as
begin
  begin try
    --Declaracion variables
    declare  @Art_Id varchar(13)
			,@Precio_Id smallint
    declare @Articulo table (	Art_Id varchar(13) NOT NULL,
	                            Nombre varchar(100) NOT NULL,
	                            FactorConversion smallint NOT NULL,
	                            ExentoIV bit NOT NULL,
	                            Suelto bit NULL,
	                            ArtPadre varchar(13) NOT NULL,
	                            Activo bit NOT NULL,
	                            Saldo float NOT NULL,
	                            Costo money NOT NULL,
	                            Margen float NOT NULL,
	                            Precio money NOT NULL,
	                            FechaIniDescuento datetime NOT NULL,
	                            FechaFinDescuento datetime NOT NULL,
	                            PorcDescuento float NOT NULL,
	                            Conjunto bit NOT NULL,
	                            SolicitarCantidad bit NOT NULL,
	                            PermiteFacturar bit NOT NULL,
	                            UnidadMedidaNombre varchar(50) NOT NULL,
	                            Servicio bit NOT NULL)

	--Busca el precio del cliente
	if @pCliente_Id > 0 begin
		select @Precio_Id = Precio_Id
		from	Cliente 
		where	Emp_Id		= @pEmp_Id 
		and		Cliente_Id	= @pCliente_Id 
		if @@rowcount = 0 or @@error <> 0 begin
		  raiserror ('Error buscando cliente, articulo: %s', 16, 1, @pArt_Id)  
		end
	end 
	else begin
		set @Precio_Id = 1
	end


    --Verifica si se trata de un codigo equivalente
    select @Art_Id = Art_Id
    from  ArticuloEquivalente
    where Emp_Id            = @pEmp_Id 
    and   ArtEquivalente_Id = @pArt_Id
    if @@error <> 0  begin
      raiserror ('Error buscando codigo equivalente, articulo: %s', 16, 1, @pArt_Id)  
    end
    
    if @Art_Id is null begin
      set @Art_Id = @pArt_Id
    end
   
    --Busca la informacion del articulo
    insert @Articulo
          (Art_Id
          ,Nombre
          ,FactorConversion
          ,ExentoIV
          ,Suelto
          ,ArtPadre
          ,Activo
          ,Saldo
          ,Costo
          ,Margen
          ,Precio
          ,FechaIniDescuento
          ,FechaFinDescuento
          ,PorcDescuento
          ,Conjunto
          ,SolicitarCantidad
          ,PermiteFacturar
          ,UnidadMedidaNombre
          ,Servicio)
    select a.Art_Id
          ,a.Nombre
          ,a.FactorConversion
          ,a.ExentoIV
          ,a.Suelto
          ,isnull(a.ArtPadre,'')
          ,a.Activo
          ,b.Saldo
          ,b.Costo
          ,case when @Precio_Id = 2	then b.MargenMayorista
									else b.Margen
								end as Margen
          ,case when @Precio_Id = 2	then b.PrecioMayorista
									else b.Precio 
								end as Precio
          ,b.FechaIniDescuento
          ,b.FechaFinDescuento
          ,b.PorcDescuento
          ,0
          ,a.SolicitarCantidad
          ,a.PermiteFacturar
          ,c.Nombre
          ,a.Servicio 
    from  Articulo a,
          ArticuloBodega b,
          UnidadMedida c
    where a.Emp_Id          = b.Emp_Id
    and   a.Art_Id          = b.Art_Id
    and   a.Emp_Id          = c.Emp_Id
    and   a.UnidadMedida_Id = c.UnidadMedida_Id
    and   b.Emp_Id          = @pEmp_Id
    and   b.Suc_Id          = @pSuc_Id
    and   b.Bod_Id          = @pBod_Id
    and   b.Art_Id          = @Art_Id
    if @@error <> 0  begin
      raiserror ('Error buscando, articulo: %s', 16, 1, @pArt_Id)  
    end
    
    -- Verifica si tiene algun articulo conjunto registrado
    update a set Conjunto = 1
    from  @Articulo a,
          ArticuloConjunto b
    where b.Emp_Id = @pEmp_Id
    and   b.Art_Id = @Art_Id
    and   a.Art_Id = b.Art_Id


    --Pone el descuento en cero para los articulos que no estan dentro del rango de fecha
    update @Articulo set PorcDescuento = 0
    where getdate() not between FechaIniDescuento and FechaFinDescuento
   
    
    select @pEmp_Id as Emp_Id
          ,@pSuc_Id as Suc_Id
          ,@pBod_Id as Bod_Id
          ,Art_Id
          ,Nombre
          ,FactorConversion
          ,ExentoIV
          ,Suelto
          ,ArtPadre
          ,Activo
          ,Saldo
          ,Costo
          ,Margen
          ,Precio
          ,FechaIniDescuento
          ,FechaFinDescuento
          ,PorcDescuento
          ,Conjunto
          ,SolicitarCantidad
          ,PermiteFacturar
          ,UnidadMedidaNombre
          ,Servicio 
    from  @Articulo
    
  end try
  begin catch

    rollback transaction

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch
end

GO
/****** Object:  StoredProcedure [dbo].[ConsultaArticuloCompra]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ConsultaArticuloCompra]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint
,@pArt_Id varchar(13))
as
begin
  begin try
    --Declaracion variables
    declare @Art_Id varchar(13)
    declare @Articulo table (	Art_Id varchar(13) NOT NULL,
	                            Nombre varchar(100) NOT NULL,
	                            FactorConversion smallint NOT NULL,
	                            ExentoIV bit NOT NULL,
	                            Suelto bit NULL,
	                            ArtPadre varchar(13) NOT NULL,
	                            Activo bit NOT NULL,
	                            Saldo float NOT NULL,
	                            Transito float NOT NULL,
	                            Costo money NOT NULL,
	                            Margen float NOT NULL,
	                            Precio money NOT NULL,
	                            UnidadMedidaNombre varchar(50) NOT NULL,
	                            FechaUltimaVenta datetime NOT NULL,
	                            PromedioVenta float NOT NULL,
	                            Minimo float NOT NULL,
	                            Maximo float NOT NULL,
	                            Servicio bit NOT NULL)
	                            

    --Verifica si se trata de un codigo equivalente
    select @Art_Id = Art_Id
    from  ArticuloEquivalente
    where Emp_Id            = @pEmp_Id 
    and   ArtEquivalente_Id = @pArt_Id
    if @@error <> 0  begin
      raiserror ('Error buscando codigo equivalente, articulo: %s', 16, 1, @pArt_Id)  
    end
    
    if @Art_Id is null begin
      set @Art_Id = @pArt_Id
    end
   
    --Busca la informacion del articulo
    insert @Articulo
          (Art_Id
          ,Nombre
          ,FactorConversion
          ,ExentoIV
          ,Suelto
          ,ArtPadre
          ,Activo
          ,Saldo
          ,Transito
          ,Costo
          ,Margen
          ,Precio
          ,UnidadMedidaNombre
          ,FechaUltimaVenta
          ,PromedioVenta
          ,Minimo
          ,Maximo
          ,Servicio)
    select a.Art_Id
          ,a.Nombre 
          ,a.FactorConversion
          ,a.ExentoIV
          ,a.Suelto
          ,isnull(a.ArtPadre,'') 
          ,a.Activo
          ,b.Saldo
          ,b.Transito
          ,b.Costo
          ,b.Margen
          ,b.Precio
          ,c.Nombre 
          ,b.FechaUltimaVenta
          ,b.PromedioVenta
          ,b.Minimo
          ,b.Maximo
          ,a.Servicio 
    from  Articulo a,
          ArticuloBodega b,
          UnidadMedida c
    where a.Emp_Id          = b.Emp_Id
    and   a.Art_Id          = b.Art_Id
    and   a.Emp_Id          = c.Emp_Id
    and   a.UnidadMedida_Id = c.UnidadMedida_Id
    and   b.Emp_Id          = @pEmp_Id
    and   b.Suc_Id          = @pSuc_Id
    and   b.Bod_Id          = @pBod_Id
    and   b.Art_Id          = @Art_Id
    if @@error <> 0  begin
      raiserror ('Error buscando, articulo: %s', 16, 1, @pArt_Id)  
    end
    
   
    
    select @pEmp_Id as Emp_Id
          ,@pSuc_Id as Suc_Id
          ,@pBod_Id as Bod_Id
          ,Art_Id
          ,Nombre as NombreArticulo
          ,FactorConversion
          ,ExentoIV
          ,Suelto
          ,isnull(ArtPadre,'') as ArtPadre
          ,Activo
          ,Saldo
          ,Transito
          ,Costo
          ,Margen
          ,Precio
          ,UnidadMedidaNombre as NombreUnidad
          ,FechaUltimaVenta
          ,PromedioVenta
          ,Minimo
          ,Maximo
          ,Servicio 
    from  @Articulo
    
  end try
  begin catch

    rollback transaction

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch
end

GO
/****** Object:  StoredProcedure [dbo].[ConsultaArticuloSinSaldo]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ConsultaArticuloSinSaldo]
(@pEmp_Id smallint
,@pArt_Id varchar(13))
as
begin
  begin try
    --Declaracion variables
    declare @Art_Id varchar(13)
	                            

    --Verifica si se trata de un codigo equivalente
    select @Art_Id = Art_Id
    from  ArticuloEquivalente
    where Emp_Id            = @pEmp_Id 
    and   ArtEquivalente_Id = @pArt_Id
    if @@error <> 0  begin
      raiserror ('Error buscando codigo equivalente, articulo: %s', 16, 1, @pArt_Id)  
    end
    
    if @Art_Id is null begin
      set @Art_Id = @pArt_Id
    end
   
    --Busca la informacion del articulo
    select a.Art_Id
          ,a.Nombre as NombreArticulo
          ,b.Nombre as CategoriaNombre
          ,c.Nombre as SubCategoriaNombre
          ,d.Nombre as DepartamentoNombre
          ,e.Nombre as UnidadMedidaNombre
          ,a.Suelto
          ,a.Activo
          ,a.ExentoIV
    from  Articulo a,
          Categoria b,
          SubCategoria c,  
          Departamento d,
          UnidadMedida e
    where a.Emp_Id    = b.Emp_Id
    and   a.Cat_Id    = b.Cat_Id
    and   a.Emp_Id    = c.Emp_Id
    and   a.Cat_Id    = c.Cat_Id
    and   a.SubCat_Id = c.SubCat_Id
    and   a.Emp_Id    = d.Emp_Id
    and   a.Departamento_Id = d.Departamento_Id
    and   a.Emp_Id = e.Emp_Id
    and   a.UnidadMedida_Id = e.UnidadMedida_Id
    and   a.Emp_Id = @pEmp_Id
    and   a.Art_Id = @Art_Id
    if @@error <> 0  begin
      raiserror ('Error buscando, articulo: %s', 16, 1, @pArt_Id)  
    end


  end try
  begin catch

    rollback transaction

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch
end

GO
/****** Object:  StoredProcedure [dbo].[ConsultaDetalleFactura]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ConsultaDetalleFactura]
(@pEmp_Id		smallint
,@pSuc_Id		smallint
,@pCaja_Id		smallint
,@pTipoDoc_Id	smallint
,@pDocumento_Id bigint)
as
begin

	create table #Detalles(
		Detalle_Id smallint NOT NULL,
		Art_Id varchar(13) NOT NULL,
		Cantidad float NOT NULL,
		Nombre varchar(100) NOT NULL,
		TotalLinea money NOT NULL,
		Observacion varchar(500) NOT NULL) 


	insert	#Detalles
	select	 a.Detalle_Id 
			,a.Art_Id 
			,a.Cantidad 
			,b.Nombre 
			,a.TotalLinea 
			,a.Observacion
	from	FacturaDetalle a,
			Articulo b 
	where	a.Emp_Id		= b.Emp_Id 
	and		a.Art_Id		= b.Art_Id 
	and		a.Emp_Id		= @pEmp_Id
	and		a.Suc_Id		= @pSuc_Id 
	and		a.Caja_Id		= @pCaja_Id
	and		a.TipoDoc_Id	= @pTipoDoc_Id 
	and		a.Documento_Id	= @pDocumento_Id 


	select *
	from	#Detalles 
	order by Detalle_Id asc

end

GO
/****** Object:  StoredProcedure [dbo].[ConsultaDetalleProforma]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ConsultaDetalleProforma]
(@pEmp_Id		smallint
,@pSuc_Id		smallint
,@pDocumento_Id bigint)
as
begin

	create table #Detalles(
		Detalle_Id smallint NOT NULL,
		Art_Id varchar(13) NOT NULL,
		Cantidad float NOT NULL,
		Nombre varchar(100) NOT NULL,
		TotalLinea money NOT NULL,
		Observacion varchar(500) NOT NULL) 


	insert	#Detalles
	select	 a.Detalle_Id 
			,a.Art_Id 
			,a.Cantidad 
			,b.Nombre 
			,a.TotalLinea 
			,a.Observacion
	from	ProformaDetalle a,
			Articulo b 
	where	a.Emp_Id		= b.Emp_Id 
	and		a.Art_Id		= b.Art_Id 
	and		a.Emp_Id		= @pEmp_Id
	and		a.Suc_Id		= @pSuc_Id 
	and		a.Documento_Id	= @pDocumento_Id 


	select *
	from	#Detalles 
	order by Detalle_Id asc

end

GO
/****** Object:  StoredProcedure [dbo].[ConsultaExistenciasArticulo]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ConsultaExistenciasArticulo]
(@pEmp_Id smallint
,@pArt_Id varchar(13))
as
begin
  begin try
  
    declare @PorcIV float
    
    
    select  @PorcIV = PorcIV 
    from  EmpresaParametro
    where Emp_Id = @pEmp_Id
    if @@rowcount = 0 or @@error <> 0  begin
      raiserror ('Error buscando porcentaje de impuesto de ventas: %s', 16, 1, @pArt_Id)  
    end    
    
  
    select c.Nombre as NombreSucursal
          ,d.Nombre as NombreBodega
          ,a.Saldo
          ,a.Comprometido 
          ,round(a.Precio,2) as Precio
          ,round(case b.ExentoIV when 1 then 0
                           else a.Precio * (@PorcIV/100)
           end,2) as MontoIV 
          ,round(case b.ExentoIV when 1 then a.Precio
                           else a.Precio * ((@PorcIV/100) + 1)
           end,2) as PrecioIVI
          ,b.Suelto
          ,b.FactorConversion
          ,a.Costo
          ,a.Transito
          ,a.Ubicacion
          
          
          ,round(a.PrecioMayorista,2) as PrecioMayorista
          ,round(case b.ExentoIV when 1 then 0
                           else a.PrecioMayorista * (@PorcIV/100)
           end,2) as MontoIVMayorista
          ,round(case b.ExentoIV when 1 then a.PrecioMayorista
                           else a.PrecioMayorista * ((@PorcIV/100) + 1)
           end,2) as PrecioMayoristaIVI
    from  ArticuloBodega a,
          Articulo b,
          Sucursal c,
          Bodega d
    where a.Emp_Id = b.Emp_Id
    and   a.Art_Id = b.Art_Id
    and   a.Emp_Id = c.Emp_Id
    and   a.Suc_Id = c.Suc_Id
    and   a.Emp_Id = d.Emp_Id
    and   a.Suc_Id = d.Suc_Id
    and   a.Bod_Id = d.Bod_Id
    and   a.Emp_Id = @pEmp_Id
    and   a.Art_Id = @pArt_Id

  end try
  begin catch

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch
end

GO
/****** Object:  StoredProcedure [dbo].[ConsultaMovimientosCliente]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ConsultaMovimientosCliente]
(@pEmp_Id smallint
,@pCliente_Id int)
as
begin

	--1-Factura
	--2-Proforma
	--3-Prefactura


	create table #Documentos(
		Emp_Id smallint NOT NULL,
		Suc_Id smallint NOT NULL,
		Caja_Id smallint NOT NULL,
		TipoDoc_Id smallint NOT NULL,
		Documento_Id bigint NOT NULL,
		SucNombre varchar(50) NOT NULL,
		TipoDocNombre varchar(50) NOT NULL,
		Documento varchar(15) NULL,
		Fecha datetime NOT NULL,
		TotalCobrado money NOT NULL,
		Comentario varchar(500) NOT NULL,
		Tipo smallint NOT NULL,
		Puntos int NOT NULL
	) 



	insert #Documentos 
	select	 a.Emp_Id
			,a.Suc_Id
			,a.Caja_Id 
			,a.TipoDoc_Id 
			,a.Documento_Id 
			,b.Nombre as SucNombre
			,c.Nombre as TipoDocNombre
			,cast(a.Caja_Id as varchar(4)) + '-' + cast(a.Documento_Id as varchar(10)) as Documento
			,a.Fecha 
			,a.TotalCobrado 
			,a.Comentario 
			,1
			,Puntos 
	from	FacturaEncabezado a, 
			Sucursal b,
			TipoDocumento c
	where	a.Emp_Id		= c.Emp_Id 
	and		a.TipoDoc_Id	= c.TipoDoc_Id 
	and		a.Emp_Id		= b.Emp_Id 
	and		a.Suc_Id		= b.Suc_Id 
	and		a.Emp_Id		= @pEmp_Id 
	and		a.Cliente_Id	= @pCliente_Id 


	insert #Documentos 
	select	 
			 a.Emp_Id
			,a.Suc_Id
			,0
			,0
			,a.Documento_Id 
			,b.Nombre as SucNombre
			,c.Nombre as TipoDocNombre
			,a.Documento_Id as Documento
			,a.Fecha 
			,a.TotalCobrado 
			,a.Comentario 
			,a.Tipo 
			,0
	from	ProformaEncabezado a, 
			Sucursal b,
			ProformaTipo c
	where	a.Emp_Id		= c.Emp_Id 
	and		a.Tipo			= c.Tipo  
	and		a.Emp_Id		= b.Emp_Id 
	and		a.Suc_Id		= b.Suc_Id 
	and		a.Emp_Id		= @pEmp_Id 
	and		a.Cliente_Id	= @pCliente_Id 


	select *
	from	#Documentos 
	order by Fecha desc, Documento desc
end

GO
/****** Object:  StoredProcedure [dbo].[CreaAjusteConteo]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CreaAjusteConteo]
as
begin
  begin try
  
    begin transaction

	  declare  @Emp_Id      smallint
	          ,@Suc_Id      smallint
			      ,@TipoMov_Id  smallint
			      ,@Mov_Id      int
			      ,@TotalCosto  money 
			      ,@Bod_Id      smallint
			      ,@Fecha       datetime
			      ,@Art_Id      varchar(13)
			      ,@Cantidad    float
			      ,@Costo       money
			      ,@Suelto      bit
			      ,@Detalle_Id  smallint
  	
	  --Valores Iniciales
	  set @Emp_Id = 1     --Empresa
	  set @Suc_Id = 1     --Sucursal
	  set @TipoMov_Id = 2 --Ajuste Suma
	  set @Mov_Id = 0     --Numero Movimiento
	  set @TotalCosto = 0 --Costo total en el encabezado
	  set @Bod_Id = 1
	  set @Fecha = GETDATE()
	  set @Art_Id = ''
	  set @Cantidad = 0
    set @Costo = 0
    set @Suelto = 0
    set @Detalle_Id = 0
    
    --Elimina los articulos que tengan cantidad 0
    delete ArticuloConteo 
    where Cantidad = 0
    			
	  --Busca el siguiente numero de movimiento
	  select @Mov_Id = ISNULL (max(Mov_Id),0)+1
	  from  MovimientoEncabezado 
	  where Emp_Id = @Emp_Id 
	  and   Suc_Id = @Suc_Id
	  and   TipoMov_Id = @TipoMov_Id 
    if @@error <> 0 begin
        raiserror ('Error buscando numero de ajuste', 16, 1)  
    end	  
  	
  	
	  --Calcula el costo total del ajuste
	  select @TotalCosto = SUM(isnull(a.Cantidad,0)*isnull(b.Costo,0)) 
	  from	ArticuloConteo a,
	        ArticuloBodega b
	  where	a.Emp_Id = b.Emp_Id 
	  and   a.Art_Id = b.Art_Id 
	  and   b.Emp_Id = @Emp_Id
	  and   b.Suc_Id = @Suc_Id 
	  and   b.Bod_Id = @Bod_Id 
	  and   Cantidad <> 0
    if @@error <> 0 or @@rowcount = 0 begin
        raiserror ('Error calculando total costo de ajuste', 16, 1)  
    end	  
	  
  	
	  --Inserta el encabezado del ajuste
	  INSERT INTO MovimientoEncabezado
             (Emp_Id
             ,Suc_Id
             ,TipoMov_Id
             ,Mov_Id
             ,Bod_Id
             ,Fecha
             ,Comentario
             ,Costo
             ,Aplicado
             ,Usuario_Id
             ,Suc_Id_Destino
             ,Bod_Id_Destino
             ,AplicaUsuario_Id
             ,AplicaFecha
             ,UltimaModificacion)
    select   @Emp_Id
            ,@Suc_Id
            ,@TipoMov_Id 
            ,@Mov_Id 
            ,@Bod_Id 
            ,@Fecha 
            ,'Ajuste Automático'
            ,@TotalCosto 
            ,0
            ,'jtrejos'
            ,null
            ,null
            ,null
            ,'19000101'
            ,@Fecha 
    if @@error <> 0  begin
        raiserror ('Error creando encabezado del ajuste', 16, 1)  
    end	              
            
    select @Art_Id = isnull(MIN(Art_Id),'')
    from  ArticuloConteo
    where Procesado = 0
    and   Art_Id > @Art_Id 
    
    while @Art_Id <> '' begin
    
      select @Cantidad = Cantidad 
      from  ArticuloConteo 
      where Emp_Id = @Emp_Id 
      and   Art_Id = @Art_Id 
      if @@error <> 0 or @@rowcount = 0 begin
          raiserror ('Error buscando registro en ArticuloConteo', 16, 1)  
      end	        
      
      select @Suelto = a.Suelto 
            ,@Costo  = b.Costo 
      from  Articulo a,
            ArticuloBodega b
      where a.Emp_Id = b.Emp_Id 
      and   a.Art_Id = b.Art_Id 
      and   b.Emp_Id = @Emp_Id 
      and   b.Suc_Id = @Suc_Id
      and   b.Bod_Id = @Bod_Id
      and   b.Art_Id = @Art_Id 
      if @@error <> 0 or @@rowcount = 0 begin
          raiserror ('Error buscando registro en ArticuloBodega', 16, 1)  
      end	       
      
      set @Detalle_Id = @Detalle_Id + 1
      
      INSERT INTO MovimientoDetalle
             (Emp_Id
             ,Suc_Id
             ,TipoMov_Id
             ,Mov_Id
             ,Detalle_Id
             ,Art_Id
             ,Cantidad
             ,Costo
             ,TotalLinea
             ,Suelto
             ,Fecha
             ,UltimaModificacion)
      select @Emp_Id 
            ,@Suc_Id
            ,@TipoMov_Id 
            ,@Mov_Id 
            ,@Detalle_Id 
            ,@Art_Id 
            ,@Cantidad 
            ,@Costo 
            ,@Cantidad*@Costo 
            ,@Suelto 
            ,@Fecha 
            ,@Fecha 
      if @@error <> 0 or @@rowcount = 0 begin
          raiserror ('Error creando detalle del ajuste', 16, 1)  
      end	             
      
      
      update ArticuloConteo set Procesado = 1
      where Emp_Id = @Emp_Id 
      and   Art_Id = @Art_Id 
    
    
      select @Art_Id = isnull(MIN(Art_Id),'')
      from  ArticuloConteo
      where Procesado = 0
      and   Art_Id > @Art_Id     
    end
    
    commit transaction

  end try
  begin catch
  
    rollback transaction

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch      

end

GO
/****** Object:  StoredProcedure [dbo].[CreaAjustesTomaFisica]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CreaAjustesTomaFisica]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint
,@pUsuario_Id varchar(20))
as
begin
  begin try
    begin transaction
      --Variables
      declare  @Mov_Id      int
              ,@Fecha       datetime
              ,@TipoMov_Id  smallint
              
      --Tablas Temporales
      CREATE TABLE #MovimientoDetalle(
	      Detalle_Id smallint NOT NULL identity(1,1),
	      Art_Id varchar(13) NOT NULL,
	      Cantidad float NOT NULL,
	      Costo money NOT NULL,
	      TotalLinea money NOT NULL,
	      Suelto bit NOT NULL,
	      Fecha datetime NOT NULL,
	      UltimaModificacion datetime NOT NULL)              
              
              
              
      select @Fecha = GETDATE ()
           

      --Actualiza Datos de Articulo
      update a set  a.Nombre = b.Nombre
                   ,a.Suelto = b.Suelto 
      from  TomaFisicaDiferencia a,
            Articulo b
      where a.Emp_Id = b.Emp_Id 
      and   a.Art_Id = b.Art_Id 
      if @@error <> 0 begin
          raiserror ('Error actualizando datos articulo', 16, 1)  
      end     
      
      --Actualiza Datos de ArticuloBodega      
       update a set  a.Costo      = b.Costo
                    ,a.Magnetico  = b.Saldo  
      from  TomaFisicaDiferencia a,
            ArticuloBodega b
      where a.Emp_Id = b.Emp_Id 
      and   a.Suc_Id = b.Suc_Id 
      and   a.Bod_Id = b.Bod_Id 
      and   a.Art_Id = b.Art_Id 
      and   b.Emp_Id = @pEmp_Id 
      and   b.Suc_Id = @pSuc_Id 
      and   b.Bod_Id = @pBod_Id
      if @@error <> 0 begin
          raiserror ('Error actualizando datos articulo bodega', 16, 1)  
      end    
      
      --Calcula la diferencia
      update TomaFisicaDiferencia set Diferencia = Fisico - Magnetico 
      if @@error <> 0 begin
          raiserror ('Error calculando diferencia', 16, 1)  
      end   
      
      -- Crea el ajuste de suma para cajas -----------------------------
      ------------------------------------------------------------------
      set @TipoMov_Id = 2 --Ajuste de suma
      
      select @Mov_Id = isnull(max(Mov_Id), 0) + 1 
      From MovimientoEncabezado
      Where Emp_Id      = @pEmp_Id 
      and   Suc_Id      = @pSuc_Id 
      and   TipoMov_Id  = @TipoMov_Id 
      
      
      --Crea el encabezado del documento
      insert MovimientoEncabezado
      (Emp_Id
      ,Suc_Id
      ,TipoMov_Id
      ,Mov_Id
      ,Bod_Id
      ,Fecha
      ,Comentario
      ,Costo
      ,Aplicado
      ,Usuario_Id
      ,Suc_Id_Destino
      ,Bod_Id_Destino
      ,AplicaUsuario_Id
      ,AplicaFecha
      ,UltimaModificacion)
     values
      (@pEmp_Id 
      ,@pSuc_Id 
      ,@TipoMov_Id
      ,@Mov_Id 
      ,@pBod_Id 
      ,@Fecha 
      ,'Ajuste suma-cajas generado automatico-inventario'
      ,0 --Costo
      ,0 --Aplicado
      ,@pUsuario_Id
      ,null
      ,null
      ,null       --AplicaUsuario_Id
      ,'19000101' --AplicaFecha
      ,@Fecha )
      if @@error <> 0 begin
          raiserror ('Error insertando encabezado', 16, 1)  
      end          
       
       
      --Limpia la tabla de detalle
      delete #MovimientoDetalle 
      
       
      insert #MovimientoDetalle
         (Art_Id
         ,Cantidad
         ,Costo
         ,TotalLinea
         ,Suelto
         ,Fecha
         ,UltimaModificacion)
      select Art_Id 
            ,abs(Diferencia)
            ,Costo
            ,Costo * abs(Diferencia)
            ,Suelto
            ,@Fecha 
            ,@Fecha 
      from  TomaFisicaDiferencia 
      where Emp_Id = @pEmp_Id 
      and   Suc_Id = @pSuc_Id
      and   Bod_Id = @pBod_Id 
      and   Suelto = 0
      and   Diferencia > 0
      if @@error <> 0 begin
          raiserror ('Error insertando detalle en tabla temporal', 16, 1)  
      end   
  
  
      insert MovimientoDetalle
           (Emp_Id
           ,Suc_Id
           ,TipoMov_Id
           ,Mov_Id
           ,Detalle_Id
           ,Art_Id
           ,Cantidad
           ,Costo
           ,TotalLinea
           ,Suelto
           ,Fecha
           ,UltimaModificacion)
      select @pEmp_Id 
            ,@pSuc_Id 
            ,@TipoMov_Id
            ,@Mov_Id 
            ,Detalle_Id 
            ,Art_Id
            ,Cantidad
            ,Costo
            ,TotalLinea
            ,Suelto
            ,Fecha
            ,UltimaModificacion            
      from  #MovimientoDetalle            
      if @@error <> 0 begin
          raiserror ('Error insertando detalle en tabla MovimientoDetalle', 16, 1)  
      end  
      
      
      
      -- Crea el ajuste de resta para cajas ----------------------------
      ------------------------------------------------------------------
      set @TipoMov_Id = 3 --Ajuste de resta
      
      select @Mov_Id = isnull(max(Mov_Id), 0) + 1 
      From MovimientoEncabezado
      Where Emp_Id      = @pEmp_Id 
      and   Suc_Id      = @pSuc_Id 
      and   TipoMov_Id  = @TipoMov_Id 
      
      
      --Crea el encabezado del documento
      insert MovimientoEncabezado
      (Emp_Id
      ,Suc_Id
      ,TipoMov_Id
      ,Mov_Id
      ,Bod_Id
      ,Fecha
      ,Comentario
      ,Costo
      ,Aplicado
      ,Usuario_Id
      ,Suc_Id_Destino
      ,Bod_Id_Destino
      ,AplicaUsuario_Id
      ,AplicaFecha
      ,UltimaModificacion)
     values
      (@pEmp_Id 
      ,@pSuc_Id 
      ,@TipoMov_Id
      ,@Mov_Id 
      ,@pBod_Id 
      ,@Fecha 
      ,'Ajuste resta-cajas generado automatico-inventario'
      ,0 --Costo
      ,0 --Aplicado
      ,@pUsuario_Id
      ,null
      ,null
      ,null       --AplicaUsuario_Id
      ,'19000101' --AplicaFecha
      ,@Fecha )
      if @@error <> 0 begin
          raiserror ('Error insertando encabezado', 16, 1)  
      end          
       
       
      --Limpia la tabla de detalle
      delete #MovimientoDetalle 
      
       
      insert #MovimientoDetalle
         (Art_Id
         ,Cantidad
         ,Costo
         ,TotalLinea
         ,Suelto
         ,Fecha
         ,UltimaModificacion)
      select Art_Id 
            ,abs(Diferencia)
            ,Costo
            ,Costo * abs(Diferencia)
            ,Suelto
            ,@Fecha 
            ,@Fecha 
      from  TomaFisicaDiferencia 
      where Emp_Id = @pEmp_Id 
      and   Suc_Id = @pSuc_Id
      and   Bod_Id = @pBod_Id 
      and   Suelto = 0
      and   Diferencia < 0
      if @@error <> 0 begin
          raiserror ('Error insertando detalle en tabla temporal', 16, 1)  
      end   
  
  
      insert MovimientoDetalle
           (Emp_Id
           ,Suc_Id
           ,TipoMov_Id
           ,Mov_Id
           ,Detalle_Id
           ,Art_Id
           ,Cantidad
           ,Costo
           ,TotalLinea
           ,Suelto
           ,Fecha
           ,UltimaModificacion)
      select @pEmp_Id 
            ,@pSuc_Id 
            ,@TipoMov_Id
            ,@Mov_Id 
            ,Detalle_Id 
            ,Art_Id
            ,Cantidad
            ,Costo
            ,TotalLinea
            ,Suelto
            ,Fecha
            ,UltimaModificacion            
      from  #MovimientoDetalle            
      if @@error <> 0 begin
          raiserror ('Error insertando detalle en tabla MovimientoDetalle', 16, 1)  
      end  


      -- Crea el ajuste de suma para sueltos ---------------------------
      ------------------------------------------------------------------
      set @TipoMov_Id = 2 --Ajuste de suma
      
      select @Mov_Id = isnull(max(Mov_Id), 0) + 1 
      From MovimientoEncabezado
      Where Emp_Id      = @pEmp_Id 
      and   Suc_Id      = @pSuc_Id 
      and   TipoMov_Id  = @TipoMov_Id 
      
      
      --Crea el encabezado del documento
      insert MovimientoEncabezado
      (Emp_Id
      ,Suc_Id
      ,TipoMov_Id
      ,Mov_Id
      ,Bod_Id
      ,Fecha
      ,Comentario
      ,Costo
      ,Aplicado
      ,Usuario_Id
      ,Suc_Id_Destino
      ,Bod_Id_Destino
      ,AplicaUsuario_Id
      ,AplicaFecha
      ,UltimaModificacion)
     values
      (@pEmp_Id 
      ,@pSuc_Id 
      ,@TipoMov_Id
      ,@Mov_Id 
      ,@pBod_Id 
      ,@Fecha 
      ,'Ajuste suma-sueltos generado automatico-inventario'
      ,0 --Costo
      ,0 --Aplicado
      ,@pUsuario_Id
      ,null
      ,null
      ,null       --AplicaUsuario_Id
      ,'19000101' --AplicaFecha
      ,@Fecha )
      if @@error <> 0 begin
          raiserror ('Error insertando encabezado', 16, 1)  
      end          
       
       
      --Limpia la tabla de detalle
      delete #MovimientoDetalle 
      
       
      insert #MovimientoDetalle
         (Art_Id
         ,Cantidad
         ,Costo
         ,TotalLinea
         ,Suelto
         ,Fecha
         ,UltimaModificacion)
      select Art_Id 
            ,abs(Diferencia)
            ,Costo
            ,Costo * abs(Diferencia)
            ,Suelto
            ,@Fecha 
            ,@Fecha 
      from  TomaFisicaDiferencia 
      where Emp_Id = @pEmp_Id 
      and   Suc_Id = @pSuc_Id
      and   Bod_Id = @pBod_Id 
      and   Suelto = 1
      and   Diferencia > 0
      if @@error <> 0 begin
          raiserror ('Error insertando detalle en tabla temporal', 16, 1)  
      end   
  
  
      insert MovimientoDetalle
           (Emp_Id
           ,Suc_Id
           ,TipoMov_Id
           ,Mov_Id
           ,Detalle_Id
           ,Art_Id
           ,Cantidad
           ,Costo
           ,TotalLinea
           ,Suelto
           ,Fecha
           ,UltimaModificacion)
      select @pEmp_Id 
            ,@pSuc_Id 
            ,@TipoMov_Id
            ,@Mov_Id 
            ,Detalle_Id 
            ,Art_Id
            ,Cantidad
            ,Costo
            ,TotalLinea
            ,Suelto
            ,Fecha
            ,UltimaModificacion            
      from  #MovimientoDetalle            
      if @@error <> 0 begin
          raiserror ('Error insertando detalle en tabla MovimientoDetalle', 16, 1)  
      end  
      
      
      
      -- Crea el ajuste de resta para sueltos --------------------------
      ------------------------------------------------------------------
      set @TipoMov_Id = 3 --Ajuste de resta
      
      select @Mov_Id = isnull(max(Mov_Id), 0) + 1 
      From MovimientoEncabezado
      Where Emp_Id      = @pEmp_Id 
      and   Suc_Id      = @pSuc_Id 
      and   TipoMov_Id  = @TipoMov_Id 
      
      
      --Crea el encabezado del documento
      insert MovimientoEncabezado
      (Emp_Id
      ,Suc_Id
      ,TipoMov_Id
      ,Mov_Id
      ,Bod_Id
      ,Fecha
      ,Comentario
      ,Costo
      ,Aplicado
      ,Usuario_Id
      ,Suc_Id_Destino
      ,Bod_Id_Destino
      ,AplicaUsuario_Id
      ,AplicaFecha
      ,UltimaModificacion)
     values
      (@pEmp_Id 
      ,@pSuc_Id 
      ,@TipoMov_Id
      ,@Mov_Id 
      ,@pBod_Id 
      ,@Fecha 
      ,'Ajuste resta-suetos generado automatico-inventario'
      ,0 --Costo
      ,0 --Aplicado
      ,@pUsuario_Id
      ,null
      ,null
      ,null       --AplicaUsuario_Id
      ,'19000101' --AplicaFecha
      ,@Fecha )
      if @@error <> 0 begin
          raiserror ('Error insertando encabezado', 16, 1)  
      end          
       
       
      --Limpia la tabla de detalle
      delete #MovimientoDetalle 
      
       
      insert #MovimientoDetalle
         (Art_Id
         ,Cantidad
         ,Costo
         ,TotalLinea
         ,Suelto
         ,Fecha
         ,UltimaModificacion)
      select Art_Id 
            ,abs(Diferencia)
            ,Costo
            ,Costo * abs(Diferencia)
            ,Suelto
            ,@Fecha 
            ,@Fecha 
      from  TomaFisicaDiferencia 
      where Emp_Id = @pEmp_Id 
      and   Suc_Id = @pSuc_Id
      and   Bod_Id = @pBod_Id 
      and   Suelto = 1
      and   Diferencia < 0
      if @@error <> 0 begin
          raiserror ('Error insertando detalle en tabla temporal', 16, 1)  
      end   
  
  
      insert MovimientoDetalle
           (Emp_Id
           ,Suc_Id
           ,TipoMov_Id
           ,Mov_Id
           ,Detalle_Id
           ,Art_Id
           ,Cantidad
           ,Costo
           ,TotalLinea
           ,Suelto
           ,Fecha
           ,UltimaModificacion)
      select @pEmp_Id 
            ,@pSuc_Id 
            ,@TipoMov_Id
            ,@Mov_Id 
            ,Detalle_Id 
            ,Art_Id
            ,Cantidad
            ,Costo
            ,TotalLinea
            ,Suelto
            ,Fecha
            ,UltimaModificacion            
      from  #MovimientoDetalle            
      if @@error <> 0 begin
          raiserror ('Error insertando detalle en tabla MovimientoDetalle', 16, 1)  
      end  
   
  
      commit transaction

  end try
  begin catch
  
    rollback transaction

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch  

-- La diferencia se calcula Fisico - Magnetico

-- Suma  Cajas  Tipo 2 y cantidad en positivo



-- Resta Cajas  Tipo 3 y cantidad en negativo
-- Suma  Sueltos tipo 2 y cantidad en positivo
-- Resta Cajas   tipo 3 y cantidad en negativo


end

GO
/****** Object:  StoredProcedure [dbo].[CreaArticuloSuelto]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CreaArticuloSuelto]
(@pEmp_Id smallint
,@pArtPadre_Id varchar(13)
,@pArtHijo_Id varchar(13)
,@pPrecio money
,@pBusquedaRapida bit
,@pFrecuencia bit)
as
begin
  begin try
  
    begin transaction
  
    declare  @FactorConversion smallint
            ,@ExentoIV  bit
            ,@PorcIV    float
            
            
    --Busca el porcentaje de impuesto de venta
    select @PorcIV = PorcIV
    from  EmpresaParametro 
    where Emp_Id = @pEmp_Id
    if @@ERROR <> 0 or @@ROWCOUNT = 0 begin
      raiserror ('No se pudo obtener el porcentaje de impuesto de venta para la empresa', 16, 1)
    end
    
  
    --Verifica si el articulo ya es padre de algun suelto
    if exists(select *
              from  Articulo 
              where Emp_Id   = @pEmp_Id 
              and   ArtPadre = @pArtPadre_Id) 
    begin
      raiserror ('Imposible asociarle un articulo suelto al código %s, debido a que este ya tiene asociado uno', 16, 1, @pArtPadre_Id)
    end
    
    
    --Verifica si el articulo suelto ya existe como codigo de algun articulo
    if exists(select *
              from  Articulo 
              where Emp_Id  = @pEmp_Id 
              and   Art_Id  = @pArtHijo_Id) 
    begin
      raiserror ('Ya existe un articulo con el código %s, elija otro codigo de suelto', 16, 1, @pArtPadre_Id)
    end


    select @FactorConversion = FactorConversion
          ,@ExentoIV = ExentoIV
    from  Articulo 
    where Emp_Id = @pEmp_Id
    and   Art_Id = @pArtPadre_Id
    if @@ROWCOUNT = 0 or @@ERROR <> 0 begin
      raiserror ('Error buscando código %s', 16, 1, @pArtPadre_Id)
    end
    
    
    if @FactorConversion <= 1 begin
      raiserror ('Debe de definir el factor de conversion para el articulo %s', 16, 1, @pArtPadre_Id)
    end
    
    if @ExentoIV = 0 begin
      set @pPrecio = (@pPrecio / (1 + (@PorcIV/100)))
    end
    

    insert Articulo 
          (Emp_Id
          ,Art_Id
          ,Nombre
          ,Cat_Id
          ,SubCat_Id
          ,Departamento_Id
          ,UnidadMedida_Id
          ,FactorConversion
          ,ExentoIV
          ,Suelto
          ,ArtPadre
          ,SolicitarCantidad
          ,PermiteFacturar
          ,CodigoCantidad
          ,CodigoCantidadTipo
          ,BusquedaRapida
          ,Frecuente
          ,Activo
          ,UltimaModificacion)
    select Emp_Id
          ,@pArtHijo_Id 
          ,ltrim(rtrim(substring(Nombre,1,43))) + ' SUELTO' 
          ,Cat_Id
          ,SubCat_Id
          ,Departamento_Id
          ,UnidadMedida_Id
          ,1 --FactorConversion, para los sueltos siempre es 1
          ,ExentoIV
          ,1 --Suelto
          ,@pArtPadre_Id 
          ,SolicitarCantidad
          ,PermiteFacturar
          ,CodigoCantidad
          ,CodigoCantidadTipo
          ,@pBusquedaRapida
          ,@pFrecuencia
          ,1 --Activo
          ,GETDATE()
    from  Articulo 
    where Emp_Id = @pEmp_Id 
    and   Art_Id = @pArtPadre_Id
    if @@ERROR <> 0 begin
      raiserror ('Error Insertando el articulo %s, debido a que este ya tiene asociado uno', 16, 1, @pArtHijo_Id)
    end
    
    
    insert ArticuloBodega 
          (Emp_Id
          ,Suc_Id
          ,Bod_Id
          ,Art_Id
          ,Saldo
          ,Transito
          ,CostoPromedio
          ,Costo
          ,Margen
          ,Precio
          ,FechaIniDescuento
          ,FechaFinDescuento
          ,PorcDescuento
          ,FechaUltimaVenta
          ,PromedioVenta
          ,Minimo
          ,Maximo
          ,Activo
          ,UltimaModificacion)
    select Emp_Id
          ,Suc_Id
          ,Bod_Id
          ,@pArtHijo_Id  
          ,0    --Saldo
          ,0    --Transito
          ,0    --CostoPromedio
          ,0    --Costo
          ,100  --Margen
          ,@pPrecio 
          ,'19000101' --FechaIniDescuento
          ,'19000101' --FechaFinDescuento
          ,0          --PorcDescuento
          ,'19000101' --FechaUltimaVenta
          ,0          --PromedioVenta
          ,0          --Minimo
          ,0          --Maximo
          ,1          --Activo
          ,GETDATE()
    from ArticuloBodega
    where Emp_Id = @pEmp_Id 
    and   Art_Id = @pArtPadre_Id 
    if @@ERROR <> 0 begin
      raiserror ('Error Insertando el articulo %s en bodegas, debido a que este ya tiene asociado uno', 16, 1, @pArtHijo_Id)
    end
    
    
    commit transaction
    
  end try
  begin catch
  
    rollback transaction
  
    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch    
end

GO
/****** Object:  StoredProcedure [dbo].[CrearAjusteCosto]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CrearAjusteCosto]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint
,@pArt_Id varchar(13)
,@pCostoNuevo money
,@pUsuario_Id varchar(20))
as
begin
  begin try
  
    begin transaction

    declare  @Ajuste_Id       int
            ,@CostoAnterior   money
            ,@PrecioAnterior  money
            ,@MargenNuevo     float
            
            
    if @pCostoNuevo<0 begin
      raiserror ('Error, el costo debe de ser mayor o igual a cero', 16, 1)
    end                
    
    --Busca el siguiente numero de ajuste
    select  @Ajuste_Id = ISNULL(MAX(Ajuste_Id),0)+1
    from  AjusteCosto
    where Emp_Id = @pEmp_Id
    and   Suc_Id = @pSuc_Id
    if @@ERROR<>0 begin
      raiserror ('Error buscando el consecutivo del ajuste', 16, 1)
    end    
    
    --Busca el costo anterior
    select   @CostoAnterior  = Costo
            ,@PrecioAnterior = Precio 
    from  ArticuloBodega 
    where Emp_Id = @pEmp_Id 
    and   Suc_Id = @pSuc_Id 
    and   Bod_Id = @pBod_Id 
    and   Art_Id = @pArt_Id
    if @@ERROR<>0 or @@ROWCOUNT = 0 begin
      raiserror ('Error buscando el costo anterior', 16, 1)
    end    
    
    --Recalcula el margen de utilidad asumiendo que el costo siempre va a ser mayor o igual a cero
    if @pCostoNuevo>0 begin
      set @MargenNuevo = ((@PrecioAnterior-@pCostoNuevo)*100)/@pCostoNuevo
    end
    else begin
      set @MargenNuevo = 100
    end
    
    
    --Cambia el costo en la tabla de articulo x bodega
    update ArticuloBodega set  Costo              = @pCostoNuevo
                              ,Margen             = @MargenNuevo
                              ,UltimaModificacion = GETDATE()
    where Emp_Id = @pEmp_Id 
    and   Suc_Id = @pSuc_Id 
    and   Bod_Id = @pBod_Id 
    and   Art_Id = @pArt_Id
    if @@ERROR<>0 or @@ROWCOUNT = 0 begin
      raiserror ('Error actualizando el nuevo costo', 16, 1)
    end    
    
    insert AjusteCosto
             (Emp_Id
             ,Suc_Id
             ,Ajuste_Id
             ,Bod_Id
             ,Art_Id
             ,CostoAnterior
             ,CostoNuevo
             ,Fecha
             ,Usuario_Id)
    values  (@pEmp_Id 
            ,@pSuc_Id 
            ,@Ajuste_Id 
            ,@pBod_Id 
            ,@pArt_Id
            ,@CostoAnterior
            ,@pCostoNuevo
            ,GETDATE()
            ,@pUsuario_Id)
    if @@ERROR<>0 or @@ROWCOUNT = 0 begin
      raiserror ('Error guardando el ajuste de costo', 16, 1)
    end              
            
    commit transaction
     
  end try
  begin catch
  
    rollback transaction
  
    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch
end

GO
/****** Object:  StoredProcedure [dbo].[CreaSugeridoCompra]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CreaSugeridoCompra]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint
,@pProv_Id smallint
,@pDias smallint)
as
begin

  begin try
    begin transaction

      declare @Articulo 
      table ( Art_Id varchar(13) collate SQL_Latin1_General_CP1_CI_AS  NOT NULL,
              Cantidad float NOT NULL,
              Nombre varchar(100) collate SQL_Latin1_General_CP1_CI_AS  NOT NULL,
              Costo money NOT NULL,
              Minimo float NOT NULL,
              Maximo float NOT NULL,
              FactorConversion smallint NOT NULL,
              PromedioVenta float NOT NULL,
              ExentoIV bit NOT NULL,
              Suelto bit NULL)




      insert @Articulo 
            (Art_Id
            ,Cantidad
            ,Nombre
            ,Costo
            ,Minimo
            ,Maximo
            ,FactorConversion
            ,PromedioVenta
            ,ExentoIV
            ,Suelto)
      select a.Art_Id
            ,ceiling((a.PromedioVenta * @pDias) - a.Saldo)
            ,b.Nombre 
            ,a.Costo 
            ,a.Minimo
            ,a.Maximo 
            ,b.FactorConversion 
            ,a.PromedioVenta 
            ,b.ExentoIV 
            ,b.Suelto 
      from  ArticuloBodega a,
            Articulo b,
            ArticuloProveedor c 
      where a.Emp_Id  = b.Emp_Id
      and   a.Art_Id  = b.Art_Id
      and   b.Emp_Id  = c.Emp_Id
      and   b.Art_Id  = c.Art_Id
      and   a.Emp_Id  = @pEmp_Id
      and   a.Suc_Id  = @pSuc_Id
      and   a.Bod_Id  = @pBod_Id
      and   c.Prov_Id = @pProv_Id
      and   b.Suelto  = 0
      if @@error <> 0 begin
          raiserror ('Error buscando artículos', 16, 1)  
      end      
      
      
      --Verifica el minimo
      update @Articulo set Cantidad = Minimo 
      where Cantidad < Minimo 
      and   Minimo > 0
      

      --Verifica el maximo
      update @Articulo set Cantidad = Maximo  
      where Cantidad > Maximo 
      and   Maximo > 0
      
       

      delete @Articulo where Cantidad < 1


      
      select *
      from  @Articulo
      order by Nombre 
      
      
    commit transaction

  end try
  begin catch
  
    rollback transaction

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch        

end

GO
/****** Object:  StoredProcedure [dbo].[CxC_AplicaMovimiento]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CxC_AplicaMovimiento]
(@pEmp_Id           smallint
,@pTipoMov_Id       smallint
,@pAplicaTipoMov_Id smallint
,@pAplicaMov_Id     int
,@pCliente_Id       int
,@pFecha            datetime
,@pMonto            money
,@pReferencia       varchar(400)
,@pUsuario_Id       varchar(20))
as
begin
  --Crea un documento en cxc y se lo aplica a otro documento
  begin try
  
    --Declaracion de variables
    declare  @Mov_Id            bigint
            ,@NombreTipo        varchar(50)
            ,@IncrementaSaldo   bit
            ,@NombreTipoAplica  varchar(50)
            ,@Fecha             datetime
            ,@SaldoActual       money
            
            
    select @Fecha       = GETDATE()
          ,@SaldoActual = 0
        
    if @pMonto=0 begin
      raiserror ('Error, el monto no puede ser cero', 16, 1)
    end

    --Busca los valores del tipo de movimiento cxc
    select   @NombreTipo      = Nombre 
            ,@IncrementaSaldo = IncrementaSaldo 
    from  CxCMovimientoTipo 
    where Emp_Id      = @pEmp_Id 
    and   TipoMov_Id  = @pTipoMov_Id
    if @@ERROR<>0 or @@ROWCOUNT = 0 begin
      raiserror ('Error buscando el tipo de movimiento', 16, 1)
    end

    --Verifica que el tipo de documento sea de resta  
    set @pMonto = ABS (@pMonto)  
    if @IncrementaSaldo = 0 begin
      set @pMonto = -(@pMonto)
    end
        
    --Busca los valores del tipo de movimiento al que se aplica
    select   @NombreTipoAplica  = Nombre 
    from  CxCMovimientoTipo 
    where Emp_Id      = @pEmp_Id 
    and   TipoMov_Id  = @pAplicaTipoMov_Id 
    if @@ERROR<>0 or @@ROWCOUNT = 0 begin
      raiserror ('Error buscando el tipo de movimiento', 16, 1)
    end
        
    --Busca el consecutivo del movimiento
    select @Mov_Id = ISNULL( MAX (Mov_Id), 0) + 1
    from  CxCMovimiento 
    where Emp_Id      = @pEmp_Id 
    and   TipoMov_Id  = @pTipoMov_Id 
    if @@ERROR<>0 begin
      raiserror ('Error buscando el consecutivo del movimiento', 16, 1)
    end     

    --Inserta la factura para el cliente
    insert into CxCMovimiento
               (Emp_Id
               ,TipoMov_Id
               ,Mov_Id
               ,Cliente_Id
               ,Referencia
               ,Fecha
               ,FechaMovimiento
               ,Vencimiento
               ,Monto
               ,Saldo
               ,Activo
               ,Usuario_Id
               ,AplicaMora
               ,FechaCalculoMora
               ,Intereses
               ,Dolares
               ,TipoCambio
               ,UltimaModificacion)
         VALUES
               (@pEmp_Id
               ,@pTipoMov_Id
               ,@Mov_Id
               ,@pCliente_Id
               --,'Aplicado a ' + @NombreTipoAplica  + ' # ' + cast(@pAplicaMov_Id  as varchar(10)) + ' ' + @pReferencia 
               ,@pReferencia 
               ,@Fecha 
               ,@pFecha
               ,@pFecha
               ,@pMonto 
               ,case @IncrementaSaldo when 1 then @pMonto else 0 end
               ,1
               ,@pUsuario_Id
               ,0       -- AplicaMora
               ,@pFecha -- FechaCalculoMora
               ,0       -- Intereses
               ,0       -- Indicador si es dolares
               ,1       -- Tipo de Cambio
               ,GETDATE ())
    if @@ERROR<>0 begin
      raiserror ('Error insertando en CxCmovimiento', 16, 1)
    end
    
    --Inserta la relacion entre el documento creado y el aplicado
    insert into CxCMovimientoAplica
               (Emp_Id
               ,TipoMov_Id
               ,Mov_Id
               ,Aplica_Id
               ,AplicaTipoMov_Id
               ,AplicaMov_Id
               ,Fecha
               ,Monto)
       values (@pEmp_Id 
              ,@pTipoMov_Id 
              ,@Mov_Id 
              ,1
              ,@pAplicaTipoMov_Id 
              ,@pAplicaMov_Id 
              ,@Fecha 
              ,@pMonto)
     
     
    if @@ERROR<>0 begin
      raiserror ('Error insertando en CxCMovimientoFactura', 16, 1)
    end
    
    
    --Vefifica que el monto sea menor o igual al saldo
    select  @SaldoActual = Saldo
    from  CxCMovimiento 
    where   Emp_Id      = @pEmp_Id 
    and     TipoMov_Id  = @pAplicaTipoMov_Id 
    and     Mov_Id      = @pAplicaMov_Id 
    if @@ROWCOUNT=0 begin
      raiserror ('Error buscando el saldo actual del documento', 16, 1)
    end    
    if @SaldoActual<abs(@pMonto) begin
      raiserror ('Error, el monto a aplicar debe de ser menor o igual al saldo', 16, 1)
    end
    
    
    --Actualiza el saldo del documento
    update CxCMovimiento set Saldo = Saldo + @pMonto , UltimaModificacion = GETDATE()
    where   Emp_Id = @pEmp_Id 
    and     TipoMov_Id = @pAplicaTipoMov_Id 
    and     Mov_Id     = @pAplicaMov_Id 
    if @@ERROR<>0 begin
      raiserror ('Error actualizando el saldo del documento', 16, 1)
    end    
    
    
    --Actualiza el saldo del cliente
    update Cliente set Saldo = Saldo + @pMonto, UltimaModificacion = GETDATE ()
    where Emp_Id      = @pEmp_Id 
    and   Cliente_Id  = @pCliente_Id 
    if @@ERROR<>0 begin
      raiserror ('Error actualizando el saldo del cliente', 16, 1)
    end
    
    
    --Retorna el numero de movimiento que se creo
    select @Mov_Id as Mov_Id
    
    
  end try
  begin catch

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch
    
end

GO
/****** Object:  StoredProcedure [dbo].[CxC_ArticulosFactura]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CxC_ArticulosFactura]
(@pEmp_Id smallint
,@pTipoMov_Id smallint
,@pMov_Id int)
as 
begin

  select b.Detalle_Id 
        ,b.Art_Id 
        ,c.Nombre 
        ,b.Cantidad 
        ,b.Cantidad * b.TotalLinea as Total
  from  CxCMovimientoFactura a,
        FacturaDetalle  b,
        Articulo c
  where a.Emp_Id        = b.Emp_Id 
  and   a.Suc_Id        = b.Suc_Id 
  and   a.Caja_Id       = b.Caja_Id 
  and   a.TipoDoc_Id    = b.TipoDoc_Id 
  and   a.Documento_Id  = b.Documento_Id
  and   b.Emp_Id        = c.Emp_Id 
  and   b.Art_Id        = c.Art_Id 
  and   a.Emp_Id        = @pEmp_Id 
  and   a.TipoMov_Id    = @pTipoMov_Id 
  and   a.Mov_Id        = @pMov_Id 
  order by
        b.Detalle_Id asc
     
end

GO
/****** Object:  StoredProcedure [dbo].[CxC_BuscaDocumentosMoraCliente]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CxC_BuscaDocumentosMoraCliente]
(@pEmp_Id smallint
,@pCliente_Id int
,@pFecha datetime)
as
begin

  --Declaracion de variables
  declare @DiasGraciaMora    smallint
          
  select @DiasGraciaMora  = DiasGraciaMora 
  from  Cliente 
  where Emp_Id     = @pEmp_Id 
  and   Cliente_Id = @pCliente_Id 
  if @@ERROR <> 0 or @@ROWCOUNT = 0 begin
    raiserror ('Error buscando datos del cliente', 16, 1)
  end      

  select TipoMov_Id
        ,Mov_Id 
        ,DATEDIFF (day, FechaCalculoMora, @pFecha) as DiasMora
        ,Saldo 
  from  CxCMovimiento 
  where Emp_Id      = @pEmp_Id 
  and   Cliente_Id  = @pCliente_Id 
  and   TipoMov_Id in (1,4)
  and   Activo      = 1
  and   AplicaMora  = 1
  and   Intereses   = 0
  and   Saldo       > 0
  and   Vencimiento < @pFecha
  and   DATEADD (day, @DiasGraciaMora, FechaCalculoMora) < @pFecha  
  if @@ERROR<>0 begin
    raiserror ('Error buscando movimientos pendientes de calculo de mora', 16, 1)
  end      

end

GO
/****** Object:  StoredProcedure [dbo].[CxC_CalculaMoraCliente]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CxC_CalculaMoraCliente]
(@pEmp_Id smallint
,@pCliente_Id int
,@pFecha datetime
,@pUsuario_Id varchar(20))
as
begin
  begin try

    --Declaracion de variables
    declare  @AplicaTipoMov_Id  smallint
            ,@AplicaMov_Id      bigint
            ,@DiasMora          smallint
            ,@Saldo             money
            ,@DiasGraciaMora    smallint
            ,@PorcMora          float
            ,@MontoMora         money
            ,@MontoMoraTotal    money
            ,@TipoMov_Id        smallint
            ,@Mov_Id            bigint
            ,@Aplica_Id         smallint
            
    --Crea tablas temporales
    create table #MovimientosAplica(TipoMov_Id smallint NOT NULL, Mov_Id bigint NOT NULL, 
                                    Monto money NOT NULL, Dias smallint NOT NULL)
              

    --Inicializa variables          
    select @TipoMov_Id     = 4 --Nota Debito
          ,@MontoMora      = 0
          ,@MontoMoraTotal = 0
          ,@Aplica_Id      = 0
    
    select @DiasGraciaMora  = DiasGraciaMora 
          ,@PorcMora        = PorcMora 
    from  Cliente 
    where Emp_Id     = @pEmp_Id 
    and   Cliente_Id = @pCliente_Id 
    if @@ERROR <> 0 or @@ROWCOUNT = 0 begin
      raiserror ('Error buscando datos del cliente', 16, 1)
    end      

    declare CurMovimientos cursor for
    select TipoMov_Id
          ,Mov_Id 
          ,DATEDIFF (day, FechaCalculoMora, @pFecha) as DiasMora
          ,Saldo 
    from  CxCMovimiento 
    where Emp_Id      = @pEmp_Id 
    and   Cliente_Id  = @pCliente_Id 
    and   TipoMov_Id in (1,4)
    and   Activo      = 1
    and   AplicaMora  = 1
    and   Intereses   = 0
    and   Saldo       > 0
    and   Vencimiento < @pFecha
    and   DATEADD (day, @DiasGraciaMora, FechaCalculoMora) < @pFecha  
    if @@ERROR<>0 begin
      raiserror ('Error buscando movimientos pendientes de calculo de mora', 16, 1)
    end      

    open CurMovimientos
      
    fetch next from CurMovimientos 
    into @AplicaTipoMov_Id, @AplicaMov_Id, @DiasMora, @Saldo
    
    while @@FETCH_STATUS = 0
    begin
    
      --Calcula el monto correspondiente a la mora
      set @MontoMora = ((@Saldo / 30) * (@PorcMora / 100)) * @DiasMora
      
      set @MontoMoraTotal = @MontoMoraTotal + floor(@MontoMora)
      
      
      insert #MovimientosAplica(TipoMov_Id, Mov_Id, Monto, Dias)
      values (@AplicaTipoMov_Id, @AplicaMov_Id, floor(@MontoMora), @DiasMora)
      if @@ERROR<>0 begin
        raiserror ('Error insertando en #MovimientosAplica', 16, 1)
      end        
    
      fetch next from CurMovimientos 
      into @AplicaTipoMov_Id, @AplicaMov_Id, @DiasMora, @Saldo    
    end
    
    close CurMovimientos
    deallocate CurMovimientos
    
    
    if @MontoMoraTotal > 0 begin --Si existe mora
    
      --Busca el consecutivo del movimiento
      select @Mov_Id = ISNULL( MAX (Mov_Id), 0) + 1
      from  CxCMovimiento 
      where Emp_Id      = @pEmp_Id 
      and   TipoMov_Id  = @TipoMov_Id 
      if @@ERROR<>0 begin
        raiserror ('Error buscando el consecutivo del movimiento', 16, 1)
      end  
      
      --Crea la nota de debito correpondiente a la mora
      insert into CxCMovimiento
               (Emp_Id
               ,TipoMov_Id
               ,Mov_Id
               ,Cliente_Id
               ,Referencia
               ,Fecha
               ,FechaMovimiento
               ,Vencimiento
               ,Monto
               ,Saldo
               ,Activo
               ,Usuario_Id
               ,AplicaMora
               ,FechaCalculoMora
               ,Intereses
               ,UltimaModificacion)
         values
               (@pEmp_Id 
               ,@TipoMov_Id 
               ,@Mov_Id 
               ,@pCliente_Id 
               ,'INTERESES MORA AL ' + CONVERT (varchar(10),@pFecha ,103)
               ,GETDATE()
               ,@pFecha
               ,@pFecha
               ,@MontoMoraTotal
               ,@MontoMoraTotal
               ,1
               ,@pUsuario_Id
               ,0
               ,@pFecha 
               ,1
               ,GETDATE ())
      if @@ERROR<>0 begin
        raiserror ('Error insertando la nota de intereses en CxCMovimiento', 16, 1)
      end               
      
      --Crea el detalle de movimientos a los que se le cargo mora         
      while exists(select * from #MovimientosAplica) begin
        set rowcount 1
        select @AplicaTipoMov_Id = TipoMov_Id
              ,@AplicaMov_Id     = Mov_Id
              ,@MontoMora        = Monto
              ,@DiasMora         = Dias 
        from  #MovimientosAplica 
        set rowcount 0
        
        set @Aplica_Id = @Aplica_Id + 1
        
        --Crea la relacion entre la nota y los documentos que afecto
        insert into CxCMovimientoMora
                   (Emp_Id
                   ,TipoMov_Id
                   ,Mov_Id
                   ,Aplica_Id
                   ,AplicaTipoMov_Id
                   ,AplicaMov_Id
                   ,Fecha
                   ,Monto
                   ,Dias)
             values
                   (@pEmp_Id 
                   ,@TipoMov_Id 
                   ,@Mov_Id 
                   ,@Aplica_Id
                   ,@AplicaTipoMov_Id
                   ,@AplicaMov_Id
                   ,GETDATE ()
                   ,@MontoMora
                   ,@DiasMora)
        if @@ERROR<>0 begin
          raiserror ('Error insertando el movimiento en CxCMovimientoMora', 16, 1)
        end
        
        --Actualiza la fecha de ultimo calculo de la mora para el documento
        update CxCMovimiento set FechaCalculoMora   = @pFecha 
                                ,UltimaModificacion = GETDATE ()
        where Emp_Id      = @pEmp_Id
        and   TipoMov_Id  = @AplicaTipoMov_Id
        and   Mov_Id      = @AplicaMov_Id
        if @@ERROR<>0 begin
          raiserror ('Error actualizando FechaCalculoMora en CxCMovimiento', 16, 1)
        end      
        
        delete #MovimientosAplica 
        where TipoMov_Id = @AplicaTipoMov_Id
        and   Mov_Id     = @AplicaMov_Id
      end
      
      --Actualiza el saldo del cliente
      update Cliente set Saldo = Saldo + @MontoMoraTotal , UltimaModificacion = GETDATE ()
      where Emp_Id      = @pEmp_Id 
      and   Cliente_Id  = @pCliente_Id 
      if @@ERROR<>0 begin
        raiserror ('Error actualizando el saldo del cliente', 16, 1)
      end
    end
  
  end try
  begin catch

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch  

end

GO
/****** Object:  StoredProcedure [dbo].[CXC_CierreAcumulaPago]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CXC_CierreAcumulaPago]
(@pEmp_Id smallint 
,@pSuc_Id smallint 
,@pCaja_Id smallint 
,@pCierre_Id int
,@pTipoMov_Id smallint
,@pMov_Id bigint)
as
begin
  begin try
    --Este procedimiento se encarga de acumular los montos que son hechos 
    --por tipos de pagos asociados a alguna factura
    --Jimmy Trejos Valverde 24/04/2012
  
    declare @Pago_Id smallint
           ,@TipoPago_Id smallint
           ,@Monto money
           ,@Banco_Id smallint
           ,@ChequeNumero varchar(20)
           ,@Tarjeta_Id smallint
           ,@TarjetaNumero varchar(16)
           ,@TarjetaAutorizacion varchar(16)
           ,@Fecha datetime
           ,@Detalle_Id int
           ,@Abierta bit


    -- Busca el estado de la caja           
    select  @Abierta = Abierta
    from  Caja
    where Emp_Id  = @pEmp_Id
    and   Suc_Id  = @pSuc_Id
    and   Caja_Id = @pCaja_Id
    if @@error <> 0 or @@rowcount = 0 begin
        raiserror ('Error buscando la caja', 16, 1)  
    end
    
    if @Abierta <> 1 begin
        raiserror ('Imposible acumular, primero debe de realizar la apertura de la caja', 16, 1)  
    end

 
    --Busca los pagos asociados a un documento
    declare CurPago cursor for
    select Pago_Id
          ,TipoPago_Id 
          ,Monto 
          ,Banco_Id 
          ,ChequeNumero 
          ,Tarjeta_Id 
          ,TarjetaNumero 
          ,TarjetaAutorizacion 
          ,Fecha
    from CxCMovimientoPago 
    where Emp_Id        = @pEmp_Id
    and   TipoMov_Id    = @pTipoMov_Id 
    and   Mov_Id        = @pMov_Id 
    
    open CurPago
    
    fetch next from CurPago
    into   @Pago_Id  
          ,@TipoPago_Id
          ,@Monto
          ,@Banco_Id
          ,@ChequeNumero
          ,@Tarjeta_Id
          ,@TarjetaNumero
          ,@TarjetaAutorizacion
          ,@Fecha

    while @@fetch_status = 0
    begin
    
      -- Acumula los montos del encabezado      
      update CajaCierreEncabezado set  Efectivo  = Efectivo  + case @TipoPago_Id when 1 then @Monto else 0 end
                                      ,Tarjeta   = Tarjeta   + case @TipoPago_Id when 2 then @Monto else 0 end
                                      ,Cheque    = Cheque    + case @TipoPago_Id when 3 then @Monto else 0 end
                                      ,MontoSuma = MontoSuma + @Monto
                                      ,Total     = Total     + @Monto
                                      ,UltimaModificacion   = getdate()
      where Emp_Id    = @pEmp_Id
      and   Suc_Id    = @pSuc_Id
      and   Caja_Id   = @pCaja_Id
      and   Cierre_Id = @pCierre_Id
      if @@rowcount = 0 begin
        raiserror ('No se encontró el encabezado del cierre', 16, 1)  
      end

    
      -- Busca el siguiente consecutivo de detalle
      select @Detalle_Id = isnull(max(Detalle_Id),0) + 1
      from  CajaCierreDetalle
      where Emp_Id    = @pEmp_Id
      and   Suc_Id    = @pSuc_Id
      and   Caja_Id   = @pCaja_Id
      and   Cierre_Id = @pCierre_Id      
      
      
      -- Inserta el detalle del pago
      insert into CajaCierreDetalle
           (Emp_Id
           ,Suc_Id
           ,Caja_Id
           ,Cierre_Id
           ,Detalle_Id
           ,TipoDoc_Id
           ,Documento_Id
           ,Pago_Id
           ,TipoPago_Id
           ,Monto
           ,Banco_Id
           ,ChequeNumero
           ,Tarjeta_Id
           ,TarjetaNumero
           ,TarjetaAutorizacion
           ,CxC)
      values
           (@pEmp_Id
           ,@pSuc_Id
           ,@pCaja_Id
           ,@pCierre_Id
           ,@Detalle_Id
           ,@pTipoMov_Id 
           ,@pMov_Id 
           ,@Pago_Id
           ,@TipoPago_Id
           ,@Monto
           ,@Banco_Id
           ,@ChequeNumero
           ,@Tarjeta_Id
           ,@TarjetaNumero
           ,@TarjetaAutorizacion
           ,1)
      if @@error <> 0 begin
        raiserror ('Se presentó un error insertando el detalle del cierre', 16, 1)  
      end
  
  
      fetch next from CurPago
      into   @Pago_Id  
            ,@TipoPago_Id
            ,@Monto
            ,@Banco_Id
            ,@ChequeNumero
            ,@Tarjeta_Id
            ,@TarjetaNumero
            ,@TarjetaAutorizacion
            ,@Fecha
    end
    
    close CurPago
    deallocate CurPago      
        
  end try
  begin catch

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch    
end

GO
/****** Object:  StoredProcedure [dbo].[CxC_CreaMovimiento]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CxC_CreaMovimiento]
(@pEmp_Id           smallint
,@pTipoMov_Id       smallint
,@pCliente_Id       int
,@pFecha            datetime
,@pMonto            money
,@pReferencia       varchar(400)
,@pUsuario_Id       varchar(20))
as
begin
  --Agrega un documento que unicamente afecta el saldo del cliente
  --Pero este documento no esta ligado a ningu otro
  begin try
  
    begin transaction
  
    --Declaracion de variables
    declare  @Mov_Id            bigint
            ,@NombreTipo        varchar(50)
            ,@IncrementaSaldo   bit
            ,@Fecha             datetime
            ,@AplicaMora        bit
            ,@DiasCredito       smallint
            
    select @AplicaMora  = AplicaMora
          ,@DiasCredito = DiasCredito 
    from  Cliente
    where Emp_Id      = @pEmp_Id 
    and   Cliente_Id  = @pCliente_Id     
    if @@ERROR<>0 or @@ROWCOUNT = 0 begin
      raiserror ('Error buscando el datos del cliente', 16, 1)
    end             
            
            
    select @Fecha       = GETDATE()

        
    if @pMonto<=0 begin
      raiserror ('Error, el monto debe de ser mayor a cero', 16, 1)
    end

    --Busca los valores del tipo de movimiento cxc
    select   @NombreTipo      = Nombre 
            ,@IncrementaSaldo = IncrementaSaldo 
    from  CxCMovimientoTipo 
    where Emp_Id      = @pEmp_Id 
    and   TipoMov_Id  = @pTipoMov_Id
    if @@ERROR<>0 or @@ROWCOUNT = 0 begin
      raiserror ('Error buscando el tipo de movimiento', 16, 1)
    end

    --Verifica que el tipo de documento sea de resta  
    set @pMonto = ABS (@pMonto)  
    if @IncrementaSaldo = 0 begin
      set @pMonto = -(@pMonto)
    end
        
    --Busca el consecutivo del movimiento
    select @Mov_Id = ISNULL( MAX (Mov_Id), 0) + 1
    from  CxCMovimiento 
    where Emp_Id      = @pEmp_Id 
    and   TipoMov_Id  = @pTipoMov_Id 
    if @@ERROR<>0 begin
      raiserror ('Error buscando el consecutivo del movimiento', 16, 1)
    end     

    --Inserta la factura para el cliente
    insert into CxCMovimiento
               (Emp_Id
               ,TipoMov_Id
               ,Mov_Id
               ,Cliente_Id
               ,Referencia
               ,Fecha
               ,FechaMovimiento
               ,Vencimiento
               ,Monto
               ,Saldo
               ,Activo
               ,Usuario_Id
               ,AplicaMora
               ,FechaCalculoMora
               ,Intereses
               ,UltimaModificacion)
         VALUES
               (@pEmp_Id
               ,@pTipoMov_Id
               ,@Mov_Id
               ,@pCliente_Id
               ,@pReferencia 
               ,@Fecha 
               ,@pFecha
               ,DATEADD (day,@DiasCredito,@pFecha)
               ,@pMonto 
               ,case @IncrementaSaldo when 1 then @pMonto else 0 end
               ,1
               ,@pUsuario_Id 
               ,@AplicaMora
               ,DATEADD (day,@DiasCredito,@pFecha)
               ,0
               ,GETDATE ())
    if @@ERROR<>0 begin
      raiserror ('Error insertando en CxCmovimiento', 16, 1)
    end
   
    
    --Actualiza el saldo del cliente
    update Cliente set Saldo = Saldo + @pMonto, UltimaModificacion = GETDATE ()
    where Emp_Id      = @pEmp_Id 
    and   Cliente_Id  = @pCliente_Id 
    if @@ERROR<>0 begin
      raiserror ('Error actualizando el saldo del cliente', 16, 1)
    end
    
    --Retorna el numero de movimiento que se creo
    select @Mov_Id as Mov_Id
    
    commit transaction
                  
  end try
  begin catch
  
    rollback transaction
 
    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch
    
end

GO
/****** Object:  StoredProcedure [dbo].[CxC_DistribuyeDevolucionCredito]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CxC_DistribuyeDevolucionCredito]
(@pEmp_Id     smallint
,@pCliente_Id int
,@pTotalPago  money
,@pUsuario_Id varchar(20)
,@pReferencia varchar(400))
as
Begin
  begin try
    --Crea tablas temporales
    create table #MovimientosAplica(TipoMov_Id smallint NOT NULL, Mov_Id bigint NOT NULL, Monto money NOT NULL)
  
  
    --Declaracion de variables
    declare @AplicaTipoMov_Id   smallint
           ,@AplicaMov_Id       bigint
           ,@Saldo              money
           ,@Pago               money
           ,@TotalPagado        money
           ,@TipoMov_Id         smallint
           ,@Mov_Id             bigint
           ,@Fecha              datetime
           ,@Aplica_Id          smallint
           ,@SaldoCliente       money

    --Inicializa variables           
    select @TotalPagado  = 0   
          ,@TipoMov_Id   = 2 --Nota Credito 
          ,@Mov_Id       = 0
          ,@Fecha        = cast(GETDATE() as DATE)
          ,@Aplica_Id    = 0
          
          
    select @SaldoCliente = Saldo 
    from  Cliente 
    where Emp_Id     = @pEmp_Id 
    and   Cliente_Id = @pCliente_Id
    if @@ERROR<>0 or @@ROWCOUNT = 0 begin
      raiserror ('Error buscando datos del cliente', 16, 1)
    end       
    
    
    if @pTotalPago>@SaldoCliente begin
      raiserror ('Error, el monto del pago no puede ser mayor al saldo del cliente', 16, 1)
    end       
    
                  

    --Busca Facturas de credito y notas de debito
    declare CurMovimientos cursor for
    select TipoMov_Id
          ,Mov_Id
          ,Saldo 
    from  CxCMovimiento 
    where Emp_Id      = @pEmp_Id 
    and   Cliente_Id  = @pCliente_Id 
    and   TipoMov_Id  in (1,4) 
    and   Activo      = 1
    and   Saldo       > 0
    order by 
       Intereses desc
      ,Vencimiento asc
      ,Saldo asc
      
    open CurMovimientos
    
    fetch next from CurMovimientos
    into @AplicaTipoMov_Id, @AplicaMov_Id, @Saldo
    
    --select @pTotalPago
    
    while @@FETCH_STATUS = 0 begin
    
      if @pTotalPago <=0 break
    
      if @pTotalPago >= @Saldo begin
        set @Pago = @Saldo
        set @pTotalPago = @pTotalPago - @Saldo
      end
      else begin
        set @Pago       = @pTotalPago 
        set @pTotalPago = 0
      end
      
      set @TotalPagado = @TotalPagado + @Pago 
      
      
      insert #MovimientosAplica(TipoMov_Id, Mov_Id, Monto)
      values (@AplicaTipoMov_Id, @AplicaMov_Id, @Pago)
      if @@ERROR<>0 begin
        raiserror ('Error insertando en #MovimientosAplica', 16, 1)
      end   
    
      --select @AplicaTipoMov_Id, @AplicaMov_Id, @Saldo as Saldo, @Pago as Pago, @pTotalPago as TotalPago
    
      fetch next from CurMovimientos
      into @AplicaTipoMov_Id, @AplicaMov_Id, @Saldo
    end
    
    close CurMovimientos
    deallocate CurMovimientos
    
    if @TotalPagado>0 begin
    
      --Busca el consecutivo del movimiento
      select @Mov_Id = ISNULL( MAX (Mov_Id), 0) + 1
      from  CxCMovimiento 
      where Emp_Id      = @pEmp_Id 
      and   TipoMov_Id  = @TipoMov_Id 
      if @@ERROR<>0 begin
        raiserror ('Error buscando el consecutivo del movimiento', 16, 1)
      end  
      
      --Crea la nota de debito correpondiente a la mora
      insert into CxCMovimiento
               (Emp_Id
               ,TipoMov_Id
               ,Mov_Id
               ,Cliente_Id
               ,Referencia
               ,Fecha
               ,FechaMovimiento
               ,Vencimiento
               ,Monto
               ,Saldo
               ,Activo
               ,Usuario_Id
               ,AplicaMora
               ,FechaCalculoMora
               ,Intereses
               ,UltimaModificacion)
         values
               (@pEmp_Id 
               ,@TipoMov_Id 
               ,@Mov_Id 
               ,@pCliente_Id 
               ,@pReferencia
               ,GETDATE()
               ,@Fecha
               ,@Fecha
               ,-(@TotalPagado)
               ,0
               ,1
               ,@pUsuario_Id
               ,0
               ,@Fecha 
               ,0
               ,GETDATE ())
      if @@ERROR<>0 begin
        raiserror ('Error insertando la nota de intereses en CxCMovimiento', 16, 1)
      end               
      


      --Crea el detalle de movimientos a los que se le cargo mora         
      while exists(select * from #MovimientosAplica) begin
        set rowcount 1
        select @AplicaTipoMov_Id = TipoMov_Id
              ,@AplicaMov_Id     = Mov_Id
              ,@Pago             = Monto
        from  #MovimientosAplica 
        set rowcount 0
        
        set @Aplica_Id = @Aplica_Id + 1
        
        --Crea la relacion entre la nota y los documentos que afecto
        insert into CxCMovimientoAplica 
                   (Emp_Id
                   ,TipoMov_Id
                   ,Mov_Id
                   ,Aplica_Id
                   ,AplicaTipoMov_Id
                   ,AplicaMov_Id
                   ,Fecha
                   ,Monto)
             values
                   (@pEmp_Id 
                   ,@TipoMov_Id 
                   ,@Mov_Id 
                   ,@Aplica_Id
                   ,@AplicaTipoMov_Id
                   ,@AplicaMov_Id
                   ,GETDATE ()
                   ,-(@Pago))
        if @@ERROR<>0 begin
          raiserror ('Error insertando el movimiento en CxCMovimientoMora', 16, 1)
        end
        
        --Actualiza el saldo del documento
        update CxCMovimiento set Saldo = Saldo - @Pago  , UltimaModificacion = GETDATE()
        where   Emp_Id = @pEmp_Id 
        and     TipoMov_Id = @AplicaTipoMov_Id 
        and     Mov_Id     = @AplicaMov_Id 
        if @@ERROR<>0 begin
          raiserror ('Error actualizando el saldo del documento', 16, 1)
        end   
          
        
        delete #MovimientosAplica 
        where TipoMov_Id = @AplicaTipoMov_Id
        and   Mov_Id     = @AplicaMov_Id
      end
      
      --Actualiza el saldo del cliente
      update Cliente set Saldo = Saldo - @TotalPagado , UltimaModificacion = GETDATE ()
      where Emp_Id      = @pEmp_Id 
      and   Cliente_Id  = @pCliente_Id 
      if @@ERROR<>0 begin
        raiserror ('Error actualizando el saldo del cliente', 16, 1)
      end
    end
    else begin
      raiserror ('Error, No se genero ningun documento', 16, 1)
    end
    
    select @Mov_Id as Mov_Id

  end try
  begin catch

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch 

end

GO
/****** Object:  StoredProcedure [dbo].[CxC_DistribuyePago]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CxC_DistribuyePago]
(@pEmp_Id     smallint
,@pCliente_Id int
,@pTotalPago  money
,@pUsuario_Id varchar(20)
,@pReferencia varchar(400))
as
Begin
  begin try
    --Crea tablas temporales
    create table #MovimientosAplica(TipoMov_Id smallint NOT NULL, Mov_Id bigint NOT NULL, Monto money NOT NULL)
  
  
    --Declaracion de variables
    declare @AplicaTipoMov_Id   smallint
           ,@AplicaMov_Id       bigint
           ,@Saldo              money
           ,@Pago               money
           ,@TotalPagado        money
           ,@TipoMov_Id         smallint
           ,@Mov_Id             bigint
           ,@Fecha              datetime
           ,@Aplica_Id          smallint
           ,@SaldoCliente       money

    --Inicializa variables           
    select @TotalPagado  = 0   
          ,@TipoMov_Id   = 3 --Recibo Dinero 
          ,@Mov_Id       = 0
          ,@Fecha        = cast(GETDATE() as DATE)
          ,@Aplica_Id    = 0
          
          
    select @SaldoCliente = Saldo 
    from  Cliente 
    where Emp_Id     = @pEmp_Id 
    and   Cliente_Id = @pCliente_Id
    if @@ERROR<>0 or @@ROWCOUNT = 0 begin
      raiserror ('Error buscando datos del cliente', 16, 1)
    end       
    
    
    if @pTotalPago>@SaldoCliente begin
      raiserror ('Error, el monto del pago no puede ser mayor al saldo del cliente', 16, 1)
    end       
    
                  

    --Busca Facturas de credito y notas de debito
    declare CurMovimientos cursor for
    select TipoMov_Id
          ,Mov_Id
          ,Saldo 
    from  CxCMovimiento 
    where Emp_Id      = @pEmp_Id 
    and   Cliente_Id  = @pCliente_Id 
    and   TipoMov_Id  in (1,4) 
    and   Activo      = 1
    and   Saldo       > 0
    order by 
       Intereses desc
      ,Vencimiento asc
      ,Saldo asc
      
    open CurMovimientos
    
    fetch next from CurMovimientos
    into @AplicaTipoMov_Id, @AplicaMov_Id, @Saldo
    
    --select @pTotalPago
    
    while @@FETCH_STATUS = 0 begin
    
      if @pTotalPago <=0 break
    
      if @pTotalPago >= @Saldo begin
        set @Pago = @Saldo
        set @pTotalPago = @pTotalPago - @Saldo
      end
      else begin
        set @Pago       = @pTotalPago 
        set @pTotalPago = 0
      end
      
      set @TotalPagado = @TotalPagado + @Pago 
      
      
      insert #MovimientosAplica(TipoMov_Id, Mov_Id, Monto)
      values (@AplicaTipoMov_Id, @AplicaMov_Id, @Pago)
      if @@ERROR<>0 begin
        raiserror ('Error insertando en #MovimientosAplica', 16, 1)
      end   
    
      --select @AplicaTipoMov_Id, @AplicaMov_Id, @Saldo as Saldo, @Pago as Pago, @pTotalPago as TotalPago
    
      fetch next from CurMovimientos
      into @AplicaTipoMov_Id, @AplicaMov_Id, @Saldo
    end
    
    close CurMovimientos
    deallocate CurMovimientos
    
    if @TotalPagado>0 begin
    
      --Busca el consecutivo del movimiento
      select @Mov_Id = ISNULL( MAX (Mov_Id), 0) + 1
      from  CxCMovimiento 
      where Emp_Id      = @pEmp_Id 
      and   TipoMov_Id  = @TipoMov_Id 
      if @@ERROR<>0 begin
        raiserror ('Error buscando el consecutivo del movimiento', 16, 1)
      end  
      
      --Crea la nota de debito correpondiente a la mora
      insert into CxCMovimiento
               (Emp_Id
               ,TipoMov_Id
               ,Mov_Id
               ,Cliente_Id
               ,Referencia
               ,Fecha
               ,FechaMovimiento
               ,Vencimiento
               ,Monto
               ,Saldo
               ,Activo
               ,Usuario_Id
               ,AplicaMora
               ,FechaCalculoMora
               ,Intereses
               ,UltimaModificacion)
         values
               (@pEmp_Id 
               ,@TipoMov_Id 
               ,@Mov_Id 
               ,@pCliente_Id 
               ,@pReferencia
               ,GETDATE()
               ,@Fecha
               ,@Fecha
               ,-(@TotalPagado)
               ,0
               ,1
               ,@pUsuario_Id
               ,0
               ,@Fecha 
               ,0
               ,GETDATE ())
      if @@ERROR<>0 begin
        raiserror ('Error insertando la nota de intereses en CxCMovimiento', 16, 1)
      end               
      


      --Crea el detalle de movimientos a los que se le cargo mora         
      while exists(select * from #MovimientosAplica) begin
        set rowcount 1
        select @AplicaTipoMov_Id = TipoMov_Id
              ,@AplicaMov_Id     = Mov_Id
              ,@Pago             = Monto
        from  #MovimientosAplica 
        set rowcount 0
        
        set @Aplica_Id = @Aplica_Id + 1
        
        --Crea la relacion entre la nota y los documentos que afecto
        insert into CxCMovimientoAplica 
                   (Emp_Id
                   ,TipoMov_Id
                   ,Mov_Id
                   ,Aplica_Id
                   ,AplicaTipoMov_Id
                   ,AplicaMov_Id
                   ,Fecha
                   ,Monto)
             values
                   (@pEmp_Id 
                   ,@TipoMov_Id 
                   ,@Mov_Id 
                   ,@Aplica_Id
                   ,@AplicaTipoMov_Id
                   ,@AplicaMov_Id
                   ,GETDATE ()
                   ,-(@Pago))
        if @@ERROR<>0 begin
          raiserror ('Error insertando el movimiento en CxCMovimientoMora', 16, 1)
        end
        
        --Actualiza el saldo del documento
        update CxCMovimiento set Saldo = Saldo - @Pago  , UltimaModificacion = GETDATE()
        where   Emp_Id = @pEmp_Id 
        and     TipoMov_Id = @AplicaTipoMov_Id 
        and     Mov_Id     = @AplicaMov_Id 
        if @@ERROR<>0 begin
          raiserror ('Error actualizando el saldo del documento', 16, 1)
        end   
          
        
        delete #MovimientosAplica 
        where TipoMov_Id = @AplicaTipoMov_Id
        and   Mov_Id     = @AplicaMov_Id
      end
      
      --Actualiza el saldo del cliente
      update Cliente set Saldo = Saldo - @TotalPagado , UltimaModificacion = GETDATE ()
      where Emp_Id      = @pEmp_Id 
      and   Cliente_Id  = @pCliente_Id 
      if @@ERROR<>0 begin
        raiserror ('Error actualizando el saldo del cliente', 16, 1)
      end
    end
    else begin
      raiserror ('Error, No se genero ningun documento', 16, 1)
    end
    
    select @Mov_Id as Mov_Id

  end try
  begin catch

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch 

end

GO
/****** Object:  StoredProcedure [dbo].[CxC_EstadoCuenta]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CxC_EstadoCuenta]
(@pEmp_Id smallint
,@pCliente_Id int)
as
begin
  -- Declara Variables
  declare  @Emp_Id smallint
          ,@TipoMov_Id smallint
          ,@Mov_Id bigint
          ,@Cliente_Id int
          ,@Referencia varchar(400)
          ,@Fecha datetime
          ,@FechaMovimiento datetime
          ,@Vencimiento datetime
          ,@Monto money
          ,@Saldo money
          ,@Activo bit
          ,@UltimaModificacion datetime
          ,@Intereses bit
          
  -- Declara tabla temporal
  create table #CxCMovimiento(
	  Emp_Id smallint NOT NULL,
	  TipoMov_Id smallint NOT NULL,
	  Mov_Id bigint NOT NULL,
	  Nombre varchar(50) NOT NULL default '', 
	  Cliente_Id int NOT NULL,
	  Referencia varchar(400) NOT NULL,
	  Fecha datetime NOT NULL,
	  FechaMovimiento datetime NOT NULL,
	  Vencimiento datetime NOT NULL,
	  Monto money NOT NULL,
	  Saldo money NOT NULL,
	  Activo bit NOT NULL,
	  UltimaModificacion datetime NOT NULL,
	  Intereses bit NOT NULL,
	  Padre bit NOT NULL,
	  PadreTipoMov_Id smallint NOT NULL,
	  PadreMov_Id bigint NOT NULL,)  
  
  
  declare CurMovimientos cursor for
  select a.Emp_Id
        ,a.TipoMov_Id
        ,a.Mov_Id
        ,a.Cliente_Id
        ,a.Referencia
        ,a.Fecha
        ,a.FechaMovimiento
        ,a.Vencimiento
        ,a.Monto
        ,a.Saldo
        ,a.Activo
        ,a.UltimaModificacion
        ,a.Intereses 
  From CxCMovimiento a
  where a.Emp_Id      = @pEmp_Id 
  and   a.Cliente_Id  = @pCliente_Id 
  and   a.TipoMov_Id  in (1,4)
  and   a.Saldo       > 0
  order by 
    a.FechaMovimiento asc, a.Fecha asc
    
  open CurMovimientos
    
  fetch next from CurMovimientos 
  into  @Emp_Id
        ,@TipoMov_Id
        ,@Mov_Id
        ,@Cliente_Id
        ,@Referencia
        ,@Fecha
        ,@FechaMovimiento
        ,@Vencimiento
        ,@Monto
        ,@Saldo
        ,@Activo
        ,@UltimaModificacion
        ,@Intereses
        
    while @@FETCH_STATUS = 0 begin
      --Inserta el movimiento principal
      insert into #CxCMovimiento
                 (Emp_Id
                 ,TipoMov_Id
                 ,Mov_Id
                 ,Cliente_Id
                 ,Referencia
                 ,Fecha
                 ,FechaMovimiento
                 ,Vencimiento
                 ,Monto
                 ,Saldo
                 ,Activo
                 ,UltimaModificacion
                 ,Intereses 
                 ,Padre 
                 ,PadreTipoMov_Id
                 ,PadreMov_Id)
           values
                (@Emp_Id
                ,@TipoMov_Id
                ,@Mov_Id
                ,@Cliente_Id
                ,@Referencia
                ,@Fecha
                ,@FechaMovimiento
                ,@Vencimiento
                ,@Monto
                ,@Saldo
                ,@Activo
                ,@UltimaModificacion
                ,@Intereses 
                ,1
                ,@TipoMov_Id
                ,@Mov_Id)                
    
      
      insert into #CxCMovimiento
                 (Emp_Id
                 ,TipoMov_Id
                 ,Mov_Id
                 ,Cliente_Id
                 ,Referencia
                 ,Fecha
                 ,FechaMovimiento
                 ,Vencimiento
                 ,Monto
                 ,Saldo
                 ,Activo
                 ,UltimaModificacion
                 ,Intereses 
                 ,Padre 
                 ,PadreTipoMov_Id
                 ,PadreMov_Id)      
      select      b.Emp_Id
                 ,b.TipoMov_Id
                 ,b.Mov_Id
                 ,b.Cliente_Id
                 ,b.Referencia
                 ,b.Fecha
                 ,b.FechaMovimiento
                 ,b.Vencimiento
                 
                 --,b.Monto
                 --,b.Saldo
                 ,a.Monto 
                 ,0
                 
                 ,b.Activo
                 ,b.UltimaModificacion
                 ,Intereses 
                 ,0
                 ,@TipoMov_Id
                 ,@Mov_Id
      from  CxCMovimientoAplica a,
            CxCMovimiento b
      where a.Emp_Id           = b.Emp_Id 
      and   a.TipoMov_Id       = b.TipoMov_Id 
      and   a.Mov_Id           = b.Mov_Id 
      and   a.Emp_Id           = @Emp_Id
      and   a.AplicaTipoMov_Id = @TipoMov_Id
      and   a.AplicaMov_Id     = @Mov_Id
      order by 
             a.TipoMov_Id asc
            ,a.Mov_Id asc
    
    
      fetch next from CurMovimientos 
      into  @Emp_Id
            ,@TipoMov_Id
            ,@Mov_Id
            ,@Cliente_Id
            ,@Referencia
            ,@Fecha
            ,@FechaMovimiento
            ,@Vencimiento
            ,@Monto
            ,@Saldo
            ,@Activo
            ,@UltimaModificacion
            ,@Intereses
    end
    
    close CurMovimientos
    deallocate CurMovimientos
    
    
    update a set a.Nombre = b.Nombre 
    from #CxCMovimiento    a,
         CxCMovimientoTipo b
    where a.Emp_Id      = b.Emp_Id 
    and   a.TipoMov_Id  = b.TipoMov_Id 

    
    
    select *
    from  #CxCMovimiento
    
end

GO
/****** Object:  StoredProcedure [dbo].[CxC_FacturasPendientesCliente]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CxC_FacturasPendientesCliente]
(@pEmp_Id     smallint
,@pSuc_Id     smallint
,@pCliente_Id int)
as
begin
  --Busca las facturas de credito con saldo para el cliente
    
  --1	Factura Credito
  --2	Nota Credito
  --3	Recibo
  --4	Nota Debito (igual factura)
  --5	Deposito

  select b.*
        ,c.Nombre as NombreCaja
        ,b.Documento_Id as Factura
        ,a.FechaMovimiento as Fecha
        ,a.Monto 
        ,a.Saldo 
  from  CxCMovimiento a,
        CxCMovimientoFactura b,
        Caja c
  where a.Emp_Id      = b.Emp_Id 
  and   a.TipoMov_Id  = b.TipoMov_Id 
  and   a.Mov_Id      = b.Mov_Id 
  and   b.Emp_Id      = c.Emp_Id 
  and   b.Suc_Id      = c.Suc_Id 
  and   b.Caja_Id     = c.Caja_Id
  and   b.Emp_Id      = @pEmp_Id 
  and   b.Suc_Id      = @pSuc_Id
  and   a.Cliente_Id  = @pCliente_Id 
  and   a.TipoMov_Id  = 1
  and   Saldo         > 0
end

GO
/****** Object:  StoredProcedure [dbo].[CxC_GeneraFacturasArregloPago]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[CxC_GeneraFacturasArregloPago]
(@pEmp_Id           smallint
,@pTipoMov_Id       smallint
,@pCliente_Id       int
,@pReferencia       varchar(400)
,@pFechaMovimiento  datetime
,@pCuotas           smallint
,@pMonto            money
,@pUsuario_Id       varchar(20)
,@pPorcInteres      float
,@pSuc_Id           smallint
,@pCaja_Id          smallint
,@pTipoDoc_Id       smallint
,@pDocumento_Id     bigint
,@pIntereses        money
,@pTipoNota_Id      smallint)
as
begin
  --Jimmy Trejos Valverde 26/MARZO/2013
  begin try
  
    begin transaction
    
    create table #Movimientos(Mov_Id bigint)

    declare  @MontoFactura    money
            ,@MontoIntereses  money
            ,@Mes             smallint
            ,@Mov_Id          bigint
            ,@Fecha           datetime
            ,@LimiteCredito   money
            ,@Saldo           money
            ,@DiasCredito     money
            ,@PorcMora        float
            ,@DiasGraciaMora  smallint
            ,@AplicaMora      bit
            ,@MontoTotal      money
            ,@NombreMes       varchar(20)
            ,@Nota_Id         bigint
--            ,@Referencia      varchar(400)
            

    --Inicializa variables
    select @MontoFactura  = round((@pMonto/@pCuotas),2)
          ,@MontoIntereses= round((@pIntereses/@pCuotas),2)
          ,@Mes           = 1
          ,@Mov_Id        = 0
          ,@Nota_Id       = 0
          ,@Fecha         = GETDATE ()
          ,@MontoTotal    = 0
          --,@Referencia    = ''
          
    --Busca parametros del cliente
    select   @LimiteCredito  = LimiteCredito
            ,@Saldo          = Saldo
            ,@DiasCredito    = DiasCredito
            ,@PorcMora       = PorcMora
            ,@DiasGraciaMora = DiasGraciaMora
            ,@AplicaMora     = AplicaMora
    from  Cliente 
    where Emp_Id      = @pEmp_Id 
    and   Cliente_Id  = @pCliente_Id 
    if @@ROWCOUNT=0 or @@ERROR<>0 begin
      raiserror ('Error buscando el datos del cliente', 16, 1)
    end
    
    --if ltrim(rtrim(@pReferencia)) <> '' begin
    --  set @Referencia = ' - ' + @pReferencia
    --end
    
          
    while @Mes <= @pCuotas begin
    
      WAITFOR DELAY '00:00:00.100';
      select @Fecha = GETDATE ()
    
      --Busca el consecutivo del movimiento
      select @Mov_Id = ISNULL( MAX (Mov_Id), 0) + 1
      from  CxCMovimiento 
      where Emp_Id      = @pEmp_Id 
      and   TipoMov_Id  = @pTipoMov_Id 
      if @@ERROR<>0 begin
        raiserror ('Error buscando el consecutivo del movimiento', 16, 1)
      end 
      
      
      if @MontoIntereses<>0 begin
        select @Nota_Id = ISNULL( MAX (Mov_Id), 0) + 1
        from  CxCMovimiento 
        where Emp_Id      = @pEmp_Id 
        and   TipoMov_Id  = @pTipoNota_Id  
        if @@ERROR<>0 begin
          raiserror ('Error buscando el consecutivo de la nota', 16, 1)
        end 
      end
      

      select @NombreMes = case datepart(MONTH,@pFechaMovimiento)
                                 when 1 then 'ENERO'
                                 when 2 then 'FEBRERO'
                                 when 3 then 'MARZO'
                                 when 4 then 'ABRIL'
                                 when 5 then 'MAYO'
                                 when 6 then 'JUNIO'
                                 when 7 then 'JULIO'
                                 when 8 then 'AGOSTO'
                                 when 9 then 'SETIEMBRE'
                                 when 10 then 'OCTUBRE'
                                 when 11 then 'NOVIEMBRE'
                                 when 12 then 'DICIEMBRE'
                          end      
      
      
      --Inserta el registro en cxc
      insert into CxCMovimiento
             (Emp_Id
             ,TipoMov_Id
             ,Mov_Id
             ,Cliente_Id
             ,Referencia
             ,Fecha
             ,FechaMovimiento
             ,Vencimiento
             ,Monto
             ,Saldo
             ,Activo
             ,Usuario_Id
             ,AplicaMora
             ,FechaCalculoMora
             ,Intereses
             ,UltimaModificacion)
      select @pEmp_Id
            ,@pTipoMov_Id
            ,@Mov_Id
            ,@pCliente_Id
            ,'COBRO MES :' + @NombreMes + @pReferencia
            ,@Fecha
            ,@pFechaMovimiento
            ,@pFechaMovimiento --La fecha de vencimiento es la misma del movimiento
            ,@MontoFactura
            ,@MontoFactura
            ,1
            ,@pUsuario_Id
            ,@AplicaMora
            ,@pFechaMovimiento
            ,0
            ,@Fecha
            
      if @@ROWCOUNT=0 or @@ERROR<>0 begin
        raiserror ('Error insertando cuota en CxCMovimiento', 16, 1)
      end  
      
      if @MontoIntereses<>0 begin
        WAITFOR DELAY '00:00:00.200';
        select @Fecha = GETDATE ()
        
        --Inserta nota de debito por los intereses
        insert into CxCMovimiento
               (Emp_Id
               ,TipoMov_Id
               ,Mov_Id
               ,Cliente_Id
               ,Referencia
               ,Fecha
               ,FechaMovimiento
               ,Vencimiento
               ,Monto
               ,Saldo
               ,Activo
               ,Usuario_Id
               ,AplicaMora
               ,FechaCalculoMora
               ,Intereses
               ,UltimaModificacion)
        select @pEmp_Id
              ,@pTipoNota_Id
              ,@Nota_Id
              ,@pCliente_Id
              ,'INTERESES :' + @NombreMes 
              ,@Fecha
              ,@pFechaMovimiento
              ,@pFechaMovimiento --La fecha de vencimiento es la misma del movimiento
              ,@MontoIntereses
              ,@MontoIntereses
              ,1
              ,@pUsuario_Id
              ,@AplicaMora
              ,@pFechaMovimiento
              ,0
              ,@Fecha
              
        if @@ROWCOUNT=0 or @@ERROR<>0 begin
          raiserror ('Error insertando intereses en CxCMovimiento', 16, 1)
        end  
      end
      
      
      --Inserta la relacion entre el documento y la factura
      insert into CxCMovimientoFactura
           (Emp_Id
           ,TipoMov_Id
           ,Mov_Id
           ,Suc_Id
           ,Caja_Id
           ,TipoDoc_Id
           ,Documento_Id)
     VALUES
           (@pEmp_Id 
           ,@pTipoMov_Id
           ,@Mov_Id
           ,@pSuc_Id 
           ,@pCaja_Id 
           ,@pTipoDoc_Id 
           ,@pDocumento_Id)
      if @@ROWCOUNT=0 or @@ERROR<>0 begin
        raiserror ('Error insertando cuota en CxCMovimiento', 16, 1)
      end            
      
      
      insert #Movimientos (Mov_Id) values (@Mov_Id)
      if @MontoIntereses<>0 begin
        insert #Movimientos (Mov_Id) values (@Nota_Id)
      end  
            
      set @MontoTotal = @MontoTotal + (@MontoFactura + @MontoIntereses)
      set @pFechaMovimiento = DATEADD(month,1,@pFechaMovimiento)
      set @Mes = @Mes + 1
      
 
    end
    
    update Cliente set Saldo = Saldo + @MontoTotal, UltimaModificacion = GETDATE ()
    where Emp_Id      = @pEmp_Id 
    and   Cliente_Id  = @pCliente_Id 
    if @@ROWCOUNT=0 or @@ERROR<>0 begin
      raiserror ('Error actualizando datos del cliente', 16, 1)
    end
    
    
    select *
    from  #Movimientos 
    
    commit transaction
    
  end try
  begin catch

    rollback transaction
    
    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch  
end



GO
/****** Object:  StoredProcedure [dbo].[CxC_GuardaMovimientoFactura]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CxC_GuardaMovimientoFactura]
(@pEmp_Id       smallint      --Empresa
,@pCliente_Id   int           --Cliente
,@pFechaMovimiento        datetime      --Fecha de la factura
,@pMonto        money         --Monto de la factura
,@pSuc_Id       smallint      --Sucursal donde se emite la factura
,@pCaja_Id      smallint      --Caja donde se emite la factura
,@pTipoDoc_Id   smallint      --Tipo documento POS 2 = Factura, 4 = Nota
,@pDocumento_Id bigint        --Numero documento POS
,@pUsuario_Id   varchar(20)   --Usuario que esta conectado
,@pDolares      bit           --Indica si la factura es en dolares
,@pTipoCambio   money)        --Tipo de cambio de la factura
as
begin
  
  begin try
    --Declaracion de variables
    declare  @Mov_Id          bigint
            ,@TipoMov_Id      smallint
            ,@NombreTipo      varchar(50)
            ,@IncrementaSaldo bit
            ,@DiasCredito     smallint
            ,@AplicaMora      bit
            ,@TipoCambioStr   varchar(100)
            
    --Asigna valores iniciales
    select   @Mov_Id      = 0
            ,@TipoMov_Id  = 0
            ,@pMonto      = ABS(@pMonto)
            ,@AplicaMora  = 1
            
    select @DiasCredito = DiasCredito 
          ,@AplicaMora  = AplicaMora 
    from  Cliente  
    where Emp_Id     = @pEmp_Id 
    and   Cliente_Id = @pCliente_Id 
    if @@ERROR<>0 or @@ROWCOUNT = 0 begin
      raiserror ('Error buscando parametros de empresa', 16, 1)
    end    
    

    --Asigna el tipo de movimiento
    select @TipoMov_Id = case @pTipoDoc_Id 
                            when 2 then 1 --Factura
                            when 4 then 2 --Nota Credito
                            else 0
                         end

    if @TipoMov_Id=0 begin
      raiserror ('Error asignando el tipo de movimiento', 16, 1)
    end
    
    --Busca los valores del tipo de movimiento
    select   @NombreTipo      = Nombre 
            ,@IncrementaSaldo = IncrementaSaldo 
    from  CxCMovimientoTipo 
    where Emp_Id      = @pEmp_Id 
    and   TipoMov_Id  = @TipoMov_Id
    and   Activo      = 1
    if @@ERROR<>0 or @@ROWCOUNT = 0 begin
      raiserror ('Error buscando el tipo de movimiento', 16, 1)
    end
    
    if @IncrementaSaldo = 0 begin
      set @pMonto = -(@pMonto)
    end
            
    
    --Busca el consecutivo del movimiento
    select @Mov_Id = ISNULL( MAX (Mov_Id), 0) + 1
    from  CxCMovimiento 
    where Emp_Id      = @pEmp_Id 
    and   TipoMov_Id  = @TipoMov_Id 
    if @@ERROR<>0 begin
      raiserror ('Error buscando el consecutivo del movimiento', 16, 1)
    end 
    
    
    set @TipoCambioStr = ''
    if @pDolares = 1 begin
      set @TipoCambioStr = ' Tipo de cambio = ' + cast(@pTipoCambio as varchar(20))
    end
   

    --Inserta la factura para el cliente
    insert into CxCMovimiento
               (Emp_Id
               ,TipoMov_Id
               ,Mov_Id
               ,Cliente_Id
               ,Referencia
               ,Fecha
               ,FechaMovimiento
               ,Vencimiento
               ,Monto
               ,Saldo
               ,Activo
               ,Usuario_Id
               ,AplicaMora
               ,FechaCalculoMora
               ,Intereses
               ,Dolares
               ,TipoCambio
               ,UltimaModificacion)
         VALUES
               (@pEmp_Id
               ,@TipoMov_Id
               ,@Mov_Id
               ,@pCliente_Id
               ,@NombreTipo + ' Caja ' + cast(@pCaja_Id as varchar(4)) + ' Factura ' + cast(@pDocumento_Id as varchar(10)) + @TipoCambioStr
               ,GETDATE ()
               ,@pFechaMovimiento 
               ,DATEADD (day,@DiasCredito,@pFechaMovimiento) 
               ,@pMonto 
               ,case @IncrementaSaldo when 1 then @pMonto else 0 end
               ,1
               ,@pUsuario_Id 
               ,@AplicaMora
               ,DATEADD (day,@DiasCredito,@pFechaMovimiento)
               ,0
               ,@pDolares 
               ,@pTipoCambio
               ,GETDATE ())
    if @@ERROR<>0 begin
      raiserror ('Error insertando en CxCmovimiento', 16, 1)
    end
    
    --Inserta la relacion entre la factura del POS y el movimiento
    insert into CxCMovimientoFactura
               (Emp_Id
               ,TipoMov_Id
               ,Mov_Id
               ,Suc_Id
               ,Caja_Id
               ,TipoDoc_Id
               ,Documento_Id)
         VALUES
               (@pEmp_Id 
               ,@TipoMov_Id 
               ,@Mov_Id 
               ,@pSuc_Id
               ,@pCaja_Id
               ,@pTipoDoc_Id
               ,@pDocumento_Id)
    if @@ERROR<>0 begin
      raiserror ('Error insertando en CxCMovimientoFactura', 16, 1)
    end
    
    --Actualiza el saldo del cliente
    update Cliente set Saldo = Saldo + @pMonto, UltimaModificacion = GETDATE ()
    where Emp_Id      = @pEmp_Id 
    and   Cliente_Id  = @pCliente_Id 
    if @@ERROR<>0 begin
      raiserror ('Error actualizando el saldo del cliente', 16, 1)
    end
                  
  end try
  begin catch
 
    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch
    
end

GO
/****** Object:  StoredProcedure [dbo].[CxC_MovimientosCliente]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CxC_MovimientosCliente]
(@pEmp_Id smallint
,@pCliente_Id int)
as
begin
  -- Declara Variables
  declare  @Emp_Id smallint
          ,@TipoMov_Id smallint
          ,@Mov_Id bigint
          ,@Cliente_Id int
          ,@Referencia varchar(400)
          ,@Fecha datetime
          ,@FechaMovimiento datetime
          ,@Vencimiento datetime
          ,@Monto money
          ,@Saldo money
          ,@Activo bit
          ,@UltimaModificacion datetime
          ,@Intereses bit
          ,@Dolares bit
          ,@TipoCambio money
          
  -- Declara tabla temporal
  create table #CxCMovimiento(
	  Emp_Id smallint NOT NULL,
	  TipoMov_Id smallint NOT NULL,
	  Mov_Id bigint NOT NULL,
	  Nombre varchar(50) NOT NULL default '', 
	  Cliente_Id int NOT NULL,
	  Referencia varchar(400) NOT NULL,
	  Fecha datetime NOT NULL,
	  FechaMovimiento datetime NOT NULL,
	  Vencimiento datetime NOT NULL,
	  Monto money NOT NULL,
	  Saldo money NOT NULL,
	  Activo bit NOT NULL,
	  UltimaModificacion datetime NOT NULL,
	  Intereses bit NOT NULL,
	  Padre bit NOT NULL,
	  PadreTipoMov_Id smallint NOT NULL,
	  PadreMov_Id bigint NOT NULL,
	  Dolares bit NOT NULL,
	  TipoCambio money NOT NULL,
	  MontoDolares money NOT NULL,
	  SaldoDolares money NOT NULL)  
  
  
  declare CurMovimientos cursor for
  select a.Emp_Id
        ,a.TipoMov_Id
        ,a.Mov_Id
        ,a.Cliente_Id
        ,a.Referencia
        ,a.Fecha
        ,a.FechaMovimiento
        ,a.Vencimiento
        ,a.Monto
        ,a.Saldo
        ,a.Activo
        ,a.UltimaModificacion
        ,a.Intereses 
        ,a.Dolares 
        ,a.TipoCambio 
  From CxCMovimiento a
  where a.Emp_Id      = @pEmp_Id 
  and   a.Cliente_Id  = @pCliente_Id 
  and   a.TipoMov_Id  in (1,4)
  order by 
    a.FechaMovimiento asc, a.Fecha asc
    
  open CurMovimientos
    
  fetch next from CurMovimientos 
  into  @Emp_Id
        ,@TipoMov_Id
        ,@Mov_Id
        ,@Cliente_Id
        ,@Referencia
        ,@Fecha
        ,@FechaMovimiento
        ,@Vencimiento
        ,@Monto
        ,@Saldo
        ,@Activo
        ,@UltimaModificacion
        ,@Intereses
        ,@Dolares
        ,@TipoCambio
        
    while @@FETCH_STATUS = 0 begin
      --Inserta el movimiento principal
      insert into #CxCMovimiento
                 (Emp_Id
                 ,TipoMov_Id
                 ,Mov_Id
                 ,Cliente_Id
                 ,Referencia
                 ,Fecha
                 ,FechaMovimiento
                 ,Vencimiento
                 ,Monto
                 ,Saldo
                 ,Activo
                 ,UltimaModificacion
                 ,Intereses 
                 ,Padre 
                 ,PadreTipoMov_Id
                 ,PadreMov_Id
                 ,Dolares
                 ,TipoCambio
                 ,MontoDolares
                 ,SaldoDolares)
           values
                (@Emp_Id
                ,@TipoMov_Id
                ,@Mov_Id
                ,@Cliente_Id
                ,@Referencia
                ,@Fecha
                ,@FechaMovimiento
                ,@Vencimiento
                ,@Monto
                ,@Saldo
                ,@Activo
                ,@UltimaModificacion
                ,@Intereses 
                ,1
                ,@TipoMov_Id
                ,@Mov_Id
                ,@Dolares
                ,@TipoCambio
                ,@Monto / @TipoCambio
                ,@Saldo / @TipoCambio)                
    
      
      insert into #CxCMovimiento
                 (Emp_Id
                 ,TipoMov_Id
                 ,Mov_Id
                 ,Cliente_Id
                 ,Referencia
                 ,Fecha
                 ,FechaMovimiento
                 ,Vencimiento
                 ,Monto
                 ,Saldo
                 ,Activo
                 ,UltimaModificacion
                 ,Intereses 
                 ,Padre 
                 ,PadreTipoMov_Id
                 ,PadreMov_Id
                 ,Dolares
                 ,TipoCambio
                 ,MontoDolares
                 ,SaldoDolares)
      select      b.Emp_Id
                 ,b.TipoMov_Id
                 ,b.Mov_Id
                 ,b.Cliente_Id
                 ,b.Referencia
                 ,b.Fecha
                 ,b.FechaMovimiento
                 ,b.Vencimiento
                 
                 --,b.Monto
                 --,b.Saldo
                 ,a.Monto 
                 ,0
                 
                 ,b.Activo
                 ,b.UltimaModificacion
                 ,Intereses 
                 ,0
                 ,@TipoMov_Id
                 ,@Mov_Id
                 ,b.Dolares 
                 ,b.TipoCambio
                 ,b.Monto/b.TipoCambio 
                 ,b.Saldo/b.TipoCambio 
      from  CxCMovimientoAplica a,
            CxCMovimiento b
      where a.Emp_Id           = b.Emp_Id 
      and   a.TipoMov_Id       = b.TipoMov_Id 
      and   a.Mov_Id           = b.Mov_Id 
      and   a.Emp_Id           = @Emp_Id
      and   a.AplicaTipoMov_Id = @TipoMov_Id
      and   a.AplicaMov_Id     = @Mov_Id
      order by 
             a.TipoMov_Id asc
            ,a.Mov_Id asc
    
    
      fetch next from CurMovimientos 
      into  @Emp_Id
            ,@TipoMov_Id
            ,@Mov_Id
            ,@Cliente_Id
            ,@Referencia
            ,@Fecha
            ,@FechaMovimiento
            ,@Vencimiento
            ,@Monto
            ,@Saldo
            ,@Activo
            ,@UltimaModificacion
            ,@Intereses
            ,@Dolares
            ,@TipoCambio            
    end
    
    close CurMovimientos
    deallocate CurMovimientos
    
    
    update a set a.Nombre = b.Nombre 
    from #CxCMovimiento    a,
         CxCMovimientoTipo b
    where a.Emp_Id      = b.Emp_Id 
    and   a.TipoMov_Id  = b.TipoMov_Id 

    
    
    select *
    from  #CxCMovimiento
    
    
end


GO
/****** Object:  StoredProcedure [dbo].[EliminaProforma]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EliminaProforma]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pDocumento_Id bigint)
as
begin
  begin try
  
  begin transaction
  
  --Declaracion de variables
  declare  @PrefacturaCompromete  bit
          ,@Emp_Id                smallint
          ,@Suc_Id                smallint
          ,@Documento_Id          bigint
          ,@Detalle_Id            smallint
          ,@Art_Id                varchar(13)
          ,@Cantidad              float
          --Datos Encabezado
          ,@Tipo                  smallint
          ,@Bod_Id                smallint
          ,@SpResult              int
          
    
  select @PrefacturaCompromete = PrefacturaCompromete
  from  EmpresaParametro
  where Emp_Id = @pEmp_Id 
  if @@ERROR <> 0 or @@ROWCOUNT = 0 begin
    raiserror ('Error buscando el detalle de la empresa', 16, 1)  
  end    
  
  
  select @Tipo    = Tipo
        ,@Bod_Id  = Bod_Id 
  from  ProformaEncabezado 
  where Emp_Id        = @pEmp_Id 
  and   Suc_Id        = @pSuc_Id 
  and   Documento_Id  = @pDocumento_Id 
  if @@ERROR <> 0 or @@ROWCOUNT = 0 begin
    raiserror ('Error buscando el encabezado de la proforma', 16, 1)  
  end     
  
  

  --Busca el detalle de la proforma o prefactura
  declare CurDetalle cursor for
  select Emp_Id
        ,Suc_Id
        ,Documento_Id
        ,Detalle_Id
        ,Art_Id
        ,Cantidad
  from  ProformaDetalle 
  where Emp_Id        = @pEmp_Id 
  and   Suc_Id        = @pSuc_Id 
  and   Documento_Id  = @pDocumento_Id 
  
  open CurDetalle
  
  fetch next from CurDetalle
  into   @Emp_Id
        ,@Suc_Id
        ,@Documento_Id
        ,@Detalle_Id
        ,@Art_Id
        ,@Cantidad
        
  while @@FETCH_STATUS = 0 begin

    --Si la empresa compromete inventario y es una prefactura libera comprometido  
    if @PrefacturaCompromete = 1 and @Tipo = 3 begin
      exec @SpResult = ComprometeInventarioArticulo @pEmp_Id, @pSuc_Id, @Bod_Id, @Art_Id ,@Cantidad, 0
      if @SpResult<>0 begin
        raiserror ('Error ejecutando, ComprometeInventarioArticulo, para el articulo: %s', 16, 1, @Art_Id)
      end  
    end
  
	  delete ProformaDetalle 
	  where	Emp_Id        = @pEmp_Id 
	  and		Suc_Id        = @pSuc_Id 
	  and		Documento_Id  = @pDocumento_Id
	  and   Detalle_Id    = @Detalle_Id
	  if @@error <> 0 begin
          raiserror ('Error eliminando detalle del documento', 16, 1)  
    end
  
    fetch next from CurDetalle
    into   @Emp_Id
          ,@Suc_Id
          ,@Documento_Id
          ,@Detalle_Id
          ,@Art_Id
          ,@Cantidad  
  end
  
  close       CurDetalle
  deallocate  CurDetalle


  --Elimina el encabezado del documento
	delete ProformaEncabezado
	where	Emp_Id = @pEmp_Id 
	and		Suc_Id = @pSuc_Id 
	and		Documento_Id = @pDocumento_Id
	if @@error <> 0 begin
        raiserror ('Error eliminando encabezado del documento', 16, 1)  
  end
  
  commit transaction

  end try
  begin catch
  
    rollback transaction

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch  
end

GO
/****** Object:  StoredProcedure [dbo].[GeneraCodigoClase]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GeneraCodigoClase](@Tabla varchar(250) ,@nombre as varchar(250))
as
begin 
	Declare @id    int
  Declare @Campo  varchar(250)
  Declare @Tipo   varchar(250)



	Select @id = id  
	from sysobjects 
	Where XType = 'U'
	and   name  =  @Tabla
	

------------------------------------ variables ----------------------------------
  if @nombre <> '' begin
    print 'Public Class ' + @nombre
  end
  else begin
    print 'Public Class T' + @Tabla
  end
	PRINT 'Inherits TBaseClassManager'
	declare  lista Cursor for 
		Select C.NAME Campo, Case  t.NAME  
			when  'bit'  then 'integer'
			when  'char'  then 'Char'
			when  'datetime'  then 'Datetime'
			when  'decimal'  then 'Double'
			when  'float'  then  'Double'
			when  'int'  then 'integer'
			when  'money'  then 'Double'
			when  'numeric' then 
                        case 
                          when C.scale <> 0 then 'Double'
                          else 'Int64'
                        end
			when  'real'  then 'Double'
			when  'smalldatetime'  then 'Date'
			when  'smallint'  then 'integer'
			when  'smallmoney'  then 'Double'
			when  'varchar'     then 'String'
			when  'nvarchar'    then 'String'
      when  'xml'         then 'String'
      when  'bigint' then 'long'
			else  T.name
		end AS Tipo	
		from   syscolumns C , sysTypes  T	
		where C.id =  @id
		and   C.xtype = T.xtype
		order by c.colorder

	OPEN Lista
	print ' '
	print '#Region "Definicion Variables Locales"'
	print ' '

	FETCH NEXT FROM Lista INTO @Campo, @tIPO
	WHILE @@FETCH_STATUS = 0 BEGIN
		print 'Private _' + @Campo + ' as ' + @Tipo
		FETCH NEXT FROM Lista INTO @Campo, @tIPO
	END
	CLOSE Lista
	DEALLOCATE Lista
  print 'Private _Data As DataSet'
	print ' '
	PRINT '#End Region'
	PRINT ''

------------------------------------ propiedades --------------------------------
  print '#Region "Definicion de propiedades"'
  print ''
	declare  lista Cursor for 
		Select C.NAME Campo, Case  t.NAME  
			when  'bit'  then 'integer'
			when  'char'  then 'Char'
			when  'datetime'  then 'Datetime'
			when  'decimal'  then 'Double'
			when  'float'  then  'Double'
			when  'int'  then 'integer'
			when  'money'  then 'Double'
			when  'numeric' then 
                        case 
                          when C.scale <> 0 then 'Double'
                          else 'Int64'
                        end
			when  'real'  then 'Double'
			when  'smalldatetime'  then 'Date'
			when  'smallint'  then 'integer'
			when  'smallmoney'  then 'Double'
			when  'varchar'  then 'String'
			when  'nvarchar'  then 'String'
      when  'xml' then 'string'
      when  'bigint' then 'long'
			else  T.name
		end AS Tipo	
		from   syscolumns C , sysTypes  T	
		where C.id =  @id
		and   C.xtype = T.xtype
		order by c.colorder

	OPEN Lista
	FETCH NEXT FROM Lista INTO @Campo, @tIPO
	WHILE @@FETCH_STATUS = 0 BEGIN

			print 'Public Property '  + @Campo + '() as ' + @Tipo
			print '    Get'
			print '       Return _' + @Campo
			print '    End Get'
			print '    Set(ByVal Value As ' + @Tipo + ')'
			print '       _' + @Campo +' = Value'
			print '	   End Set'
    		print 'End Property'

		FETCH NEXT FROM Lista INTO @Campo, @tIPO
	END
	CLOSE Lista
	DEALLOCATE Lista


  print 'Public ReadOnly Property Data() As DataSet'
  print 'Get'
  print '   Return _Data'
  print 'End Get'
  print 'End Property'
  print 'Public ReadOnly Property RowsAffected() As Long'
  print '   Get'
  print '       Return Cn.RowsAffected'
  print 'End Get'
  print 'End Property'
  print ''
	print ''
	print '#End Region'


------------------------------------ constructores ------------------------------

  print '#Region "Constructores"'
  print 'Public Sub New(pEmp_Id as integer)'
  print ' MyBase.New()'
  print ' Inicializa()'
  print ' _Emp_Id = pEmp_Id'
  print 'End Sub'
  print 'Public Sub New(pEmp_Id as integer, ByVal pCnStr As String)'
  print ' MyBase.New(pCnStr)'
  print ' Inicializa()'
  print ' _Emp_Id = pEmp_Id'
  print 'End Sub'
  print '#End Region'

------------------------------------ metodos privados ---------------------------

  print '#Region "Metodos Privados"'
  print 'Private Sub Inicializa'  
	declare  lista Cursor for 
		Select C.NAME Campo, Case  t.NAME  
			when  'bit'  then '0'
			when  'char'  then '""'
			when  'datetime'  then 'CDATE("1900/01/01")'
			when  'decimal'  then '0.00'
			when  'float'  then  '0.00'
			when  'int'  then '0'
			when  'money'  then '0.00'
			when  'numeric' then 
                        case 
                          when C.scale <> 0 then '0.00'
                          else '0'
                        end
			when  'real'  then '0.00'
			when  'smalldatetime'  then 'CDATE("1900/01/01")'
			when  'smallint'  then '0'
			when  'smallmoney'  then '0'
			when  'varchar'  then '""'
			when  'nvarchar'  then '""'
      when  'xml' then '""'
      when  'bigint' then '0'
			else  T.name
		end AS Tipo	
		from   syscolumns C , sysTypes  T	
		where C.id =  @id
		and   C.xtype = T.xtype
		order by c.colorder
	OPEN Lista
	FETCH NEXT FROM Lista INTO @Campo, @tIPO
	WHILE @@FETCH_STATUS = 0 BEGIN		
    PRINT  '             _' + @Campo +'= ' + @Tipo
		FETCH NEXT FROM Lista INTO @Campo, @tIPO
	END
	CLOSE Lista
	DEALLOCATE Lista
	print '_Data = New Dataset'
  print 'End Sub'
  print '#End Region'


------------------------------------ metodos publicos ---------------------------
	PRINT '#Region "Definicion metodos publicos"'
	----------------------------------insert
	print '    Public Overrides Function Insert() As string'
  print '        Dim Query As String = ""'
  print '        Try'
  print '            Cn.Open()'
  print ''
  print '            Cn.BeginTransaction()'
  print ''
	exec GeneraCodigoClaseInsert @id, @Tabla
  print ''
  print '            Cn.Ejecutar(Query)'
  print ''
  print '            Cn.CommitTransaction()'
  print ''
  print '            Return ""'
  print '        Catch ex As Exception'
  print '            Cn.RollBackTransaction()'
  print '            Return ex.Message'
  print '        Finally'
  print '            Cn.Close()'
  print '        End Try'
  print '    End Function'

	-------------------------DELETE
	print '    Public Overrides Function Delete() As String'
	print '        Dim Query As String = ""'
	print '        Try'
	print '            Cn.Open()'
	print ''
	print '            Cn.BeginTransaction()'
	print ''
	print '        query =  "Delete '+ @Tabla +'" & _ '
	exec GeneraCodigoClaseWhere @id, @Tabla
	print ''
	print '            Cn.Ejecutar(Query)'
	print ''
	print '            Cn.CommitTransaction()'
	print ''
	print '            Return ""'
	print '        Catch ex As Exception'
	print '            Cn.RollBackTransaction()'
	print '            Return ex.Message'
	print '        Finally'
	print '            Cn.Close()'
	print '        End Try'
	print '    End Function'

  -------------------------MODIFY
	print '    Public Overrides Function Modify() As String'
	print '        Dim Query As String = ""'
	print '        Try'
	print '            Cn.Open()'
	print ''
	print '            Cn.BeginTransaction()'
	print ''
	exec GeneraCodigoClaseUpdate @id, @Tabla
	exec GeneraCodigoClaseWhere  @id, @Tabla
	print ''
	print '            Cn.Ejecutar(Query)'
	print ''
	print '            Cn.CommitTransaction()'
	print ''
	print '            Return ""'
	print '        Catch ex As Exception'
	print '            Cn.RollBackTransaction()'
	print '            Return ex.Message'
	print '        Finally'
	print '            Cn.Close()'
	print '        End Try'
	print '    End Function'


  -------------------------LISTKEY
	print '    Public Overrides Function ListKey() As String'
	print '        Dim Query As String'
	print '        Dim Tabla As DataTable'
	print '        Try'
	print '            Cn.Open()'
	print ''
	print '            Query = "select * From ' + @Tabla + '" & _'
 exec GeneraCodigoClaseWhere  @id, @Tabla
	print ''
	print '            Tabla = Cn.Seleccionar(Query).Copy'
	print ''
	print '            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then'
	declare  lista Cursor for 
		Select C.NAME Campo
		from   syscolumns C 
		where C.id =  @id
		order by c.colorder
	OPEN Lista
	FETCH NEXT FROM Lista INTO @Campo
	WHILE @@FETCH_STATUS = 0 BEGIN		
		PRINT  '               _' + @Campo + ' = Tabla.Rows(0).Item("' + @Campo+ '")'
		FETCH NEXT FROM Lista INTO @Campo
	END
	CLOSE Lista
	DEALLOCATE Lista
	print '            End If'
	print ''
	print '            Return ""'
	print ''
  print '      Catch ex As Exception'
  print '            Return ex.Message'
  print '        Finally'
  print '            Cn.Close()'
  print '        End Try'
  print '    End Function'

  -------------------------LIST
  print '    Public Overrides Function List() As String'
  print '        Dim Query As String'
  print '        Dim Tabla As DataTable'
  print '        Try'
  print '            Cn.Open()'
  print ''
	print '            Query = "select * From ' + @Tabla + '"'
  print ''
  print '            Tabla = Cn.Seleccionar(Query).Copy'
  print ''
  print '            If _Data.Tables.Contains(Tabla.TableName) Then'
  print '                _Data.Tables.Remove(Tabla.TableName)'
  print '            End If'
  print ''
  print '            _Data.Tables.Add(Tabla)'
  print ''
  print '            Return ""'
  print ''
  print '        Catch ex As Exception'
  print '            Return ex.Message'
  print '        Finally'
  print '            Cn.Close()'
  print '        End Try'
  print '    End Function'
  
    -------------------------LOAD
  print '    Public Overrides Function LoadComboBox(pCombo As System.Windows.Forms.ComboBox) As String'
  print '        Dim Query As String'
  print '        Dim Tabla As DataTable'
  print '        Try'
  print '            Cn.Open()'
  print ''
	print '            Query = "select ' + @Tabla + '_Id as Numero, Nombre From ' + @Tabla + '"'
  print ''
  print '            Tabla = Cn.Seleccionar(Query).Copy'
  print ''
  print '            If not Tabla is nothing Then'
  print '            pCombo.DataSource = Nothing'
  print '            pCombo.DataSource = Tabla'
  print '            pCombo.DisplayMember = "Nombre"'
  print '            pCombo.ValueMember = "Numero"'
  print '            End If'
  print ''
  print '            Return ""'
  print ''
  print '        Catch ex As Exception'
  print '            Return ex.Message'
  print '        Finally'
  print '            Cn.Close()'
  print '        End Try'
  print '    End Function'



  print '#End Region'

  print 'End Class'
end

GO
/****** Object:  StoredProcedure [dbo].[GeneraCodigoClaseInsert]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GeneraCodigoClaseInsert] (@id as int, @Table varchar (250) ) as
begin

	Declare @Campo   varchar(250)
	Declare @Tipo    varchar(250)
	Declare @Fields  varchar(5000)
	Declare @Values  varchar(5000)
	Declare @Enter   varchar(50)
	Declare @Order   int
	Declare @Primero   int
	Declare @ContEnter int
	declare  lista Cursor for

		Select distinct C.NAME Campo, Case  t.NAME  
			when  'bit'  then 'System.Boolean'
			when  'char'  then 'System.String'
			when  'datetime'  then 'System.DateTime'
			when  'decimal'  then 'System.Double'
			when  'float'  then  'System.Double'
			when  'int'  then 'System.Int32'
			when  'money'  then 'System.Double'
			when  'numeric'  then 'System.Double'
			when  'real'  then 'System.Double'
			when  'smalldatetime'  then 'System.DateTime'
			when  'smallint'  then 'System.Int32'
			when  'smallmoney'  then 'System.Double'
			when  'varchar'  then 'System.String'
			when  'nvarchar'  then 'System.String'
			when  'xml'  then 'System.String'
			when  'bigint'  then 'System.Int64'
			else  T.name
		end AS Tipo	, c.colorder
		from   syscolumns C , sysTypes  T	
		where C.id =  @id
		and   C.xtype = T.xtype
		order by c.colorder

	OPEN Lista

	Set @Fields  = ''
	Set @Values  = ''
	Set @Primero = 1 
	set @ContEnter = 0 
	set @Enter = '   & _' +Char(13) + '       '

	FETCH NEXT FROM Lista INTO @Campo, @tIPO , @Order
	WHILE @@FETCH_STATUS = 0 BEGIN
		if @Primero = 1 begin
			Set @Fields = '" Insert into '+ @Table +'( ' + @Campo
			set @Primero	= 0 
			if @tIPO <> 'System.String' begin
			   Set @Values = '       " Values ( " & _' + @Campo + '.ToString()'
			end
			else begin
				Set @Values = '       " Values ( ' + char(39) + '"& _' + @Campo +  ' & "' + Char(39) + '"'
			end 
		end 
		else begin
			Set @Fields = @Fields +' , ' + @Campo
			if @tIPO <> 'System.String' begin
				if @Tipo <> 'System.DateTime' begin
					if @ContEnter = 1 begin
					    Set @Values = @Values +' & "," & _' + @Campo + '.ToString()'
					end
					else begin
					    Set @Values = @Values +'"," & _' + @Campo + '.ToString()'
					end
				end 
				else begin
					if @ContEnter = 1 begin
					    Set @Values = @Values +' & ",'+ char(39) + '" & Format(_' + @Campo +  ',"yyyyMMdd HH:mm:ss") & "' + Char(39) + '"'
					end
					else begin
						Set @Values = @Values +'",'+ char(39) + '" & Format(_' + @Campo +  ',"yyyyMMdd HH:mm:ss") & "' + Char(39) + '"'
					end
				end 
			end
			else begin
					if @ContEnter = 1 begin
						Set @Values = @Values +' & ",'+ char(39) + '" & _' + @Campo +  ' & "' + Char(39) + '"'
					end
					else begin
						Set @Values = @Values +'",'+ char(39) + '" & _' + @Campo +  ' & "' + Char(39) + '"'
					end
			end 
		end
		set @ContEnter = @ContEnter + 1 
		if @ContEnter = 2 begin
			set @ContEnter = 0 
			Set @Values = @Values + @Enter
			Set @Fields = @Fields + '"' +@Enter+ '"'
		end 
		FETCH NEXT FROM Lista INTO @Campo, @tIPO, @Order
	END
	CLOSE Lista
	DEALLOCATE Lista
	print 'query = ' + @Fields + ' )" & _ ' 
	print @Values + ' & ")"'
end

GO
/****** Object:  StoredProcedure [dbo].[GeneraCodigoClaseUpdate]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GeneraCodigoClaseUpdate] (@id as int, @Table varchar (250) ) as
begin

	Declare @Campo   varchar(250)
	Declare @Tipo    varchar(250)
	Declare @Fields  varchar(8000)
	Declare @Values  varchar(8000)
	Declare @Order   int
	Declare @Primero   int
	declare  lista Cursor for

		Select distinct C.NAME Campo, Case  t.NAME  
			when  'bit'  then 'System.Boolean'
			when  'char'  then 'System.String'
			when  'datetime'  then 'System.DateTime'
			when  'decimal'  then 'System.Double'
			when  'float'  then  'System.Double'
			when  'int'  then 'System.Int32'
			when  'money'  then 'System.Double'
			when  'numeric'  then 'System.Double'
			when  'real'  then 'System.Double'
			when  'smalldatetime'  then 'System.DateTime'
			when  'smallint'  then 'System.Int32'
			when  'smallmoney'  then 'System.Double'
			when  'varchar'  then 'System.String'
			when  'nvarchar'  then 'System.String'
			else  T.name
		end AS Tipo	, c.colorder
		from   syscolumns C , sysTypes  T	
		where C.id =  @id
		and   C.xtype = T.xtype
		AND   C.NAME NOT IN (Select C.Name
					from   syscolumns C ,    SysIndexes I , SysIndexkeys K 
					where C.id =  @id
					and   I.id = C.id
					and   I.name like 'PK_%'
					and   K.id = C.id
					and   K.indid = I.indid
					and   K.Colid = C.Colid)
		order by c.colorder

	OPEN Lista

	Set @Fields  = ''
	Set @Values  = ''
	Set @Primero = 1 

	FETCH NEXT FROM Lista INTO @Campo, @tIPO , @Order
	WHILE @@FETCH_STATUS = 0 BEGIN
			
		if @Primero = 1 begin
			set @Primero	= 0 
			if @tIPO <> 'System.String' begin
			   Set @Fields = '       " SET    ' + @Campo + '=" & _'+ @Campo + '.ToString() '
			end
			else begin
			   Set @Fields = '       " SET   ' + @Campo + '=' +char(39)+'" & _'+ @Campo +'  &"' +char(39) +' "'
			end 
		end 
		else begin
			if @tIPO <> 'System.String' begin
				if @Tipo <> 'System.DateTime' begin
					Set @Fields = @Fields + ' & "," & _' +char(13) + '           " '+ @Campo + '=" & _'+ @Campo + ''
				end 
				else begin
					Set @Fields = @Fields + ' & "," & _' +char(13) + '           " '+ @Campo + '=' + char(39) + '" & Format(_'+ @Campo  +',"yyyyMMdd HH:mm:ss") &"' +char(39) +'"'
				end 
			end
			else begin
				Set @Fields = @Fields + ' & "," & _' +char(13) + '           " '+ @Campo + '='+ char(39)+'" & _'+ @Campo +' &"' +char(39) +'"'
			end 
		end
		
		FETCH NEXT FROM Lista INTO @Campo, @tIPO, @Order
	END
	CLOSE Lista
	DEALLOCATE Lista

	print  ' query = " Update dbo.' + @Table + ' " & _ ' 
	print  '    ' + @Fields + ' & _ '
end

GO
/****** Object:  StoredProcedure [dbo].[GeneraCodigoClaseWhere]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GeneraCodigoClaseWhere] (@id as int, @Table varchar (250) ) as
begin

	Declare @Campo   varchar(250)
	Declare @Tipo    varchar(250)
	Declare @Fields  varchar(2000)
	Declare @Values  varchar(2000)
	Declare @Order   int
	Declare @Primero   int
	declare  lista Cursor for

		Select distinct C.NAME Campo, Case  t.NAME  
			when  'bit'  then 'System.Boolean'
			when  'char'  then 'System.String'
			when  'datetime'  then 'System.DateTime'
			when  'decimal'  then 'System.Double'
			when  'float'  then  'System.Double'
			when  'int'  then 'System.Int32'
			when  'money'  then 'System.Double'
			when  'numeric'  then 'System.Double'
			when  'real'  then 'System.Double'
			when  'smalldatetime'  then 'System.DateTime'
			when  'smallint'  then 'System.Int32'
			when  'smallmoney'  then 'System.Double'
			when  'varchar'  then 'System.String'
			when  'nvarchar'  then 'System.String'
			else  T.name
		end AS Tipo	, c.colorder
		from   syscolumns C , sysTypes  T	
		where C.id =  @id
		and   C.xtype = T.xtype
		AND   C.NAME  IN (Select C.Name
					from   syscolumns C ,    SysIndexes I , SysIndexkeys K 
					where C.id =  @id
					and   I.id = C.id
					and   I.name like 'PK_%'
					and   K.id = C.id
					and   K.indid = I.indid
					and   K.Colid = C.Colid)
		order by c.colorder

	OPEN Lista

	Set @Fields  = ''
	Set @Values  = ''
	Set @Primero = 1 

	FETCH NEXT FROM Lista INTO @Campo, @tIPO , @Order
	WHILE @@FETCH_STATUS = 0 BEGIN
			
		if @Primero = 1 begin
		    set @Primero	= 0 
		    if @tIPO <> 'System.String' begin
 				  Set @Fields = '           " Where     ' + @Campo + '=" & _'+ @Campo + '.ToString() '
			  end 
			  else begin
				  Set @Fields = '           " Where     ' + @Campo + '=' + char(39) + '" & _' + @Campo + ' & "' + char(39) + '"'
			  end 
		end 
		else begin
		    if @tIPO <> 'System.String' begin
 				Set @Fields = @Fields + ' & _ ' + char(13) + '           " And    ' + @Campo + '=" & _'+ @Campo + '.ToString() '
			end 
			else begin
				Set @Fields = @Fields + ' & _ ' + char(13) + '           " And     ' + @Campo + '=' + char(39) + '" & _' + @Campo + ' & "' + char(39) + '"'
			end 
		end
	
		FETCH NEXT FROM Lista INTO @Campo, @tIPO, @Order
	END
	CLOSE Lista
	DEALLOCATE Lista

	print @Fields + ' '
end

GO
/****** Object:  StoredProcedure [dbo].[GuardaArticuloKardex]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GuardaArticuloKardex]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint
,@pArt_Id varchar(13)
,@pCantidad float
,@pDetalle varchar(200)
,@pUsuario_Id varchar(20)
,@pSuelto bit)
as
begin
  begin try
	declare @SaldoActual float
	

	if @pSuelto = 0 begin
		--Busca el saldo alctual del articulo
		--28/04/2014
		select	@SaldoActual = Saldo
		from	ArticuloBodega 
		where	Emp_Id = @pEmp_Id
		and		Suc_Id = @pSuc_Id
		and		Bod_Id = @pBod_Id 
		and		Art_Id = @pArt_Id  
		if @@error<>0 begin
				raiserror ('Error buscando saldo alctual de producto en GuardaArticuloKardex', 16, 1)
		end
	end
	else begin
		set @SaldoActual = 0
	end   	
  
  
    --Le invierte el signo, para guardar positivo lo que suma al inventario
    --y negativo lo que resta 
    --Jimmy Trejos Valverde 02/05/2012
    select @pCantidad = @pCantidad * -1
  
  
    --Guarda el Kardex del articulo
    insert into ArticuloKardex
               (Emp_Id
               ,Suc_Id
               ,Bod_Id
               ,Art_Id
               ,Fecha
               ,Cantidad
               ,Detalle
               ,Usuario_Id
               ,Saldo
               ,Suelto)
         VALUES
               (@pEmp_Id
               ,@pSuc_Id
               ,@pBod_Id
               ,@pArt_Id
               ,getdate()
               ,@pCantidad
               ,@pDetalle
               ,@pUsuario_Id
               ,@SaldoActual
               ,@pSuelto)
    if @@error<>0 begin
      raiserror ('Error guardando en ArticuloKaedex', 16, 1)
    end                    
               
  end try
  begin catch

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch                   
end

GO
/****** Object:  StoredProcedure [dbo].[GuardaBitacoraUsuario]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GuardaBitacoraUsuario]
(@pModulo_Id  smallint
,@pEmp_Id     smallint
,@pUsuario_Id varchar(20)
,@pDescripcion varchar(500))
as
begin

  insert BitacoraUsuario(Modulo_Id, Emp_Id, Usuario_Id, Fecha, Descripcion)
  values(@pModulo_Id, @pEmp_Id, @pUsuario_Id, GETDATE(), @pDescripcion)
  
end

GO
/****** Object:  StoredProcedure [dbo].[GuardaFacturaDetalle]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GuardaFacturaDetalle]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pCaja_Id smallint
,@pBod_Id smallint
,@pTipoDoc_Id smallint
,@pDocumento_Id bigint
,@pDetalle_Id smallint
,@pArt_Id varchar(13)
,@pCantidad float
,@pFecha datetime
,@pCosto money
,@pPrecio money
,@pPorcDescuento money
,@pMontoDescuento money
,@pMontoIV money
,@pTotalLinea money
,@pExentoIV bit
,@pSuelto bit
,@pUsuario_Id varchar(20)
,@pObservacion varchar(500))
as
begin
  begin try
  
    declare  @SpResult int
            ,@Nombre varchar(50)
    
    
    --Busca el nombre del tipo de documento
    select @Nombre = Nombre
    from  TipoDocumento
    where Emp_Id     = @pEmp_Id
    and   TipoDoc_Id = @pTipoDoc_Id
    if @@error <> 0  begin
      raiserror ('Error buscando el nombre del tipo de documento, articulo: %s', 16, 1, @pArt_Id)  
    end
    
    
    --Guarda el detalle de la factura           
    insert into FacturaDetalle
               (Emp_Id
               ,Suc_Id
               ,Caja_Id
               ,TipoDoc_Id
               ,Documento_Id
               ,Detalle_Id
               ,Art_Id
               ,Cantidad
               ,Fecha
               ,Costo
               ,Precio
               ,PorcDescuento
               ,MontoDescuento
               ,MontoIV
               ,TotalLinea
               ,ExentoIV
               ,Suelto
               ,Observacion)
         values
               (@pEmp_Id
               ,@pSuc_Id
               ,@pCaja_Id
               ,@pTipoDoc_Id
               ,@pDocumento_Id
               ,@pDetalle_Id
               ,@pArt_Id
               ,@pCantidad
               ,@pFecha
               ,@pCosto
               ,@pPrecio
               ,@pPorcDescuento
               ,@pMontoDescuento
               ,@pMontoIV
               ,@pTotalLinea
               ,@pExentoIV
               ,@pSuelto
               ,@pObservacion)
               
    if @@error <> 0  begin
      raiserror ('Error guardando detalle factura , articulo: %s', 16, 1, @pArt_Id)  
    end
    
    --Si es una devolucion el monto se envia negativo para que se haga la devolucion al inventario
    exec @SpResult = RebajaSumaIventario @pEmp_Id, @pSuc_Id, @pBod_Id, @pArt_Id ,@pCantidad, @Nombre, @pUsuario_Id
    if @SpResult<>0 begin
      raiserror ('Error ejecutando, RebajaSumaIventario, para el articulo: %s', 16, 1, @pArt_Id)
    end
    
    
    --Actualiza la decha de la ultima venta
    update ArticuloBodega set FechaUltimaVenta = getdate()
    where Emp_Id = @pEmp_Id
    and   Suc_Id = @pSuc_Id
    and   Bod_Id = @pBod_Id
    and   Art_Id = @pArt_Id
    if @@error <> 0 begin
      raiserror ('Error actualizando fecha ultima venta, articulo: %s', 16, 1, @pArt_Id)  
    end
    
   
  end try
  begin catch

    rollback transaction

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch
end

GO
/****** Object:  StoredProcedure [dbo].[GuardaMovimientoDetalle]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GuardaMovimientoDetalle]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pTipoMov_Id smallint
,@pMov_Id int 
,@pDetalle_Id smallint
,@pArt_Id varchar(13) 
,@pCantidad float 
,@pCosto money 
,@pTotalLinea money 
,@pSuelto bit 
,@pFecha datetime)
as
begin
  --Unicamente almacena el movimiento, el rebajo se hace al aplicar sp AplicaMovimientoAjuste
  begin try
  
    insert into MovimientoDetalle 
               (Emp_Id 
               ,Suc_Id 
               ,TipoMov_Id 
               ,Mov_Id 
               ,Detalle_Id 
               ,Art_Id 
               ,Cantidad 
               ,Costo 
               ,TotalLinea 
               ,Suelto 
               ,Fecha 
               ,UltimaModificacion)
         VALUES
               (@pEmp_Id 
               ,@pSuc_Id 
               ,@pTipoMov_Id 
               ,@pMov_Id
               ,@pDetalle_Id 
               ,@pArt_Id
               ,@pCantidad
               ,@pCosto
               ,@pTotalLinea
               ,@pSuelto
               ,@pFecha
               ,getdate())
    if @@error<>0 begin
      raiserror ('Error guardando detalle, para el articulo: %s', 16, 1, @pArt_Id)
    end               
          
  end try
  begin catch

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch
end

GO
/****** Object:  StoredProcedure [dbo].[GuardaPreFacturaDetalle]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GuardaPreFacturaDetalle]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pCaja_Id smallint
,@pBod_Id smallint
,@pTipoDoc_Id smallint
,@pDocumento_Id bigint
,@pDetalle_Id smallint
,@pArt_Id varchar(13)
,@pCantidad float
,@pFecha datetime
,@pCosto money
,@pPrecio money
,@pPorcDescuento money
,@pMontoDescuento money
,@pMontoIV money
,@pTotalLinea money
,@pExentoIV bit
,@pSuelto bit
,@pUsuario_Id varchar(20))
as
begin
  begin try
  
    declare  @SpResult int
            ,@Nombre varchar(50)
    
    
    --Busca el nombre del tipo de documento
    select @Nombre = Nombre
    from  TipoDocumento
    where Emp_Id     = @pEmp_Id
    and   TipoDoc_Id = @pTipoDoc_Id
    if @@error <> 0  begin
      raiserror ('Error buscando el nombre del tipo de documento, articulo: %s', 16, 1, @pArt_Id)  
    end
    
    
    --Guarda el detalle de la factura           
    insert into PreFacturaDetalle
               (Emp_Id
               ,Suc_Id
               ,Caja_Id
               ,TipoDoc_Id
               ,Documento_Id
               ,Detalle_Id
               ,Art_Id
               ,Cantidad
               ,Fecha
               ,Costo
               ,Precio
               ,PorcDescuento
               ,MontoDescuento
               ,MontoIV
               ,TotalLinea
               ,ExentoIV
               ,Suelto)
         values
               (@pEmp_Id
               ,@pSuc_Id
               ,@pCaja_Id
               ,@pTipoDoc_Id
               ,@pDocumento_Id
               ,@pDetalle_Id
               ,@pArt_Id
               ,@pCantidad
               ,@pFecha
               ,@pCosto
               ,@pPrecio
               ,@pPorcDescuento
               ,@pMontoDescuento
               ,@pMontoIV
               ,@pTotalLinea
               ,@pExentoIV
               ,@pSuelto)
               
    if @@error <> 0  begin
      raiserror ('Error guardando detalle factura , articulo: %s', 16, 1, @pArt_Id)  
    end
    
  
  end try
  begin catch

    rollback transaction

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch
end

GO
/****** Object:  StoredProcedure [dbo].[InsertaFacturaBitacora]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsertaFacturaBitacora]
(@pCliente_Id   int
,@pEmp_Id       smallint
,@pSuc_Id       smallint
,@pCaja_Id      smallint
,@pTipoDoc_Id   smallint
,@pDocumento_Id bigint
,@pUsuario_Id   varchar(20)
,@pIp           varchar(50)
,@pTipo         smallint
,@DocAnterior   bigint)
as
begin
  begin try
  
    begin transaction
    
    
    if @DocAnterior > -1 begin
      insert into FacturaBitacora
             (Cliente_Id
             ,Emp_Id
             ,Suc_Id
             ,Caja_Id
             ,TipoDoc_Id
             ,Documento_Id
             ,Fecha
             ,Usuario_Id
             ,Ip
             ,Tipo)
      select  Cliente_Id
             ,Emp_Id
             ,Suc_Id
             ,@pCaja_Id 
             ,@pTipoDoc_Id 
             ,@pDocumento_Id 
             ,Fecha
             ,Usuario_Id
             ,Ip
             ,Tipo
      from FacturaBitacora
      where Emp_Id        = @pEmp_Id 
      and   Suc_Id        = @pSuc_Id 
      and   Cliente_Id    = @pCliente_Id 
      and   Documento_Id  = @DocAnterior 
      if @@error <> 0 begin
          raiserror ('Error insertando trasladando historia factura', 16, 1)  
      end	                   

      delete FacturaBitacora
      where Emp_Id        = @pEmp_Id 
      and   Suc_Id        = @pSuc_Id 
      and   Cliente_Id    = @pCliente_Id 
      and   Documento_Id  = @DocAnterior 
      if @@error <> 0 begin
          raiserror ('Error Eliminando bitacora PreFactura', 16, 1)  
      end	                   


    end

    INSERT INTO FacturaBitacora
               (Cliente_Id
               ,Emp_Id
               ,Suc_Id
               ,Caja_Id
               ,TipoDoc_Id
               ,Documento_Id
               ,Fecha
               ,Usuario_Id
               ,Ip
               ,Tipo)
         VALUES
               (@pCliente_Id
               ,@pEmp_Id
               ,@pSuc_Id
               ,@pCaja_Id
               ,@pTipoDoc_Id
               ,@pDocumento_Id
               ,GETDATE()
               ,@pUsuario_Id
               ,@pIp
               ,@pTipo)
    if @@error <> 0 or @@rowcount = 0 begin
        raiserror ('Error insertando registro en la bitacora', 16, 1)  
    end	                   
             
    commit transaction

  end try
  begin catch
  
    rollback transaction

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch  
end
GO
/****** Object:  StoredProcedure [dbo].[LimpiaBD]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[LimpiaBD]
as
begin

  delete AjusteCosto
  delete Articulo
  delete ArticuloBodega
  delete ArticuloConjunto
  delete ArticuloConteo
  delete ArticuloEquivalente
  delete ArticuloKardex
  delete ArticuloProveedor
  delete ArticuloTemporal
  --delete Banco
  delete BitacoraUsuario
  --delete Bodega
  --delete Botones
  delete Caja where Caja_Id<>1
  update Caja set Abierta = 0, Cierre_Id=1
  delete CajaAutorizacion
  delete CajaCierreDetalle
  delete CajaCierreEncabezado
  delete Categoria
  delete Cliente where Cliente_Id <> 1
  --delete ClientePrecio
  --delete ConsecutivoTemporal
  delete CxCMovimiento
  delete CxCMovimientoAplica
  delete CxCMovimientoFactura
  delete CxCMovimientoMora
  delete CxCMovimientoPago
  --delete CxCMovimientoTipo
  delete Departamento
  --delete Empresa
  --delete EmpresaConsecutivo
  --delete EmpresaParametro
  delete EntradaDetalle
  delete EntradaEncabezado
  --delete EntradaEstado
  delete EntradaFactura
  --delete EtiquetaTipo
  delete FacturaDetalle
  delete FacturaDevolucion
  delete FacturaEncabezado
  delete FacturaPago
  delete Grupo where Grupo_Id <> 1
  delete GrupoMenu where Grupo_Id <> 1
  delete Menu
  --delete Modulo
  --delete Moneda
  delete MovimientoDetalle
  delete MovimientoEncabezado
  delete OrdenCompraDetalle
  delete OrdenCompraEncabezado
  --delete OrdenCompraEstado
  --delete Permiso
  delete PermisoBitacora
  delete ProformaDetalle
  delete ProformaEncabezado
  --delete ProformaTipo
  --delete ProformaTipoEntrega
  delete Proveedor
  delete RecargaOperacion
  delete RecargaTelefonica
  delete ResultadoTomaFisica
  delete SubCategoria
  --delete Sucursal
  --delete SucursalParametro
  --delete sysdiagrams
  --delete Tarjeta
  --delete TipoAcumulacion
  delete TipoCambio
  --delete TipoDocumento
  --delete TipoMovimiento
  --delete TipoPago
  --delete TipoVenta
  delete TrasladoDetalle
  delete TrasladoEncabezado
  delete UnidadMedida
  delete Usuario where Usuario_Id <> 'jtrejos'
  delete UsuarioPermiso where Usuario_Id <> 'jtrejos'
  delete Vendedor

end  
GO
/****** Object:  StoredProcedure [dbo].[PreFacturasPendientes]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[PreFacturasPendientes]
(@pEmp_Id smallint
,@pSuc_Id smallint)
as
begin
  begin try

    declare @MinutosPrefactura smallint
    
    select @MinutosPrefactura = MinutosPrefactura 
    from EmpresaParametro 
    where Emp_Id = @pEmp_Id 
    
    
    --Elimina detalle de la prefactura
    delete a
    from  PreFacturaDetalle a,
          PreFacturaEncabezado b
    where a.Emp_Id        = b.Emp_Id 
    and   a.Suc_Id        = b.Suc_Id 
    and   a.Caja_Id       = b.Caja_Id 
    and   a.TipoDoc_Id    = b.TipoDoc_Id 
    and   a.Documento_Id  = b.Documento_Id 
    and   DATEDIFF (MINUTE,b.Fecha,getdate()) > @MinutosPrefactura
    if @@ERROR<>0 begin
      raiserror ('Error eliminando detalle de prefactura', 16, 1)
    end    
    
    
    --Elimina encabezado de la prefactura
    delete PreFacturaEncabezado
    where DATEDIFF (MINUTE,Fecha,getdate()) > @MinutosPrefactura
    if @@ERROR<>0 begin
      raiserror ('Error eliminando encabezado de prefactura', 16, 1)
    end    
    


    select Emp_Id 
          ,Suc_Id
          ,Caja_Id 
          ,TipoDoc_Id 
          ,Documento_Id 
          ,Fecha 
          ,Nombre 
          ,TotalCobrado 
          ,DATEDIFF (MINUTE,Fecha,getdate())
    from  PreFacturaEncabezado 
    where Emp_Id = @pEmp_Id 
    and   Suc_Id = @pSuc_Id 
    order by Fecha asc
    
  end try
  begin catch

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch    

end

GO
/****** Object:  StoredProcedure [dbo].[ProformasPendientes]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ProformasPendientes]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pTipoDoc_Id smallint
,@pTipo smallint
,@pTipoBusqueda smallint
,@pFecha datetime
,@pNombre varchar(50))
as
begin
  begin try
  
    create table #ProformasVencidas
      (Emp_Id       smallint not null
      ,Suc_Id       smallint not null
      ,Documento_Id bigint  not null)

    declare  @MinutosPrefactura smallint
            ,@Emp_Id            smallint
            ,@Suc_Id            smallint
            ,@Documento_Id      bigint
            ,@SpResult          int

    
    select @MinutosPrefactura = MinutosPrefactura 
    from EmpresaParametro 
    where Emp_Id = @pEmp_Id 
    
    
    if @MinutosPrefactura >0 begin
    
      --Guarda las prefacturas vencidas
      insert #ProformasVencidas
      select Emp_Id
            ,Suc_Id
            ,Documento_Id
      from  ProformaEncabezado
      where Emp_Id  = @pEmp_Id 
      and		Suc_Id	= @pSuc_Id
      and   DATEDIFF (MINUTE,Fecha,getdate()) > @MinutosPrefactura
      and   Tipo = 3 --Prefacturas
      if @@ERROR<>0 begin
        raiserror ('Error eliminando encabezado de prefactura', 16, 1)
      end    
      

    
      while exists(select 1 from  #ProformasVencidas) begin
          set rowcount 1
          select @Emp_Id = Emp_Id
                ,@Suc_Id = Suc_Id
                ,@Documento_Id = Documento_Id
          from  #ProformasVencidas 
          set rowcount 0
          
          --Elimina la proforma y libera comprometidos si la empresa compromete en la prefactura
          exec @SpResult = EliminaProforma @Emp_Id, @Suc_Id, @Documento_Id 
          if @SpResult<>0 begin
            raiserror ('Error eliminando proforma vencida', 16, 1)
          end    
          
          delete #ProformasVencidas 
          where Emp_Id        = @Emp_Id
          and   Suc_Id        = @Suc_Id
          and   Documento_Id  = @Documento_Id

      end
    end
    

    if @pTipoBusqueda = 1 begin -- Todos
      select a.Emp_Id 
            ,a.Suc_Id
            ,a.Documento_Id 
            ,a.Fecha 
            ,a.Nombre 
            ,a.TotalCobrado 
            ,DATEDIFF (MINUTE,a.Fecha,getdate())
            ,a.Vencimiento
		        ,b.Nombre as TipoDocumento
		        ,c.Nombre as TipoEntregaNombre
		        ,a.FechaEntrega 
		        ,a.Comentario 
		        ,a.TipoDoc_Id 
		        ,d.Telefono1 
		        ,d.Telefono2 
		        ,d.Direccion 
		        ,e.Nombre as ClienteTipo 
		        ,f.Nombre as VendedorNombre
		        ,a.Usuario_Id 
      from  ProformaEncabezado a, 
            ProformaTipo b,
            ProformaTipoEntrega c,
            Cliente d,
            ClientePrecio e,
            Vendedor f
      where	a.Emp_Id		      = b.Emp_Id
	    and		a.Tipo			      = b.Tipo
	    and   a.Emp_Id          = c.Emp_Id 
	    and   a.TipoEntrega_Id  = c.TipoEntrega_Id 
	    and   a.Emp_Id          = d.Emp_Id
	    and   a.Cliente_Id      = d.Cliente_Id 
	    and   d.Emp_Id          = e.Emp_Id 
	    and   d.Precio_Id       = e.Precio_Id 
	    and   a.Emp_Id          = f.Emp_Id 
	    and   a.Vendedor_Id     = f.Vendedor_Id 
	    and		a.Emp_Id		= @pEmp_Id 
      and		a.Suc_Id		= @pSuc_Id 
      and		a.TipoDoc_Id	= @pTipoDoc_Id
	    and		a.Tipo			= @pTipo 
      order by a.FechaEntrega asc
    end
    
    
    if @pTipoBusqueda = 2 begin -- Fecha
      select a.Emp_Id 
            ,a.Suc_Id
            ,a.Documento_Id 
            ,a.Fecha 
            ,a.Nombre 
            ,a.TotalCobrado 
            ,DATEDIFF (MINUTE,a.Fecha,getdate())
            ,a.Vencimiento
		        ,b.Nombre as TipoDocumento
		        ,c.Nombre as TipoEntregaNombre
		        ,a.FechaEntrega 
		        ,a.Comentario 
		        ,a.TipoDoc_Id 
		        ,d.Telefono1 
		        ,d.Telefono2 
		        ,d.Direccion 
		        ,e.Nombre as ClienteTipo 
		        ,f.Nombre as VendedorNombre
		        ,a.Usuario_Id 
      from  ProformaEncabezado a, 
            ProformaTipo b,
            ProformaTipoEntrega c,
            Cliente d,
            ClientePrecio e,
            Vendedor f
      where	a.Emp_Id		      = b.Emp_Id
	    and		a.Tipo			      = b.Tipo
	    and   a.Emp_Id          = c.Emp_Id 
	    and   a.TipoEntrega_Id  = c.TipoEntrega_Id 
	    and   a.Emp_Id          = d.Emp_Id
	    and   a.Cliente_Id      = d.Cliente_Id 
	    and   d.Emp_Id          = e.Emp_Id 
	    and   d.Precio_Id       = e.Precio_Id 
	    and   a.Emp_Id          = f.Emp_Id 
	    and   a.Vendedor_Id     = f.Vendedor_Id 
	    and		a.Emp_Id		= @pEmp_Id 
      and		a.Suc_Id		= @pSuc_Id 
      and		a.TipoDoc_Id	= @pTipoDoc_Id
	    and		a.Tipo			= @pTipo 
	    and   convert(varchar(10), a.FechaEntrega, 111) = convert(varchar(10), @pFecha, 111)
      order by a.FechaEntrega asc
    end
    
    if @pTipoBusqueda = 3 begin -- Nombre
      select a.Emp_Id 
            ,a.Suc_Id
            ,a.Documento_Id 
            ,a.Fecha 
            ,a.Nombre 
            ,a.TotalCobrado 
            ,DATEDIFF (MINUTE,a.Fecha,getdate())
            ,a.Vencimiento
		        ,b.Nombre as TipoDocumento
		        ,c.Nombre as TipoEntregaNombre
		        ,a.FechaEntrega 
		        ,a.Comentario 
		        ,a.TipoDoc_Id 
		        ,d.Telefono1 
		        ,d.Telefono2 
		        ,d.Direccion 
		        ,e.Nombre as ClienteTipo 
		        ,f.Nombre as VendedorNombre
		        ,a.Usuario_Id 
      from  ProformaEncabezado a, 
            ProformaTipo b,
            ProformaTipoEntrega c,
            Cliente d,
            ClientePrecio e,
            Vendedor f
      where	a.Emp_Id		      = b.Emp_Id
	    and		a.Tipo			      = b.Tipo
	    and   a.Emp_Id          = c.Emp_Id 
	    and   a.TipoEntrega_Id  = c.TipoEntrega_Id 
	    and   a.Emp_Id          = d.Emp_Id
	    and   a.Cliente_Id      = d.Cliente_Id 
	    and   d.Emp_Id          = e.Emp_Id 
	    and   d.Precio_Id       = e.Precio_Id 
	    and   a.Emp_Id          = f.Emp_Id 
	    and   a.Vendedor_Id     = f.Vendedor_Id 
	    and		a.Emp_Id		= @pEmp_Id 
      and		a.Suc_Id		= @pSuc_Id 
      and		a.TipoDoc_Id	= @pTipoDoc_Id
	    and		a.Tipo			= @pTipo 
	    and   a.Nombre like '%' + @pNombre + '%'
      order by a.FechaEntrega asc
    end
    
  end try
  begin catch

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch    

end


GO
/****** Object:  StoredProcedure [dbo].[RebajaSumaIventario]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RebajaSumaIventario]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint
,@pArt_Id varchar(13)
,@pCantidad float
,@pDetalle varchar(200)
,@pUsuario_Id varchar(20)) --Si es una devolucion el monto viene negativo
as
begin
  --Jimmy Trejos Valverde 13/May/2012 09:00 am
  begin try
    declare  @SpResult						int
            ,@Suelto							bit          --Indicador de si es un suelto
            ,@ArtPadre						varchar(13)  --Codigo del artículo padre
            ,@FactorConversion		smallint     --Cantidad de unidades de la caja
            ,@SaldoActual					float        --Saldo actual del producto
            ,@SaldoSueltoTmp			float        --Suma del saldo actual de suelto + cantidad        
            ,@CantidadCajas				int          --Cantidad total de suma-resta de cajas
            ,@CantidadSueltos			float        --Cantidad total de suma-resta de sueltos
            ,@Servicio						int          --Indica si es un servicio
            ,@CantidadCajasKardex int					 --Cantidad Cajas Kardex
            ,@DetalleKardex				varchar(200)
            
            
    --Inicializa variables
    set @SaldoActual					= 0
    set @SaldoSueltoTmp				= 0
    set @CantidadCajas				= 0
    set @CantidadSueltos			= 0
    set @CantidadCajasKardex	= 0
    
    
    
    --Busca si se trata de un articulo suelto
    select @Suelto   = Suelto
          ,@ArtPadre = ArtPadre
          ,@Servicio = Servicio 
    from  Articulo
    where Emp_Id = @pEmp_Id
    and   Art_Id = @pArt_Id
    if @@error <> 0  begin
      raiserror ('Error buscando artículo padre, articulo: %s', 16, 1, @pArt_Id)  
    end
    
    --Hace el rebajo de inventario solo si es un servicio    
    if @Servicio = 0 begin
      if @Suelto = 0 begin
        --Si es una caja se le suma o resta normal la cantidad al inventario
        
        --Crea el Kardex para cada articulo
        exec @SpResult = GuardaArticuloKardex @pEmp_Id, @pSuc_Id, @pBod_Id, @pArt_Id, @pCantidad, @pDetalle, @pUsuario_Id, 0
        if @@error <> 0  begin
          raiserror ('Error buscando ejecutando GuardaArticuloKardex, articulo: %s', 16, 1, @pArt_Id)  
        end
        
        --Si es devolucion la cantidad viene negativo
        update ArticuloBodega set  Saldo              = Saldo - @pCantidad
                                  ,UltimaModificacion = getdate()
        where Emp_Id = @pEmp_Id
        and   Suc_Id = @pSuc_Id
        and   Bod_Id = @pBod_Id             
        and   Art_Id = @pArt_Id
        if @@error <> 0  begin
          raiserror ('Error rebajando de inventario, articulo: %s', 16, 1, @pArt_Id)  
        end    
      end
      else begin
        --Busca el factor de conversion de la caja (padre)
        select @FactorConversion = FactorConversion
        from  Articulo
        where Emp_Id = @pEmp_Id
        and   Art_Id = @ArtPadre
        if @@error <> 0  begin
          raiserror ('Error buscando factor de conversion, articulo: %s', 16, 1, @pArt_Id)  
        end
        
        --Busca el saldo actual del suelto
        select @SaldoActual = Saldo
        from  ArticuloBodega
        where Emp_Id = @pEmp_Id
        and   Suc_Id = @pSuc_Id
        and   Bod_Id = @pBod_Id             
        and   Art_Id = @pArt_Id
        if @@error <> 0 or @@rowcount = 0 begin
          raiserror ('Error buscando saldo actual, articulo: %s', 16, 1, @pArt_Id)  
        end
        
        
        if @pCantidad > 0 begin --Si es una salida de inventario
          --Le resta los sueltos al saldo actual
          set @SaldoSueltoTmp = @SaldoActual - @pCantidad
          --Calcula la cantidad de cajas que debe rebajar
          set @CantidadCajas  = abs(@SaldoSueltoTmp)/@FactorConversion
          --Le quita el equivalente en sueltos a las cajas que desea rebajar
          set @CantidadSueltos = @SaldoSueltoTmp + (@CantidadCajas*@FactorConversion)
          
          --Si la cantidad de sueltos es negativa quiere decir que tiene que 
          --abrir una caja, entonces rebaja otra caja y calcula los suletos que quedan
          if @CantidadSueltos<0 begin
            set @CantidadCajas   = @CantidadCajas + 1
            set @CantidadSueltos = @CantidadSueltos + @FactorConversion
          end
          
          --Rebaja la cantidad de cajas
          if @CantidadCajas>0 begin
						set @DetalleKardex = @pDetalle + ' - Ajuste Sueltos (Resta)'
          
            --Crea el Kardex para la caja
            exec @SpResult = GuardaArticuloKardex @pEmp_Id, @pSuc_Id, @pBod_Id, @ArtPadre, @CantidadCajas, @DetalleKardex, @pUsuario_Id, 0
            if @@error <> 0  begin
              raiserror ('Error buscando ejecutando GuardaArticuloKardex, articulo: %s', 16, 1, @pArt_Id)  
            end          
          
            update ArticuloBodega set  Saldo              = Saldo - @CantidadCajas
                                      ,UltimaModificacion = getdate()
            where Emp_Id = @pEmp_Id
            and   Suc_Id = @pSuc_Id
            and   Bod_Id = @pBod_Id             
            and   Art_Id = @ArtPadre
            if @@error <> 0  begin
              raiserror ('Error rebajando de inventario, articulo: %s', 16, 1, @pArt_Id)  
            end            
          end
          
          --Actualiza la cantidad de sueltos
          update ArticuloBodega set  Saldo              = @CantidadSueltos
                                    ,UltimaModificacion = getdate()
          where Emp_Id = @pEmp_Id
          and   Suc_Id = @pSuc_Id
          and   Bod_Id = @pBod_Id             
          and   Art_Id = @pArt_Id
          if @@error <> 0  begin
            raiserror ('Error rebajando de inventario, articulo: %s', 16, 1, @pArt_Id)  
          end
          
          --Crea el Kardex para el suelto
          exec @SpResult = GuardaArticuloKardex @pEmp_Id, @pSuc_Id, @pBod_Id, @pArt_Id, @pCantidad, @pDetalle, @pUsuario_Id, 1
          if @@error <> 0  begin
            raiserror ('Error buscando ejecutando GuardaArticuloKardex, articulo: %s', 16, 1, @pArt_Id)  
          end          
          
        end     
        else begin --Si es una entrada al inventario
          --Le suma los sueltos al saldo actual
          set @SaldoSueltoTmp = @SaldoActual + (-@pCantidad)
          --Calcula la cantidad de cajas que debe agregar
          set @CantidadCajas  = abs(@SaldoSueltoTmp)/@FactorConversion
          --Le quita el equivalente en sueltos a las cajas que desea rebajar
          set @CantidadSueltos = @SaldoSueltoTmp - (@CantidadCajas*@FactorConversion)
          
          --Suma la cantidad de cajas
          if @CantidadCajas>0 begin
            --Crea el Kardex para la caja
            set @DetalleKardex = @pDetalle + ' - Ajuste Sueltos (Suma)'
            set @CantidadCajasKardex = (@CantidadCajas * -1)
            
            exec @SpResult = GuardaArticuloKardex @pEmp_Id, @pSuc_Id, @pBod_Id, @ArtPadre, @CantidadCajasKardex, @DetalleKardex, @pUsuario_Id, 0
            if @@error <> 0  begin
              raiserror ('Error buscando ejecutando GuardaArticuloKardex, articulo: %s', 16, 1, @pArt_Id)  
            end    
          
            update ArticuloBodega set  Saldo              = Saldo + @CantidadCajas
                                      ,UltimaModificacion = getdate()
            where Emp_Id = @pEmp_Id
            and   Suc_Id = @pSuc_Id
            and   Bod_Id = @pBod_Id             
            and   Art_Id = @ArtPadre
            if @@error <> 0  begin
              raiserror ('Error rebajando de inventario, articulo: %s', 16, 1, @pArt_Id)  
            end            
          end
          
          --Actualiza la cantidad de sueltos
          update ArticuloBodega set  Saldo              = @CantidadSueltos
                                    ,UltimaModificacion = getdate()
          where Emp_Id = @pEmp_Id
          and   Suc_Id = @pSuc_Id
          and   Bod_Id = @pBod_Id             
          and   Art_Id = @pArt_Id
          if @@error <> 0  begin
            raiserror ('Error rebajando de inventario, articulo: %s', 16, 1, @pArt_Id)  
          end
          
          --Crea el Kardex para el suelto
          exec @SpResult = GuardaArticuloKardex @pEmp_Id, @pSuc_Id, @pBod_Id, @pArt_Id, @pCantidad, @pDetalle, @pUsuario_Id, 1
          if @@error <> 0  begin
            raiserror ('Error buscando ejecutando GuardaArticuloKardex, articulo: %s', 16, 1, @pArt_Id)  
          end           
                        
        end 
      end --Fin suelto
    end --Fin Servicio

  end try
  begin catch

    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch    
end

GO
/****** Object:  StoredProcedure [dbo].[RecalculoExentoGravado]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RecalculoExentoGravado]
as
begin
  create table #Facturas(Emp_Id smallint NOT NULL,
	                       Suc_Id smallint NOT NULL,
	                       Caja_Id smallint NOT NULL,
	                       TipoDoc_Id smallint NOT NULL,
	                       Documento_Id bigint NOT NULL)
	                       
	                       
  declare  @Emp_Id        smallint
          ,@Suc_Id        smallint
          ,@Caja_Id       smallint
          ,@TipoDoc_Id    smallint
          ,@Documento_Id  bigint
          ,@Exento        money
          ,@Gravado       money


  insert #Facturas 
        (Emp_Id
        ,Suc_Id
        ,Caja_Id
        ,TipoDoc_Id
        ,Documento_Id)
  select Emp_Id
        ,Suc_Id
        ,Caja_Id
        ,TipoDoc_Id
        ,Documento_Id
  from  FacturaEncabezado 
  
  
  while exists(select * from  #Facturas) begin
    set @Exento  = 0
    set @Gravado = 0
  
    set rowcount 1
    select @Emp_Id        = Emp_Id 
          ,@Suc_Id        = Suc_Id 
          ,@Caja_Id       = Caja_Id 
          ,@TipoDoc_Id    = TipoDoc_Id 
          ,@Documento_Id  = Documento_Id 
    from #Facturas
    set rowcount 0
    
    
    select @Exento  = sum(case when ExentoIV = 1 then Cantidad * Precio else 0 end)
          ,@Gravado = sum(case when ExentoIV = 0 then Cantidad * Precio else 0 end)
    from FacturaDetalle
    where Emp_Id        = @Emp_Id 
    and   Suc_Id        = @Suc_Id 
    and   Caja_Id       = @Caja_Id 
    and   TipoDoc_Id    = @TipoDoc_Id 
    and   Documento_Id  = @Documento_Id 
    
    
    update FacturaEncabezado set Exento   = @Exento 
                                ,Gravado  = @Gravado 
    where Emp_Id        = @Emp_Id 
    and   Suc_Id        = @Suc_Id 
    and   Caja_Id       = @Caja_Id 
    and   TipoDoc_Id    = @TipoDoc_Id 
    and   Documento_Id  = @Documento_Id     
    
    
    delete #Facturas 
    where Emp_Id        = @Emp_Id 
    and   Suc_Id        = @Suc_Id 
    and   Caja_Id       = @Caja_Id 
    and   TipoDoc_Id    = @TipoDoc_Id 
    and   Documento_Id  = @Documento_Id 
    
    
  end
  
end

GO
/****** Object:  StoredProcedure [dbo].[RepCierreDetalle]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RepCierreDetalle]
(@pEmp_Id		smallint
,@pSuc_Id		smallint
,@pCaja_Id		smallint
,@pCierre_Id	int)
as
begin
	CREATE TABLE #Detalle(
	Emp_Id smallint NOT NULL,
	Suc_Id smallint NOT NULL,
	Caja_Id smallint NOT NULL,
	Cierre_Id int NOT NULL,
	Detalle_Id int NOT NULL,
	TipoDoc_Id smallint NOT NULL,
	Documento_Id bigint NOT NULL,
	Pago_Id smallint NOT NULL,
	TipoPago_Id smallint NOT NULL,
	Monto money NOT NULL,
	Banco_Id smallint NULL,
	ChequeNumero varchar(20) NOT NULL,
	Tarjeta_Id smallint NULL,
	TarjetaNumero varchar(16) NOT NULL,
	TarjetaAutorizacion varchar(16) NOT NULL,
	CxC bit NOT NULL,
	NombreTipoDocumento varchar(50) NOT NULL,
	NombreTipoPago varchar(50) NOT NULL,
	NombreBanco varchar(50) NOT NULL)

	insert #Detalle
			(Emp_Id
			,Suc_Id
			,Caja_Id
			,Cierre_Id
			 ,Detalle_Id
			,TipoDoc_Id
			,Documento_Id
			,Pago_Id
			,TipoPago_Id
			,Monto
			,Banco_Id
			,ChequeNumero
			,Tarjeta_Id
			,TarjetaNumero
			,TarjetaAutorizacion
			,CxC
			,NombreTipoDocumento
			,NombreTipoPago
			,NombreBanco)
	select	 a.Emp_Id
			,a.Suc_Id
			,a.Caja_Id
			,a.Cierre_Id
			,a.Detalle_Id
			,a.TipoDoc_Id
			,a.Documento_Id
			,a.Pago_Id
			,a.TipoPago_Id
			,a.Monto
			,a.Banco_Id
			,a.ChequeNumero
			,a.Tarjeta_Id
			,a.TarjetaNumero
			,a.TarjetaAutorizacion
			,a.CxC
			,b.Nombre
			,c.Nombre
			,''
	From	CajaCierreDetalle a, 
			TipoDocumento b, 
			TipoPago c 
	Where	a.Emp_Id		= b.Emp_Id 
	and		a.TipoDoc_Id	= b.TipoDoc_Id 
	and		a.Emp_Id		= c.Emp_Id 
	and		a.TipoPago_Id = c.TipoPago_Id  
	And		a.Emp_Id		= @pEmp_Id 
	And		a.Suc_Id		= @pSuc_Id 
	And		a.Caja_Id		= @pCaja_Id 
	And		a.Cierre_Id		= @pCierre_Id 
	Order by 
		a.TipoPago_Id asc, a.Documento_Id asc


	update a set a.NombreBanco = b.Nombre 
	from
		#Detalle a,
		Banco    b
	where	a.Emp_Id		= b.Emp_Id 
	and		a.Banco_Id		= b.Banco_Id
	and		a.TipoPago_Id	= 3


	select *
	from	#Detalle 

end

GO
/****** Object:  StoredProcedure [dbo].[RetornaTipoCambio]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RetornaTipoCambio]

as

begin

 

      declare  @Fecha datetime

                             ,@Compra money

                             ,@Venta money

     

      select @Fecha  = cast(convert(varchar(10),Fecha, 112) as datetime)

                        ,@Compra = Compra

                        ,@Venta  = Venta

      from  TipoCambio

      where Fecha =(select max(Fecha)

                                               from  TipoCambio)

      if @@rowcount = 0 begin

            set @Fecha = cast(convert(varchar(10),getdate(), 112) as datetime)    

            set @Compra = 1

            set @Venta  = 1

      end

     

     

      select @Fecha as Fecha

                        ,@Compra as Compra

                        ,@Venta as Venta

 

end

GO
/****** Object:  StoredProcedure [dbo].[RptAjusteInventario]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RptAjusteInventario]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pTipoMov_Id smallint
,@pMov_Id int)
as
begin

  select a.TipoMov_Id
        ,d.Nombre as TipoMovNombre
        ,a.Bod_Id
        ,c.Nombre as BodegaNombre
        ,a.Mov_Id
        ,a.Fecha
        ,a.Comentario
        ,a.Aplicado
        ,isnull(a.AplicaUsuario_Id, '') as AplicaUsuario_Id
        ,a.AplicaFecha
        ,a.Costo as TotalCosto
        ,b.Detalle_Id
        ,b.Art_Id
        ,e.Nombre as ArticuloNombre
        ,b.Cantidad
        ,b.Costo
        ,b.TotalLinea
  from  MovimientoEncabezado a,
        MovimientoDetalle    b,
        Bodega               c,
        TipoMovimiento       d,
        Articulo             e
  where a.Emp_Id      = b.Emp_Id
  and   a.Suc_Id      = b.Suc_Id
  and   a.TipoMov_Id  = b.TipoMov_Id
  and   a.Mov_Id      = b.Mov_Id
  and   a.Emp_Id      = d.Emp_Id
  and   a.TipoMov_Id  = d.TipoMov_Id
  and   a.Emp_Id      = c.Emp_Id
  and   a.Suc_Id      = c.Suc_Id
  and   a.Bod_Id      = c.Bod_Id
  and   b.Emp_Id      = e.Emp_Id
  and   b.Art_Id      = e.Art_Id
  and   a.Emp_Id      = @pEmp_Id
  and   a.Suc_Id      = @pSuc_Id
  and   a.TipoMov_Id  = @pTipoMov_Id
  and   a.Mov_Id      = @pMov_Id
  order by e.Nombre asc
  
end

GO
/****** Object:  StoredProcedure [dbo].[RptArticuloKardex]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RptArticuloKardex]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint
,@pArt_Id varchar(13)
,@pUsuarioIni varchar(20)
,@pUsuarioFin varchar(20)
,@pFechaIni datetime
,@pFechaFin datetime)
as
begin
  begin try
  
    declare  @Nombre varchar(50)
            ,@Saldo float
            ,@ArtSuelto_Id varchar(13)
            ,@SaldoSuelto float
            
            
    select   @Nombre = ''
            ,@Saldo = 0
            ,@ArtSuelto_Id = ''
            ,@SaldoSuelto = 0
    
    --Busca los datos del articulo
    select @Nombre = a.Nombre 
          ,@Saldo  = b.Saldo  
    from  Articulo a,
          ArticuloBodega b
    where a.Emp_Id = b.Emp_Id
    and   a.Art_Id = b.Art_Id 
    and   b.Emp_Id = @pEmp_Id 
    and   b.Suc_Id = @pSuc_Id
    and   b.Bod_Id = @pBod_Id 
    and   b.Art_Id = @pArt_Id 
    if @@ROWCOUNT = 0 or @@ERROR <> 0 begin
        raiserror ('Error buscando datos de articulo', 16, 1)  
    end
    
    --Verifica si el articulo tiene definido un suelto
    select @ArtSuelto_Id = Art_Id 
    from  Articulo 
    where Emp_Id    = @pEmp_Id 
    and   ArtPadre  = @pArt_Id
    if @@ROWCOUNT > 0 begin
      --Busca 
      select @SaldoSuelto = Saldo 
      from  ArticuloBodega 
      where Emp_Id = @pEmp_Id 
      and   Suc_Id = @pSuc_Id
      and   Bod_Id = @pBod_Id 
      and   Art_Id = @ArtSuelto_Id 
    end
    else begin
      set @ArtSuelto_Id = null
      set @SaldoSuelto  = null
    end
    


    
    select @pArt_Id as Art_Id
          ,@Nombre as Nombre
          ,@Saldo as SaldoPadre
          ,@ArtSuelto_Id as ArtSuelto_Id
          ,@SaldoSuelto as  SaldoSuelto
          ,a.Fecha
          ,a.Detalle
          ,b.Usuario_Id
          ,b.Nombre as NombreUsuario
          ,a.Saldo as SaldoDetalle
          ,a.Cantidad          
          ,a.Cantidad + a.Saldo as SaldoLineaNuevo
    from  ArticuloKardex a,
          Usuario b
    where a.Emp_Id      = b.Emp_Id 
    and   a.Usuario_Id  = b.Usuario_Id 
    and   a.Emp_Id      = @pEmp_Id 
    and   a.Suc_Id      = @pSuc_Id
    and   a.Bod_Id      = @pBod_Id 
    and   a.Art_Id      = @pArt_Id
    and   a.Usuario_Id >= @pUsuarioIni 
    and   a.Usuario_Id <= @pUsuarioFin 
    and   a.Fecha      >= @pFechaIni 
    and   a.Fecha       < @pFechaFin
    order by a.Kardex_Id Asc
    
              
    
    select @pArt_Id  as Art_Id
          ,@Nombre as Nombre
          ,@Saldo  as Saldo
          ,@ArtSuelto_Id as ArtSuelto
          ,@SaldoSuelto as SaldoSuelto
    
  end try
  begin catch
  
 
    declare @ErrorMessage nvarchar(4000);
    declare @ErrorSeverity int;
    declare @ErrorState int;

    select @ErrorMessage  = error_message(),
           @ErrorSeverity = error_severity(),
           @ErrorState    = error_state();

    raiserror (@ErrorMessage , @ErrorSeverity, @ErrorState)

  end catch    
end

GO
/****** Object:  StoredProcedure [dbo].[RptArticulosListado]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RptArticulosListado]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint)
as
begin

  select d.Nombre as NonbreSubCat
        ,c.Nombre as NombreCat
        ,a.Art_Id
        ,a.Nombre as NombreArt
        ,b.Precio 
        ,b.PrecioMayorista  
  from  Articulo a 
        inner join  ArticuloBodega b on a.Emp_Id = b.Emp_Id 
        and a.Art_Id = b.Art_Id 
        inner join  Categoria c on a.Emp_Id = c.Emp_Id 
        and a.Cat_Id = c.Cat_Id
        inner join  SubCategoria d on a.Emp_Id = d.Emp_Id 
        and a.Cat_Id    = d.Cat_Id
        and a.SubCat_Id = d.SubCat_Id 
  where b.Emp_Id    = @pEmp_Id 
  and   b.Suc_Id    = @pSuc_Id
  and   b.Bod_Id    = @pBod_Id 
  and   a.Servicio  = 0
  and   a.Activo    = 1
  order by
     d.Nombre asc
    ,c.Nombre asc
    ,a.Nombre asc
  
    
    
        

end


GO
/****** Object:  StoredProcedure [dbo].[RptArticulosPrefacturados]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RptArticulosPrefacturados]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint)
as
begin

  select   a.Documento_Id 
          ,a.Nombre 
          ,a.Fecha 
          ,a.TotalCobrado 
          ,b.Art_Id 
          ,c.Nombre as ArtNombre
          ,b.Cantidad 
          ,b.TotalLinea 
  from  ProformaEncabezado a,
        ProformaDetalle b,
        Articulo c
  where a.Emp_Id        = b.Emp_Id 
  and   a.Suc_Id        = b.Suc_Id
  and   a.Documento_Id  = b.Documento_Id 
  and   a.Emp_Id        = c.Emp_Id 
  and   b.Art_Id        = c.Art_Id 
  and   a.Emp_Id        = @pEmp_Id 
  and   a.Suc_Id        = @pSuc_Id 
  and   a.Bod_Id        = @pBod_Id 
  
end

GO
/****** Object:  StoredProcedure [dbo].[RptArticulosPromedioVenta]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RptArticulosPromedioVenta]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint
,@pPromedio float)
as
begin

  select a.Art_Id 
        ,a.Nombre 
        ,b.Costo 
        ,b.Precio 
        ,b.PromedioVenta 
        ,b.Saldo 
  from  Articulo a,
        ArticuloBodega b
  where a.Emp_Id = b.Emp_Id 
  and   a.Art_Id = b.Art_Id 
  and   b.Emp_Id = @pEmp_Id
  and   b.Suc_Id = @pSuc_Id 
  and   b.Bod_Id = @pBod_Id
  and   b.PromedioVenta >= @pPromedio 
  order by 
        b.PromedioVenta desc
             
end

GO
/****** Object:  StoredProcedure [dbo].[RptArticulosPromedioVentaFecha]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RptArticulosPromedioVentaFecha]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint
,@pPromedio float
,@pFechaIni datetime
,@pFechaFin datetime)
as
begin

  declare @Dias smallint

  select @pFechaFin = DATEADD(day,1,@pFechaFin)
  select @Dias      = DATEDIFF(day,@pFechaIni,@pFechaFin)

  select b.Art_Id
        ,c.Nombre
        ,b.Costo 
        ,b.Precio 
        ,sum (b.Cantidad ) / @Dias as PromedioVenta
  from  FacturaEncabezado a,
        FacturaDetalle b,
        Articulo c
  where a.Emp_Id        =  b.Emp_Id
  and   a.Suc_Id        =  b.Suc_Id 
  and   a.Caja_Id       =  b.Caja_Id 
  and   a.TipoDoc_Id    =  b.TipoDoc_Id 
  and   a.Documento_Id  =  b.Documento_Id 
  and   b.Emp_Id        =  c.Emp_Id
  and   b.Art_Id        =  c.Art_Id 
  and   a.Emp_Id        =  @pEmp_Id 
  and   a.Suc_Id        =  @pSuc_Id 
  and   a.Bod_Id        =  @pBod_Id 
  and   b.Fecha         >= @pFechaIni 
  and   b.Fecha         <  dateadd(day,1,@pFechaFin)
  group by 
        b.Art_Id, c.Nombre, b.Costo, b.Precio 
  having
        sum (b.Cantidad)>= @pPromedio
  order by
        sum (b.Cantidad) desc
      
end

GO
/****** Object:  StoredProcedure [dbo].[RptCliente]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RptCliente]
(@pEmp_Id smallint
,@pPrecio_Id smallint)
as
begin

  if @pPrecio_Id >= 0 begin
    select a.Cliente_Id
          ,a.Nombre 
          ,a.Email 
          ,a.Telefono1 
          ,a.Telefono2 
          ,a.Direccion 
          ,b.Nombre as NombrePrecio
    from  Cliente a,
          ClientePrecio b
    where a.Emp_Id    = b.Emp_Id 
    and   a.Precio_Id = b.Precio_Id 
    and   a.Activo    = 1
    and   a.Precio_Id = @pPrecio_Id     
    order by 
      a.Nombre asc
  end
  else begin
    select a.Cliente_Id
          ,a.Nombre 
          ,a.Email 
          ,a.Telefono1 
          ,a.Telefono2 
          ,a.Direccion 
          ,b.Nombre as NombrePrecio
    from  Cliente a,
          ClientePrecio b
    where a.Emp_Id    = b.Emp_Id 
    and   a.Precio_Id = b.Precio_Id 
    and   a.Activo    = 1
    order by 
      a.Nombre asc
  end      
  
end

GO
/****** Object:  StoredProcedure [dbo].[RptCxCSaldosxCliente]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RptCxCSaldosxCliente]
(@pEmp_Id smallint
,@pSaldo money)
as
begin

  select *
  from Cliente 
  where Emp_Id  = @pEmp_Id 
  and   Saldo  >= @pSaldo 
  order by 
    Nombre asc

end

GO
/****** Object:  StoredProcedure [dbo].[RptEntradaMercaderia]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RptEntradaMercaderia]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pEntrada_Id int)
as
begin

  select a.Entrada_Id
        ,a.Bod_Id
        ,c.Nombre as BodegaNombre
        ,a.Prov_Id
        ,f.Nombre as ProveedorNombre
        ,a.Fecha
        ,a.Comentario
        ,a.EntradaEstado_Id
        ,d.Nombre as EntradaEstadoNombre
        ,isnull(a.AplicaUsuario_Id, '') as AplicaUsuario_Id
        ,a.AplicaFecha
        ,a.SubTotal
        ,a.Descuento
        ,a.IV
        ,a.Total
        ,a.TotalBonificacion
        ,b.Detalle_Id
        ,b.Art_Id
        ,e.Nombre as ArticuloNombre
        ,b.Cantidad
        ,b.CantidadBonificada
        ,b.Costo
        ,b.PorcDescuento
        ,b.MontoDescuento
        ,b.MontoIV
        ,b.TotalLinea
        ,b.TotalLineaBonificada
        ,b.ExentoIV
  from  EntradaEncabezado a,
        EntradaDetalle    b,
        Bodega            c,
        EntradaEstado     d,
        Articulo          e,
        Proveedor         f
  where a.Emp_Id         = b.Emp_Id
  and   a.Suc_Id         = b.Suc_Id
  and   a.Entrada_Id       = b.Entrada_Id
  and   a.Emp_Id         = c.Emp_Id
  and   a.Suc_Id         = c.Suc_Id
  and   a.Bod_Id         = c.Bod_Id
  and   a.Emp_Id         = d.Emp_Id
  and   a.EntradaEstado_Id = d.EntradaEstado_Id
  and   b.Emp_Id         = e.Emp_Id
  and   b.Art_Id         = e.Art_Id
  and   a.Emp_Id         = f.Emp_Id
  and   a.Prov_Id        = f.Prov_Id
  and   a.Emp_Id         = @pEmp_Id
  and   a.Suc_Id         = @pSuc_Id
  and   a.Entrada_Id       = @pEntrada_Id
  
end

GO
/****** Object:  StoredProcedure [dbo].[RptEntradaMercaderiaxFecha]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RptEntradaMercaderiaxFecha]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pFecha_Ini datetime
,@pFecha_Fin datetime)
as
begin
  select a.Prov_Id
        ,b.Nombre
        ,b.CedulaJuridica 
        ,cast(CONVERT (date,a.Fecha) as datetime) as Fecha
        ,sum(a.Subtotal)      as SubTotal
        ,sum(a.Descuento)     as Descuento
        ,sum(a.IV)            as IV
        ,sum(a.Total)         as Total
        ,SUM(a.Exento)        as Exento
        ,SUM(a.Gravado)       as Gravado
  from  EntradaEncabezado  a,
        Proveedor b
  where a.Emp_Id  = b.Emp_Id
  and   a.Prov_Id = b.Prov_Id 
  and   a.Emp_Id = @pEmp_Id 
  and   a.Suc_Id = @pSuc_Id 
  and   a.Fecha  >= @pFecha_Ini 
  and   a.Fecha  <  @pFecha_fin
  and   a.EntradaEstado_Id = 2 --Aplicado
  group by
       a.Prov_Id 
      ,b.Nombre
      ,b.CedulaJuridica  
      ,CONVERT (date,a.Fecha)
  order by 
       a.Prov_Id 
      ,b.Nombre 
      ,b.CedulaJuridica  
      ,CONVERT (date,a.Fecha) desc
     
end

GO
/****** Object:  StoredProcedure [dbo].[RptFacturaCarta1]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RptFacturaCarta1]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pCaja_Id smallint
,@pTipoDoc_Id smallint
,@pDocumento_Id bigint)
as
begin



  select  a.Cliente_Id
         ,a.Nombre
         ,a.Fecha
         ,a.Vendedor_Id
  from  FacturaEncabezado a,
        FacturaDetalle b
  where a.Emp_Id        = b.Emp_Id
  and   a.Suc_Id        = b.Suc_Id 
  and   a.Caja_Id       = b.Caja_Id 
  and   a.TipoDoc_Id    = b.TipoDoc_Id
  and   a.Documento_Id  = b.Documento_Id
  and   a.Emp_Id        = @pEmp_Id
  and   a.Suc_Id        = @pSuc_Id 
  and   a.Caja_Id       = @pCaja_Id 
  and   a.TipoDoc_Id    = @pTipoDoc_Id
  and   a.Documento_Id  = @pDocumento_Id

end

GO
/****** Object:  StoredProcedure [dbo].[RptFacturasDetallado]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RptFacturasDetallado]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pFechaIni datetime
,@pFechaFin datetime)
as
begin

  select d.Nombre as NombreTipoDocumento
        ,a.Caja_Id 
        ,cast(a.Caja_Id as varchar(5)) + ' - ' + CAST(a.Documento_Id as varchar(20)) as Documento_Id
        ,a.Fecha 
        ,a.Nombre 
        ,a.TotalCobrado 
        ,c.Nombre NombreTipoPrecio
  from  FacturaEncabezado a,
        Cliente b,
        ClientePrecio c,
        TipoDocumento d
  where a.Emp_Id      = b.Emp_Id 
  and   a.Cliente_Id  = b.Cliente_Id 
  and   b.Emp_Id      = c.Emp_Id 
  and   b.Precio_Id   = c.Precio_Id 
  and   a.Emp_Id      = d.Emp_Id 
  and   a.TipoDoc_Id  = d.TipoDoc_Id 
  and   a.Emp_Id      = @pEmp_Id 
  and   a.Suc_Id      = @pSuc_Id 
  and   a.Fecha       >= @pFechaIni 
  and   a.Fecha       <= @pFechaFin
  order by Fecha asc

end

GO
/****** Object:  StoredProcedure [dbo].[RptListadoPrecios]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RptListadoPrecios]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint)
as
begin

  select c.SubCat_Id 
        ,c.Nombre 
        ,d.Nombre 
        ,a.Art_Id 
        ,a.Nombre 
        ,b.Precio 
        ,b.PrecioMayorista 
  from  Articulo a,
        ArticuloBodega b,
        SubCategoria c,
        Categoria d
  where a.Emp_Id    = b.Emp_Id
  and   a.Art_Id    = b.Art_Id 
  and   a.Emp_Id    = c.Emp_Id 
  and   a.Cat_Id    = c.Cat_Id 
  and   a.SubCat_Id = c.SubCat_Id 
  and   a.Emp_Id    = d.Emp_Id 
  and   a.Cat_Id    = d.Cat_Id 
  and   b.Emp_Id    = @pEmp_Id
  and   b.Suc_Id    = @pSuc_Id
  and   b.Bod_Id    = @pBod_Id 
  order by 
     c.Nombre asc
    ,d.Nombre  
    ,a.Nombre asc

end


GO
/****** Object:  StoredProcedure [dbo].[RptOrdenCompra]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RptOrdenCompra]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pOrden_Id int)
as
begin

  select a.Orden_Id
        ,a.Bod_Id
        ,c.Nombre as BodegaNombre
        ,a.Prov_Id
        ,f.Nombre as ProveedorNombre
        ,a.Fecha
        ,a.Comentario
        ,a.OrdenEstado_Id
        ,d.Nombre as OrdenEstadoNombre
        ,isnull(a.AplicaUsuario_Id, '') as AplicaUsuario_Id
        ,a.AplicaFecha
        ,a.SubTotal
        ,a.Descuento
        ,a.IV
        ,a.Total
        ,a.TotalBonificacion
        ,b.Detalle_Id
        ,b.Art_Id
        ,e.Nombre as ArticuloNombre
        ,b.Cantidad
        ,b.CantidadBonificada
        ,b.Costo
        ,b.PorcDescuento
        ,b.MontoDescuento
        ,b.MontoIV
        ,b.TotalLinea
        ,b.TotalLineaBonificada
        ,b.ExentoIV
  from  OrdenCompraEncabezado a,
        OrdenCompraDetalle    b,
        Bodega                c,
        OrdenCompraEstado     d,
        Articulo              e,
        Proveedor             f
  where a.Emp_Id         = b.Emp_Id
  and   a.Suc_Id         = b.Suc_Id
  and   a.Orden_Id       = b.Orden_Id
  and   a.Emp_Id         = c.Emp_Id
  and   a.Suc_Id         = c.Suc_Id
  and   a.Bod_Id         = c.Bod_Id
  and   a.Emp_Id         = d.Emp_Id
  and   a.OrdenEstado_Id = d.OrdenEstado_Id
  and   b.Emp_Id         = e.Emp_Id
  and   b.Art_Id         = e.Art_Id
  and   a.Emp_Id         = f.Emp_Id
  and   a.Prov_Id        = f.Prov_Id
  and   a.Emp_Id         = @pEmp_Id
  and   a.Suc_Id         = @pSuc_Id
  and   a.Orden_Id       = @pOrden_Id
  
end

GO
/****** Object:  StoredProcedure [dbo].[RptRecargasTelefonicas]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RptRecargasTelefonicas]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pFechaIni datetime
,@pFechaFin datetime
,@pTelefonoIni varchar(20)
,@pTelefonoFin varchar(20))
as
begin
  declare @FechaInicio datetime
  
  
  create table #Recargas( Emp_Id smallint NOT NULL,
	                        Recarga_Id bigint NOT NULL,
	                        Suc_Id smallint NOT NULL,
	                        Caja_Id smallint NOT NULL,
	                        Cierre_Id int NOT NULL,
	                        Operacion varchar(50) NOT NULL,
	                        NombreOperacion varchar(50) NOT NULL,
	                        Cia varchar(20) NOT NULL,
	                        Telefono varchar(20) NOT NULL,
	                        Monto money NOT NULL,
	                        Detallista varchar(20) NOT NULL,
	                        FechaStr varchar(10) NULL,
	                        Fecha datetime NOT NULL,
	                        Usuario_Id varchar(20) NOT NULL,
	                        Documento bigint NOT NULL,
	                        IdTrans bigint NOT NULL,
	                        Comision money NOT NULL,
	                        Correlativo varchar(20) NULL,
	                        FechaRespuesta datetime NULL,
	                        NumSerie varchar(50) NULL,
	                        DiasExp smallint NULL,
	                        EstadoRecarga varchar(5) NULL,
	                        DetalleRecarga varchar(100) NULL,
	                        ErrorCode varchar(2) NULL,
	                        ErrorDes varchar(100) NULL,
	                        IceTransId varchar(50) NULL,
	                        DistComision money NULL,
	                        Saldo money NULL,
	                        SucursalNombre varchar(50) NULL,
	                        CajaNombre varchar(50) NULL) 
  
  insert #Recargas 
        (Emp_Id
        ,Recarga_Id
        ,Suc_Id
        ,Caja_Id
        ,Cierre_Id
        ,Operacion
        ,NombreOperacion
        ,Cia
        ,Telefono
        ,Monto
        ,Detallista
        ,FechaStr
        ,Fecha
        ,Usuario_Id
        ,Documento
        ,IdTrans
        ,Comision
        ,Correlativo
        ,FechaRespuesta
        ,NumSerie
        ,DiasExp
        ,EstadoRecarga
        ,DetalleRecarga
        ,ErrorCode
        ,ErrorDes
        ,IceTransId
        ,DistComision
        ,Saldo)
  select a.Emp_Id
        ,a.Recarga_Id
        ,a.Suc_Id
        ,a.Caja_Id
        ,a.Cierre_Id
        ,a.Operacion
        ,b.Nombre as NombreOperacion
        ,a.Cia
        ,a.Telefono
        ,a.Monto
        ,a.Detallista
        ,convert(varchar(10),a.Fecha,103) as FechaStr
        ,a.Fecha 
        ,a.Usuario_Id
        ,a.Documento
        ,a.IdTrans
        ,a.Comision
        ,a.Correlativo
        ,a.FechaRespuesta
        ,a.NumSerie
        ,a.DiasExp
        ,a.EstadoRecarga
        ,a.DetalleRecarga
        ,a.ErrorCode
        ,a.ErrorDes
        ,a.IceTransId
        ,a.DistComision
        ,a.Saldo
  from  RecargaTelefonica a,
        RecargaOperacion b
  where a.Operacion = b.Operacion 
  and   a.Emp_Id = @pEmp_Id 
  and   a.Fecha >= @pFechaIni 
  and   a.Fecha <  @pFechaFin 
  and   a.Telefono >= @pTelefonoIni 
  and   a.Telefono <= @pTelefonoFin 
  and	a.ErrorCode = '00'
  order by a.Fecha desc
  
  
  
  update #Recargas set Telefono = LEFT (telefono,4) + '-' + Substring(Telefono ,5,LEN(telefono)-4)
  
  
  update a set a.SucursalNombre = b.Nombre 
  from  #Recargas a,
        Sucursal b 
  where a.Emp_Id = b.Emp_Id
  and   a.Suc_Id = b.Suc_Id 
  
  
  update a set a.CajaNombre  = b.Nombre 
  from  #Recargas a,
        Caja b 
  where a.Emp_Id = b.Emp_Id
  and   a.Suc_Id = b.Suc_Id
  and   a.Caja_Id = b.Caja_Id 
  


  
  
  select * 
  from  #Recargas 
  
  
end

GO
/****** Object:  StoredProcedure [dbo].[RptSaldosInventario]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RptSaldosInventario]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint
,@pCantidad as float)
as
begin

  if @pCantidad<>0 begin
    select a.Art_Id 
          ,a.Nombre 
          ,b.Costo
          ,b.Precio 
          ,b.Saldo 
          ,b.Ubicacion
    from  Articulo a,
          ArticuloBodega b
    where a.Emp_Id  = b.Emp_Id 
    and   a.Art_Id  = b.Art_Id 
    and   b.Emp_Id  = @pEmp_Id 
    and   b.Suc_Id  = @pSuc_Id 
    and   b.Bod_Id  = @pBod_Id 
    and   b.Saldo  >= @pCantidad 
    order by b.Saldo desc
  end
  else begin
    select a.Art_Id 
          ,a.Nombre 
          ,b.Costo
          ,b.Precio 
          ,b.Saldo 
          ,b.Ubicacion
    from  Articulo a,
          ArticuloBodega b
    where a.Emp_Id  = b.Emp_Id 
    and   a.Art_Id  = b.Art_Id 
    and   b.Emp_Id  = @pEmp_Id 
    and   b.Suc_Id  = @pSuc_Id 
    and   b.Bod_Id  = @pBod_Id 
    order by b.Saldo desc
  end

end

GO
/****** Object:  StoredProcedure [dbo].[RptSaldosInventarioProveedor]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[RptSaldosInventarioProveedor]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint
,@pProv_Id smallint
,@pCantidad as float)
as
begin

  select d.Prov_Id 
        ,d.Nombre as NombreProveedor
        ,a.Art_Id 
        ,a.Nombre 
        ,b.Costo
        ,b.Precio 
        ,b.Saldo 
  from  Articulo a,
        ArticuloBodega b,
        ArticuloProveedor c,
        Proveedor d
  where a.Emp_Id  = b.Emp_Id 
  and   a.Art_Id  = b.Art_Id 
  and   a.Emp_Id = c.Emp_Id 
  and   a.Art_Id = c.Art_Id 
  and   c.Emp_Id = d.Emp_Id 
  and   c.Prov_Id = d.Prov_Id 
  and   b.Emp_Id  = @pEmp_Id 
  and   b.Suc_Id  = @pSuc_Id 
  and   b.Bod_Id  = @pBod_Id 
  and   b.Saldo  >= @pCantidad 
  and   c.Prov_Id = @pProv_Id
  order by a.Nombre asc

end

GO
/****** Object:  StoredProcedure [dbo].[RptSaldosInventarioUbicacion]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[RptSaldosInventarioUbicacion]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint
,@pUbicacionIni varchar(20)
,@pUbicacionFin varchar(20))
as
begin

  select a.Art_Id 
        ,a.Nombre 
        ,b.Costo
        ,b.Precio 
        ,b.Saldo
        ,b.Ubicacion 
  from  Articulo a,
        ArticuloBodega b
  where a.Emp_Id  = b.Emp_Id 
  and   a.Art_Id  = b.Art_Id 
  and   b.Emp_Id  = @pEmp_Id 
  and   b.Suc_Id  = @pSuc_Id 
  and   b.Bod_Id  = @pBod_Id 
  and   b.Ubicacion >= @pUbicacionIni 
  and   b.Ubicacion <= @pUbicacionFin 
  order by b.Ubicacion asc, a.Nombre asc

end

GO
/****** Object:  StoredProcedure [dbo].[RptVentasCategoria]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RptVentasCategoria]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pCat_Ini smallint
,@pCat_Fin smallint
,@pFecha_Ini datetime
,@pFecha_Fin datetime)
as
begin
  select CONVERT (varchar(10),a.Fecha,103) as FechaStr
        ,c.Cat_Id
        ,c.Nombre as NombreCategoria 
        ,b.Art_Id 
        ,b.Nombre as NombreArticulo 
        ,a.Cantidad
        ,a.Costo
        ,a.Precio
        ,a.PorcDescuento
        ,a.MontoDescuento
        ,a.MontoIV
        ,a.TotalLinea
        ,a.Fecha 
        ,a.ExentoIV 
  from  FacturaDetalle a,
        Articulo b,
        Categoria c
  where a.Emp_Id = b.Emp_Id 
  and   a.Art_Id = b.Art_Id 
  and   b.Emp_Id = c.Emp_Id 
  and   b.Cat_Id = c.Cat_Id 
  and   a.Emp_Id = @pEmp_Id 
  and   a.Suc_Id = @pSuc_Id 
  and   b.Cat_Id >= @pCat_Ini 
  and   b.Cat_Id <= @pCat_Fin 
  and   a.Fecha  >= @pFecha_Ini 
  and   a.Fecha  <  @pFecha_fin
  order by
    a.Fecha, c.Nombre  
  
        
  

end

GO
/****** Object:  StoredProcedure [dbo].[RptVentasxFecha]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RptVentasxFecha]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pFecha_Ini datetime
,@pFecha_Fin datetime)
as
begin


  select cast(CONVERT (date,a.Fecha) as datetime) as Fecha
        ,sum(a.Costo)         as Costo
        ,sum(a.Subtotal)      as SubTotal
        ,sum(a.Descuento)     as Descuento
        ,sum(a.IV)            as IV
        ,sum(a.Total)         as Total
        ,sum(a.Redondeo)      as Redondeo
        ,sum(a.TotalCobrado)  as TotalCobrado
        ,SUM(a.Exento)        as Exento
        ,SUM(a.Gravado)       as Gravado
  from  FacturaEncabezado a
  where a.Emp_Id = @pEmp_Id 
  and   a.Suc_Id = @pSuc_Id 
  and   a.Fecha  >= @pFecha_Ini 
  and   a.Fecha  <  @pFecha_fin
  group by
      CONVERT (date,a.Fecha) 
  order by 
      CONVERT (date,a.Fecha) desc


end

GO
/****** Object:  StoredProcedure [dbo].[RptVentasxTipoPago]    Script Date: 4/8/2016 3:47:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RptVentasxTipoPago]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pFechaIni datetime
,@pFechaFin datetime)
as
begin

  select  cast(a.Caja_Id as varchar(4)) + '-' + cast(a.TipoDoc_Id as varchar(4)) + '-' + cast(a.Documento_Id as varchar(20)) as Documento_Id
         ,c.Nombre as NombreTipoDoc
         ,a.Fecha 
         ,a.Cliente_Id
         ,a.Nombre as ClienteNombre
         ,a.TotalCobrado 
         ,b.TipoPago_Id
         ,d.Nombre as TipoPagoNombre
         ,b.Monto 
         ,case b.TipoPago_Id 
              when 2 then b.TarjetaNumero
              when 3 then b.ChequeNumero 
              else ''
          end as NumeroPago 
         ,case b.TipoPago_Id 
              when 2 then e.Nombre 
              when 3 then f.Nombre 
              else ''
          end as NombrePago
  from  FacturaEncabezado a left join FacturaPago b 
        on    a.Emp_Id        = b.Emp_Id
        and   a.Suc_Id        = b.Suc_Id
        and   a.Caja_Id       = b.Caja_Id 
        and   a.TipoDoc_Id    = b.TipoDoc_Id 
        and   a.Documento_Id  = b.Documento_Id
        inner join TipoDocumento c 
        on    a.Emp_Id        = c.Emp_Id 
        and   a.TipoDoc_Id    = c.TipoDoc_Id 
        left outer join TipoPago d on b.Emp_Id = d.Emp_Id 
        and   b.TipoPago_Id   = d.TipoPago_Id 
        left outer join Tarjeta e  on b.Emp_Id = e.Emp_Id
        and   b.Tarjeta_Id    = e.Tarjeta_Id 
        left outer join Banco f    on b.Emp_Id = f.Emp_Id
        and   b.Banco_Id      = f.Banco_Id 
  where        
        a.Emp_Id = @pEmp_Id 
  and   a.Suc_Id = @pSuc_Id
  and   a.Fecha >= @pFechaIni 
  and   a.Fecha <  @pFechaFin 
  and   a.TipoDoc_Id in (1,3)
 order  by a.Fecha asc
  

  

end



GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si pide la cantidad al ingresarlo en la pantalla de facturacion' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articulo', @level2type=N'COLUMN',@level2name=N'SolicitarCantidad'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si el articulo trae la cantidad en el codigo de barras, este se usa para los articulos de la romana con etiquetas' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articulo', @level2type=N'COLUMN',@level2name=N'CodigoCantidad'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si el articulo pide el precio al ser facturado en el punto de venta' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articulo', @level2type=N'COLUMN',@level2name=N'Servicio'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Monto del principal en cxc, no se puede editar, es un campo calculado' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cliente', @level2type=N'COLUMN',@level2name=N'Saldo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si al cliente se le pueden hacer facturas de credito' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cliente', @level2type=N'COLUMN',@level2name=N'FacturaCredito'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Cantidad de dias de credito, se utiliza en CxC para calcular la fecha de vencimiento' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cliente', @level2type=N'COLUMN',@level2name=N'DiasCredito'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Porcentaje de mora diario ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cliente', @level2type=N'COLUMN',@level2name=N'PorcMora'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dias de gracia sin aplicar cargos x mora' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cliente', @level2type=N'COLUMN',@level2name=N'DiasGraciaMora'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si al cliente se le aplica mora' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cliente', @level2type=N'COLUMN',@level2name=N'AplicaMora'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipo de movimiento que al que se afecta' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CxCMovimientoAplica', @level2type=N'COLUMN',@level2name=N'AplicaTipoMov_Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Numero de movimiento que al que se afecta' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CxCMovimientoAplica', @level2type=N'COLUMN',@level2name=N'AplicaMov_Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipo de movimiento que al que se afecta' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CxCMovimientoMora', @level2type=N'COLUMN',@level2name=N'AplicaTipoMov_Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Numero de movimiento que al que se afecta' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CxCMovimientoMora', @level2type=N'COLUMN',@level2name=N'AplicaMov_Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Cantidad de minutos que dura una prefactura para ser eliminada' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmpresaParametro', @level2type=N'COLUMN',@level2name=N'MinutosPrefactura'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 = Factura 2 = Proforma 3 = PreFactura' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FacturaBitacora', @level2type=N'COLUMN',@level2name=N'Tipo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Costo Unitario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FacturaDetalle', @level2type=N'COLUMN',@level2name=N'Costo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Precio Bruto Unitario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FacturaDetalle', @level2type=N'COLUMN',@level2name=N'Precio'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'% Descuento' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FacturaDetalle', @level2type=N'COLUMN',@level2name=N'PorcDescuento'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Monto Descuento Unitario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FacturaDetalle', @level2type=N'COLUMN',@level2name=N'MontoDescuento'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Monto IV Unitario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FacturaDetalle', @level2type=N'COLUMN',@level2name=N'MontoIV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Precio - Descuento + IV (Unitario)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FacturaDetalle', @level2type=N'COLUMN',@level2name=N'TotalLinea'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 = Efectivo 2 = Tarjeta 3 = Cheque' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FacturaPago', @level2type=N'COLUMN',@level2name=N'TipoPago_Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Costo Unitario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProformaDetalle', @level2type=N'COLUMN',@level2name=N'Costo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Precio Bruto Unitario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProformaDetalle', @level2type=N'COLUMN',@level2name=N'Precio'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'% Descuento' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProformaDetalle', @level2type=N'COLUMN',@level2name=N'PorcDescuento'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Monto Descuento Unitario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProformaDetalle', @level2type=N'COLUMN',@level2name=N'MontoDescuento'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Monto IV Unitario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProformaDetalle', @level2type=N'COLUMN',@level2name=N'MontoIV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Precio - Descuento + IV (Unitario)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProformaDetalle', @level2type=N'COLUMN',@level2name=N'TotalLinea'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProformaEncabezado', @level2type=N'COLUMN',@level2name=N'Tipo'
GO
ALTER DATABASE [Produccion] SET  READ_WRITE 
GO
