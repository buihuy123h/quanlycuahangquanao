using System;
using System.Data;
using QuanLyCuaHang.DAL; // Đảm bảo namespace này khớp với file ThongKeDAL.cs

namespace ql_quan_ao.BUS // Sửa lại cho khớp với cấu trúc dự án của bạn
{
    public class ThongKeBUS
    {
        ThongKeDAL dal = new ThongKeDAL();

        public DataTable LayDanhSachHoaDon(DateTime tu, DateTime den)
        {
            if (tu > den) return new DataTable();
            return dal.GetDanhSachHoaDon(tu, den);
        }

        public DataTable LaySoLieuTongQuan(DateTime tu, DateTime den)
        {
            return dal.GetSoLieuTongQuan(tu, den);
        }
    }
}