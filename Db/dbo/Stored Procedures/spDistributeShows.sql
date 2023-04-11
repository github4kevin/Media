/*********************
-- Distribute Shows --
*********************/

CREATE PROCEDURE spDistributeShows
AS
	BEGIN
		SET NOCOUNT ON

		-- Temp Table Creation to Group Show Information (For Testing Only) -- 
		DECLARE
				 @shows TABLE
								  (show_id             INT,
									show_name           NVARCHAR(200),
									show_seasons        INT,
									show_episodes       INT,
									show_width          INT,
									show_height         INT,
									show_size           INT,
									show_duration       INT,
									show_release_date   BIGINT,
									show_added_date     BIGINT,
									show_rating         DECIMAL(5, 2),
									show_content_rating VARCHAR(20),
									show_collection     VARCHAR(50))

		-- Not Using Temp Table for Official Insert  
		INSERT INTO Shows
				 SELECT show_id,
						  show_name,
						  show_seasons = NULL, -- Not Calculated Yet
						  COUNT(show_id) AS            show_episodes,
						  AVG(episode_width) AS        show_width,
						  AVG(episode_height) AS       show_height,
						  SUM(episode_size) AS         show_size,
						  SUM(episode_duration) AS     show_duration,
						  MIN(episode_release_date) AS show_release_date,
						  MAX(episode_added_date) AS   show_added_date,
						  show_rating,
						  show_content_rating,
						  show_collection
				 FROM PlexData
				 WHERE show_id <> 0
						 AND library_name LIKE '%Shows%'
				 GROUP BY show_id,
							 show_name,
							 show_rating,
							 show_content_rating,
							 show_collection

		-- DROP Temp Table if Exist for Multiple Executions (If Needed) --
		IF OBJECT_ID('TempDB..#SeasonCnt') IS NOT NULL
			DROP TABLE #SeasonCnt

		-- New Temp Table to Hold Total Seasons per Show --
		CREATE TABLE #SeasonCnt
						 (show_id INT)

		-- Calculating Total Seasons per Show (Thanks to the Group By of Season Numbers) --  
		INSERT INTO #SeasonCnt
				 SELECT show_id
				 FROM PlexData
				 WHERE show_id <> 0
						 AND library_name LIKE '%Shows%'
				 GROUP BY show_id,
							 season_number

		-- Update The Calculated Seasons per Show into the Shows Table --
		UPDATE s
		SET
			s.show_seasons = (SELECT COUNT(*)
									FROM #SeasonCnt AS sc
									WHERE sc.show_id = s.show_id
									GROUP BY sc.show_id)
		FROM Shows s
			  INNER JOIN #SeasonCnt AS #s ON s.show_id = #s.show_id
	END