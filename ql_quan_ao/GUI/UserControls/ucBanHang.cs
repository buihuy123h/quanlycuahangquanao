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

        // Biến lưu trữ thông số đang được chọn
        private string sizeDuocChon = "";
        private string mauDuocChon = "";
        private decimal giaHienTai = 0;
        private int soLuongMua = 1;
        private int maxTonKho = 0;

        public ucBanHang()
        {
            InitializeComponent();

            // Bật vẽ kép giúp FlowLayoutPanel cuộn mượt
            typeof(FlowLayoutPanel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, flpDanhSachSP, new object[] { true });

            // Đăng ký sự kiện xử lý thông số ngay khi khởi tạo
            GanSuKienChonSize();
            GanSuKienChonMau();
            GanSuKienTangGiamSoLuong();
        }

        #region XỬ LÝ SỰ KIỆN CHỌN THÔNG SỐ (SIZE, MÀU, SỐ LƯỢNG)

        // 1. Xử lý đổi màu khi chọn Size
        private void GanSuKienChonSize()
        {
            Button[] dsButtonSize = { button12, button13, button14, button15 };
            foreach (Button btn in dsButtonSize)
            {
                btn.Click += (s, e) =>
                {
                    // Trả lại màu nền trắng cho tất cả các nút size
                    foreach (Button b in dsButtonSize)
                    {
                        b.BackColor = Color.White;
                        b.ForeColor = Color.Black;
                    }

                    // Đổi màu nút được chọn sang màu xanh làm điểm nhấn
                    btn.BackColor = Color.DodgerBlue;
                    btn.ForeColor = Color.White;
                    sizeDuocChon = btn.Text; // Lưu lại size vừa chọn
                };
            }
        }

        // 2. Xử lý đổi màu viền khi chọn Màu sắc
        private void GanSuKienChonMau()
        {
            Panel[] dsPanelMau = { panel3, panel4, panel5, panel6 };
            foreach (Panel pnl in dsPanelMau)
            {
                // Tìm Label chứa tên màu nằm trong panel đó
                Label lblColorName = pnl.Controls.OfType<Label>().FirstOrDefault();
                PictureBox picCircle = pnl.Controls.OfType<PictureBox>().FirstOrDefault();

                EventHandler colorSelectEvent = (s, e) =>
                {
                    // Trả lại nền trong suốt cho tất cả panel màu
                    foreach (Panel p in dsPanelMau) p.BackColor = Color.Transparent;

                    // Đổi màu nền panel được chọn sang xanh nhạt để làm nổi bật
                    pnl.BackColor = Color.LightSkyBlue;

                    if (lblColorName != null)
                    {
                        mauDuocChon = lblColorName.Text; // Lưu lại màu vừa chọn
                    }
                };

                // Gán sự kiện click cho cả Panel, Label và PictureBox để click vào đâu cũng nhận
                pnl.Click += colorSelectEvent;
                if (lblColorName != null) lblColorName.Click += colorSelectEvent;
                if (picCircle != null) picCircle.Click += colorSelectEvent;
            }
        }

        // 3. Tăng giảm số lượng và tự động tính tiền
        private void GanSuKienTangGiamSoLuong()
        {
            // Thiết lập giá trị mặc định ban đầu cho ô số lượng
            textBox2.Text = soLuongMua.ToString();
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox3.ReadOnly = true; // Không cho người dùng tự sửa ô thành tiền

            // Nút Giảm (-)
            button16.Click += (s, e) =>
            {
                if (soLuongMua > 1)
                {
                    soLuongMua--;
                    CapNhatSoLuongVaTinhTien();
                }
            };

            // Nút Tăng (+)
            button17.Click += (s, e) =>
            {
                if (soLuongMua < maxTonKho)
                {
                    soLuongMua++;
                    CapNhatSoLuongVaTinhTien();
                }
                else
                {
                    MessageBox.Show($"Sản phẩm này chỉ còn tối đa {maxTonKho} sản phẩm trong kho!", "Thông báo");
                }
            };

            // Người dùng tự gõ vào ô số lượng
            textBox2.TextChanged += (s, e) =>
            {
                if (int.TryParse(textBox2.Text, out int result))
                {
                    if (result < 1) soLuongMua = 1;
                    else if (result > maxTonKho && maxTonKho > 0)
                    {
                        MessageBox.Show($"Số lượng vượt quá tồn kho ({maxTonKho})!", "Thông báo");
                        soLuongMua = maxTonKho;
                    }
                    else soLuongMua = result;
                }
                else
                {
                    soLuongMua = 1;
                }
                CapNhatSoLuongVaTinhTien();
            };
        }

        private void CapNhatSoLuongVaTinhTien()
        {
            // Tránh vòng lặp vô hạn khi gán text
            if (textBox2.Text != soLuongMua.ToString())
            {
                textBox2.Text = soLuongMua.ToString();
            }

            decimal thanhTien = soLuongMua * giaHienTai;
            textBox3.Text = thanhTien.ToString("#,##0") + "đ";
        }

        // Reset lại trạng thái các nút chọn thông số khi đổi sang sản phẩm khác
        private void ResetThongSoChon()
        {
            sizeDuocChon = "";
            mauDuocChon = "";
            soLuongMua = 1;
            textBox2.Text = "1";

            // Reset màu nút Size
            Button[] dsButtonSize = { button12, button13, button14, button15 };
            foreach (Button b in dsButtonSize)
            {
                b.BackColor = Color.White;
                b.ForeColor = Color.Black;
            }

            // Reset màu ô Màu sắc
            Panel[] dsPanelMau = { panel3, panel4, panel5, panel6 };
            foreach (Panel p in dsPanelMau) p.BackColor = Color.Transparent;
        }

        #endregion

        // TỐI ƯU: Đọc dữ liệu ngầm dưới nền, giúp giao diện không bị đơ cứng khi tải sản phẩm
        private async void HienThiTatCaSanPham()
        {
            try
            {
                flpDanhSachSP.SuspendLayout();
                flpDanhSachSP.Controls.Clear();

                string query = "SELECT MaSP, TenSP, GiaBan, SoLuongTon, AnhSP FROM SanPham";

                DataTable dtSanPham = await Task.Run(() => {
                    return db.ExecuteQuery(query);
                });

                if (dtSanPham == null || dtSanPham.Rows.Count == 0) return;

                foreach (DataRow row in dtSanPham.Rows)
                {
                    string maSP = row["MaSP"].ToString();
                    string tenSP = row["TenSP"].ToString();
                    decimal giaBan = Convert.ToDecimal(row["GiaBan"]);
                    int soLuongTon = Convert.ToInt32(row["SoLuongTon"]);
                    string anhSP = row["AnhSP"].ToString();

                    ucProductCard card = new ucProductCard();
                    card.ThietLapThongTin(maSP, tenSP, giaBan, soLuongTon, anhSP);

                    card.SanPhamSelected += (sender, maSanPhamDuocChon) =>
                    {
                        // Khôi phục trạng thái nút chọn khi chuyển sản phẩm
                        ResetThongSoChon();

                        // Lưu thông tin vào biến toàn cục để tính toán tiền và kiểm tra tồn kho
                        giaHienTai = giaBan;
                        maxTonKho = soLuongTon;

                        // Đổ dữ liệu chi tiết
                        lblChiTietMaSP.Text = "Mã SP: " + maSanPhamDuocChon;
                        lblChiTietTenSP.Text = tenSP;
                        lblChiTietGia.Text = giaBan.ToString("#,##0") + "đ";
                        lblChiTietTon.Text = "Tồn kho: " + soLuongTon;

                        // Tính tiền lượt đầu tiên
                        CapNhatSoLuongVaTinhTien();

                        // Load ảnh sản phẩm
                        try
                        {
                            if (!string.IsNullOrEmpty(anhSP))
                            {
                                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                                pictureBox1.Load(anhSP);
                            }
                            else
                            {
                                pictureBox1.Image = null;
                                pictureBox1.BackColor = Color.LightGray;
                            }
                        }
                        catch
                        {
                            pictureBox1.Image = null;
                            pictureBox1.BackColor = Color.LightGray;
                        }
                    };

                    flpDanhSachSP.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message);
            }
            finally
            {
                flpDanhSachSP.ResumeLayout();
            }
        }

        // Sự kiện click nút THÊM VÀO GIỎ HÀNG (button18)
        private void button18_Click(object sender, EventArgs e)
        {
            if (giaHienTai == 0)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm trước!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(sizeDuocChon))
            {
                MessageBox.Show("Vui lòng chọn Size sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(mauDuocChon))
            {
                MessageBox.Show("Vui lòng chọn Màu sắc sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thực hiện hành động thêm vào Giỏ hàng tại đây (ví dụ thông báo thành công)
            string thongTinDonHang = $"Đã thêm thành công vào giỏ hàng:\n" +
                                     $"- {lblChiTietTenSP.Text}\n" +
                                     $"- Size: {sizeDuocChon} | Màu: {mauDuocChon}\n" +
                                     $"- Số lượng: {soLuongMua}\n" +
                                     $"- Tổng tiền: {textBox3.Text}";

            MessageBox.Show(thongTinDonHang, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // TODO: Viết tiếp code thêm sản phẩm này vào DataGridView giỏ hàng của bạn ở panelRight...
        }

        private void ucBanHang_Load(object sender, EventArgs e)
        {
            HienThiTatCaSanPham();
        }

        // --- CÁC HÀM CŨ ĐỂ KHÔNG BỊ LỖI DESIGNER ---
        private void label1_Click(object sender, EventArgs e) { }
        private void panelCenter_Paint(object sender, PaintEventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void button8_Click(object sender, EventArgs e) { }
        private void button7_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void panelRight_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void pnlMiddle_Paint(object sender, PaintEventArgs e) { }
        private void flpDanhSachSP_Paint(object sender, PaintEventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
    }
}