using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;  

namespace ql_quan_ao
{
    public partial class FormThongTinSanPham : Form
    {
        private ErrorProvider errorProvider1 = new ErrorProvider();
        // =========================================================
        // CHÈN CHÍNH XÁC DÒNG NÀY VÀO ĐÂY ĐỂ XỬ LÝ DỨT ĐIỂM LỖI ĐỎ:
        // =========================================================
        private bool isAdding = true;
        private SanPhamBUS bus = new SanPhamBUS(); // Hoặc SanPhamBUS bus = new SanPhamBUS(); tùy theo project của bạn
        public FormThongTinSanPham()
        {
            InitializeComponent();
        }

        public void ThietLapCheDo(bool modeThemMoi, DataGridViewRow rowXoaSua)
        {
            this.isAdding = modeThemMoi; // Dòng này sẽ lập tức hết báo đỏ!
            // ... nội dung code xử lý bên trong giữ nguyên ...
        }
        public void LoadDuLieu(string ma, string ten, string maDM, string size, string mau, string gia)
        {
            txtMaSP.Text = ma;
            txtMaSP.Enabled = false; // Khóa mã SP không cho sửa
            txtTenSP.Text = ten;
            cboMaDM.Text = maDM;
            cboSize.Text = size;
            cboMau.Text = mau;
            txtGiaBan.Text = gia;
        }

        // Hãy đảm bảo tên hàm này trùng khớp hoàn toàn với tên hàm vừa tự sinh ra khi click đúp nút Lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra tính hợp lệ qua ErrorProvider
            if (!ValidateInput()) return; // Nếu có lỗi (false), hàm sẽ thoát ngay, không lưu

            // 2. Nếu vượt qua, tiếp tục thu thập dữ liệu
            string maSP = txtMaSP.Text.Trim();
            string tenSP = txtTenSP.Text.Trim();
            string size = cboSize.Text;
            string mauSac = cboMau.Text;
            decimal giaBan = decimal.Parse(txtGiaBan.Text);
            string MaDM = cboMaDM.SelectedValue?.ToString(); // Hoặc lấy từ Text

            // ... (Phần switch cboMaDM giữ nguyên) ...

            // 3. Thực hiện lưu
            if (isAdding)
            {
                if (bus.ThemSanPham(maSP, tenSP, MaDM, size, mauSac, giaBan, 0))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                // Code cập nhật (Update) nếu cần
            }
        }
        private bool ValidateInput()
        {
            // Xóa tất cả các lỗi hiện tại trước khi kiểm tra mới
            errorProvider1.Clear();
            bool hopLe = true;

            // Kiểm tra tên
            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                errorProvider1.SetError(txtTenSP, "Tên sản phẩm không được để trống!");
                hopLe = false;
            }

            // Kiểm tra giá bán (phải là số và >= 0)
            if (!decimal.TryParse(txtGiaBan.Text, out decimal gia) || gia < 0)
            {
                errorProvider1.SetError(txtGiaBan, "Giá bán không hợp lệ!");
                hopLe = false;
            }

            // (Bạn có thể thêm các ô khác như MaSP, SoLuong vào đây tương tự)

            return hopLe;
        }

        // Hãy đảm bảo tên hàm này trùng khớp hoàn toàn với tên hàm vừa tự sinh ra khi click đúp nút Hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close(); // Lệnh đóng Form ngay lập tức khi bấm Huỷ
        }

        private void FormThongTinSanPham_Load(object sender, EventArgs e)
        {

        }
    }
}