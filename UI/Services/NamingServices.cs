using Dapper;
using UI.Interfaces;
using UI.Models;
using System.Data;
using System.Data.SqlClient;

namespace UI.Services
{
    public class NamingServices : INaming
    {
        // Establish Database Connection

        private IDbConnection db;

        public NamingServices(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        // Stored Procedure to Get All Records

        public List<Naming> GetAll()
        {
            return db.Query<Naming>("spGetNaming", commandType: CommandType.StoredProcedure).ToList();
        }
    }
}