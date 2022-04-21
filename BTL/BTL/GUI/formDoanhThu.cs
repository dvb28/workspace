using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.GUI
{
    public partial class formDoanhThu : Form
    {
        public formDoanhThu()
        {
            InitializeComponent();
        }

        static DAL.Connection.clsConnect connection = new DAL.Connection.clsConnect(@"ACER-NITRO-5\SQLEXPRESS", "BTL_QLBH", "sa", "123456@Ab");
        // string strConnection = $@"Data Source=ACER-NITRO-5\SQLEXPRESS;Initial Catalog=BTL_QLBH;User ID =sa;Password=123456@Ab";
        public string strConnection = connection.getConectionString();

        private void formDoanhThu_Load(object sender, EventArgs e)
        {
            MessageBox.Show(strConnection);
        }
    }
}
