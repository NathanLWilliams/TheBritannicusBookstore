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
CREATE PROCEDURE InsertCollector 
	-- Add the parameters for the stored procedure here
	@customerTypeID int,
	@firstName varchar(25),
	@lastName varchar(25),
	@phoneNumber varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO customers(customerTypeID, firstName, lastName, phoneNumber)
	VALUES(@customerTypeID, @firstName, @lastName, @phoneNumber);

	RETURN SCOPE_IDENTITY();
END
GO
