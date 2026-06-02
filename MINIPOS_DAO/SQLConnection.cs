using System.Configuration;
using System.Data;
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

        public static DataTable ExecuteQuery(string query)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                SqlDataAdapter da =
                    new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }
    }
}