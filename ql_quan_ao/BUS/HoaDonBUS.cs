using ql_quan_ao.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_quan_ao.BUS
{
    public class HoaDonBUS
    {
        private HoaDonDAL dal = new HoaDonDAL();

        public DataTable LayDSHoaDon() => dal.LayDanhSachHoaDon();

        public DataTable LayCTHoaDon(string maHD) => dal.LayChiTietHoaDon(maHD);

        public bool ThanhToan(string maKH, decimal tongTien, DataTable dtChiTiet, out string thongBao)
        {
            if (dtChiTiet.Rows.Count == 0)
            {
                thongBao = "Giỏ hàng đang trống, không thể thanh toán!";
                return false;
            }

            // Tự động sinh mã hóa đơn theo thời gian thực duy nhất (Dạng chuỗi: HD20260523...)
            string maHD = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss");

            if (dal.LuuHoaDon(maHD, maKH, tongTien, dtChiTiet))
            {
                thongBao = "Thanh toán thành công! Mã đơn: " + maHD;
                return true;
            }
            else
            {
                thongBao = "Thanh toán thất bại. Vui lòng kiểm tra lại hệ thống!";
                return false;
            }
        }
    }
}
