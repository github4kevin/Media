using Dapper;
using UI.Interfaces;
using UI.Models;
using System.Data;
using System.Data.SqlClient;

namespace UI.Services
{
   public class ShowServices : IShows
   {
      // Establish Database Connection

      private IDbConnection db;

      public ShowServices(IConfiguration configuration)
      {
         db = new SqlConnection(configuration.GetConnectionString("Default"));
      }

      // Stored Procedure for Get All Records

      public List<Shows> GetAll()
      {
         return db.Query<Shows>("spGetShows", commandType: CommandType.StoredProcedure).ToList();
      }

      // Stored Procedure for Getting a Single Record

      public Shows Find(int id)
      {
         return db.Query<Shows>("spGetShows", new { show_id = id }, commandType: CommandType.StoredProcedure).SingleOrDefault();
      }
   }
}