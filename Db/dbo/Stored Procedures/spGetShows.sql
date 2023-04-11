
/********************************
Get Shows with Optional Parameter
********************************/

CREATE PROCEDURE spGetShows
AS
   BEGIN
      SET NOCOUNT ON
      SELECT *
      FROM vwShows
   END