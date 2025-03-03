using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    class ConnectionSQL
    {
        public SqlConnection conn = new SqlConnection();


        // Mở kết nối CSDL
        public void open()
        {
            try
            {
                if (conn.State == 0)
                {
                    conn.ConnectionString = @"Data Source=SANGG\SQLEXPRESS;Initial Catalog=QLSach;Integrated Security=True";
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối đến CSDL: " + ex.Message, "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Đóng kết nối CSDL
        public void close()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }


        // Phương thức truy vấn để xem dữ liệu
        public DataTable hienDL(string sql)
        {
            open();

            try
            {
                SqlDataAdapter adap = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                return dt;
            }
            finally
            {
                close();
            }
        }

        public DataTable hienDL_Para_Command(SqlCommand cmd)
        {
            open();

            try
            {
                cmd.Connection = conn; // Gán connection cho command
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                return dt;
            }
            finally
            {
                close();
            }
        }



        // Phương thức truy vấn dữ liệu: Insert, Update, Delete
        public SqlCommand thucThiDl(string sql)
        {
            open();
            try
            {
                SqlCommand cm = new SqlCommand(sql, conn);
                cm.ExecuteNonQuery();

                return cm;
            }
            finally
            {
                close();
            }
        }
    }
}
