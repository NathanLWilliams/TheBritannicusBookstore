-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nathan Williams
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE InsertInterest 
	-- Add the parameters for the stored procedure here
	@collectorID int,
	@tagID int,
	@itemTypeID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO customerInterests (customerID, tagID, itemTypeID) 
	VALUES (@collectorID, @tagID, @itemTypeID);

	RETURN @@ROWCOUNT;
END
GO
