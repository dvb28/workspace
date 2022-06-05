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
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using Bunifu.Charts.WinForms;
using BTL.DAL;
namespace BTL.BUS
{
    internal class clsBridge_BUS
    {
        //Thay đổi chuỗi kết nối phù hợp với máy
        static DAL.Connection.clsConnect connection = new DAL.Connection.clsConnect(@"ACER-NITRO-5\SQLEXPRESS", "QLBH_MT", "sa", "123456@Ab");
        public string strConnection = connection.getConectionString();
        DAL.clsHangHoa_DAL.clsHangHoa_DAL objHangHoa = new DAL.clsHangHoa_DAL.clsHangHoa_DAL();
        DAL.clsNhanVien_DAL.clsNhanVien_DAL objNhanVien = new DAL.clsNhanVien_DAL.clsNhanVien_DAL();
        DAL.clsKhachHang_DAL.clsKhachHang_DAL objKhachHang = new DAL.clsKhachHang_DAL.clsKhachHang_DAL();
        DAL.clsHoaDon_DAL.clsHoaDon_DAL objHoaDon = new DAL.clsHoaDon_DAL.clsHoaDon_DAL();
        DAL.clsDoanhThu_DAL objDoanhThu = new DAL.clsDoanhThu_DAL();
        //Load dữ liệu từ Dasboard lên
        public void loadDashboard(BunifuLabel HangHoa, BunifuLabel HoaDon, BunifuLabel KhachHang, BunifuLabel NhanVien, BunifuLabel DoanhThu) {
            objDoanhThu.Dashboard(strConnection, HangHoa, HoaDon, KhachHang, NhanVien, DoanhThu);
        }
        //Load TopNhanVien
        public void loadTopHang(Guna2DataGridView chartTopNhanVien) {
            chartTopNhanVien.DataSource = objDoanhThu.topHang(strConnection);
            chartTopNhanVien.Columns[0].HeaderText = "Tên Hàng";
            chartTopNhanVien.Columns[1].HeaderText = "Số Lượng";
        }
        public void loadChart(BunifuChartCanvas chartDoanhThu, List<string> listMonth, List<string> listDoanhThu) {
            objDoanhThu.LoadChart(strConnection, chartDoanhThu, listMonth, listDoanhThu);
        }
        public int loadBestStafff(BunifuLabel tenNV, BunifuLabel soSP) {
            DataTable data = objDoanhThu.loadBestStaff(strConnection);
            tenNV.Text = data.Rows[0][0].ToString();
            soSP.Text = data.Rows[0][1].ToString();
            return 1;
        }
        //Đẩy dữ liệu của bảng HangHoa lên DataGridView
        public void showHangHoa(Guna2DataGridView data)
        {
            data.DataSource = objHangHoa.Get(strConnection);
            data.Columns[0].HeaderText = "Mã Máy";
            data.Columns[1].HeaderText = "Loại Máy";
            data.Columns[2].HeaderText = "Mã NCC";
            data.Columns[3].HeaderText = "Tên Hàng";
            data.Columns[4].HeaderText = "Giá($)";
            data.Columns[5].HeaderText = "Số Lượng";
        }
        //Đẩy dữ liệu của bảng NhanVien lên DataGridView
        public void showNhanVien(Guna2DataGridView data)
        {
            data.DataSource = objNhanVien.Get(strConnection);
            data.Columns[0].HeaderText = "Mã NV";
            data.Columns[1].HeaderText = "Tên Nhân Viên";
            data.Columns[2].HeaderText = "SĐT";
            data.Columns[3].HeaderText = "Địa Chỉ";
        }
        //Đẩy dữ liệu của bảng NhanVien lên DataGridView
        public void showKhachHang(Guna2DataGridView data)
        {
            data.DataSource = objKhachHang.Get(strConnection);
            data.Columns[0].HeaderText = "Mã KH";
            data.Columns[1].HeaderText = "Tên KH";
            data.Columns[2].HeaderText = "SĐT";
            data.Columns[3].HeaderText = "Địa Chỉ";
            data.Columns[4].HeaderText = "Lượt Mua";
            data.Columns[5].HeaderText = "Ghi Chú";
        }
        //Đẩy dữ liệu của bảng NhanVien lên DataGridView
        public void showHoaDon(Guna2DataGridView data)
        {
            data.DataSource = objHoaDon.Get(strConnection);
            data.Columns[0].HeaderText = "Mã HĐ";
            data.Columns[1].HeaderText = "Tên Máy";
            data.Columns[2].HeaderText = "Nhân Viên";
            data.Columns[3].HeaderText = "Số Lượng";
            data.Columns[4].HeaderText = "Tên Khách";
            data.Columns[6].HeaderText = "Ngày Xuất";
            data.Columns[6].HeaderText = "Thanh Toán";
        }
        //Chức năng tìm kiếm
        //Tìm kiếm hàng hóa
        public int searchHangHoa(Guna2DataGridView data, string searchContent) {
            if(objHangHoa.Search(strConnection, searchContent).Rows.Count > 0)
            {
                data.DataSource = objHangHoa.Search(strConnection, searchContent);
                return 1;
            } else
            {
                return -1;
            }
        }
        //Tìm kiếm nhân viên
        public int searchNhanVien(Guna2DataGridView data, string searchContent) {
            if (objNhanVien.Search(strConnection, searchContent).Rows.Count > 0)
            {
                data.DataSource = objNhanVien.Search(strConnection, searchContent);
                return 1;
            } else
            {
                return -1;
            }
        }

