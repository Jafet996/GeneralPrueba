USE [master]
GO
/****** Object:  Database [Produccion]    Script Date: 05/01/2012 23:51:52 ******/
CREATE DATABASE [Produccion] ON  PRIMARY 
( NAME = N'Produccion', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\Produccion.mdf' , SIZE = 23552KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Produccion_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\Produccion_log.ldf' , SIZE = 136064KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Produccion] SET COMPATIBILITY_LEVEL = 90
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
ALTER DATABASE [Produccion] SET AUTO_CREATE_STATISTICS ON
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
ALTER DATABASE [Produccion] SET  READ_WRITE
GO
ALTER DATABASE [Produccion] SET RECOVERY FULL
GO
ALTER DATABASE [Produccion] SET  MULTI_USER
GO
ALTER DATABASE [Produccion] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Produccion] SET DB_CHAINING OFF
GO
USE [Produccion]
GO
/****** Object:  User [ESCRITORIO\temporal]    Script Date: 05/01/2012 23:51:52 ******/
CREATE USER [ESCRITORIO\temporal] FOR LOGIN [ESCRITORIO\temporal] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 05/01/2012 23:51:54 ******/
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
	[Activo] [bit] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Cliente_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UnidadMedida]    Script Date: 05/01/2012 23:51:54 ******/
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
	[Activo] [bit] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_UnidadMedida] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[UnidadMedida_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 05/01/2012 23:51:54 ******/
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
	[Direccion] [varchar](200) NOT NULL,
	[Telefono1] [varchar](20) NOT NULL,
	[Telefono2] [varchar](20) NOT NULL,
	[Fax] [varchar](20) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Apartado] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Prov_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoPago]    Script Date: 05/01/2012 23:51:54 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Articulo]    Script Date: 05/01/2012 23:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Articulo](
	[Emp_Id] [smallint] NOT NULL,
	[Art_Id] [varchar](13) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Cat_Id] [smallint] NOT NULL,
	[SubCat_Id] [smallint] NOT NULL,
	[Departamento_Id] [smallint] NOT NULL,
	[UnidadMedida_Id] [smallint] NOT NULL,
	[FactorConversion] [smallint] NOT NULL,
	[ExentoIV] [bit] NOT NULL,
	[Suelto] [bit] NULL,
	[ArtPadre] [varchar](13) NULL,
	[SolicitarCantidad] [bit] NOT NULL,
	[PermiteFacturar] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Articulo] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Art_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si pide la cantidad al ingresarlo en la pantalla de facturacion' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articulo', @level2type=N'COLUMN',@level2name=N'SolicitarCantidad'
GO
/****** Object:  StoredProcedure [dbo].[GeneraCodigoClaseUpdate]    Script Date: 05/01/2012 23:51:56 ******/
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
					Set @Fields = @Fields + ' & "," & _' +char(13) + '           " '+ @Campo + '=' + char(39) + '" & Format(_'+ @Campo  +',"yyyyMMdd hh:mm:ss") &"' +char(39) +'"'
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
/****** Object:  StoredProcedure [dbo].[GeneraCodigoClaseWhere]    Script Date: 05/01/2012 23:51:56 ******/
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
/****** Object:  StoredProcedure [dbo].[GeneraCodigoClaseInsert]    Script Date: 05/01/2012 23:51:56 ******/
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
					    Set @Values = @Values +' & ",'+ char(39) + '" & Format(_' + @Campo +  ',"yyyyMMdd hh:mm:ss") & "' + Char(39) + '"'
					end
					else begin
						Set @Values = @Values +'",'+ char(39) + '" & Format(_' + @Campo +  ',"yyyyMMdd hh:mm:ss") & "' + Char(39) + '"'
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
/****** Object:  Table [dbo].[Empresa]    Script Date: 05/01/2012 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empresa](
	[Emp_Id] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Cedula] [varchar](50) NOT NULL,
	[Telefono] [varchar](20) NOT NULL,
	[Direccion] [varchar](200) NOT NULL,
	[PorcIV] [float] NOT NULL,
	[Activo] [bit] NOT NULL,
	[FactorRedondeo] [smallint] NOT NULL,
	[TopeRedondeo] [float] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tarjeta]    Script Date: 05/01/2012 23:51:56 ******/
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
	[Activo] [bit] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Tarjeta] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Tarjeta_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Banco]    Script Date: 05/01/2012 23:51:56 ******/
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
	[Activo] [bit] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Banco] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Banco_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoCambio]    Script Date: 05/01/2012 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCambio](
	[TipoCambio_Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[DolarCompra] [float] NOT NULL,
	[DolarVenta] [float] NOT NULL,
 CONSTRAINT [PK_TipoCambio_1] PRIMARY KEY CLUSTERED 
(
	[TipoCambio_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Moneda]    Script Date: 05/01/2012 23:51:56 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoDocumento]    Script Date: 05/01/2012 23:51:56 ******/
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
	[Activo] [bit] NOT NULL,
	[Cliente_Id] [int] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_TipoDocumento] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[TipoDoc_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 05/01/2012 23:51:56 ******/
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
	[Activo] [bit] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Usuario_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 05/01/2012 23:51:56 ******/
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
	[Activo] [bit] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Departamento] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Departamento_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoMovimiento]    Script Date: 05/01/2012 23:51:56 ******/
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
	[Traslado] [bit] NOT NULL,
	[EntradaMercaderia] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_TipoMovimiento] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[TipoMov_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CajaAutorizacion]    Script Date: 05/01/2012 23:51:56 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 05/01/2012 23:51:56 ******/
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
	[Activo] [bit] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Cat_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FacturaEncabezado]    Script Date: 05/01/2012 23:51:56 ******/
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
 CONSTRAINT [PK_FacturaEncabezado_1] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Caja_Id] ASC,
	[TipoDoc_Id] ASC,
	[Documento_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CajaCierreEncabezado]    Script Date: 05/01/2012 23:51:56 ******/
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
	[FechaApertura] [datetime] NOT NULL,
	[FechaCierre] [datetime] NOT NULL,
	[CajeroEfectivo] [money] NOT NULL,
	[CajeroTarjeta] [money] NOT NULL,
	[CajeroCheque] [money] NOT NULL,
	[CajeroTotal] [money] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_CajaCierre] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Caja_Id] ASC,
	[Cierre_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MovimientoDetalle]    Script Date: 05/01/2012 23:51:56 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Caja]    Script Date: 05/01/2012 23:51:56 ******/
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
	[Abierta] [bit] NOT NULL,
	[Cierre_Id] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Caja] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Caja_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MovimientoEncabezado]    Script Date: 05/01/2012 23:51:56 ******/
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
	[Aplicado] [bit] NOT NULL,
	[Usuario_Id] [varchar](20) NOT NULL,
	[Suc_Id_Destino] [smallint] NULL,
	[Bod_Id_Destino] [smallint] NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_MovimientoEncabezado] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[TipoMov_Id] ASC,
	[Mov_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArticuloBodega]    Script Date: 05/01/2012 23:51:56 ******/
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
	[Saldo] [float] NOT NULL,
	[Costo] [money] NOT NULL,
	[Margen] [float] NOT NULL,
	[Precio] [money] NOT NULL,
	[FechaIniDescuento] [datetime] NOT NULL,
	[FechaFinDescuento] [datetime] NOT NULL,
	[PorcDescuento] [float] NOT NULL,
	[Activo] [bit] NOT NULL,
	[FechaUltimaVenta] [datetime] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_ArticuloBodega] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Bod_Id] ASC,
	[Art_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bodega]    Script Date: 05/01/2012 23:51:56 ******/
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
	[Activo] [bit] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Bodega] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Bod_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArticuloProveedor]    Script Date: 05/01/2012 23:51:56 ******/
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
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_ArticuloProveedor] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Art_Id] ASC,
	[Prov_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArticuloKardex]    Script Date: 05/01/2012 23:51:56 ******/
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
 CONSTRAINT [PK_ArticuloKardex] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Bod_Id] ASC,
	[Art_Id] ASC,
	[Kardex_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CajaCierreDetalle]    Script Date: 05/01/2012 23:51:56 ******/
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
 CONSTRAINT [PK_CajaCierreDetalle] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Caja_Id] ASC,
	[Cierre_Id] ASC,
	[Detalle_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FacturaPago]    Script Date: 05/01/2012 23:51:56 ******/
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
	[Tarjeta_Id] [smallint] NULL,
	[TarjetaNumero] [varchar](16) NOT NULL,
	[TarjetaAutorizacion] [varchar](16) NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_FacturaPago] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Caja_Id] ASC,
	[TipoDoc_Id] ASC,
	[Documento_Id] ASC,
	[Pago_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 = Efectivo 2 = Tarjeta 3 = Cheque' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FacturaPago', @level2type=N'COLUMN',@level2name=N'TipoPago_Id'
GO
/****** Object:  Table [dbo].[ArticuloConjunto]    Script Date: 05/01/2012 23:51:56 ******/
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
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_ArticuloConjunto] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Art_Id] ASC,
	[ArtConjunto_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArticuloEquivalente]    Script Date: 05/01/2012 23:51:56 ******/
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
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_ArticuloEquivalente] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Art_Id] ASC,
	[ArtEquivalente_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ArticuloEquivalente] ON [dbo].[ArticuloEquivalente] 
