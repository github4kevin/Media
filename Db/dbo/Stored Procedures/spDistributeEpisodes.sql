
/******************
Distribute Episodes
******************/

CREATE PROCEDURE spDistributeEpisodes
AS
   BEGIN
      SET NOCOUNT ON
      INSERT INTO Episodes
             SELECT pd.show_id, 
                    pd.show_name, 
                    pd.season_number, 
                    pd.episode_number, 
                    pd.episode_id, 
                    pd.episode_name, 
                    pd.episode_width, 
                    pd.episode_height, 
                    pd.episode_size, 
                    pd.episode_duration, 
                    pd.episode_fps, 
                    pd.episode_video_codec, 
                    pd.episode_audio_codec, 
                    pd.episode_release_date, 
                    pd.episode_added_date, 
                    pd.movie_audience_rating AS episode_rating, 
                    pd.show_content_rating
             FROM PlexData AS pd
             WHERE pd.library_name = 'Shows'
   END