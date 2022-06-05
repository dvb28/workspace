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
namespace BTL.GUI
{
    public partial class formHangHoa : Form
    {
        
        BUS.clsBridge_BUS clsHangHoa_BUS = new BUS.clsBridge_BUS();
        public formHangHoa()
        {
            InitializeComponent();
        }
        //Đổ dữ liệu vào trong DataGridView
        public void loadDataGrid() {
            clsHangHoa_BUS.showHangHoa(hanghoaTable);
        }

        //Tìm kiếm
        private void hanghoaSearchBtn_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(hanghoaSearch.Text))
            {
                MessageBox.Show("Vui lòng nhập mã máy cần tìm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                hanghoaSearch.Focus();
            } else {
                if(clsHangHoa_BUS.searchHangHoa(hanghoaTable, hanghoaSearch.Text) == -1)
                {
                    MessageBox.Show($"Mã máy '{hanghoaSearch.Text}' không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    hanghoaSearch.Focus();
                }
            }
        }

        private void hanghoaSuaBtn_Click(object sender, EventArgs e) {
            GUI.InsertForm.isrHangHoa isrHangHoa = new GUI.InsertForm.isrHangHoa(hanghoaTable);
            isrHangHoa.ShowDialog();
        }

        private void hanghoaXoaBtn_Click(object sender, EventArgs e) {
            if (hanghoaTable.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    clsHangHoa_BUS.deleteHangHoa(hanghoaTable, hanghoaTable.CurrentRow.Cells["MaMay"].Value.ToString());
                    MessageBox.Show("Xóa thành công!", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        //Các sự kiện phụ
        private void hanghoaSearch_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                hanghoaSearchBtn.PerformClick();
            }
        }

        private void hanghoaThemBtn_Click(object sender, EventArgs e) {
            GUI.InsertForm.isrHangHoa isrHangHoa = new GUI.InsertForm.isrHangHoa(hanghoaTable);
            isrHangHoa.ShowDialog();
        }

        private void xuatHangHoa_Click(object sender, EventArgs e) {
            if (MessageBox.Show($"Bạn muốn xuất thông tin máy tính?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Document hanghoaBaoCao = new Document($@"..\..\CrystalReport\ReportSample\BaoCaoHangHoa.doc");
                Table hanghoaTb = hanghoaBaoCao.GetChild(NodeType.Table, 0, true) as Table;
                int currentRow = 1;
                hanghoaTb.InsertRows(currentRow, currentRow, (hanghoaTable.Rows.Count - 1));
                for (int i = 0; i < hanghoaTable.Rows.Count; i++)
                {
                    hanghoaTb.PutValue(currentRow, 0, hanghoaTable.Rows[i].Cells["MaMay"].Value.ToString());
                    hanghoaTb.PutValue(currentRow, 1, hanghoaTable.Rows[i].Cells["TenLoai"].Value.ToString());
                    hanghoaTb.PutValue(currentRow, 2, hanghoaTable.Rows[i].Cells["TenNCC"].Value.ToString());
                    hanghoaTb.PutValue(currentRow, 3, hanghoaTable.Rows[i].Cells["TenMay"].Value.ToString());
                    hanghoaTb.PutValue(currentRow, 4, hanghoaTable.Rows[i].Cells["Gia"].Value.ToString() + "$");
                    hanghoaTb.PutValue(currentRow, 5, hanghoaTable.Rows[i].Cells["SoLuong"].Value.ToString());
                    currentRow++;
                }
                hanghoaBaoCao.SaveAndOpenFile("BaoCaoHang.pdf");
            }
        }
    }
}
