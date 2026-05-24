using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BUS; // Đảm bảo project đã tham chiếu tới Project BUS

namespace ql_quan_ao
{
    public partial class ucQuanLyKho : UserControl
    {
        private SanPhamBUS bus = new SanPhamBUS();
        private DataTable dtSanPham; // Lưu dữ liệu trên RAM để tìm kiếm cực nhanh

        public ucQuanLyKho()
        {
            InitializeComponent();

            // Gán sự kiện cho bộ lọc (Tự động lọc khi người dùng gõ/chọn)
            txtTimKiem.TextChanged += (s, e) => TimKiemSanPham();
            cboLoai.SelectedIndexChanged += (s, e) => TimKiemSanPham();
            cboSize.SelectedIndexChanged += (s, e) => TimKiemSanPham();
            cboMau.SelectedIndexChanged += (s, e) => TimKiemSanPham();

            // Gán sự kiện cảnh báo hàng tồn (Chức năng 1.2)
            dgvSanPham.CellFormatting += DgvSanPham_CellFormatting;
        }

        private void ucQuanLyKho_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dtSanPham = bus.LayDanhSachKhoHang();
                dgvSanPham.DataSource = dtSanPham;

                // Cấu hình hiển thị bảng
                dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void TimKiemSanPham()
        {
            if (dtSanPham == null) return;

            string filter = "1=1"; // Điều kiện cơ bản

            if (!string.IsNullOrWhiteSpace(txtTimKiem.Text))
                filter += string.Format(" AND (TenSP LIKE '%{0}%' OR MaSP LIKE '%{0}%')", txtTimKiem.Text.Replace("'", "''"));

            if (cboLoai.SelectedIndex > 0)
                filter += string.Format(" AND LoaiSP = '{0}'", cboLoai.Text);

            if (cboSize.SelectedIndex > 0)
                filter += string.Format(" AND Size = '{0}'", cboSize.Text);

            if (cboMau.SelectedIndex > 0)
                filter += string.Format(" AND MauSac = '{0}'", cboMau.Text);

            dtSanPham.DefaultView.RowFilter = filter;
        }

        private void DgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Chức năng 1.2: Tự động cảnh báo hàng tồn < 5
            if (dgvSanPham.Columns[e.ColumnIndex].Name == "SoLuongTon")
            {
                if (e.Value != null && int.TryParse(e.Value.ToString(), out int sl))
                {
                    if (sl < 5)
                    {
                        dgvSanPham.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
                        dgvSanPham.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                }
            }
        }

        // --- Các nút chức năng (Sẽ code chi tiết ở các bước sau) ---
        private void btnThem_Click(object sender, EventArgs e) { /* Code thêm mới */ }
        private void btnSua_Click(object sender, EventArgs e) { /* Code sửa */ }
        private void btnXoa_Click(object sender, EventArgs e) { /* Code xóa */ }
        private void btnNhapKho_Click(object sender, EventArgs e) { /* Code nhập kho */ }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}