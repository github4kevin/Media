﻿CREATE TABLE Episodes (show_id               INT NOT NULL, 
                       show_name             NVARCHAR(255) NOT NULL, 
                       season_number         INT NULL, 
                       episode_number        INT NULL, 
                       episode_id            INT NOT NULL, 
                       episode_name          NVARCHAR(255) NULL, 
                       episode_width         INT NULL, 
                       episode_height        INT NULL, 
                       episode_size          INT NULL, 
                       episode_duration      INT NULL, 
                       episode_fps           DECIMAL(5, 2) NULL, 
                       episode_video_codec   NVARCHAR(25) NULL, 
                       episode_audio_codec   NVARCHAR(25) NULL, 
                       episode_release_date  BIGINT NULL, 
                       episode_added_date    BIGINT NULL, 
                       episode_rating        DECIMAL(5, 1) NULL, 
                       show_content_rating   NVARCHAR(25) NULL)
GO