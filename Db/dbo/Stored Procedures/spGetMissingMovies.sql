/**********************
-- Get Missing Movies --
**********************/

CREATE PROCEDURE spGetMissingMovies
AS
	BEGIN
		SET NOCOUNT ON
		SELECT
			*
		FROM vwOldMovies
	END