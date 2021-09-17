using System.Data.SqlClient;
using System.Data;

namespace Access
{
    public class Sqlconnection
    {
        public static string Cn = Properties.Settings.Default.cn;

        private SqlConnection Connection = new SqlConnection(Cn);

        public SqlConnection GetSqlConnection()
        {
            if (Connection.State == ConnectionState.Open) Connection.Close();
            return Connection;
        }
        public SqlConnection CloseSqlConnection()
        {
            if (Connection.State == ConnectionState.Closed) Connection.Open();
            return Connection;
        }
    }
}
