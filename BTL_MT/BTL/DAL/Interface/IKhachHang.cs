using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace BTL.DAL.Interface
{
    internal interface IKhachHang
    {
        //Các thuộc tính
        string MaKH { get; set; }
        string TenKH { get; set; }
        string SDT { get; set; }
        string DiaChi { get; set; }
        int LuotMua { get; set; }
        //Các phương thức
        //Phương thức Thêm
        DataTable Get(string strSqlConnection);
        //Phương thức Thêm
        int Add(string strSqlConnection);
        //Phương thức Xóa
        int Remove(string strSqlConnection, string MaKH);
        //Phuong thức Tìm Kiếm
        DataTable Search(string strSqlConnection, string searchContent);
        //Phương thức Cập nhật
        int Update(string strSqlConnection);
    }
}
