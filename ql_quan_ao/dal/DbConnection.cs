using System.Data.SqlClient;


namespace DAL
{
    public class DbConnection
    {
        private static string connectionString =
            "Server=.;Database=QuanLyCuaHangQuanAo;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}   