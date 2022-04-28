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
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
namespace BTL.GUI.InsertForm {
    public partial class isrHangHoa : Form {
        public Guna2DataGridView dtg = new Guna2DataGridView();
        public isrHangHoa(Guna2DataGridView HangHoa) {
            InitializeComponent();
            loadLoaiHang();
            loadNhaCC();
            this.dtg = HangHoa;
        }
        BUS.clsBridge_BUS clsHangHoa_BUS = new BUS.clsBridge_BUS();
        //Load Loại Hàng
        public void loadLoaiHang() {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaLoai, TenLoai FROM PhanLoai", clsHangHoa_BUS.strConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string text = dt.Rows[j]["MaLoai"].ToString() + " : " + dt.Rows[j]["TenLoai"].ToString();
                    this.loaihangCbb.Items.Add(text);
                    loaihangCbb.ValueMember = "MaLoai";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //Load Nhà Cung Cấp
        public void loadNhaCC() {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaNCC, TenNCC FROM NhaCC", clsHangHoa_BUS.strConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string text = dt.Rows[j]["MaNCC"].ToString() + " : " + dt.Rows[j]["TenNCC"].ToString();
                    this.nhacungcapCbb.Items.Add(text);
                    nhacungcapCbb.ValueMember = "MaNCC";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bunifuButton21_Click(object sender, EventArgs e) {
            if (txtMaHang.Text == "" || txtTenHang.Text == "" || loaihangCbb.Text == "" || nhacungcapCbb.Text == "" || txtGia.Text == "" || txtSoLuong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thêm?!", "Add Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clsHangHoa_BUS.addHangHoa(dtg, txtMaHang.Text, txtTenHang.Text, loaihangCbb.Text, nhacungcapCbb.Text, int.Parse(txtGia.Text), int.Parse(txtSoLuong.Text));
                    MessageBox.Show("Thêm thành công", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void hanghoaBtnUpdate_Click(object sender, EventArgs e) {
            if (txtMaHang.Text == "" || txtTenHang.Text == "" || loaihangCbb.Text == "" || nhacungcapCbb.Text == "" || txtGia.Text == "" || txtSoLuong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật?!", "Add Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clsHangHoa_BUS.updateHangHoa(dtg, txtMaHang.Text, txtTenHang.Text, loaihangCbb.Text, nhacungcapCbb.Text, int.Parse(txtGia.Text), int.Parse(txtSoLuong.Text));
                    MessageBox.Show("Cập nhật thành công", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
