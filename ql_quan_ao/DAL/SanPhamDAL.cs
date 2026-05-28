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

        // 1. Hàm gốc 7 tham số (Dùng để chạy SQL)
        public bool Insert(string maSP, string tenSP, string maDM, string size, string mauSac, decimal giaBan, int soLuong)
        {
            string query = string.Format(
                "INSERT INTO SanPham (MaSP, TenSP, MaDM, Size, MauSac, GiaBan, SoLuongTon) VALUES ('{0}', N'{1}', '{2}', '{3}', N'{4}', {5}, {6})",
                maSP, tenSP, maDM, size, mauSac, giaBan, soLuong
            );
            return ExecuteNonQuery(query);
        }

        // 2. Hàm nạp chồng 4 tham số (Dùng để phục vụ code cũ của bạn bạn)
        public bool Insert(string tenSP, int soLuong, decimal giaNhap, decimal giaBan)
        {
            // Gọi đến hàm 7 tham số ở trên
            return this.Insert("SP_" + tenSP, tenSP, "DM03", "Free", "Trắng", giaBan, soLuong);
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
        // --- Chèn hàm CapNhat này vào SanPhamDAL.cs ---
        public bool CapNhat(string maSP, string tenSP, string maDM, string size, string mauSac, decimal giaBan)
        {
            using (SqlConnection conn = new SqlConnection(db.GetConnectionString()))
            {
                // Câu lệnh SQL Update đầy đủ cho các trường bạn cần
                string query = "UPDATE SanPham SET TenSP = @TenSP, MaDM = @MaDM, Size = @Size, MauSac = @MauSac, GiaBan = @GiaBan WHERE MaSP = @MaSP";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Gán giá trị cho các tham số
                    cmd.Parameters.AddWithValue("@MaSP", maSP.Trim());
                    cmd.Parameters.AddWithValue("@TenSP", tenSP.Trim());
                    cmd.Parameters.AddWithValue("@MaDM", maDM.Trim());
                    cmd.Parameters.AddWithValue("@Size", size.Trim());
                    cmd.Parameters.AddWithValue("@MauSac", mauSac.Trim());
                    cmd.Parameters.AddWithValue("@GiaBan", giaBan);

                    try
                    {
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Lỗi SQL khi cập nhật: " + ex.Message, "Thông báo lỗi");
                        return false;
                    }
                }
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
        // ... (các hàm có sẵn của bạn như Xoa_QLSP ở phía trên)

        // CHÈN HÀM NÀY VÀO TRƯỚC DẤU ĐÓNG NGOẶC NHỌN CUỐI CÙNG CỦA CLASS
        public bool ExecuteNonQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(db.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Lỗi SQL: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    } // Đây là dấu đóng ngoặc cuối cùng của class SanPhamDAL
}
