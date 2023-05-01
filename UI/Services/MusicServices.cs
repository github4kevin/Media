using Dapper;
using UI.Interfaces;
using UI.Models;
using System.Data;
using System.Data.SqlClient;

namespace UI.Services
{
   public class MusicServices : IMusic
   {
      // Establish Database Connection

      private IDbConnection db;

      public MusicServices(IConfiguration configuration)
      {
         db = new SqlConnection(configuration.GetConnectionString("Default"));
      }

      // Stored Procedure for Get All Records

      public List<Music> GetAll()
      {
         return db.Query<Music>("spGetMusic", commandType: CommandType.StoredProcedure).ToList();
      }

      // Stored Procedure for Getting a Single Record

      public Music Find(int id)
      {
         return db.Query<Music>("spGetMusic", new { movie_id = id }, commandType: CommandType.StoredProcedure).SingleOrDefault();
      }
   }
}