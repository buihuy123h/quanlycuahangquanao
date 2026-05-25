using System.Data;
using DAL;

namespace ql_quan_ao.BUS
{
    public class QuanLySanPhamBUS
    {
        private SanPhamDAL spDAL = new SanPhamDAL();

        // ==========================================================
        // PHẦN 1: ĐIỀU HƯỚNG CÁC HÀM CỦA BẠN BẠN
        // ==========================================================
        public DataTable LayDanhSachSanPham()
        {
            return spDAL.GetAll();
        }

        public bool ThemSanPhamVaoKho(string tenSP, int soLuong, decimal giaNhap, decimal giaBan)
        {
            return spDAL.Insert(tenSP, soLuong, giaNhap, giaBan);
        }

        // ==========================================================
        // PHẦN 2: ĐIỀU HƯỚNG CÁC HÀM QUẢN LÝ CỦA BẠN
        // ==========================================================
        public DataTable LayDanhSachTabSanPham()
        {
            return spDAL.GetDanhSach_QLSP();
        }

        public bool ChucNangThemSP(string ma, string ten, string gia)
        {
            return spDAL.Them_QLSP(ma, ten, gia);
        }

        public bool ChucNangSuaSP(string ma, string ten, string gia)
        {
            return spDAL.Sua_QLSP(ma, ten, gia);
        }

        public bool ChucNangXoaSP(string ma)
        {
            return spDAL.Xoa_QLSP(ma);
        }
    }
}