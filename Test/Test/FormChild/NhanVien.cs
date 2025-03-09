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
using System.IO;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;

namespace Test.FormChild
{
    public partial class NhanVien : Form
    {
        ConnectionSQL connectionSQL = new ConnectionSQL();

        public NhanVien()
        {
            InitializeComponent();
        }

        private void loadDataNV()
        {
            string sqlKH = "SELECT " +
                "nv.maNhanVien AS [Mã nhân viên], " +
                "nv.tenNhanVien AS [Tên nhân viên], " +
                "nv.gioiTinh AS [Giới tính], " +
                "nv.soDienThoai AS [Số điện thoại], " +
                "nv.diaChi AS [Địa chỉ], " +
                "nv.ngaySinh AS [Ngày sinh], " +
                "nv.chucDanh AS [Chức danh], " +
                "ISNULL(acc.taiKhoan, 'Chưa có') AS [Tài khoản] " +
                "FROM NhanVien nv " +
                "LEFT JOIN Account acc ON nv.maNhanVien = acc.maNhanVien";

            dgvNhanVien.DataSource = connectionSQL.hienDL(sqlKH);
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                connectionSQL.open();

                // Kiểm tra mã nhân viên đã nhập chưa
                if (string.IsNullOrWhiteSpace(txtMaNV.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Kiểm tra mã khách hàng đã tồn tại
                string query = "SELECT COUNT(*) FROM NhanVien WHERE maNhanVien = @maNV";
                using (SqlCommand cmd = new SqlCommand(query, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maNV", txtMaNV.Text);
                    int count = (int)cmd.ExecuteScalar();

                    if (!(count > 0))
                    {
                        MessageBox.Show("Mã nhân viên không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string gioiTinh = radioBtnNam.Checked ? "Nam" : "Nữ";

                // Cập nhật nhân viên
                string insertQuery = "UPDATE NhanVien " +
                                     "SET tenNhanVien = @tenNV, gioiTinh = @gioiTinh, soDienThoai = @sdt, diaChi = @diaChi, ngaySinh = @ngaySinh," +
                                     " chucDanh = @chucDanh Where maNhanVien = @maNV";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, connectionSQL.conn))
                {
                    insertCmd.Parameters.AddWithValue("@maNV", txtMaNV.Text);
                    insertCmd.Parameters.AddWithValue("@tenNV", txtTenNV.Text);
                    insertCmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                    insertCmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
                    insertCmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text);
                    insertCmd.Parameters.AddWithValue("@ngaySinh", dateNgaySinh.Value.ToString("yyyy-MM-dd"));
                    insertCmd.Parameters.AddWithValue("@chucDanh", cbbChucDanh.Text);

                    insertCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Load lại dữ liệu
                loadDataNV();
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

        private void NhanVien_Load(object sender, EventArgs e)
        {
            loadDataNV();

            Function frmSach = new Function();

            cbbChucDanh.Text = "Quản lý";

            // Căn chỉnh table
            frmSach.CanChinhDGV(dgvNhanVien);
            dgvNhanVien.Columns["Tên nhân viên"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentCell != null)
            {
                int rowIndex = dgvNhanVien.CurrentCell.RowIndex;

                if (dgvNhanVien.Rows[rowIndex].IsNewRow || dgvNhanVien.Rows[rowIndex].Cells[0].Value == null)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string maNV = dgvNhanVien.Rows[rowIndex].Cells[0].Value.ToString();

                try
                {
                    connectionSQL.open();

                    // Kiểm tra chức vụ của nhân viên trong CSDL
                    string checkRoleQuery = "SELECT chucDanh FROM NhanVien WHERE maNhanVien = @maNV";
                    using (SqlCommand checkRoleCmd = new SqlCommand(checkRoleQuery, connectionSQL.conn))
                    {
                        checkRoleCmd.Parameters.AddWithValue("@maNV", maNV);
                        object roleResult = checkRoleCmd.ExecuteScalar();

                        if (roleResult != null)
                        {
                            string chucVu = roleResult.ToString().Trim();

                            // Nếu là quản lý thì không cho xóa
                            if (chucVu.ToLower() == "quản lý")
                            {
                                MessageBox.Show("Không thể xóa Quản lý!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nhân viên không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Xác nhận trước khi xóa
                    DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên {maNV}?",
                                                          "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return;
                    }

                    // Xóa nhân viên
                    string deleteQuery = "DELETE FROM NhanVien WHERE maNhanVien = @maNV";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, connectionSQL.conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@maNV", maNV);
                        int rowsAffected = deleteCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Load lại dữ liệu sau khi xóa
                            loadDataNV();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            try
            {
                connectionSQL.open();

                // Kiểm tra mã nhân viên đã nhập chưa
                if (string.IsNullOrWhiteSpace(txtMaNV.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Kiểm tra mã nhân viên đã tồn tại
                string query = "SELECT COUNT(*) FROM NhanVien WHERE maNhanVien = @maNV";
                using (SqlCommand cmd = new SqlCommand(query, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maNV", txtMaNV.Text);
                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (!(cbbChucDanh.Text == "Quản lý" || cbbChucDanh.Text == "Nhân viên" || cbbChucDanh.Text == "Thu ngân"))
                {
                    MessageBox.Show("Bạn chỉ có thể thêm Quản lý, Nhân viên hoặc Thu ngân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string gioiTinh = radioBtnNam.Checked ? "Nam" : "Nữ";

                // Thêm nhân viên mới
                string insertQuery = "INSERT INTO NhanVien (maNhanVien, tenNhanVien, gioiTinh, soDienThoai, diaChi, ngaySinh, chucDanh) " +
                     "VALUES (@maNV, @tenNV, @gioiTinh, @sdt, @diaChi, @ngaySinh, @chucDanh)";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, connectionSQL.conn))
                {
                    insertCmd.Parameters.AddWithValue("@maNV", txtMaNV.Text);
                    insertCmd.Parameters.AddWithValue("@tenNV", txtTenNV.Text);
                    insertCmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                    insertCmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
                    insertCmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text);
                    insertCmd.Parameters.AddWithValue("@ngaySinh", dateNgaySinh.Value.ToString("yyyy-MM-dd"));
                    insertCmd.Parameters.AddWithValue("@chucDanh", cbbChucDanh.Text);

                    insertCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDataNV();
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadDataNV();
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvNhanVien.CurrentRow.Index;

            txtMaNV.Text = dgvNhanVien.Rows[i].Cells[0].Value?.ToString() ?? "";
            txtTenNV.Text = dgvNhanVien.Rows[i].Cells[1].Value?.ToString() ?? "";

            if (dgvNhanVien.Rows[i].Cells[2].Value?.ToString() == "Nam")
            {
                radioBtnNam.Checked = true;
            }
            else
            {
                radioBtnNu.Checked = true;
            }

            txtSDT.Text = dgvNhanVien.Rows[i].Cells[3].Value?.ToString() ?? "";
            txtDiaChi.Text = dgvNhanVien.Rows[i].Cells[4].Value?.ToString() ?? "";

            if (DateTime.TryParse(dgvNhanVien.Rows[i].Cells[5].Value?.ToString(), out DateTime ngaySinh))
            {
                dateNgaySinh.Value = ngaySinh;
            }

            cbbChucDanh.Text = dgvNhanVien.Rows[i].Cells[6].Value?.ToString() ?? "";
            txtTaiKhoan.Text = dgvNhanVien.Rows[i].Cells[7].Value?.ToString() ?? "";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            dateNgaySinh.Value = DateTime.Now;
            radioBtnNam.Checked = false;
            radioBtnNu.Checked = false;
            txtTaiKhoan.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            cbbChucDanh.Text = "";
        }


        private void exportExcel(string path)
        {
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);

            // Tạo cột 
            for (int i = 0; i < dgvNhanVien.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dgvNhanVien.Columns[i].HeaderText;
            }
            for (int i = 0; i < dgvNhanVien.Rows.Count; i++)
            {
                for (int j = 0; j < dgvNhanVien.Columns.Count; j++)
                {
                    application.Cells[i + 2, j + 1] = dgvNhanVien.Rows[i].Cells[j].Value;
                }
            }

            application.Columns.AutoFit();
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
        }


        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Export Excel";
            save.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls";
            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    exportExcel(save.FileName);
                    MessageBox.Show("Xuất file thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xuất file không thành công!\n" + ex.Message);
                }
            }
        }

        private void btnTaoTK_Click(object sender, EventArgs e)
        {
            frmNhanVien.taoTKNhanVien taoTK = new frmNhanVien.taoTKNhanVien();
            taoTK.Show();
        }
    }
}
