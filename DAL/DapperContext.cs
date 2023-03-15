using Microsoft.Data.SqlClient;
using System.Data;

namespace MovieApp.DAL
{
    public class DapperContext
    {
        private IConfiguration configuration;

        public DapperContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IDbConnection GetConnection => new SqlConnection(this.configuration.GetConnectionString("dapper"));



    }
}
