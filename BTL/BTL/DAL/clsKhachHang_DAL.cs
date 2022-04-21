using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace BTL.DAL.clsKhachHang_DAL
{
    public class clsKhachHang_DAL : DAL.Interface.IKhachHang
    {
        //Implement các thuộc tính từ Interface
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public int LuotMua { get; set; }
        public string GhiChu { get; set; }

        public int Add(string strSqlConnection)
        {
            throw new NotImplementedException();
            return Ultil.Ultil.ExecuteProcedure(
            new string[] { "@MaKH", "@TenKH", "@SDT", "@DiaChi", "@LuotMua", "@GhiChu"},
            new object[] { MaKH, TenKH, SDT, DiaChi, LuotMua, GhiChu },
            strSqlConnection, "usp_insertKhachHang");
        }

        public DataTable Get(string strSqlConnection)
        {
            throw new NotImplementedException();
            SqlConnection conn = new SqlConnection(strSqlConnection);
            conn.Open();
            string sql = "SELECT * FROM KhachHang";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            da.Dispose();
            conn.Close();
            conn.Dispose();
            return table;
        }

        public int Remove(string strSqlConnection)
        {
            throw new NotImplementedException();
            return Ultil.Ultil.ExecuteProcedure(
            new string[] { "@MaKH", "@TenKH", "@SDT", "@DiaChi", "@LuotMua", "@GhiChu" },
            new object[] { MaKH, TenKH, SDT, DiaChi, LuotMua, GhiChu },
            strSqlConnection, "usp_deletetKhachHang");
        }
    }
}
