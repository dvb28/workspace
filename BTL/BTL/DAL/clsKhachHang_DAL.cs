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

        //Khởi tạo không tham số
        public clsKhachHang_DAL() { }
        //Khởi tạo có tham số
        public clsKhachHang_DAL(string _maKH, string _tenKH, string _SDT, string _diaChi, int _luotMua, string _ghiChu) {
            this.MaKH = _maKH;
            this.TenKH = _tenKH;
            this.SDT = _SDT;
            this.DiaChi = _diaChi;
            this.LuotMua = _luotMua;
            this.GhiChu = _ghiChu;
        }
        public int Add(string strSqlConnection)
        {
            return Ultil.Ultil.ExecuteProcedure(
            new string[] { "@MaKH", "@TenKH", "@SDT", "@DiaChi", "@LuotMua", "@GhiChu"},
            new object[] { MaKH, TenKH, SDT, DiaChi, LuotMua, GhiChu },
            strSqlConnection, "sp_insertKhachHang");
        }

        public DataTable Get(string strSqlConnection)
        {
            SqlConnection conn = new SqlConnection(strSqlConnection);
            conn.Open();
            string sql = "sp_showKhachHang";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            da.Dispose();
            conn.Close();
            conn.Dispose();
            return table;
        }

        public int Remove(string strSqlConnection, string MaKH)
        {
            return Ultil.Ultil.ExecuteProcedure(
            new string[] { "@MaKH"},
            new object[] { MaKH},
            strSqlConnection, "sp_deleteKhachHang");
        }

        //Phương thức tìm kiếm sử dụng Procedure
        public DataTable Search(string strSqlConnection, string searchContent) {
            SqlConnection conn = new SqlConnection(strSqlConnection);
            conn.Open();
            string sql = "EXEC sp_selectKhachHang'" + searchContent + "'";
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


        //Phương thức cập nhật dữ liệu
        public int Update(string strSqlConnection) {
            return Ultil.Ultil.ExecuteProcedure(
            new string[] { "@MaKH", "@TenKH", "@SDT", "@DiaChi", "@LuotMua", "@GhiChu" },
            new object[] { MaKH, TenKH, SDT, DiaChi, LuotMua, GhiChu },
            strSqlConnection, "sp_updateKhachHang");
        }
    }
}
