using Dapper;
using UI.Interfaces;
using UI.Models;
using System.Data;
using System.Data.SqlClient;

namespace UI.Services
{
    public class MissingMovieServices : IMissingMovies
    {
        // Establish Database Connection

        private IDbConnection db;

        public MissingMovieServices(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        // Stored Procedure for Get All Records

        public List<MissingMovies> GetAll()
        {
            return db.Query<MissingMovies>("spGetMissingMovies", commandType: CommandType.StoredProcedure).ToList();
        }
    }
}