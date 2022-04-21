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
        BUS.clsBridge_BUS clsBridge_BUS = new BUS.clsBridge_BUS();
        public formHoaDon()
        {
            InitializeComponent();
        }

        private void formHoaDon_Load(object sender, EventArgs e)
        {
            clsBridge_BUS.showHoaDon(hoadonTable);
        }
        //Hàm test lấy dữ liệu từ Database ra
    }
}
