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

namespace BTL.GUI
{
    public partial class nhanvienPanel : Form
    {
        public nhanvienPanel()
        {
            InitializeComponent();
        }

        public DataSet getDataTable()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = $@"Data Source = {"ACER-NITRO-5"}\SQLEXPRESS; Initial Catalog = {"BTL_QLBH"}; User ID = {"sa"}; Password = {"123456@Ab"}";
            conn.Open();
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM NhanVien", conn);
            da.Fill(dt);
            da.Dispose();
            conn.Close();
            return dt;
        }

        private void nhanvienPanel_Load(object sender, EventArgs e)
        {
            nhanvienTable.DataSource = getDataTable().Tables[0];
        }
    }
}
