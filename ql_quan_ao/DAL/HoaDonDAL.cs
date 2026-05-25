using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_quan_ao.DAL
{
     public class HoaDonDAL
    {
        private DatabaseConnect db = new DatabaseConnect();

        // TRUY VẤN 1: Lấy danh sách hóa đơn cho màn hình lịch sử
        public DataTable LayDanhSachHoaDon()
        {
            string sql = @"SELECT MaHD as 'Mã Hóa Đơn', 
                                  NgayLap as 'Ngày Lập', 
                                  MaKH as 'Mã KH', 
                                  TongTien as 'Tổng Tiền' 
                           FROM HoaDon 
                           ORDER BY NgayLap DESC";
            return db.ExecuteQuery(sql);
        }

        // TRUY VẤN 2: Lấy chi tiết các món của một hóa đơn khi người dùng click chọn
        public DataTable LayChiTietHoaDon(string maHD)
        {
            string sql = @"SELECT c.MaSP as 'Mã SP', 
                                  s.TenSP as 'Tên Sản Phẩm', 
                                  c.SoLuong as 'Số Lượng', 
                                  c.DonGia as 'Đơn Giá', 
                                  c.ThanhTien as 'Thành Tiền' 
                           FROM ChiTietHoaDon c 
                           JOIN SanPham s ON c.MaSP = s.MaSP 
                           WHERE c.MaHD = @MaHD";

            SqlParameter[] p = { new SqlParameter("@MaHD", maHD) };
            return db.ExecuteQuery(sql, p);
        }

        // TRUY VẤN 3 (Nâng cao): Lưu hóa đơn mới khi ấn Thanh Toán + Tự động trừ kho
        public bool LuuHoaDon(string maHD, string maKH, decimal tongTien, DataTable dtChiTiet)
        {
            using (SqlConnection conn = new SqlConnection(db.GetConnectionString()))
            {
                conn.Open();
                // Dùng SqlTransaction để đảm bảo chèn lỗi ở bất kỳ dòng nào sẽ hoàn tác ngay lập tức, không lo lệch kho
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // Lệnh 1: Chèn thông tin chung vào bảng HoaDon
                    string sqlHD = "INSERT INTO HoaDon (MaHD, NgayLap, MaKH, TongTien) VALUES (@MaHD, GETDATE(), @MaKH, @TongTien)";
                    SqlCommand cmdHD = new SqlCommand(sqlHD, conn, trans);
                    cmdHD.Parameters.AddWithValue("@MaHD", maHD);
                    cmdHD.Parameters.AddWithValue("@MaKH", string.IsNullOrEmpty(maKH) ? (object)DBNull.Value : maKH);
                    cmdHD.Parameters.AddWithValue("@TongTien", tongTien);
                    cmdHD.ExecuteNonQuery();

                    // Lệnh 2 & 3: Duyệt qua giỏ hàng để chèn chi tiết và tự động TRỪ KHO của sản phẩm đó
                    foreach (DataRow row in dtChiTiet.Rows)
                    {
                        string sqlCT = "INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia) VALUES (@MaHD, @MaSP, @SoLuong, @DonGia)";
                        SqlCommand cmdCT = new SqlCommand(sqlCT, conn, trans);
                        cmdCT.Parameters.AddWithValue("@MaHD", maHD);
                        cmdCT.Parameters.AddWithValue("@MaSP", row["MaSP"]);
                        cmdCT.Parameters.AddWithValue("@SoLuong", row["SoLuong"]);
                        cmdCT.Parameters.AddWithValue("@DonGia", row["DonGia"]);
                        cmdCT.ExecuteNonQuery();

                        // Lệnh UPDATE trừ số lượng tồn kho tự động
                        string sqlTruKho = "UPDATE SanPham SET SoLuongTon = SoLuongTon - @SoLuong WHERE MaSP = @MaSP";
                        SqlCommand cmdKho = new SqlCommand(sqlTruKho, conn, trans);
                        cmdKho.Parameters.AddWithValue("@SoLuong", row["SoLuong"]);
                        cmdKho.Parameters.AddWithValue("@MaSP", row["MaSP"]);
                        cmdKho.ExecuteNonQuery();
                    }

                    trans.Commit(); // Đồng ý lưu nếu chạy mượt mà không lỗi
                    return true;
                }
                catch (Exception)
                {
                    trans.Rollback(); // Hủy toàn bộ tiến trình nếu gặp bất kỳ lỗi nào giữa chừng
                    return false;
                }
            }
        }
    }
}
