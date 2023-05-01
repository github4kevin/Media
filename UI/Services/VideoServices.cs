using Dapper;
using UI.Interfaces;
using UI.Models;
using System.Data;
using System.Data.SqlClient;

namespace UI.Services
{
   public class VideoServices : IVideos
   {
      // Establish Database Connection

      private IDbConnection db;

      public VideoServices(IConfiguration configuration)
      {
         db = new SqlConnection(configuration.GetConnectionString("Default"));
      }

      // Stored Procedure for Get All Records

      public List<Videos> GetAll()
      {
         return db.Query<Videos>("spGetVideos", commandType: CommandType.StoredProcedure).ToList();
      }

   }
}

