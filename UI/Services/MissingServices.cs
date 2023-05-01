using Dapper;
using UI.Interfaces;
using UI.Models;
using System.Data;
using System.Data.SqlClient;

namespace UI.Services
{
    public class MissingServices : IMissing
    {
        // Establish Database Connection

        private IDbConnection db;

        public MissingServices(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        // Stored Procedure for Get All Records

        public List<Missing> GetAll()
        {
            return db.Query<Missing>("spGetMissing", commandType: CommandType.StoredProcedure).ToList();
        }
    }
}