using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BTL.DAL.clsHangHoa_DAL
{
    public class clsHangHoa_DAL : DAL.Interface.IHangHoa
    {
        //Implement Thuộc Tính Từ Interface
        public string MaHang { get; set; }
        public string MaLoai { get; set; }
        public string MaNCC { get; set; }
        public string TenHang { get; set; } 
        public int Gia { get; set; }
        public int SoLuong { get; set; }


        //Các phương thức
        //Phương thức Thêm sử dụng Procedure
        public int Add(string strSqlConnection)
        {
            return Ultil.Ultil.ExecuteProcedure(
            new string[] { "@MaHang", "@MaLoai", "@MaNCC", "@TenHang", "@Gia", "@SoLuong" },
            new object[] { MaHang, MaLoai, MaNCC, TenHang, Gia, SoLuong },
            strSqlConnection, "usp_insertHangHoa");
        }
        //Phương thức Lấy dữ liệu sử dụng Procedure

        public DataTable Get(string strSqlConnection) {
            SqlConnection conn = new SqlConnection(strSqlConnection);
            conn.Open();
            string sql = "SELECT * FROM HangHoa";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            da.Dispose();
            conn.Close();
            conn.Dispose();
            return table;
        }
        //Phương thức Xóa sử dụng Procedure

        public int Remove(string strSqlConnection)
        {
            return BTL.Ultil.Ultil.ExecuteProcedure(
            new string[] { "@MaHang", "@MaLoai", "@MaNCC", "@TenHang", "@Gia", "@SoLuong" },
            new object[] { MaHang, MaLoai, MaNCC, TenHang, Gia, SoLuong },
            strSqlConnection, "usp_deleteHangHoa");
        }


        //Phương thức tìm kiếm sử dụng Procedure
    }
}
