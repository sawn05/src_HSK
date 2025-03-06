using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.frmNhanVien
{
    public partial class taoTKNhanVien : Form
    {
        ConnectionSQL connectionSQL = new ConnectionSQL();

        public taoTKNhanVien()
        {
            InitializeComponent();

            this.Text = string.Empty;
            this.ControlBox = false;
        }

        private void btnMinimun_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximun_Click(object sender, EventArgs e)
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fillCBB()
        {
            cbbMaNV.Items.Clear();

            string query = "SELECT maNhanVien FROM NhanVien";
            DataTable dt = connectionSQL.hienDL(query);
            foreach (DataRow row in dt.Rows)
            {
                cbbMaNV.Items.Add(row["maNhanVien"].ToString());
            }
        }

        private void taoTK_Load(object sender, EventArgs e)
        {
            fillCBB();
            cbbMaNV.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            string maNV = cbbMaNV.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Vui lòng chọn mã nhân viên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtTaiKhoan.Text.Trim() == "" || txtMatKhau.Text.Trim() == "" || (txtTaiKhoan.Text.Trim() == "" && txtMatKhau.Text.Trim() == ""))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản và mật khẩu!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra nhân viên đã có tài khoản chưa
            string checkAccount = "SELECT COUNT(*) FROM Account WHERE maNhanVien = @maNV";

            SqlCommand cmd = new SqlCommand(checkAccount, connectionSQL.conn);
            cmd.Parameters.AddWithValue("@maNV", maNV);

            connectionSQL.open();
            int count = (int)cmd.ExecuteScalar();
            connectionSQL.close();

            // Có tài khoản
            if (count > 0)
            {
                MessageBox.Show("Nhân viên này đã có tài khoản!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    connectionSQL.open();

                    // Thêm tài khoản mới
                    string insertQuery = "INSERT INTO Account (taiKhoan, matKhau, maNhanVien) " +
                         "VALUES (@taiKhoan, @matKhau, @maNhanVien)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, connectionSQL.conn))
                    {
                        insertCmd.Parameters.AddWithValue("@maNhanVien", cbbMaNV.Text);
                        insertCmd.Parameters.AddWithValue("@taiKhoan", txtTaiKhoan.Text);
                        insertCmd.Parameters.AddWithValue("@matKhau", txtMatKhau.Text);

                        insertCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Tạo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connectionSQL.close();
                }
            }
        }

    }
}
