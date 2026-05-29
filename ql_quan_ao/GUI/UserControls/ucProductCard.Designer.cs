namespace ql_quan_ao.GUI.UserControls
{
    partial class ucProductCard
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
            this.picAnhSP = new System.Windows.Forms.PictureBox();
            this.lblMaSP = new System.Windows.Forms.Label();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.lblGiaBan = new System.Windows.Forms.Label();
            this.lblTonKho = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhSP)).BeginInit();
            this.SuspendLayout();
            // 
            // picAnhSP
            // 
            this.picAnhSP.Dock = System.Windows.Forms.DockStyle.Top;
            this.picAnhSP.Location = new System.Drawing.Point(2, 2);
            this.picAnhSP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picAnhSP.Name = "picAnhSP";
            this.picAnhSP.Size = new System.Drawing.Size(121, 101);
            this.picAnhSP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnhSP.TabIndex = 0;
            this.picAnhSP.TabStop = false;
            this.picAnhSP.Click += new System.EventHandler(this.picAnhSP_Click);
            // 
            // lblMaSP
            // 
            this.lblMaSP.AutoSize = true;
            this.lblMaSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaSP.Location = new System.Drawing.Point(8, 109);
            this.lblMaSP.Name = "lblMaSP";
            this.lblMaSP.Size = new System.Drawing.Size(47, 15);
            this.lblMaSP.TabIndex = 1;
            this.lblMaSP.Text = "label1";
            // 
            // lblTenSP
            // 
            this.lblTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenSP.Location = new System.Drawing.Point(8, 128);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(115, 43);
            this.lblTenSP.TabIndex = 2;
            this.lblTenSP.Text = "label1";
            // 
            // lblGiaBan
            // 
            this.lblGiaBan.AutoSize = true;
            this.lblGiaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaBan.ForeColor = System.Drawing.Color.Blue;
            this.lblGiaBan.Location = new System.Drawing.Point(8, 171);
            this.lblGiaBan.Name = "lblGiaBan";
            this.lblGiaBan.Size = new System.Drawing.Size(47, 15);
            this.lblGiaBan.TabIndex = 3;
            this.lblGiaBan.Text = "label1";
            this.lblGiaBan.Click += new System.EventHandler(this.lblGiaBan_Click);
            // 
            // lblTonKho
            // 
            this.lblTonKho.AutoSize = true;
            this.lblTonKho.ForeColor = System.Drawing.Color.Red;
            this.lblTonKho.Location = new System.Drawing.Point(8, 190);
            this.lblTonKho.Name = "lblTonKho";
            this.lblTonKho.Size = new System.Drawing.Size(35, 13);
            this.lblTonKho.TabIndex = 4;
            this.lblTonKho.Text = "label1";
            this.lblTonKho.Click += new System.EventHandler(this.lblTonKho_Click);
            // 
            // ucProductCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTonKho);
            this.Controls.Add(this.lblGiaBan);
            this.Controls.Add(this.lblTenSP);
            this.Controls.Add(this.lblMaSP);
            this.Controls.Add(this.picAnhSP);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ucProductCard";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(125, 203);
            ((System.ComponentModel.ISupportInitialize)(this.picAnhSP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picAnhSP;
        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.Label lblTonKho;
    }
}
