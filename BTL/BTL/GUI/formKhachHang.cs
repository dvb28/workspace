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
    public partial class formKhachHang : Form
    {
        BUS.clsBridge_BUS clsHoaDon_BUS = new BUS.clsBridge_BUS();
        public formKhachHang()
        {
            InitializeComponent();
        }

        private void formKhachHang_Load(object sender, EventArgs e)
        {
            clsHoaDon_BUS.showHoaDon(khachhangTable);
        }
    }
}
