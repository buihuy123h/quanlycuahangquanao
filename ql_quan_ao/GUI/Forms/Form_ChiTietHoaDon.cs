using QuanLyCuaHang.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ql_quan_ao.GUI.Forms
{
    public partial class Form_ChiTietHoaDon : Form
    {
        // Biến lưu trữ mã hóa đơn được truyền từ Form lịch sử sang
        private string _maHD;

        // Ép buộc phải truyền mã hóa đơn khi khởi tạo Form này
        public Form_ChiTietHoaDon(string maHD)
        {
            InitializeComponent();
            _maHD = maHD;
        }

        // Sự kiện tự động chạy khi Form chi tiết được mở lên
        private void Form_ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Chi tiết hóa đơn: " + _maHD;

                // Viết chuỗi trên một dòng duy nhất, viết liền mạch để DataProvider thực thi không bị lỗi ký tự xuống dòng
                string sql = "SELECT MaHD AS MaHD, MaSP AS MaSP, SoLuong AS SoLuong, DonGia AS DonGia, ThanhTien AS ThanhTien " +
                     "FROM ChiTietHoaDon " +
                     "WHERE MaHD = " + _maHD;

                // Gọi truy vấn bằng nối chuỗi thuần túy
                DataTable dt = DataProvider.Instance.ExecuteQuery(sql);

                // Giữ nguyên cấu hình không tự sinh cột
                dgvDanhSach.AutoGenerateColumns = false;

                // Gán nguồn dữ liệu
                dgvDanhSach.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị dữ liệu: " + ex.Message);
            }
        }

        // Xóa bỏ các sự kiện trống không dùng đến để code gọn gàng hơn
    }
}