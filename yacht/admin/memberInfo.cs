using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yacht.admin
{
    public class memberInfo
    {
        public int id { get; set; } //主key
        public string account { get; set; }//帳號
        public string name { get; set; }//名字
        public string photo { get; set; } //照片
        public string email { get; set; } //信箱 email
        public string maxPower { get; set; }//權限
    }
}