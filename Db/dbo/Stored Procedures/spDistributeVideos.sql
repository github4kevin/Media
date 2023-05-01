
/***********************
-- Distribute YouTube --
***********************/

CREATE PROCEDURE spDistributeVideos
AS
   BEGIN
      SET NOCOUNT ON
      INSERT INTO Videos
             SELECT pd.episode_name AS video_name, 
                    pd.episode_width, 
                    pd.episode_height, 
                    pd.episode_size, 
                    pd.episode_duration
             FROM PlexData AS pd
             WHERE pd.library_name LIKE '%YouTube%'
   END