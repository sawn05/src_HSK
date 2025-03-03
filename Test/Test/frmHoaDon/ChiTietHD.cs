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

namespace Test.frmHoaDon
{
    public partial class ChiTietHD : Form
    {
        ConnectionSQL connectionSQL = new ConnectionSQL();
        convertNumberToWords convert = new convertNumberToWords();

        public ChiTietHD()
        {

        }

        private static string getMaHD = "";
        public ChiTietHD(string maHD, string ngayLap, string khachHang, string sdt, string diaChi, string PTTT, string ghiChu)
        {
            InitializeComponent();

            this.Text = string.Empty;
            this.ControlBox = false;

            getMaHD = maHD;

            lbMaHD.Text = "Mã hóa đơn: " + maHD ;
            lbNgayLap.Text = "Ngày lập: " + ngayLap;
            lbKhachHang.Text = "Khách hàng: " + khachHang;
            lbSoDienThoai.Text = "Số điện thoại: " + sdt;
            lbDiaChi.Text = "Địa chỉ: " + diaChi;

            lbPhuongThucTT.Text = "Phương thức thanh toán: " + (PTTT == "TM" ? "Tiền mặt" : "Chuyển khoản");

            loadSanPham(maHD);

            lbTongTien.Text = getTongTien(maHD).ToString("N0"); 
            lbGhiChu.Text = string.IsNullOrEmpty(ghiChu) ? "Không có" : ghiChu;
        }

        private void loadSanPham(string maHD)
        {
            string sqlSanPham = "SELECT " +
                                "ctdh.maSanPham AS [Mã sản phẩm], " +
                                "sp.tenSanPham AS [Tên sản phẩm], " +
                                "ctdh.soLuong AS [SL mua], " +
                                "ctdh.giaDonHang AS [Đơn giá] " +
                                "FROM ChiTietDonHang ctdh " +
                                "JOIN SanPham sp ON ctdh.maSanPham = sp.maSanPham " +
                                "WHERE ctdh.maHD = @maHD";
            try
            {
                connectionSQL.open();

                using (SqlCommand cmd = new SqlCommand(sqlSanPham, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maHD", maHD);
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    dgvSanPham.DataSource = dt;
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


        private void ChiTietHD_Load(object sender, EventArgs e)
        {
            FormChild.Sach frmSach = new FormChild.Sach();
            frmSach.canChinhDGV(dgvSanPham);
            dgvSanPham.Columns["Tên sản phẩm"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSanPham.Columns["Mã sản phẩm"].Width = 150;
            dgvSanPham.Columns["SL mua"].Width = 55;
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

        private int getTongTien(string maHD)
        {
            string sqlQuery = "SELECT " +
                                "tongTien " +
                                "FROM HoaDon " +
                                "WHERE maHD = @maHD";

            try
            {
                connectionSQL.open();

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connectionSQL.conn))
                {
                    cmd.Parameters.AddWithValue("@maHD", maHD);

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

        private void btnMinimun_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            string tienChu = lbTienChu.Text;
            string ghiChu = lbGhiChu.Text;
            string maHD = "";
            if (!string.IsNullOrEmpty(getMaHD))
            {
                maHD = getMaHD;
            }

            DataTable dt = new DataTable();

            try
            {
                connectionSQL.open();
                using (SqlCommand cmd = new SqlCommand("sp_GetChiTietHoaDon", connectionSQL.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@maHoaDon", maHD);

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

            rptChiTietHD report = new rptChiTietHD();
            report.SetDataSource(dt);

            report.SetParameterValue("TienChu", tienChu);
            report.SetParameterValue("GhiChu", ghiChu);

            FormInRptHD frm = new FormInRptHD(report);
            frm.ShowDialog();
        }
    }
}
