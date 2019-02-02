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
CREATE PROCEDURE SaveEmployee
	-- Add the parameters for the stored procedure here
	@employeeID int,
	@positionID int,
	@firstName varchar(25), 
	@lastName varchar(25), 
	@phoneNumber varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @result int;

    -- Insert statements for procedure here
	UPDATE employees SET 
	positionID = @positionID, 
	firstName = @firstName, 
	lastName = @lastName, 
	phoneNumber = @phoneNumber
	WHERE employeeID = @employeeID;

	SET @result = @@ROWCOUNT;

	IF @result = 0
	BEGIN
		INSERT INTO employees (positionID, firstName, lastName, phoneNumber) 
		VALUES(@positionID, @firstName, @lastName, @phoneNumber);
		SET @result = @@ROWCOUNT;
	END

	RETURN @result;
END
GO
