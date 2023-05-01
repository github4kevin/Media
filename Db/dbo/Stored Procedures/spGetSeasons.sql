
/**********************************
Get Seasons with Optional Parameter
**********************************/

CREATE PROCEDURE spGetSeasons
AS
   BEGIN
      SET NOCOUNT ON
      SELECT *
      FROM vwSeasons AS vws
   END