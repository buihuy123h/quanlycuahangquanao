using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QuanLyCuaHang.DAL // Đảm bảo trùng namespace với ThongKeDAL.cs
{
    public class DataProvider
    {
        // Chuỗi kết nối đến Database của bạn (Hãy thay đổi đoạn này cho khớp với máy bạn)
        private string strConn = @"Data Source=localhost;Initial Catalog=QuanLyCuaHang;Integrated Security=True";

        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { instance = value; }
        }

        private DataProvider() { }

        // Hàm thực thi câu lệnh SQL trả về DataTable (Dùng cho SELECT)
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    // Thêm tham số vào câu lệnh SQL để tránh lỗi bảo mật (SQL Injection)
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
    }
}