(
	[Emp_Id] ASC,
	[ArtEquivalente_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacturaDetalle]    Script Date: 05/01/2012 23:51:56 ******/
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
 CONSTRAINT [PK_FacturaDetalle] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC,
	[Caja_Id] ASC,
	[TipoDoc_Id] ASC,
	[Documento_Id] ASC,
	[Detalle_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
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
/****** Object:  Table [dbo].[Sucursal]    Script Date: 05/01/2012 23:51:56 ******/
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
	[Direccion] [varchar](200) NOT NULL,
	[Activo] [bit] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Suc_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vendedor]    Script Date: 05/01/2012 23:51:56 ******/
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
	[Activo] [bit] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Vendedor] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Vendedor_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FacturaDevolucion]    Script Date: 05/01/2012 23:51:56 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubCategoria]    Script Date: 05/01/2012 23:51:56 ******/
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
	[Activo] [bit] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_SubCategoria] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC,
	[Cat_Id] ASC,
	[SubCat_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[ConsultaArticulo]    Script Date: 05/01/2012 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ConsultaArticulo]
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
	                            Nombre varchar(50) NOT NULL,
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
	                            UnidadMedidaNombre varchar(50) NOT NULL)
	                            

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
          ,UnidadMedidaNombre)
    select a.Art_Id
          ,a.Nombre
          ,a.FactorConversion
          ,a.ExentoIV
          ,a.Suelto
          ,isnull(a.ArtPadre,'')
          ,a.Activo
          ,b.Saldo
          ,b.Costo
          ,b.Margen
          ,b.Precio
          ,b.FechaIniDescuento
          ,b.FechaFinDescuento
          ,b.PorcDescuento
          ,0
          ,a.SolicitarCantidad
          ,a.PermiteFacturar
          ,c.Nombre
    from  Articulo a,
          ArticuloBodega b,
          UnidadMedida c
    where a.Emp_Id          = b.Emp_Id
    and   a.Art_Id          = b.Art_Id
    and   a.Emp_Id          = c.Emp_Id
    and   a.UnidadMedida_Id = c.UnidadMedida_Id
    and   b.Emp_Id          = @pEmp_Id
    and   b.Suc_Id          = @pSuc_Id
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

    
    ----Busca si tiene algun articulo conjunto
    --insert @Articulo
    --      (Art_Id
    --      ,Nombre
    --      ,FactorConversion
    --      ,ExentoIV
    --      ,Suelto
    --      ,ArtPadre
    --      ,Activo
    --      ,Saldo
    --      ,Costo
    --      ,Margen
    --      ,Precio
    --      ,FechaIniDescuento
    --      ,FechaFinDescuento
    --      ,PorcDescuento
    --      ,Conjunto
    --      ,SolicitarCantidad)      
    --    select a.Art_Id
    --      ,a.Nombre
    --      ,a.FactorConversion
    --      ,a.ExentoIV
    --      ,a.Suelto
    --      ,isnull(a.ArtPadre,'')
    --      ,a.Activo
    --      ,b.Saldo
    --      ,b.Costo
    --      ,b.Margen
    --      ,b.Precio
    --      ,b.FechaIniDescuento
    --      ,b.FechaFinDescuento
    --      ,b.PorcDescuento
    --      ,1
    --      ,a.SolicitarCantidad
    --from  Articulo a,
    --      ArticuloBodega b,
    --      ArticuloConjunto c
    --where a.Emp_Id          = b.Emp_Id
    --and   a.Art_Id          = b.Art_Id
    --and   c.Emp_Id          = a.Emp_Id
    --and   c.Art_Id          = @Art_Id
    --and   c.ArtConjunto_Id  = a.Art_id
    --and   b.Emp_Id = @pEmp_Id
    --and   b.Suc_Id = @pSuc_Id
    --if @@error <> 0  begin
    --  raiserror ('Error buscando, articulo conjunto: %s', 16, 1, @pArt_Id)  
    --end
    
    
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
/****** Object:  StoredProcedure [dbo].[CierreCajaAcumulaPago]    Script Date: 05/01/2012 23:51:56 ******/
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
/****** Object:  StoredProcedure [dbo].[CierreCajaAcumulaMonto]    Script Date: 05/01/2012 23:51:56 ******/
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


