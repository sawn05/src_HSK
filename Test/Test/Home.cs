using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Home : Form
    {
        private Form activeForm = null;
        private string maNvBanHang = "";

        public Home(string tenNV, string maNhanVien)
        {
            InitializeComponent();
            productDesign();

            lbTenNVBanHang.Text = "Xin chào: " + tenNV;
            maNvBanHang = maNhanVien;
        }

        private void productDesign()
        {
            panelDanhMuc.Visible = false;
        }

        private void anSanPham()
        {
            if (panelDanhMuc.Visible == true)
            {
                panelDanhMuc.Visible = false;
            }
        }

        private void hienSanPham(Panel panelDanhMuc)
        {
            if (panelDanhMuc.Visible == false)
            {
                anSanPham();
                panelDanhMuc.Visible = true;
            }
            else
            {
                panelDanhMuc.Visible = false;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null && activeForm.GetType() == childForm.GetType())
                return;

            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm; 

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelContainer.Controls.Clear(); 
            this.panelContainer.Controls.Add(childForm); 
            this.panelContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void ResetButtonColors()
        {
            btnDanhMuc.BackColor = Color.FromArgb(174, 220, 222);
            btnNhapHang.BackColor = Color.FromArgb(174, 220, 222);
            btnNhanVien.BackColor = Color.FromArgb(174, 220, 222);
            btnGioHang.BackColor = Color.FromArgb(174, 220, 222);
            btnKhachHang.BackColor = Color.FromArgb(174, 220, 222);
            btnTKHoaDon.BackColor = Color.FromArgb(174, 220, 222);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = string.Empty;
            this.ControlBox = false;

            if (maNvBanHang != "NV001")
            {
                btnNhanVien.Visible = false;
                btnNhapHang.Visible = false;
            }
        }

        private void Reset()
        {
            lbTitle.Text = "CHÀO MỪNG BẠN ĐẾN VỚI CỬA HÀNG SÁCH HAPIBOOK";

            // Show pictureBox1
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(pictureBox1);
            pictureBox1.Dock = DockStyle.None;

            ResetButtonColors();
            if (btnDanhMuc.Enabled == true)
            {
                anSanPham();
            }
            else
            {
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            hienSanPham(panelDanhMuc);
            ResetButtonColors();
            btnDanhMuc.BackColor = Color.FromArgb(156, 197, 199);
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnDanhMuc.BackColor = Color.FromArgb(156, 197, 199);
            lbTitle.Text = "Sách";
            OpenChildForm(new FormChild.Sach(maNvBanHang));
        }


        private void btnTCVB_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnDanhMuc.BackColor = Color.FromArgb(156, 197, 199);
            lbTitle.Text = "Tạp chí và báo";
            OpenChildForm(new FormChild.TCVB(maNvBanHang));
        }

        private void btnTruyen_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnDanhMuc.BackColor = Color.FromArgb(156, 197, 199);
            lbTitle.Text = "Truyện";
            OpenChildForm(new FormChild.Truyen(maNvBanHang));
        }

        private void btnDCGD_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnDanhMuc.BackColor = Color.FromArgb(156, 197, 199);
            lbTitle.Text = "Đồ chơi giáo dục";
            OpenChildForm(new FormChild.DoChoiGD(maNvBanHang));
        }

        private void btnDCHT_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnDanhMuc.BackColor = Color.FromArgb(156, 197, 199);
            lbTitle.Text = "Dụng cụ học tập";
            OpenChildForm(new FormChild.DungCuHocTap(maNvBanHang));
        }

        private void btnTBCongNghe_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnDanhMuc.BackColor = Color.FromArgb(156, 197, 199);
            lbTitle.Text = "Thiết bị công nghệ";
            OpenChildForm(new FormChild.TBCN(maNvBanHang));
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                Reset();
            }
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            anSanPham();
            lbTitle.Text = "Nhập hàng";
            ResetButtonColors();
            btnNhapHang.BackColor = Color.FromArgb(156, 197, 199);
            OpenChildForm(new FormChild.NhapHang());
        }

        private void btnGioHang_Click(object sender, EventArgs e)
        {
            anSanPham();
            lbTitle.Text = "Giỏ hàng";
            ResetButtonColors();
            btnGioHang.BackColor = Color.FromArgb(156, 197, 199);
            OpenChildForm(new FormChild.GioHang(maNvBanHang));
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            anSanPham();
            lbTitle.Text = "Danh sách nhân viên";
            ResetButtonColors();
            btnNhanVien.BackColor = Color.FromArgb(156, 197, 199);
            OpenChildForm(new FormChild.NhanVien());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            anSanPham();
            lbTitle.Text = "Danh sách khách hàng";
            ResetButtonColors();
            btnKhachHang.BackColor = Color.FromArgb(156, 197, 199);
            OpenChildForm(new FormChild.KhachHang());
        }

        private void panelLeft_Scroll(object sender, ScrollEventArgs e)
        {
            picLogo.Location = new Point(pictureBox1.Location.X, -panelLeft.AutoScrollPosition.Y);
        }

        private void btnTKHoaDon_Click(object sender, EventArgs e)
        {
            anSanPham();
            lbTitle.Text = "Danh sách hóa đơn";
            ResetButtonColors();
            btnTKHoaDon.BackColor = Color.FromArgb(156, 197, 199);
            OpenChildForm(new FormChild.ThongKeHD(maNvBanHang));
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?",
                                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }

}
