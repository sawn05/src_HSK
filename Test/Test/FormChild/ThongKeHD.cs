﻿using System;
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

        private string maNV;
        public ThongKeHD(string maNVBanHang)
        {
            InitializeComponent();
            maNV = maNVBanHang;
        }

        private void ThongKeHD_Load(object sender, EventArgs e)
        {
            loadDataHD();

            Function frmSach = new Function();
            frmSach.CanChinhDGV(dgvHoaDon);
            dgvHoaDon.Columns["Ngày lập"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHoaDon.Columns["Tổng tiền"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dgvHoaDon.Columns["Ghi chú"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHoaDon.Columns["Khách hàng"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHoaDon.Columns["Nhân viên"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            // Load doanh thu
            lbTongDoanhThu.Text = "Tổng doanh thu của cửa hàng: " + tongDoanhThu_ToString() + " VND";
        }


        private void loadDataHD()
        {
            string sqlHD = "SELECT " +
                    "hd.maHD AS [Mã HĐ], " +
                    "kh.tenKhachHang AS [Khách hàng], " +
                    "nv.tenNhanVien AS [Nhân viên], " +
                    "hd.ngayLapHD AS [Ngày lập], " +
                    "hd.tongTien AS [Tổng tiền], " +
                    "hd.phuongThucTT AS [Phương thức thanh toán], " +
                    "hd.ghiChu AS [Ghi chú] " +
                    "FROM HoaDon hd " +
                    "JOIN KhachHang kh ON hd.maKhachHang = kh.maKhachHang " +
                    "JOIN NhanVien nv ON hd.maNhanVien = nv.maNhanVien";

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
                string sqlHD = "SELECT " +
                    "hd.maHD AS [Mã HĐ], " +
                    "kh.tenKhachHang AS [Khách hàng], " +
                    "nv.tenNhanVien AS [Nhân viên], " +
                    "hd.ngayLapHD AS [Ngày lập], " +
                    "hd.tongTien AS [Tổng tiền], " +
                    "hd.phuongThucTT AS [Phương thức thanh toán], " +
                    "hd.ghiChu AS [Ghi chú] " +
                    "FROM HoaDon hd " +
                    "JOIN KhachHang kh ON hd.maKhachHang = kh.maKhachHang " +
                    "JOIN NhanVien nv ON hd.maNhanVien = nv.maNhanVien WHERE maHD LIKE N'%" + txtTimKiem.Text.Trim() + "%'";

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
            if (dgvHoaDon.CurrentRow != null)
            {
                return dgvHoaDon.CurrentRow.Cells[1].Value?.ToString() ?? "";
            }
            return "";
        }

        private string getMaKH(string maHD)
        {
            string sqlLayMaKH = "SELECT maKhachHang FROM HoaDon WHERE maHD = @maHD";

            try
            {
                connectionSQL.open();
                using (SqlCommand cmd = new SqlCommand(sqlLayMaKH, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maHD", maHD);
                    object result = cmd.ExecuteScalar();
                    return result?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy mã khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            finally
            {
                connectionSQL.close();
            }
        }


        private string getSDT(string maKH)
        {
            if (string.IsNullOrEmpty(maKH))
            {
                MessageBox.Show("Không tìm thấy mã khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "0";
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
                MessageBox.Show("Lỗi lấy số điện thoại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "0";
            }
            finally
            {
                connectionSQL.close();
            }
        }


        private string getDiaChi(string maKH)
        {
            if (string.IsNullOrEmpty(maKH))
            {
                MessageBox.Show("Không tìm thấy mã khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "0";
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
            string maKH = getMaKH(maHD);
            string soDienThoai = getSDT(maKH);
            string diaChi = getDiaChi(maKH);
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maNV != "NV001")
            {
                MessageBox.Show("Bạn phải được cấp quyền này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvHoaDon.CurrentCell != null)
            {
                int rowIndex = dgvHoaDon.CurrentCell.RowIndex;

                if (dgvHoaDon.Rows[rowIndex].IsNewRow || dgvHoaDon.Rows[rowIndex].Cells[0].Value == null)
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string maHD = dgvHoaDon.Rows[rowIndex].Cells[0].Value.ToString();

                try
                {
                    connectionSQL.open();

                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này?", "Xác nhận xóa",
                                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return;
                    }

                    // Kiểm tra phiếu nhập có tồn tại không trước khi xóa
                    string sqlCheckNH = "SELECT COUNT(*) FROM HoaDon WHERE maHD = @maHD";
                    using (SqlCommand cmdCheck = new SqlCommand(sqlCheckNH, connectionSQL.conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@maHD", maHD);
                        int count = Convert.ToInt32(cmdCheck.ExecuteScalar());

                        if (count == 0)
                        {
                            MessageBox.Show("Hóa đơn không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    using (SqlTransaction transaction = connectionSQL.conn.BeginTransaction())
                    {
                        try
                        {
                            // Xóa chi tiết nhập hàng
                            string sqlXoaCTNH = "DELETE FROM ChiTietDonHang WHERE maHD = @maHD";
                            using (SqlCommand cmdCTDH = new SqlCommand(sqlXoaCTNH, connectionSQL.conn, transaction))
                            {
                                cmdCTDH.Parameters.AddWithValue("@maHD", maHD);
                                cmdCTDH.ExecuteNonQuery();
                            }

                            // Xóa phiếu nhập
                            string sqlXoaNH = "DELETE FROM HoaDon WHERE maHD = @maHD";
                            using (SqlCommand cmdHD = new SqlCommand(sqlXoaNH, connectionSQL.conn, transaction))
                            {
                                cmdHD.Parameters.AddWithValue("@maHD", maHD);
                                cmdHD.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ThongKeHD_Load(sender, e);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }
    }
}
