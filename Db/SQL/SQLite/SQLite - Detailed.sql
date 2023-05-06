/**********************
Run This in SQLite Only
**********************/

SELECT
     (SELECT a.name FROM accounts AS a
     INNER JOIN metadata_item_settings AS mis ON mis.account_id = a.id
     WHERE mis.id = metadata_media.id)                  AS plex_user,
     printf('%02d', library_sections.id)                AS library_id,
	   library_sections.name                              AS library_name,
     NULL                                               AS folder_id,
		 NULL                                               AS folder_name,
	   printf('%05d', metadata_series.id)                 AS show_id,
	   metadata_series.title                              AS show_name,
	   printf('%02d', metadata_season.'index')            AS season_number,
     metadata_season.title                              AS music_album,
     metadata_season.studio                             AS season_studio,
	   printf('%03d', metadata_media.'index')             AS episode_number,
	   printf('%.2f', metadata_series.rating)             AS show_rating,
	   UPPER(metadata_series.content_rating)              AS show_content_rating,
	   metadata_series.tags_genre                         AS show_genre,
	   metadata_series.studio                             AS show_studio,
	   metadata_series.tags_country                       AS show_country,
	   metadata_series.tags_star                          AS show_stars,
	   metadata_series.tags_collection                    AS show_collection,
	   metadata_series.summary                            AS show_summary,
	   printf('%05d', metadata_media.id)                  AS episode_id,
	   metadata_media.title                               AS episode_name,
	   metadata_media.summary                             AS episode_summary,
	   (media_items.duration / 1000)                      AS episode_duration,
	   media_items.Width                                  AS episode_width,
	   media_items.Height                                 AS episode_height,
	   media_items.size / (1024 * 1024)                   AS episode_size,
	   printf('%.2f', media_items.frames_per_second)      AS episode_fps,
	   UPPER(media_items.video_codec)                     AS episode_video_codec,
	   UPPER(media_items.audio_codec)                     AS episode_audio_codec,
	   metadata_media.originally_available_at             AS episode_release_date,
	   metadata_media.added_at                            AS episode_added_date,

  CASE
	   WHEN
	   (SELECT 1
	   FROM metadata_item_views miv
	   WHERE miv.grandparent_title = metadata_series.title
	   AND miv.library_section_id = library_sections.id
	   AND miv.parent_index = metadata_season.'index'
	   AND miv.'index' = metadata_media.'index')
	   THEN 1
  ELSE 0 END                                            AS episode_viewed,

  (SELECT COUNT(*)
	   FROM metadata_item_views miv
	   WHERE miv.grandparent_title = metadata_series.title
	   AND miv.library_section_id = library_sections.id
	   AND miv.parent_index = metadata_season.'index'
	   AND miv.'index' = metadata_media.'index'
	   GROUP BY miv.grandparent_title,
				miv.parent_index,
				miv.'index')                                    AS episode_view_count,


	 (SELECT COALESCE(d.name, '')
	 FROM metadata_item_views miv
	 INNER JOIN devices d ON miv.device_id = d.id
	 WHERE miv.grandparent_title = metadata_series.title
	 AND miv.library_section_id = library_sections.id
	 AND miv.parent_index = metadata_season.'index'
	 AND miv.'index' = metadata_media.'index')            AS episode_view_device,

	   printf('%.2f', metadata_media.rating)              AS movie_critic_rating,
	   printf('%.2f', metadata_media.audience_rating)     AS movie_audience_rating,
	   UPPER(metadata_media.content_rating)               AS movie_content_rating,
	   metadata_media.tags_genre                          AS movie_genre,
	   metadata_media.studio                              AS movie_studio,
	   metadata_media.tags_country                        AS movie_country,
	   metadata_media.tags_star                           AS movie_stars,
	   metadata_media.tags_director                       AS movie_directors,
	   metadata_media.tags_writer                         AS movie_writers,
	   metadata_media.tags_collection                     AS movie_collection,
	   metadata_media.tagline                             AS movie_tagline,

  CASE
	   WHEN
	   (SELECT 1
	   FROM metadata_item_views miv
	   WHERE miv.title = metadata_media.title
	   and miv.library_section_id = library_sections.id
	   AND miv.parent_index = -1)
	   THEN 1
  ELSE 0 END AS movie_viewed,

  (SELECT COUNT(*)
  FROM metadata_item_views miv
  WHERE miv.title = metadata_media.title
  AND miv.library_section_id = library_sections.id
  AND miv.parent_index = -1
  GROUP BY miv.title,
		   miv.parent_index) AS movie_view_count,

	 (SELECT COALESCE(d.name, '')
	 FROM metadata_item_views miv
	 INNER JOIN devices d on miv.device_id = d.id
	 WHERE miv.title = metadata_media.title
	 and miv.library_section_id = library_sections.id
	 AND miv.parent_index = -1) AS movie_view_device,

	   (SELECT media_parts.file
		FROM media_parts
		WHERE media_parts.media_item_id = media_items.id) AS file_path,
	   '.' || UPPER(media_items.container)                AS file_type

--   metadata_media.*
FROM media_items
		 INNER JOIN metadata_items AS metadata_media ON media_items.metadata_item_id = metadata_media.id
		 LEFT JOIN metadata_items AS metadata_season ON metadata_media.parent_id = metadata_season.id
		 LEFT JOIN metadata_items AS metadata_series ON metadata_season.parent_id = metadata_series.id
		 INNER JOIN section_locations ON media_items.section_location_id = section_locations.id
		 INNER JOIN library_sections ON library_sections.id = section_locations.library_section_id
--WHERE metadata_media.title like '%2 Fast%'
--and metadata_media.id = 00303
--metadata_series.title LIKE '%Clover%' -- Old Black Clover with Incorrect Media
--library_sections.id IN (5) -- New TV Shows & New Movies
--ORDER BY metadata_series.id