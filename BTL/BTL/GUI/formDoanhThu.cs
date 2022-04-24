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
using Bunifu.Charts.WinForms;

namespace BTL.GUI {
    public partial class formDoanhThu : Form {
        public formDoanhThu() {
            InitializeComponent();
        }

        static DAL.Connection.clsConnect connection = new DAL.Connection.clsConnect(@"ACER-NITRO-5\SQLEXPRESS", "BTL_QLBH", "sa", "123456@Ab");
        // string strConnection = $@"Data Source=ACER-NITRO-5\SQLEXPRESS;Initial Catalog=BTL_QLBH;User ID =sa;Password=123456@Ab";
        public string strConnection = connection.getConectionString();
        //SqlConnection cnn = new SqlConnection(@"Data Source = MSI\SQLEXPRESS; Initial Catalog = BTL_QLBH; User ID = sa; Password=123");
        SqlCommand cmd;
        SqlDataReader dr;
        private void formDoanhThu_Load(object sender, EventArgs e) {

            doanhSo();
            Dashboard();
            diagramTopHang();
            diagramDoanhThu();
        }

        private void Dashboard() {
            //Tạo kết nối
            SqlConnection cnn = new SqlConnection(strConnection);
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
            lbHangHoa.Text = "SL : " + cmd.Parameters["@SLHang"].Value.ToString();
            lbNhanVien.Text = "SL : " + cmd.Parameters["@SLNhanVien"].Value.ToString();
            lbKhachHang.Text = "SL : " + cmd.Parameters["@SLKH"].Value.ToString();
            lbDoanhThu.Text = "SL : " + cmd.Parameters["@DoanhThu"].Value.ToString();
            cnn.Close();
        }


        //Arraylist để lưu dữ liệu
        ArrayList thang = new ArrayList();
        ArrayList doanhThu = new ArrayList();
        // Diagram doanh số mỗi tháng
        private void diagramDoanhThu() {
            SqlConnection cnn = new SqlConnection(strConnection);
            cmd = new SqlCommand("sp_DoanhThuThang", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cnn.Open();
            dr = cmd.ExecuteReader();
            //Dùng vòng lặp để lấy dữ liệu
            while (dr.Read())
            {
                thang.Add(dr.GetString(0));
                doanhThu.Add(dr.GetString(1));
            }
            //Truyền giá trị cho cột X và Y
            //charDoanhThu.Series[0].Points.DataBindXY(thang, doanhThu);
            dr.Close();
            cnn.Close();
        }
        //Arraylist để lưu dữ liệu
        ArrayList tenHang = new ArrayList();
        ArrayList soLuong = new ArrayList();
        private void diagramTopHang() {
            SqlConnection cnn = new SqlConnection(strConnection);
            cmd = new SqlCommand("sp_topHang", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cnn.Open();
            dr = cmd.ExecuteReader();
            //Dùng vòng lặp để lấy dữ liệu
            while (dr.Read())
            {
                tenHang.Add(dr.GetString(0));
                soLuong.Add(dr.GetInt32(1));
            }
            //Truyền giá trị cho cột X và Y
            charTopHang.Series[0].Points.DataBindXY(tenHang, soLuong);
            dr.Close();
            cnn.Close();
        }
        //Top 5 nhân viên có doanh số cao nhất
        public void doanhSo() {
            SqlConnection cnn = new SqlConnection(strConnection);
            string text = "exec sp_DoanhSo";
            SqlCommand cmd = new SqlCommand(text, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            da.Fill(data);
            //Hiển thị thông tin lên datagridview.
            dgvDoanhSo.DataSource = data;
        }

        private void bunifuDatavizBasic1_Load(object sender, EventArgs e) {

        }
    }
}
