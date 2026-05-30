using BUS;
using DAL;
using ql_quan_ao.BUS;
using ql_quan_ao.DAL;
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
    public partial class ucBanHang : UserControl
    {
        DatabaseConnect db = new DatabaseConnect();
        SanPhamDAL sanPhamDAL = new SanPhamDAL();

        // --- THÊM DÒNG NÀY ĐỂ ĐẠI DIỆN CHO TẦNG BUS ---
        private SanPhamBUS sanPhamBUS = new SanPhamBUS();

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

            // Khởi tạo tiền hóa đơn về 0 ban đầu và gán sự kiện TextChanged cho ô giảm giá
            GanSuKienTinhTienHoaDon();

            // Đăng ký sự kiện click chuột trực tiếp vào các ô (Nút Xóa dòng) trên lưới giỏ hàng
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;

            // Đảm bảo ô hiển thị tiền "Khách cần trả" không bị gõ đè bằng tay làm sai logic
            txtTien.ReadOnly = true;
        }

        #region XỬ LÝ SỰ KIỆN CHỌN THÔNG SỐ (SIZE, MÀU, SỐ LƯỢNG)

        private void GanSuKienChonSize()
        {
            Button[] dsButtonSize = { btnSizeS, btnSizeM, btnSizeL, btnSizeXL };
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
            txtSoLuong.Text = soLuongMua.ToString();
            txtSoLuong.TextAlign = HorizontalAlignment.Center;
            txtThanhTien.ReadOnly = true;

            btnGiamSoLuong.Click += (s, e) =>
            {
                if (soLuongMua > 1)
                {
                    soLuongMua--;
                    CapNhatSoLuongVaTinhTien();
                }
            };

            btnTangSoLuong.Click += (s, e) =>
            {
                if (soLuongMua < maxTonKho)
                {
                    soLuongMua++;
                    CapNhatSoLuongVaTinhTien();
                }
                else
                {
                    MessageBox.Show($"Sản phẩm này chỉ còn tối đa {maxTonKho} sản phẩm trong kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            txtSoLuong.TextChanged += (s, e) =>
            {
                if (int.TryParse(txtSoLuong.Text, out int result))
                {
                    if (result < 1) soLuongMua = 1;
                    else if (result > maxTonKho && maxTonKho > 0)
                    {
                        MessageBox.Show($"Số lượng vượt quá tồn kho ({maxTonKho})!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (txtSoLuong.Text != soLuongMua.ToString())
            {
                txtSoLuong.Text = soLuongMua.ToString();
            }

            decimal thanhTien = soLuongMua * giaHienTai;
            txtThanhTien.Text = thanhTien.ToString("#,##0") + "đ";
        }

        private void ResetThongSoChon()
        {
            sizeDuocChon = "";
            mauDuocChon = "";
            soLuongMua = 1;
            txtSoLuong.Text = "1";

            Button[] dsButtonSize = { btnSizeS, btnSizeM, btnSizeL, btnSizeXL };
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
                                picAnhSPChiTiet.SizeMode = PictureBoxSizeMode.Zoom;
                                picAnhSPChiTiet.Load(anhSP);
                            }
                            else
                            {
                                picAnhSPChiTiet.Image = null;
                                picAnhSPChiTiet.BackColor = Color.LightGray;
                            }
                        }
                        catch
                        {
                            picAnhSPChiTiet.Image = null;
                            picAnhSPChiTiet.BackColor = Color.LightGray;
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

        // CHỨC NĂNG CHÍNH: SỰ KIỆN CLICK NÚT THÊM VÀO GIỎ HÀNG
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

            // Kiểm tra trùng: Duyệt tìm trên DataGridView theo chỉ số cột chính xác
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
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

            // Nếu sản phẩm này CHƯA CÓ trong giỏ hàng thì nạp đủ 8 cột
            if (!isTrung)
            {
                int stt = dataGridView1.Rows.Count + 1;
                decimal thanhTien = soLuongMua * giaHienTai;

                // Nạp mảng khớp 100% thứ tự cấu trúc 8 cột trên giao diện:
                // STT(0) | Mã Sản Phẩm(1) | SanPham(2) | Phân Loại(3) | Số lượng(4) | Đơn Giá(5) | Thành Tiền(6) | Thao Tác(7)
                dataGridView1.Rows.Add(stt, maSP, tenSP, phanLoaiMoi, soLuongMua, giaHienTai, thanhTien, "Xóa");
            }

            // Tính toán lại toàn bộ tiền ngay sau khi thêm đồ mới
            TinhTongTienHoaDon();
        }

        #region XỬ LÝ TÍNH TOÁN TIỀN HÓA ĐƠN VÀ SỐ THỨ TỰ INDEX TỰ ĐỘNG

        private void GanSuKienTinhTienHoaDon()
        {
            txtGiamGia.Text = "0";
            // Kích hoạt tính tiền tự động bất cứ khi nào chữ trong ô giảm giá biến đổi
            txtGiamGia.TextChanged += (s, e) => TinhTongTienHoaDon();
        }

        private void TinhTongTienHoaDon()
        {
            decimal tongTienHang = 0;

            // 1. Quét qua giỏ hàng tính tổng tiền
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[6].Value != null) // Index 6 luôn luôn là cột Thành Tiền
                {
                    tongTienHang += Convert.ToDecimal(row.Cells[6].Value);
                }
            }

            // 2. Ép kiểu đọc số tiền giảm giá
            decimal giamGia = 0;
            if (!decimal.TryParse(txtGiamGia.Text, out giamGia))
            {
                giamGia = 0;
            }

            // Chặn lỗi logic: Giảm giá không được âm hoặc vượt quá tổng tiền hàng
            if (giamGia < 0) giamGia = 0;
            if (giamGia > tongTienHang) giamGia = tongTienHang;

            // 3. Tính toán tiền thực trả
            decimal khachThanhToan = tongTienHang - giamGia;

            // 4. Đẩy chuỗi định dạng tiền tệ lên các Label và TextBox thích hợp
            txtTongTienHang.Text = tongTienHang.ToString("#,##0") + "đ";
            lblTongTienHang.Text = tongTienHang.ToString("#,##0") + "đ";
            lblTongTienGioHang.Text = "Tổng Tiền :" + tongTienHang.ToString("#,##0") + "đ";

            // Đổ số tiền cuối cùng cần trả vào ô hiển thị kết quả
            txtTien.Text = khachThanhToan.ToString("#,##0") + "đ";
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
                if (row.Cells[1].Value != null)
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
        private bool KiemTraSDTVietNam(string sdt)
        {
            if (string.IsNullOrEmpty(sdt)) return false;

            // Biểu thức chính quy Regex quét các đầu số di động phổ biến tại VN
            string pattern = @"^(03|05|07|08|09)\d{8}$";

            return System.Text.RegularExpressions.Regex.IsMatch(sdt, pattern);
        }

        // --- CÁC HÀM CŨ ĐỂ KHÔNG BỊ LỖI DESIGNER ---
        private void label1_Click(object sender, EventArgs e) { }
        private void panelCenter_Paint(object sender, PaintEventArgs e) { }
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
        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem giỏ hàng có hàng chưa
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống! Vui lòng thêm sản phẩm trước khi thanh toán.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Lấy thông tin SĐT người dùng nhập (txtSDT)
            string sdtKhachHang = txtSDT.Text.Trim();

            // Nếu người dùng có nhập SĐT thì bắt buộc phải nhập ĐÚNG ĐỊNH DẠNG
            if (!string.IsNullOrEmpty(sdtKhachHang))
            {
                if (!KiemTraSDTVietNam(sdtKhachHang))
                {
                    MessageBox.Show("Số điện thoại không đúng định dạng Việt Nam! (Phải gồm 10 số và bắt đầu bằng đầu số 03, 05, 07, 08, 09).",
                                    "Sai định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSDT.Focus(); // Đưa con trỏ chuột quay lại ô SĐT để người dùng sửa
                    return;
                }
            }
            // Trường hợp nếu bạn muốn bắt buộc PHẢI NHẬP SĐT (không cho để trống) thì dùng đoạn này:
            /*
            else
            {
                MessageBox.Show("Vui lòng nhập số điện thoại khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }
            */

            // 3. Kiểm tra xem đã chọn phương thức thanh toán chưa (radTienMat, radChuyenKhoan, radioTheNganHang)
            string phuongThuc = "";
            if (radTienMat.Checked) phuongThuc = "Tiền mặt";
            else if (radChuyenKhoan.Checked) phuongThuc = "Chuyển khoản";
            else if (radioTheNganHang.Checked) phuongThuc = "Thẻ ngân hàng";
            else
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Nếu vượt qua tất cả các bước kiểm tra (Validation) ở trên -> Thông báo thành công và hiển thị dữ liệu đã nhận
            string thongTinXacNhan = $"=== THÔNG TIN ĐƠN HÀNG ===\n\n" +
                                     $"- Khách hàng: {(string.IsNullOrEmpty(txtTenKH.Text) ? "Khách vãng lai" : txtTenKH.Text.Trim())}\n" +
                                     $"- SĐT: {(string.IsNullOrEmpty(sdtKhachHang) ? "Không có" : sdtKhachHang)}\n" +
                                     $"- Tổng tiền: {txtTongTienHang.Text}\n" +
                                     $"- Giảm giá: {txtGiamGia.Text} đ\n" +
                                     $"- Khách cần trả: {txtTien.Text}\n" +
                                     $"- Phương thức: {phuongThuc}\n\n" +
                                     $"[Hệ thống]: Xác nhận dữ liệu hợp lệ! Bạn có muốn hoàn tất thanh toán và xuất hóa đơn không?";

            DialogResult result = MessageBox.Show(thongTinXacNhan, "Kiểm tra dữ liệu thành công",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                // KHÚC NÀY: Nơi bạn gọi hàm xuống Database để lưu Hóa đơn (Ví dụ: HoaDonBLL.LuuHoaDon...)
                // Sau khi lưu DB thành công thì xóa giỏ hàng:

                MessageBox.Show("Thanh toán thành công! Đã lưu hóa đơn vào hệ thống.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dataGridView1.Rows.Clear(); // Xóa sạch giỏ hàng
                txtGiamGia.Text = "0";      // Reset giảm giá
                txtSDT.Clear();
                txtTenKH.Clear();
                txtDiaChi.Clear();
                txtGhiChu.Clear();
            }
        }

        private void lblChiTietGia_Click(object sender, EventArgs e)
        {

        }

        private void lblChiTietTenSP_Click(object sender, EventArgs e)
        {

        }

        private void lblChiTietMaSP_Click(object sender, EventArgs e)
        {

        }

        private void lblGhiChu_Click(object sender, EventArgs e)
        {

        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTongTienHang_Click(object sender, EventArgs e)
        {

        }

        private void lblSDT_Click(object sender, EventArgs e)
        {

        }

        public async Task sulylaysanphamtheoloai(string MaDM)
        {
            try
            {
                flpDanhSachSP.SuspendLayout();
                flpDanhSachSP.Controls.Clear(); // Xóa sạch các card sản phẩm cũ trước đó

                // GỌI QUA TẦNG BUS: Lấy danh sách sản phẩm có phân loại là "Áo"
                // Sử dụng await giúp ứng dụng chạy mượt dưới nền ngầm, không gây đơ UI
                DataTable dtSanPham = await sanPhamBUS.GetSanPhamTheoLoaiBUS(MaDM);

                if (dtSanPham == null || dtSanPham.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Duyệt qua từng dòng dữ liệu đổ về để dựng UserControl Card
                foreach (DataRow row in dtSanPham.Rows)
                {
                    string maSP = row["MaSP"].ToString();
                    string tenSP = row["TenSP"].ToString();
                    decimal giaBan = Convert.ToDecimal(row["GiaBan"]);
                    int soLuongTon = Convert.ToInt32(row["SoLuongTon"]);
                    string anhSP = row["AnhSP"].ToString();

                    ucProductCard card = new ucProductCard();
                    card.ThietLapThongTin(maSP, tenSP, giaBan, soLuongTon, anhSP);

                    // Gán sự kiện click chọn sản phẩm hiển thị chi tiết bên cánh phải (Giữ nguyên logic của bạn)
                    card.SanPhamSelected += (senderCard, maSanPhamDuocChon) =>
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
                                picAnhSPChiTiet.SizeMode = PictureBoxSizeMode.Zoom;
                                picAnhSPChiTiet.Load(anhSP);
                            }
                            else
                            {
                                picAnhSPChiTiet.Image = null;
                                picAnhSPChiTiet.BackColor = Color.LightGray;
                            }
                        }
                        catch
                        {
                            picAnhSPChiTiet.Image = null;
                            picAnhSPChiTiet.BackColor = Color.LightGray;
                        }
                    };

                    // Đưa card áo vừa tạo vào danh sách hiển thị công khai
                    flpDanhSachSP.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sản phẩm nhóm Áo: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                flpDanhSachSP.ResumeLayout();
            }
        }
        private async void btnAo_Click(object sender, EventArgs e)
        {
            await sulylaysanphamtheoloai("DM01");
        }

        private async void btnQuan_Click(object sender, EventArgs e)
        {
            await sulylaysanphamtheoloai("DM02");
        }

        private async void btnVay_Click(object sender, EventArgs e)
        {
            await sulylaysanphamtheoloai("DM03");
        }

        private async void btnPhuKien_Click(object sender, EventArgs e)
        {
            await sulylaysanphamtheoloai("DM04");
        }

        private void btn_lay_tat_ca_SP(object sender, EventArgs e)
        {
            HienThiTatCaSanPham();
        }

        private async void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            string tuKhoa = txt.Text.Trim();
            try
            {
                flpDanhSachSP.SuspendLayout();
                flpDanhSachSP.Controls.Clear(); // Xóa sạch các card sản phẩm cũ trước đó

                // GỌI QUA TẦNG BUS: Lấy danh sách sản phẩm có phân loại là "Áo"
                // Sử dụng await giúp ứng dụng chạy mượt dưới nền ngầm, không gây đơ UI
                DataTable dtSanPham = await sanPhamBUS.GetSanPhamTheoTenBUS(tuKhoa);

                if (dtSanPham == null || dtSanPham.Rows.Count == 0)
                {
                    MessageBox.Show($"Không tìm thấy sản phẩm '{tuKhoa}'", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Duyệt qua từng dòng dữ liệu đổ về để dựng UserControl Card
                foreach (DataRow row in dtSanPham.Rows)
                {
                    string maSP = row["MaSP"].ToString();
                    string tenSP = row["TenSP"].ToString();
                    decimal giaBan = Convert.ToDecimal(row["GiaBan"]);
                    int soLuongTon = Convert.ToInt32(row["SoLuongTon"]);
                    string anhSP = row["AnhSP"].ToString();

                    ucProductCard card = new ucProductCard();
                    card.ThietLapThongTin(maSP, tenSP, giaBan, soLuongTon, anhSP);

                    // Gán sự kiện click chọn sản phẩm hiển thị chi tiết bên cánh phải (Giữ nguyên logic của bạn)
                    card.SanPhamSelected += (senderCard, maSanPhamDuocChon) =>
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
                                picAnhSPChiTiet.SizeMode = PictureBoxSizeMode.Zoom;
                                picAnhSPChiTiet.Load(anhSP);
                            }
                            else
                            {
                                picAnhSPChiTiet.Image = null;
                                picAnhSPChiTiet.BackColor = Color.LightGray;
                            }
                        }
                        catch
                        {
                            picAnhSPChiTiet.Image = null;
                            picAnhSPChiTiet.BackColor = Color.LightGray;
                        }
                    };

                    // Đưa card áo vừa tạo vào danh sách hiển thị công khai
                    flpDanhSachSP.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không tìm thấy sản phẩm" + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                flpDanhSachSP.ResumeLayout();
            }
        }

        private void txtTimKiem_enter(object sender, EventArgs e)
        {
            if(txtTimKiem.Text == "Tìm kiếm sản phẩm...")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            };
        }

        private void txtTimKiem_leave(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                txtTimKiem.Text = "Tìm kiếm sản phẩm...";
                txtTimKiem.ForeColor = Color.Gray;
            }
            ;
        }
    }
}