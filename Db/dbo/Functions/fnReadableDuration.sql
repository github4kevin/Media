/******************
 Readable Duration 
******************/

CREATE FUNCTION fnReadableDuration (@durationseconds INT)
RETURNS VARCHAR(100)
AS
	BEGIN
		DECLARE
				 @output VARCHAR(100),
				 @vardt  DATETIME     = DATEADD(SECOND, @durationseconds, 0);
		SET @output = CASE
						  -- Less than 1 Hr (Mins & Secs)
							  WHEN @durationseconds < 3600
							  THEN CAST(DATEPART(MINUTE, @vardt) AS VARCHAR(2)) + ' Mins, ' 
									 + CAST(DATEPART(SECOND, @vardt) AS VARCHAR(2)) + ' Secs'

						  -- Between 1 Hr & 1 Day (Hrs, Mins, & Secs)
							  WHEN @durationseconds >= 3600
									 AND @durationseconds < 86400
							  THEN CAST(DATEPART(HOUR, @vardt) AS VARCHAR(2)) + ' Hrs, ' 
									 + CAST(DATEPART(MINUTE, @vardt) AS VARCHAR(2)) + ' Mins'
								 --  + CAST(DATEPART(SECOND, @vardt) AS VARCHAR(2)) + ' Secs '

						  -- Between 1 Day & 1 Month (Days, Hrs, and Mins)
							  WHEN @durationseconds BETWEEN 86400 AND 2629800
							  THEN CAST(DATEPART(DD, @vardt) - 1 AS VARCHAR(2)) + ' Days, ' 
									 + CAST(DATEPART(HOUR, @vardt) AS VARCHAR(2)) + ' Hrs' 
								 --  + CAST(DATEPART(MINUTE, @vardt) AS VARCHAR(2)) + ' Mins'

						  -- Between 1 Month and 1 Year (Months, Days, & Hrs)
							  WHEN @durationseconds BETWEEN 2629801 AND 31557600
							  THEN CAST(DATEPART(MONTH, @vardt) - 1 AS VARCHAR(2)) + ' Months, ' 
									 + CAST(DATEPART(DD, @vardt) - 1 AS VARCHAR(2)) + ' Days, '
									 + CAST(DATEPART(HOUR, @vardt) AS VARCHAR(2)) + ' Hrs' 

						  -- Between 1 Year & 50 Years (Yrs, Months, & Days)
							  WHEN @durationseconds > 31557600
							  THEN CAST(DATEDIFF(YEAR, 0, @vardt) AS VARCHAR(10)) + ' Yrs, ' 
									 + CAST(DATEPART(MONTH, @vardt) - 1 AS VARCHAR(2)) + ' Months, '
									 + CAST(DATEPART(DD, @vardt) - 1 AS VARCHAR(2)) + ' Days'
						  END
		RETURN @output;
	END
