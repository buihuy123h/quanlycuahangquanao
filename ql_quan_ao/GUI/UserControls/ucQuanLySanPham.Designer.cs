namespace ql_quan_ao.GUI.UserControls
{
    partial class ucQuanLySanPham
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
            this.lblMSP = new System.Windows.Forms.Label();
            this.lblTSP = new System.Windows.Forms.Label();
            this.lblLSP = new System.Windows.Forms.Label();
            this.lblGia = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.grThongTinSP = new System.Windows.Forms.GroupBox();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.colMSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grThongTinSP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMSP
            // 
            this.lblMSP.AutoSize = true;
            this.lblMSP.Location = new System.Drawing.Point(138, 32);
            this.lblMSP.Name = "lblMSP";
            this.lblMSP.Size = new System.Drawing.Size(39, 13);
            this.lblMSP.TabIndex = 0;
            this.lblMSP.Text = "Mã SP";
            // 
            // lblTSP
            // 
            this.lblTSP.AutoSize = true;
            this.lblTSP.Location = new System.Drawing.Point(134, 80);
            this.lblTSP.Name = "lblTSP";
            this.lblTSP.Size = new System.Drawing.Size(43, 13);
            this.lblTSP.TabIndex = 1;
            this.lblTSP.Text = "Tên SP";
            // 
            // lblLSP
            // 
            this.lblLSP.AutoSize = true;
            this.lblLSP.Location = new System.Drawing.Point(718, 32);
            this.lblLSP.Name = "lblLSP";
            this.lblLSP.Size = new System.Drawing.Size(44, 13);
            this.lblLSP.TabIndex = 2;
            this.lblLSP.Text = "Loại SP";
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Location = new System.Drawing.Point(718, 80);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(44, 13);
            this.lblGia.TabIndex = 3;
            this.lblGia.Text = "Giá bán";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(217, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(159, 20);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(217, 73);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(159, 20);
            this.textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(814, 77);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(166, 20);
            this.textBox3.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Quần",
            "Áo",
            "Váy"});
            this.comboBox1.Location = new System.Drawing.Point(814, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(166, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // grThongTinSP
            // 
            this.grThongTinSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grThongTinSP.Controls.Add(this.dgvSanPham);
            this.grThongTinSP.Location = new System.Drawing.Point(3, 152);
            this.grThongTinSP.Name = "grThongTinSP";
            this.grThongTinSP.Size = new System.Drawing.Size(1225, 328);
            this.grThongTinSP.TabIndex = 8;
            this.grThongTinSP.TabStop = false;
            this.grThongTinSP.Text = "Thông tin sản phẩm";
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AllowUserToAddRows = false;
            this.dgvSanPham.AllowUserToDeleteRows = false;
            this.dgvSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMSP,
            this.colTSP,
            this.colLSP,
            this.colGiaBan});
            this.dgvSanPham.Location = new System.Drawing.Point(6, 19);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.Size = new System.Drawing.Size(1213, 303);
            this.dgvSanPham.TabIndex = 0;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnThem.Location = new System.Drawing.Point(122, 511);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(128, 70);
            this.btnThem.TabIndex = 9;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSua.Location = new System.Drawing.Point(417, 511);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(128, 70);
            this.btnSua.TabIndex = 10;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnXoa.Location = new System.Drawing.Point(721, 511);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(128, 70);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLamMoi.Location = new System.Drawing.Point(997, 511);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(128, 70);
            this.btnLamMoi.TabIndex = 12;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // colMSP
            // 
            this.colMSP.HeaderText = "Mã SP";
            this.colMSP.Name = "colMSP";
            this.colMSP.ReadOnly = true;
            // 
            // colTSP
            // 
            this.colTSP.HeaderText = "Tên SP";
            this.colTSP.Name = "colTSP";
            this.colTSP.ReadOnly = true;
            // 
            // colLSP
            // 
            this.colLSP.HeaderText = "Loại SP";
            this.colLSP.Name = "colLSP";
            this.colLSP.ReadOnly = true;
            // 
            // colGiaBan
            // 
            this.colGiaBan.HeaderText = "Giá bán";
            this.colGiaBan.Name = "colGiaBan";
            this.colGiaBan.ReadOnly = true;
            // 
            // ucQuanLySanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.grThongTinSP);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblGia);
            this.Controls.Add(this.lblLSP);
            this.Controls.Add(this.lblTSP);
            this.Controls.Add(this.lblMSP);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ucQuanLySanPham";
            this.Size = new System.Drawing.Size(1228, 630);
            this.grThongTinSP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMSP;
        private System.Windows.Forms.Label lblTSP;
        private System.Windows.Forms.Label lblLSP;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox grThongTinSP;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaBan;
    }
}
