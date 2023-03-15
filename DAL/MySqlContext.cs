using Microsoft.Data.SqlClient;
using MySqlConnector;
using System.Data;

namespace MovieApp.DAL
{
    public class MySqlContext
    {
        private IConfiguration configuration;

        public MySqlContext(IConfiguration configuration) 
        {
            this.configuration = configuration;
        } 
        public MySqlConnection Connection => new MySqlConnection(configuration.GetConnectionString("MySqlDapper"));
    }
}
