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

            // Khởi tạo tiền hóa đơn về 0 ban đầu
            GanSuKienTinhTienHoaDon();

            // Đăng ký sự kiện click chuột trực tiếp vào các ô (Nút Xóa dòng) trên lưới giỏ hàng
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }

        #region XỬ LÝ SỰ KIỆN CHỌN THÔNG SỐ (SIZE, MÀU, SỐ LƯỢNG)

        private void GanSuKienChonSize()
        {
            Button[] dsButtonSize = { button12, button13, button14, button15 };
            foreach (Button btn in dsButtonSize)
            {
                btn.Click += (s, e) =>
                {
                    foreach (Button b in dsButtonSize)
                    {
                        b.BackColor = Color.White;
                        b.ForeColor = Color.Black;
                    }
                    btn.BackColor = Color.DodgerBlue;
                    btn.ForeColor = Color.White;
                    sizeDuocChon = btn.Text;
                };
            }
        }

        private void GanSuKienChonMau()
        {
            Panel[] dsPanelMau = { panel3, panel4, panel5, panel6 };
            foreach (Panel pnl in dsPanelMau)
            {
                Label lblColorName = pnl.Controls.OfType<Label>().FirstOrDefault();
                PictureBox picCircle = pnl.Controls.OfType<PictureBox>().FirstOrDefault();

                EventHandler colorSelectEvent = (s, e) =>
                {
                    foreach (Panel p in dsPanelMau) p.BackColor = Color.Transparent;
                    pnl.BackColor = Color.LightSkyBlue;

                    if (lblColorName != null)
                    {
                        mauDuocChon = lblColorName.Text;
                    }
                };

                pnl.Click += colorSelectEvent;
                if (lblColorName != null) lblColorName.Click += colorSelectEvent;
                if (picCircle != null) picCircle.Click += colorSelectEvent;
            }
        }

        private void GanSuKienTangGiamSoLuong()
        {
            textBox2.Text = soLuongMua.ToString();
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox3.ReadOnly = true;

            button16.Click += (s, e) =>
            {
                if (soLuongMua > 1)
                {
                    soLuongMua--;
                    CapNhatSoLuongVaTinhTien();
                }
            };

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
            if (textBox2.Text != soLuongMua.ToString())
            {
                textBox2.Text = soLuongMua.ToString();
            }

            decimal thanhTien = soLuongMua * giaHienTai;
            textBox3.Text = thanhTien.ToString("#,##0") + "đ";
        }

        private void ResetThongSoChon()
        {
            sizeDuocChon = "";
            mauDuocChon = "";
            soLuongMua = 1;
            textBox2.Text = "1";

            Button[] dsButtonSize = { button12, button13, button14, button15 };
            foreach (Button b in dsButtonSize)
            {
                b.BackColor = Color.White;
                b.ForeColor = Color.Black;
            }

            Panel[] dsPanelMau = { panel3, panel4, panel5, panel6 };
            foreach (Panel p in dsPanelMau) p.BackColor = Color.Transparent;
        }

        #endregion

        // Tải danh sách sản phẩm lên FlowLayoutPanel dưới nền ngầm
        private async void HienThiTatCaSanPham()
        {
            try
            {
                flpDanhSachSP.SuspendLayout();
                flpDanhSachSP.Controls.Clear();

                string query = "SELECT MaSP, TenSP, GiaBan, SoLuongTon, AnhSP FROM SanPham";

                DataTable dtSanPham = await Task.Run(() => { return db.ExecuteQuery(query); });

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
                        ResetThongSoChon();

                        giaHienTai = giaBan;
                        maxTonKho = soLuongTon;

                        lblChiTietMaSP.Text = "Mã SP: " + maSanPhamDuocChon;
                        lblChiTietTenSP.Text = tenSP;
                        lblChiTietGia.Text = giaBan.ToString("#,##0") + "đ";
                        lblChiTietTon.Text = "Tồn kho: " + soLuongTon;

                        CapNhatSoLuongVaTinhTien();

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

        // CHỨC NĂNG CHÍNH: SỰ KIỆN CLICK NÚT THÊM VÀO GIỎ HÀNG (ĐÃ ĐỔI TÊN ĐỂ SỬA LỖI DESIGNER)
        private void button18_Click_1(object sender, EventArgs e)
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

            // Xử lý chuỗi lấy mã SP nguyên bản
            string maSP = lblChiTietMaSP.Text.Replace("Mã SP:", "").Replace("Mã SP :", "").Trim();
            string tenSP = lblChiTietTenSP.Text;
            string phanLoaiMoi = $"{sizeDuocChon} - {mauDuocChon}";

            bool isTrung = false;

            // Kiểm tra trùng: Duyệt tìm trên DataGridView theo đúng cột Chỉ số / Tên ô thiết kế
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Sử dụng vị trí index của cột để tuyệt đối chính xác, không sợ lỗi gõ sai tên ô:
                // Cột 1 (Index 1) luôn luôn là Mã Sản Phẩm theo danh sách cột bạn mới cập nhật
                if (row.Cells[1].Value == null) continue;

                string maTrongBang = row.Cells[1].Value.ToString().Trim();
                string phanLoaiTrongBang = row.Cells[3].Value?.ToString() ?? ""; // Cột 3 (Index 3): Phân Loại

                if (maTrongBang == maSP && phanLoaiTrongBang == phanLoaiMoi)
                {
                    int slHienTai = Convert.ToInt32(row.Cells[4].Value); // Cột 4 (Index 4): Số lượng
                    int slMoi = slHienTai + soLuongMua;

                    if (slMoi > maxTonKho)
                    {
                        MessageBox.Show($"Không thể thêm! Số lượng vượt quá lượng tồn kho thực tế ({maxTonKho}).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    row.Cells[4].Value = slMoi;
                    row.Cells[6].Value = slMoi * giaHienTai; // Cột 6 (Index 6): Thành Tiền
                    isTrung = true;
                    break;
                }
            }

            // Nếu sản phẩm này CHƯA CÓ trong giỏ hàng
            if (!isTrung)
            {
                int stt = dataGridView1.Rows.Count; // STT thuần túy tăng dần làm chỉ mục index
                decimal thanhTien = soLuongMua * giaHienTai;

                // Nạp mảng dữ liệu khớp 100% thứ tự 8 cột bạn tự dựng trên WinForms Designer:
                // STT(0) | Mã Sản Phẩm(1) | SanPham(2) | Phân Loại(3) | Số lượng(4) | Đơn Giá(5) | Thành Tiền(6) | Thao Tác(7)
                dataGridView1.Rows.Add(stt, maSP, tenSP, phanLoaiMoi, soLuongMua, giaHienTai, thanhTien, "Xóa");
            }

            TinhTongTienHoaDon();
        }

        #region XỬ LÝ TÍNH TOÁN TIỀN HÓA ĐƠN VÀ SỐ THỨ TỰ INDEX TỰ ĐỘNG

        private void GanSuKienTinhTienHoaDon()
        {
            txtGiamGia.Text = "0";
            txtGiamGia.TextChanged += (s, e) => TinhTongTienHoaDon();
        }

        private void TinhTongTienHoaDon()
        {
            decimal tongTienHang = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[6].Value != null) // Index 6: Thành Tiền
                {
                    tongTienHang += Convert.ToDecimal(row.Cells[6].Value);
                }
            }

            decimal giamGia = 0;
            if (!decimal.TryParse(txtGiamGia.Text, out giamGia)) { giamGia = 0; }

            decimal khachThanhToan = tongTienHang - giamGia;
            if (khachThanhToan < 0) khachThanhToan = 0;

            lblTongTienHang.Text = tongTienHang.ToString("#,##0") + "đ";
            lblTongTienGioHang.Text ="Tổng Tiền :" + tongTienHang.ToString("#,##0") + "đ";
            lblKhachThanhToan.Text = khachThanhToan.ToString("#,##0") + "đ";
        }

        // Bấm nút xóa toàn bộ giỏ hàng sạch sẽ
        private void btnXoaTatCa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa toàn bộ giỏ hàng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    dataGridView1.Rows.Clear();
                    TinhTongTienHoaDon();
                }
            }
        }

        // RE-INDEX: Sắp xếp, đánh số lại cột STT tự động chạy từ 1, 2, 3... sau khi xóa bớt hàng
        private void CapNhatLaiSTT()
        {
            int index = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Value != null) // Nếu dòng có chứa Mã sản phẩm
                {
                    row.Cells[0].Value = index; // Gán lại số thứ tự tăng dần vào cột thứ 0 (STT)
                    index++;
                }
            }
        }

        // SỰ KIỆN XÓA TỪNG MÓN HÀNG: Khi người dùng nhấn nút chữ "Xóa" ở cột cuối cùng
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem hàng được chọn có hợp lệ và cột click vào có phải là cột Thao Tác (Index số 7) không
            if (e.RowIndex >= 0 && e.ColumnIndex == 7)
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex); // Tiến hành xóa dòng này khỏi giỏ hàng
                CapNhatLaiSTT();                         // Đánh lại số thứ tự index 1, 2, 3... mượt mà
                TinhTongTienHoaDon();                    // Cập nhật lại hóa đơn tính tổng tiền
            }
        }

        #endregion

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
        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e) { }
    }
}