/**********************
-- Get Missing Movies --
**********************/

CREATE PROCEDURE spGetMissing
AS
	BEGIN
		SET NOCOUNT ON
		SELECT
			*
		FROM vwMissing
	END