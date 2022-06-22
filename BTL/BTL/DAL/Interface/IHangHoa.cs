using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BTL.DAL.Interface
{
    interface IHangHoa
    {
        //Các thuộc tính
        string MaHang { get; set; }
        string MaLoai { get; set; }
        string MaNCC { get; set; }
        string TenHang { get; set; }
        int Gia { get; set; }
        int SoLuong { get; set; }
        //Các phương thức
        //Phương thức lấy dữ liệu
        DataTable Get(string strSqlConnection);
        //Phương thức Thêm
        int Add(string strSqlConnection);
        //Phương thức Xóa
        int Remove(string strSqlConnection, string MaHH);
        //Phuong thức Tìm Kiếm
        DataTable Search(string strSqlConnection, string searchContent);
        //Phương thức Cập nhật
        int Update(string strSqlConnection);
    }
}
