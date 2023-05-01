/********************************
Delete Everything Except PlexData
********************************/

CREATE PROCEDURE spDeleteEverything
AS
	BEGIN
		SET NOCOUNT ON

		-- Delete Table Data --
		DELETE FROM Episodes
		DELETE FROM Seasons
		DELETE FROM Shows
		DELETE FROM Movies
		DELETE FROM Videos
		DELETE FROM Music
		DELETE FROM Duplicates
		DELETE FROM Libraries

		-- RESEED Identity to 0 --
		DBCC CHECKIDENT (Episodes, RESEED, 0)
		DBCC CHECKIDENT (Seasons, RESEED, 0)
		DBCC CHECKIDENT (Shows, RESEED, 0)
		DBCC CHECKIDENT (Movies, RESEED, 0)
		DBCC CHECKIDENT (Videos, RESEED, 0)
		DBCC CHECKIDENT (Music, RESEED, 0)
		DBCC CHECKIDENT (Libraries, RESEED, 0)
		DBCC CHECKIDENT (Duplicates, RESEED, 0)
	END