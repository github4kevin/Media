
CREATE TABLE Music (music_id           INT NOT NULL,
						  music_name         NVARCHAR(200) NOT NULL,
						  artist_name        NVARCHAR(200) NULL,
						  album_name         NVARCHAR(200) NULL,
						  music_studio       NVARCHAR(200) NULL,
						  music_size         INT NULL,
						  music_duration     INT NULL,
						  music_added_date   BIGINT NULL,
						  music_release_date BIGINT NULL,
						  file_type          VARCHAR(10),
						  CONSTRAINT PK_Music PRIMARY KEY CLUSTERED(music_id ASC));
GO

CREATE NONCLUSTERED INDEX IX_Music_Name ON Music (music_name ASC);