        //Tìm kiếm hóa đơn
        public int searchHoaDon(Guna2DataGridView data, string searchContent) {
            if (objHoaDon.Search(strConnection, searchContent).Rows.Count > 0)
            {
                data.DataSource = objHoaDon.Search(strConnection, searchContent);
                return 1;
            } else
            {
                return -1;
            }
        }

        //Tìm kiếm khách hàng
        public int searchKhachHang(Guna2DataGridView data, string searchContent) {
            if (objKhachHang.Search(strConnection, searchContent).Rows.Count > 0)
            {
                data.DataSource = objKhachHang.Search(strConnection, searchContent);
                return 1;
            } else
            {
                return -1;
            }
        }

        //Thêm hàng hóa
        public int addHangHoa(Guna2DataGridView data, string MaHang, string TenHang, string LoaiHang, string NhaCC, int Gia, int SoLuong) {
            DAL.clsHangHoa_DAL.clsHangHoa_DAL thisObjHangHoa = new DAL.clsHangHoa_DAL.clsHangHoa_DAL(MaHang, TenHang, LoaiHang, NhaCC, Gia, SoLuong);
            thisObjHangHoa.Add(strConnection);
            data.DataSource = thisObjHangHoa.Get(strConnection);
            return 1;
        }

        //Thêm Hóa Đơn
        public int addHoaDon(Guna2DataGridView data, string MaHD, string MaHang, string MaNV, string MaKH, string NgayHD) {
            DAL.clsHoaDon_DAL.clsHoaDon_DAL thisObjHoaDon = new DAL.clsHoaDon_DAL.clsHoaDon_DAL(MaHD, MaHang, MaNV, MaKH, NgayHD);
            thisObjHoaDon.Add(strConnection);
            data.DataSource = thisObjHoaDon.Get(strConnection);
            return 1;
        }

        //Thêm khách hàng
        public int addKhachHang(Guna2DataGridView data, string MaKH, string TenKH, string SDT, string DiaChi, int LuotMua) {
            DAL.clsKhachHang_DAL.clsKhachHang_DAL thisObjKhachHang = new DAL.clsKhachHang_DAL.clsKhachHang_DAL(MaKH, TenKH, SDT, DiaChi, LuotMua);
            thisObjKhachHang.Add(strConnection);
            data.DataSource = thisObjKhachHang.Get(strConnection);
            return 1;
        }

        //Thêm nhân viên
        public int addNhanVien(Guna2DataGridView data, string MaNV, string TenNV, string SDT, string DiaChi) {
            DAL.clsNhanVien_DAL.clsNhanVien_DAL thisObjNhanVien = new DAL.clsNhanVien_DAL.clsNhanVien_DAL(MaNV, TenNV, SDT, DiaChi);
            thisObjNhanVien.Add(strConnection);
            data.DataSource = thisObjNhanVien.Get(strConnection);
            return 1;
        }

