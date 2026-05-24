using System;
using System.Data;
using System.Windows.Forms;
using ql_quan_ao.BUS;

namespace ql_quan_ao.GUI.UserControls
{
    public partial class ucKhachHang : UserControl
    {
        private QuanLyKhachHangBUS khBUS = new QuanLyKhachHangBUS();

        public ucKhachHang()
        {
            InitializeComponent();

            // Ép liên kết sự kiện click chuột cho nút Tìm kiếm
            this.btnTimKiemKhach.Click += new System.EventHandler(this.btnTimKiemKhach_Click);

            // ÉP NẠP DỮ LIỆU TRỰC TIẾP: Đảm bảo bảng luôn tự vẽ cột và đổ dữ liệu ngay khi mở ứng dụng
            LoadDataGridKhachHang();
        }

        private void ucKhachHang_Load(object sender, EventArgs e)
        {
            LoadDataGridKhachHang();
        }

        private void ucKhachHang_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && dgvKhachHang != null)
            {
                LoadDataGridKhachHang();
            }
        }

        /// <summary>
        /// Nạp dữ liệu và ép tự động vẽ cột lên dgvKhachHang
        /// </summary>
        public void LoadDataGridKhachHang()
        {
            if (dgvKhachHang != null && khBUS != null)
            {
                dgvKhachHang.DataSource = null; // Xóa trạng thái rỗng cũ
                dgvKhachHang.AutoGenerateColumns = true; // Bật tính năng tự động nhận diện vẽ cột

                DataTable dt = khBUS.LayDanhSachTabKhachHang();
                dgvKhachHang.DataSource = dt; // Đổ toàn bộ bảng dữ liệu vào dgvKhachHang
            }
        }

        /// <summary>
        /// Chức năng: Tìm kiếm khách hàng mua nhiều nhất
        /// </summary>
        private void btnTimKiemKhach_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.Rows.Count == 0 || dgvKhachHang.DataSource == null)
            {
                MessageBox.Show("Bảng dữ liệu khách hàng hiện đang trống, không thể tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenKhachHangMax = "";
            string maKhachHangMax = "";
            int soLanMuaMax = -1;

            foreach (DataGridViewRow row in dgvKhachHang.Rows)
            {
                if (row.Cells["Mã KH"].Value != null && row.Cells["Số lần mua"].Value != null)
                {
                    int soLanMuaCur = Convert.ToInt32(row.Cells["Số lần mua"].Value);

                    if (soLanMuaCur > soLanMuaMax)
                    {
                        soLanMuaMax = soLanMuaCur;
                        maKhachHangMax = row.Cells["Mã KH"].Value.ToString();
                        tenKhachHangMax = row.Cells["Tên KH"].Value?.ToString() ?? "Chưa rõ tên";
                    }
                }
            }

            if (soLanMuaMax >= 0)
            {
                MessageBox.Show($"Khách hàng mua nhiều nhất hệ thống là:\n\n" +
                                $" - Mã KH: {maKhachHangMax}\n" +
                                $" - Tên KH: {tenKhachHangMax}\n" +
                                $" - Tổng số lần mua: {soLanMuaMax} lần",
                                "Kết quả tìm kiếm",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }
    }
}