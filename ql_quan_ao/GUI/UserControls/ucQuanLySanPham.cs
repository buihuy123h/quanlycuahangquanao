using System;
using System.Windows.Forms;
using ql_quan_ao.BUS;

namespace ql_quan_ao.GUI.UserControls
{
    public partial class ucQuanLySanPham : UserControl
    {
        private QuanLySanPhamBUS spBUS = new QuanLySanPhamBUS();
        private bool isSelectedRow = false; // Biến kiểm tra xem người dùng đã chọn dòng chưa

        public ucQuanLySanPham()
        {
            InitializeComponent();

            // Ép liên kết sự kiện để các nút và bảng luôn hoạt động ổn định
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            this.dgvSanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellClick);
        }

        private void ucQuanLySanPham_Load(object sender, EventArgs e)
        {
            LoadDataGrid(); // Tự động hiển thị danh sách khi mở tab
        }

        private void ucQuanLySanPham_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && dgvSanPham != null)
            {
                LoadDataGrid();
            }
        }

        private void LoadDataGrid()
        {
            if (dgvSanPham != null && spBUS != null)
            {
                // ĐỔI THÀNH TRUE: Cho phép bảng tự động đổ dữ liệu từ SQL lên các cột
                dgvSanPham.AutoGenerateColumns = true;

                dgvSanPham.DataSource = spBUS.LayDanhSachTabSanPham();
                isSelectedRow = false;
            }
        }

        // Chức năng: THÊM SẢN PHẨM
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Ràng buộc: Không được để trống thông tin
            if (string.IsNullOrWhiteSpace(txtMSP.Text) || string.IsNullOrWhiteSpace(txtTSP.Text) || string.IsNullOrWhiteSpace(txtGia.Text))
            {
                MessageBox.Show("Không được để trống thông tin sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ràng buộc: Giá bán phải lớn hơn 0
            if (decimal.TryParse(txtGia.Text.Trim(), out decimal giaCheck) && giaCheck <= 0)
            {
                MessageBox.Show("Giá bán sản phẩm phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (spBUS.ChucNangThemSP(txtMSP.Text, txtTSP.Text, txtGia.Text))
            {
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGrid(); // Cập nhật lại danh sách
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Thêm thất bại! Mã sản phẩm có thể đã tồn tại trong hệ thống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); // Ràng buộc mã không trùng
            }
        }

        // Chức năng: SỬA SẢN PHẨM
        private void btnSua_Click(object sender, EventArgs e)
        {
            // Ràng buộc: Phải chọn sản phẩm trong bảng trước khi sửa
            if (!isSelectedRow)
            {
                MessageBox.Show("Vui lòng click chọn một dòng sản phẩm trên bảng trước khi sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTSP.Text) || string.IsNullOrWhiteSpace(txtGia.Text))
            {
                MessageBox.Show("Tên sản phẩm và Giá bán không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (spBUS.ChucNangSuaSP(txtMSP.Text, txtTSP.Text, txtGia.Text))
            {
                MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGrid(); // Cập nhật lại danh sách
                ClearInputs();
            }
        }

        // Chức năng: XÓA SẢN PHẨM
        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Ràng buộc: Phải chọn sản phẩm cần xóa
            if (!isSelectedRow)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa trên bảng dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult r = MessageBox.Show($"Bạn có chắc muốn xóa sản phẩm {txtMSP.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (spBUS.ChucNangXoaSP(txtMSP.Text))
                {
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGrid(); // Cập nhật lại danh sách
                    ClearInputs();
                }
            }
        }

        // Chức năng: LÀM MỚI
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs(); // Xóa tất cả nội dung các ô nhập
        }

        private void ClearInputs()
        {
            txtMSP.Clear();
            txtTSP.Clear();
            txtGia.Clear();
            txtMSP.Enabled = true; // Mở khóa lại ô Mã SP
            isSelectedRow = false;
        }

        // Sự kiện: Chọn 1 dòng đẩy dữ liệu ngược lên các ô nhập tương ứng
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];

                txtMSP.Text = row.Cells["Mã SP"].Value?.ToString(); // Đẩy dữ liệu lên ô nhập
                txtTSP.Text = row.Cells["Tên SP"].Value?.ToString();
                txtGia.Text = row.Cells["Giá bán"].Value?.ToString();

                txtMSP.Enabled = false; // Khóa không cho sửa Mã SP vì là Khóa chính (Primary Key)
                isSelectedRow = true;   // Xác nhận đã chọn dòng hợp lệ
            }
        }
    }
}