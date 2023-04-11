
CREATE TABLE Shows
				 (show_id             INT NOT NULL,
				  show_name           NVARCHAR(255) NOT NULL,
				  show_seasons        INT NULL,
				  show_episodes       INT NULL,
				  show_width          INT NULL,
				  show_height         INT NULL,
				  show_size           INT NULL,
				  show_duration       INT NULL,
				  show_release_date   BIGINT NULL,
				  show_added_date     BIGINT NULL,
				  show_rating         DECIMAL(5, 2) NULL,
				  show_content_rating VARCHAR(25) NULL,
				  show_collection     VARCHAR(50) NULL)
GO

CREATE NONCLUSTERED INDEX IX_Show_Name ON Shows (show_name ASC);