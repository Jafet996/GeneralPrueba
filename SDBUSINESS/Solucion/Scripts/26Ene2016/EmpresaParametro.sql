/*
   Tuesday, January 26, 20167:42:19 PM
   User: sa
   Server: JTREJOS-PC\SERVER2008EXPR2
   Database: Perfumes12Oct2015
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
ALTER TABLE dbo.EmpresaParametro ADD
	DiasMayoreo smallint NOT NULL CONSTRAINT DF_EmpresaParametro_DiasMayoreo DEFAULT 0
GO
ALTER TABLE dbo.EmpresaParametro SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
