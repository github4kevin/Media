/**********
Shows Views
**********/

CREATE VIEW vwShows
AS
   SELECT show_id,
		  show_name = (s.show_name + ' (' + CAST(YEAR(DATEADD(s, show_release_date, '19700101')) AS VARCHAR(5)) + ')'),
		  show_seasons,
		  show_episodes,
		  dbo.fnReadableSize(show_size) AS show_size,
		  dbo.fnReadableDuration(show_duration) AS show_duration,
		  dbo.fnReadableQuality(show_height) AS show_quality,
		  CAST(DATEADD(s, show_release_date, '19700101') AS DATE) AS show_release_date,
		  YEAR(DATEADD(s, show_release_date, '19700101')) AS show_release_year,
		  CAST(DATEADD(s, show_added_date, '19700101') AS DATE) AS show_added_date,
		  show_rating,
		  show_content_rating,
		  show_collection,

		  /*******************
	 		  Grid Sorting Columns
	 		  *******************/

		  show_size AS show_sort_size,
		  show_duration AS show_sort_duration,
		  show_height AS show_sort_quality
   FROM Shows AS s