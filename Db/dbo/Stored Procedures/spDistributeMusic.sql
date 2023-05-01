
/*********************
-- Distribute Music --
*********************/

CREATE PROCEDURE spDistributeMusic
AS
   BEGIN
      SET NOCOUNT ON
      INSERT INTO Music
             SELECT pd.episode_id AS music_id, 
                    pd.episode_name AS music_name, 
                    pd.show_name AS artist_name, 
                    pd.music_album AS album_name, 
                    pd.season_studio AS music_studio, 
                    pd.episode_size AS music_size, 
                    pd.episode_duration AS music_duration, 
                    pd.episode_added_date AS music_added_date, 
                    pd.episode_release_date AS music_release_date,
                    pd.file_type
             FROM PlexData AS pd
             WHERE pd.library_name LIKE '%Music%'
   END