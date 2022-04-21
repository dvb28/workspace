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
        BUS.clsBridge_BUS clsNhanVien_BUS = new BUS.clsBridge_BUS();
        public nhanvienPanel()
        {
            InitializeComponent();
        }

        private void nhanvienPanel_Load(object sender, EventArgs e)
        {
            clsNhanVien_BUS.showHoaDon(nhanvienTable);
        }
    }
}
