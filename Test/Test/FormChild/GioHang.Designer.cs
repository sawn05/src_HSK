
namespace Test.FormChild
{
    partial class GioHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GioHang));
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.txtTimKiemSP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimKhachHang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelThanhToan = new System.Windows.Forms.Panel();
            this.lbTienTraKhach = new System.Windows.Forms.Label();
            this.picQR = new System.Windows.Forms.PictureBox();
            this.radioBtnCK = new System.Windows.Forms.RadioButton();
            this.radioBtnTM = new System.Windows.Forms.RadioButton();
            this.lbTongTienHang = new System.Windows.Forms.Label();
            this.lbSoLuongSP = new System.Windows.Forms.Label();
            this.radioBtnVND = new System.Windows.Forms.RadioButton();
            this.radioBtnPecent = new System.Windows.Forms.RadioButton();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtKhachThanhToan = new System.Windows.Forms.TextBox();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.dgvTimKiem = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoaSPGioHang = new System.Windows.Forms.Button();
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.btnXemGioHang = new System.Windows.Forms.Button();
            this.btnXemSanPham = new System.Windows.Forms.Button();
            this.lbTongTienHangGiaCu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.panelThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Location = new System.Drawing.Point(37, 121);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.RowTemplate.Height = 24;
            this.dgvSanPham.Size = new System.Drawing.Size(605, 435);
            this.dgvSanPham.TabIndex = 2;
            this.dgvSanPham.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSanPham_CellFormatting);
            // 
            // txtTimKiemSP
            // 
            this.txtTimKiemSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiemSP.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.txtTimKiemSP.Location = new System.Drawing.Point(216, 27);
            this.txtTimKiemSP.Name = "txtTimKiemSP";
            this.txtTimKiemSP.Size = new System.Drawing.Size(300, 26);
            this.txtTimKiemSP.TabIndex = 3;
            this.txtTimKiemSP.TextChanged += new System.EventHandler(this.txtTimKiemSP_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(38, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tìm kiếm sản phẩm:";
            // 
            // txtTimKhachHang
            // 
            this.txtTimKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKhachHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKhachHang.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.txtTimKhachHang.Location = new System.Drawing.Point(762, 12);
            this.txtTimKhachHang.Name = "txtTimKhachHang";
            this.txtTimKhachHang.Size = new System.Drawing.Size(319, 26);
            this.txtTimKhachHang.TabIndex = 5;
            this.txtTimKhachHang.TextChanged += new System.EventHandler(this.txtTimKhachHang_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(649, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tổng tiền hàng";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(649, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Số lượng sản phẩm";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(649, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Giảm giá";
            // 
            // panelThanhToan
            // 
            this.panelThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelThanhToan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelThanhToan.Controls.Add(this.lbTienTraKhach);
            this.panelThanhToan.Controls.Add(this.picQR);
            this.panelThanhToan.Controls.Add(this.radioBtnCK);
            this.panelThanhToan.Controls.Add(this.radioBtnTM);
            this.panelThanhToan.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.panelThanhToan.Location = new System.Drawing.Point(653, 312);
            this.panelThanhToan.Name = "panelThanhToan";
            this.panelThanhToan.Size = new System.Drawing.Size(428, 244);
            this.panelThanhToan.TabIndex = 9;
            // 
            // lbTienTraKhach
            // 
            this.lbTienTraKhach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTienTraKhach.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.lbTienTraKhach.Location = new System.Drawing.Point(3, 115);
            this.lbTienTraKhach.Name = "lbTienTraKhach";
            this.lbTienTraKhach.Size = new System.Drawing.Size(420, 21);
            this.lbTienTraKhach.TabIndex = 19;
            this.lbTienTraKhach.Text = "Tiền thừa trả khách: 0";
            this.lbTienTraKhach.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picQR
            // 
            this.picQR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picQR.Enabled = false;
            this.picQR.Image = ((System.Drawing.Image)(resources.GetObject("picQR.Image")));
            this.picQR.Location = new System.Drawing.Point(130, 51);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(164, 168);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picQR.TabIndex = 20;
            this.picQR.TabStop = false;
            this.picQR.Visible = false;
            // 
            // radioBtnCK
            // 
            this.radioBtnCK.AutoSize = true;
            this.radioBtnCK.Location = new System.Drawing.Point(248, 20);
            this.radioBtnCK.Name = "radioBtnCK";
            this.radioBtnCK.Size = new System.Drawing.Size(136, 25);
            this.radioBtnCK.TabIndex = 0;
            this.radioBtnCK.TabStop = true;
            this.radioBtnCK.Text = "Chuyển khoản";
            this.radioBtnCK.UseVisualStyleBackColor = true;
            this.radioBtnCK.CheckedChanged += new System.EventHandler(this.radioBtnCK_CheckedChanged);
            // 
            // radioBtnTM
            // 
            this.radioBtnTM.AutoSize = true;
            this.radioBtnTM.Location = new System.Drawing.Point(48, 20);
            this.radioBtnTM.Name = "radioBtnTM";
            this.radioBtnTM.Size = new System.Drawing.Size(100, 25);
            this.radioBtnTM.TabIndex = 0;
            this.radioBtnTM.TabStop = true;
            this.radioBtnTM.Text = "Tiền mặt";
            this.radioBtnTM.UseVisualStyleBackColor = true;
            this.radioBtnTM.CheckedChanged += new System.EventHandler(this.radioBtnTM_CheckedChanged);
            // 
            // lbTongTienHang
            // 
            this.lbTongTienHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTongTienHang.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.lbTongTienHang.Location = new System.Drawing.Point(961, 178);
            this.lbTongTienHang.Name = "lbTongTienHang";
            this.lbTongTienHang.Size = new System.Drawing.Size(120, 21);
            this.lbTongTienHang.TabIndex = 10;
            this.lbTongTienHang.Text = "0";
            this.lbTongTienHang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbSoLuongSP
            // 
            this.lbSoLuongSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSoLuongSP.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.lbSoLuongSP.Location = new System.Drawing.Point(961, 211);
            this.lbSoLuongSP.Name = "lbSoLuongSP";
            this.lbSoLuongSP.Size = new System.Drawing.Size(120, 21);
            this.lbSoLuongSP.TabIndex = 10;
            this.lbSoLuongSP.Text = "0";
            this.lbSoLuongSP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radioBtnVND
            // 
            this.radioBtnVND.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radioBtnVND.AutoSize = true;
            this.radioBtnVND.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.radioBtnVND.Location = new System.Drawing.Point(762, 245);
            this.radioBtnVND.Name = "radioBtnVND";
            this.radioBtnVND.Size = new System.Drawing.Size(55, 25);
            this.radioBtnVND.TabIndex = 11;
            this.radioBtnVND.TabStop = true;
            this.radioBtnVND.Text = "VND";
            this.radioBtnVND.UseVisualStyleBackColor = true;
            this.radioBtnVND.CheckedChanged += new System.EventHandler(this.radioBtnVND_CheckedChanged);
            // 
            // radioBtnPecent
            // 
            this.radioBtnPecent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radioBtnPecent.AutoSize = true;
            this.radioBtnPecent.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.radioBtnPecent.Location = new System.Drawing.Point(823, 245);
            this.radioBtnPecent.Name = "radioBtnPecent";
            this.radioBtnPecent.Size = new System.Drawing.Size(37, 25);
            this.radioBtnPecent.TabIndex = 11;
            this.radioBtnPecent.TabStop = true;
            this.radioBtnPecent.Text = "%";
            this.radioBtnPecent.UseVisualStyleBackColor = true;
            this.radioBtnPecent.CheckedChanged += new System.EventHandler(this.radioBtnPecent_CheckedChanged);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtGhiChu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGhiChu.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.txtGhiChu.Location = new System.Drawing.Point(37, 590);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(605, 26);
            this.txtGhiChu.TabIndex = 12;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(223)))), ((int)(((byte)(203)))));
            this.btnThanhToan.FlatAppearance.BorderSize = 0;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.Location = new System.Drawing.Point(653, 567);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(428, 49);
            this.btnThanhToan.TabIndex = 13;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(649, 281);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 21);
            this.label10.TabIndex = 14;
            this.label10.Text = "Khách thanh toán";
            // 
            // txtKhachThanhToan
            // 
            this.txtKhachThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKhachThanhToan.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtKhachThanhToan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKhachThanhToan.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtKhachThanhToan.Location = new System.Drawing.Point(961, 281);
            this.txtKhachThanhToan.Name = "txtKhachThanhToan";
            this.txtKhachThanhToan.Size = new System.Drawing.Size(120, 19);
            this.txtKhachThanhToan.TabIndex = 5;
            this.txtKhachThanhToan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtKhachThanhToan.TextChanged += new System.EventHandler(this.txtKhachThanhToan_TextChanged);
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGiamGia.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtGiamGia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGiamGia.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtGiamGia.Location = new System.Drawing.Point(961, 247);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(120, 19);
            this.txtGiamGia.TabIndex = 5;
            this.txtGiamGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGiamGia.TextChanged += new System.EventHandler(this.txtGiamGia_TextChanged);
            // 
            // dgvTimKiem
            // 
            this.dgvTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTimKiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimKiem.Location = new System.Drawing.Point(38, 121);
            this.dgvTimKiem.Name = "dgvTimKiem";
            this.dgvTimKiem.ReadOnly = true;
            this.dgvTimKiem.Size = new System.Drawing.Size(605, 435);
            this.dgvTimKiem.TabIndex = 15;
            this.dgvTimKiem.Visible = false;
            this.dgvTimKiem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTimKiem_CellFormatting);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(223)))), ((int)(((byte)(203)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.btnThem.Location = new System.Drawing.Point(567, 86);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 29);
            this.btnThem.TabIndex = 16;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoaSPGioHang
            // 
            this.btnXoaSPGioHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaSPGioHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(223)))), ((int)(((byte)(203)))));
            this.btnXoaSPGioHang.FlatAppearance.BorderSize = 0;
            this.btnXoaSPGioHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaSPGioHang.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.btnXoaSPGioHang.Location = new System.Drawing.Point(486, 86);
            this.btnXoaSPGioHang.Name = "btnXoaSPGioHang";
            this.btnXoaSPGioHang.Size = new System.Drawing.Size(75, 29);
            this.btnXoaSPGioHang.TabIndex = 16;
            this.btnXoaSPGioHang.Text = "Xóa";
            this.btnXoaSPGioHang.UseVisualStyleBackColor = false;
            this.btnXoaSPGioHang.Click += new System.EventHandler(this.btnXoaSPGioHang_Click);
            // 
            // dgvKhachHang
            // 
            this.dgvKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhachHang.Location = new System.Drawing.Point(653, 52);
            this.dgvKhachHang.MaximumSize = new System.Drawing.Size(428, 300);
            this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.Size = new System.Drawing.Size(428, 111);
            this.dgvKhachHang.TabIndex = 17;
            this.dgvKhachHang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachHang_CellContentClick);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(649, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 21);
            this.label6.TabIndex = 18;
            this.label6.Text = "Khách hàng:";
            // 
            // btnXemGioHang
            // 
            this.btnXemGioHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(223)))), ((int)(((byte)(203)))));
            this.btnXemGioHang.FlatAppearance.BorderSize = 0;
            this.btnXemGioHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemGioHang.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.btnXemGioHang.Location = new System.Drawing.Point(37, 86);
            this.btnXemGioHang.Name = "btnXemGioHang";
            this.btnXemGioHang.Size = new System.Drawing.Size(128, 29);
            this.btnXemGioHang.TabIndex = 16;
            this.btnXemGioHang.Text = "Xem giỏ hàng";
            this.btnXemGioHang.UseVisualStyleBackColor = false;
            this.btnXemGioHang.Click += new System.EventHandler(this.btnXemGioHang_Click);
            // 
            // btnXemSanPham
            // 
            this.btnXemSanPham.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(223)))), ((int)(((byte)(203)))));
            this.btnXemSanPham.FlatAppearance.BorderSize = 0;
            this.btnXemSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemSanPham.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.btnXemSanPham.Location = new System.Drawing.Point(171, 86);
            this.btnXemSanPham.Name = "btnXemSanPham";
            this.btnXemSanPham.Size = new System.Drawing.Size(131, 29);
            this.btnXemSanPham.TabIndex = 16;
            this.btnXemSanPham.Text = "Xem sản phẩm";
            this.btnXemSanPham.UseVisualStyleBackColor = false;
            this.btnXemSanPham.Click += new System.EventHandler(this.btnXemSanPham_Click);
            // 
            // lbTongTienHangGiaCu
            // 
            this.lbTongTienHangGiaCu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTongTienHangGiaCu.Font = new System.Drawing.Font("Cascadia Code", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTongTienHangGiaCu.Location = new System.Drawing.Point(828, 178);
            this.lbTongTienHangGiaCu.Name = "lbTongTienHangGiaCu";
            this.lbTongTienHangGiaCu.Size = new System.Drawing.Size(120, 21);
            this.lbTongTienHangGiaCu.TabIndex = 10;
            this.lbTongTienHangGiaCu.Text = "0";
            this.lbTongTienHangGiaCu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GioHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 651);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvKhachHang);
            this.Controls.Add(this.btnXemSanPham);
            this.Controls.Add(this.btnXemGioHang);
            this.Controls.Add(this.btnXoaSPGioHang);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvTimKiem);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.radioBtnPecent);
            this.Controls.Add(this.radioBtnVND);
            this.Controls.Add(this.lbSoLuongSP);
            this.Controls.Add(this.lbTongTienHangGiaCu);
            this.Controls.Add(this.lbTongTienHang);
            this.Controls.Add(this.panelThanhToan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGiamGia);
            this.Controls.Add(this.txtKhachThanhToan);
            this.Controls.Add(this.txtTimKhachHang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTimKiemSP);
            this.Controls.Add(this.dgvSanPham);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold);
            this.MinimumSize = new System.Drawing.Size(1109, 690);
            this.Name = "GioHang";
            this.Text = "GioHang";
            this.Load += new System.EventHandler(this.GioHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.panelThanhToan.ResumeLayout(false);
            this.panelThanhToan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.TextBox txtTimKiemSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimKhachHang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelThanhToan;
        private System.Windows.Forms.RadioButton radioBtnCK;
        private System.Windows.Forms.RadioButton radioBtnTM;
        private System.Windows.Forms.Label lbTongTienHang;
        private System.Windows.Forms.Label lbSoLuongSP;
        private System.Windows.Forms.RadioButton radioBtnVND;
        private System.Windows.Forms.RadioButton radioBtnPecent;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtKhachThanhToan;
        private System.Windows.Forms.TextBox txtGiamGia;
        private System.Windows.Forms.DataGridView dgvTimKiem;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoaSPGioHang;
        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnXemGioHang;
        private System.Windows.Forms.Button btnXemSanPham;
        private System.Windows.Forms.Label lbTienTraKhach;
        private System.Windows.Forms.PictureBox picQR;
        private System.Windows.Forms.Label lbTongTienHangGiaCu;
    }
}