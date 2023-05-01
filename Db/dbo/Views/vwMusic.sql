
/************
 Music Views 
************/

CREATE VIEW vwMusic
AS
   SELECT m.music_id, 
          m.music_name, 
          m.artist_name, 
          m.album_name, 
          m.music_studio, 
          dbo.fnReadableSize (m.music_size) AS music_size, 
          dbo.fnReadableDuration (m.music_duration) AS music_duration, 
          CAST(DATEADD(s, m.music_added_date, '19700101') AS DATE) AS music_added_date, 
          m.file_type,

/******************
 Grid Sort Columns 
******************/

          m.music_size AS music_sort_size, 
          m.music_duration AS music_sort_duration
   FROM Music AS m