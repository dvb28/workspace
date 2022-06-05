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
        public string MaMay { get; set; }
        public string MaLoai { get; set; }
        public string MaNCC { get; set; }
        public string TenMay { get; set; } 
        public int Gia { get; set; }
        public int SoLuong { get; set; }
        //Hàm khởi tạo không tham số
        public clsHangHoa_DAL() { }
        //Hàm khởi tạo có tham số
        public clsHangHoa_DAL(string _maMay, string _tenMay, string _loai, string _nhaCC, int _gia, int _soLuong) {
            MaMay = _maMay;
            TenMay = _tenMay;
            MaLoai = _loai;
            MaNCC = _nhaCC;
            Gia = _gia;
            SoLuong = _soLuong;
        }
        //Các phương thức
        //Phương thức Thêm sử dụng Procedure
        public int Add(string strSqlConnection)
        {
            return Ultil.Ultil.ExecuteProcedure(
            new string[] { "@MaMay", "@MaLoai", "@MaNCC", "@TenMay", "@Gia", "@SoLuong" },
            new object[] { MaMay, MaLoai, MaNCC, TenMay, Gia, SoLuong },
            strSqlConnection, "sp_insertMayTinh");
        }
        //Phương thức Lấy dữ liệu sử dụng Procedure
        public DataTable Get(string strSqlConnection) {
            SqlConnection conn = new SqlConnection(strSqlConnection);
            conn.Open();
            string sql = "sp_showMayTinh";
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

        public int Remove(string strSqlConnection, string MaHH)
        {
            return Ultil.Ultil.ExecuteProcedure(
            new string[] { "@MaMay"},
            new object[] { MaHH },
            strSqlConnection, "sp_deleteMayTinh");
        }

        //Phương thức tìm kiếm sử dụng
        public DataTable Search(string strSqlConnection, string searchContent) {
            SqlConnection conn = new SqlConnection(strSqlConnection);
            conn.Open();
            string sql = "EXEC sp_selectHangHoa'" + searchContent + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            da.Dispose();
            conn.Close();
            conn.Dispose();
            if(table == null)
            {
                table = null;
            }
            return table;
        }
        //Phương thức Cập nhật dữ liệu
        public int Update(string strSqlConnection) {
            return Ultil.Ultil.ExecuteProcedure(
            new string[] { "@MaMay", "@MaLoai", "@MaNCC", "@TenMay", "@Gia", "@SoLuong" },
            new object[] { MaMay, MaLoai, MaNCC, TenMay, Gia, SoLuong },
            strSqlConnection, "sp_updateMayTinh");
        }
    }
}
