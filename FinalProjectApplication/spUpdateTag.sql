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
CREATE PROCEDURE UpdateTag 
	-- Add the parameters for the stored procedure here
	@tagID int, 
	@tagDescription varchar(15)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE tags SET tagDescription = @tagDescription
	WHERE tagID = @tagID;

	RETURN @@ROWCOUNT;
END
GO
