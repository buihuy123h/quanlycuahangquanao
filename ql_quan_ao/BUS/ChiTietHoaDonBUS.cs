using ql_quan_ao.DAL;

namespace ql_quan_ao.BUS
{
    public class ChiTietHoaDonBUS
    {
        private ChiTietHoaDonDAL chiTietDAL = new ChiTietHoaDonDAL();

        public bool ThemChiTietHoaDon(int maHD, string maSP, int soLuong, decimal donGia)
        {
            return chiTietDAL.ThemChiTietHoaDon(maHD, maSP, soLuong, donGia);
        }
    }
}