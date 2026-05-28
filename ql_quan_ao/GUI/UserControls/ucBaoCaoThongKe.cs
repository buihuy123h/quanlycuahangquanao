using ql_quan_ao.GUI.Forms;
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

namespace ql_quan_ao.GUI.UserControls
{
    public partial class ucBaoCaoThongKe : UserControl
    {
        BUS.ThongKeBUS bus = new BUS.ThongKeBUS();
        public ucBaoCaoThongKe()
        {
            InitializeComponent();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // 1. Lấy ngày từ giao diện
            DateTime tu = dtpTuNgay.Value;
            DateTime den = dtpDenNgay.Value;

            // 2. Gọi BUS thực thi truy vấn
            // Lấy dữ liệu cho lưới
            DataTable dtDS = bus.LayDanhSachHoaDon(tu, den);
            // Lấy dữ liệu tổng hợp (SUM, COUNT)
            DataTable dtTong = bus.LaySoLieuTongQuan(tu, den);

            // 3. Tải dữ liệu vào lưới
            dgvHoaDon.DataSource = dtDS;

            // 4. Cập nhật các Label số liệu
            // Trong hàm btnThongKe_Click
            if (dtTong.Rows.Count > 0)
            {
                DataRow row = dtTong.Rows[0];
                decimal doanhThu = Convert.ToDecimal(row["TongDoanhThu"]);
                lblTongDoanhThu.Text = "Tổng doanh thu: " + doanhThu.ToString("N0") + " VND";
                lblTongHoaDon.Text = "Tổng số hóa đơn: " + row["TongSoHoaDon"].ToString();
                // Bỏ dòng gán lblTongSanPham vì không có dữ liệu
            }
            string tuNgay = dtpTuNgay.Value.ToString("yyyy-MM-dd");
    string denNgay = dtpDenNgay.Value.ToString("yyyy-MM-dd");
    
    LoadTopSanPham(tuNgay, denNgay);
        }

        private void cboChonNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            if (cboChonNhanh.Text == "Hôm nay")
            {
                dtpTuNgay.Value = now;
                dtpDenNgay.Value = now;
            }
            else if (cboChonNhanh.Text == "Tháng này")
            {
                dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
                dtpDenNgay.Value = now;
            }
            // Tự động kích hoạt nút Thống kê sau khi chọn
            btnThongKe.PerformClick();
        }

        private void dgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra để đảm bảo người dùng click vào dòng dữ liệu, không phải header
            if (e.RowIndex >= 0)
            {
                // 2. Lấy ra giá trị cột MaHD tại dòng vừa click đúp
                // Thay "MaHD" bằng đúng tên cột chứa mã hóa đơn trong DataGridView của bạn
                string maHD = dgvHoaDon.Rows[e.RowIndex].Cells["MaHD"].Value.ToString();

                // 3. Khởi tạo và hiển thị Form con (Form_ChiTietHoaDon)
                Form_ChiTietHoaDon f = new Form_ChiTietHoaDon(maHD);
                f.ShowDialog();
            }
        }
        private void LoadTopSanPham(string dateStart, string dateEnd)
        {
            // Câu lệnh SQL lấy ra 5 sản phẩm có số lượng bán nhiều nhất
            string sql = @"
        SELECT TOP 5 S.TenSP, SUM(C.SoLuong) AS TongSoLuong 
        FROM ChiTietHoaDon C
        INNER JOIN HoaDon H ON C.MaHD = H.MaHD
        INNER JOIN SanPham S ON C.MaSP = S.MaSP  -- PHẢI JOIN VÀO ĐÂY THÌ MỚI CÓ TenSP
        WHERE H.NgayLap BETWEEN '2026-05-01' AND '2026-05-31' -- Thay ngày của bạn vào
        GROUP BY S.TenSP 
        ORDER BY TongSoLuong DESC";

            DataTable dt = DataProvider.Instance.ExecuteQuery(sql);

            // Gán dữ liệu vào bảng phụ
            dgvTopSanPham.DataSource = dt;
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
