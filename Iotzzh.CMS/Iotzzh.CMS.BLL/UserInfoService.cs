using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iotzzh.CMS.Model;

namespace Iotzzh.CMS.BLL
{
    public class UserInfoService
    {
        DAL.UserInfoDal UserInfoDal = new DAL.UserInfoDal();
        public UserInfo GetUserInfo(string userName, string userPwd)
        {
            return UserInfoDal.GetUserInfo(userName,userPwd);
        }
    }
}
