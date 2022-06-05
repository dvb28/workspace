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
using Guna.UI2.WinForms;
namespace BTL.GUI.InsertForm {
    public partial class isrKhachHang : Form {
        BUS.clsBridge_BUS clsKhachHang_BUS = new BUS.clsBridge_BUS();
        Guna2DataGridView dvg = new Guna2DataGridView();
        public isrKhachHang(Guna2DataGridView data) {
            InitializeComponent();
            dvg = data;
        }


        private void bunifuButton21_Click(object sender, EventArgs e) {
            if (txtMaKH.Text == "" || txtTenKH.Text == "" || txtSDT.Text == "" || txtDiaChi.Text == "" || txtDiaChi.Text == "" || txtLuotMua.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thêm?!", "Add Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clsKhachHang_BUS.addKhachHang(dvg, txtMaKH.Text, txtTenKH.Text, txtSDT.Text, txtDiaChi.Text, int.Parse(txtLuotMua.Text));
                    MessageBox.Show("Thêm thành công", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void khachhangBtnUpdate_Click(object sender, EventArgs e) {
            if (txtMaKH.Text == "" || txtTenKH.Text == "" || txtSDT.Text == "" || txtDiaChi.Text == "" || txtDiaChi.Text == "" || txtLuotMua.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thêm?!", "Add Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clsKhachHang_BUS.updateKhachHang(dvg, txtMaKH.Text, txtTenKH.Text, txtSDT.Text, txtDiaChi.Text, int.Parse(txtLuotMua.Text));
                    MessageBox.Show("Cập nhật thành công", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
