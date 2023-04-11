using Dapper;
using UI.Interfaces;
using UI.Models;
using System.Data;
using System.Data.SqlClient;

namespace UI.Services
{
    public class MovieServices : IMovies
    {
        // Establish Database Connection

        private IDbConnection db;

        public MovieServices(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        // Stored Procedure for Get All Records

        public List<Movies> GetAll()
        {
            return db.Query<Movies>("spGetMovies", commandType: CommandType.StoredProcedure).ToList();
        }

        // Stored Procedure for Getting a Single Record

        public Movies Find(int id)
        {
            return db.Query<Movies>("spGetMovies", new { movie_id = id }, commandType: CommandType.StoredProcedure).SingleOrDefault();
        }
    }
}