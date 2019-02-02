USE [C:\USERS\NATHAN\DROPBOX\YEAR 3\DBAS\FINALPROJECTAPPLICATION\FINALPROJECTAPPLICATION\BIN\DEBUG\BRITANNICUS_DB.MDF]
GO

/****** Object:  StoredProcedure [dbo].[InsertBook]    Script Date: 05/12/2018 5:19:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nathan Williams
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[InsertBook] 
	-- Add the parameters for the stored procedure here
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
	SET NOCOUNT ON;
	DECLARE @id int;

	INSERT INTO items (itemTypeID, itemDescription, price, edition)
	VALUES (1, @itemDescription, @price, @edition);

	SELECT @id = SCOPE_IDENTITY();

	INSERT INTO books (bookID, genreID, authorFirst, authorLast, publisher, publishDate)
	VALUES (@id, @genreID, @authorFirst, @authorLast, @publisher, @publishDate);

	INSERT INTO inventory (itemID, conditionID, quantity)
	VALUES (@id, @conditionID, @quantity);

	RETURN @id;
END
GO


