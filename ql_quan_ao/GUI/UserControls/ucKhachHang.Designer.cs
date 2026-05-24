namespace ql_quan_ao.GUI.UserControls
{
    partial class ucKhachHang
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
            this.grDanhSachKH = new System.Windows.Forms.GroupBox();
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.btnTimKiemKhach = new System.Windows.Forms.Button();
            this.grDanhSachKH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.SuspendLayout();
            // 
            // grDanhSachKH
            // 
            this.grDanhSachKH.Controls.Add(this.dgvKhachHang);
            this.grDanhSachKH.Location = new System.Drawing.Point(3, 37);
            this.grDanhSachKH.Name = "grDanhSachKH";
            this.grDanhSachKH.Size = new System.Drawing.Size(1222, 451);
            this.grDanhSachKH.TabIndex = 0;
            this.grDanhSachKH.TabStop = false;
            this.grDanhSachKH.Text = "Thông tin khách hàng";
            // 
            // dgvKhachHang
            // 
            this.dgvKhachHang.AllowUserToAddRows = false;
            this.dgvKhachHang.AllowUserToDeleteRows = false;
            this.dgvKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhachHang.Location = new System.Drawing.Point(6, 19);
            this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.ReadOnly = true;
            this.dgvKhachHang.Size = new System.Drawing.Size(1210, 427);
            this.dgvKhachHang.TabIndex = 0;
            // 
            // btnTimKiemKhach
            // 
            this.btnTimKiemKhach.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnTimKiemKhach.Location = new System.Drawing.Point(949, 519);
            this.btnTimKiemKhach.Name = "btnTimKiemKhach";
            this.btnTimKiemKhach.Size = new System.Drawing.Size(152, 77);
            this.btnTimKiemKhach.TabIndex = 1;
            this.btnTimKiemKhach.Text = "Tìm kiếm khách";
            this.btnTimKiemKhach.UseVisualStyleBackColor = false;
            // 
            // ucKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnTimKiemKhach);
            this.Controls.Add(this.grDanhSachKH);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucKhachHang";
            this.Size = new System.Drawing.Size(1228, 630);
            this.grDanhSachKH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grDanhSachKH;
        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.Button btnTimKiemKhach;
    }
}
