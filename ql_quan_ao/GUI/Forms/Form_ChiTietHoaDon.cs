using QuanLyCuaHang.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ql_quan_ao.GUI.Forms
{
    public partial class Form_ChiTietHoaDon : Form
    {
        string _maHD;

        // Constructor nhận mã hóa đơn
        public Form_ChiTietHoaDon(string maHD)
        {
            InitializeComponent();
            _maHD = maHD;
        }

        private void Form_ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            // Kiểm tra biến _maHD có giá trị hay không
            if (string.IsNullOrEmpty(_maHD)) return;

            // Câu lệnh SQL "trần trụi" để kiểm tra
            string sql = "SELECT * FROM ChiTietHoaDon WHERE MaHD = '" + _maHD + "'";

            // Gọi thực thi
            DataTable dt = DataProvider.Instance.ExecuteQuery(sql);

            // BÁO CÁO KẾT QUẢ ĐỂ CHÚNG TA BIẾT LỖI Ở ĐÂU
            MessageBox.Show("Số dòng lấy được từ CSDL: " + dt.Rows.Count);

            if (dt.Rows.Count > 0)
            {
                dgvDanhSach.DataSource = dt;
            }
        }
    }
}

