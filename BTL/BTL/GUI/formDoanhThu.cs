using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using Bunifu.UI.WinForms;
using Bunifu.Dataviz.WinForms;
using Bunifu.Charts.WinForms.ChartTypes;
namespace BTL.GUI {
    public partial class formDoanhThu : Form {
        public formDoanhThu() {
            InitializeComponent();
        }
        static List<string> listMonth = new List<string>();
        static List<string> listDoanhThu = new List<string>();
        static BUS.clsBridge_BUS clsBridge_BUS = new BUS.clsBridge_BUS();
        public string strConnection = clsBridge_BUS.strConnection;
        SqlCommand cmd;
        SqlDataReader dr;
        private void formDoanhThu_Load(object sender, EventArgs e) {
            clsBridge_BUS.loadTopNhanVien(chartTopNhanVien);
            clsBridge_BUS.loadDashboard(lbHangHoa, lbHoaDon, lbKhachHang, lbNhanVien, lbDoanhThu);
            clsBridge_BUS.loadChart(chartDoanhThu, listMonth, listDoanhThu);
            clsBridge_BUS.loadBestStafff(lbDoanhSoNhanVien, lbdoanhssNVNum);
        }
    }
}
