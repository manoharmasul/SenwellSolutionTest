using System.Data;
using System.Data.SqlClient;

namespace SenwellSolutionTest.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionstring;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("SqlServer");
        }
        public IDbConnection CreateConnection() =>
                 new SqlConnection(_connectionstring);
    }
}
