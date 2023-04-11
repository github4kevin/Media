/**********************
-- Distribute Movies --
**********************/

CREATE PROCEDURE spDistributeMovies
AS
	BEGIN
		SET NOCOUNT ON
		INSERT INTO Movies
				 SELECT episode_id AS           movie_id,
						  episode_name AS         movie_name,
						  episode_width AS        movie_width,
						  episode_height AS       movie_height,
						  episode_size AS         movie_size,
						  episode_duration AS     movie_duration,
						  episode_release_date AS movie_release_date,
						  episode_added_date AS   movie_added_date,
						  movie_critic_rating,
						  movie_audience_rating,
						  movie_content_rating,
						  episode_fps AS          movie_fps,
						  episode_video_codec AS  movie_video_codec,
						  episode_audio_codec AS  movie_audio_codec,
						  movie_collection,
						  movie_file_path = CASE
													  WHEN file_path LIKE '%/%'
													  THEN REVERSE(LEFT(REVERSE(file_path), CHARINDEX('/', REVERSE(file_path)) - 1))
													  WHEN file_path LIKE '%\%'
													  THEN REVERSE(LEFT(REVERSE(file_path), CHARINDEX('\', REVERSE(file_path)) - 1))
													  ELSE 'IDK'
												  END,
						  file_type AS            movie_file_type
				 FROM PlexData
				 WHERE show_id = 0 -- Excluding Shows
						 AND library_name LIKE '%Movies%' -- Excluding Other Libraries (Photos, Music, etc.)
				 ORDER BY episode_name
	END