
/*********
Video View
*********/

CREATE VIEW vwVideos
AS
   SELECT v.video_id, 
          v.video_name, 
          dbo.fnReadableQuality (v.video_height) AS video_quality, 
          dbo.fnReadableSize (v.video_size) AS video_size, 
          dbo.fnReadableDuration (v.video_duration) AS video_duration,

/*******************
Grid Sorting Columns
*******************/

          v.video_size AS video_sort_size, 
          v.video_height AS video_sort_quality,
          v.video_duration AS video_sort_duration
   FROM Videos AS v