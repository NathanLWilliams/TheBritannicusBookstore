USE [C:\USERS\NATHAN\DROPBOX\YEAR 3\DBAS\FINALPROJECTAPPLICATION\FINALPROJECTAPPLICATION\BRITANNICUS_DB.MDF]
GO

INSERT INTO [dbo].[employeeAccount]
           ([username]
           ,[employeeID]
           ,[password]
           ,[dateCreated]
           ,[lastAccess])
     VALUES('connor123', 2, HASHBYTES('SHA2_256', 'password'), GETDATE(), GETDATE())
GO


