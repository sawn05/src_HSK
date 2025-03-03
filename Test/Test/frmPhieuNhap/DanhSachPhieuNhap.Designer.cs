
namespace Test.frmPhieuNhap
{
    partial class DanhSachPhieuNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DanhSachPhieuNhap));
            this.btnInPhieu = new System.Windows.Forms.Button();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.lbDiaChi = new System.Windows.Forms.Label();
            this.lbNV = new System.Windows.Forms.Label();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.lbTienChu = new System.Windows.Forms.Label();
            this.lbTongTienHang = new System.Windows.Forms.Label();
            this.lbKhachHang = new System.Windows.Forms.Label();
            this.lbNgayNhap = new System.Windows.Forms.Label();
            this.lbMaHD = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMinimun = new System.Windows.Forms.Button();
            this.btnMaximun = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtNCC = new System.Windows.Forms.Label();
            this.txtNV = new System.Windows.Forms.Label();
            this.cbbMaPhieu = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnXoaPhieu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.AccessibleName = "lbNCC";
            this.btnInPhieu.BackColor = System.Drawing.Color.Gainsboro;
            this.btnInPhieu.FlatAppearance.BorderSize = 0;
            this.btnInPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInPhieu.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.btnInPhieu.Location = new System.Drawing.Point(667, 698);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(114, 33);
            this.btnInPhieu.TabIndex = 38;
            this.btnInPhieu.Text = "In phiếu";
            this.btnInPhieu.UseVisualStyleBackColor = false;
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AccessibleName = "lbNCC";
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Location = new System.Drawing.Point(93, 337);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.Size = new System.Drawing.Size(731, 294);
            this.dgvSanPham.TabIndex = 34;
            this.dgvSanPham.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSanPham_CellFormatting);
            // 
            // lbDiaChi
            // 
            this.lbDiaChi.AccessibleName = "lbNCC";
            this.lbDiaChi.AutoSize = true;
            this.lbDiaChi.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbDiaChi.Location = new System.Drawing.Point(120, 223);
            this.lbDiaChi.Name = "lbDiaChi";
            this.lbDiaChi.Size = new System.Drawing.Size(82, 21);
            this.lbDiaChi.TabIndex = 32;
            this.lbDiaChi.Text = "Địa chỉ:";
            // 
            // lbNV
            // 
            this.lbNV.AccessibleName = "lbNCC";
            this.lbNV.AutoSize = true;
            this.lbNV.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbNV.Location = new System.Drawing.Point(120, 191);
            this.lbNV.Name = "lbNV";
            this.lbNV.Size = new System.Drawing.Size(100, 21);
            this.lbNV.TabIndex = 31;
            this.lbNV.Text = "Nhân viên:";
            // 
            // lbTongTien
            // 
            this.lbTongTien.AccessibleName = "lbNCC";
            this.lbTongTien.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTongTien.Location = new System.Drawing.Point(636, 651);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(145, 21);
            this.lbTongTien.TabIndex = 30;
            this.lbTongTien.Text = "0";
            this.lbTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbTienChu
            // 
            this.lbTienChu.AccessibleName = "lbNCC";
            this.lbTienChu.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTienChu.Location = new System.Drawing.Point(88, 651);
            this.lbTienChu.Name = "lbTienChu";
            this.lbTienChu.Size = new System.Drawing.Size(309, 80);
            this.lbTienChu.TabIndex = 28;
            this.lbTienChu.Text = "Không đồng";
            // 
            // lbTongTienHang
            // 
            this.lbTongTienHang.AccessibleName = "lbNCC";
            this.lbTongTienHang.AutoSize = true;
            this.lbTongTienHang.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTongTienHang.Location = new System.Drawing.Point(467, 651);
            this.lbTongTienHang.Name = "lbTongTienHang";
            this.lbTongTienHang.Size = new System.Drawing.Size(127, 21);
            this.lbTongTienHang.TabIndex = 27;
            this.lbTongTienHang.Text = "Tổng số tiền:";
            // 
            // lbKhachHang
            // 
            this.lbKhachHang.AccessibleName = "lbNCC";
            this.lbKhachHang.AutoSize = true;
            this.lbKhachHang.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbKhachHang.Location = new System.Drawing.Point(120, 159);
            this.lbKhachHang.Name = "lbKhachHang";
            this.lbKhachHang.Size = new System.Drawing.Size(127, 21);
            this.lbKhachHang.TabIndex = 23;
            this.lbKhachHang.Text = "Nhà cung cấp:";
            // 
            // lbNgayNhap
            // 
            this.lbNgayNhap.AccessibleName = "lbNCC";
            this.lbNgayNhap.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbNgayNhap.Location = new System.Drawing.Point(460, 123);
            this.lbNgayNhap.Name = "lbNgayNhap";
            this.lbNgayNhap.Size = new System.Drawing.Size(123, 21);
            this.lbNgayNhap.TabIndex = 22;
            this.lbNgayNhap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMaHD
            // 
            this.lbMaHD.AccessibleName = "lbNCC";
            this.lbMaHD.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbMaHD.Location = new System.Drawing.Point(314, 94);
            this.lbMaHD.Name = "lbMaHD";
            this.lbMaHD.Size = new System.Drawing.Size(144, 21);
            this.lbMaHD.TabIndex = 33;
            this.lbMaHD.Text = "Mã phiếu nhập:";
            this.lbMaHD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AccessibleName = "lbNCC";
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(2, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(931, 76);
            this.label1.TabIndex = 21;
            this.label1.Text = "PHIẾU NHẬP KHO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMinimun
            // 
            this.btnMinimun.AccessibleName = "lbNCC";
            this.btnMinimun.FlatAppearance.BorderSize = 0;
            this.btnMinimun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimun.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimun.Image")));
            this.btnMinimun.Location = new System.Drawing.Point(74, 11);
            this.btnMinimun.Name = "btnMinimun";
            this.btnMinimun.Size = new System.Drawing.Size(25, 23);
            this.btnMinimun.TabIndex = 35;
            this.btnMinimun.UseVisualStyleBackColor = true;
            this.btnMinimun.Click += new System.EventHandler(this.btnMinimun_Click);
            // 
            // btnMaximun
            // 
            this.btnMaximun.AccessibleName = "lbNCC";
            this.btnMaximun.FlatAppearance.BorderSize = 0;
            this.btnMaximun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximun.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximun.Image")));
            this.btnMaximun.Location = new System.Drawing.Point(43, 11);
            this.btnMaximun.Name = "btnMaximun";
            this.btnMaximun.Size = new System.Drawing.Size(25, 23);
            this.btnMaximun.TabIndex = 36;
            this.btnMaximun.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.AccessibleName = "lbNCC";
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(12, 11);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(25, 23);
            this.btnExit.TabIndex = 37;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtNCC
            // 
            this.txtNCC.AccessibleName = "lbNCC";
            this.txtNCC.AutoSize = true;
            this.txtNCC.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtNCC.Location = new System.Drawing.Point(253, 159);
            this.txtNCC.Name = "txtNCC";
            this.txtNCC.Size = new System.Drawing.Size(0, 21);
            this.txtNCC.TabIndex = 23;
            // 
            // txtNV
            // 
            this.txtNV.AccessibleName = "lbNCC";
            this.txtNV.AutoSize = true;
            this.txtNV.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtNV.Location = new System.Drawing.Point(226, 191);
            this.txtNV.Name = "txtNV";
            this.txtNV.Size = new System.Drawing.Size(0, 21);
            this.txtNV.TabIndex = 31;
            // 
            // cbbMaPhieu
            // 
            this.cbbMaPhieu.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.cbbMaPhieu.FormattingEnabled = true;
            this.cbbMaPhieu.Location = new System.Drawing.Point(464, 91);
            this.cbbMaPhieu.Name = "cbbMaPhieu";
            this.cbbMaPhieu.Size = new System.Drawing.Size(130, 29);
            this.cbbMaPhieu.TabIndex = 39;
            this.cbbMaPhieu.SelectedIndexChanged += new System.EventHandler(this.cbbMaPhieu_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AccessibleName = "lbNCC";
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(120, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 21);
            this.label2.TabIndex = 31;
            this.label2.Text = "Nhân viên:";
            // 
            // label3
            // 
            this.label3.AccessibleName = "lbNCC";
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(120, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(622, 21);
            this.label3.TabIndex = 32;
            this.label3.Text = "Nhập tại: Cửa hàng sách Hapibook - 96 Định Công - Hoàng Mai - Hà Nội";
            // 
            // label5
            // 
            this.label5.AccessibleName = "lbNCC";
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(120, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 21);
            this.label5.TabIndex = 31;
            this.label5.Text = "Số điện thoại:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.AccessibleName = "lbNCC";
            this.txtDiaChi.AutoSize = true;
            this.txtDiaChi.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtDiaChi.Location = new System.Drawing.Point(208, 223);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(0, 21);
            this.txtDiaChi.TabIndex = 32;
            // 
            // txtSDT
            // 
            this.txtSDT.AccessibleName = "lbNCC";
            this.txtSDT.AutoSize = true;
            this.txtSDT.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSDT.Location = new System.Drawing.Point(262, 256);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(0, 21);
            this.txtSDT.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AccessibleName = "lbNCC";
            this.label4.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(346, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 21);
            this.label4.TabIndex = 22;
            this.label4.Text = "Ngày nhập: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnXoaPhieu
            // 
            this.btnXoaPhieu.AccessibleName = "lbNCC";
            this.btnXoaPhieu.BackColor = System.Drawing.Color.Gainsboro;
            this.btnXoaPhieu.FlatAppearance.BorderSize = 0;
            this.btnXoaPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaPhieu.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.btnXoaPhieu.Location = new System.Drawing.Point(524, 698);
            this.btnXoaPhieu.Name = "btnXoaPhieu";
            this.btnXoaPhieu.Size = new System.Drawing.Size(114, 33);
            this.btnXoaPhieu.TabIndex = 38;
            this.btnXoaPhieu.Text = "Xóa phiếu";
            this.btnXoaPhieu.UseVisualStyleBackColor = false;
            this.btnXoaPhieu.Click += new System.EventHandler(this.btnXoaPhieu_Click);
            // 
            // DanhSachPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 761);
            this.Controls.Add(this.cbbMaPhieu);
            this.Controls.Add(this.btnXoaPhieu);
            this.Controls.Add(this.btnInPhieu);
            this.Controls.Add(this.btnMinimun);
            this.Controls.Add(this.btnMaximun);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgvSanPham);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbDiaChi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNV);
            this.Controls.Add(this.lbNV);
            this.Controls.Add(this.lbTongTien);
            this.Controls.Add(this.lbTienChu);
            this.Controls.Add(this.lbTongTienHang);
            this.Controls.Add(this.txtNCC);
            this.Controls.Add(this.lbKhachHang);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbNgayNhap);
            this.Controls.Add(this.lbMaHD);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold);
            this.MaximumSize = new System.Drawing.Size(950, 800);
            this.MinimumSize = new System.Drawing.Size(950, 800);
            this.Name = "DanhSachPhieuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DanhSachPhieuNhap";
            this.Load += new System.EventHandler(this.DanhSachPhieuNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInPhieu;
        private System.Windows.Forms.Button btnMinimun;
        private System.Windows.Forms.Button btnMaximun;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Label lbDiaChi;
        private System.Windows.Forms.Label lbNV;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Label lbTienChu;
        private System.Windows.Forms.Label lbTongTienHang;
        private System.Windows.Forms.Label lbKhachHang;
        private System.Windows.Forms.Label lbNgayNhap;
        private System.Windows.Forms.Label lbMaHD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtNCC;
        private System.Windows.Forms.Label txtNV;
        private System.Windows.Forms.ComboBox cbbMaPhieu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtDiaChi;
        private System.Windows.Forms.Label txtSDT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnXoaPhieu;
    }
}