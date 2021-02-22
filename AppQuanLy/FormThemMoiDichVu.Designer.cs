namespace AppQuanLy
{
    partial class FormThemMoiDichVu
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
            this.buttonThemMoiLoaiHang = new System.Windows.Forms.Button();
            this.txtThemMoi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtidDichVu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonThemMoiLoaiHang
            // 
            this.buttonThemMoiLoaiHang.Location = new System.Drawing.Point(317, 12);
            this.buttonThemMoiLoaiHang.Name = "buttonThemMoiLoaiHang";
            this.buttonThemMoiLoaiHang.Size = new System.Drawing.Size(93, 57);
            this.buttonThemMoiLoaiHang.TabIndex = 11;
            this.buttonThemMoiLoaiHang.Text = "Thêm Mới";
            this.buttonThemMoiLoaiHang.UseVisualStyleBackColor = true;
            this.buttonThemMoiLoaiHang.Click += new System.EventHandler(this.buttonThemMoiLoaiHang_Click);
            // 
            // txtThemMoi
            // 
            this.txtThemMoi.Location = new System.Drawing.Point(118, 49);
            this.txtThemMoi.Name = "txtThemMoi";
            this.txtThemMoi.Size = new System.Drawing.Size(154, 20);
            this.txtThemMoi.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tên Dịch Vụ Mới : ";
            // 
            // txtidDichVu
            // 
            this.txtidDichVu.Location = new System.Drawing.Point(118, 12);
            this.txtidDichVu.Name = "txtidDichVu";
            this.txtidDichVu.Size = new System.Drawing.Size(154, 20);
            this.txtidDichVu.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Mã Dịch Vụ Mới : ";
            // 
            // FormThemMoiDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 105);
            this.Controls.Add(this.txtidDichVu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonThemMoiLoaiHang);
            this.Controls.Add(this.txtThemMoi);
            this.Controls.Add(this.label1);
            this.Name = "FormThemMoiDichVu";
            this.Text = "FormThemMoiDichVu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormThemMoiDichVu_FormClosing);
            this.Load += new System.EventHandler(this.FormThemMoiDichVu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonThemMoiLoaiHang;
        private System.Windows.Forms.TextBox txtThemMoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtidDichVu;
        private System.Windows.Forms.Label label2;
    }
}