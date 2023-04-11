
/************************************
Get Libraries with Optional Parameter
************************************/

CREATE PROCEDURE spGetLibraries
AS
   BEGIN
      SET NOCOUNT ON
      SELECT *
      FROM vwLibraries AS vwl
   END