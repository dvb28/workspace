using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace BTL.DAL.Interface
{
    internal interface INhanVien
    {
        //Các thuộc tính
        string MaNV { get; set; }
        string TenNV { get; set; }
        string SDT { get; set; }
        string DiaChi { get; set; }
        //Các phương thức
        //Phương thức Get
        DataTable Get(string strSqlConnection);
        //Phương thức Thêm
        int Add(string strSqlConnection);
        //Phương thức Xóa
        int Remove(string strSqlConnection);
        //Phuong thức Tìm Kiếm
        DataTable Search(string strSqlConnection, string searchContent);
    }
}
