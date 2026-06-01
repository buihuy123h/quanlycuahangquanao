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
            
                DataTable dt = hoaDonBUS.LayDanhSachHoaDonTheoThoiGian(dateTimePicker1.Value, dateTimePicker2.Value);

                // 2. Ánh xạ cấu trúc cột hiển thị
                colMaHD.DataPropertyName = "MaHD";
                colNgayLap.DataPropertyName = "NgayLap";
                colTenKH.DataPropertyName = "TenKH";
                colTongTien.DataPropertyName = "TongTien";

                dgvLichSuBanHang.DataSource = dt;
                
                if (dgvLichSuBanHang.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn nào trong khoảng thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show(argEx.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}