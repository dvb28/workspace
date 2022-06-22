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
using Guna.UI2.WinForms;
using Bunifu.Charts.WinForms;
namespace BTL.DAL.Interface {
    interface IDoanhThu {
        //Phương thức để load dữ liệu của form doanh thu
        void Dashboard(string sqlConnection, BunifuLabel HangHoa, BunifuLabel HoaDon, BunifuLabel KhachHang, BunifuLabel NhanVien, BunifuLabel DoanhThu);
        DataTable loadBestStaff(string sqlConnection);
        void LoadChart(string strConnection, BunifuChartCanvas chartDoanhThu, List<string> listMonth, List<string> listDoanhThu);
        void TopNhanVien(string strConnection, Guna2DataGridView chartTopHang);
    }
}
