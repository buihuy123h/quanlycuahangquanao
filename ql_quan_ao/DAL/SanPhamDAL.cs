using System;
using System.Data;
using System.Data.SqlClient;
using ql_quan_ao.DAL; // Gọi đúng namespace chứa DatabaseConnect của dự án bạn

namespace DAL
{
    public class SanPhamDAL
    {
        // Khởi tạo thực thể cấu hình theo đúng thiết kế mới trong DatabaseConnect của bạn
        private DatabaseConnect db = new DatabaseConnect();

        /// <summary>
        /// LẤY DANH SÁCH CHO BẠN BẠN (HÀM CŨ - GIỮ NGUYÊN ĐỂ BÁN HÀNG KHÔNG LỖI)
        /// </summary>
        public DataTable GetAll()
        {
            // Thêm TrangThai, HinhAnh, SoLuongTon để hiển thị mượt mà trên UI bán hàng và kho
            string query = "SELECT MaSP, TenSP, GiaBan, SoLuongTon, AnhSP FROM SanPham";
            return db.ExecuteQuery(query);
        }

        /// <summary>
        /// LẤY DANH SÁCH CHO BẠN (HÀM MỚI - ĐÃ ĐƯỢC THÊM VÀO ĐỂ ĐỦ CỘT ĐẶC TẢ KHO HÀNG)
        /// </summary>
        public DataTable GetDanhSachKhoHang()
        {
            // Câu lệnh SQL nâng cao: Tự đổi tên MaDM -> LoaiSP, tự tính toán TrangThai tự động
            string query = @"SELECT 
                                MaSP, 
                                TenSP, 
                                MaDM AS LoaiSP, 
                                Size, 
                                MauSac, 
                                ISNULL(GiaNhap, 0.00) AS GiaNhap, 
                                GiaBan, 
                                SoLuongTon,
                                CASE 
                                    WHEN SoLuongTon > 0 THEN N'Còn hàng' 
                                    ELSE N'Hết hàng' 
                                END AS TrangThai,
                                AnhSP
                             FROM SanPham";

            // Tận dụng hàm ExecuteQuery có sẵn cực kỳ an toàn của nhóm bạn
            return db.ExecuteQuery(query);
        }

        /// <summary>
        /// Thêm mới sản phẩm vào kho sử dụng chuỗi kết nối Transaction của bạn
        /// </summary>
        public bool Insert(string tenSP, int soLuong, decimal giaNhap, decimal giaBan)
        {
            // Gọi chuỗi kết nối an toàn từ thực thể db
            using (SqlConnection conn = new SqlConnection(db.GetConnectionString()))
            {
                string sql = @"INSERT INTO SanPham (TenSP, SoLuongTon, GiaNhap, GiaBan, TrangThai)
                               VALUES (@TenSP, @SoLuongTon, @GiaNhap, @GiaBan, 1)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TenSP", tenSP);
                    cmd.Parameters.AddWithValue("@SoLuongTon", soLuong);
                    cmd.Parameters.AddWithValue("@GiaNhap", giaNhap);
                    cmd.Parameters.AddWithValue("@GiaBan", giaBan);

                    try
                    {
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        conn.Close();
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Lỗi lưu sản phẩm vào kho: " + ex.Message, "Lỗi SQL", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }
    }
}