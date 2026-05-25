using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms; // Thêm thư viện này để hiển thị hộp thoại báo lỗi MessageBox

namespace ql_quan_ao.DAL
{
    public class DatabaseConnect
    {
        // Chuỗi kết nối bốc từ SQL Server Object Explorer của máy bạn

        private string chuoiKetNoi = @"Data Source=localhost;Initial Catalog=QuanlyCuaHang;Integrated Security=True;Encrypt=False;";
        private string chuoiKetNoi = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyCuaHang;Integrated Security=True;TrustServerCertificate=True;";
        private string chuoiKetNoi = @"Data Source=localhost;Initial Catalog=QuanLyCuaHang;Integrated Security=True;TrustServerCertificate=True;";


        /// <summary>
        /// Hàm thực thi câu lệnh lấy dữ liệu (SELECT) an toàn với try...catch
        /// </summary>
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Bắt riêng lỗi của SQL Server (Sai tên bảng, mất kết nối, sai chính tả câu lệnh...)
                MessageBox.Show("Lỗi truy vấn Cơ sở dữ liệu: " + ex.Message, "Lỗi SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Bắt các lỗi hệ thống khác
                MessageBox.Show("Hệ thống gặp sự cố bất ngờ: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        /// <summary>
        /// Hàm trả về chuỗi kết nối gốc
        /// Lưu ý: Hàm này dùng cho Transaction (Thanh toán giỏ hàng) nên bản thân nó không cần try...catch, 
        /// vì việc try...catch và Rollback/Commit đã được xử lý triệt để ở file HoaDonDAL.cs rồi!
        /// </summary>
        public string GetConnectionString()
        {
            return chuoiKetNoi;
        }
    }
}