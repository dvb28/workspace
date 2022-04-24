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
using Bunifu.UI.WinForms;
namespace BTL.GUI.InsertForm {
    public partial class isrHoaDon : Form {
        public BunifuDataGridView dvg = new BunifuDataGridView();
        public isrHoaDon(BunifuDataGridView data) {
            InitializeComponent();
            loadHangHoa();
            loadNhanVien();
            loadKhachHang();
            dvg = data;
        }

        BUS.clsBridge_BUS clsHangHoa_BUS = new BUS.clsBridge_BUS();
        //Load Mã Hàng
        public void loadHangHoa() {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaHang, TenHang FROM HangHoa", clsHangHoa_BUS.strConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string text = dt.Rows[j]["MaHang"].ToString() + " : " + dt.Rows[j]["TenHang"].ToString();
                    this.txtMaHang.Items.Add(text);
                    txtMaHang.ValueMember = "MaHang";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //Load Mã Nhân Viên
        public void loadNhanVien() {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaNV, TenNV FROM NhanVien", clsHangHoa_BUS.strConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string text = dt.Rows[j]["MaNV"].ToString() + " : " + dt.Rows[j]["TenNV"].ToString();
                    this.txtMaNV.Items.Add(text);
                    txtMaNV.ValueMember = "MaNV";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //Load Mã Khách Hàng
        public void loadKhachHang() {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT HD.MaKH, KH.TenKH FROM HoaDon HD, KhachHang KH WHERE HD.MaKH = KH.MaKH", clsHangHoa_BUS.strConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string text = dt.Rows[j]["MaKH"].ToString() + " : " + dt.Rows[j]["TenKH"].ToString();
                    this.txtMaKH.Items.Add(text);
                    txtMaKH.ValueMember = "MaKH";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void bunifuButton21_Click(object sender, EventArgs e) {
            if (txtMaHang.Text == "" || txtMaHD.Text == "" || txtMaHang.Text == "" || txtMaNV.Text == "" || txtMaKH.Text == "" || txtNgayHD.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thêm?!", "Add Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clsHangHoa_BUS.addHoaDon(dvg, txtMaHD.Text, txtMaHang.Text, txtMaNV.Text, txtMaKH.Text, txtNgayHD.Text);
                }
            }
        }
    }
}
