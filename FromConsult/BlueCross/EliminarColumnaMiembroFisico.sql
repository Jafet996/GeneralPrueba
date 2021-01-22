ALTER  TABLE MiembroFisico 
DROP COLUMN RangoIngreso



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
	RangoIngreso numeric(18, 2) NULL
GO
ALTER TABLE dbo.MiembroFisico ADD CONSTRAINT
	DF_MiembroFisico_RangoIngreso DEFAULT 0 FOR RangoIngreso
GO
ALTER TABLE dbo.MiembroFisico SET (LOCK_ESCALATION = TABLE)
GO
COMMIT