        //Thêm hàng hóa
        public int updateHangHoa(Guna2DataGridView data, string MaHang, string TenHang, string LoaiHang, string NhaCC, int Gia, int SoLuong) {
            DAL.clsHangHoa_DAL.clsHangHoa_DAL thisObjHangHoa = new DAL.clsHangHoa_DAL.clsHangHoa_DAL(MaHang, TenHang, LoaiHang, NhaCC, Gia, SoLuong);
            thisObjHangHoa.Update(strConnection);
            data.DataSource = thisObjHangHoa.Get(strConnection);
            return 1;
        }

        //Thêm Hóa Đơn
        public int updateHoaDon(Guna2DataGridView data, string MaHD, string MaHang, string MaNV, string MaKH, string NgayHD) {
            DAL.clsHoaDon_DAL.clsHoaDon_DAL thisObjHoaDon = new DAL.clsHoaDon_DAL.clsHoaDon_DAL(MaHD, MaHang, MaNV, MaKH, NgayHD);
            thisObjHoaDon.Update(strConnection);
            data.DataSource = thisObjHoaDon.Get(strConnection);
            return 1;
        }

        //Thêm khách hàng
        public int updateKhachHang(Guna2DataGridView data, string MaKH, string TenKH, string SDT, string DiaChi, int LuotMua) {
            DAL.clsKhachHang_DAL.clsKhachHang_DAL thisObjKhachHang = new DAL.clsKhachHang_DAL.clsKhachHang_DAL(MaKH, TenKH, SDT, DiaChi, LuotMua);
            thisObjKhachHang.Update(strConnection);
            data.DataSource = thisObjKhachHang.Get(strConnection);
            return 1;
        }

        //Thêm nhân viên
        public int updateNhanVien(Guna2DataGridView data, string MaNV, string TenNV, string SDT, string DiaChi) {
            DAL.clsNhanVien_DAL.clsNhanVien_DAL thisObjNhanVien = new DAL.clsNhanVien_DAL.clsNhanVien_DAL(MaNV, TenNV, SDT, DiaChi);
            thisObjNhanVien.Update(strConnection);
            data.DataSource = thisObjNhanVien.Get(strConnection);
            return 1;
        }

        //Xóa Hàng Hóa
        //Thêm hàng hóa
        public int deleteHangHoa(Guna2DataGridView data, string MaHang) {
            DAL.clsHangHoa_DAL.clsHangHoa_DAL thisObjHangHoa = new DAL.clsHangHoa_DAL.clsHangHoa_DAL();
            thisObjHangHoa.Remove(strConnection, MaHang);
            data.DataSource = thisObjHangHoa.Get(strConnection);
            return 1;
        }

        //Thêm Hóa Đơn
        public int deleteHoaDon(Guna2DataGridView data, string MaHD) {
            DAL.clsHoaDon_DAL.clsHoaDon_DAL thisObjHoaDon = new DAL.clsHoaDon_DAL.clsHoaDon_DAL();
            thisObjHoaDon.Remove(strConnection, MaHD);
            data.DataSource = thisObjHoaDon.Get(strConnection);
            return 1;
        }

        //Thêm khách hàng
        public int deleteKhachHang(Guna2DataGridView data, string MaKH) {
            DAL.clsKhachHang_DAL.clsKhachHang_DAL thisObjKhachHang = new DAL.clsKhachHang_DAL.clsKhachHang_DAL();
            thisObjKhachHang.Remove(strConnection, MaKH);
            data.DataSource = thisObjKhachHang.Get(strConnection);
            return 1;
        }

        //Thêm nhân viên
        public int deleteNhanVien(Guna2DataGridView data, string MaNV) {
            DAL.clsNhanVien_DAL.clsNhanVien_DAL thisObjNhanVien = new DAL.clsNhanVien_DAL.clsNhanVien_DAL();
            thisObjNhanVien.Remove(strConnection, MaNV);
            data.DataSource = thisObjNhanVien.Get(strConnection);
            return 1;
        }
    }
}
