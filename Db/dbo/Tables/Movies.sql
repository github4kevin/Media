CREATE TABLE Movies
				 (movie_id              INT NOT NULL,
				  movie_name            NVARCHAR(200) NOT NULL,
				  movie_width           INT NULL,
				  movie_height          INT NULL,
				  movie_size            INT NULL,
				  movie_duration        INT NULL,
				  movie_release_date    BIGINT NULL,
				  movie_added_date      BIGINT NULL,
				  movie_critic_rating   DECIMAL(5, 2) NULL,
				  movie_audience_rating DECIMAL(5, 2) NULL,
				  movie_content_rating  VARCHAR(25) NULL,
				  movie_fps             DECIMAL(5, 2) NULL,
				  movie_video_codec     VARCHAR(10) NULL,
				  movie_audio_codec     VARCHAR(10) NULL,
				  movie_collection      VARCHAR(50) NULL,
				  movie_file_path       NVARCHAR(100) NULL,
				  movie_file_type       VARCHAR(10) NULL,
				  CONSTRAINT PK_Movies PRIMARY KEY CLUSTERED(movie_id ASC));
GO

CREATE NONCLUSTERED INDEX IX_Movie_Name ON Movies (movie_name ASC);