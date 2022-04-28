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
using Lib.Report.AsposeWordExtension;
namespace BTL.GUI
{
    public partial class formHoaDon : Form
    {
        BUS.clsBridge_BUS clsBridge_BUS = new BUS.clsBridge_BUS();
        public formHoaDon()
        {
            InitializeComponent();
        }
        //Đổ dữ liệu vào trong DataGridView
        public void loadDataGrid() {
            clsBridge_BUS.showHoaDon(hoadonTable);
        }

        //Tìm kiếm
        private void hoadonSearchBtn_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(hoadonSearch.Text))
            {
                MessageBox.Show("Vui lòng nhập mã hàng cần tìm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                hoadonSearch.Focus();
            } else
            {
                if (clsBridge_BUS.searchHoaDon(hoadonTable, hoadonSearch.Text) == -1)
                {
                    MessageBox.Show($"Mã hàng '{hoadonSearch.Text}' không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    hoadonSearch.Focus();
                }
            }
        }

        private void hoadonSearch_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
            {
                hoadonSearchBtn.PerformClick();
            }
        }

        private void hanghoaThemBtn_Click(object sender, EventArgs e) {
            GUI.InsertForm.isrHoaDon isrHoaDon = new GUI.InsertForm.isrHoaDon(hoadonTable);
            isrHoaDon.ShowDialog();
        }

        
        private void xuatHoaDon_Click(object sender, EventArgs e) {
            if(MessageBox.Show($"Bạn muốn xuất hóa đơn có mã {hoadonTable.CurrentRow.Cells["MaHD"].Value.ToString()}", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                double dongGia = double.Parse(hoadonTable.CurrentRow.Cells["ThanhToan"].Value.ToString()) / double.Parse(hoadonTable.CurrentRow.Cells["SoLuong"].Value.ToString());
                Document crytalReport = new Document($@"..\..\CrystalReport\ReportSample\TRIOSHOP.doc");
                crytalReport.MailMerge.Execute(new[] { "MaHD" }, new[] { hoadonTable.CurrentRow.Cells["MaHD"].Value.ToString() });
                crytalReport.MailMerge.Execute(new[] { "TenKH" }, new[] { hoadonTable.CurrentRow.Cells["TenKH"].Value.ToString() });
                crytalReport.MailMerge.Execute(new[] { "TenHang" }, new[] { hoadonTable.CurrentRow.Cells["TenHang"].Value.ToString() });
                crytalReport.MailMerge.Execute(new[] { "SoLuong" }, new[] { hoadonTable.CurrentRow.Cells["SoLuong"].Value.ToString() });
                crytalReport.MailMerge.Execute(new[] { "NgayHD" }, new[] { hoadonTable.CurrentRow.Cells["NgayHD"].Value.ToString() });
                crytalReport.MailMerge.Execute(new[] { "ThanhToan" }, new[] { hoadonTable.CurrentRow.Cells["ThanhToan"].Value.ToString()});
                crytalReport.MailMerge.Execute(new[] { "DonGia" }, new[] { dongGia.ToString()});
                crytalReport.SaveAndOpenFile("BaoCao.pdf");
            }
        }

        private void hanghoaXoaBtn_Click(object sender, EventArgs e) {
            if (hoadonTable.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    clsBridge_BUS.deleteHoaDon(hoadonTable, hoadonTable.CurrentRow.Cells["MaHD"].Value.ToString());
                    MessageBox.Show("Xóa thành công!", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void hanghoaLuuBtn_Click(object sender, EventArgs e) {
            GUI.InsertForm.isrHoaDon isrHoaDon = new GUI.InsertForm.isrHoaDon(hoadonTable);
            isrHoaDon.ShowDialog();
        }
    }
}
