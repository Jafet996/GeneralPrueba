/*
   Friday, June 08, 201211:15:00 PM
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
CREATE UNIQUE NONCLUSTERED INDEX IX_ArticuloArtPadre ON dbo.Articulo
	(
	Emp_Id,
	ArtPadre
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.Articulo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
