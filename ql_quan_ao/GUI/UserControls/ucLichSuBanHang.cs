using ql_quan_ao.BUS;
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
    }
}