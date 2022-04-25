﻿using System;
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
        static DAL.Connection.clsConnect connection = new DAL.Connection.clsConnect(@"ACER-NITRO-5\SQLEXPRESS", "BTL_QLBH", "sa", "123456@Ab");
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
        public void loadTopNhanVien(Guna2DataGridView chartTopNhanVien) {
            objDoanhThu.TopNhanVien(strConnection, chartTopNhanVien);
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
        public void showHangHoa(BunifuDataGridView data)
        {
            data.DataSource = objHangHoa.Get(strConnection);
        }
        //Đẩy dữ liệu của bảng NhanVien lên DataGridView
        public void showNhanVien(BunifuDataGridView data)
        {
            data.DataSource = objNhanVien.Get(strConnection);
        }
        //Đẩy dữ liệu của bảng NhanVien lên DataGridView
        public void showKhachHang(BunifuDataGridView data)
        {
            data.DataSource = objKhachHang.Get(strConnection);
        }
        //Đẩy dữ liệu của bảng NhanVien lên DataGridView
        public void showHoaDon(BunifuDataGridView data)
        {
            data.DataSource = objHoaDon.Get(strConnection);
        }
        //Chức năng tìm kiếm
        //Tìm kiếm hàng hóa
        public int searchHangHoa(BunifuDataGridView data, string searchContent) {
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
        public int searchNhanVien(BunifuDataGridView data, string searchContent) {
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
        public int searchHoaDon(BunifuDataGridView data, string searchContent) {
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
        public int searchKhachHang(BunifuDataGridView data, string searchContent) {
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
        public int addHangHoa(BunifuDataGridView data, string MaHang, string TenHang, string LoaiHang, string NhaCC, int Gia, int SoLuong) {
            DAL.clsHangHoa_DAL.clsHangHoa_DAL thisObjHangHoa = new DAL.clsHangHoa_DAL.clsHangHoa_DAL(MaHang, TenHang, LoaiHang, NhaCC, Gia, SoLuong);
            thisObjHangHoa.Add(strConnection);
            data.DataSource = thisObjHangHoa.Get(strConnection);
            return 1;
        }

        //Thêm Hóa Đơn
        public int addHoaDon(BunifuDataGridView data, string MaHD, string MaHang, string MaNV, string MaKH, string NgayHD) {
            DAL.clsHoaDon_DAL.clsHoaDon_DAL thisObjHoaDon = new DAL.clsHoaDon_DAL.clsHoaDon_DAL(MaHD, MaHang, MaNV, MaKH, NgayHD);
            thisObjHoaDon.Add(strConnection);
            data.DataSource = thisObjHoaDon.Get(strConnection);
            return 1;
        }

        //Thêm khách hàng
        public int addKhachHang(BunifuDataGridView data, string MaKH, string TenKH, string SDT, string DiaChi, int LuotMua, string GhiChu) {
            DAL.clsKhachHang_DAL.clsKhachHang_DAL thisObjKhachHang = new DAL.clsKhachHang_DAL.clsKhachHang_DAL(MaKH, TenKH, SDT, DiaChi, LuotMua, GhiChu);
            thisObjKhachHang.Add(strConnection);
            data.DataSource = thisObjKhachHang.Get(strConnection);
            return 1;
        }

        //Thêm nhân viên
        public int addNhanVien(BunifuDataGridView data, string MaNV, string TenNV, string SDT, string DiaChi) {
            DAL.clsNhanVien_DAL.clsNhanVien_DAL thisObjNhanVien = new DAL.clsNhanVien_DAL.clsNhanVien_DAL(MaNV, TenNV, SDT, DiaChi);
            thisObjNhanVien.Add(strConnection);
            data.DataSource = thisObjNhanVien.Get(strConnection);
            return 1;
        }

        //Thêm hàng hóa
        public int updateHangHoa(BunifuDataGridView data, string MaHang, string TenHang, string LoaiHang, string NhaCC, int Gia, int SoLuong) {
            DAL.clsHangHoa_DAL.clsHangHoa_DAL thisObjHangHoa = new DAL.clsHangHoa_DAL.clsHangHoa_DAL(MaHang, TenHang, LoaiHang, NhaCC, Gia, SoLuong);
            thisObjHangHoa.Update(strConnection);
            data.DataSource = thisObjHangHoa.Get(strConnection);
            return 1;
        }

        //Thêm Hóa Đơn
        public int updateHoaDon(BunifuDataGridView data, string MaHD, string MaHang, string MaNV, string MaKH, string NgayHD) {
            DAL.clsHoaDon_DAL.clsHoaDon_DAL thisObjHoaDon = new DAL.clsHoaDon_DAL.clsHoaDon_DAL(MaHD, MaHang, MaNV, MaKH, NgayHD);
            thisObjHoaDon.Update(strConnection);
            data.DataSource = thisObjHoaDon.Get(strConnection);
            return 1;
        }

        //Thêm khách hàng
        public int updateKhachHang(BunifuDataGridView data, string MaKH, string TenKH, string SDT, string DiaChi, int LuotMua, string GhiChu) {
            DAL.clsKhachHang_DAL.clsKhachHang_DAL thisObjKhachHang = new DAL.clsKhachHang_DAL.clsKhachHang_DAL(MaKH, TenKH, SDT, DiaChi, LuotMua, GhiChu);
            thisObjKhachHang.Update(strConnection);
            data.DataSource = thisObjKhachHang.Get(strConnection);
            return 1;
        }

        //Thêm nhân viên
        public int updateNhanVien(BunifuDataGridView data, string MaNV, string TenNV, string SDT, string DiaChi) {
            DAL.clsNhanVien_DAL.clsNhanVien_DAL thisObjNhanVien = new DAL.clsNhanVien_DAL.clsNhanVien_DAL(MaNV, TenNV, SDT, DiaChi);
            thisObjNhanVien.Update(strConnection);
            data.DataSource = thisObjNhanVien.Get(strConnection);
            return 1;
        }

        //Xóa Hàng Hóa
        //Thêm hàng hóa
        public int deleteHangHoa(BunifuDataGridView data, string MaHang) {
   
            objHangHoa.Remove(strConnection, MaHang);
            data.DataSource = objHangHoa.Get(strConnection);
            return 1;
        }

        //Thêm Hóa Đơn
        public int deleteHoaDon(BunifuDataGridView data, string MaHD) {
            objHoaDon.Remove(strConnection, MaHD);
            data.DataSource = objHoaDon.Get(strConnection);
            return 1;
        }

        //Thêm khách hàng
        public int deleteKhachHang(BunifuDataGridView data, string MaKH) {
            objKhachHang.Remove(strConnection, MaKH);
            data.DataSource = objKhachHang.Get(strConnection);
            return 1;
        }

        //Thêm nhân viên
        public int deleteNhanVien(BunifuDataGridView data, string MaNV) {
            objNhanVien.Remove(strConnection, MaNV);
            data.DataSource = objNhanVien.Get(strConnection);
            return 1;
        }
    }
}
