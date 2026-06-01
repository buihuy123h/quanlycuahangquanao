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

        // TRUY VẤN 1: Lấy danh sách hóa đơn mặc định khi mở màn hình Lịch sử
        public DataTable LayDanhSachHoaDon()
        {
            // Viết nối chuỗi nhiều dòng bằng dấu +
            string sql = "SELECT hd.MaHD as 'MaHoaDon', " +
                         "       hd.NgayLap as 'NgayLap', " +
                         "       ISNULL(kh.TenKH, N'Khách vãng lai') as 'TenKhachHang', " +
                         "       hd.TongTien as 'TongTien' " +
                         "FROM HoaDon hd " +
                         "LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH " +
                         "ORDER BY hd.NgayLap DESC";

            return db.ExecuteQuery(sql);
        }

        // TRUY VẤN 2: Lấy chi tiết các món của một hóa đơn (Đã bỏ hoàn toàn SqlParameter)
        public DataTable LayChiTietHoaDon(string maHD)
        {
            // SỬA TẠI ĐÂY: Nối trực tiếp biến maHD vào chuỗi theo đúng yêu cầu
            string sql = "SELECT c.MaSP as 'Mã SP', " +
                         "       ISNULL(s.TenSP, N'Sản phẩm đã ngừng kinh doanh') as 'Tên Sản Phẩm', " +
                         "       c.SoLuong as 'Số Lượng', " +
                         "       c.DonGia as 'Đơn Giá', " +
                         "       c.ThanhTien as 'Thành Tiền' " +
                         "FROM ChiTietHoaDon c " +
                         "LEFT JOIN SanPham s ON c.MaSP = s.MaSP " +
                         "WHERE c.MaHD = '" + maHD + "'";

            return db.ExecuteQuery(sql);
        }

        // TRUY VẤN 3: Lưu hóa đơn mới khi ấn Thanh Toán
        public int ThemHoaDon(int maKH, decimal tongTien)
        {
            int maHDResult = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(db.GetConnectionString()))
                {
                    conn.Open();

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

        // TRUY VẤN 4: Lọc lịch sử theo ngày
        public DataTable LayLichSuBanHangTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            string strTuNgay = tuNgay.ToString("yyyy-MM-dd 00:00:00");
            string strDenNgay = denNgay.ToString("yyyy-MM-dd 23:59:59");

            string query = "SELECT hd.MaHD AS MaHD, " +
                           "       hd.NgayLap AS NgayLap, " +
                           "       ISNULL(kh.TenKH, N'Khách vãng lai') AS TenKH, " +
                           "       hd.TongTien AS TongTien " +
                           "FROM HoaDon hd " +
                           "LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH " +
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
                        throw new Exception("Lỗi truy vấn cơ sở dữ liệu: " + ex.Message);
                    }
                }
            }
        }
    }
}