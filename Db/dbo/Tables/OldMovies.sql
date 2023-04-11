CREATE TABLE OldMovies
				 (library_name    VARCHAR(25) NOT NULL,
				  movie_name      NVARCHAR(200) NOT NULL,
				  movie_duration  INT NOT NULL,
				  movie_width     INT NULL,
				  movie_height    INT NULL,
				  movie_size      INT NULL,
				  movie_file_path NVARCHAR(100) NULL,
				  movie_file_type VARCHAR(10) NULL)
GO