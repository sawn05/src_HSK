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
    public partial class DanhSachPhieuNhap : Form
    {
        ConnectionSQL connectionSQL = new ConnectionSQL();
        convertNumberToWords convert = new convertNumberToWords();

        public DanhSachPhieuNhap()
        {
            InitializeComponent();
        }

        private void DanhSachPhieuNhap_Load(object sender, EventArgs e)
        {
            this.Text = string.Empty;
            this.ControlBox = false;
            txtNCC.Text = "";
            txtNV.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            lbTienChu.Text = "Không đồng";
            lbTongTien.Text = "0";
            dgvSanPham.Columns.Clear();

            fillCBB();
            cbbMaPhieu.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void fillCBB()
        {
            cbbMaPhieu.Items.Clear();
            DataTable dt = connectionSQL.hienDL("SELECT maNhap from NhapHang");
            foreach (DataRow row in dt.Rows)
            {
                cbbMaPhieu.Items.Add(row["maNhap"].ToString());
            }
        }

        private void loadDataSanPham()
        {
            string maNhap = cbbMaPhieu.Text;
            string sqlPhieuNhap = @"
                            SELECT 
                                ct.maSanPham AS [Mã sản phẩm], 
                                sp.tenSanPham AS [Tên sản phẩm], 
                                ct.soLuong AS [Số lượng], 
                                ct.donGia AS [Giá nhập],
                                (ct.soLuong * ct.donGia) AS [Thành tiền]
                            FROM ChiTietNhapHang ct
                            INNER JOIN SanPham sp ON ct.maSanPham = sp.maSanPham
                            WHERE ct.maNhap = '" + maNhap + "'";

            dgvSanPham.DataSource = connectionSQL.hienDL(sqlPhieuNhap);

            FormChild.Sach frmSach = new FormChild.Sach();
            frmSach.canChinhDGV(dgvSanPham);
            dgvSanPham.Columns["Tên sản phẩm"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void cbbMaPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            getNCC(txtNCC, txtDiaChi, txtSDT);
            txtNV.Text = getTenNV();
            loadDataSanPham();
            lbTongTien.Text = getTongTien(cbbMaPhieu).ToString("N0");
            lbNgayNhap.Text = getNgayNhap();
        }

        private void dgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal gia))
                {
                    e.Value = gia.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
            if (e.ColumnIndex == 4 && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal gia))
                {
                    e.Value = gia.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
        }

        private void getNCC(Label ten, Label diaChi, Label sdt)
        {
            if (cbbMaPhieu == null || string.IsNullOrWhiteSpace(cbbMaPhieu.Text))
            {
                MessageBox.Show("Vui lòng chọn mã phiếu nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNhap = cbbMaPhieu.Text;

            // Lấy tên NCC
            string sqlTenNCC = @"
                                SELECT ncc.tenNhaCungCap
                                FROM NhapHang nhap
                                INNER JOIN NhaCungCap ncc ON ncc.maNhaCungCap = nhap.maNhaCungCap
                                WHERE nhap.maNhap = @maNhap";

            // Lấy địa chỉ NCC
            string sqlDC = @"
                                SELECT ncc.diaChi
                                FROM NhapHang nhap
                                INNER JOIN NhaCungCap ncc ON ncc.maNhaCungCap = nhap.maNhaCungCap
                                WHERE nhap.maNhap = @maNhap";


            // Lấy SĐT NCC
            string sqlSDT = @"
                                SELECT ncc.soDienThoai
                                FROM NhapHang nhap
                                INNER JOIN NhaCungCap ncc ON ncc.maNhaCungCap = nhap.maNhaCungCap
                                WHERE nhap.maNhap = @maNhap";

            try
            {
                connectionSQL.open();

                using (SqlCommand cmd = new SqlCommand(sqlTenNCC, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maNhap", maNhap);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        ten.Text = result.ToString();
                    }
                }


                using (SqlCommand cmd = new SqlCommand(sqlDC, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maNhap", maNhap);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        diaChi.Text = result.ToString();
                    }
                }


                using (SqlCommand cmd = new SqlCommand(sqlSDT, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maNhap", maNhap);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        sdt.Text = result.ToString();
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

        private string getTenNV()
        {
            if (cbbMaPhieu == null || string.IsNullOrWhiteSpace(cbbMaPhieu.Text))
            {
                MessageBox.Show("Vui lòng chọn mã phiếu nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }

            string maNhap = cbbMaPhieu.Text;
            string tenNV = "";

            string sqlTenNCC = @"
                                SELECT nv.tenNhanVien
                                FROM NhapHang nhap
                                INNER JOIN NhanVien nv ON nv.maNhanVien = nhap.maNhanVien
                                WHERE nhap.maNhap = @maNhap";

            try
            {
                connectionSQL.open();

                using (SqlCommand cmd = new SqlCommand(sqlTenNCC, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maNhap", maNhap);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        tenNV = result.ToString();
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

            return tenNV;
        }

        private int getTongTien(ComboBox comboBox)
        {
            string sqlQuery = "SELECT " +
                                "tongTien " +
                                "FROM NhapHang " +
                                "WHERE maNhap = @maNhap";

            try
            {
                connectionSQL.open();

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maNhap", comboBox.Text);

                    object result = cmd.ExecuteScalar();
                    if (result != null && decimal.TryParse(result.ToString(), out decimal tongTien))
                    {
                        lbTienChu.Text = convert.ChuyenSoSangChu(Convert.ToInt32(tongTien));
                        return Convert.ToInt32(tongTien);
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

            return 0;
        }

        private string getNgayNhap()
        {
            if (cbbMaPhieu == null || string.IsNullOrWhiteSpace(cbbMaPhieu.Text))
            {
                MessageBox.Show("Vui lòng chọn mã phiếu nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }

            string maNhap = cbbMaPhieu.Text;
            string ngayNhap = "";

            string sqlNgayNhap = @"
                            SELECT ngayNhap 
                            FROM NhapHang 
                            WHERE maNhap = @maNhap";

            try
            {
                connectionSQL.open();

                using (SqlCommand cmd = new SqlCommand(sqlNgayNhap, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maNhap", maNhap);

                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        ngayNhap = Convert.ToDateTime(result).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy ngày nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            return ngayNhap;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimun_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbMaPhieu.Text))
            {
                MessageBox.Show("Vui lòng chọn phiếu cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNhap = cbbMaPhieu.Text;

            try
            {
                connectionSQL.open();

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu này?", "Xác nhận xóa",
                                                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }

                // Kiểm tra phiếu nhập có tồn tại không trước khi xóa
                string sqlCheckNH = "SELECT COUNT(*) FROM NhapHang WHERE maNhap = @maNhap";
                using (SqlCommand cmdCheck = new SqlCommand(sqlCheckNH, connectionSQL.conn))
                {
                    cmdCheck.Parameters.AddWithValue("@maNhap", maNhap);
                    int count = Convert.ToInt32(cmdCheck.ExecuteScalar());

                    if (count == 0)
                    {
                        MessageBox.Show("Phiếu nhập không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                using (SqlTransaction transaction = connectionSQL.conn.BeginTransaction())
                {
                    try
                    {
                        // Xóa chi tiết nhập hàng
                        string sqlXoaCTNH = "DELETE FROM ChiTietNhapHang WHERE maNhap = @maNhap";
                        using (SqlCommand cmdCTNH = new SqlCommand(sqlXoaCTNH, connectionSQL.conn, transaction))
                        {
                            cmdCTNH.Parameters.AddWithValue("@maNhap", maNhap);
                            cmdCTNH.ExecuteNonQuery();
                        }

                        // Xóa phiếu nhập
                        string sqlXoaNH = "DELETE FROM NhapHang WHERE maNhap = @maNhap";
                        using (SqlCommand cmdNH = new SqlCommand(sqlXoaNH, connectionSQL.conn, transaction))
                        {
                            cmdNH.Parameters.AddWithValue("@maNhap", maNhap);
                            cmdNH.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Xóa phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DanhSachPhieuNhap_Load(sender, e);
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
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connectionSQL.close();
            }
        }


        // Cần update sql
        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbMaPhieu.Text))
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tienChu = lbTienChu.Text;

            DataTable dt = new DataTable();

            try
            {
                connectionSQL.open();
                using (SqlCommand cmd = new SqlCommand("sp_GetChiTietPhieuNhap", connectionSQL.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@maNhap", cbbMaPhieu.Text);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                connectionSQL.close();
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            rptChiTietNhapHang report = new rptChiTietNhapHang();
            report.SetDataSource(dt);

            report.SetParameterValue("TienChu", tienChu);

            FormInRptNhapHang frm = new FormInRptNhapHang(report);
            frm.ShowDialog();
        }
    }
}
