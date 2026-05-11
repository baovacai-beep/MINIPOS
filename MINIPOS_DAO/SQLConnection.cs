using System.Configuration;
using System.Data.SqlClient;

namespace MINIPOS_DAO
{
    public static class SQLConnection
    {
        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["MiniPOS"].ConnectionString;
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
