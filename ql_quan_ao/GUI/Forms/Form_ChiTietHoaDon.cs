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
        string _maHD;

        // Constructor nhận mã hóa đơn
        public Form_ChiTietHoaDon(string maHD)
        {
            InitializeComponent();
            _maHD = maHD;
        }

        private void Form_ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            string sql = "SELECT MaHD, MaSP, SoLuong, DonGia, ThanhTien FROM ChiTietHoaDon WHERE MaHD = '" + _maHD + "'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(sql);

            // Ép buộc không tự sinh cột để dùng cấu hình bạn đã thiết kế trong Designer
            dgvDanhSach.AutoGenerateColumns = false;

            // Gán dữ liệu
            dgvDanhSach.DataSource = dt;
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra để tránh lỗi khi click vào Header (dòng tiêu đề)
            if (e.RowIndex >= 0)
            {
                // Lấy MaHD từ cột "MaHD"
                string maHD = dgvDanhSach.Rows[e.RowIndex].Cells["MaHD"].Value.ToString();

                // Mở Form chi tiết và truyền MaHD qua constructor
                Form_ChiTietHoaDon f = new Form_ChiTietHoaDon(maHD);
                f.ShowDialog();
            }
        }
    }
}

