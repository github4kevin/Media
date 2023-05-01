using Dapper;
using UI.Interfaces;
using UI.Models;
using System.Data;
using System.Data.SqlClient;

namespace UI.Services
{
    public class EpisodeServices : IEpisodes
    {
        // Establish Database Connection

        private IDbConnection db;

        public EpisodeServices(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        // Stored Procedure to Get All Records

        public List<Episodes> GetAll()
        {
            return db.Query<Episodes>("spGetEpisodes", commandType: CommandType.StoredProcedure).ToList();
        }

        // Stored Procedure for Getting a Single Record

        public Episodes Find(int id)
        {
            return db.Query<Episodes>("spGetEpisodes", new { folder_id = id }, commandType: CommandType.StoredProcedure)
                .SingleOrDefault();
        }
    }
}