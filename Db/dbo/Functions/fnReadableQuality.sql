
/***********************
Readable Quality
Ex: 480p vs 576p vs 720p
***********************/

CREATE FUNCTION fnReadableQuality (@height INT) 
RETURNS VARCHAR(5)
AS
   BEGIN
      DECLARE 
             @output VARCHAR(5);
      SET @output = CASE
                    -- Low SD 
                       WHEN @height < 480
                       THEN 'SD'

                    -- SD 
                       WHEN @height >= 480
                            AND @height < 576
                       THEN '480p'

                    -- SD+  
                       WHEN @height >= 576
                            AND @height < 720
                       THEN '576p'

                    -- HD  
                       WHEN @height >= 720
                            AND @height < 1080
                       THEN '720p'

                    -- UHD  
                       WHEN @height = 1080
                       THEN '1080p'

                    -- 4K 
                       WHEN @height > 1080
                       THEN '4K'
                    END;
      RETURN @output;
   END