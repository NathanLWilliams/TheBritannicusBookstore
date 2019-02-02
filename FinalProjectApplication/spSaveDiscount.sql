USE [C:\USERS\NATHAN\DROPBOX\YEAR 3\DBAS\FINALPROJECTAPPLICATION\FINALPROJECTAPPLICATION\BIN\DEBUG\BRITANNICUS_DB.MDF]
GO

/****** Object:  StoredProcedure [dbo].[SaveEmployee]    Script Date: 05/12/2018 8:17:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Nathan Williams
-- Create date:
-- Description:
-- =============================================
CREATE PROCEDURE SaveDiscount
	-- Add the parameters for the stored procedure here
	@discountID int,
	@discountAmount decimal,
	@startDate date,
	@endDate date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @result int;

    -- Insert statements for procedure here
	UPDATE itemDiscounts SET 
	discountAmount = @discountAmount, 
	startDate = @startDate, 
	endDate = @endDate
	WHERE discountID = @discountID;

	SET @result = @@ROWCOUNT;

	IF @result = 0
	BEGIN
		INSERT INTO itemDiscounts (discountID, discountAmount, startDate, endDate) 
		VALUES(@discountID, @discountAmount, @startDate, @endDate);
		SET @result = @@ROWCOUNT;
	END

	RETURN @result;
END
GO


