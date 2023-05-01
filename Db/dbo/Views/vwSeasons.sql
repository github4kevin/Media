/***********
Seasons View
***********/

CREATE VIEW vwSeasons
AS
   SELECT season_id, 
          s.show_id, 
          s.show_name,
          season_number, 
          season_episodes, 
          dbo.fnReadableSize (season_size) AS season_size, 
          dbo.fnReadableDuration (season_duration) AS season_duration, 
          dbo.fnReadableQuality (season_height) AS season_quality, 
          CAST(DATEADD(s, s.season_released_date, '19700101') AS DATE) AS season_release_date, 
          YEAR(DATEADD(s, s.season_released_date, '19700101')) AS season_release_year, 
          CAST(DATEADD(s, s.season_added_date, '19700101') AS DATE) AS season_added_date,

/*******************
Grid Sorting Columns
*******************/

          season_size AS season_sort_size, 
          season_duration AS season_sort_duration, 
          season_height AS season_sort_quality
   FROM Seasons AS s
   INNER JOIN Shows AS sho ON s.show_id = sho.show_id