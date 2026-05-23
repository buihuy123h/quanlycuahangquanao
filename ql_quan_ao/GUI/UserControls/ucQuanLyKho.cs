using System;
using System.Windows.Forms;
using BUS; // Đã liên kết thành công với namespace BUS sạch lỗi ở trên!

namespace ql_quan_ao
{
    public partial class ucQuanLyKho : UserControl
    {
        private SanPhamBUS bus = new SanPhamBUS();

        public ucQuanLyKho()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvSanPham.DataSource = bus.LayDanhSachSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách kho hàng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ten = txtTenSP.Text;

            // Chống sập ứng dụng (Crash) nếu người dùng để trống ô số lượng hoặc nhập chữ cái rác
            if (!int.TryParse(txtSoLuong.Text, out int soLuong) ||
                !decimal.TryParse(txtGiaNhap.Text, out decimal giaNhap) ||
                !decimal.TryParse(txtGiaBan.Text, out decimal giaBan))
            {
                MessageBox.Show("Số lượng, Giá nhập và Giá bán phải nhập định dạng số hợp lệ!", "Dữ liệu lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi xuống tầng nghiệp vụ BUS để thực thi lệnh thêm
            bool result = bus.ThemSanPham(ten, soLuong, giaNhap, giaBan);

            if (result)
            {
                MessageBox.Show("Thêm sản phẩm vào kho thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Tải lại bảng dữ liệu GridView mới ngay lập tức
            }
            else
            {
                MessageBox.Show("Dữ liệu không hợp lệ! Vui lòng kiểm tra lại tên hoặc giá trị tiền.", "Thêm thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Dọn dẹp các hàm sự kiện thừa (Giữ nguyên cấu trúc WinForms Designer) ---
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void ucQuanLyKho_Load(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }
        private void button4_Click(object sender, EventArgs e) { }
    }
}