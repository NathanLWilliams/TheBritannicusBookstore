USE [C:\USERS\NATHAN\DROPBOX\YEAR 3\DBAS\FINALPROJECTAPPLICATION\FINALPROJECTAPPLICATION\BIN\DEBUG\BRITANNICUS_DB.MDF]
GO

/****** Object:  StoredProcedure [dbo].[UpdateMap]    Script Date: 05/12/2018 2:53:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nathan Williams
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[UpdateMap]
	-- Add the parameters for the stored procedure here
	@mapID int,
	@itemDescription varchar(50),
	@price decimal(7,2),
	@edition tinyint,
	@publisher varchar(30),
	@year smallint,
	@conditionID int,
	@quantity int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE items SET
	itemDescription = @itemDescription,
	price = @price,
	edition = @edition
	WHERE itemID = @mapID;

	UPDATE maps SET
	publisher = @publisher,
	year = @year
	WHERE mapID = @mapID;

	UPDATE inventory SET
	conditionID = @conditionID,
	quantity = @quantity
	WHERE itemID = @mapID;
    
	RETURN @@ROWCOUNT;
END
GO


