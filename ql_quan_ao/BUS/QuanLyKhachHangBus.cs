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
    }
}