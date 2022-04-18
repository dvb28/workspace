using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BTL.BUS
{
    internal class getTaiKhoan
    {
        DAL.clsClass.clsConnect connection = new DAL.clsClass.clsConnect("ACER-NITRO-5", "BTL_QLBH", "sa", "123456@Ab");
        //Tạo đối tượng kết nối
        SqlConnection conn = new SqlConnection();
        //Lấy ra dữ liệu tài khoản và mật khẩu người dùng
        public DataTable getUserInfo()
        {
            conn.ConnectionString = $@"Data Source = {"ACER-NITRO-5"}\SQLEXPRESS; Initial Catalog = {"BTL_QLBH"}; User ID = {"sa"}; Password = {"123456@Ab"}";
            DataTable dataTable = connection.GetDataToTable("SELECT * FROM TaiKhoan", conn);
            return dataTable;
        }
    }
}
