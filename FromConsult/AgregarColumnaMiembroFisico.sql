/*
   lunes, 14 de diciembre de 202021:52:38
   User: appbluecross
   Server: 40.70.130.129\MSSQLSERVER,17177
   Database: UAUBlueCross_STAGE
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
ALTER TABLE dbo.MiembroFisico ADD
	RangoIngreso varchar(255) NULL
GO
ALTER TABLE dbo.MiembroFisico SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
