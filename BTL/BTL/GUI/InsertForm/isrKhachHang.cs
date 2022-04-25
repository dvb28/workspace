using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
namespace BTL.GUI.InsertForm {
    public partial class isrKhachHang : Form {
        BUS.clsBridge_BUS clsKhachHang_BUS = new BUS.clsBridge_BUS();
        BunifuDataGridView dvg = new BunifuDataGridView();
        public isrKhachHang(BunifuDataGridView data) {
            InitializeComponent();
            loadGhiChu();
            dvg = data;
        }

        //Load Ghi Chú
        public void loadGhiChu() {
            try
            {   
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT GhiChu FROM KhachHang", clsKhachHang_BUS.strConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string text = dt.Rows[j]["GhiChu"].ToString();
                    this.cbbGhiChu.Items.Add(text);
                    cbbGhiChu.ValueMember = "GhiChu";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bunifuButton21_Click(object sender, EventArgs e) {
                        if (txtMaKH.Text == "" || txtTenKH.Text == "" || txtSDT.Text == "" || txtDiaChi.Text == "" || txtDiaChi.Text == "" || txtLuotMua.Text == "" || cbbGhiChu.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thêm?!", "Add Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clsKhachHang_BUS.addKhachHang(dvg, txtMaKH.Text, txtTenKH.Text, txtSDT.Text, txtDiaChi.Text, int.Parse(txtLuotMua.Text), cbbGhiChu.Text);
                }
            }
        }
    }
}
