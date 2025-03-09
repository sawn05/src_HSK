using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace Test
{
    public partial class FrmDangNhap : Form
    {
        ConnectionSQL connectionSQL = new ConnectionSQL();

        public FrmDangNhap()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.MouseDown += FrmLogin_MouseDown;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinisize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTaiKhoan.Text) || string.IsNullOrEmpty(txtMatKhau.Text) || txtMatKhau.Text.Trim() == "Mật khẩu"
                || txtTaiKhoan.Text.Trim() == "Tài khoản")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản và mật khẩu của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    connectionSQL.open();

                    // Kiểm tra tài khoản & mật khẩu
                    string sqlCheck = "SELECT * FROM Account WHERE taiKhoan = @taiKhoan AND matKhau = @matKhau";
                    using (SqlCommand cmd = new SqlCommand(sqlCheck, connectionSQL.conn))
                    {
                        cmd.Parameters.AddWithValue("@taiKhoan", txtTaiKhoan.Text);
                        cmd.Parameters.AddWithValue("@matKhau", txtMatKhau.Text);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string maNhanVien = reader["maNhanVien"].ToString();
                                reader.Close();

                                // Lấy tên nhân viên
                                string tenNhanVien = "";
                                string sqlTenNV = "SELECT tenNhanVien FROM NhanVien WHERE maNhanVien = @maNV";
                                using (SqlCommand cmdNV = new SqlCommand(sqlTenNV, connectionSQL.conn))
                                {
                                    cmdNV.Parameters.AddWithValue("@maNV", maNhanVien);
                                    object result = cmdNV.ExecuteScalar();
                                    if (result != null)
                                    {
                                        tenNhanVien = result.ToString();
                                    }
                                }

                                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Home home = new Home(tenNhanVien, maNhanVien);
                                this.Hide();
                                home.ShowDialog();
                                this.Show();
                            }
                            else
                            {
                                MessageBox.Show("Thông tin tài khoản hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    connectionSQL.close();
                }
            }

        }

        private void txtTaiKhoan_MouseClick(object sender, MouseEventArgs e)
        {
            txtTaiKhoan.Clear();
        }

        private void checkBoxHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (txtMatKhau.Text.Trim() != "Mật khẩu")
            {
                txtMatKhau.PasswordChar = checkBoxHienMK.Checked ? '\0' : '*';
            }
            else
            {
                txtMatKhau.PasswordChar = '\0';
            }
        }


        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                txtMatKhau.Text = "Mật khẩu";
                txtMatKhau.PasswordChar = '\0';
                txtMatKhau.ForeColor = Color.FromArgb(38, 65, 94);
            }
        }

        private void txtMatKhau_MouseClick(object sender, MouseEventArgs e)
        {
            txtMatKhau.Clear();
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.ForeColor = Color.FromArgb(38, 65, 94);
        }

        private void txtTaiKhoan_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                txtTaiKhoan.Text = "Tài khoản";
                txtTaiKhoan.PasswordChar = '\0';
                txtTaiKhoan.ForeColor = Color.FromArgb(38, 65, 94);
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            FrmDangKy dk = new FrmDangKy();
            this.Hide();
            dk.ShowDialog(); 
        }
    }
}
