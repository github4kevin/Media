CREATE TABLE Videos (video_id INT NOT NULL IDENTITY (1, 1),
							video_name NVARCHAR(255) NOT NULL,
							video_width INT NOT NULL,
							video_height INT NOT NULL,
							video_size INT NULL,
							video_duration INT NULL,
							CONSTRAINT PK_Video PRIMARY KEY CLUSTERED (video_id ASC));

GO