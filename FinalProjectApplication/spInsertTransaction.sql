USE [C:\USERS\777588\DROPBOX\YEAR 3\DBAS\FINALPROJECTAPPLICATION\FINALPROJECTAPPLICATION\BIN\DEBUG\BRITANNICUS_DB.MDF]
GO

/****** Object:  StoredProcedure [dbo].[InsertTransaction]    Script Date: 2018-12-09 6:27:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Nathan Williams
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[InsertTransaction] 
	-- Add the parameters for the stored procedure here
	@invoiceID int,
	@itemID int,
	@quantity int,
	@conditionID int,
	@totalPrice decimal
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [transaction](invoiceID, itemID, quantity, totalPrice)
	VALUES (@invoiceID, @itemID, @quantity, @totalPrice);

	UPDATE inventory SET quantity = quantity - @quantity
	WHERE itemID = @itemID AND conditionID = @conditionID;

	RETURN @@ROWCOUNT;
END
GO


