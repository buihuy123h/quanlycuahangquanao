using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ql_quan_ao.DAL
{
    public class HoaDonDAL
    {
        private DatabaseConnect db = new DatabaseConnect();

        // TRUY VẤN 1: Lấy danh sách hóa đơn cho màn hình lịch sử
        public DataTable LayDanhSachHoaDon()
        {
            string sql = @"
        SELECT 
            hd.MaHD as 'MaHoaDon',
            hd.NgayLap as 'NgayLap',
            kh.TenKH as 'TenKhachHang',
            hd.TongTien as 'TongTien'
        FROM HoaDon hd
        JOIN KhachHang kh
            ON hd.MaKH = kh.MaKH
        ORDER BY hd.NgayLap DESC";

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
        
        public int ThemHoaDon(int maKH, decimal tongTien)
        {
            int maHDResult = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(db.GetConnectionString()))
                {
                    conn.Open();

                    // LƯU Ý: Bỏ hẳn cột NgayLap ra khỏi câu lệnh dưới đây. 
                    // SQL sẽ tự động điền ngày giờ hiện tại vào hệ thống cho bạn.
                    string sql = "INSERT INTO HoaDon(MaKH, TongTien) " +
                                 "OUTPUT INSERTED.MaHD " +
                                 "VALUES(" + (maKH > 0 ? maKH.ToString() : "NULL") + ", " + tongTien + ")";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    maHDResult = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm hóa đơn tại HoaDonDAL: " + ex.Message);
            }
            return maHDResult;
        }
        public DataTable LayLichSuBanHangTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            // Định dạng ngày chuẩn SQL Server
            string strTuNgay = tuNgay.ToString("yyyy-MM-dd HH:mm:ss");
            string strDenNgay = denNgay.ToString("yyyy-MM-dd HH:mm:ss");

            string query = "SELECT hd.MaHD AS MaHD, " +
                           "       hd.NgayLap AS NgayLap, " +
                           "       kh.TenKH AS TenKH, " +
                           "       hd.TongTien AS TongTien " +
                           "FROM HoaDon hd " +
                           "INNER JOIN KhachHang kh ON hd.MaKH = kh.MaKH " +
                           "WHERE hd.NgayLap BETWEEN '" + strTuNgay + "' AND '" + strDenNgay + "' " +
                           "ORDER BY hd.NgayLap DESC";

            using (SqlConnection conn = new SqlConnection(db.GetConnectionString()))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        conn.Open();
                        adapter.Fill(dt);
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        // Thảy lỗi ngược lên để tầng trên bắt và hiển thị MessageBox
                        throw new Exception("Lỗi truy vấn cơ sở dữ liệu: " + ex.Message);
                    }
                }
            }
        }

    }
}