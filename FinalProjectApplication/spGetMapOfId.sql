USE [C:\USERS\777588\DROPBOX\YEAR 3\DBAS\FINALPROJECTAPPLICATION\FINALPROJECTAPPLICATION\BIN\DEBUG\BRITANNICUS_DB.MDF]
GO

/****** Object:  StoredProcedure [dbo].[GetMapOfId]    Script Date: 2018-12-05 1:43:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Nathan Williams
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetMapOfId] 
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT mapID, publisher, itemDescription, year, edition, quantity, conditionID, price
    FROM maps, inventory, items
    WHERE maps.mapID = @id AND inventory.itemID = maps.mapID AND maps.mapID = items.itemID AND items.isActive = 1;
END
GO


