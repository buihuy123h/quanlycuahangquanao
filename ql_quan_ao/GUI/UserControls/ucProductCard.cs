using System;
using System.Drawing;
using System.Windows.Forms;

namespace ql_quan_ao.GUI.UserControls
{
    public partial class ucProductCard : UserControl
    {
        // Property lưu mã sản phẩm
        public string MaSP { get; private set; }

        public ucProductCard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Hàm nạp dữ liệu lên Card
        /// </summary>
        public void ThietLapThongTin(string maSP, string tenSP, decimal giaBan, int soLuongTon, string anhSP)
        {
            this.MaSP = maSP;

            lblMaSP.Text = maSP;
            lblTenSP.Text = tenSP;

            // TÊN LABEL PHẢI ĐÚNG
            lblGiaBan.Text = giaBan.ToString("N0") + "đ";

            lblTonKho.Text = "Tồn: " + soLuongTon;

            if (soLuongTon <= 0)
            {
                lblTonKho.Text = "Hết hàng!";
                lblTonKho.ForeColor = Color.Red;
            }
            try
            {
                if (!string.IsNullOrEmpty(anhSP))
                {
                    picAnhSP.Load(anhSP);
                }
            }
            catch
            {
                picAnhSP.Image = null;
                picAnhSP.BackColor = Color.LightGray;
            }
        }

        private void picAnhSP_Click(object sender, EventArgs e)
        {

        }
    }
}