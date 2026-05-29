using DAL;
using System.Data;
using System.Threading.Tasks;
using System.Threading.Tasks;

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

        // Đảm bảo file SanPhamBUS.cs có hàm này:
        // Đảm bảo dòng 22 có đủ 7 tham số:
        public bool ThemSanPham(string maSP, string tenSP, string maDM, string size, string mauSac, decimal giaBan, int soLuong)
        {
            // Phải truyền đủ 7 tham số xuống DAL để khớp với hàm 7 tham số mà bạn đã định nghĩa
            return dal.Insert(maSP, tenSP, maDM, size, mauSac, giaBan, soLuong);
        }
        public bool CapNhatSoLuong(string maSP, int soLuongMoi)
        {
            // Giả sử lớp DAL của bạn có hàm ExecuteNonQuery
            string query = "UPDATE SanPham SET SoLuongTon = " + soLuongMoi + " WHERE MaSP = '" + maSP + "'";
            return dal.ExecuteNonQuery(query);
        }
        public bool CapNhatSanPham(string maSP, string tenSP, string maDM, string size, string mauSac, decimal giaBan)
        {
            // Gọi hàm DAL để UPDATE vào CSDL
            return dal.CapNhat(maSP, tenSP, maDM, size, mauSac, giaBan);
        }
        public async Task<DataTable> GetSanPhamTheoLoaiBUS(string maDM)
        {
            return await dal.GetSanPhamTheoLoaiDAL(maDM);
        }
    }
}