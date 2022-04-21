using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Bunifu.UI.WinForms;
using BTL.DAL;
namespace BTL.BUS
{
    internal class clsBridge_BUS
    {
        static DAL.Connection.clsConnect connection = new DAL.Connection.clsConnect(@"ACER-NITRO-5\SQLEXPRESS", "BTL_QLBH", "sa", "123456@Ab");
        // string strConnection = $@"Data Source=ACER-NITRO-5\SQLEXPRESS;Initial Catalog=BTL_QLBH;User ID =sa;Password=123456@Ab";
        public string strConnection = connection.getConectionString();
        //Đẩy dữ liệu của bảng HangHoa lên DataGridView
        public void showHangHoa(BunifuDataGridView data)
        {
            DAL.clsHangHoa_DAL.clsHangHoa_DAL objHangHoa = new DAL.clsHangHoa_DAL.clsHangHoa_DAL();
            data.DataSource = objHangHoa.Get(strConnection);
        }
        //Đẩy dữ liệu của bảng NhanVien lên DataGridView
        public void showNhanVien(BunifuDataGridView data)
        {
            DAL.clsNhanVien_DAL.clsNhanVien_DAL objNhanVien = new DAL.clsNhanVien_DAL.clsNhanVien_DAL();
            data.DataSource = objNhanVien.Get(strConnection);
        }
        //Đẩy dữ liệu của bảng NhanVien lên DataGridView
        public void showKhachHang(BunifuDataGridView data)
        {
            DAL.clsKhachHang_DAL.clsKhachHang_DAL objKhachHang = new DAL.clsKhachHang_DAL.clsKhachHang_DAL();
            data.DataSource = objKhachHang.Get(strConnection);
        }
        //Đẩy dữ liệu của bảng NhanVien lên DataGridView
        public void showHoaDon(BunifuDataGridView data)
        {
            DAL.clsHoaDon_DAL.clsHoaDon_DAL objHoaDon = new DAL.clsHoaDon_DAL.clsHoaDon_DAL();
            data.DataSource = objHoaDon.Get(strConnection);
        }
    }
}
