/*************************
-- Distribute Libraries --
*************************/

CREATE PROCEDURE spDistributeLibraries
AS
	BEGIN
		SET NOCOUNT ON
		DECLARE
				 @lib TABLE
								(library_id       INT,
								 library_name     NVARCHAR(25),
								 show_total       NVARCHAR(50),
								 library_total    INT,
								 library_size     INT,
								 library_duration INT)
		INSERT INTO @lib
				 SELECT pd.library_id,
						  pd.library_name,
						  CASE
							  WHEN COUNT(DISTINCT(pd.show_id)) < 450
							  THEN 'N/A'
							  ELSE CAST(COUNT(DISTINCT(pd.show_id)) AS VARCHAR)
						  END AS                      show_total,
						  COUNT(pd.episode_id) AS     library_total,
						  SUM(pd.episode_size) AS     library_size,
						  SUM(pd.episode_duration) AS library_duration
				 FROM PlexData AS pd
				 GROUP BY pd.library_id,
							 pd.library_name

/***************************
 INSERT INTO Libraries Table
***************************/

		INSERT INTO Libraries
				 SELECT lib.library_id,
						  lib.library_name,
						  lib.show_total,
						  lib.library_total,
						  lib.library_size,
						  lib.library_duration
				 FROM @lib AS lib
				 ORDER BY lib.library_name
	END