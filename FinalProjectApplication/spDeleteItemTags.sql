USE [C:\USERS\NATHAN\DROPBOX\YEAR 3\DBAS\FINALPROJECTAPPLICATION\FINALPROJECTAPPLICATION\BIN\DEBUG\BRITANNICUS_DB.MDF]
GO

/****** Object:  StoredProcedure [dbo].[DeleteInterests]    Script Date: 05/12/2018 5:51:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Nathan Williams
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE DeleteItemTags
	-- Add the parameters for the stored procedure here
	@itemID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM itemTags WHERE itemID = @itemID;

	RETURN @@ROWCOUNT;
END
GO


