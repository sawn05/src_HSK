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

namespace Test
{
    public partial class themKhachHang : Form
    {

        ConnectionSQL connectionSQL = new ConnectionSQL();

        public themKhachHang()
        {
            InitializeComponent();

            this.Text = string.Empty;
            this.ControlBox = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                connectionSQL.open();

                // Kiểm tra mã khách hàng đã nhập chưa
                if (string.IsNullOrWhiteSpace(txtMaKH.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Kiểm tra mã khách hàng đã tồn tại
                string query = "SELECT COUNT(*) FROM KhachHang WHERE maKhachHang = @maKH";
                using (SqlCommand cmd = new SqlCommand(query, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maKH", txtMaKH.Text);
                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Mã khách hàng đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string gioiTinh = radioBtnNam.Checked ? "Nam" : "Nữ";

                // Thêm khách hàng mới
                string insertQuery = "INSERT INTO KhachHang (maKhachHang, tenKhachHang, gioiTinh, soDienThoai, diaChi) " +
                                     "VALUES (@maKH, @tenKH, @gioiTinh, @sdt, @diaChi)";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, connectionSQL.conn))
                {
                    insertCmd.Parameters.AddWithValue("@maKH", txtMaKH.Text);
                    insertCmd.Parameters.AddWithValue("@tenKH", txtTenKH.Text);
                    insertCmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                    insertCmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
                    insertCmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text);

                    insertCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null) return;

            string text = txt.Text;

            int dotCount = text.Count(c => c == '.' || c == ',');
            if (dotCount > 1)
            {
                txt.Text = text.Remove(text.LastIndexOfAny(new char[] { '.', ',' }));
                txt.SelectionStart = txt.Text.Length;
                return;
            }

            if (!decimal.TryParse(text, out _))
            {
                txt.Text = new string(text.Where(c => char.IsDigit(c) || c == '.' || c == ',').ToArray());
                txt.SelectionStart = txt.Text.Length;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            radioBtnNam.Checked = false;
            radioBtnNu.Checked = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimun_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
