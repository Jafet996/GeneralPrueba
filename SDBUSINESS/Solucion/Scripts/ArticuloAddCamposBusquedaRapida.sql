/*
   Sunday, June 03, 20125:21:28 PM
   User: sa
   Server: JTREJOS-PC\SERVER2008EXPR2
   Database: BuenPrecioProduccion
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Articulo ADD
	BusquedaRapida bit NOT NULL CONSTRAINT DF_Articulo_BusquedaRapida DEFAULT 0,
	Frecuente bit NOT NULL CONSTRAINT DF_Articulo_Frecuente DEFAULT 0
GO
DECLARE @v sql_variant 
SET @v = N'Indica si aparece en la fusqueda rapida del punto de venta'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Articulo', N'COLUMN', N'BusquedaRapida'
GO
DECLARE @v sql_variant 
SET @v = N'Indica si aparece en la lista de articulos frecuentes de la busqueda rapida'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Articulo', N'COLUMN', N'Frecuente'
GO
ALTER TABLE dbo.Articulo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
