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
                MessageBox.Show("Vui lòng nhập mã hàng cần tìm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                hanghoaSearch.Focus();
            } else {
                if(clsHangHoa_BUS.searchHangHoa(hanghoaTable, hanghoaSearch.Text) == -1)
                {
                    MessageBox.Show($"Mã hàng '{hanghoaSearch.Text}' không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    hanghoaSearch.Focus();
                }
            }
        }

        private void hanghoaLuuBtn_Click(object sender, EventArgs e) {

        }

        private void hanghoaXoaBtn_Click(object sender, EventArgs e) {
            if (hanghoaTable.SelectedRows.Count > 0)
            {
                hanghoaTable.Rows.RemoveAt(hanghoaTable.CurrentRow.Index);
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
    }
}
