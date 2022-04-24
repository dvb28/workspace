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
        //Hàm khởi tạo không tham số
        public clsNhanVien_DAL() { }
        //Hàm khởi tạo không tham số
        public clsNhanVien_DAL(string _maNV, string _tenNV, string _SDT, string _diaChi) {
            this.MaNV = _maNV;
            this.TenNV = _tenNV;
            this.SDT = _SDT;
            this.DiaChi = _diaChi;
        }

        //Hàm khởi tạo có tham số
        //Các phương thức Implement từ Interface

        public int Add(string strSqlConnection)
        {
            return Ultil.Ultil.ExecuteProcedure(
            new string[] { "@MaNV", "@TenNV", "@SDT", "@DiaChi"},
            new object[] { MaNV, TenNV, SDT, DiaChi},
            strSqlConnection, "sp_insertNhanVien");
        }

        public DataTable Get(string strSqlConnection)
        {
            SqlConnection conn = new SqlConnection(strSqlConnection);
            conn.Open();
            string sql = "sp_showNhanVien";
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
            return Ultil.Ultil.ExecuteProcedure(
            new string[] { "@MaNV", "@TenNV", "@SDT", "@DiaChi", "@DoanhSo" },
            new object[] { MaNV, TenNV, SDT, DiaChi},
            strSqlConnection, "sp_deleteNhanVien");
        }

        //Phương thức tìm kiếm sử dụng Procedure
        public DataTable Search(string strSqlConnection, string searchContent) {
            SqlConnection conn = new SqlConnection(strSqlConnection);
            conn.Open();
            string sql = "EXEC sp_selectNhanVien'" + searchContent + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            da.Dispose();
            conn.Close();
            conn.Dispose();
            if (table == null)
            {
                table = null;
            }
            return table;
        }

    }
}
