/**********
Movies View
**********/

CREATE VIEW vwMovies
AS
   SELECT m.movie_id, 
          m.movie_name, 
          dbo.fnReadableSize (m.movie_size) AS movie_size, 
          dbo.fnReadableDuration (m.movie_duration) AS movie_duration, 
          dbo.fnReadableQuality (m.movie_height) AS movie_quality, 
          CAST(DATEADD(s, m.movie_release_date, '19700101') AS DATE) AS movie_release_date, 
          CAST(DATEADD(s, m.movie_added_date, '19700101') AS DATE) AS movie_added_date, 
          m.movie_critic_rating, 
          m.movie_audience_rating, 
          m.movie_content_rating, 
          m.movie_fps, 
          m.movie_video_codec, 
          m.movie_audio_codec, 
          m.movie_collection, 
          m.movie_file_path, 
          m.movie_file_type,

/*******************
Grid Sorting Columns
*******************/

          m.movie_size AS movie_sort_size, 
          m.movie_duration AS movie_sort_duration, 
          m.movie_height AS movie_sort_quality
   FROM Movies AS m