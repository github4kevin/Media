CREATE TABLE Libraries
				 (library_id       INT NOT NULL,
				  library_name     VARCHAR(25) NOT NULL,
				  show_total       VARCHAR(25) NULL,
				  library_total    INT NULL,
				  library_size     INT NULL,
				  library_duration INT NULL
				CONSTRAINT PK_Libraries PRIMARY KEY CLUSTERED (library_id ASC));
GO

CREATE NONCLUSTERED INDEX IX_Library_Name ON Libraries (library_name ASC);