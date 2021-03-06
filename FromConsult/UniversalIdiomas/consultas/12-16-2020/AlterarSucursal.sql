/*
   Wednesday, December 16, 202011:15:00 AM
   User: udi
   Server: 45.224.202.8,59433
   Database: UniversalProduccion
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
ALTER TABLE dbo.Sucursal ADD
	CabysCodigo nchar(20) NULL
GO
ALTER TABLE dbo.Sucursal SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
