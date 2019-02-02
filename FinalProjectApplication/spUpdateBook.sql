USE [C:\USERS\NATHAN\DROPBOX\YEAR 3\DBAS\FINALPROJECTAPPLICATION\FINALPROJECTAPPLICATION\BIN\DEBUG\BRITANNICUS_DB.MDF]
GO

/****** Object:  StoredProcedure [dbo].[UpdateBook]    Script Date: 05/12/2018 2:53:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Nathan Williams
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[UpdateBook] 
	-- Add the parameters for the stored procedure here
	@bookID int,
	@itemDescription varchar(50),
	@price decimal(7,2),
	@edition tinyint,
	@genreID int,
	@authorFirst varchar(25),
	@authorLast varchar(25),
	@publisher varchar(30),
	@publishDate date,
	@conditionID int,
	@quantity int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE items SET
	itemDescription = @itemDescription,
	price = @price,
	edition = @edition
	WHERE itemID = @bookID;

	UPDATE books SET
	genreID = @genreID,
	authorFirst = @authorFirst,
	authorLast = @authorLast,
	publisher = @publisher,
	publishDate = @publishDate
	WHERE bookID = @bookID;

	UPDATE inventory SET
	conditionID = @conditionID,
	quantity = @quantity
	WHERE itemID = @bookID;

	RETURN @@ROWCOUNT;
END
GO


