/*
   Sunday, June 03, 20125:25:34 PM
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
ALTER TABLE dbo.SubCategoria
	DROP CONSTRAINT FK_SubCategoria_Categoria
GO
ALTER TABLE dbo.Categoria SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.SubCategoria
	DROP CONSTRAINT DF_SubCategoria_Activo
GO
ALTER TABLE dbo.SubCategoria
	DROP CONSTRAINT DF_SubCategoria_UltimaModificacion
GO
CREATE TABLE dbo.Tmp_SubCategoria
	(
	Emp_Id smallint NOT NULL,
	Cat_Id smallint NOT NULL,
	SubCat_Id smallint NOT NULL,
	Nombre varchar(50) NOT NULL,
	Activo bit NOT NULL,
	BusquedaRapida bit NOT NULL,
	UltimaModificacion datetime NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_SubCategoria SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_SubCategoria ADD CONSTRAINT
	DF_SubCategoria_Activo DEFAULT ((1)) FOR Activo
GO
ALTER TABLE dbo.Tmp_SubCategoria ADD CONSTRAINT
	DF_SubCategoria_BusquedaRapida DEFAULT 0 FOR BusquedaRapida
GO
ALTER TABLE dbo.Tmp_SubCategoria ADD CONSTRAINT
	DF_SubCategoria_UltimaModificacion DEFAULT (getdate()) FOR UltimaModificacion
GO
IF EXISTS(SELECT * FROM dbo.SubCategoria)
	 EXEC('INSERT INTO dbo.Tmp_SubCategoria (Emp_Id, Cat_Id, SubCat_Id, Nombre, Activo, UltimaModificacion)
		SELECT Emp_Id, Cat_Id, SubCat_Id, Nombre, Activo, UltimaModificacion FROM dbo.SubCategoria WITH (HOLDLOCK TABLOCKX)')
GO
ALTER TABLE dbo.Articulo
	DROP CONSTRAINT FK_Articulo_SubCategoria
GO
DROP TABLE dbo.SubCategoria
GO
EXECUTE sp_rename N'dbo.Tmp_SubCategoria', N'SubCategoria', 'OBJECT' 
GO
ALTER TABLE dbo.SubCategoria ADD CONSTRAINT
	PK_SubCategoria PRIMARY KEY CLUSTERED 
	(
	Emp_Id,
	Cat_Id,
	SubCat_Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.SubCategoria ADD CONSTRAINT
	FK_SubCategoria_Categoria FOREIGN KEY
	(
	Emp_Id,
	Cat_Id
	) REFERENCES dbo.Categoria
	(
	Emp_Id,
	Cat_Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Articulo ADD CONSTRAINT
	FK_Articulo_SubCategoria FOREIGN KEY
	(
	Emp_Id,
	Cat_Id,
	SubCat_Id
	) REFERENCES dbo.SubCategoria
	(
	Emp_Id,
	Cat_Id,
	SubCat_Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Articulo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
