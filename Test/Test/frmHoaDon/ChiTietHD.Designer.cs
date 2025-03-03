
namespace Test.frmHoaDon
{
    partial class ChiTietHD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChiTietHD));
            this.label1 = new System.Windows.Forms.Label();
            this.lbMaHD = new System.Windows.Forms.Label();
            this.lbKhachHang = new System.Windows.Forms.Label();
            this.lbNgayLap = new System.Windows.Forms.Label();
            this.lbPhuongThucTT = new System.Windows.Forms.Label();
            this.lbSoDienThoai = new System.Windows.Forms.Label();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.lbTongTienHang = new System.Windows.Forms.Label();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.lbTienChu = new System.Windows.Forms.Label();
            this.lbFooter = new System.Windows.Forms.Label();
            this.lbDiaChi = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbGhiChu = new System.Windows.Forms.Label();
            this.btnMinimun = new System.Windows.Forms.Button();
            this.btnMaximun = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnInHD = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(0, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(931, 76);
            this.label1.TabIndex = 0;
            this.label1.Text = "HÓA ĐƠN MUA HÀNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMaHD
            // 
            this.lbMaHD.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbMaHD.Location = new System.Drawing.Point(8, 95);
            this.lbMaHD.Name = "lbMaHD";
            this.lbMaHD.Size = new System.Drawing.Size(923, 21);
            this.lbMaHD.TabIndex = 1;
            this.lbMaHD.Text = "Mã hóa đơn: ";
            this.lbMaHD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbKhachHang
            // 
            this.lbKhachHang.AutoSize = true;
            this.lbKhachHang.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbKhachHang.Location = new System.Drawing.Point(118, 160);
            this.lbKhachHang.Name = "lbKhachHang";
            this.lbKhachHang.Size = new System.Drawing.Size(109, 21);
            this.lbKhachHang.TabIndex = 1;
            this.lbKhachHang.Text = "Khách hàng:";
            // 
            // lbNgayLap
            // 
            this.lbNgayLap.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbNgayLap.Location = new System.Drawing.Point(8, 127);
            this.lbNgayLap.Name = "lbNgayLap";
            this.lbNgayLap.Size = new System.Drawing.Size(914, 21);
            this.lbNgayLap.TabIndex = 1;
            this.lbNgayLap.Text = "Ngày lập: ";
            this.lbNgayLap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPhuongThucTT
            // 
            this.lbPhuongThucTT.AutoSize = true;
            this.lbPhuongThucTT.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbPhuongThucTT.Location = new System.Drawing.Point(465, 561);
            this.lbPhuongThucTT.Name = "lbPhuongThucTT";
            this.lbPhuongThucTT.Size = new System.Drawing.Size(217, 21);
            this.lbPhuongThucTT.TabIndex = 1;
            this.lbPhuongThucTT.Text = "Phương thức thanh toán:";
            // 
            // lbSoDienThoai
            // 
            this.lbSoDienThoai.AutoSize = true;
            this.lbSoDienThoai.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbSoDienThoai.Location = new System.Drawing.Point(118, 192);
            this.lbSoDienThoai.Name = "lbSoDienThoai";
            this.lbSoDienThoai.Size = new System.Drawing.Size(136, 21);
            this.lbSoDienThoai.TabIndex = 1;
            this.lbSoDienThoai.Text = "Số điện thoại:";
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Location = new System.Drawing.Point(167, 274);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.Size = new System.Drawing.Size(612, 229);
            this.dgvSanPham.TabIndex = 2;
            this.dgvSanPham.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSanPham_CellFormatting);
            // 
            // lbTongTienHang
            // 
            this.lbTongTienHang.AutoSize = true;
            this.lbTongTienHang.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTongTienHang.Location = new System.Drawing.Point(465, 534);
            this.lbTongTienHang.Name = "lbTongTienHang";
            this.lbTongTienHang.Size = new System.Drawing.Size(145, 21);
            this.lbTongTienHang.TabIndex = 1;
            this.lbTongTienHang.Text = "Tổng tiền hàng:";
            // 
            // lbTongTien
            // 
            this.lbTongTien.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTongTien.Location = new System.Drawing.Point(634, 534);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(145, 21);
            this.lbTongTien.TabIndex = 1;
            this.lbTongTien.Text = "0";
            this.lbTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbTienChu
            // 
            this.lbTienChu.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTienChu.Location = new System.Drawing.Point(163, 534);
            this.lbTienChu.Name = "lbTienChu";
            this.lbTienChu.Size = new System.Drawing.Size(258, 115);
            this.lbTienChu.TabIndex = 1;
            this.lbTienChu.Text = "Không đồng";
            // 
            // lbFooter
            // 
            this.lbFooter.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbFooter.Location = new System.Drawing.Point(332, 670);
            this.lbFooter.Name = "lbFooter";
            this.lbFooter.Size = new System.Drawing.Size(278, 33);
            this.lbFooter.TabIndex = 1;
            this.lbFooter.Text = "Cảm ơn và hẹn gặp lại!";
            this.lbFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDiaChi
            // 
            this.lbDiaChi.AutoSize = true;
            this.lbDiaChi.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbDiaChi.Location = new System.Drawing.Point(118, 224);
            this.lbDiaChi.Name = "lbDiaChi";
            this.lbDiaChi.Size = new System.Drawing.Size(82, 21);
            this.lbDiaChi.TabIndex = 1;
            this.lbDiaChi.Text = "Địa chỉ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(465, 590);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ghi chú:";
            // 
            // lbGhiChu
            // 
            this.lbGhiChu.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbGhiChu.Location = new System.Drawing.Point(553, 590);
            this.lbGhiChu.Name = "lbGhiChu";
            this.lbGhiChu.Size = new System.Drawing.Size(226, 80);
            this.lbGhiChu.TabIndex = 1;
            this.lbGhiChu.Text = "text";
            // 
            // btnMinimun
            // 
            this.btnMinimun.FlatAppearance.BorderSize = 0;
            this.btnMinimun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimun.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimun.Image")));
            this.btnMinimun.Location = new System.Drawing.Point(72, 12);
            this.btnMinimun.Name = "btnMinimun";
            this.btnMinimun.Size = new System.Drawing.Size(25, 23);
            this.btnMinimun.TabIndex = 17;
            this.btnMinimun.UseVisualStyleBackColor = true;
            this.btnMinimun.Click += new System.EventHandler(this.btnMinimun_Click);
            // 
            // btnMaximun
            // 
            this.btnMaximun.FlatAppearance.BorderSize = 0;
            this.btnMaximun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximun.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximun.Image")));
            this.btnMaximun.Location = new System.Drawing.Point(41, 12);
            this.btnMaximun.Name = "btnMaximun";
            this.btnMaximun.Size = new System.Drawing.Size(25, 23);
            this.btnMaximun.TabIndex = 18;
            this.btnMaximun.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(10, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(25, 23);
            this.btnExit.TabIndex = 19;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnInHD
            // 
            this.btnInHD.BackColor = System.Drawing.Color.Gainsboro;
            this.btnInHD.FlatAppearance.BorderSize = 0;
            this.btnInHD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInHD.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.btnInHD.Location = new System.Drawing.Point(665, 218);
            this.btnInHD.Name = "btnInHD";
            this.btnInHD.Size = new System.Drawing.Size(114, 33);
            this.btnInHD.TabIndex = 20;
            this.btnInHD.Text = "In hóa đơn";
            this.btnInHD.UseVisualStyleBackColor = false;
            this.btnInHD.Click += new System.EventHandler(this.btnInHD_Click);
            // 
            // ChiTietHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 713);
            this.Controls.Add(this.btnInHD);
            this.Controls.Add(this.btnMinimun);
            this.Controls.Add(this.btnMaximun);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgvSanPham);
            this.Controls.Add(this.lbDiaChi);
            this.Controls.Add(this.lbSoDienThoai);
            this.Controls.Add(this.lbTongTien);
            this.Controls.Add(this.lbFooter);
            this.Controls.Add(this.lbTienChu);
            this.Controls.Add(this.lbTongTienHang);
            this.Controls.Add(this.lbGhiChu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbPhuongThucTT);
            this.Controls.Add(this.lbKhachHang);
            this.Controls.Add(this.lbNgayLap);
            this.Controls.Add(this.lbMaHD);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold);
            this.MaximumSize = new System.Drawing.Size(950, 752);
            this.MinimumSize = new System.Drawing.Size(950, 752);
            this.Name = "ChiTietHD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChiTietHD";
            this.Load += new System.EventHandler(this.ChiTietHD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbMaHD;
        private System.Windows.Forms.Label lbKhachHang;
        private System.Windows.Forms.Label lbNgayLap;
        private System.Windows.Forms.Label lbPhuongThucTT;
        private System.Windows.Forms.Label lbSoDienThoai;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Label lbTongTienHang;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Label lbTienChu;
        private System.Windows.Forms.Label lbFooter;
        private System.Windows.Forms.Label lbDiaChi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbGhiChu;
        private System.Windows.Forms.Button btnMinimun;
        private System.Windows.Forms.Button btnMaximun;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnInHD;
    }
}