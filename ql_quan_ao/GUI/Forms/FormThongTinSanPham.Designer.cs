namespace ql_quan_ao
{
    public partial class FormThongTinSanPham
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblMaSP = new System.Windows.Forms.Label();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.MaskedTextBox();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblMau = new System.Windows.Forms.Label();
            this.cboMaDM = new System.Windows.Forms.ComboBox();
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.cboMau = new System.Windows.Forms.ComboBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.lblGiaBan = new System.Windows.Forms.Label();
            this.txtGiaBan = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // lblMaSP
            // 
            this.lblMaSP.AutoSize = true;
            this.lblMaSP.Location = new System.Drawing.Point(60, 45);
            this.lblMaSP.Name = "lblMaSP";
            this.lblMaSP.Size = new System.Drawing.Size(60, 20);
            this.lblMaSP.TabIndex = 0;
            this.lblMaSP.Text = "Mã SP:";
            // 
            // lblTenSP
            // 
            this.lblTenSP.AutoSize = true;
            this.lblTenSP.Location = new System.Drawing.Point(60, 131);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(65, 20);
            this.lblTenSP.TabIndex = 1;
            this.lblTenSP.Text = "Tên SP:";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(164, 45);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(170, 26);
            this.txtMaSP.TabIndex = 2;
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(164, 131);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(170, 26);
            this.txtTenSP.TabIndex = 3;
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Location = new System.Drawing.Point(463, 45);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(60, 20);
            this.lblLoai.TabIndex = 4;
            this.lblLoai.Text = "MaDM:";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(463, 112);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(44, 20);
            this.lblSize.TabIndex = 5;
            this.lblSize.Text = "Size:";
            // 
            // lblMau
            // 
            this.lblMau.AutoSize = true;
            this.lblMau.Location = new System.Drawing.Point(463, 182);
            this.lblMau.Name = "lblMau";
            this.lblMau.Size = new System.Drawing.Size(44, 20);
            this.lblMau.TabIndex = 6;
            this.lblMau.Text = "Màu:";
            // 
            // cboMaDM
            // 
            this.cboMaDM.FormattingEnabled = true;
            this.cboMaDM.Location = new System.Drawing.Point(557, 43);
            this.cboMaDM.Name = "cboMaDM";
            this.cboMaDM.Size = new System.Drawing.Size(170, 28);
            this.cboMaDM.TabIndex = 7;
            // 
            // cboSize
            // 
            this.cboSize.FormattingEnabled = true;
            this.cboSize.Location = new System.Drawing.Point(557, 112);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(170, 28);
            this.cboSize.TabIndex = 9;
            // 
            // cboMau
            // 
            this.cboMau.FormattingEnabled = true;
            this.cboMau.Location = new System.Drawing.Point(557, 182);
            this.cboMau.Name = "cboMau";
            this.cboMau.Size = new System.Drawing.Size(170, 28);
            this.cboMau.TabIndex = 10;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(485, 337);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(118, 68);
            this.btnLuu.TabIndex = 11;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(656, 337);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(115, 68);
            this.btnHuy.TabIndex = 12;
            this.btnHuy.Text = "Huỷ";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // lblGiaBan
            // 
            this.lblGiaBan.AutoSize = true;
            this.lblGiaBan.Location = new System.Drawing.Point(60, 218);
            this.lblGiaBan.Name = "lblGiaBan";
            this.lblGiaBan.Size = new System.Drawing.Size(69, 20);
            this.lblGiaBan.TabIndex = 13;
            this.lblGiaBan.Text = "Giá bán:";
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(164, 218);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(170, 26);
            this.txtGiaBan.TabIndex = 14;
            // 
            
            // 
            // FormThongTinSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtGiaBan);
            this.Controls.Add(this.lblGiaBan);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.cboMau);
            this.Controls.Add(this.cboSize);
            this.Controls.Add(this.cboMaDM);
            this.Controls.Add(this.lblMau);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblLoai);
            this.Controls.Add(this.txtTenSP);
            this.Controls.Add(this.txtMaSP);
            this.Controls.Add(this.lblTenSP);
            this.Controls.Add(this.lblMaSP);
            this.Name = "FormThongTinSanPham";
            this.Text = "FormThongTinSanPham";
            this.Load += new System.EventHandler(this.FormThongTinSanPham_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.MaskedTextBox txtMaSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblMau;
        private System.Windows.Forms.ComboBox cboMaDM;
        private System.Windows.Forms.ComboBox cboSize;
        private System.Windows.Forms.ComboBox cboMau;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.MaskedTextBox txtGiaBan;
    }
}