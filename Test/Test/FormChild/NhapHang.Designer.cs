
namespace Test.FormChild
{
    partial class NhapHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhapHang));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTaoMaPhieu = new System.Windows.Forms.Button();
            this.btnXoaPhieu = new System.Windows.Forms.Button();
            this.btnSuaPhieu = new System.Windows.Forms.Button();
            this.cbbNhanVien = new System.Windows.Forms.ComboBox();
            this.btnTaoPhieu = new System.Windows.Forms.Button();
            this.cbbNCC = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelKQTimKiem = new System.Windows.Forms.Label();
            this.txtMaNhap = new System.Windows.Forms.TextBox();
            this.dgvPhieuNhap = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThemHangMoi = new System.Windows.Forms.Button();
            this.dgvTimKiem = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnNhapHang = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnDSPhieuNhap = new System.Windows.Forms.Button();
            this.btnXoaSP = new System.Windows.Forms.Button();
            this.btnThemVaoPhieu = new System.Windows.Forms.Button();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.cbbMaPhieu = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.btnTaoMaPhieu);
            this.groupBox1.Controls.Add(this.btnXoaPhieu);
            this.groupBox1.Controls.Add(this.btnSuaPhieu);
            this.groupBox1.Controls.Add(this.cbbNhanVien);
            this.groupBox1.Controls.Add(this.btnTaoPhieu);
            this.groupBox1.Controls.Add(this.cbbNCC);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labelKQTimKiem);
            this.groupBox1.Controls.Add(this.txtMaNhap);
            this.groupBox1.Font = new System.Drawing.Font("Cascadia Code", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(591, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phiếu nhập";
            // 
            // btnTaoMaPhieu
            // 
            this.btnTaoMaPhieu.FlatAppearance.BorderSize = 0;
            this.btnTaoMaPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoMaPhieu.Image = ((System.Drawing.Image)(resources.GetObject("btnTaoMaPhieu.Image")));
            this.btnTaoMaPhieu.Location = new System.Drawing.Point(300, 46);
            this.btnTaoMaPhieu.Name = "btnTaoMaPhieu";
            this.btnTaoMaPhieu.Size = new System.Drawing.Size(19, 26);
            this.btnTaoMaPhieu.TabIndex = 8;
            this.btnTaoMaPhieu.UseVisualStyleBackColor = true;
            this.btnTaoMaPhieu.Click += new System.EventHandler(this.btnTaoMaPhieu_Click);
            // 
            // btnXoaPhieu
            // 
            this.btnXoaPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaPhieu.BackColor = System.Drawing.Color.Gainsboro;
            this.btnXoaPhieu.FlatAppearance.BorderSize = 0;
            this.btnXoaPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaPhieu.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.btnXoaPhieu.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaPhieu.Image")));
            this.btnXoaPhieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaPhieu.Location = new System.Drawing.Point(391, 130);
            this.btnXoaPhieu.Name = "btnXoaPhieu";
            this.btnXoaPhieu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnXoaPhieu.Size = new System.Drawing.Size(143, 37);
            this.btnXoaPhieu.TabIndex = 7;
            this.btnXoaPhieu.Text = " Xóa phiếu";
            this.btnXoaPhieu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaPhieu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoaPhieu.UseVisualStyleBackColor = false;
            this.btnXoaPhieu.Click += new System.EventHandler(this.btnXoaPhieu_Click);
            // 
            // btnSuaPhieu
            // 
            this.btnSuaPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSuaPhieu.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSuaPhieu.FlatAppearance.BorderSize = 0;
            this.btnSuaPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaPhieu.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.btnSuaPhieu.Image = ((System.Drawing.Image)(resources.GetObject("btnSuaPhieu.Image")));
            this.btnSuaPhieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaPhieu.Location = new System.Drawing.Point(221, 130);
            this.btnSuaPhieu.Name = "btnSuaPhieu";
            this.btnSuaPhieu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSuaPhieu.Size = new System.Drawing.Size(147, 37);
            this.btnSuaPhieu.TabIndex = 4;
            this.btnSuaPhieu.Text = " Sửa phiếu";
            this.btnSuaPhieu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaPhieu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSuaPhieu.UseVisualStyleBackColor = false;
            this.btnSuaPhieu.Click += new System.EventHandler(this.btnSuaPhieu_Click);
            // 
            // cbbNhanVien
            // 
            this.cbbNhanVien.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbbNhanVien.FormattingEnabled = true;
            this.cbbNhanVien.Location = new System.Drawing.Point(472, 45);
            this.cbbNhanVien.Name = "cbbNhanVien";
            this.cbbNhanVien.Size = new System.Drawing.Size(105, 29);
            this.cbbNhanVien.TabIndex = 6;
            // 
            // btnTaoPhieu
            // 
            this.btnTaoPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaoPhieu.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTaoPhieu.FlatAppearance.BorderSize = 0;
            this.btnTaoPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoPhieu.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.btnTaoPhieu.Image = ((System.Drawing.Image)(resources.GetObject("btnTaoPhieu.Image")));
            this.btnTaoPhieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaoPhieu.Location = new System.Drawing.Point(58, 130);
            this.btnTaoPhieu.Name = "btnTaoPhieu";
            this.btnTaoPhieu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTaoPhieu.Size = new System.Drawing.Size(140, 37);
            this.btnTaoPhieu.TabIndex = 3;
            this.btnTaoPhieu.Text = " Tạo phiếu";
            this.btnTaoPhieu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaoPhieu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTaoPhieu.UseVisualStyleBackColor = false;
            this.btnTaoPhieu.Click += new System.EventHandler(this.btnTaoPhieu_Click);
            // 
            // cbbNCC
            // 
            this.cbbNCC.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbbNCC.FormattingEnabled = true;
            this.cbbNCC.Location = new System.Drawing.Point(190, 81);
            this.cbbNCC.Name = "cbbNCC";
            this.cbbNCC.Size = new System.Drawing.Size(129, 29);
            this.cbbNCC.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(339, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã nhân viên:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(30, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã nhà cung cấp:";
            // 
            // labelKQTimKiem
            // 
            this.labelKQTimKiem.AutoSize = true;
            this.labelKQTimKiem.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelKQTimKiem.Location = new System.Drawing.Point(30, 48);
            this.labelKQTimKiem.Name = "labelKQTimKiem";
            this.labelKQTimKiem.Size = new System.Drawing.Size(136, 21);
            this.labelKQTimKiem.TabIndex = 3;
            this.labelKQTimKiem.Text = "Mã phiếu nhập:";
            // 
            // txtMaNhap
            // 
            this.txtMaNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaNhap.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtMaNhap.Location = new System.Drawing.Point(190, 46);
            this.txtMaNhap.Name = "txtMaNhap";
            this.txtMaNhap.ReadOnly = true;
            this.txtMaNhap.Size = new System.Drawing.Size(104, 26);
            this.txtMaNhap.TabIndex = 4;
            // 
            // dgvPhieuNhap
            // 
            this.dgvPhieuNhap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuNhap.Location = new System.Drawing.Point(609, 12);
            this.dgvPhieuNhap.MaximumSize = new System.Drawing.Size(900, 188);
            this.dgvPhieuNhap.MinimumSize = new System.Drawing.Size(472, 188);
            this.dgvPhieuNhap.Name = "dgvPhieuNhap";
            this.dgvPhieuNhap.ReadOnly = true;
            this.dgvPhieuNhap.Size = new System.Drawing.Size(472, 188);
            this.dgvPhieuNhap.TabIndex = 1;
            this.dgvPhieuNhap.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuNhap_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox2.Controls.Add(this.btnThemHangMoi);
            this.groupBox2.Controls.Add(this.dgvTimKiem);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnLamMoi);
            this.groupBox2.Controls.Add(this.btnNhapHang);
            this.groupBox2.Controls.Add(this.txtTimKiem);
            this.groupBox2.Controls.Add(this.btnDSPhieuNhap);
            this.groupBox2.Controls.Add(this.btnXoaSP);
            this.groupBox2.Controls.Add(this.btnThemVaoPhieu);
            this.groupBox2.Controls.Add(this.dgvSanPham);
            this.groupBox2.Controls.Add(this.cbbMaPhieu);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Cascadia Code", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox2.Location = new System.Drawing.Point(12, 206);
            this.groupBox2.MaximumSize = new System.Drawing.Size(1069, 800);
            this.groupBox2.MinimumSize = new System.Drawing.Size(1069, 405);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1069, 405);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Chi tiết phiếu nhập";
            // 
            // btnThemHangMoi
            // 
            this.btnThemHangMoi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnThemHangMoi.BackColor = System.Drawing.Color.Gainsboro;
            this.btnThemHangMoi.FlatAppearance.BorderSize = 0;
            this.btnThemHangMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemHangMoi.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.btnThemHangMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemHangMoi.Location = new System.Drawing.Point(947, 326);
            this.btnThemHangMoi.Name = "btnThemHangMoi";
            this.btnThemHangMoi.Size = new System.Drawing.Size(116, 51);
            this.btnThemHangMoi.TabIndex = 11;
            this.btnThemHangMoi.Text = "Thêm hàng mới";
            this.btnThemHangMoi.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnThemHangMoi.UseVisualStyleBackColor = false;
            this.btnThemHangMoi.Click += new System.EventHandler(this.btnThemHangMoi_Click);
            // 
            // dgvTimKiem
            // 
            this.dgvTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTimKiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimKiem.Location = new System.Drawing.Point(811, 92);
            this.dgvTimKiem.Name = "dgvTimKiem";
            this.dgvTimKiem.ReadOnly = true;
            this.dgvTimKiem.Size = new System.Drawing.Size(252, 215);
            this.dgvTimKiem.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(859, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 21);
            this.label6.TabIndex = 8;
            this.label6.Text = "Tìm kiếm sản phẩm";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoi.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLamMoi.Location = new System.Drawing.Point(495, 38);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLamMoi.Size = new System.Drawing.Size(96, 41);
            this.btnLamMoi.TabIndex = 8;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLamMoi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnNhapHang
            // 
            this.btnNhapHang.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNhapHang.BackColor = System.Drawing.Color.Gainsboro;
            this.btnNhapHang.FlatAppearance.BorderSize = 0;
            this.btnNhapHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhapHang.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.btnNhapHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapHang.Location = new System.Drawing.Point(330, 336);
            this.btnNhapHang.Name = "btnNhapHang";
            this.btnNhapHang.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnNhapHang.Size = new System.Drawing.Size(114, 41);
            this.btnNhapHang.TabIndex = 8;
            this.btnNhapHang.Text = "Nhập hàng";
            this.btnNhapHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapHang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNhapHang.UseVisualStyleBackColor = false;
            this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiem.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTimKiem.Location = new System.Drawing.Point(855, 60);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(173, 26);
            this.txtTimKiem.TabIndex = 9;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // btnDSPhieuNhap
            // 
            this.btnDSPhieuNhap.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDSPhieuNhap.BackColor = System.Drawing.Color.Gainsboro;
            this.btnDSPhieuNhap.FlatAppearance.BorderSize = 0;
            this.btnDSPhieuNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDSPhieuNhap.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.btnDSPhieuNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDSPhieuNhap.Location = new System.Drawing.Point(472, 336);
            this.btnDSPhieuNhap.Name = "btnDSPhieuNhap";
            this.btnDSPhieuNhap.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDSPhieuNhap.Size = new System.Drawing.Size(215, 41);
            this.btnDSPhieuNhap.TabIndex = 8;
            this.btnDSPhieuNhap.Text = "Danh sách phiếu nhập";
            this.btnDSPhieuNhap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDSPhieuNhap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDSPhieuNhap.UseVisualStyleBackColor = false;
            this.btnDSPhieuNhap.Click += new System.EventHandler(this.btnDSPhieuNhap_Click);
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnXoaSP.BackColor = System.Drawing.Color.Gainsboro;
            this.btnXoaSP.FlatAppearance.BorderSize = 0;
            this.btnXoaSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaSP.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.btnXoaSP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaSP.Location = new System.Drawing.Point(169, 336);
            this.btnXoaSP.Name = "btnXoaSP";
            this.btnXoaSP.Size = new System.Drawing.Size(131, 41);
            this.btnXoaSP.TabIndex = 8;
            this.btnXoaSP.Text = "Xóa sản phẩm";
            this.btnXoaSP.UseVisualStyleBackColor = false;
            this.btnXoaSP.Click += new System.EventHandler(this.btnXoaSP_Click);
            // 
            // btnThemVaoPhieu
            // 
            this.btnThemVaoPhieu.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnThemVaoPhieu.BackColor = System.Drawing.Color.Gainsboro;
            this.btnThemVaoPhieu.FlatAppearance.BorderSize = 0;
            this.btnThemVaoPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemVaoPhieu.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.btnThemVaoPhieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemVaoPhieu.Location = new System.Drawing.Point(811, 326);
            this.btnThemVaoPhieu.Name = "btnThemVaoPhieu";
            this.btnThemVaoPhieu.Size = new System.Drawing.Size(119, 51);
            this.btnThemVaoPhieu.TabIndex = 8;
            this.btnThemVaoPhieu.Text = "Thêm vào phiếu";
            this.btnThemVaoPhieu.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnThemVaoPhieu.UseVisualStyleBackColor = false;
            this.btnThemVaoPhieu.Click += new System.EventHandler(this.btnThemVaoPhieu_Click);
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Location = new System.Drawing.Point(57, 92);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.Size = new System.Drawing.Size(736, 215);
            this.dgvSanPham.TabIndex = 2;
            this.dgvSanPham.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSanPham_CellFormatting);
            // 
            // cbbMaPhieu
            // 
            this.cbbMaPhieu.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbbMaPhieu.FormattingEnabled = true;
            this.cbbMaPhieu.Location = new System.Drawing.Point(194, 45);
            this.cbbMaPhieu.Name = "cbbMaPhieu";
            this.cbbMaPhieu.Size = new System.Drawing.Size(129, 29);
            this.cbbMaPhieu.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(53, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 21);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mã phiếu nhập:";
            // 
            // NhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 651);
            this.Controls.Add(this.dgvPhieuNhap);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold);
            this.Name = "NhapHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NhapHang";
            this.Load += new System.EventHandler(this.NhapHang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvPhieuNhap;
        private System.Windows.Forms.Label labelKQTimKiem;
        private System.Windows.Forms.TextBox txtMaNhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbNhanVien;
        private System.Windows.Forms.ComboBox cbbNCC;
        private System.Windows.Forms.Button btnTaoPhieu;
        private System.Windows.Forms.Button btnSuaPhieu;
        private System.Windows.Forms.Button btnXoaPhieu;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbbMaPhieu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.DataGridView dgvTimKiem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnNhapHang;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnDSPhieuNhap;
        private System.Windows.Forms.Button btnXoaSP;
        private System.Windows.Forms.Button btnThemVaoPhieu;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThemHangMoi;
        private System.Windows.Forms.Button btnTaoMaPhieu;
    }
}