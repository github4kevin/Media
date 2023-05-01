/********************
Distribute Every Table
*********************/

CREATE PROCEDURE spDistributeEverything
AS
   BEGIN
      SET NOCOUNT ON

      -- Generate Table Data --
      EXEC spDistributeShows
      EXEC spDistributeSeasons
      EXEC spDistributeEpisodes
      EXEC spDistributeMovies
      EXEC spDistributeVideo
      EXEC spDistributeMusic
      EXEC spDistributeLibraries
      EXEC spDistributeDuplicates
   END