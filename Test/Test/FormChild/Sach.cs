﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.FormChild
{
    public partial class Sach : Form
    {
        private string maNV = "";
        public Sach(string maNVBanHang)
        {
            InitializeComponent();
            maNV = maNVBanHang;
        }

        ConnectionSQL connectionSQL = new ConnectionSQL();


        private void Sach_Load(object sender, EventArgs e)
        {
            cbbTimKiem.Text = "Tên sách";
            Function function = new Function();

            // Load data sách
            loadDataSach();

            // Căn chỉnh table
            function.CanChinhDGV(dgvSach);
            dgvSach.Columns["Tên sách"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        // Load table Sách
        private void loadDataSach()
        {
            string sqlSach = "Select " +
                "maSanPham AS [Mã sách], " +
                "tenSanPham AS [Tên sách], " +
                "soLuongTon AS [SL tồn], " +
                "gia AS [Đơn giá] " +
                "from SanPham Where maTheLoai = 'SACH'";

            dgvSach.DataSource = connectionSQL.hienDL(sqlSach);
        }


        private void dgvSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvSach.CurrentRow.Index;

            txtMaSach.Text = dgvSach.Rows[i].Cells[0].Value?.ToString() ?? "";
            txtTenSach.Text = dgvSach.Rows[i].Cells[1].Value?.ToString() ?? "";

            // Xử lý Đơn giá để không lỗi
            if (dgvSach.Rows[i].Cells[3].Value != null)
            {
                decimal donGia;
                if (decimal.TryParse(dgvSach.Rows[i].Cells[3].Value.ToString(), out donGia))
                {
                    txtDonGia.Text = donGia.ToString("N0");
                }
                else
                {
                    txtDonGia.Text = "0";
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (cbbTimKiem.Text == "Tên sách")
            {
                string sqlSach = "Select " +
                    "maSanPham AS [Mã sách]," +
                    "tenSanPham AS [Tên sách]," +
                    "soLuongTon AS [Số lượng tồn]," +
                    "gia AS [Đơn giá]" +
                    "FROM SanPham WHERE maTheLoai = 'SACH' and tenSanPham LIKE N'%" + txtTimKiem.Text.Trim() + "%'";

                dgvSach.DataSource = connectionSQL.hienDL(sqlSach);
                labelKQTimKiem.Text = $"Kết quả tìm thấy: {dgvSach.Rows.Count}";
            }
            if (cbbTimKiem.Text == "Mã sách")
            {
                string sqlSach = "Select " +
                    "maSanPham AS [Mã sách]," +
                    "tenSanPham AS [Tên sách]," +
                    "soLuongTon AS [Số lượng tồn]," +
                    "gia AS [Đơn giá]" +
                    "FROM SanPham WHERE maTheLoai = 'SACH' and maSanPham LIKE N'%" + txtTimKiem.Text.Trim() + "%'";

                dgvSach.DataSource = connectionSQL.hienDL(sqlSach);
                labelKQTimKiem.Text = $"Kết quả tìm thấy: {dgvSach.Rows.Count}";
            }
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
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

        private void dgvSach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal gia))
                {
                    e.Value = gia.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
        }


        private void btnLoadData_Click(object sender, EventArgs e)
        {
            loadDataSach();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (maNV != "NV001")
                {
                    MessageBox.Show("Bạn phải được cấp quyền này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra rỗng
                string maSanPham = txtMaSach.Text.Trim();

                if (string.IsNullOrEmpty(maSanPham))
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                connectionSQL.open();
                string sql = "Update SanPham Set tenSanPham = @tenSP, gia = @donGia" +
                    " Where maSanPham = @maSP";
                SqlCommand sqlCommand = new SqlCommand(sql, connectionSQL.conn);
                sqlCommand.Parameters.AddWithValue("maSP", txtMaSach.Text);
                sqlCommand.Parameters.AddWithValue("tenSP", txtTenSach.Text);
                sqlCommand.Parameters.AddWithValue("donGia", txtDonGia.Text);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại DataGridView
                loadDataSach();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (maNV != "NV001")
                {
                    MessageBox.Show("Bạn phải được cấp quyền này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maSP = txtMaSach.Text.Trim();

                if (string.IsNullOrEmpty(maSP))
                {
                    MessageBox.Show("Vui lòng chọn mã sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                connectionSQL.open();

                // Kiểm tra mã sản phẩm có tồn tại không
                string queryCheck = "SELECT COUNT(*) FROM SanPham WHERE maSanPham = @maSP";
                using (SqlCommand checkCmd = new SqlCommand(queryCheck, connectionSQL.conn))
                {
                    checkCmd.Parameters.AddWithValue("@maSP", maSP);
                    int exists = (int)checkCmd.ExecuteScalar();

                    if (exists == 0)
                    {
                        MessageBox.Show("Mã sản phẩm không tồn tại trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa",
                                                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.No)
                        {
                            return;
                        }

                        string queryDelete = "DELETE FROM SanPham WHERE maSanPham = @maSP";
                        using (SqlCommand deleteCmd = new SqlCommand(queryDelete, connectionSQL.conn))
                        {
                            deleteCmd.Parameters.AddWithValue("@maSP", maSP);
                            int rowsAffected = deleteCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Xóa thất bại, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        loadDataSach();
                    }
                }

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

        private void btnThemVaoGioHang_Click(object sender, EventArgs e)
        {
            try
            {
                connectionSQL.open();

                // Kiểm tra xem mã sản phẩm đã nhập chưa
                if (string.IsNullOrWhiteSpace(txtMaSach.Text))
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string maSP = txtMaSach.Text;
                string tenSP = txtTenSach.Text;


                // Kiểm tra số lượng mua
                int soLuongMua = (int)numSoLuong.Value;

                if (soLuongMua == 0)
                {
                    MessageBox.Show("Vui lòng nhập số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Lấy số lượng tồn kho từ bảng SanPham
                int soLuongTon = 0;
                string queryTonKho = "SELECT soLuongTon FROM SanPham WHERE maSanPham = @maSP";
                using (SqlCommand cmdTonKho = new SqlCommand(queryTonKho, connectionSQL.conn))
                {
                    cmdTonKho.Parameters.AddWithValue("@maSP", maSP);
                    object result = cmdTonKho.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        soLuongTon = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm không tồn tại trong kho!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (soLuongMua > soLuongTon)
                {
                    MessageBox.Show("Số lượng sản phẩm trong kho không đủ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal donGia = 0;
                // Lấy thông tin sản phẩm từ bảng SanPham
                string query = "SELECT tenSanPham, gia FROM SanPham WHERE maSanPham = @maSP";
                using (SqlCommand cmd = new SqlCommand(query, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maSP", maSP);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tenSP = reader["tenSanPham"].ToString();
                            donGia = Convert.ToDecimal(reader["gia"]);
                        }
                        else
                        {
                            MessageBox.Show("Sản phẩm không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                // Thêm sản phẩm vào giỏ hàng
                string insertQuery = "INSERT INTO GioHang (maSP, tenSP, soLuong, donGia) VALUES (@maSP, @tenSP, @soLuong, @donGia)";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, connectionSQL.conn))
                {
                    insertCmd.Parameters.AddWithValue("@maSP", maSP);
                    insertCmd.Parameters.AddWithValue("@tenSP", tenSP);
                    insertCmd.Parameters.AddWithValue("@soLuong", soLuongMua);
                    insertCmd.Parameters.AddWithValue("@donGia", donGia);

                    insertCmd.ExecuteNonQuery();
                }

                // Update tồn kho
                string sqlUpdateSanPham = "Update SanPham SET soLuongTon = soLuongTon - @slMua Where maSanPham = @maSP";
                using (SqlCommand updateCmd = new SqlCommand(sqlUpdateSanPham, connectionSQL.conn))
                {
                    updateCmd.Parameters.AddWithValue("@slMua", soLuongMua);
                    updateCmd.Parameters.AddWithValue("@maSP", maSP);
                    updateCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm vào giỏ hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                loadDataSach();
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

        private void txtTimKiem_MouseClick(object sender, MouseEventArgs e)
        {
            txtTimKiem.Text = "";
        }
    }
}
