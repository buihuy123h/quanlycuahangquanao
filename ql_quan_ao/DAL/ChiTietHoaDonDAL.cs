using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ql_quan_ao.DAL
{
    public class ChiTietHoaDonDAL
    {
        private DatabaseConnect db = new DatabaseConnect();

        public bool ThemChiTietHoaDon(int maHD, string maSP, int soLuong, decimal donGia)
        {
            bool isSuccess = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(db.GetConnectionString()))
                {
                    conn.Open();
                    string strDonGia = donGia.ToString().Replace(",", ".");

                    // MaSP kiểu varchar bắt buộc phải nằm trong nháy đơn
                    string sql = "INSERT INTO ChiTietHoaDon(MaHD, MaSP, SoLuong, DonGia) " +
                                 "VALUES(" + maHD + ", '" + maSP + "', " + soLuong + ", " + strDonGia + ")";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0) isSuccess = true;
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm chi tiết hóa đơn tại ChiTietHoaDonDAL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isSuccess;
        }
    }
}