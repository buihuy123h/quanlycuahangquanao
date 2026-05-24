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
    public partial class FormNhapKho : Form
    {
        public FormNhapKho()
        {
            InitializeComponent();
        }
        public int SoLuongNhap { get; private set; } // Thuộc tính để lấy số lượng

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Giả sử textbox của bạn tên là txtSoLuongNhap
            if (int.TryParse(txtSoLuongNhap.Text, out int sl) && sl > 0)
            {
                SoLuongNhap = sl;
                this.DialogResult = DialogResult.OK; // Đóng Form và báo cho nút "Nhập kho" biết là OK
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ!");
            }
        }
    }
}
