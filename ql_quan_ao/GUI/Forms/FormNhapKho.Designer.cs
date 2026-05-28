namespace ql_quan_ao.GUI.UserControls
{
    partial class FormNhapKho
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
            this.lblNhapSoLuong = new System.Windows.Forms.Label();
            this.txtSoLuongNhap = new System.Windows.Forms.TextBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNhapSoLuong
            // 
            this.lblNhapSoLuong.AutoSize = true;
            this.lblNhapSoLuong.Location = new System.Drawing.Point(61, 82);
            this.lblNhapSoLuong.Name = "lblNhapSoLuong";
            this.lblNhapSoLuong.Size = new System.Drawing.Size(115, 20);
            this.lblNhapSoLuong.TabIndex = 0;
            this.lblNhapSoLuong.Text = "Nhập số lượng:";
            // 
            // txtSoLuongNhap
            // 
            this.txtSoLuongNhap.Location = new System.Drawing.Point(278, 79);
            this.txtSoLuongNhap.Name = "txtSoLuongNhap";
            this.txtSoLuongNhap.Size = new System.Drawing.Size(315, 26);
            this.txtSoLuongNhap.TabIndex = 1;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(65, 197);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(111, 57);
            this.btnXacNhan.TabIndex = 2;
            this.btnXacNhan.Text = "Xác nhận ";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // FormNhapKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.txtSoLuongNhap);
            this.Controls.Add(this.lblNhapSoLuong);
            this.Name = "FormNhapKho";
            this.Text = "FormNhapKho";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNhapSoLuong;
        private System.Windows.Forms.TextBox txtSoLuongNhap;
        private System.Windows.Forms.Button btnXacNhan;
    }
}