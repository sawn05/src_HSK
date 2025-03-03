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

namespace Test.frmPhieuNhap
{
    public partial class ThemSanPham : Form
    {
        ConnectionSQL connectionSQL = new ConnectionSQL();

        public ThemSanPham()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimun_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtDonGiaBan_TextChanged(object sender, EventArgs e)
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
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            cbbMaTheLoai.Text = "";
            cbbNhaCungCap.Text = "";
            txtDonGiaBan.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                connectionSQL.open();

                // Kiểm tra mã sản phẩm đã nhập chưa
                if (string.IsNullOrWhiteSpace(txtMaSP.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Kiểm tra mã sản phẩm đã tồn tại
                string query = "SELECT COUNT(*) FROM SanPham WHERE maSanPham = @maSP";
                using (SqlCommand cmd = new SqlCommand(query, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maSP", txtMaSP.Text);
                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Mã sản phẩm đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }


                // Thêm sản phẩm mới
                string insertQuery = "INSERT INTO SanPham (maSanPham, tenSanPham, maTheLoai, maNhaCungCap, gia) " +
                                     "VALUES (@maSanPham, @tenSanPham, @maTheLoai, @maNhaCungCap, @gia)";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, connectionSQL.conn))
                {
                    insertCmd.Parameters.AddWithValue("@maSanPham", txtMaSP.Text);
                    insertCmd.Parameters.AddWithValue("@tenSanPham", txtTenSP.Text);
                    insertCmd.Parameters.AddWithValue("@maTheLoai", cbbMaTheLoai.Text);
                    insertCmd.Parameters.AddWithValue("@maNhaCungCap", cbbNhaCungCap.Text);
                    insertCmd.Parameters.AddWithValue("@gia", txtDonGiaBan.Text);

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

        private void ThemSanPham_Load(object sender, EventArgs e)
        {
            cbbNhaCungCap.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbMaTheLoai.DropDownStyle = ComboBoxStyle.DropDownList;

            fillMaTheLoai();
            fillNhaCC();

            this.Text = string.Empty;
            this.ControlBox = false;
        }

        private void fillNhaCC()
        {
            cbbNhaCungCap.Items.Clear();

            string query = "SELECT DISTINCT maNhaCungCap FROM NhaCungCap";
            DataTable dt = connectionSQL.hienDL(query);
            foreach (DataRow row in dt.Rows)
            {
                cbbNhaCungCap.Items.Add(row["maNhaCungCap"].ToString());
            }
        }

        private void fillMaTheLoai()
        {
            cbbMaTheLoai.Items.Clear();

            string query = "SELECT DISTINCT maTheLoai FROM TheLoai";
            DataTable dt = connectionSQL.hienDL(query);
            foreach (DataRow row in dt.Rows)
            {
                cbbMaTheLoai.Items.Add(row["maTheLoai"].ToString());
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
