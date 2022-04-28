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
using Bunifu.Charts.WinForms.ChartTypes;
using Bunifu.Charts.WinForms;
namespace BTL.DAL {
    internal class clsDoanhThu_DAL {
        SqlCommand cmd;
        SqlDataReader dr;
        public void Dashboard(string sqlConnection, BunifuLabel HangHoa, BunifuLabel HoaDon, BunifuLabel KhachHang, BunifuLabel NhanVien, BunifuLabel DoanhThu) {
            //Tạo kết nối
            SqlConnection cnn = new SqlConnection(sqlConnection);
            cmd = new SqlCommand("Dashboard", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter Hang = new SqlParameter("@SLHang", 0); Hang.Direction = ParameterDirection.Output;
            SqlParameter nhanVien = new SqlParameter("@SLNhanVien", 0); nhanVien.Direction = ParameterDirection.Output;
            SqlParameter hoaDon = new SqlParameter("@SLHoaDon", 0); hoaDon.Direction = ParameterDirection.Output;
            SqlParameter khachHang = new SqlParameter("@SLKH", 0); khachHang.Direction = ParameterDirection.Output;
            SqlParameter doanhThu = new SqlParameter("@DoanhThu", 0); doanhThu.Direction = ParameterDirection.Output;
            //Thêm dữ liệu 
            cmd.Parameters.Add(Hang);
            cmd.Parameters.Add(nhanVien);
            cmd.Parameters.Add(hoaDon);
            cmd.Parameters.Add(khachHang);
            cmd.Parameters.Add(doanhThu);
            cnn.Open();
            cmd.ExecuteNonQuery();
            // In dữ liệu ra lable
            HangHoa.Text = cmd.Parameters["@SLHang"].Value.ToString() + " loại hàng";
            NhanVien.Text = cmd.Parameters["@SLNhanVien"].Value.ToString() + " nhân viên";
            KhachHang.Text = cmd.Parameters["@SLKH"].Value.ToString() + " khách hàng";
            DoanhThu.Text = "$ " + cmd.Parameters["@DoanhThu"].Value.ToString() + "K";
            HoaDon.Text = cmd.Parameters["@SLHoaDon"].Value.ToString() + " HĐ đã xuất";
            cnn.Close();
        }

        //Top Hàng hóa bán chạy nhất
        public DataTable topHang(string strConnection) {
            SqlConnection cnn = new SqlConnection(strConnection);
            string text = "exec sp_topHang";
            SqlCommand cmd = new SqlCommand(text, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            da.Fill(data);
            return data;
        }
        //Bảng doanh thu
        public void LoadChart(string strConnection, BunifuChartCanvas chartDoanhThu, List<string> listMonth, List<string> listDoanhThu) {
            Bunifu.Charts.WinForms.ChartTypes.BunifuLineChart lineChart = new Bunifu.Charts.WinForms.ChartTypes.BunifuLineChart();
            SqlConnection cnn = new SqlConnection(strConnection);
            cmd = new SqlCommand("sp_DoanhThuThang", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cnn.Open();
            dr = cmd.ExecuteReader();
            //Dùng vòng lặp để lấy dữ liệu
            while (dr.Read())
            {
                listMonth.Add(dr.GetString(0));
                listDoanhThu.Add(dr.GetString(1));
            }
            //Conver List String To Doubles
            List<double> arrayDoanhThu = listDoanhThu.ConvertAll(item => double.Parse(item));
            lineChart.Data = arrayDoanhThu;
            lineChart.TargetCanvas = chartDoanhThu;
            lineChart.BorderColor = Color.DodgerBlue;
            lineChart.PointBorderColor = Color.DodgerBlue;
            lineChart.PointBackgroundColor = Color.White;
            string[] arrayMonth = new string[listMonth.Count];
            int i = 0;
            foreach (var item in listMonth)
            {
                arrayMonth[i] = item.ToString();
                i++;
            }
            chartDoanhThu.Labels = arrayMonth;
            dr.Close();
            cnn.Close();
        }

        public DataTable loadBestStaff(string strSqlConnection) {
            SqlConnection conn = new SqlConnection(strSqlConnection);
            conn.Open();
            string sql = "sp_DoanhSo";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            da.Dispose();
            conn.Close();
            conn.Dispose();
            return table;
        }
    }
}
