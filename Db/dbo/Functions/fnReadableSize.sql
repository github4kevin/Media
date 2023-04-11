/*********************
Readable Size
Ex: 500MBs, 5GBs, 3TBs
*********************/

CREATE FUNCTION fnReadableSize (@size INT)
RETURNS VARCHAR(10)
AS
	BEGIN
		DECLARE
				 @output VARCHAR(10)
		SET @output = CASE
						  -- Less than 1GB
							  WHEN @size < 1000
							  THEN CAST(@size AS VARCHAR(25)) + 'MBs'

						  -- 1GB to 999GB
							  WHEN @size BETWEEN 1000 AND 999999
							  THEN CAST(CAST(@size / 1024.0 AS DECIMAL(10, 2)) AS VARCHAR(25)) + 'GBs'

						  -- Greater than 1TB
							  WHEN @size > 1000000
							  THEN CAST(CAST(@size / 1024.0 / 1024.0 AS DECIMAL(10, 2)) AS VARCHAR(25)) + 'TBs'
						  END
		RETURN @output
	END