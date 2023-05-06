/*************
 Readable Date
**************/

CREATE FUNCTION fnReadableDate (@date BIGINT)
RETURNS DATE
AS
	BEGIN
		DECLARE @output DATE
		SET @output = CAST(DATEADD(s, @date, '19700101') AS DATE)
		RETURN @output
	END
