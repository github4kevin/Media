
/***********
Get Episodes
***********/

CREATE PROCEDURE spGetEpisodes
AS
   BEGIN
      SET NOCOUNT ON
      SELECT *
      FROM vwEpisodes AS vwe
   END