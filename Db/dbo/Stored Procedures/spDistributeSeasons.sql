
/***********************
-- Distribute Seasons --
***********************/

CREATE PROCEDURE spDistributeSeasons
AS
   BEGIN
      SET NOCOUNT ON

      -- Temp Table to Hold the Seasons (For Testing)
      DECLARE 
             @ss TABLE (show_id              INT, 
                        show_name            NVARCHAR(200), 
                        season_number        INT, 
                        season_episodes      INT, 
                        season_width         INT, 
                        season_height        INT, 
                        season_size          INT, 
                        season_duration      INT, 
                        season_released_date BIGINT, 
                        season_added_date    BIGINT)

      -- Not Using Temp Table for Official Insert 
      INSERT INTO Seasons
             SELECT show_id, 
                    show_name, 
                    season_number, 
                    COUNT(season_number) AS season_episodes, 
                    AVG(episode_width) AS season_width, 
                    AVG(episode_height) AS season_height, 
                    SUM(episode_size) AS season_size, 
                    SUM(episode_duration) AS season_duration, 
                    MIN(episode_release_date) AS season_released_date, 
                    MAX(episode_added_date) AS season_added_date
             FROM PlexData AS pd
             WHERE pd.show_id <> 0
                   AND pd.library_name LIKE '%Shows%'
             GROUP BY show_id, 
                      show_name, 
                      season_number
   END