using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace BTL.DAL.clsNhanVien_DAL
{
    public class clsNhanVien_DAL : DAL.Interface.INhanVien
    {
        //Implement Thuộc Tính Từ Interface
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public int DoanhSo { get; set; }

        //Các phương thức Implement từ Interface

        public int Add(string strSqlConnection)
        {
            throw new NotImplementedException();
            return Ultil.Ultil.ExecuteProcedure(
            new string[] { "@MaNV", "@TenNV", "@SDT", "@DiaChi", "@DoanhSo"},
            new object[] { MaNV, TenNV, SDT, DiaChi, DoanhSo},
            strSqlConnection, "usp_insertNhanVien");
        }

        public DataTable Get(string strSqlConnection)
        {
            throw new NotImplementedException();
            SqlConnection conn = new SqlConnection(strSqlConnection);
            conn.Open();
            string sql = "SELECT * FROM NhanVien";
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
            new string[] { "@MaNV", "@TenNV", "@SDT", "@DiaChi", "@DoanhSo" },
            new object[] { MaNV, TenNV, SDT, DiaChi, DoanhSo },
            strSqlConnection, "usp_deleteNhanVien");
        }
    }
}
