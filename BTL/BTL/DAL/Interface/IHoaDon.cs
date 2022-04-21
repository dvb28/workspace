﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace BTL.DAL.Interface
{
    internal interface IHoaDon
    {
        //Các thuộc tính
        string MaHD { get; set; }
        string MaHang { get; set; }
        string MaNV { get; set; }
        string MaKH { get; set; }
        string NgayHD { get; set; }
        float ThanhTien { get; set; }
        //Phương thức Get
        DataTable Get(string strSqlConnection);
        //Phương thức Thêm
        int Add(string strSqlConnection);
        //Phương thức Xóa
        int Remove(string strSqlConnection);
    }
}