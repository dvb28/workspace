using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace BTL.DAL.Interface
{
    interface IConnect
    {
        string UserID { get; set; }
        string Password { get; set; }
        string Database { get; set; }
        string Server { get; set; }
        //Kết nối
    }
}
