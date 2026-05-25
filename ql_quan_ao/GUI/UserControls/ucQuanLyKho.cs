using BUS; // Đảm bảo project đã tham chiếu tới Project BUS
using ql_quan_ao.GUI.UserControls;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

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
        // 1. Sự kiện Click vào bảng để đổ dữ liệu sang ô nhập liệu
        // Biến tạm để lưu thông tin dòng đang chọn
        private string selectedMaSP = "";
        private int selectedSoLuongTon = 0;

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];

                // Lưu thông tin vào biến tạm để dùng khi nhấn "Xác nhận nhập kho"
                selectedMaSP = row.Cells["MaSP"].Value.ToString();
                selectedSoLuongTon = Convert.ToInt32(row.Cells["SoLuongTon"].Value);

                // Thông báo cho người dùng biết đã chọn sản phẩm
                // (Không cần gán vào ô bên trái vì giao diện không có)
            }
        }

        

        // --- Các nút chức năng (Sẽ code chi tiết ở các bước sau) ---
        private void btnThem_Click(object sender, EventArgs e) { /* Code thêm mới */ }
        private void btnSua_Click(object sender, EventArgs e) { /* Code sửa */ }
        private void btnXoa_Click(object sender, EventArgs e) { /* Code xóa */ }
        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm trên bảng trước!");
                return;
            }

            DataGridViewRow row = dgvSanPham.SelectedRows[0];

            // CÁCH MỚI: Truy cập bằng Index thay vì Tên cột (Ví dụ: cột 0 là MaSP, cột 7 là SoLuongTon)
            // Bạn hãy đếm xem trên lưới của bạn "MaSP" là cột thứ mấy (bắt đầu từ 0)
            string maSP = row.Cells[0].Value.ToString();

            // Tương tự, nếu SoLuongTon là cột thứ 7 (đếm từ trái sang, bắt đầu từ 0)
            int slHienTai = Convert.ToInt32(row.Cells[7].Value);

            FormNhapKho f = new FormNhapKho();
            if (f.ShowDialog() == DialogResult.OK)
            {
                int slNhapThem = f.SoLuongNhap;
                int slMoi = slHienTai + slNhapThem;

                if (bus.CapNhatSoLuong(maSP, slMoi))
                {
                    MessageBox.Show("Nhập kho thành công!");
                    LoadData();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}