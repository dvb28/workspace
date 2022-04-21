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
    public partial class formHangHoa : Form
    {
        public formHangHoa()
        {
            InitializeComponent();
        }

        //Test lấy dữ liệu ra từ Database
        public DataSet getDataTable()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = $@"Data Source = {"ACER-NITRO-5"}\SQLEXPRESS; Initial Catalog = {"BTL_QLBH"}; User ID = {"sa"}; Password = {"123456@Ab"}";
            conn.Open();
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM HangHoa", conn);
            da.Fill(dt);
            da.Dispose();
            conn.Close();
            return dt;
        }
        private void formHangHoa_Load(object sender, EventArgs e)
        {
            hanghoaTable.DataSource = getDataTable().Tables[0];
        }
    }
}
