
/**************
Duplicates View
**************/

CREATE VIEW vwDuplicates
AS
   SELECT d.media_type,
          d.media_name, 
		  dbo.fnReadableQuality(d.media_quality) AS media_quality,
          dbo.fnReadableSize (d.media_size) AS media_size, 
          dbo.fnReadableDuration (d.media_duration) AS media_duration, 
          d.media_released, 
          d.total_backups,

/*****************
 Grid Sort Columns
*****************/

          d.media_size AS media_sort_size, 
          d.media_duration AS media_sort_duration,
		  d.media_quality as media_sort_quality
   FROM Duplicates AS d
