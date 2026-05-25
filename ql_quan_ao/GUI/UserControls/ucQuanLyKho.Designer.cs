            namespace ql_quan_ao
    {
        partial class ucQuanLyKho
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
            this.cboMau = new System.Windows.Forms.ComboBox();
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.lblMau = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblLoai = new System.Windows.Forms.Label();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnNhapKho = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.colMaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cboMau);
            this.panel1.Controls.Add(this.cboSize);
            this.panel1.Controls.Add(this.cboLoai);
            this.panel1.Controls.Add(this.lblMau);
            this.panel1.Controls.Add(this.lblSize);
            this.panel1.Controls.Add(this.lblLoai);
            this.panel1.Controls.Add(this.lblTimKiem);
            this.panel1.Controls.Add(this.txtTimKiem);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1298, 173);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cboMau
            // 
            this.cboMau.FormattingEnabled = true;
            this.cboMau.Items.AddRange(new object[] {
            "Trắng ",
            "Đen",
            "Đỏ"});
            this.cboMau.Location = new System.Drawing.Point(879, 130);
            this.cboMau.Name = "cboMau";
            this.cboMau.Size = new System.Drawing.Size(236, 28);
            this.cboMau.TabIndex = 7;
            // 
            // cboSize
            // 
            this.cboSize.FormattingEnabled = true;
            this.cboSize.Items.AddRange(new object[] {
            "S",
            "M",
            "L",
            "XL"});
            this.cboSize.Location = new System.Drawing.Point(879, 69);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(236, 28);
            this.cboSize.TabIndex = 6;
            // 
            // cboLoai
            // 
            this.cboLoai.FormattingEnabled = true;
            this.cboLoai.Items.AddRange(new object[] {
            "DM01",
            "DM02",
            "DM03"});
            this.cboLoai.Location = new System.Drawing.Point(879, 11);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(236, 28);
            this.cboLoai.TabIndex = 5;
            // 
            // lblMau
            // 
            this.lblMau.AutoSize = true;
            this.lblMau.Location = new System.Drawing.Point(772, 130);
            this.lblMau.Name = "lblMau";
            this.lblMau.Size = new System.Drawing.Size(44, 20);
            this.lblMau.TabIndex = 4;
            this.lblMau.Text = "Màu:";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(772, 72);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(44, 20);
            this.lblSize.TabIndex = 3;
            this.lblSize.Text = "Size:";
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Location = new System.Drawing.Point(772, 11);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(43, 20);
            this.lblLoai.TabIndex = 2;
            this.lblLoai.Text = "Loại:";
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(69, 53);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(75, 20);
            this.lblTimKiem.TabIndex = 1;
            this.lblTimKiem.Text = "Tìm kiếm:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(271, 50);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(299, 26);
            this.txtTimKiem.TabIndex = 0;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(43, 207);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(167, 37);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(393, 207);
            this.btnSua.Name = "btnSua";
            this.btnSua.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSua.Size = new System.Drawing.Size(177, 37);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(753, 207);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(181, 37);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnNhapKho
            // 
            this.btnNhapKho.Location = new System.Drawing.Point(1069, 207);
            this.btnNhapKho.Name = "btnNhapKho";
            this.btnNhapKho.Size = new System.Drawing.Size(180, 37);
            this.btnNhapKho.TabIndex = 4;
            this.btnNhapKho.Text = "Nhập kho";
            this.btnNhapKho.UseVisualStyleBackColor = true;
            this.btnNhapKho.Click += new System.EventHandler(this.btnNhapKho_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 689);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1297, 150);
            this.dataGridView1.TabIndex = 5;
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSP,
            this.colTenSP,
            this.colGiaNhap,
            this.colGiaBan});
            this.dgvSanPham.Location = new System.Drawing.Point(0, 342);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.RowHeadersWidth = 62;
            this.dgvSanPham.RowTemplate.Height = 28;
            this.dgvSanPham.Size = new System.Drawing.Size(1297, 351);
            this.dgvSanPham.TabIndex = 6;
            // 
            // colMaSP
            // 
            this.colMaSP.DataPropertyName = "MaSP";
            this.colMaSP.HeaderText = "MaSP";
            this.colMaSP.MinimumWidth = 8;
            this.colMaSP.Name = "colMaSP";
            this.colMaSP.Width = 256;
            // 
            // colTenSP
            // 
            this.colTenSP.DataPropertyName = "TenSP";
            this.colTenSP.HeaderText = "TenSP";
            this.colTenSP.MinimumWidth = 8;
            this.colTenSP.Name = "colTenSP";
            this.colTenSP.Width = 256;
            // 
            // colGiaNhap
            // 
            this.colGiaNhap.DataPropertyName = "GiaNhap";
            this.colGiaNhap.HeaderText = "GiaNhap";
            this.colGiaNhap.MinimumWidth = 8;
            this.colGiaNhap.Name = "colGiaNhap";
            this.colGiaNhap.Width = 256;
            // 
            // colGiaBan
            // 
            this.colGiaBan.DataPropertyName = "GiaBan";
            this.colGiaBan.HeaderText = "GiaBan";
            this.colGiaBan.MinimumWidth = 8;
            this.colGiaBan.Name = "colGiaBan";
            this.colGiaBan.Width = 256;
            // 
            // ucQuanLyKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvSanPham);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnNhapKho);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucQuanLyKho";
            this.Size = new System.Drawing.Size(1297, 839);
            this.Load += new System.EventHandler(this.ucQuanLyKho_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.ResumeLayout(false);

            }

            #endregion

            private System.Windows.Forms.Panel panel1;
            private System.Windows.Forms.Button btnThem;
            private System.Windows.Forms.Button btnSua;
            private System.Windows.Forms.Button btnXoa;
            private System.Windows.Forms.Button btnNhapKho;
            private System.Windows.Forms.DataGridView dataGridView1;
            private System.Windows.Forms.DataGridView dgvSanPham;
            private System.Windows.Forms.DataGridViewTextBoxColumn colMaSP;
            private System.Windows.Forms.DataGridViewTextBoxColumn colTenSP;
            private System.Windows.Forms.DataGridViewTextBoxColumn colGiaNhap;
            private System.Windows.Forms.DataGridViewTextBoxColumn colGiaBan;
            private System.Windows.Forms.Label lblTimKiem;
            private System.Windows.Forms.TextBox txtTimKiem;
            private System.Windows.Forms.Label lblSize;
            private System.Windows.Forms.Label lblLoai;
            private System.Windows.Forms.Label lblMau;
            private System.Windows.Forms.ComboBox cboMau;
            private System.Windows.Forms.ComboBox cboSize;
            private System.Windows.Forms.ComboBox cboLoai;
        }
    }
