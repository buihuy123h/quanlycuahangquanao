namespace ql_quan_ao.GUI.UserControls
{
    partial class ucLichSuBanHang
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dgvLichSuBanHang = new System.Windows.Forms.DataGridView();
            this.colMaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuBanHang)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.lblDenNgay);
            this.panel1.Controls.Add(this.lblTuNgay);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1177, 196);
            this.panel1.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(827, 49);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(139, 56);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(179, 116);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(240, 22);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(179, 32);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(240, 22);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(83, 116);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(67, 16);
            this.lblDenNgay.TabIndex = 1;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(83, 32);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(59, 16);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // dgvLichSuBanHang
            // 
            this.dgvLichSuBanHang.AllowUserToAddRows = false;
            this.dgvLichSuBanHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSuBanHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSuBanHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaHD,
            this.colNgayLap,
            this.colTenKH,
            this.colTongTien,
            this.colTrangThai});
            this.dgvLichSuBanHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichSuBanHang.Location = new System.Drawing.Point(0, 196);
            this.dgvLichSuBanHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvLichSuBanHang.Name = "dgvLichSuBanHang";
            this.dgvLichSuBanHang.RowHeadersWidth = 62;
            this.dgvLichSuBanHang.RowTemplate.Height = 28;
            this.dgvLichSuBanHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichSuBanHang.Size = new System.Drawing.Size(1177, 481);
            this.dgvLichSuBanHang.TabIndex = 1;
            // 
            // colMaHD
            // 
            this.colMaHD.HeaderText = "Mã Hoá Đơn";
            this.colMaHD.MinimumWidth = 8;
            this.colMaHD.Name = "colMaHD";
            // 
            // colNgayLap
            // 
            this.colNgayLap.HeaderText = "Ngày Lập";
            this.colNgayLap.MinimumWidth = 8;
            this.colNgayLap.Name = "colNgayLap";
            // 
            // colTenKH
            // 
            this.colTenKH.HeaderText = "Tên Khách Hàng";
            this.colTenKH.MinimumWidth = 8;
            this.colTenKH.Name = "colTenKH";
            // 
            // colTongTien
            // 
            this.colTongTien.HeaderText = "Tổng tiền";
            this.colTongTien.MinimumWidth = 8;
            this.colTongTien.Name = "colTongTien";
            // 
            // colTrangThai
            // 
            this.colTrangThai.HeaderText = "Trạng Thái";
            this.colTrangThai.MinimumWidth = 8;
            this.colTrangThai.Name = "colTrangThai";
            // 
            // ucLichSuBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvLichSuBanHang);
            this.Controls.Add(this.panel1);
            this.Name = "ucLichSuBanHang";
            this.Size = new System.Drawing.Size(1177, 677);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuBanHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvLichSuBanHang;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
    }
}