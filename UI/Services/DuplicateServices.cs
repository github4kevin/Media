using Dapper;
using UI.Interfaces;
using UI.Models;
using System.Data;
using System.Data.SqlClient;

namespace UI.Services
{
    public class DuplicateServices : IDuplicates
    {
        // Establish Database Connection

        private IDbConnection db;

        public DuplicateServices(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        // Stored Procedure to Get All Records

        public List<Duplicates> GetAll()
        {
            return db.Query<Duplicates>("spGetDuplicates", commandType: CommandType.StoredProcedure).ToList();
        }
    }
}