using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ql_quan_ao.DAL;
namespace ql_quan_ao.GUI.UserControls
{
    public partial class ucBanHang : UserControl
    {
        DatabaseConnect db = new DatabaseConnect();

        public ucBanHang()
        {
            InitializeComponent();
            HienThiTatCaSanPham();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panelCenter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void HienThiTatCaSanPham()
        {
            // Xóa card cũ
            flpDanhSachSP.Controls.Clear();

            // Query lấy sản phẩm
            string query = "SELECT MaSP, TenSP, GiaBan, SoLuongTon, AnhSP FROM SanPham";

            // Lấy dữ liệu
            DataTable dtSanPham = db.ExecuteQuery(query);

            // Duyệt từng sản phẩm
            foreach (DataRow row in dtSanPham.Rows)
            {
                string maSP = row["MaSP"].ToString();
                string tenSP = row["TenSP"].ToString();
                decimal giaBan = Convert.ToDecimal(row["GiaBan"]);
                int soLuongTon = Convert.ToInt32(row["SoLuongTon"]);
                string anhSP = row["AnhSP"].ToString();


                // Tạo card
                ucProductCard card = new ucProductCard();

                // Nạp dữ liệu
                card.ThietLapThongTin(maSP, tenSP, giaBan, soLuongTon,anhSP);

                // Sự kiện click card
                card.Click += (sender, e) =>
                {
                    MessageBox.Show(
                        "Bạn vừa chọn mua: " + tenSP,
                        "Thông báo"
                    );
                };

                // Thêm card vào FlowLayoutPanel
                flpDanhSachSP.Controls.Add(card);
            }
        }


    }
}
