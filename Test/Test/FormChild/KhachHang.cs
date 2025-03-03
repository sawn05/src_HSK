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
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }

        ConnectionSQL connectionSQL = new ConnectionSQL();

        private void loadDataKH()
        {
            string sqlKH = "Select " +
                "maKhachHang AS [Mã khách hàng]," +
                "tenKhachHang AS [Tên khách hàng]," +
                "gioiTinh AS [Giới tính]," +
                "soDienThoai AS [Số điện thoại]," +
                "diaChi AS [Địa chỉ]," +
                "tongTienDaMua AS [Tổng tiền đã mua]" +
                " from KhachHang";
            dgvKhachHang.DataSource = connectionSQL.hienDL(sqlKH);
        }

        private void txtStart_TextChanged(object sender, EventArgs e)
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

            filterData();
        }

        private void txtEnd_TextChanged(object sender, EventArgs e)
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

            filterData();
        }

        private void fillCBB()
        {
            cbbLocDiaChi.Items.Clear();

            string query = "SELECT DISTINCT diaChi FROM KhachHang";
            DataTable dt = connectionSQL.hienDL(query);
            foreach (DataRow row in dt.Rows)
            {
                cbbLocDiaChi.Items.Add(row["diaChi"].ToString());
            }
        }



        private void KhachHang_Load(object sender, EventArgs e)
        {
            cbbTimKiem.Text = " Mã khách hàng";

            FormChild.Sach frmSach = new FormChild.Sach();
            frmSach.SetPlaceholder(txtTimKiem, " Nhập từ khóa....");

            loadDataKH();
            fillCBB(); // Hiện dữ liệu địa chỉ từ sql lên combobox
            labelKQTimKiem.Text = "Kết quả tìm thấy: 0";

            // Căn chỉnh table
            frmSach.canChinhDGV(dgvKhachHang);
            dgvKhachHang.Columns["Tên khách hàng"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (cbbTimKiem.Text == " Tên khách hàng")
            {
                string sqlKH = "Select " +
                "maKhachHang AS [Mã khách hàng]," +
                "tenKhachHang AS [Tên khách hàng]," +
                "gioiTinh AS [Giới tính]," +
                "soDienThoai AS [Số điện thoại]," +
                "diaChi AS [Địa chỉ]," +
                "tongTienDaMua AS [Tổng tiền đã mua]" +
                " from KhachHang Where tenKhachHang LIKE N'%" + txtTimKiem.Text.Trim() + "%'";

                dgvKhachHang.DataSource = connectionSQL.hienDL(sqlKH);
                labelKQTimKiem.Text = $"Kết quả tìm thấy: {dgvKhachHang.Rows.Count}";
            }
            if (cbbTimKiem.Text == " Mã khách hàng")
            {
                string sqlKH = "Select " +
                "maKhachHang AS [Mã khách hàng]," +
                "tenKhachHang AS [Tên khách hàng]," +
                "gioiTinh AS [Giới tính]," +
                "soDienThoai AS [Số điện thoại]," +
                "diaChi AS [Địa chỉ]," +
                "tongTienDaMua AS [Tổng tiền đã mua]" +
                " from KhachHang Where maKhachHang LIKE N'%" + txtTimKiem.Text.Trim() + "%'";

                dgvKhachHang.DataSource = connectionSQL.hienDL(sqlKH);
                labelKQTimKiem.Text = $"Kết quả tìm thấy: {dgvKhachHang.Rows.Count}";
            }
        }

        private void dgvKhachHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal tongTienMua))
                {
                    e.Value = tongTienMua.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
        }


        private void filterData()
        {
            // Bắt đầu câu truy vấn
            string sqlKH = "SELECT " +
                "maKhachHang AS [Mã khách hàng], " +
                "tenKhachHang AS [Tên khách hàng], " +
                "gioiTinh AS [Giới tính], " +
                "soDienThoai AS [Số điện thoại], " +
                "diaChi AS [Địa chỉ], " +
                "tongTienDaMua AS [Tổng tiền đã mua] " +
                "FROM KhachHang WHERE 1=1";

            // Kiểm tra giới tính (grbGioiTinh)
            if (grbGioiTinh.Enabled)
            {
                if (radioBtnNam.Checked)
                {
                    sqlKH += " AND gioiTinh = N'Nam'";
                }
                else if (radioBtnNu.Checked)
                {
                    sqlKH += " AND gioiTinh = N'Nữ'";
                }
            }

            // Kiểm tra địa chỉ (grbDiaChi)
            if (grbDiaChi.Enabled && !string.IsNullOrWhiteSpace(cbbLocDiaChi.Text))
            {
                sqlKH += " AND diaChi = N'" + cbbLocDiaChi.Text + "'";
            }

            // Kiểm tra tổng tiền (grbTongBan)
            decimal startValue, endValue;
            bool hasStart = decimal.TryParse(txtStart.Text.Trim(), out startValue);
            bool hasEnd = decimal.TryParse(txtEnd.Text.Trim(), out endValue);

            if (grbTongBan.Enabled && hasStart && hasEnd)
            {
                sqlKH += " AND tongTienDaMua BETWEEN " + startValue + " AND " + endValue;
            }

            // Load dữ liệu
            dgvKhachHang.DataSource = connectionSQL.hienDL(sqlKH);
        }



        private void radioBtnNam_CheckedChanged(object sender, EventArgs e)
        {
            filterData();
        }

        private void radioBtnNu_CheckedChanged(object sender, EventArgs e)
        {
            filterData();
        }

        private void cbbLocDiaChi_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            radioBtnNam.Checked = false;
            radioBtnNu.Checked = false;
            cbbLocDiaChi.Text = "";
            txtEnd.Text = "";
            txtStart.Text = "";
            loadDataKH();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            themKhachHang themKH = new themKhachHang();
            themKH.Show();
        }

        private void exportExcel(string path)
        {
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);

            // Tạo cột 
            for (int i = 0; i < dgvKhachHang.Columns.Count; i++)
                {
                application.Cells[1, i + 1] = dgvKhachHang.Columns[i].HeaderText;
                }
            for (int i = 0; i < dgvKhachHang.Rows.Count; i++)
            {
                for (int j = 0; j < dgvKhachHang.Columns.Count; j++)
                {
                    application.Cells[i + 2, j + 1] = dgvKhachHang.Rows[i].Cells[j].Value;
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            frmKhachHang.suaKhachHang suaKH = new frmKhachHang.suaKhachHang();
            suaKH.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentCell != null)
            {
                int rowIndex = dgvKhachHang.CurrentCell.RowIndex;

                if (dgvKhachHang.Rows[rowIndex].IsNewRow || dgvKhachHang.Rows[rowIndex].Cells[0].Value == null)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string maKH = dgvKhachHang.Rows[rowIndex].Cells[0].Value.ToString();

                if (maKH == "KH000")
                {
                    MessageBox.Show("Không thể xóa khách lẻ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    connectionSQL.open();

                    // Xác nhận trước khi xóa
                    DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng {maKH}?",
                                                          "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return;
                    }

                    // Xóa khách hàng
                    string deleteQuery = "DELETE FROM KhachHang WHERE maKhachHang = @maKH";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, connectionSQL.conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@maKH", maKH);
                        int rowsAffected = deleteCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Load lại dữ liệu sau khi xóa
                            loadDataKH();
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
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
