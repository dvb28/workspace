using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.GUI
{
    public partial class formKhachHang : Form
    {
        BUS.clsBridge_BUS clsKhachHang_BUS = new BUS.clsBridge_BUS();
        public formKhachHang()
        {
            InitializeComponent();
        }
        //Đổ dữ liệu vào trong DataGridView
        public void loadDataGrid() {
            clsKhachHang_BUS.showKhachHang(khachhangTable);
        }

        //Tìm kiếm
        private void khachhangSearchBtn_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(khachhangSearch.Text))
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng cần tìm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                khachhangSearch.Focus();
            } else
            {
                if (clsKhachHang_BUS.searchKhachHang(khachhangTable, khachhangSearch.Text) == -1)
                {
                    MessageBox.Show($"Mã khách hàng '{khachhangSearch.Text}' không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    khachhangSearch.Focus();
                }
            }
        }

        private void khachhangSearch_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
            {
                khachhangSearchBtn.PerformClick();
            }
        }

        private void khachhangThemBtn_Click(object sender, EventArgs e) {
            GUI.InsertForm.isrKhachHang isrKhachHang = new GUI.InsertForm.isrKhachHang(khachhangTable);
            isrKhachHang.ShowDialog();
        }
    }
}
