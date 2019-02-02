USE [C:\USERS\NATHAN\DROPBOX\YEAR 3\DBAS\FINALPROJECTAPPLICATION\FINALPROJECTAPPLICATION\BIN\DEBUG\BRITANNICUS_DB.MDF]
GO

/****** Object:  StoredProcedure [dbo].[InsertPeriodical]    Script Date: 05/12/2018 5:24:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nathan Williams
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[InsertPeriodical]
	-- Add the parameters for the stored procedure here
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
	DECLARE @id int;

    -- Insert statements for procedure here
	INSERT INTO items (itemTypeID, itemDescription, price, edition)
	VALUES (3, @itemDescription, @price, @edition);

	SELECT @id = SCOPE_IDENTITY();

	INSERT INTO periodicals (periodicalID, companyName, genreID, date)
	VALUES (@id, @companyName, @genreID, @date);

	INSERT INTO inventory (itemID, conditionID, quantity)
	VALUES (@id, @conditionID, @quantity);

	RETURN @id;
END
GO


