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
    public partial class ucQuanLyKho : UserControl
    {
        SanPhamBUS bus = new SanPhamBUS();
        public ucQuanLyKho()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgvSanPham.DataSource = bus.LayDanhSachSanPham();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucQuanLyKho_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ten = txtTenSP.Text;
            int soLuong = int.Parse(txtSoLuong.Text);
            decimal giaNhap = decimal.Parse(txtGiaNhap.Text);
            decimal giaBan = decimal.Parse(txtGiaBan.Text);

            bool result = bus.ThemSanPham(ten, soLuong, giaNhap, giaBan);

            if (result)
            {
                MessageBox.Show("Thêm sản phẩm thành công");
                LoadData();
            }
            else
            {
                MessageBox.Show("Dữ liệu không hợp lệ");
            }
        }
    }
}
