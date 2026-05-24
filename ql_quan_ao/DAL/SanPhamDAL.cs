using System;
using System.Data;
using System.Data.SqlClient;
using ql_quan_ao.DAL; // Gọi đúng namespace chứa DatabaseConnect của dự án bạn


namespace DAL
{
    public class SanPhamDAL
    {
        private DatabaseConnect db = new DatabaseConnect();

        /// <summary>
        /// LẤY DANH SÁCH CHO BẠN BẠN (HÀM CŨ - GIỮ NGUYÊN ĐỂ BÁN HÀNG KHÔNG LỖI)
        /// </summary>

        // ==========================================================
        // PHẦN 1: CODE CỦA BẠN BẠN (GIỮ NGUYÊN CHO TAB KHO/BÁN HÀNG)
        // ==========================================================


        public DataTable GetAll()
        {
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

        // ==========================================================
        // PHẦN 2: CODE CHỨC NĂNG QUẢN LÝ CỦA BẠN (ĐÃ BỎ LOAI_SP)
        // ==========================================================

        // Lấy danh sách hiển thị lên bảng dgvSanPham (3 cột: Mã, Tên, Giá bán)
        public DataTable GetDanhSach_QLSP()
        {
            using (SqlConnection conn = new SqlConnection(db.GetConnectionString()))
            {
                string query = "SELECT MaSP AS [Mã SP], TenSP AS [Tên SP], GiaBan AS [Giá bán] FROM SanPham";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                try { adapter.Fill(dt); } catch { }
                return dt;
            }
        }

        // Chức năng Thêm sản phẩm (Có tự động chèn MaDM khóa ngoại mặc định)
        public bool Them_QLSP(string ma, string ten, string gia)
        {
            using (SqlConnection conn = new SqlConnection(db.GetConnectionString()))
            {
                string query = "INSERT INTO SanPham (MaSP, TenSP, GiaBan, SoLuongTon, MaDM) VALUES (@MaSP, @TenSP, @GiaBan, 0, @MaDM)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSP", ma.Trim());
                    cmd.Parameters.AddWithValue("@TenSP", ten.Trim());

                    decimal giaBanDecimal = 0;
                    decimal.TryParse(gia.Trim(), out giaBanDecimal);
                    cmd.Parameters.AddWithValue("@GiaBan", giaBanDecimal);
                    cmd.Parameters.AddWithValue("@MaDM", "DM01"); // Đảm bảo không lỗi ràng buộc CSDL

                    try
                    {
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        conn.Close();
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Lỗi SQL khi thêm: " + ex.Message, "Thông báo lỗi");
                        return false;
                    }
                }
            }
        }

        // Chức năng Sửa sản phẩm
        public bool Sua_QLSP(string ma, string ten, string gia)
        {
            using (SqlConnection conn = new SqlConnection(db.GetConnectionString()))
            {
                string query = "UPDATE SanPham SET TenSP = @TenSP, GiaBan = @GiaBan WHERE MaSP = @MaSP";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSP", ma.Trim());
                    cmd.Parameters.AddWithValue("@TenSP", ten.Trim());

                    decimal giaBanDecimal = 0;
                    decimal.TryParse(gia.Trim(), out giaBanDecimal);
                    cmd.Parameters.AddWithValue("@GiaBan", giaBanDecimal);

                    try
                    {
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        conn.Close();
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Lỗi SQL khi sửa: " + ex.Message, "Thông báo lỗi");
                        return false;
                    }
                }
            }
        }

        // Chức năng Xóa sản phẩm
        public bool Xoa_QLSP(string ma)
        {
            using (SqlConnection conn = new SqlConnection(db.GetConnectionString()))
            {
                string query = "DELETE FROM SanPham WHERE MaSP = @MaSP";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSP", ma.Trim());
                    try
                    {
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        conn.Close();
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Lỗi SQL khi xóa: " + ex.Message, "Thông báo lỗi");
                        return false;
                    }
                }
            }
        }
    }
}