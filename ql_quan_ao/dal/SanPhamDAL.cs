using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DAL
{
    public class SanPhamDAL
    {
        public  DataTable GetAll()
        {
            SqlConnection conn = DbConnection.GetConnection();
            SqlDataAdapter da = new SqlDataAdapter(
                "Select * FROM SanPham WHERE TrangThai = 1", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public bool Insert(string tenSP, int soLuong, decimal giaNhap, decimal giaBan)
        {
            SqlConnection conn = DbConnection.GetConnection();
            string sql = @"INSERT INTO SanPham
                           (TenSP, SoLuong, GiaNhap, GiaBan)
                           Values (@TenSP, @SoLuong, @GiaNhap, @GiaBan)";
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@TenSP", tenSP);
            cmd.Parameters.AddWithValue("@SoLuong", soLuong);
            cmd.Parameters.AddWithValue("@GiaNhap", giaNhap);
            cmd.Parameters.AddWithValue("@GiaBan", giaBan);

            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();

            return result > 0;
        }
    }
}