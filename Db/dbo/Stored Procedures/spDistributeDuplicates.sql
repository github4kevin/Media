
/**************************
-- Distribute Duplicates --
**************************/

CREATE PROCEDURE spDistributeDuplicates
AS
	BEGIN
		SET NOCOUNT ON
		DECLARE @media TABLE (media_type VARCHAR(25),
									 media_name NVARCHAR(255),
									 media_released BIGINT,
									 total_backups INT)
		INSERT INTO @media
			-- Movies
			SELECT
				'Movie' AS media_type,
				m.movie_name AS media_name,
				m.movie_release_date AS media_released,
				COUNT(*) AS cnt
			FROM Movies AS m
			GROUP BY m.movie_name,
						m.movie_release_date
			HAVING COUNT(*) > 1
		INSERT INTO @media
			-- Shows
			SELECT
				'Show' AS media_type,
				s.show_name AS media_name,
				s.show_release_date AS media_released,
				COUNT(*) AS cnt
			FROM Shows AS s
			GROUP BY s.show_name,
						s.show_release_date
			HAVING COUNT(*) > 1

		-- New Temp Table Including Server Name

		DECLARE @server TABLE (media_type VARCHAR(25),
									  media_name NVARCHAR(255),
									  media_released BIGINT,
									  total_backups INT)
		INSERT INTO @server
			-- Movies
			SELECT
				m.media_type, m.media_name, m.media_released, m.total_backups
			FROM @media AS m
			INNER JOIN PlexData AS pd ON m.media_name = pd.episode_name
			ORDER BY m.media_type,
						m.media_name
		INSERT INTO @server
			-- Shows
			SELECT
				m.media_type, m.media_name, m.media_released, m.total_backups
			FROM @media AS m
			INNER JOIN PlexData AS pd ON m.media_name = pd.show_name
			GROUP BY m.media_type,
						m.media_name,
						m.media_released,
						m.total_backups
			ORDER BY m.media_type,
						m.media_name

		-- Gathering Final Results

		DECLARE @final TABLE (media_type VARCHAR(25),
									 media_name NVARCHAR(255),
									 media_size INT,
									 media_duration INT,
									 media_released DATE,
									 total_backups INT)
		INSERT INTO Duplicates
			SELECT
				d.media_type,
				d.media_name,
				CASE
					WHEN media_type = 'Show'
					THEN (SELECT
								SUM(pd.episode_size)
							FROM PlexData AS pd
							WHERE pd.show_name = d.media_name)
					WHEN media_type = 'Movie'
					THEN (SELECT
								SUM(pd.episode_size)
							FROM PlexData AS pd
							WHERE pd.episode_name = d.media_name) END AS media_size,
				CASE
					WHEN d.media_type = 'Show'
					THEN (SELECT TOP 1
								s.show_duration
							FROM Shows AS s
							WHERE s.show_name = d.media_name)
					WHEN d.media_type = 'Movie'
					THEN (SELECT TOP 1
								m.movie_duration
							FROM Movies AS m
							WHERE m.movie_name = d.media_name) END AS media_duration,
				CASE
					WHEN d.media_type = 'Show'
					THEN (SELECT
								AVG(s.show_height)
							FROM Shows AS s
							WHERE s.show_name = d.media_name)
					WHEN d.media_type = 'Movie'
					THEN (SELECT TOP 1
								m.movie_height
							FROM Movies AS m
							WHERE m.movie_name = d.media_name) END AS media_quality,
				CAST(DATEADD(s, d.media_released, '19700101') AS DATE) AS media_released,
				d.total_backups
			FROM @server AS d
			ORDER BY d.media_type,
						d.media_name
	END