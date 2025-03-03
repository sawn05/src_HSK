using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.FormChild
{
    public partial class GioHang : Form
    {
        ConnectionSQL connectionSQL = new ConnectionSQL();
        public GioHang()
        {
            InitializeComponent();
        }

        private void GioHang_Load(object sender, EventArgs e)
        {
            FormChild.Sach frmSach = new FormChild.Sach();
            frmSach.SetPlaceholder(txtGhiChu, " Ghi chú....");

            // Set dataGridView
            dgvSanPham.Visible = true;
            dgvTimKiem.Visible = false;

            loadDataGioHang();
            loadDataKH();

            // Tính tiền hàng và số lượng hàng
            tongTienHang();
            soLuongHang();
            txtKhachThanhToan.Text = "0";
            txtGiamGia.Text = "0";

            // Load panelThanhToan
            radioBtnTM.Checked = true;


            // Căn chỉnh table
            frmSach.canChinhDGV(dgvTimKiem);

            // Căn chỉnh table
            frmSach.canChinhDGV(dgvKhachHang);
            dgvKhachHang.Columns["Tên KH"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKhachHang.Columns["Địa chỉ"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            // Căn chỉnh table
            frmSach.canChinhDGV(dgvSanPham);
            dgvSanPham.Columns["Tên SP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void txtTimKiemSP_TextChanged(object sender, EventArgs e)
        {
            dgvSanPham.Visible = false;
            dgvTimKiem.Visible = true;

            string sqlSP = "Select " +
            "maSanPham AS [Mã sản phẩm]," +
            "tenSanPham AS [Tên SP]," +
            "soLuongTon AS [Số lượng tồn]," +
            "gia AS [Đơn giá]" +
            " from SanPham WHERE tenSanPham LIKE N'%" + txtTimKiemSP.Text.Trim() + "%'";

            dgvTimKiem.DataSource = connectionSQL.hienDL(sqlSP);
        }


        // Load data Giỏ hàng
        private void loadDataGioHang()
        {
            string sqlSP = "Select " +
                "maSP AS [Mã SP], " +
                "tenSP AS [Tên SP], " +
                "soLuong AS [SL mua], " +
                "donGia AS [Giá] " +
                "from GioHang";

            dgvSanPham.DataSource = connectionSQL.hienDL(sqlSP);
        }

        private void btnXemGioHang_Click(object sender, EventArgs e)
        {
            dgvSanPham.Visible = true;
            dgvTimKiem.Visible = false;
            loadDataGioHang();
        }

        private void btnXemSanPham_Click(object sender, EventArgs e)
        {
            dgvSanPham.Visible = false;
            dgvTimKiem.Visible = true;

            string sqlSP = "Select " +
            "maSanPham AS [Mã SP]," +
            "tenSanPham AS [Tên SP]," +
            "soLuongTon AS [SL tồn]," +
            "gia AS [Giá]" +
            " from SanPham";

            dgvTimKiem.DataSource = connectionSQL.hienDL(sqlSP);
            dgvTimKiem.Columns["Tên SP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void dgvTimKiem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
        }

        private void loadDataKH()
        {
            string sqlKH = "Select " +
                "maKhachHang AS [Mã KH]," +
                "tenKhachHang AS [Tên KH]," +
                "soDienThoai AS [SĐT]," +
                "diaChi AS [Địa chỉ]" +
                " from KhachHang";
            dgvKhachHang.DataSource = connectionSQL.hienDL(sqlKH);
            dgvKhachHang.Columns["Mã KH"].Visible = false;

        }

        private void txtTimKhachHang_TextChanged(object sender, EventArgs e)
        {
            string sqlKH = "Select " +
                "maKhachHang AS [Mã KH]," +
                "tenKhachHang AS [Tên KH]," +
                "soDienThoai AS [SĐT]," +
                "diaChi AS [Địa chỉ]" +
                " from KhachHang Where tenKhachHang LIKE N'%" + txtTimKhachHang.Text.Trim() + "%' or soDienThoai LIKE N'%" + txtTimKhachHang.Text.Trim() + "%'";

            dgvKhachHang.DataSource = connectionSQL.hienDL(sqlKH);
            dgvKhachHang.Columns["Mã KH"].Visible = false;
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvKhachHang.CurrentRow.Index;

            txtTimKhachHang.Text = dgvKhachHang.Rows[i].Cells[1].Value?.ToString() ?? "";
        }

        public void nhapSo(object sender)
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

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            nhapSo(sender);

            decimal giamGia = 0;
            decimal tongTien = 0;

            if (!decimal.TryParse(lbTongTienHangGiaCu.Text, out tongTien))
            {
                tongTien = 0;
            }

            if (!decimal.TryParse(txtGiamGia.Text, out giamGia))
            {
                giamGia = 0;
            }

            if (radioBtnVND.Checked)
            {
                decimal tongSauGiam = tongTien - giamGia;
                if (tongSauGiam < 0) tongSauGiam = 0;

                lbTongTienHang.Text = tongSauGiam.ToString("N0");
            }

            if (radioBtnPecent.Checked)
            {
                decimal giamGiaPhanTram = giamGia / 100;
                decimal tongSauGiam = tongTien * (1 - giamGiaPhanTram);
                if (tongSauGiam < 0) tongSauGiam = 0;

                lbTongTienHang.Text = tongSauGiam.ToString("N0");
            }

            // Update tiền trả khách 
            tienTraKhach();
        }


        private void tienTraKhach()
        {
            try
            {
                if (txtKhachThanhToan.Text.Trim() != "")
                {
                    // Cập nhật tiền trả khách
                    decimal khachThanhToan = Convert.ToDecimal(txtKhachThanhToan.Text);
                    decimal tongTienHang = Convert.ToDecimal(lbTongTienHang.Text);
                    string tienTraKhach = Convert.ToDecimal(khachThanhToan - tongTienHang).ToString("N0");

                    lbTienTraKhach.Text = $"Tiền thừa trả khách: {tienTraKhach} VNĐ";
                }
                else
                {
                    string tienTraKhach = lbTongTienHang.Text;
                    lbTienTraKhach.Text = $"Tiền thừa trả khách: -{tienTraKhach} VNĐ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtKhachThanhToan_TextChanged(object sender, EventArgs e)
        {
            nhapSo(sender);
            tienTraKhach();
        }

        private void btnXoaSPGioHang_Click(object sender, EventArgs e)
        {
           if (dgvSanPham.Visible == true && dgvTimKiem.Visible == false)
                {
                if (dgvSanPham.CurrentCell != null)
                {
                    int rowIndex = dgvSanPham.CurrentCell.RowIndex;

                    if (dgvSanPham.Rows[rowIndex].IsNewRow || dgvSanPham.Rows[rowIndex].Cells[0].Value == null)
                    {
                        MessageBox.Show("Vui lòng chọn sản phẩm hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string maSP = dgvSanPham.Rows[rowIndex].Cells[0].Value.ToString();

                    try
                    {
                        connectionSQL.open();

                        // Xác nhận trước khi xóa
                        DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm: {maSP}?",
                                                              "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.No)
                        {
                            return;
                        }

                        // Xóa hàng trong giỏ
                        string deleteQuery = "DELETE FROM GioHang WHERE maSP = @maSP";
                        using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, connectionSQL.conn))
                        {
                            deleteCmd.Parameters.AddWithValue("@maSP", maSP);
                            int rowsAffected = deleteCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Load lại dữ liệu sau khi xóa
                                loadDataGioHang();

                                // Update tổng tiền hàng sau khi xóa
                                tongTienHang();

                                // Update tiền trả khách 
                                tienTraKhach();
                                soLuongHang();
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
                    MessageBox.Show("Vui lòng chọn hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
           }
            else
            {
                MessageBox.Show("Vui lòng hiện giỏ hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dgvTimKiem.Visible == true && dgvSanPham.Visible == false)
            {
                if (dgvTimKiem.CurrentCell != null)
                {
                    int rowIndex = dgvTimKiem.CurrentCell.RowIndex;

                    if (dgvTimKiem.Rows[rowIndex].IsNewRow || dgvTimKiem.Rows[rowIndex].Cells[0].Value == null)
                    {
                        MessageBox.Show("Vui lòng chọn sản phẩm hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int slMua = 1;
                    string maSP = dgvTimKiem.Rows[rowIndex].Cells[0].Value.ToString();
                    string tenSP = dgvTimKiem.Rows[rowIndex].Cells[1].Value.ToString();

                    decimal donGia = 0;
                    if (dgvTimKiem.Rows[rowIndex].Cells[3].Value != null)
                    {
                        decimal.TryParse(dgvTimKiem.Rows[rowIndex].Cells[3].Value.ToString(), out donGia);
                    }


                    try
                    {
                        connectionSQL.open();

                        // Xác nhận trước khi thêm
                        DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn thêm sản phẩm: {maSP} vào giỏ hàng?",
                                                              "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.No)
                        {
                            return;
                        }

                        // Thêm hàng vào trong giỏ
                        string insertQuery = "INSERT INTO GioHang (maSP, tenSP, soLuong, donGia) " +
                                             "VALUES (@maSP, @tenSP, @soLuong, @donGia)";
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, connectionSQL.conn))
                        {
                            insertCmd.Parameters.AddWithValue("@maSP", maSP);
                            insertCmd.Parameters.AddWithValue("@tenSP", tenSP);
                            insertCmd.Parameters.AddWithValue("@soLuong", slMua);
                            insertCmd.Parameters.AddWithValue("@donGia", donGia);

                            insertCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Update tổng tiền hàng 
                        tongTienHang();

                        // Update tiền trả khách
                        tienTraKhach();

                        // Update số lượng hàng
                        soLuongHang();
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
                    MessageBox.Show("Vui lòng chọn hàng cần mua!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng hiện danh sách sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tongTienHang()
        {
            connectionSQL.open();
            string sql = "SELECT SUM(thanhTien) FROM GioHang";
            SqlCommand cmd = new SqlCommand(sql, connectionSQL.conn);

            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value && result != null)
            {
                lbTongTienHang.Text = Convert.ToDecimal(result).ToString("N0");
                lbTongTienHangGiaCu.Text = Convert.ToDecimal(result).ToString("N0");
            }
            else
            {
                lbTongTienHang.Text = "0";
                lbTongTienHangGiaCu.Text = "0";
            }
            connectionSQL.close();
        }

        // Load số lượng hàng
        private void soLuongHang()
        {
            connectionSQL.open();
            string sql = "SELECT SUM(soLuong) FROM GioHang";
            SqlCommand cmd = new SqlCommand(sql, connectionSQL.conn);

            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value && result != null)
            {
                lbSoLuongSP.Text = Convert.ToDecimal(result).ToString("N0");
            }
            else
            {
                lbSoLuongSP.Text = "0";
            }
            connectionSQL.close();
        }


        private void radioBtnCK_CheckedChanged(object sender, EventArgs e)
        {
            picQR.Visible = true;
            lbTienTraKhach.Visible = false;
        }

        private void radioBtnTM_CheckedChanged(object sender, EventArgs e)
        {
            picQR.Visible = false;
            lbTienTraKhach.Visible = true;
        }

        private void radioBtnVND_CheckedChanged(object sender, EventArgs e)
        {
            if (txtGiamGia.Text.Trim() == "")
            {
                return;
            }

            decimal tongTien = Convert.ToDecimal(lbTongTienHangGiaCu.Text);
            decimal giamGiaVND = Convert.ToDecimal(txtGiamGia.Text);
            lbTongTienHang.Text = Convert.ToDecimal(tongTien - giamGiaVND).ToString("N0");
            tienTraKhach();
        }

        private void radioBtnPecent_CheckedChanged(object sender, EventArgs e)
        {
            if (txtGiamGia.Text.Trim() == "")
            {
                return;
            }

            decimal tongTien = Convert.ToDecimal(lbTongTienHangGiaCu.Text);
            decimal giamGiaPecent = (Convert.ToDecimal(txtGiamGia.Text)) / 100;
            lbTongTienHang.Text = Convert.ToDecimal(tongTien * (1 - giamGiaPecent)).ToString("N0");
            tienTraKhach();
        }


        // Hàm tự động lấy mã hóa đơn
        private string taoMaHD()
        {
            string maHD = "HD001";
            string query = "SELECT TOP 1 maHD FROM HoaDon ORDER BY maHD DESC";

            using (SqlCommand cmd = new SqlCommand(query, connectionSQL.conn))
            {
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string lastMaHD = result.ToString();
                    int soThuTu = int.Parse(lastMaHD.Substring(2)) + 1;
                    maHD = "HD" + soThuTu.ToString("D3");
                }
            }

            return maHD;
        }


        // Cần cập nhật mã nhân viên bán hàng (đang để NV001)
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                connectionSQL.open();

                // Tạo mã hóa đơn mới
                string maHD = taoMaHD();

                string maKhachHang = "KH000";
                if (dgvKhachHang.CurrentRow != null)
                {
                    maKhachHang = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();
                }

                string maNhanVien = "NV001";
                DateTime ngayLapHD = DateTime.Now;
                decimal tongTien = Convert.ToDecimal(lbTongTienHang.Text);
                string ghiChu = txtGhiChu.Text;
                if (ghiChu == " Ghi chú....")
                {
                    ghiChu = "";
                }

                string phuongThucTT = radioBtnTM.Checked ? "TM" : (radioBtnCK.Checked ? "CK" : "");

                // Chèn hóa đơn vào CSDL
                string insertHoaDon = "INSERT INTO HoaDon (maHD, maKhachHang, maNhanVien, ngayLapHD, tongTien, ghiChu, phuongThucTT) " +
                                      "VALUES (@maHD, @maKhachHang, @maNhanVien, @ngayLapHD, @tongTien, @ghiChu, @phuongThucTT)";
                using (SqlCommand cmd = new SqlCommand(insertHoaDon, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maHD", maHD);
                    cmd.Parameters.AddWithValue("@maKhachHang", maKhachHang);
                    cmd.Parameters.AddWithValue("@maNhanVien", maNhanVien);
                    cmd.Parameters.AddWithValue("@ngayLapHD", ngayLapHD);
                    cmd.Parameters.AddWithValue("@tongTien", tongTien);
                    cmd.Parameters.AddWithValue("@ghiChu", ghiChu);
                    cmd.Parameters.AddWithValue("@phuongThucTT", phuongThucTT);
                    cmd.ExecuteNonQuery();
                }

                // Thêm từng sản phẩm từ giỏ hàng vào ChiTietDonHang
                foreach (DataGridViewRow row in dgvSanPham.Rows)
                {
                    if (row.Cells["Mã SP"].Value != null) 
                    {
                        string maSP = row.Cells["Mã SP"].Value.ToString();
                        int soLuong = Convert.ToInt32(row.Cells["SL mua"].Value);
                        decimal donGia = Convert.ToDecimal(row.Cells["Giá"].Value);
                        decimal thanhTien = soLuong * donGia;

                        string insertChiTiet = "INSERT INTO ChiTietDonHang (maHD, maSanPham, soLuong, giaDonHang) " +
                                               "VALUES (@maHD, @maSP, @soLuong, @giaDonHang)";
                        using (SqlCommand cmd = new SqlCommand(insertChiTiet, connectionSQL.conn))
                        {
                            cmd.Parameters.AddWithValue("@maHD", maHD);
                            cmd.Parameters.AddWithValue("@maSP", maSP);
                            cmd.Parameters.AddWithValue("@soLuong", soLuong);
                            cmd.Parameters.AddWithValue("@giaDonHang", thanhTien);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                // Xóa giỏ hàng sau khi thanh toán
                string deleteGioHang = "DELETE FROM GioHang";
                using (SqlCommand cmd = new SqlCommand(deleteGioHang, connectionSQL.conn))
                {
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Thanh toán thành công! Mã hóa đơn: " + maHD, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật tổng tiền mua của khách
                string updateTongKhachMua = "Update KhachHang Set tongTienDaMua = tongTienDaMua + @tongTienHD Where maKhachHang = @maKhachHang";
                using (SqlCommand cmd = new SqlCommand(updateTongKhachMua, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@tongTienHD", tongTien);
                    cmd.Parameters.AddWithValue("@maKhachHang", maKhachHang);
                    cmd.ExecuteNonQuery();
                }

                // Load lại giỏ hàng
                GioHang_Load(sender, e);

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
