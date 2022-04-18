using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.GUI
{
    public partial class formHoaDon : Form
    {
        public formHoaDon()
        {
            InitializeComponent();
        }

        private void formHoaDon_Load(object sender, EventArgs e)
        {
            hoadonTable.DataSource = getDataTable().Tables[0];

        }
        //Hàm test lấy dữ liệu từ Database ra
        public DataSet getDataTable()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = $@"Data Source = {"ACER-NITRO-5"}\SQLEXPRESS; Initial Catalog = {"BTL_QLBH"}; User ID = {"sa"}; Password = {"123456@Ab"}";
            conn.Open();
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM HoaDon", conn);
            da.Fill(dt);
            da.Dispose();
            conn.Close();
            return dt;
        }
    }
}
