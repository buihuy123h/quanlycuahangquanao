using DAL;
using System.Data;
using System.Runtime.Remoting.Messaging;


namespace BUS
{
    public class SanPhamBUS
    {
        SanPhamDAL dal = new SanPhamDAL();

        public DataTable LayDanhSachSanPham()
        {
            return dal.GetAll();
        }

        public bool ThemSanPham(string tenSP, int soLuong, decimal giaNhap, decimal giaBan)
        {
            if (soLuong < 0 || giaNhap < 0 || giaBan < 0)
                return false;

            return dal.Insert(tenSP, soLuong, giaNhap, giaBan);
        }
    }
}