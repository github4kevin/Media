using Dapper;
using UI.Interfaces;
using UI.Models;
using System.Data;
using System.Data.SqlClient;

namespace UI.Services
{
    public class SeasonServices : ISeasons
    {
        // Establish Database Connection

        private IDbConnection db;

        public SeasonServices(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        // Stored Procedure for Get All Records

        public List<Seasons> GetAll()
        {
            return db.Query<Seasons>("spGetSeasons", commandType: CommandType.StoredProcedure).ToList();
        }

        // Stored Procedure for Getting a Single Record

        public Seasons Find(int id)
        {
            return db.Query<Seasons>("spGetSeasons", new { season_id = id }, commandType: CommandType.StoredProcedure).SingleOrDefault();
        }
    }
}