using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BTL.DAL.Interface;

namespace BTL.DAL.clsClass
{
    public class clsConnect : IConnect
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public string Server { get; set; }
        //Tạo đối tượng kết nối
        public static SqlConnection connect;
        SqlDataAdapter da;
        public clsConnect() { }
        //Tạo phương thức kết nối
        public clsConnect(string _UserID, string _Password, string _Database, string _Server)
        {
            UserID = _UserID;
            Password = _Password;
            Database = _Database;
            Server = _Server;
        }
        public void Connect()
        {
            connect = new SqlConnection();
            connect.ConnectionString = getConnectionString();
            try
            {
                connect.Open();
            }catch(Exception ex) { ex.ToString(); }
        }


        //Tạo chuỗi kết nối
        public string getConnectionString()
        {
            return $@"Data Source = {Server}; Initial Catalog = {Database}; User ID = {UserID}; Password = {Password}";
        }
        //Hàm lấy dữ liệu từ Database xuống và lưu vào Table
        public DataTable GetDataToTable(string sql, SqlConnection thisConnection)
        {
            thisConnection.Open();
            DataTable table = new DataTable();
            da = new SqlDataAdapter(sql, thisConnection);
            da.Fill(table);
            da.Dispose();
            thisConnection.Close();
            return table;
        }
    }
}
