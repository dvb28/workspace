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

namespace BTL.GUI
{
    public partial class nhanvienPanel : Form
    {
        BUS.clsBridge_BUS clsNhanVien_BUS = new BUS.clsBridge_BUS();
        public nhanvienPanel()
        {
            InitializeComponent();
        }

        //Đổ dữ liệu vào trong DataGridView
        public void loadDataGrid() {
            clsNhanVien_BUS.showNhanVien(nhanvienTable);
        }

        //Tìm kiếm
        private void nhanvienSearchBtn_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(nhanvienSearch.Text))
            {
                MessageBox.Show("Vui lòng nhập mã hàng cần tìm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                nhanvienSearch.Focus();
            } else
            {
                if (clsNhanVien_BUS.searchNhanVien(nhanvienTable, nhanvienSearch.Text) == -1)
                {
                    MessageBox.Show($"Mã hàng '{nhanvienSearch.Text}' không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nhanvienSearch.Focus();
                }
            }
        }

        private void nhanvienSearch_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
            {
                nhanvienSearchBtn.PerformClick();
            }
        }

        private void hanghoaThemBtn_Click(object sender, EventArgs e) {
            GUI.InsertForm.isrNhanVien isrNhanVien = new GUI.InsertForm.isrNhanVien(nhanvienTable);
            isrNhanVien.ShowDialog();
        }

        private void hanghoaXoaBtn_Click(object sender, EventArgs e) {
            if (nhanvienTable.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    clsNhanVien_BUS.deleteHoaDon(nhanvienTable, nhanvienTable.CurrentRow.Cells["MaNV"].Value.ToString());
                    MessageBox.Show("Xóa thành công!", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
