USE [C:\USERS\NATHAN\DROPBOX\YEAR 3\DBAS\FINALPROJECTAPPLICATION\FINALPROJECTAPPLICATION\BIN\DEBUG\BRITANNICUS_DB.MDF]
GO

/****** Object:  StoredProcedure [dbo].[UpdatePeriodical]    Script Date: 05/12/2018 2:53:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nathan Williams
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[UpdatePeriodical]
	-- Add the parameters for the stored procedure here
	@periodicalID int,
	@itemDescription varchar(50),
	@price decimal(7,2),
	@edition tinyint,
	@companyName varchar(30),
	@genreID int,
	@date date,
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
	WHERE itemID = @periodicalID;

	UPDATE periodicals SET
	companyName = @companyName,
	genreID = @genreID,
	date = @date
	WHERE periodicalID = @periodicalID;

	UPDATE inventory SET
	conditionID = @conditionID,
	quantity = @quantity
	WHERE itemID = @periodicalID;

	RETURN @@ROWCOUNT;
END
GO


