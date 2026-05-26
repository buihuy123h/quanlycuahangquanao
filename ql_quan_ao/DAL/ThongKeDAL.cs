using System;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCuaHang.DAL // Hãy đổi namespace theo dự án của bạn
{
    public class ThongKeDAL
    {
        public DataTable GetDanhSachHoaDon(DateTime tu, DateTime den)
        {
            // Chỉ chọn đúng các cột hiện có trong bảng HoaDon
            string sql = "SELECT MaHD, NgayLap, MaKH, TongTien FROM HoaDon WHERE NgayLap BETWEEN @Tu AND @Den";
            return DataProvider.Instance.ExecuteQuery(sql, new object[] { tu, den });
        }

        public DataTable GetSoLieuTongQuan(DateTime tu, DateTime den)
        {
            // Bảng không có cột SoLuongSP, nên chúng ta chỉ tính TongTien và Count
            string sql = @"SELECT 
                        ISNULL(SUM(TongTien), 0) AS TongDoanhThu, 
                        COUNT(MaHD) AS TongSoHoaDon
                      FROM HoaDon 
                      WHERE NgayLap BETWEEN @Tu AND @Den";
            return DataProvider.Instance.ExecuteQuery(sql, new object[] { tu, den });
        }
    }
}