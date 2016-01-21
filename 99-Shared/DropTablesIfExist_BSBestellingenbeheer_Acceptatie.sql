USE [GoudGeel_BSBestellingenBeheer_Acceptatie]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__MigrationHistory]') AND TYPE IN (N'U'))
DROP TABLE [dbo].__MigrationHistory


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Artikel]') AND TYPE IN (N'U'))
DROP TABLE [dbo].Artikel

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bestelling]') AND TYPE IN (N'U'))
DROP TABLE [dbo].Bestelling