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
using Aspose.Words;
using Aspose.Words.Tables;
using Lib.Report.AsposeWordExtension;
using Guna.UI2.WinForms;
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

        private void khachhangXoaBtn_Click(object sender, EventArgs e) {
            if (khachhangTable.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    clsKhachHang_BUS.deleteKhachHang(khachhangTable, khachhangTable.CurrentRow.Cells["MaKH"].Value.ToString());
                    MessageBox.Show("Xóa thành công!", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void xuatKhachHang_Click(object sender, EventArgs e) {
            if (MessageBox.Show($"Bạn muốn xuất thông tin khách hàng?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Document hanghoaBaoCao = new Document($@"..\..\CrystalReport\ReportSample\Mau_Khach_Hang.doc");
                Table hanghoaTb = hanghoaBaoCao.GetChild(NodeType.Table, 0, true) as Table;
                int currentRow = 1;
                hanghoaTb.InsertRows(currentRow, currentRow, (khachhangTable.Rows.Count - 1));
                for (int i = 0; i < khachhangTable.Rows.Count; i++)
                {
                    hanghoaTb.PutValue(currentRow, 0, khachhangTable.Rows[i].Cells["MaKH"].Value.ToString());
                    hanghoaTb.PutValue(currentRow, 1, khachhangTable.Rows[i].Cells["TenKH"].Value.ToString());
                    hanghoaTb.PutValue(currentRow, 2, khachhangTable.Rows[i].Cells["SDT"].Value.ToString());
                    hanghoaTb.PutValue(currentRow, 3, khachhangTable.Rows[i].Cells["DiaChi"].Value.ToString());
                    hanghoaTb.PutValue(currentRow, 4, khachhangTable.Rows[i].Cells["LuotMua"].Value.ToString());
                    hanghoaTb.PutValue(currentRow, 5, khachhangTable.Rows[i].Cells["GhiChu"].Value.ToString());
                    currentRow++;
                }
                hanghoaBaoCao.SaveAndOpenFile("BaoCaoKhachHang.pdf");
            }
        }

        private void khachhangLuuBtn_Click(object sender, EventArgs e) {
            GUI.InsertForm.isrKhachHang isrKhachHang = new GUI.InsertForm.isrKhachHang(khachhangTable);
            isrKhachHang.ShowDialog();
        }
    }
}
