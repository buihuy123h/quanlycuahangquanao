using System.Data;
using DAL;

// Ép về đúng cụm từ 'namespace BUS' để ăn khớp với lệnh gọi 'using BUS;' trên FormMain và ucQuanLyKho
namespace BUS
{
    public class SanPhamBUS
    {
        private SanPhamDAL dal = new SanPhamDAL();

            public DataTable LayDanhSachSanPham()
            {
                return dal.GetAll();
            }

        public DataTable LayDanhSachKhoHang()
        {
            return dal.GetDanhSachKhoHang();
        }

        public bool ThemSanPham(string tenSP, int soLuong, decimal giaNhap, decimal giaBan)
        {
            if (string.IsNullOrEmpty(tenSP) || soLuong < 0 || giaNhap < 0 || giaBan < 0)
            {
                return false;
            }
            return dal.Insert(tenSP, soLuong, giaNhap, giaBan);
        }
    }
}