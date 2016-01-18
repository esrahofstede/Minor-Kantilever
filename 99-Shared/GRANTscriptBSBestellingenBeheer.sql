
IF NOT EXISTS 
    (SELECT name  
     FROM master.sys.server_principals
     WHERE name = 'IIS APPPOOL\DefaultAppPool')
BEGIN
    CREATE LOGIN [IIS APPPOOL\DefaultAppPool] 
	FROM WINDOWS
END
GO

USE [GoudGeel_BSBestellingenBeheer_Acceptatie]	-- RENAME this to the name of the database that you are installing
GO

IF NOT EXISTS
    (SELECT name
     FROM sys.database_principals
     WHERE name = 'IIS APPPOOL\DefaultAppPool')
BEGIN
    CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool]
END

ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO