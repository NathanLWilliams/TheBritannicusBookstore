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
CREATE PROCEDURE DeleteCollector 
	-- Add the parameters for the stored procedure here
	@collectorID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM customerInterests WHERE customerID = @collectorID;
	DELETE [transaction] FROM [transaction] 
	INNER JOIN invoice ON invoice.invoiceID = [transaction].invoiceID
	WHERE invoice.customerID = @collectorID;
	DELETE FROM invoice WHERE customerID = @collectorID;
	DELETE FROM customers WHERE customerID = @collectorID;

	RETURN @@ROWCOUNT;
END
GO
