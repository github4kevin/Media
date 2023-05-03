/******************
 Get Episode Naming
******************/

CREATE PROCEDURE spGetNaming
AS
	BEGIN
		SET NOCOUNT ON
		DECLARE @name TABLE (show_name NVARCHAR(255),
									season_number INT,
									total_episodes INT,
									total_size INT,
									total_duration INT)
		INSERT INTO @name
			SELECT
				pd.show_name,
				pd.season_number,
				COUNT(pd.episode_id) AS total_episodes,
				SUM(pd.episode_size) AS total_size,
				SUM(pd.episode_duration) AS total_duration
			FROM PlexData AS pd
			WHERE pd.library_id = 2 -- Shows
				AND show_id NOT IN (13824, 14539) -- Naruto & One Piece  
				AND pd.file_path NOT LIKE '%[0-9]x[0-9]%'
				AND LEN(show_name) < 75 -- Short Named TV Shows
			GROUP BY pd.show_name,
						pd.season_number

		-- Select Final Results --
		SELECT
			n.show_name,
			n.season_number,
			n.total_episodes,
			dbo.fnReadableSize(n.total_size) AS total_size,
			dbo.fnReadableDuration(n.total_duration) AS total_duration,

			/****************
			Grid Sort Columns
			****************/

			n.total_size AS total_sort_size,
			n.total_duration AS total_sort_duration
		FROM @name AS n
	END