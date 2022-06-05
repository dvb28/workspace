using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
namespace BTL.GUI
{
    public partial class MainForm : Form
    {
        public string strConnection;
        static formDangNhapDangKy formDangNhapDangKy = new formDangNhapDangKy();
        //Khởi tạo các đối tượng trỏ đến form
        formHangHoa frHangHoa = new formHangHoa();
        nhanvienPanel frNhanVien = new nhanvienPanel();
        formKhachHang frKhachHang = new formKhachHang();
        formHoaDon frHoaDon = new formHoaDon();
        formLienHe frLienHe = new formLienHe();
        formDoanhThu frDoanhThu = new formDoanhThu();
        //formDangNhapDangKy formDangNhapDangKy = new formDangNhapDangKy();
        //List chứa các Form
        List<Form> listForm = new List<Form>();
        private void addFormToList() { listForm.Add(frHangHoa); listForm.Add(frNhanVien); listForm.Add(frKhachHang); listForm.Add(frHoaDon); listForm.Add(frLienHe); listForm.Add(frDoanhThu); }
        public MainForm()
        {
            InitializeComponent();
            addFormToList();
        }

        //Form tùy ý sẽ thành form con của Form Main
        public void formMatch(Form thisForm)
        {
            thisForm.TopLevel = false;
            this.Controls.Add(thisForm);
            thisForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            thisForm.Dock = DockStyle.Fill;
            thisForm.Show();
        }

        //Ẩn Các Form
        private void hideForm(Form notHideForm)
        {
            for (int i = 0; i < listForm.Count; i++)
            {
                if(listForm[i] != notHideForm)
                {
                    listForm[i].Hide();
                }
            }
        }
        //Hiện Form Doanh Thu ngay khi load Form
        private void MainForm_Load(object sender, EventArgs e)
        {
            formMatch(frDoanhThu);
            hideForm(frDoanhThu);
        }

        //Show Form Trang Chủ
        private void trangchuBtn_Click(object sender, EventArgs e)
        {
            formMatch(frDoanhThu);
            hideForm(frDoanhThu);
            indicatorLine.Top = ((Control)sender).Top;
        }
        //Show Form Hàng Hóa
        private void hanghoaBtn_Click(object sender, EventArgs e)
        {
            formMatch(frHangHoa);
            hideForm(frHangHoa);
            indicatorLine.Top = ((Control)sender).Top;
            frHangHoa.loadDataGrid();
        }
        //Show Form Nhân Viên
        private void nhanvienBtn_Click(object sender, EventArgs e)
        {
            formMatch(frNhanVien);
            hideForm(frNhanVien);
            indicatorLine.Top = ((Control)sender).Top;
            frNhanVien.loadDataGrid();
        }
        //Show Form Khách Hàng
        private void khachhangBtn_Click(object sender, EventArgs e)
        {
            formMatch(frKhachHang);
            hideForm(frKhachHang);
            indicatorLine.Top = ((Control)sender).Top;
            frKhachHang.loadDataGrid();
        }
        //Show Form Hóa Đơn
        private void hoadonBtn_Click(object sender, EventArgs e)
        {
            formMatch(frHoaDon);
            hideForm(frHoaDon);
            indicatorLine.Top = ((Control)sender).Top;
            frHoaDon.loadDataGrid();
        }
        //Show Form Liên Hệ
        private void lienheBtn_Click(object sender, EventArgs e)
        {
            formMatch(frLienHe);
            hideForm(frLienHe);
            indicatorLine.Top = ((Control)sender).Top;

        }

        private void logOut_Click(object sender, EventArgs e) {
            if(MessageBox.Show("Bạn muốn đăng xuất?", "Log Out", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Hide();
                formDangNhapDangKy.Show();
            }
        }
    }
}
