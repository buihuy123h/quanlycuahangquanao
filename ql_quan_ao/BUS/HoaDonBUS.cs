using ql_quan_ao.DAL;
using ql_quan_ao.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ql_quan_ao.BUS
{
    public class HoaDonBUS
    {
        private HoaDonDAL dal = new HoaDonDAL();

        public DataTable LayDSHoaDon() => dal.LayDanhSachHoaDon();

        public DataTable LayCTHoaDon(string maHD) => dal.LayChiTietHoaDon(maHD);

        //public bool ThanhToan(int maKH, decimal tongTien, DataTable dtChiTiet, out string thongBao)
        //{
        //    if (dtChiTiet.Rows.Count == 0)
        //    {
        //        thongBao = "Giỏ hàng đang trống, không thể thanh toán!";
        //        return false;
        //    }

        //    int maHDVuaSinh = dal.ThemHoaDon(maKH, tongTien);

        //    if (maHDVuaSinh > 0)
        //    {
        //        // 3. Khi đã có mã MaHD dạng số nguyên hợp lệ, tiến hành lưu các dòng trong giỏ hàng vào bảng ChiTietHoaDon
        //        bool checkChiTiet = dal.LuuDanhSachChiTiet(maHDVuaSinh, dtChiTiet);

        //        if (checkChiTiet)
        //        {
        //            thongBao = $"Thanh toán thành công! Mã hóa đơn của bạn là: {maHDVuaSinh}";
        //            return true;
        //        }
        //        else
        //        {
        //            thongBao = "Hóa đơn đã tạo nhưng xảy ra lỗi khi lưu chi tiết các mặt hàng!";
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        thongBao = "Thanh toán thất bại. Không thể tạo hóa đơn mới trên hệ thống!";
        //        return false;
        //    }
        //}
        public bool ThanhToanThuNghiem(int maKH, decimal tongTien, out string thongBao)
        {
            // Gọi DAL để chèn vào bảng HoaDon
            int maHD = dal.ThemHoaDon(maKH, tongTien);

            if (maHD > 0)
            {
                thongBao = $"Thành công! Đã lưu vào bảng HoaDon. Mã HD tự tăng vừa sinh là: {maHD}";
                return true;
            }
            else
            {
                thongBao = "Thất bại! SQL Server không thể tạo dòng mới trong bảng HoaDon.";
                return false;
            }
        }
        public int LuuHoaDonBUS(int maKH, decimal tongTien)
        {
            return dal.ThemHoaDon(maKH, tongTien);
        }
        public DataTable LayDanhSachHoaDonTheoThoiGian(DateTime tuNgay, DateTime denNgay)
        {
            // 1. Ép thời gian về đầu ngày và cuối ngày giống hệt logic cũ của bạn
            DateTime tuNgayChuan = tuNgay.Date;
            DateTime denNgayChuan = denNgay.Date.AddDays(1).AddTicks(-1);

            // 2. Kiểm tra logic nghiệp vụ (Business Rule)
            if (tuNgayChuan > denNgayChuan)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!");
            }

            // 3. Nếu mọi thứ hợp lệ, gọi tầng DAL mang dữ liệu về
            return dal.LayLichSuBanHangTheoNgay(tuNgayChuan, denNgayChuan);
        }
    }
}
