USE [C:\USERS\777588\DROPBOX\YEAR 3\DBAS\FINALPROJECTAPPLICATION\FINALPROJECTAPPLICATION\BIN\DEBUG\BRITANNICUS_DB.MDF]
GO
/****** Object:  StoredProcedure [dbo].[Register]    Script Date: 2018-11-17 6:04:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nathan Williams
-- Create date: 16/11/2018
-- Description:	
-- =============================================
ALTER PROCEDURE [dbo].[Register] 
	-- Add the parameters for the stored procedure here
	@username varchar(15), 
	@password varchar(64),
	@employeeID int
AS
BEGIN
	DECLARE @count tinyint;
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO employeeAccount(username, employeeID, password, dateCreated, lastAccess)
	VALUES(@username, @employeeID, @password, GETDATE(), GETDATE());

	SELECT @count = count(*) 
	FROM employeeAccount 
	WHERE username = @username;

    RETURN @count
END
