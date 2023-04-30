/**************
Missing Movies
***************/
CREATE VIEW vwOldMovies
AS
	SELECT
		om.movie_name,
		dbo.fnReadableQuality(om.movie_height) AS movie_quality,
		dbo.fnReadableDuration(om.movie_duration) AS movie_duration,
		dbo.fnReadableSize(om.movie_size) AS movie_size,
		om.movie_duration AS movie_sort_duration,
		om.movie_size AS movie_sort_size,
		om.movie_height AS movie_sort_quality,
		om.movie_file_type
	FROM OldMovies om
	LEFT JOIN Movies m ON om.movie_name = m.movie_name
	WHERE m.movie_id IS NULL