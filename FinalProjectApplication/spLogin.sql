USE [C:\USERS\NATHAN\DROPBOX\YEAR 3\DBAS\FINALPROJECTAPPLICATION\FINALPROJECTAPPLICATION\BIN\DEBUG\BRITANNICUS_DB.MDF]
GO

/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 06/12/2018 4:41:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Nathan Williams
-- Create date: 16/11/2018
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[Login] 
	-- Add the parameters for the stored procedure here
	@username varchar(15), 
	@password varchar(64) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--SELECT username, password FROM employeeAccount
	--WHERE username=@username AND password=@password

	SELECT employees.employeeID, positionID, firstName, lastName, phoneNumber, lastAccess FROM employees
	INNER JOIN employeeAccount ON employeeAccount.employeeID=employees.employeeID
	WHERE username=@username AND password=@password
END
GO


