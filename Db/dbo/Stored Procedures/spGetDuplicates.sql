
/*************
Get Duplicates
*************/

CREATE PROCEDURE spGetDuplicates
AS
   BEGIN
      SET NOCOUNT ON
      SELECT *
      FROM vwDuplicates AS vd
   END