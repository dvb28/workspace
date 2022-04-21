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
        
        BUS.clsBridge_BUS tbHangHoa = new BUS.clsBridge_BUS();
        public formHangHoa()
        {
            InitializeComponent();
        }
        //Test lấy dữ liệu ra từ Database
        private void formHangHoa_Load(object sender, EventArgs e)
        {
            tbHangHoa.showHangHoa(hanghoaTable);
        }
    }
}
