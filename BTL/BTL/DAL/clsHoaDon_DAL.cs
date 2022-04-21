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
        public string MaHang { get; set; }
        public string MaNV { get; set; }
        public string MaKH { get; set; }
        public string NgayHD { get; set; }
        public float ThanhTien { get; set; }

        public int Add(string strSqlConnection)
        {
            throw new NotImplementedException();
            return Ultil.Ultil.ExecuteProcedure(
            new string[] { "@MaHD", "@MaNV", "@MaKH", "@NgayHD", "@ThanhTien"},
            new object[] { MaHD, MaNV, MaKH, NgayHD, ThanhTien},
            strSqlConnection, "usp_insertHoaDon");
        }

        public DataTable Get(string strSqlConnection)
        {
            throw new NotImplementedException();
            SqlConnection conn = new SqlConnection(strSqlConnection);
            conn.Open();
            string sql = "SELECT * FROM HoaDon";
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
            new string[] { "@MaHD", "@MaNV", "@MaKH", "@NgayHD", "@ThanhTien" },
            new object[] { MaHD, MaNV, MaKH, NgayHD, ThanhTien },
            strSqlConnection, "usp_deleteHoaDon");
        }
    }
}
