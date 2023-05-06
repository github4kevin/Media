/**********************
Run This in SQLite Only
**********************/

SELECT
      printf('%02d', library_sections.id)                AS library_id,
	   library_sections.name                              AS library_name,
	   printf('%05d', metadata_series.id)                 AS show_id,
	   metadata_series.title                              AS show_name,
	   printf('%02d', metadata_season.'index')            AS season_number,
      metadata_season.title                              AS music_album,
      metadata_season.studio                             AS season_studio,
	   printf('%03d', metadata_media.'index')             AS episode_number,
	   printf('%.2f', metadata_series.rating)             AS show_rating,
	   UPPER(metadata_series.content_rating)              AS show_content_rating,
	   metadata_series.tags_collection                    AS show_collection,
	   printf('%05d', metadata_media.id)                  AS episode_id,
	   metadata_media.title                               AS episode_name,
	   (media_items.duration / 1000)                      AS episode_duration,
	   media_items.Width                                  AS episode_width,
	   media_items.Height                                 AS episode_height,
	   media_items.size / (1024 * 1024)                   AS episode_size,
	   printf('%.2f', media_items.frames_per_second)      AS episode_fps,
	   UPPER(media_items.video_codec)                     AS episode_video_codec,
	   UPPER(media_items.audio_codec)                     AS episode_audio_codec,
	   metadata_media.originally_available_at             AS episode_release_date,
	   metadata_media.added_at                            AS episode_added_date,
	   printf('%.2f', metadata_media.rating)              AS movie_critic_rating,
	   printf('%.2f', metadata_media.audience_rating)     AS movie_audience_rating,
	   UPPER(metadata_media.content_rating)               AS movie_content_rating,
	   metadata_media.tags_collection                     AS movie_collection,
	   (SELECT media_parts.file
		FROM media_parts
		WHERE media_parts.media_item_id = media_items.id)  AS file_path,
	   '.' || UPPER(media_items.container)                AS file_type
FROM media_items
		 INNER JOIN metadata_items AS metadata_media ON media_items.metadata_item_id = metadata_media.id
		 LEFT JOIN metadata_items AS metadata_season ON metadata_media.parent_id = metadata_season.id
		 LEFT JOIN metadata_items AS metadata_series ON metadata_season.parent_id = metadata_series.id
		 INNER JOIN section_locations ON media_items.section_location_id = section_locations.id
		 INNER JOIN library_sections ON library_sections.id = section_locations.library_section_id