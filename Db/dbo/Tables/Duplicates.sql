CREATE TABLE Duplicates (media_id       INT NOT NULL IDENTITY(1, 1), 
                         media_type     VARCHAR(25) NOT NULL, 
                         media_name     NVARCHAR(255) NOT NULL, 
                         media_size     INT NOT NULL, 
                         media_duration INT NOT NULL, 
                         media_quality  INT NOT NULL, 
                         media_released DATE NOT NULL, 
                         total_backups  INT NOT NULL, 
                         CONSTRAINT PK_Duplicates PRIMARY KEY CLUSTERED(media_id ASC));
GO

CREATE NONCLUSTERED INDEX IX_Media_Name ON Duplicates (media_name ASC);