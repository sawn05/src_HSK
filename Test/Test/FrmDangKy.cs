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
    public partial class FrmDangKy : Form
    {
        ConnectionSQL connectionSQL = new ConnectionSQL();
        public FrmDangKy()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.MouseDown += FrmDangKy_MouseDown;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void FrmDangKy_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            FrmDangNhap dn = new FrmDangNhap();
            this.Hide();
            dn.ShowDialog();

            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinisize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtMaNV_MouseClick(object sender, MouseEventArgs e)
        {
            txtMaNV.Clear();
        }

        private void txtMatKhau_MouseClick(object sender, MouseEventArgs e)
        {
            txtMatKhau.Clear();
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.ForeColor = Color.FromArgb(38, 65, 94);
        }

        private void txtTaiKhoan_MouseClick(object sender, MouseEventArgs e)
        {
            txtTaiKhoan.Clear();
        }

        private void txtTaiKhoan_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                txtTaiKhoan.Text = "Nhập tài khoản";
                txtTaiKhoan.PasswordChar = '\0';
                txtTaiKhoan.ForeColor = Color.FromArgb(38, 65, 94);
            }
        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                txtMatKhau.Text = "Nhập mật khẩu";
                txtMatKhau.PasswordChar = '\0';
                txtMatKhau.ForeColor = Color.FromArgb(38, 65, 94);
            }
        }

        private void txtMaNV_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                txtMaNV.Text = "Nhập mã nhân viên của bạn";
                txtMaNV.PasswordChar = '\0';
                txtMaNV.ForeColor = Color.FromArgb(38, 65, 94);
            }
        }


        private void checkBoxHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (txtMatKhau.Text.Trim() != "Nhập mật khẩu")
            {
                txtMatKhau.PasswordChar = checkBoxHienMK.Checked ? '\0' : '*';
            }
            else
            {
                txtMatKhau.PasswordChar = '\0';
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTaiKhoan.Text) || string.IsNullOrEmpty(txtMatKhau.Text) ||
                string.IsNullOrEmpty(txtMaNV.Text) || txtMatKhau.Text.Trim() == "Nhập mật khẩu"
                || txtTaiKhoan.Text.Trim() == "Nhập tài khoản" || txtMaNV.Text.Trim() == "Nhập mã nhân viên của bạn")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    connectionSQL.open();

                    // Kiểm tra tài khoản và nhân viên
                    string query = "SELECT " +
                                   "(SELECT COUNT(*) FROM Account WHERE taiKhoan = @tk) AS CountTK, " +
                                   "(SELECT COUNT(*) FROM Account WHERE maNhanVien = @maNV) AS CountNV";

                    using (SqlCommand cmd = new SqlCommand(query, connectionSQL.conn))
                    {
                        cmd.Parameters.AddWithValue("@tk", txtTaiKhoan.Text);
                        cmd.Parameters.AddWithValue("@maNV", txtMaNV.Text);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int countTK = reader.GetInt32(0);
                                int countNV = reader.GetInt32(1);

                                if (countTK > 0)
                                {
                                    MessageBox.Show("Tài khoản nhân viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                if (countNV > 0)
                                {
                                    MessageBox.Show("Nhân viên này đã có tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }
                    }

                    // Kiểm tra mã nhân viên có tồn tại không
                    string queryNV = "SELECT COUNT(*) FROM NhanVien WHERE maNhanVien = @maNV";
                    using (SqlCommand cmd = new SqlCommand(queryNV, connectionSQL.conn))
                    {
                        cmd.Parameters.AddWithValue("@maNV", txtMaNV.Text);
                        int count = (int)cmd.ExecuteScalar();

                        if (count <= 0)
                        {
                            MessageBox.Show("Vui lòng nhập đúng mã nhân viên của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Thêm tài khoản mới
                    string insertQuery = "INSERT INTO Account (taiKhoan, matKhau, maNhanVien) " +
                                     "VALUES (@taiKhoan, @matKhau, @maNhanVien)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, connectionSQL.conn))
                    {
                        insertCmd.Parameters.AddWithValue("@taiKhoan", txtTaiKhoan.Text);
                        insertCmd.Parameters.AddWithValue("@matKhau", txtMatKhau.Text);
                        insertCmd.Parameters.AddWithValue("@maNhanVien", txtMaNV.Text);
                        insertCmd.ExecuteNonQuery();
                    }

                    DialogResult result = MessageBox.Show("Thêm thành công! Bạn có muốn đăng nhập luôn không?",
                                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        FrmDangNhap dn = new FrmDangNhap();
                        this.Hide();
                        dn.ShowDialog();

                        this.Show();
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
    }
}
