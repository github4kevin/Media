/***************************
 Function to Get Proper Case
***************************/

CREATE FUNCTION [fnGetProperCase] (@text AS VARCHAR(8000)) 
RETURNS VARCHAR(8000)
AS
   BEGIN
      DECLARE 
             @reset BIT, 
             @ret   VARCHAR(8000), 
             @index INT, 
             @c     CHAR(1);
      IF @text IS NULL
         RETURN NULL;
      SELECT @reset = 1, 
             @index = 1, 
             @ret = '';
      WHILE (@index <= LEN(@text)) 
         SELECT @c = SUBSTRING(@text, @index, 1), 
                @ret = @ret
                       + CASE
                            WHEN @reset = 1
                            THEN UPPER(@c)
                            ELSE LOWER(@c)
                         END, 
                @reset = CASE
                            WHEN @c LIKE '[a-zA-Z]'
                            THEN 0
                            ELSE 1
                         END, 
                @index = @index + 1
      RETURN @ret
   END