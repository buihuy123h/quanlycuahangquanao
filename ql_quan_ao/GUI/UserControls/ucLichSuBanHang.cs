using ql_quan_ao.BUS;
using ql_quan_ao.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ql_quan_ao.GUI.UserControls
{
    public partial class ucLichSuBanHang : UserControl
    {
        HoaDonBUS hoaDonBUS = new HoaDonBUS();
        public ucLichSuBanHang()
        {
            InitializeComponent();

            colMaHD.DataPropertyName = "MaHoaDon";
            colNgayLap.DataPropertyName = "NgayLap";
            colTenKH.DataPropertyName = "TenKhachHang";
            colTongTien.DataPropertyName = "TongTien";
            loadData();

        }
        public void loadData()
        {
            dgvLichSuBanHang.AutoGenerateColumns = false;
            DataTable danhsachhoadon = hoaDonBUS.LayDSHoaDon();
            dgvLichSuBanHang.DataSource = danhsachhoadon;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Gọi tầng BLL xử lý và lấy dữ liệu về (không cần quan tâm SQL viết như thế nào nữa)
                DataTable dt = hoaDonBUS.LayDanhSachHoaDonTheoThoiGian(dateTimePicker1.Value, dateTimePicker2.Value);

                // 2. Ánh xạ cấu trúc cột hiển thị
                colMaHD.DataPropertyName = "MaHD";
                colNgayLap.DataPropertyName = "NgayLap";
                colTenKH.DataPropertyName = "TenKH";
                colTongTien.DataPropertyName = "TongTien";

                // 3. Đổ dữ liệu lên Grid
                dgvLichSuBanHang.DataSource = dt;

                // 4. Kiểm tra số lượng dòng để báo nếu trống
                if (dgvLichSuBanHang.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn nào trong khoảng thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException argEx)
            {
                // Bắt riêng lỗi logic ngày tháng do tầng BLL ném ra
                MessageBox.Show(argEx.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Bắt các lỗi hệ thống hoặc lỗi kết nối SQL từ tầng DAL truyền lên
                MessageBox.Show("Đã xảy ra lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}