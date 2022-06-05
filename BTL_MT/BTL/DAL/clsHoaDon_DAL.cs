using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace BTL.DAL.clsHoaDon_DAL
{
    public class clsHoaDon_DAL : DAL.Interface.IHoaDon
    {
        //Implement các thuộc tính  
        public string MaHD { get; set; }
        public string MaMay { get; set; }
        public string MaNV { get; set; }
        public string MaKH { get; set; }
        public string NgayHD { get; set; }

        //Hàm khởi tạo không tham số
        public clsHoaDon_DAL() { }
        //Hàm khởi tạo có tham số
        public clsHoaDon_DAL(string _maHD, string _maMay, string _maNV, string _maKH, string _ngayHD) {
            MaHD = _maHD;
            MaMay = _maMay;
            MaNV = _maNV;
            MaKH = _maKH;
            NgayHD = _ngayHD;
        }
        public int Add(string strSqlConnection)
        {
            return Ultil.Ultil.ExecuteProcedure(
            new string[] { "@MaHD", "@MaMay", "@MaNV", "@MaKH", "@NgayHD"},
            new object[] { MaHD, MaMay, MaNV, MaKH, NgayHD},
            strSqlConnection, "sp_insertHoaDon");
        }

        public DataTable Get(string strSqlConnection)
        {
            SqlConnection conn = new SqlConnection(strSqlConnection);
            conn.Open();
            string sql = "EXEC sp_showHoaDon";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            da.Dispose();
            conn.Close();
            conn.Dispose();
            return table;
        }

        //Phương thức xóa sử dụng Procedure
        public int Remove(string strSqlConnection, string MaHD)
        {
            return Ultil.Ultil.ExecuteProcedure(
            new string[] { "@MaHD"},
            new object[] { MaHD},
            strSqlConnection, "sp_deleteHoaDon");
        }

        //Phương thức tìm kiếm sử dụng Procedure
        public DataTable Search(string strSqlConnection, string searchContent) {
            SqlConnection conn = new SqlConnection(strSqlConnection);
            conn.Open();
            string sql = "EXEC sp_selectHoaDon'" + searchContent + "'";
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
            new string[] { "@MaHD", "@MaMay", "@MaNV", "@MaKH", "@NgayHD" },
            new object[] { MaHD, MaMay, MaNV, MaKH, NgayHD },
            strSqlConnection, "sp_updateHoaDon");
        }
    }
}
