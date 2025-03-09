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
using Microsoft.VisualBasic;


namespace Test.FormChild
{
    public partial class NhapHang : Form
    {
        ConnectionSQL connectionSQL = new ConnectionSQL();

        public NhapHang()
        {
            InitializeComponent();
        }

        private string TaoMaNhap()
        {
            string sql = "SELECT TOP 1 maNhap FROM NhapHang ORDER BY maNhap DESC";
            string maNhapMoi = "NH001"; // Default

            try
            {
                connectionSQL.open();
                using (SqlCommand cmd = new SqlCommand(sql, connectionSQL.conn))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != null && result.ToString().StartsWith("NH"))
                    {
                        string maHienTai = result.ToString();

                        if (maHienTai.Length >= 3)
                        {
                            int soThuTu = Convert.ToInt32(maHienTai.Substring(2)) + 1;
                            maNhapMoi = "NH" + soThuTu.ToString("D3");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã nhập: " + ex.Message);
            }
            finally
            {
                connectionSQL.close();
            }

            return maNhapMoi;
        }


        private void NhapHang_Load(object sender, EventArgs e)
        {
            txtMaNhap.Text = TaoMaNhap();
            cbbMaPhieu.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbNCC.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;

            // Load phieuNhap
            loadDataPhieuNhap();
            loadDataSanPham();

            // Khởi tạo bảng sản phẩm
            initDgvSanPham();

            Function frmSach = new Function();
            // Căn chỉnh table
            frmSach.CanChinhDGV(dgvSanPham);
            frmSach.CanChinhDGV(dgvTimKiem);
            frmSach.CanChinhDGV(dgvPhieuNhap);
            dgvPhieuNhap.Columns["Ngày nhập"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSanPham.Columns["tenSP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            // Load combobox
            loadCBB();
        }

        private void loadCBB()
        {
            string queryNCC = "SELECT maNhaCungCap FROM NhaCungCap";
            string queryNV = "SELECT maNhanVien FROM NhanVien";
            string queryMaNhap = "SELECT maNhap FROM NhapHang";
            fillCBB(cbbNCC, queryNCC, "maNhaCungCap");
            fillCBB(cbbNhanVien, queryNV, "maNhanVien");
            fillCBB(cbbMaPhieu, queryMaNhap, "maNhap");
        }

        private void fillCBB(ComboBox comboBox, string query, string nameCol)
        {
            comboBox.Items.Clear();
            DataTable dt = connectionSQL.hienDL(query);
            foreach (DataRow row in dt.Rows)
            {
                comboBox.Items.Add(row[nameCol].ToString());
            }
        }

        private void loadDataPhieuNhap()
        {
            string sqlPhieuNhap = @"
                        SELECT 
                            maNhap AS [Mã phiếu], 
                            maNhaCungCap AS [NCC], 
                            maNhanVien AS [NV], 
                            ngayNhap AS [Ngày nhập] 
                        FROM NhapHang";
            dgvPhieuNhap.DataSource = connectionSQL.hienDL(sqlPhieuNhap);
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                connectionSQL.open();

                // Kiểm tra mã nhập được khởi tạo chưa
                if (string.IsNullOrWhiteSpace(txtMaNhap.Text) || string.IsNullOrWhiteSpace(cbbNCC.Text) || string.IsNullOrWhiteSpace(cbbNhanVien.Text))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Kiểm tra NV có tồn tại không
                string queryNV = "SELECT COUNT(*) FROM NhanVien WHERE maNhanVien = @maNV";
                using (SqlCommand cmd = new SqlCommand(queryNV, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maNV", cbbNhanVien.Text);
                    int count = (int)cmd.ExecuteScalar();

                    if (!(count > 0))
                    {
                        MessageBox.Show("Mã nhân viên không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Kiểm tra NCC có tồn tại không
                string queryNCC = "SELECT COUNT(*) FROM NhaCungCap WHERE maNhaCungCap = @maNCC";
                using (SqlCommand cmd = new SqlCommand(queryNCC, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maNCC", cbbNCC.Text);
                    int count = (int)cmd.ExecuteScalar();

                    if (!(count > 0))
                    {
                        MessageBox.Show("Mã nhà cung cấp không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Kiểm tra mã nhập đã tồn tại
                string query = "SELECT COUNT(*) FROM NhapHang WHERE maNhap = @maNhap";
                using (SqlCommand cmd = new SqlCommand(query, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maNhap", txtMaNhap.Text);
                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Mã nhập đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string maNhap = txtMaNhap.Text;
                string maNCC = cbbNCC.Text;
                string maNV = cbbNhanVien.Text;

                // Thêm phiếu nhập mới
                string insertQuery = "INSERT INTO NhapHang (maNhap, maNhaCungCap, maNhanVien) " +
                                     "VALUES(@maNhap, @maNCC, @maNV)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maNhap", maNhap);
                    cmd.Parameters.AddWithValue("@maNCC", maNCC);
                    cmd.Parameters.AddWithValue("@maNV", maNV);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Tạo đơn nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDataPhieuNhap();
                txtMaNhap.Text = TaoMaNhap();
                loadCBB();
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

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string sqlSP = "Select " +
            "maSanPham AS [Mã sản phẩm]," +
            "soLuongTon AS [SL tồn]" +
            " from SanPham WHERE maSanPham LIKE N'%" + txtTimKiem.Text.Trim() + "%'";

            dgvTimKiem.DataSource = connectionSQL.hienDL(sqlSP);
        }

        private void loadDataSanPham()
        {
            string sqlSP = "Select " +
            "maSanPham AS [Mã sản phẩm]," +
            "soLuongTon AS [SL tồn]" +
            " from SanPham";

            dgvTimKiem.DataSource = connectionSQL.hienDL(sqlSP);
            dgvTimKiem.Columns["Mã sản phẩm"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void dgvPhieuNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvPhieuNhap.CurrentRow.Index;

            txtMaNhap.Text = dgvPhieuNhap.Rows[i].Cells[0].Value?.ToString() ?? "";
            cbbNCC.Text = dgvPhieuNhap.Rows[i].Cells[1].Value?.ToString() ?? "";
            cbbNhanVien.Text = dgvPhieuNhap.Rows[i].Cells[2].Value?.ToString() ?? "";
        }

        private void btnSuaPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                connectionSQL.open();

                // Kiểm tra NV có tồn tại không
                string queryNV = "SELECT COUNT(*) FROM NhanVien WHERE maNhanVien = @maNV";
                using (SqlCommand cmd = new SqlCommand(queryNV, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maNV", cbbNhanVien.Text);
                    int count = (int)cmd.ExecuteScalar();

                    if (!(count > 0))
                    {
                        MessageBox.Show("Mã nhân viên không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Kiểm tra NCC có tồn tại không
                string queryNCC = "SELECT COUNT(*) FROM NhaCungCap WHERE maNhaCungCap = @maNCC";
                using (SqlCommand cmd = new SqlCommand(queryNCC, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maNCC", cbbNCC.Text);
                    int count = (int)cmd.ExecuteScalar();

                    if (!(count > 0))
                    {
                        MessageBox.Show("Mã nhà cung cấp không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string insertQuery = "UPDATE NhapHang " +
                                     "SET maNhaCungCap = @maNCC, maNhanVien = @maNV Where maNhap = @maNhap";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, connectionSQL.conn))
                {
                    insertCmd.Parameters.AddWithValue("@maNCC", cbbNCC.Text);
                    insertCmd.Parameters.AddWithValue("@maNV", cbbNhanVien.Text);
                    insertCmd.Parameters.AddWithValue("@maNhap", txtMaNhap.Text);

                    insertCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDataPhieuNhap();
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

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.CurrentCell != null)
            {
                int rowIndex = dgvPhieuNhap.CurrentCell.RowIndex;

                if (dgvPhieuNhap.Rows[rowIndex].IsNewRow || dgvPhieuNhap.Rows[rowIndex].Cells[0].Value == null)
                {
                    MessageBox.Show("Vui lòng chọn phiếu hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string maPhieu = dgvPhieuNhap.Rows[rowIndex].Cells[0].Value.ToString();

                try
                {
                    connectionSQL.open();

                    // Xác nhận trước khi xóa
                    DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa phiếu: {maPhieu}?",
                                                          "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return;
                    }

                    // Xóa phiếu
                    string deleteQuery = "DELETE FROM NhapHang WHERE maNhap = @maNhap";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, connectionSQL.conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@maNhap", maPhieu);
                        int rowsAffected = deleteCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Load lại dữ liệu sau khi xóa
                            loadDataPhieuNhap();

                            fillCBB(cbbMaPhieu, "SELECT maNhap FROM NhapHang", "maNhap");
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
                MessageBox.Show("Vui lòng chọn phiếu cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTaoMaPhieu_Click(object sender, EventArgs e)
        {
            txtMaNhap.Text = TaoMaNhap();
        }

        private void btnThemVaoPhieu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbMaPhieu.Text))
            {
                MessageBox.Show("Vui lòng chọn mã phiếu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maPhieu = cbbMaPhieu.Text;

            // Lấy thông tin sản phẩm từ bảng tìm kiếm
            string maSP = dgvTimKiem.CurrentRow.Cells["Mã sản phẩm"].Value.ToString();
            string tenSP = "";
            decimal donGia = 0;
            decimal giaNhap = 0;

            try
            {
                connectionSQL.open();

                // Kiểm tra sản phẩm có phải của nhà cung cấp đã chọn ở phiếu nhập không
                string sqlCheck = @"
                            SELECT 
                                (SELECT maNhaCungCap FROM SanPham WHERE maSanPham = @maSP) AS MaNCCSP,
                                (SELECT maNhaCungCap FROM NhapHang WHERE maNhap = @maNhap) AS MaNCCNH";

                using (SqlCommand cmd = new SqlCommand(sqlCheck, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maSP", maSP);
                    cmd.Parameters.AddWithValue("@maNhap", maPhieu);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string maNCCSP = reader["MaNCCSP"]?.ToString();
                            string maNCCNH = reader["MaNCCNH"]?.ToString();

                            if (string.IsNullOrEmpty(maNCCSP) || string.IsNullOrEmpty(maNCCNH) || maNCCSP != maNCCNH)
                            {
                                MessageBox.Show("Sản phẩm không thuộc nhà cung cấp của phiếu nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi kiểm tra nhà cung cấp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
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



            // Lấy tên, giá của sản phẩm
            try
            {
                connectionSQL.open();
                string queryTenSP = "SELECT tenSanPham, gia FROM SanPham WHERE maSanPham = @maSanPham";
                using (SqlCommand cmd = new SqlCommand(queryTenSP, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maSanPham", maSP);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tenSP = reader["tenSanPham"].ToString().Trim();
                            donGia = reader.GetDecimal(reader.GetOrdinal("gia"));
                        }
                        else
                        {
                            MessageBox.Show("Sản phẩm không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                int soLuongTon = Convert.ToInt32(dgvTimKiem.CurrentRow.Cells["SL tồn"].Value);
                int soLuongNhap = 0;

                // Kiểm tra sản phẩm đã có trong dgvSanPham chưa
                foreach (DataGridViewRow row in dgvSanPham.Rows)
                {
                    if (row.Cells["maSP"].Value?.ToString() == maSP)
                    {
                        // Nếu sản phẩm đã tồn tại, chỉ nhập số lượng
                        string soLuongNhapStr = Microsoft.VisualBasic.Interaction.InputBox(
                            $"Nhập thêm số lượng cho sản phẩm {tenSP} (SL tồn: {soLuongTon}):",
                            "Nhập số lượng", "1");

                        if (!int.TryParse(soLuongNhapStr, out soLuongNhap) || soLuongNhap <= 0)
                        {
                            MessageBox.Show("Số lượng nhập không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Cập nhật số lượng mới, giữ nguyên giá nhập cũ
                        int soLuongCu = Convert.ToInt32(row.Cells["soLuong"].Value);
                        decimal giaNhapCu = Convert.ToDecimal(row.Cells["giaNhap"].Value); // Lấy giá nhập cũ
                        row.Cells["soLuong"].Value = soLuongCu + soLuongNhap;
                        row.Cells["thanhTien"].Value = (soLuongCu + soLuongNhap) * giaNhapCu;

                        return;
                    }
                }

                // Nếu sản phẩm chưa có, yêu cầu nhập giá nhập
                string soLuongNhapMoiStr = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Nhập số lượng cho sản phẩm {tenSP} (SL tồn: {soLuongTon}):",
                    "Nhập số lượng", "1");

                if (!int.TryParse(soLuongNhapMoiStr, out soLuongNhap) || soLuongNhap <= 0)
                {
                    MessageBox.Show("Số lượng nhập không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string giaNhapStr = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Nhập giá nhập cho sản phẩm {tenSP}:", "Nhập giá nhập", "0");

                if (!decimal.TryParse(giaNhapStr, out giaNhap) || giaNhap <= 0)
                {
                    MessageBox.Show("Giá nhập không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal thanhTien = soLuongNhap * giaNhap;

                // Thêm sản phẩm mới vào dgvSanPham
                dgvSanPham.Rows.Add(maSP, tenSP, soLuongNhap, giaNhap, donGia, thanhTien);
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


        private void initDgvSanPham()
        {
            dgvSanPham.Columns.Clear();

            dgvSanPham.Columns.Add("maSP", "Mã sản phẩm");
            dgvSanPham.Columns.Add("tenSP", "Tên sản phẩm");
            dgvSanPham.Columns.Add("soLuong", "Số lượng");
            dgvSanPham.Columns.Add("giaNhap", "Giá nhập");
            dgvSanPham.Columns.Add("giaBan", "Giá bán");
            dgvSanPham.Columns.Add("thanhTien", "Thành tiền");
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
            if (e.ColumnIndex == 5 && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal gia))
                {
                    e.Value = gia.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cbbMaPhieu.Text = "";
            // Xóa các sản phẩm trong dgvSanPham
            dgvSanPham.Rows.Clear();

            fillCBB(cbbMaPhieu, "SELECT maNhap FROM NhapHang", "maNhap");
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbMaPhieu.Text))
            {
                MessageBox.Show("Vui lòng chọn mã phiếu nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgvSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào để nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                connectionSQL.open();
                SqlTransaction transaction = connectionSQL.conn.BeginTransaction();

                try
                {
                    string maNhap = cbbMaPhieu.Text;

                    // Kiểm tra mã phiếu có tồn tại không
                    string queryCheckPhieu = "SELECT COUNT(*) FROM NhapHang WHERE maNhap = @maNhap";
                    using (SqlCommand cmd = new SqlCommand(queryCheckPhieu, connectionSQL.conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@maNhap", maNhap);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count == 0)
                        {
                            MessageBox.Show("Mã nhập không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            transaction.Rollback();
                            return;
                        }
                    }

                    int soLuongSanPham = 0;

                    foreach (DataGridViewRow row in dgvSanPham.Rows)
                    {
                        if (row.Cells["maSP"].Value == null) continue;

                        string maSP = row.Cells["maSP"].Value.ToString();
                        int soLuong = Convert.ToInt32(row.Cells["soLuong"].Value);
                        decimal giaNhap = Convert.ToDecimal(row.Cells["giaNhap"].Value);

                        // Thêm dữ liệu vào ChiTietNhapHang
                        string sqlInsert = "INSERT INTO ChiTietNhapHang(maNhap, maSanPham, soLuong, donGia) VALUES (@maNhap, @maSanPham, @soLuong, @donGia)";
                        using (SqlCommand cmd = new SqlCommand(sqlInsert, connectionSQL.conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@maNhap", maNhap);
                            cmd.Parameters.AddWithValue("@maSanPham", maSP);
                            cmd.Parameters.AddWithValue("@soLuong", soLuong);
                            cmd.Parameters.AddWithValue("@donGia", giaNhap);
                            cmd.ExecuteNonQuery();
                        }

                        soLuongSanPham += soLuong;
                    }

                    if (soLuongSanPham > 0)
                    {
                        transaction.Commit();
                        MessageBox.Show($"Nhập hàng thành công {soLuongSanPham} sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDataSanPham();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi nhập hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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



        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int rowIndex = dgvSanPham.CurrentCell.RowIndex;

            if (dgvSanPham.Rows[rowIndex].IsNewRow || dgvSanPham.Rows[rowIndex].Cells[0].Value == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maSP = dgvSanPham.Rows[rowIndex].Cells[0].Value.ToString();

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm: {maSP}?",
                                                  "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                dgvSanPham.Rows.RemoveAt(rowIndex);
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThemHangMoi_Click(object sender, EventArgs e)
        {
            frmPhieuNhap.ThemSanPham themSP = new frmPhieuNhap.ThemSanPham();
            themSP.FormClosed += (s, args) => loadDataSanPham();
            themSP.Show();
        }

        private void btnDSPhieuNhap_Click(object sender, EventArgs e)
        {
            frmPhieuNhap.DanhSachPhieuNhap ds = new frmPhieuNhap.DanhSachPhieuNhap();
            ds.Show();
        }

        private void cbbMaPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                connectionSQL.open();
                SqlTransaction transaction = connectionSQL.conn.BeginTransaction();

                string queryCheckChiTiet = "SELECT COUNT(*) FROM ChiTietNhapHang WHERE maNhap = @maNhap";
                using (SqlCommand cmd = new SqlCommand(queryCheckChiTiet, connectionSQL.conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@maNhap", cbbMaPhieu.SelectedItem);
                    int countCT = Convert.ToInt32(cmd.ExecuteScalar());

                    if (countCT > 0)
                    {
                        MessageBox.Show("Phiếu nhập này đã có sản phẩm, không thể nhập thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbbMaPhieu.Text = "";
                        transaction.Rollback();
                        return;
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
    }
}
