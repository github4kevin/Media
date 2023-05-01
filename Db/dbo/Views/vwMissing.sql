/**************
Missing Movies
***************/
CREATE VIEW vwMissing
AS
	SELECT
		mis.movie_name,
		dbo.fnReadableQuality(mis.movie_height) AS movie_quality,
		dbo.fnReadableDuration(mis.movie_duration) AS movie_duration,
		dbo.fnReadableSize(mis.movie_size) AS movie_size,
		mis.movie_duration AS movie_sort_duration,
		mis.movie_size AS movie_sort_size,
		mis.movie_height AS movie_sort_quality,
		mis.movie_file_type
	FROM Missing AS mis
	LEFT JOIN Movies m ON mis.movie_name = m.movie_name
	WHERE m.movie_id IS NULL