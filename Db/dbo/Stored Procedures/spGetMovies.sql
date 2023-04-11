
/*********************************
Get Movies with Optional Parameter
*********************************/

CREATE PROCEDURE spGetMovies
AS
   BEGIN
      SET NOCOUNT ON
      SELECT *
      FROM vwMovies AS vwm
   END