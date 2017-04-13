using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iotzzh.CMS.Model
{
    //为UserInfo表创建一个实体类
    public class UserInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string UserMail { get; set; }
        public DateTime RegTime { get; set; }
    }
}
