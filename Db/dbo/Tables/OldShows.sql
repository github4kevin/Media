CREATE TABLE OldShows
				 (library_name     VARCHAR(25) NOT NULL,
				  show_name        NVARCHAR(255) NULL,
				  season_number    INT NULL,
				  episode_name     NVARCHAR(255) NULL,
				  episode_duration INT NULL,
				  episode_width    INT NULL,
				  episode_height   INT NULL,
				  episode_size     INT NULL,
				  file_path        NVARCHAR(255) NULL,
				  file_type        VARCHAR(25))
GO