select @Sumar    

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
/****** Object:  StoredProcedure [dbo].[CierreCajaCierraCaja]    Script Date: 05/01/2012 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CierreCajaCierraCaja]
(@pEmp_Id         smallint 
,@pSuc_Id         smallint 
,@pCaja_Id        smallint
,@pCajeroEfectivo money
,@pCajeroTarjeta  money
,@pCajeroCheque   money)
as
begin
  begin try
    begin transaction
   
    declare  @Abierta bit
            ,@Cierre_Id int

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
    
    --Crea el encabezado del cierre de caja
    update CajaCierreEncabezado
       set Cerrado            = 1
          ,FechaCierre        = getdate()
          ,CajeroEfectivo     = @pCajeroEfectivo
          ,CajeroTarjeta      = @pCajeroTarjeta
          ,CajeroCheque       = @pCajeroCheque
          ,CajeroTotal        = (@pCajeroEfectivo + @pCajeroTarjeta + @pCajeroCheque)
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
/****** Object:  StoredProcedure [dbo].[CierreCajaAbreCaja]    Script Date: 05/01/2012 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CierreCajaAbreCaja]
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
/****** Object:  StoredProcedure [dbo].[RebajaSumaIventario]    Script Date: 05/01/2012 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RebajaSumaIventario]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint
,@pArt_Id varchar(13)
,@pCantidad float) --Si es una devolucion el monto viene negativo
as
begin
  begin try
    declare  @Suelto bit
            ,@FactorConversion smallint
            ,@ArtPadre varchar(13)
            ,@Saldo float
            ,@CantidadCajas int
            

    --Realiza el rebajo de inventario
    update ArticuloBodega set  Saldo              = Saldo - @pCantidad
                              ,UltimaModificacion = getdate()
    where Emp_Id = @pEmp_Id
    and   Suc_Id = @pSuc_Id
    and   Bod_Id = @pBod_Id
    and   Art_Id = @pArt_Id
    if @@error <> 0  begin
      raiserror ('Error rebajando de inventario, articulo: %s', 16, 1, @pArt_Id)  
    end
    
    -----------------------------------------------------------------------------
    --Verifica si se trata de un articulo suelto
    -----------------------------------------------------------------------------
    select @Suelto = Suelto
          ,@ArtPadre = ArtPadre
    from  Articulo
    where Emp_Id = @pEmp_Id
    and   Art_Id = @pArt_Id
    if @@error <> 0  begin
      raiserror ('Error buscando artículo padre, articulo: %s', 16, 1, @pArt_Id)  
    end  
    
    if @Suelto = 1 begin
      --Busca el factor de conversion del padre
      select @FactorConversion = FactorConversion
      from  Articulo
      where Emp_Id = @pEmp_Id
      and   Art_Id = @ArtPadre
      if @@error <> 0  begin
        raiserror ('Error buscando factor de conversion, articulo: %s', 16, 1, @pArt_Id)  
      end  
      
      --Busca el saldo actual del hijo
      select @Saldo = Saldo
      from  ArticuloBodega
      where Emp_Id = @pEmp_Id
      and   Suc_Id = @pSuc_Id
      and   Bod_Id = @pBod_Id
      and   Art_Id = @pArt_Id
      if @@error <> 0  begin
        raiserror ('Error buscando saldo, articulo: %s', 16, 1, @pArt_Id)  
      end    
      
      --Verifica si la cantidad de unidades en el hijo sea positivo o negativo es mayor 
      --al factor de conversion de padre entonces debe ajustar el saldo del padre y la
      --del suelto tambien
      
      if abs(@Saldo)>=@FactorConversion begin
        select @CantidadCajas = abs(@Saldo)/@FactorConversion
        
        if @Saldo>0 begin
          set @CantidadCajas = @CantidadCajas * -1
        end
        
        --Ajusta la cantidad de unidades del padre
        update ArticuloBodega set  Saldo              = Saldo - @CantidadCajas
                                  ,UltimaModificacion = getdate()
        where Emp_Id = @pEmp_Id
        and   Suc_Id = @pSuc_Id
        and   Bod_Id = @pBod_Id
        and   Art_Id = @ArtPadre
        if @@error <> 0  begin
          raiserror ('Error rebajando de inventario, articulo: %s', 16, 1, @pArt_Id)  
        end
                
        --Ajusta la cantidad de unidades del hijo
        update ArticuloBodega set  Saldo              = Saldo + (@CantidadCajas * @FactorConversion)
                                  ,UltimaModificacion = getdate()
        where Emp_Id = @pEmp_Id
        and   Suc_Id = @pSuc_Id
        and   Bod_Id = @pBod_Id
        and   Art_Id = @pArt_Id
        if @@error <> 0  begin
          raiserror ('Error rebajando de inventario artículo suelto, articulo: %s', 16, 1, @pArt_Id)  
        end        

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
/****** Object:  StoredProcedure [dbo].[GuardaArticuloKardex]    Script Date: 05/01/2012 23:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GuardaArticuloKardex]
(@pEmp_Id smallint
,@pSuc_Id smallint
,@pBod_Id smallint
,@pArt_Id varchar(13)
,@pFecha datetime
,@pCantidad float
,@pDetalle varchar(200)
,@pUsuario_Id varchar(20))
as
begin
  begin try
  
    --Guarda el Kardex del articulo
    insert into ArticuloKardex
               (Emp_Id
               ,Suc_Id
               ,Bod_Id
               ,Art_Id
               ,Fecha
               ,Cantidad
               ,Detalle
               ,Usuario_Id)
         VALUES
               (@pEmp_Id
               ,@pSuc_Id
               ,@pBod_Id
               ,@pArt_Id
               ,@pFecha
               ,@pCantidad
               ,@pDetalle
               ,@pUsuario_Id)
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
/****** Object:  StoredProcedure [dbo].[GeneraCodigoClase]    Script Date: 05/01/2012 23:51:56 ******/
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
/****** Object:  StoredProcedure [dbo].[GuardaFacturaDetalle]    Script Date: 05/01/2012 23:51:56 ******/
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
,@pSuelto bit)
as
begin
  begin try
  
    declare @SpResult int
    
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
    
    --Si es una devolucion el monto se envia negativo para que se haga la devolucion al inventario
    exec @SpResult = RebajaSumaIventario @pEmp_Id, @pSuc_Id, @pBod_Id, @pArt_Id ,@pCantidad
    if @SpResult<>0 begin
      raiserror ('Error ejecutando, RebajaSumaIventario, para el articulo: %s', 16, 1, @pArt_Id)
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
/****** Object:  StoredProcedure [dbo].[GuardaMovimientoDetalle]    Script Date: 05/01/2012 23:51:56 ******/
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
,@pFecha datetime
,@pBod_Id smallint
,@pDetalle varchar(200)
,@pUsuario_Id varchar(20))
as
begin
  begin try
  
    declare @SpResult int

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
               
    --Si es una devolucion el monto se envia negativo para que se haga la devolucion al inventario
    exec @SpResult = RebajaSumaIventario @pEmp_Id, @pSuc_Id, @pBod_Id, @pArt_Id ,@pCantidad
    if @SpResult<>0 begin
      raiserror ('Error ejecutando, RebajaSumaIventario, para el articulo: %s', 16, 1, @pArt_Id)
    end
    
    --Guarda el kardex del articulo
    exec @SpResult = GuardaArticuloKardex @pEmp_Id, @pSuc_Id, @pBod_Id, @pArt_Id, @pFecha ,@pCantidad, @pDetalle, @pUsuario_Id
    if @SpResult<>0 begin
      raiserror ('Error ejecutando, GuardaArticuloKardex, para el articulo: %s', 16, 1, @pArt_Id)
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
/****** Object:  Default [DF_Cliente_Activo]    Script Date: 05/01/2012 23:51:54 ******/
ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF_Cliente_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  Default [DF_Cliente_UltimaModificacion]    Script Date: 05/01/2012 23:51:54 ******/
ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF_Cliente_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO
/****** Object:  Default [DF_UnidadMedida_Activo]    Script Date: 05/01/2012 23:51:54 ******/
ALTER TABLE [dbo].[UnidadMedida] ADD  CONSTRAINT [DF_UnidadMedida_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  Default [DF_UnidadMedida_UltimaModificacion]    Script Date: 05/01/2012 23:51:54 ******/
ALTER TABLE [dbo].[UnidadMedida] ADD  CONSTRAINT [DF_UnidadMedida_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO
/****** Object:  Default [DF_Proveedor_Activo]    Script Date: 05/01/2012 23:51:54 ******/
ALTER TABLE [dbo].[Proveedor] ADD  CONSTRAINT [DF_Proveedor_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  Default [DF_Proveedor_UltimaModificacion]    Script Date: 05/01/2012 23:51:54 ******/
ALTER TABLE [dbo].[Proveedor] ADD  CONSTRAINT [DF_Proveedor_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO
/****** Object:  Default [DF_Articulo_SolicitaCantidadFacturacion]    Script Date: 05/01/2012 23:51:54 ******/
ALTER TABLE [dbo].[Articulo] ADD  CONSTRAINT [DF_Articulo_SolicitaCantidadFacturacion]  DEFAULT ((0)) FOR [SolicitarCantidad]
GO
/****** Object:  Default [DF_Articulo_Activo]    Script Date: 05/01/2012 23:51:54 ******/
ALTER TABLE [dbo].[Articulo] ADD  CONSTRAINT [DF_Articulo_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  Default [DF_Articulo_UltimaModificacion]    Script Date: 05/01/2012 23:51:54 ******/
ALTER TABLE [dbo].[Articulo] ADD  CONSTRAINT [DF_Articulo_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO
/****** Object:  Default [DF_Empresa_Activo]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Empresa] ADD  CONSTRAINT [DF_Empresa_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  Default [DF_Empresa_UltimaModificacion]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Empresa] ADD  CONSTRAINT [DF_Empresa_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO
/****** Object:  Default [DF_Tarjeta_Activo]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Tarjeta] ADD  CONSTRAINT [DF_Tarjeta_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  Default [DF_Tarjeta_UltimaModificacion]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Tarjeta] ADD  CONSTRAINT [DF_Tarjeta_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO
/****** Object:  Default [DF_Banco_Activo]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Banco] ADD  CONSTRAINT [DF_Banco_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  Default [DF_Banco_UltimaModificacion]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Banco] ADD  CONSTRAINT [DF_Banco_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO
/****** Object:  Default [DF_TipoCambio_Fecha]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[TipoCambio] ADD  CONSTRAINT [DF_TipoCambio_Fecha]  DEFAULT (getdate()) FOR [Fecha]
GO
/****** Object:  Default [DF_Moneda_Activo]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Moneda] ADD  CONSTRAINT [DF_Moneda_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  Default [DF_Moneda_UltimaModificacion]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Moneda] ADD  CONSTRAINT [DF_Moneda_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO
/****** Object:  Default [DF_TipoDocumento_Activo]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[TipoDocumento] ADD  CONSTRAINT [DF_TipoDocumento_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  Default [DF_TipoDocumento_UltimaModificacion]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[TipoDocumento] ADD  CONSTRAINT [DF_TipoDocumento_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO
/****** Object:  Default [DF_Usuario_Activo]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  Default [DF_Usuario_UltimaModificacion]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO
/****** Object:  Default [DF_Departamento_Activo]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Departamento] ADD  CONSTRAINT [DF_Departamento_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  Default [DF_Departamento_UltimaModificacion]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Departamento] ADD  CONSTRAINT [DF_Departamento_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO
/****** Object:  Default [DF_TipoMovimiento_Activo]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[TipoMovimiento] ADD  CONSTRAINT [DF_TipoMovimiento_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  Default [DF_TipoMovimiento_UltimaModificacion]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[TipoMovimiento] ADD  CONSTRAINT [DF_TipoMovimiento_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO
/****** Object:  Default [DF_CajaAutorizacion_Fecha]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[CajaAutorizacion] ADD  CONSTRAINT [DF_CajaAutorizacion_Fecha]  DEFAULT (getdate()) FOR [Fecha]
GO
/****** Object:  Default [DF_Categoria_Activo]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Categoria] ADD  CONSTRAINT [DF_Categoria_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  Default [DF_Categoria_UltimaModificacion]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Categoria] ADD  CONSTRAINT [DF_Categoria_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO
/****** Object:  Default [DF_CajaCierre_FechaApertura]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[CajaCierreEncabezado] ADD  CONSTRAINT [DF_CajaCierre_FechaApertura]  DEFAULT ('19000101') FOR [FechaApertura]
GO
/****** Object:  Default [DF_CajaCierre_FechaApertura1]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[CajaCierreEncabezado] ADD  CONSTRAINT [DF_CajaCierre_FechaApertura1]  DEFAULT ('19000101') FOR [FechaCierre]
GO
/****** Object:  Default [DF_CajaCierreEncabezado_CajeroEfectivo]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[CajaCierreEncabezado] ADD  CONSTRAINT [DF_CajaCierreEncabezado_CajeroEfectivo]  DEFAULT ((0)) FOR [CajeroEfectivo]
GO
/****** Object:  Default [DF_CajaCierreEncabezado_CajeroTarjeta]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[CajaCierreEncabezado] ADD  CONSTRAINT [DF_CajaCierreEncabezado_CajeroTarjeta]  DEFAULT ((0)) FOR [CajeroTarjeta]
GO
/****** Object:  Default [DF_CajaCierreEncabezado_CajeroCheque]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[CajaCierreEncabezado] ADD  CONSTRAINT [DF_CajaCierreEncabezado_CajeroCheque]  DEFAULT ((0)) FOR [CajeroCheque]
GO
/****** Object:  Default [DF_CajaCierreEncabezado_CajeroTotal]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[CajaCierreEncabezado] ADD  CONSTRAINT [DF_CajaCierreEncabezado_CajeroTotal]  DEFAULT ((0)) FOR [CajeroTotal]
GO
/****** Object:  Default [DF_CajaCierre_UltimaModificacion]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[CajaCierreEncabezado] ADD  CONSTRAINT [DF_CajaCierre_UltimaModificacion]  DEFAULT ('19000101') FOR [UltimaModificacion]
GO
/****** Object:  Default [DF_Caja_Abierta]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Caja] ADD  CONSTRAINT [DF_Caja_Abierta]  DEFAULT ((0)) FOR [Abierta]
GO
/****** Object:  Default [DF_Caja_Cierre_Id]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Caja] ADD  CONSTRAINT [DF_Caja_Cierre_Id]  DEFAULT ((0)) FOR [Cierre_Id]
GO
/****** Object:  Default [DF_Caja_Activo]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Caja] ADD  CONSTRAINT [DF_Caja_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  Default [DF_Caja_UltimaModificacion]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Caja] ADD  CONSTRAINT [DF_Caja_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO
/****** Object:  Default [DF_MovimientoEncabezado_Aplicado]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[MovimientoEncabezado] ADD  CONSTRAINT [DF_MovimientoEncabezado_Aplicado]  DEFAULT ((0)) FOR [Aplicado]
GO
/****** Object:  Default [DF_MovimientoEncabezado_UltimaModificacion]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[MovimientoEncabezado] ADD  CONSTRAINT [DF_MovimientoEncabezado_UltimaModificacion]  DEFAULT ('19000101') FOR [UltimaModificacion]
GO
/****** Object:  Default [DF_ArticuloBodega_FechaInicioDescuento]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[ArticuloBodega] ADD  CONSTRAINT [DF_ArticuloBodega_FechaInicioDescuento]  DEFAULT ('19000101') FOR [FechaIniDescuento]
GO
/****** Object:  Default [DF_ArticuloBodega_FechaInicioDescuento1]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[ArticuloBodega] ADD  CONSTRAINT [DF_ArticuloBodega_FechaInicioDescuento1]  DEFAULT ('19000101') FOR [FechaFinDescuento]
GO
/****** Object:  Default [DF_ArticuloBodega_PorcDescuento]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[ArticuloBodega] ADD  CONSTRAINT [DF_ArticuloBodega_PorcDescuento]  DEFAULT ((0)) FOR [PorcDescuento]
GO
/****** Object:  Default [DF_ArticuloBodega_Activo]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[ArticuloBodega] ADD  CONSTRAINT [DF_ArticuloBodega_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  Default [DF_ArticuloBodega_FechaUltimaVenta]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[ArticuloBodega] ADD  CONSTRAINT [DF_ArticuloBodega_FechaUltimaVenta]  DEFAULT ('1900/01/01') FOR [FechaUltimaVenta]
GO
/****** Object:  Default [DF_ArticuloBodega_UltimaModificacion]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[ArticuloBodega] ADD  CONSTRAINT [DF_ArticuloBodega_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO
/****** Object:  Default [DF_Bodega_Activo]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Bodega] ADD  CONSTRAINT [DF_Bodega_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  Default [DF_Bodega_UltimaModificacion]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Bodega] ADD  CONSTRAINT [DF_Bodega_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO
/****** Object:  Default [DF_ArticuloProveedor_UltimaModificacion]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[ArticuloProveedor] ADD  CONSTRAINT [DF_ArticuloProveedor_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO
/****** Object:  Default [DF_FacturaPago_Fecha]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[FacturaPago] ADD  CONSTRAINT [DF_FacturaPago_Fecha]  DEFAULT (getdate()) FOR [Fecha]
GO
/****** Object:  Default [DF_ArticuloConjunto_UltimaModificacion]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[ArticuloConjunto] ADD  CONSTRAINT [DF_ArticuloConjunto_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO
/****** Object:  Default [DF_ArticuloEquivalente_UltimaModificacion]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[ArticuloEquivalente] ADD  CONSTRAINT [DF_ArticuloEquivalente_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO
/****** Object:  Default [DF_Sucursal_Activo]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Sucursal] ADD  CONSTRAINT [DF_Sucursal_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  Default [DF_Sucursal_UltimaModificacion]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Sucursal] ADD  CONSTRAINT [DF_Sucursal_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO
/****** Object:  Default [DF_Vendedor_Activo]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Vendedor] ADD  CONSTRAINT [DF_Vendedor_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  Default [DF_Vendedor_UltimaModificacion]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Vendedor] ADD  CONSTRAINT [DF_Vendedor_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO
/****** Object:  Default [DF_SubCategoria_Activo]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[SubCategoria] ADD  CONSTRAINT [DF_SubCategoria_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  Default [DF_SubCategoria_UltimaModificacion]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[SubCategoria] ADD  CONSTRAINT [DF_SubCategoria_UltimaModificacion]  DEFAULT (getdate()) FOR [UltimaModificacion]
GO
/****** Object:  Check [CK_Articulo_FactorConversion]    Script Date: 05/01/2012 23:51:54 ******/
ALTER TABLE [dbo].[Articulo]  WITH CHECK ADD  CONSTRAINT [CK_Articulo_FactorConversion] CHECK  (([FactorConversion]>(0)))
GO
ALTER TABLE [dbo].[Articulo] CHECK CONSTRAINT [CK_Articulo_FactorConversion]
GO
/****** Object:  Check [CK_FacturaPago]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[FacturaPago]  WITH CHECK ADD  CONSTRAINT [CK_FacturaPago] CHECK  (([TipoPago_Id]=(3) OR [TipoPago_Id]=(2) OR [TipoPago_Id]=(1)))
GO
ALTER TABLE [dbo].[FacturaPago] CHECK CONSTRAINT [CK_FacturaPago]
GO
/****** Object:  ForeignKey [FK_Articulo_Articulo]    Script Date: 05/01/2012 23:51:54 ******/
ALTER TABLE [dbo].[Articulo]  WITH CHECK ADD  CONSTRAINT [FK_Articulo_Articulo] FOREIGN KEY([Emp_Id], [ArtPadre])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO
ALTER TABLE [dbo].[Articulo] CHECK CONSTRAINT [FK_Articulo_Articulo]
GO
/****** Object:  ForeignKey [FK_FacturaEncabezado_Bodega]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[FacturaEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_FacturaEncabezado_Bodega] FOREIGN KEY([Emp_Id], [Suc_Id], [Bod_Id])
REFERENCES [dbo].[Bodega] ([Emp_Id], [Suc_Id], [Bod_Id])
GO
ALTER TABLE [dbo].[FacturaEncabezado] CHECK CONSTRAINT [FK_FacturaEncabezado_Bodega]
GO
/****** Object:  ForeignKey [FK_FacturaEncabezado_Caja]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[FacturaEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_FacturaEncabezado_Caja] FOREIGN KEY([Emp_Id], [Suc_Id], [Caja_Id])
REFERENCES [dbo].[Caja] ([Emp_Id], [Suc_Id], [Caja_Id])
GO
ALTER TABLE [dbo].[FacturaEncabezado] CHECK CONSTRAINT [FK_FacturaEncabezado_Caja]
GO
/****** Object:  ForeignKey [FK_FacturaEncabezado_CajaCierreEncabezado]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[FacturaEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_FacturaEncabezado_CajaCierreEncabezado] FOREIGN KEY([Emp_Id], [Suc_Id], [Caja_Id], [Cierre_Id])
REFERENCES [dbo].[CajaCierreEncabezado] ([Emp_Id], [Suc_Id], [Caja_Id], [Cierre_Id])
GO
ALTER TABLE [dbo].[FacturaEncabezado] CHECK CONSTRAINT [FK_FacturaEncabezado_CajaCierreEncabezado]
GO
/****** Object:  ForeignKey [FK_FacturaEncabezado_Cliente]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[FacturaEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_FacturaEncabezado_Cliente] FOREIGN KEY([Emp_Id], [Cliente_Id])
REFERENCES [dbo].[Cliente] ([Emp_Id], [Cliente_Id])
GO
ALTER TABLE [dbo].[FacturaEncabezado] CHECK CONSTRAINT [FK_FacturaEncabezado_Cliente]
GO
/****** Object:  ForeignKey [FK_FacturaEncabezado_TipoDocumento]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[FacturaEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_FacturaEncabezado_TipoDocumento] FOREIGN KEY([Emp_Id], [TipoDoc_Id])
REFERENCES [dbo].[TipoDocumento] ([Emp_Id], [TipoDoc_Id])
GO
ALTER TABLE [dbo].[FacturaEncabezado] CHECK CONSTRAINT [FK_FacturaEncabezado_TipoDocumento]
GO
/****** Object:  ForeignKey [FK_FacturaEncabezado_Usuario]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[FacturaEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_FacturaEncabezado_Usuario] FOREIGN KEY([Emp_Id], [Usuario_Id])
REFERENCES [dbo].[Usuario] ([Emp_Id], [Usuario_Id])
GO
ALTER TABLE [dbo].[FacturaEncabezado] CHECK CONSTRAINT [FK_FacturaEncabezado_Usuario]
GO
/****** Object:  ForeignKey [FK_FacturaEncabezado_Vendedor]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[FacturaEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_FacturaEncabezado_Vendedor] FOREIGN KEY([Emp_Id], [Vendedor_Id])
REFERENCES [dbo].[Vendedor] ([Emp_Id], [Vendedor_Id])
GO
ALTER TABLE [dbo].[FacturaEncabezado] CHECK CONSTRAINT [FK_FacturaEncabezado_Vendedor]
GO
/****** Object:  ForeignKey [FK_CajaCierreEncabezado_Caja]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[CajaCierreEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_CajaCierreEncabezado_Caja] FOREIGN KEY([Emp_Id], [Suc_Id], [Caja_Id])
REFERENCES [dbo].[Caja] ([Emp_Id], [Suc_Id], [Caja_Id])
GO
ALTER TABLE [dbo].[CajaCierreEncabezado] CHECK CONSTRAINT [FK_CajaCierreEncabezado_Caja]
GO
/****** Object:  ForeignKey [FK_CajaCierreEncabezado_Usuario]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[CajaCierreEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_CajaCierreEncabezado_Usuario] FOREIGN KEY([Emp_Id], [Usuario_Id])
REFERENCES [dbo].[Usuario] ([Emp_Id], [Usuario_Id])
GO
ALTER TABLE [dbo].[CajaCierreEncabezado] CHECK CONSTRAINT [FK_CajaCierreEncabezado_Usuario]
GO
/****** Object:  ForeignKey [FK_MovimientoDetalle_Articulo]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[MovimientoDetalle]  WITH CHECK ADD  CONSTRAINT [FK_MovimientoDetalle_Articulo] FOREIGN KEY([Emp_Id], [Art_Id])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO
ALTER TABLE [dbo].[MovimientoDetalle] CHECK CONSTRAINT [FK_MovimientoDetalle_Articulo]
GO
/****** Object:  ForeignKey [FK_MovimientoDetalle_MovimientoEncabezado]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[MovimientoDetalle]  WITH CHECK ADD  CONSTRAINT [FK_MovimientoDetalle_MovimientoEncabezado] FOREIGN KEY([Emp_Id], [Suc_Id], [TipoMov_Id], [Mov_Id])
REFERENCES [dbo].[MovimientoEncabezado] ([Emp_Id], [Suc_Id], [TipoMov_Id], [Mov_Id])
GO
ALTER TABLE [dbo].[MovimientoDetalle] CHECK CONSTRAINT [FK_MovimientoDetalle_MovimientoEncabezado]
GO
/****** Object:  ForeignKey [FK_Caja_Bodega]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Caja]  WITH CHECK ADD  CONSTRAINT [FK_Caja_Bodega] FOREIGN KEY([Emp_Id], [Suc_Id], [Bod_Id])
REFERENCES [dbo].[Bodega] ([Emp_Id], [Suc_Id], [Bod_Id])
GO
ALTER TABLE [dbo].[Caja] CHECK CONSTRAINT [FK_Caja_Bodega]
GO
/****** Object:  ForeignKey [FK_Caja_Sucursal]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Caja]  WITH CHECK ADD  CONSTRAINT [FK_Caja_Sucursal] FOREIGN KEY([Emp_Id], [Suc_Id])
REFERENCES [dbo].[Sucursal] ([Emp_Id], [Suc_Id])
GO
ALTER TABLE [dbo].[Caja] CHECK CONSTRAINT [FK_Caja_Sucursal]
GO
/****** Object:  ForeignKey [FK_MovimientoEncabezado_Bodega]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[MovimientoEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_MovimientoEncabezado_Bodega] FOREIGN KEY([Emp_Id], [Suc_Id], [Bod_Id])
REFERENCES [dbo].[Bodega] ([Emp_Id], [Suc_Id], [Bod_Id])
GO
ALTER TABLE [dbo].[MovimientoEncabezado] CHECK CONSTRAINT [FK_MovimientoEncabezado_Bodega]
GO
/****** Object:  ForeignKey [FK_MovimientoEncabezado_Bodega1]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[MovimientoEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_MovimientoEncabezado_Bodega1] FOREIGN KEY([Emp_Id], [Suc_Id_Destino], [Bod_Id_Destino])
REFERENCES [dbo].[Bodega] ([Emp_Id], [Suc_Id], [Bod_Id])
GO
ALTER TABLE [dbo].[MovimientoEncabezado] CHECK CONSTRAINT [FK_MovimientoEncabezado_Bodega1]
GO
/****** Object:  ForeignKey [FK_MovimientoEncabezado_TipoMovimiento]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[MovimientoEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_MovimientoEncabezado_TipoMovimiento] FOREIGN KEY([Emp_Id], [TipoMov_Id])
REFERENCES [dbo].[TipoMovimiento] ([Emp_Id], [TipoMov_Id])
GO
ALTER TABLE [dbo].[MovimientoEncabezado] CHECK CONSTRAINT [FK_MovimientoEncabezado_TipoMovimiento]
GO
/****** Object:  ForeignKey [FK_MovimientoEncabezado_Usuario]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[MovimientoEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_MovimientoEncabezado_Usuario] FOREIGN KEY([Emp_Id], [Usuario_Id])
REFERENCES [dbo].[Usuario] ([Emp_Id], [Usuario_Id])
GO
ALTER TABLE [dbo].[MovimientoEncabezado] CHECK CONSTRAINT [FK_MovimientoEncabezado_Usuario]
GO
/****** Object:  ForeignKey [FK_ArticuloBodega_Articulo]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[ArticuloBodega]  WITH CHECK ADD  CONSTRAINT [FK_ArticuloBodega_Articulo] FOREIGN KEY([Emp_Id], [Art_Id])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO
ALTER TABLE [dbo].[ArticuloBodega] CHECK CONSTRAINT [FK_ArticuloBodega_Articulo]
GO
/****** Object:  ForeignKey [FK_ArticuloBodega_Bodega]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[ArticuloBodega]  WITH CHECK ADD  CONSTRAINT [FK_ArticuloBodega_Bodega] FOREIGN KEY([Emp_Id], [Suc_Id], [Bod_Id])
REFERENCES [dbo].[Bodega] ([Emp_Id], [Suc_Id], [Bod_Id])
GO
ALTER TABLE [dbo].[ArticuloBodega] CHECK CONSTRAINT [FK_ArticuloBodega_Bodega]
GO
/****** Object:  ForeignKey [FK_Bodega_Sucursal]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Bodega]  WITH CHECK ADD  CONSTRAINT [FK_Bodega_Sucursal] FOREIGN KEY([Emp_Id], [Suc_Id])
REFERENCES [dbo].[Sucursal] ([Emp_Id], [Suc_Id])
GO
ALTER TABLE [dbo].[Bodega] CHECK CONSTRAINT [FK_Bodega_Sucursal]
GO
/****** Object:  ForeignKey [FK_ArticuloProveedor_Articulo]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[ArticuloProveedor]  WITH CHECK ADD  CONSTRAINT [FK_ArticuloProveedor_Articulo] FOREIGN KEY([Emp_Id], [Art_Id])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO
ALTER TABLE [dbo].[ArticuloProveedor] CHECK CONSTRAINT [FK_ArticuloProveedor_Articulo]
GO
/****** Object:  ForeignKey [FK_ArticuloProveedor_Proveedor]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[ArticuloProveedor]  WITH CHECK ADD  CONSTRAINT [FK_ArticuloProveedor_Proveedor] FOREIGN KEY([Emp_Id], [Prov_Id])
REFERENCES [dbo].[Proveedor] ([Emp_Id], [Prov_Id])
GO
ALTER TABLE [dbo].[ArticuloProveedor] CHECK CONSTRAINT [FK_ArticuloProveedor_Proveedor]
GO
/****** Object:  ForeignKey [FK_ArticuloKardex_ArticuloBodega]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[ArticuloKardex]  WITH CHECK ADD  CONSTRAINT [FK_ArticuloKardex_ArticuloBodega] FOREIGN KEY([Emp_Id], [Suc_Id], [Bod_Id], [Art_Id])
REFERENCES [dbo].[ArticuloBodega] ([Emp_Id], [Suc_Id], [Bod_Id], [Art_Id])
GO
ALTER TABLE [dbo].[ArticuloKardex] CHECK CONSTRAINT [FK_ArticuloKardex_ArticuloBodega]
GO
/****** Object:  ForeignKey [FK_CajaCierreDetalle_CajaCierreEncabezado]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[CajaCierreDetalle]  WITH CHECK ADD  CONSTRAINT [FK_CajaCierreDetalle_CajaCierreEncabezado] FOREIGN KEY([Emp_Id], [Suc_Id], [Caja_Id], [Cierre_Id])
REFERENCES [dbo].[CajaCierreEncabezado] ([Emp_Id], [Suc_Id], [Caja_Id], [Cierre_Id])
GO
ALTER TABLE [dbo].[CajaCierreDetalle] CHECK CONSTRAINT [FK_CajaCierreDetalle_CajaCierreEncabezado]
GO
/****** Object:  ForeignKey [FK_FacturaPago_Banco]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[FacturaPago]  WITH CHECK ADD  CONSTRAINT [FK_FacturaPago_Banco] FOREIGN KEY([Emp_Id], [Banco_Id])
REFERENCES [dbo].[Banco] ([Emp_Id], [Banco_Id])
GO
ALTER TABLE [dbo].[FacturaPago] CHECK CONSTRAINT [FK_FacturaPago_Banco]
GO
/****** Object:  ForeignKey [FK_FacturaPago_FacturaEncabezado]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[FacturaPago]  WITH CHECK ADD  CONSTRAINT [FK_FacturaPago_FacturaEncabezado] FOREIGN KEY([Emp_Id], [Suc_Id], [Caja_Id], [TipoDoc_Id], [Documento_Id])
REFERENCES [dbo].[FacturaEncabezado] ([Emp_Id], [Suc_Id], [Caja_Id], [TipoDoc_Id], [Documento_Id])
GO
ALTER TABLE [dbo].[FacturaPago] CHECK CONSTRAINT [FK_FacturaPago_FacturaEncabezado]
GO
/****** Object:  ForeignKey [FK_FacturaPago_Tarjeta]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[FacturaPago]  WITH CHECK ADD  CONSTRAINT [FK_FacturaPago_Tarjeta] FOREIGN KEY([Emp_Id], [Tarjeta_Id])
REFERENCES [dbo].[Tarjeta] ([Emp_Id], [Tarjeta_Id])
GO
ALTER TABLE [dbo].[FacturaPago] CHECK CONSTRAINT [FK_FacturaPago_Tarjeta]
GO
/****** Object:  ForeignKey [FK_FacturaPago_TipoPago]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[FacturaPago]  WITH CHECK ADD  CONSTRAINT [FK_FacturaPago_TipoPago] FOREIGN KEY([Emp_Id], [TipoPago_Id])
REFERENCES [dbo].[TipoPago] ([Emp_Id], [TipoPago_Id])
GO
ALTER TABLE [dbo].[FacturaPago] CHECK CONSTRAINT [FK_FacturaPago_TipoPago]
GO
/****** Object:  ForeignKey [FK_ArticuloConjunto_Articulo]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[ArticuloConjunto]  WITH CHECK ADD  CONSTRAINT [FK_ArticuloConjunto_Articulo] FOREIGN KEY([Emp_Id], [Art_Id])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO
ALTER TABLE [dbo].[ArticuloConjunto] CHECK CONSTRAINT [FK_ArticuloConjunto_Articulo]
GO
/****** Object:  ForeignKey [FK_ArticuloConjunto_Articulo1]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[ArticuloConjunto]  WITH CHECK ADD  CONSTRAINT [FK_ArticuloConjunto_Articulo1] FOREIGN KEY([Emp_Id], [ArtConjunto_Id])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO
ALTER TABLE [dbo].[ArticuloConjunto] CHECK CONSTRAINT [FK_ArticuloConjunto_Articulo1]
GO
/****** Object:  ForeignKey [FK_ArticuloEquivalente_Articulo]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[ArticuloEquivalente]  WITH CHECK ADD  CONSTRAINT [FK_ArticuloEquivalente_Articulo] FOREIGN KEY([Emp_Id], [Art_Id])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO
ALTER TABLE [dbo].[ArticuloEquivalente] CHECK CONSTRAINT [FK_ArticuloEquivalente_Articulo]
GO
/****** Object:  ForeignKey [FK_FacturaDetalle_Articulo]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[FacturaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_FacturaDetalle_Articulo] FOREIGN KEY([Emp_Id], [Art_Id])
REFERENCES [dbo].[Articulo] ([Emp_Id], [Art_Id])
GO
ALTER TABLE [dbo].[FacturaDetalle] CHECK CONSTRAINT [FK_FacturaDetalle_Articulo]
GO
/****** Object:  ForeignKey [FK_FacturaDetalle_FacturaEncabezado]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[FacturaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_FacturaDetalle_FacturaEncabezado] FOREIGN KEY([Emp_Id], [Suc_Id], [Caja_Id], [TipoDoc_Id], [Documento_Id])
REFERENCES [dbo].[FacturaEncabezado] ([Emp_Id], [Suc_Id], [Caja_Id], [TipoDoc_Id], [Documento_Id])
GO
ALTER TABLE [dbo].[FacturaDetalle] CHECK CONSTRAINT [FK_FacturaDetalle_FacturaEncabezado]
GO
/****** Object:  ForeignKey [FK_Sucursal_Empresa]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Sucursal]  WITH CHECK ADD  CONSTRAINT [FK_Sucursal_Empresa] FOREIGN KEY([Emp_Id])
REFERENCES [dbo].[Empresa] ([Emp_Id])
GO
ALTER TABLE [dbo].[Sucursal] CHECK CONSTRAINT [FK_Sucursal_Empresa]
GO
/****** Object:  ForeignKey [FK_Vendedor_Empresa]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[Vendedor]  WITH CHECK ADD  CONSTRAINT [FK_Vendedor_Empresa] FOREIGN KEY([Emp_Id])
REFERENCES [dbo].[Empresa] ([Emp_Id])
GO
ALTER TABLE [dbo].[Vendedor] CHECK CONSTRAINT [FK_Vendedor_Empresa]
GO
/****** Object:  ForeignKey [FK_FacturaDevolucion_FacturaEncabezado]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[FacturaDevolucion]  WITH CHECK ADD  CONSTRAINT [FK_FacturaDevolucion_FacturaEncabezado] FOREIGN KEY([Emp_Id], [Suc_Id], [Caja_Id], [TipoDoc_Id], [Documento_Id])
REFERENCES [dbo].[FacturaEncabezado] ([Emp_Id], [Suc_Id], [Caja_Id], [TipoDoc_Id], [Documento_Id])
GO
ALTER TABLE [dbo].[FacturaDevolucion] CHECK CONSTRAINT [FK_FacturaDevolucion_FacturaEncabezado]
GO
/****** Object:  ForeignKey [FK_FacturaDevolucion_FacturaEncabezado1]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[FacturaDevolucion]  WITH CHECK ADD  CONSTRAINT [FK_FacturaDevolucion_FacturaEncabezado1] FOREIGN KEY([Emp_Id], [Dev_Suc_Id], [Dev_Caja_Id], [Dev_TipoDoc_Id], [Dev_Documento_Id])
REFERENCES [dbo].[FacturaEncabezado] ([Emp_Id], [Suc_Id], [Caja_Id], [TipoDoc_Id], [Documento_Id])
GO
ALTER TABLE [dbo].[FacturaDevolucion] CHECK CONSTRAINT [FK_FacturaDevolucion_FacturaEncabezado1]
GO
/****** Object:  ForeignKey [FK_SubCategoria_Categoria]    Script Date: 05/01/2012 23:51:56 ******/
ALTER TABLE [dbo].[SubCategoria]  WITH CHECK ADD  CONSTRAINT [FK_SubCategoria_Categoria] FOREIGN KEY([Emp_Id], [Cat_Id])
REFERENCES [dbo].[Categoria] ([Emp_Id], [Cat_Id])
GO
ALTER TABLE [dbo].[SubCategoria] CHECK CONSTRAINT [FK_SubCategoria_Categoria]
GO
