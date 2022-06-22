using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BTL.DAL.Connection;

namespace BTL.DAL.Connection
{
    public class clsConnect
    {
        public string Database { get; set; }
        public string Server { get; set; }
        //Tạo đối tượng kết nối
        public clsConnect() { }
        //Tạo phương thức kết nối
        public clsConnect(string _Server, string _Database)
        {
            Database = _Database;
            Server = _Server;
        }
        public SqlConnection connect = new SqlConnection();
        public void Connect()
        {
            connect.ConnectionString = getConectionString();
            try
            {
                connect.Open();
            }catch(Exception ex) { ex.ToString(); }
        }

        public void Disconnect()
        {
            connect.Close();
            connect.Dispose();
        }
        //Tạo chuỗi kết nối{
        public string getConectionString()
        {
            string strConnection;
            strConnection = "";
            strConnection += "Data Source =" + Server + ";";
            strConnection += "Initial Catalog =" + Database + ";";
            strConnection += "Integrated Security = true";
            return strConnection;
        }
    }
}
