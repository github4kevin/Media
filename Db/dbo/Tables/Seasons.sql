CREATE TABLE Seasons (season_id            INT NOT NULL IDENTITY(1, 1),
							 show_id              INT NOT NULL,
							 show_name            NVARCHAR(200) NOT NULL,
							 season_number        INT NULL,
							 season_episodes      INT NULL,
							 season_width         INT NULL,
							 season_height        INT NULL,
							 season_size          INT NULL,
							 season_duration      INT NULL,
							 season_released_date BIGINT NULL,
							 season_added_date    BIGINT NULL,
							 CONSTRAINT PK_Seasons PRIMARY KEY CLUSTERED(season_id ASC));
GO