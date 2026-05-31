using System.Data;
using DAL;

namespace ql_quan_ao.BUS
{
    public class QuanLyKhachHangBUS
    {
        private KhachHangDAL khDAL = new KhachHangDAL();

        public DataTable LayDanhSachTabKhachHang()
        {
            return khDAL.GetDanhSach_QLKH();
        }
        //public DataTable LayDanhSachKhachHangTheoSDT(string sdt)
        //{
        public string LayTenKhachHang(string sdt)
        {
            return khDAL.GetDanhSachKhachHangTheoSDT(sdt);
        }
        public int ThemKhachHang(string tenKhachHang, string sdtKhachHang)
        {
            return khDAL.ThemKhachHang(tenKhachHang, sdtKhachHang);
        }
    }
}