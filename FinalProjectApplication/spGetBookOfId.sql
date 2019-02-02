USE [C:\USERS\777588\DROPBOX\YEAR 3\DBAS\FINALPROJECTAPPLICATION\FINALPROJECTAPPLICATION\BIN\DEBUG\BRITANNICUS_DB.MDF]
GO

/****** Object:  StoredProcedure [dbo].[GetBookOfId]    Script Date: 2018-12-05 1:42:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Nathan Williams
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetBookOfId] 
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT bookID, itemDescription, genreID, authorFirst, authorLast, publisher, publishDate, edition, quantity, conditionID, price
    FROM books, inventory, items
    WHERE books.bookID = @id AND inventory.itemID = books.bookID AND books.bookID = items.itemID AND items.isActive = 1;
END
GO


