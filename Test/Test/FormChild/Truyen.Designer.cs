
namespace Test.FormChild
{
    partial class Truyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Truyen));
            this.dgvTruyen = new System.Windows.Forms.DataGridView();
            this.grbTTTruyen = new System.Windows.Forms.GroupBox();
            this.txtMaTruyen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenTruyen = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.grbTimKiem = new System.Windows.Forms.GroupBox();
            this.cbbTimKiem = new System.Windows.Forms.ComboBox();
            this.labelKQTimKiem = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThemVaoGioHang = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnLoadData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTruyen)).BeginInit();
            this.grbTTTruyen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            this.grbTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTruyen
            // 
            this.dgvTruyen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTruyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTruyen.Location = new System.Drawing.Point(156, 292);
            this.dgvTruyen.Name = "dgvTruyen";
            this.dgvTruyen.ReadOnly = true;
            this.dgvTruyen.RowHeadersWidth = 51;
            this.dgvTruyen.RowTemplate.Height = 24;
            this.dgvTruyen.Size = new System.Drawing.Size(771, 338);
            this.dgvTruyen.TabIndex = 1;
            this.dgvTruyen.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTruyen_CellContentClick);
            this.dgvTruyen.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTruyen_CellFormatting);
            // 
            // grbTTTruyen
            // 
            this.grbTTTruyen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grbTTTruyen.Controls.Add(this.txtMaTruyen);
            this.grbTTTruyen.Controls.Add(this.label1);
            this.grbTTTruyen.Controls.Add(this.label4);
            this.grbTTTruyen.Controls.Add(this.label2);
            this.grbTTTruyen.Controls.Add(this.label3);
            this.grbTTTruyen.Controls.Add(this.txtTenTruyen);
            this.grbTTTruyen.Controls.Add(this.txtDonGia);
            this.grbTTTruyen.Controls.Add(this.numSoLuong);
            this.grbTTTruyen.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grbTTTruyen.Location = new System.Drawing.Point(156, 85);
            this.grbTTTruyen.Name = "grbTTTruyen";
            this.grbTTTruyen.Size = new System.Drawing.Size(375, 181);
            this.grbTTTruyen.TabIndex = 3;
            this.grbTTTruyen.TabStop = false;
            this.grbTTTruyen.Text = "Thông tin";
            // 
            // txtMaTruyen
            // 
            this.txtMaTruyen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaTruyen.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtMaTruyen.Location = new System.Drawing.Point(141, 39);
            this.txtMaTruyen.Name = "txtMaTruyen";
            this.txtMaTruyen.ReadOnly = true;
            this.txtMaTruyen.Size = new System.Drawing.Size(203, 26);
            this.txtMaTruyen.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(26, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã truyện:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(26, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tên truyện:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(26, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số lượng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(26, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Đơn giá:";
            // 
            // txtTenTruyen
            // 
            this.txtTenTruyen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenTruyen.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTenTruyen.Location = new System.Drawing.Point(141, 71);
            this.txtTenTruyen.Name = "txtTenTruyen";
            this.txtTenTruyen.Size = new System.Drawing.Size(203, 26);
            this.txtTenTruyen.TabIndex = 4;
            // 
            // txtDonGia
            // 
            this.txtDonGia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDonGia.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtDonGia.Location = new System.Drawing.Point(141, 140);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(106, 26);
            this.txtDonGia.TabIndex = 6;
            this.txtDonGia.TextChanged += new System.EventHandler(this.txtDonGia_TextChanged);
            // 
            // numSoLuong
            // 
            this.numSoLuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numSoLuong.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.numSoLuong.Location = new System.Drawing.Point(141, 105);
            this.numSoLuong.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(58, 26);
            this.numSoLuong.TabIndex = 5;
            // 
            // grbTimKiem
            // 
            this.grbTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grbTimKiem.Controls.Add(this.cbbTimKiem);
            this.grbTimKiem.Controls.Add(this.labelKQTimKiem);
            this.grbTimKiem.Controls.Add(this.label6);
            this.grbTimKiem.Controls.Add(this.txtTimKiem);
            this.grbTimKiem.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grbTimKiem.Location = new System.Drawing.Point(625, 85);
            this.grbTimKiem.Name = "grbTimKiem";
            this.grbTimKiem.Size = new System.Drawing.Size(302, 181);
            this.grbTimKiem.TabIndex = 4;
            this.grbTimKiem.TabStop = false;
            this.grbTimKiem.Text = "Tìm kiếm theo";
            // 
            // cbbTimKiem
            // 
            this.cbbTimKiem.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbbTimKiem.FormattingEnabled = true;
            this.cbbTimKiem.Items.AddRange(new object[] {
            "Tên truyện",
            "Mã truyện"});
            this.cbbTimKiem.Location = new System.Drawing.Point(30, 39);
            this.cbbTimKiem.Name = "cbbTimKiem";
            this.cbbTimKiem.Size = new System.Drawing.Size(121, 29);
            this.cbbTimKiem.TabIndex = 1;
            // 
            // labelKQTimKiem
            // 
            this.labelKQTimKiem.AutoSize = true;
            this.labelKQTimKiem.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelKQTimKiem.Location = new System.Drawing.Point(26, 142);
            this.labelKQTimKiem.Name = "labelKQTimKiem";
            this.labelKQTimKiem.Size = new System.Drawing.Size(154, 21);
            this.labelKQTimKiem.TabIndex = 2;
            this.labelKQTimKiem.Text = "Kết quả tìm thấy";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(26, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(226, 21);
            this.label6.TabIndex = 2;
            this.label6.Text = "Nhập từ khóa để tìm kiếm";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiem.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTimKiem.Location = new System.Drawing.Point(27, 107);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(217, 26);
            this.txtTimKiem.TabIndex = 2;
            this.txtTimKiem.Text = " Nhập từ khóa....";
            this.txtTimKiem.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtTimKiem_MouseClick);
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSua.Location = new System.Drawing.Point(1025, 267);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(56, 57);
            this.btnSua.TabIndex = 13;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.BackColor = System.Drawing.Color.Gainsboro;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnXoa.Location = new System.Drawing.Point(1025, 331);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(56, 54);
            this.btnXoa.TabIndex = 13;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThemVaoGioHang
            // 
            this.btnThemVaoGioHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemVaoGioHang.BackColor = System.Drawing.Color.Gainsboro;
            this.btnThemVaoGioHang.FlatAppearance.BorderSize = 0;
            this.btnThemVaoGioHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemVaoGioHang.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThemVaoGioHang.Image = ((System.Drawing.Image)(resources.GetObject("btnThemVaoGioHang.Image")));
            this.btnThemVaoGioHang.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnThemVaoGioHang.Location = new System.Drawing.Point(1025, 391);
            this.btnThemVaoGioHang.Name = "btnThemVaoGioHang";
            this.btnThemVaoGioHang.Size = new System.Drawing.Size(56, 114);
            this.btnThemVaoGioHang.TabIndex = 13;
            this.btnThemVaoGioHang.Text = "Thêm vào giỏ hàng";
            this.btnThemVaoGioHang.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnThemVaoGioHang.UseVisualStyleBackColor = false;
            this.btnThemVaoGioHang.Click += new System.EventHandler(this.btnThemVaoGioHang_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.Font = new System.Drawing.Font("Cascadia Code", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(196, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(820, 47);
            this.label5.TabIndex = 14;
            this.label5.Text = "\"Những gì sách dạy chúng ta cũng giống như lửa. Chúng ta lấy nó từ nhà hàng xóm, " +
    "thắp nó trong nhà ta, đem nó truyền cho người khác và nó trở thành tài sản của t" +
    "ất cả mọi người.\" - Voltaire";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(139, 24);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(51, 39);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 20;
            this.pictureBox4.TabStop = false;
            // 
            // btnLoadData
            // 
            this.btnLoadData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(223)))), ((int)(((byte)(203)))));
            this.btnLoadData.FlatAppearance.BorderSize = 0;
            this.btnLoadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadData.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLoadData.Location = new System.Drawing.Point(101, 292);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(49, 71);
            this.btnLoadData.TabIndex = 31;
            this.btnLoadData.Text = "Cập nhật bảng";
            this.btnLoadData.UseVisualStyleBackColor = false;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // Truyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 651);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnThemVaoGioHang);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.grbTimKiem);
            this.Controls.Add(this.grbTTTruyen);
            this.Controls.Add(this.dgvTruyen);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold);
            this.MinimumSize = new System.Drawing.Size(1109, 690);
            this.Name = "Truyen";
            this.Text = "Truyen";
            this.Load += new System.EventHandler(this.Truyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTruyen)).EndInit();
            this.grbTTTruyen.ResumeLayout(false);
            this.grbTTTruyen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            this.grbTimKiem.ResumeLayout(false);
            this.grbTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTruyen;
        private System.Windows.Forms.GroupBox grbTTTruyen;
        private System.Windows.Forms.TextBox txtMaTruyen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenTruyen;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.GroupBox grbTimKiem;
        private System.Windows.Forms.ComboBox cbbTimKiem;
        private System.Windows.Forms.Label labelKQTimKiem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThemVaoGioHang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btnLoadData;
    }
}