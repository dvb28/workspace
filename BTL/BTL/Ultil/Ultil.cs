using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.Ultil
{
    public class Ultil
    {
        public static int ExecuteProcedure(string[] paras, object[] values, string strConnection, string sp_name)
        {
            int kt = -1;
            SqlConnection connection = new SqlConnection(strConnection);
            if (connection.State == ConnectionState.Closed) connection.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = connection;
            cm.CommandText = sp_name;
            cm.CommandType = CommandType.StoredProcedure;
            for(int i = 0; i < paras.Length; i++)
            {
                cm.Parameters.AddWithValue(paras[i], values[i]);
            }
            try
            {
                cm.ExecuteNonQuery();
                kt = 0;
            }
            catch (Exception e)
            {
                e.ToString();
            }
            cm.Dispose();
            connection.Dispose();
            return kt;
        }
    }
}
