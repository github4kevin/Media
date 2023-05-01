
/*********************************
Get Music with Optional Parameters
*********************************/

CREATE PROCEDURE spGetMusic
AS
   BEGIN
      SET NOCOUNT ON
      SELECT *
      FROM vwMusic
   END