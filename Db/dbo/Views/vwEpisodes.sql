
/***********
Episode View
***********/

CREATE VIEW vwEpisodes
AS
   SELECT e.show_name, 
          e.season_number, 
          e.episode_number, 
          e.episode_name, 
          dbo.fnReadableQuality (e.episode_height) AS episode_quality, 
          dbo.fnReadableSize (e.episode_size) AS episode_size, 
          dbo.fnReadableDuration (e.episode_duration) AS episode_duration,
          e.episode_fps, 
          e.episode_video_codec, 
          e.episode_audio_codec, 
          CAST(DATEADD(s, e.episode_release_date, '19700101') AS DATE) AS episode_release_date, 
          CAST(DATEADD(s, e.episode_added_date, '19700101') AS DATE) AS episode_added_date, 
          e.episode_rating, 
          e.show_content_rating, 
          e.episode_size AS episode_sort_size, 
          e.episode_duration AS episode_sort_duration, 
          e.episode_height AS episode_sort_quality
   FROM Episodes AS e
   INNER JOIN vwShows AS s ON e.show_id = s.show_id