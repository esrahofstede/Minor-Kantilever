USE [Goudgeel_PcSWinkelenDB_Acceptatie]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__MigrationHistory]') AND TYPE IN (N'U'))
DROP TABLE [dbo].__MigrationHistory


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WinkelmandItem]') AND TYPE IN (N'U'))
DROP TABLE [dbo].WinkelmandItem