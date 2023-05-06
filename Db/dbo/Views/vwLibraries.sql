/**************
Libraries Views
**************/

CREATE VIEW vwLibraries
AS
   SELECT l.library_id, 
		  l.library_name,
		  (CAST('20230506' AS DATETIME)) as library_scanned_date,
		  l.show_total,
		  (SELECT COUNT(*)
		   FROM PlexData AS pd
		   WHERE pd.library_name = l.library_name
										  AND (pd.episode_width <= 718
											   OR pd.file_type = '.mp3') ) AS 'sd_total', 
		  (SELECT COUNT(*)
		   FROM PlexData AS pd
		   WHERE pd.library_name = l.library_name
										  AND (pd.episode_width >= 719
											   OR pd.file_type = '.flac') ) AS 'hd_total', 
		  l.library_total, 
		  dbo.fnReadableSize (l.library_size) AS library_size, 
		  dbo.fnReadableDuration (l.library_duration) AS library_duration,

/*******************
Grid Sorting Columns
*******************/

		  l.library_size AS library_sort_size, 
		  l.library_duration AS library_sort_duration,
		l.library_total AS library_sort_total
   FROM Libraries AS l