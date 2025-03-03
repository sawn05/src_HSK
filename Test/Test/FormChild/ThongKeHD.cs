using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;

namespace Test.FormChild
{
    public partial class ThongKeHD : Form
    {
        ConnectionSQL connectionSQL = new ConnectionSQL();

        public ThongKeHD()
        {
            InitializeComponent();
        }

        private void ThongKeHD_Load(object sender, EventArgs e)
        {
            loadDataHD();

            FormChild.Sach frmSach = new FormChild.Sach();
            frmSach.canChinhDGV(dgvHoaDon);
            dgvHoaDon.Columns["Ngày lập"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHoaDon.Columns["Tổng tiền"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHoaDon.Columns["Ghi chú"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            // Load doanh thu
            lbTongDoanhThu.Text = "Tổng doanh thu của cửa hàng: " + tongDoanhThu_ToString() + " VND";
        }


        private void loadDataHD()
        {
            string sqlHD = "Select " +
                "maHD AS [Mã HĐ]," +
                "maKhachHang AS [Mã KH]," +
                "maNhanVien AS [Mã NV]," +
                "ngayLapHD AS [Ngày lập]," +
                "tongTien AS [Tổng tiền]," +
                "phuongThucTT AS [Phương thức thanh toán]," +
                "ghiChu AS [Ghi chú]" +
                " from HoaDon";

            dgvHoaDon.DataSource = connectionSQL.hienDL(sqlHD);
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal gia))
                {
                    e.Value = gia.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                loadDataHD();
                return;
            }
            else
            {
                string sqlHD = "Select " +
                "maHD AS [Mã HĐ]," +
                "maKhachHang AS [Mã KH]," +
                "maNhanVien AS [Mã NV]," +
                "ngayLapHD AS [Ngày lập]," +
                "tongTien AS [Tổng tiền]," +
                "phuongThucTT AS [Phương thức thanh toán]," +
                "ghiChu AS [Ghi chú]" +
                " from HoaDon Where maHD LIKE N'%" + txtTimKiem.Text.Trim() + "%'";

                dgvHoaDon.DataSource = connectionSQL.hienDL(sqlHD);
            }
        }

        // Xử lý btn Xuất file excel
        private void exportExcel(string path)
        {
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);

            // Tạo cột 
            for (int i = 0; i < dgvHoaDon.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dgvHoaDon.Columns[i].HeaderText;
            }
            for (int i = 0; i < dgvHoaDon.Rows.Count; i++)
            {
                for (int j = 0; j < dgvHoaDon.Columns.Count; j++)
                {
                    application.Cells[i + 2, j + 1] = dgvHoaDon.Rows[i].Cells[j].Value;
                }
            }

            application.Columns.AutoFit();
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
        }

        private void btnXuatFileExcel_Click(object sender, EventArgs e)
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


        // Tính tổng doanh thu của cửa hàng
        private string tongDoanhThu_ToString()
        {
            string sqlTongTienHD = "SELECT SUM(tongTien) FROM HoaDon";

            try
            {
                connectionSQL.open();

                using (SqlCommand cmd = new SqlCommand(sqlTongTienHD, connectionSQL.conn))
                {
                    object result = cmd.ExecuteScalar();
                    return (result != DBNull.Value ? Convert.ToDecimal(result) : 0).ToString("N0");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "0"; 
            }
            finally
            {
                connectionSQL.close();
            }
        }


        // Lấy dữ liệu phục vụ cho form Chi tiết hóa đơn
        private string getMaHD()
        {
            if (dgvHoaDon.CurrentRow != null)
            {
                return dgvHoaDon.CurrentRow.Cells[0].Value?.ToString() ?? "";
            }
            return "";
        }

        private string getNgayLap()
        {
            if (dgvHoaDon.CurrentRow != null)
            {
                return dgvHoaDon.CurrentRow.Cells[3].Value?.ToString() ?? "";
            }
            return "";
        }

        private string getKhachHang()
        {
            string maKH = "";
            if (dgvHoaDon.CurrentRow != null)
            {
                maKH = dgvHoaDon.CurrentRow.Cells[1].Value?.ToString() ?? "";
            }

            string sqlTenKH = "SELECT tenKhachHang FROM KhachHang WHERE maKhachHang = @maKH";
            try
            {
                connectionSQL.open();

                using (SqlCommand cmd = new SqlCommand(sqlTenKH, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maKH", maKH);

                    object result = cmd.ExecuteScalar();
                    return result?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "0";
            }
            finally
            {
                connectionSQL.close();
            }
        }


        private string getSDT()
        {
            string maKH = "";
            if (dgvHoaDon.CurrentRow != null)
            {
                maKH = dgvHoaDon.CurrentRow.Cells[1].Value?.ToString() ?? "";
            }

            string sqlTenKH = "SELECT soDienThoai FROM KhachHang WHERE maKhachHang = @maKH";
            try
            {
                connectionSQL.open();

                using (SqlCommand cmd = new SqlCommand(sqlTenKH, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maKH", maKH);

                    object result = cmd.ExecuteScalar();
                    return result?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "0";
            }
            finally
            {
                connectionSQL.close();
            }
        }

        private string getDiaChi()
        {
            string maKH = "";
            if (dgvHoaDon.CurrentRow != null)
            {
                maKH = dgvHoaDon.CurrentRow.Cells[1].Value?.ToString() ?? "";
            }

            string sqlTenKH = "SELECT diaChi FROM KhachHang WHERE maKhachHang = @maKH";
            try
            {
                connectionSQL.open();

                using (SqlCommand cmd = new SqlCommand(sqlTenKH, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maKH", maKH);

                    object result = cmd.ExecuteScalar();
                    return result?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "0";
            }
            finally
            {
                connectionSQL.close();
            }
        }

        private string getPTTT()
        {
            if (dgvHoaDon.CurrentRow != null)
            {
                return dgvHoaDon.CurrentRow.Cells[5].Value?.ToString() ?? "";
            }
            return "";
        }

        private string getGhiChu()
        {
            if (dgvHoaDon.CurrentRow != null)
            {
                return dgvHoaDon.CurrentRow.Cells[6].Value?.ToString() ?? "";
            }
            return "";
        }


        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            string maHD = getMaHD();
            string ngayLap = getNgayLap();
            string khachHang = getKhachHang();
            string soDienThoai = getSDT();
            string diaChi = getDiaChi();
            string phuongThucTT = getPTTT();
            string ghiChu = getGhiChu();

            if (string.IsNullOrEmpty(maHD))
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmHoaDon.ChiTietHD chiTietHD = new frmHoaDon.ChiTietHD(maHD, ngayLap, khachHang, soDienThoai, diaChi, phuongThucTT, ghiChu);
            chiTietHD.Show();
        }

    }
}
