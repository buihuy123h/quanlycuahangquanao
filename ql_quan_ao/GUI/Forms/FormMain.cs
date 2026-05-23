using ql_quan_ao.GUI.UserControls;
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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            HienThiUserControl(new ucBanHang());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            SanPhamBUS bus = new SanPhamBUS();
            var dt = bus.LayDanhSachSanPham();

            MessageBox.Show("Số sản phẩm: " + dt.Rows.Count);
        }
        private void HienThiUserControl(UserControl uc)
        {
            panelContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            HienThiUserControl(new ucBanHang());
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            HienThiUserControl(new ucLichSuBanHang());
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            HienThiUserControl(new ucQuanLySanPham());
        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            HienThiUserControl(new ucQuanLyKho());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            HienThiUserControl(new ucKhachHang());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            HienThiUserControl(new ucBaoCaoThongKe());
        }
    }
}