
/*********
Get Videos
*********/

CREATE PROCEDURE spGetVideos
AS
   BEGIN
      SET NOCOUNT ON
      SELECT *
      FROM vwVideos
   END