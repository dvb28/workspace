using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Bunifu.UI.WinForms;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.GUI.InsertForm {
    public partial class isrNhanVien : Form {
        BunifuDataGridView dvg = new BunifuDataGridView();
        BUS.clsBridge_BUS clsBridge_BUS = new BUS.clsBridge_BUS();
        public isrNhanVien(BunifuDataGridView data) {
            InitializeComponent();
            dvg = data;
        }

        private void bunifuButton21_Click(object sender, EventArgs e) {
            if (txtMaNhanVien.Text == "" || txtTenNhanVien.Text == "" || txtSDT.Text == "" || txtDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thêm?!", "Add Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clsBridge_BUS.addNhanVien(dvg, txtMaNhanVien.Text, txtTenNhanVien.Text, txtSDT.Text, txtDiaChi.Text);
                    MessageBox.Show("Thêm thành công", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void nhanvienBtnUpdate_Click(object sender, EventArgs e) {
            if (txtMaNhanVien.Text == "" || txtTenNhanVien.Text == "" || txtSDT.Text == "" || txtDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thêm?!", "Add Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clsBridge_BUS.updateNhanVien(dvg, txtMaNhanVien.Text, txtTenNhanVien.Text, txtSDT.Text, txtDiaChi.Text);
                    MessageBox.Show("Cập nhật thành công", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
