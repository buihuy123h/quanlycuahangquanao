using System;
using System.Drawing;
using System.Windows.Forms;

namespace ql_quan_ao.GUI.UserControls
{
    public partial class ucProductCard : UserControl
    {
        // Property lưu mã sản phẩm công khai để các form khác có thể đọc
        public string MaSP { get; private set; }

        // Sự kiện gửi Mã sản phẩm ra ngoài khi người dùng click vào Card
        public event EventHandler<string> SanPhamSelected;

        public ucProductCard()
        {
            InitializeComponent();
            RegisterHoverAndClickEvents();

            // Đăng ký sự kiện click cho chính bản thân UserControl
            this.Click += ucProductCard_Click;
        }

        /// <summary>
        /// Hàm tự động đăng ký sự kiện hover và click cho UserControl và tất cả các thành phần con bên trong
        /// </summary>
        private void RegisterHoverAndClickEvents()
        {
            // Đăng ký sự kiện Hover cho chính UserControl
            this.MouseEnter += ucProductCard_MouseEnter;
            this.MouseLeave += ucProductCard_MouseLeave;

            // Duyệt qua tất cả các control con (nhãn chữ, hình ảnh) để gán chung sự kiện
            foreach (Control ctrl in this.Controls)
            {
                ctrl.MouseEnter += ucProductCard_MouseEnter;
                ctrl.MouseLeave += ucProductCard_MouseLeave;

                // Ép các thành phần con khi bị click thì cũng kích hoạt sự kiện click của cả Card
                if (ctrl != picAnhSP)
                {
                    ctrl.Click += (s, e) => this.OnClick(e);
                }
            }
        }

        /// <summary>
        /// Hàm nạp dữ liệu từ Database lên giao diện của Card sản phẩm
        /// </summary>
        public void ThietLapThongTin(string maSP, string tenSP, decimal giaBan, int soLuongTon, string anhSP)
        {
            this.MaSP = maSP;

            lblMaSP.Text = maSP;
            lblTenSP.Text = tenSP;
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

        // Xử lý sự kiện click vào PictureBox ảnh sản phẩm
        private void picAnhSP_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        // Khi click vào bất kỳ vị trí nào trên Card, truyền mã sản phẩm ra ngoài
        private void ucProductCard_Click(object sender, EventArgs e)
        {
            // Kích hoạt sự kiện và bắn MaSP sang cho ucBanHang hứng
            SanPhamSelected?.Invoke(this, this.MaSP);
        }

        // Hiệu ứng đổi màu nền sang DeepSkyBlue khi di chuột vào ô sản phẩm
        private void ucProductCard_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.DeepSkyBlue;
        }

        // Trả lại màu nền mặc định LightGray khi chuột rời hẳn khỏi ô sản phẩm
        private void ucProductCard_MouseLeave(object sender, EventArgs e)
        {
            // Kiểm tra xem con trỏ chuột thực sự đã ra khỏi phạm vi của toàn bộ Card chưa
            if (!this.ClientRectangle.Contains(this.PointToClient(Control.MousePosition)))
            {
                this.BackColor = Color.LightGray;
            }
        }
    }
}