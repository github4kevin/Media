using Dapper;
using UI.Interfaces;
using UI.Models;
using System.Data;
using System.Data.SqlClient;

namespace UI.Services
{
    public class LibraryServices : ILibraries
    {
        // Establish Database Connection

        private IDbConnection db;

        public LibraryServices(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        // Stored Procedure to Get All Records

        public List<Libraries> GetAll()
        {
            return db.Query<Libraries>("spGetLibraries", commandType: CommandType.StoredProcedure).ToList();
        }

        // Stored Procedure to Get a Single Record

        public Libraries Find(int id)
        {
            return db.Query<Libraries>("spGetLibraries", new { library_id = id }, commandType: CommandType.StoredProcedure).SingleOrDefault();
        }
    }
}