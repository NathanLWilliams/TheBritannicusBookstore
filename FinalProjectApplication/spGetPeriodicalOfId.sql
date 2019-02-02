USE [C:\USERS\777588\DROPBOX\YEAR 3\DBAS\FINALPROJECTAPPLICATION\FINALPROJECTAPPLICATION\BIN\DEBUG\BRITANNICUS_DB.MDF]
GO

/****** Object:  StoredProcedure [dbo].[GetPeriodicalOfId]    Script Date: 2018-12-05 1:44:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Nathan Williams
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetPeriodicalOfId] 
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT periodicalID, companyName, itemDescription, genreID, date, edition, quantity, conditionID, price
    FROM periodicals, inventory, items
    WHERE periodicals.periodicalID = @id AND inventory.itemID = periodicals.periodicalID AND periodicals.periodicalID = items.itemID AND items.isActive = 1;
END
GO


