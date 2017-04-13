using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iotzzh.CMS.Model;
using System.Data.SqlClient;
using System.Data;

namespace Iotzzh.CMS.DAL
{
    public class UserInfoDal
    {
        public UserInfo GetUserInfo(string userName,string userPwd)
        {
            string sql = "select * from UserInfo where UserName = @UserName" + 
                " and UserPwd = @UserPwd";
            SqlParameter[] pars = {
                                    new SqlParameter("@UserName",SqlDbType.NVarChar,50),
                                    new SqlParameter("@UserPwd",SqlDbType.NVarChar,50)
                                 };
            pars[0].Value = userName;
            pars[1].Value = userPwd;
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, pars);
            UserInfo userInfo = null;
            if (da.Rows.Count > 0)
            {
                userInfo = new UserInfo();
                LoadEntity(userInfo,da.Rows[0]);
            }
            return userInfo;
        }
        public void LoadEntity(UserInfo userInfo, DataRow row)
        {
            userInfo.Id = Convert.ToInt32(row["Id"]);
            //判断是否为空，对于上面的Id也可以做此操作，由于设置了主键不会为空的
            //就没有必要执行这一步了
            userInfo.UserName = row["UserName"] != DBNull.Value?
                row["UserName"].ToString():string.Empty;
            userInfo.UserPwd = row["UserPwd"] != DBNull.Value ?
                row["UserPwd"].ToString() : string.Empty;
            userInfo.UserMail = row["UserMail"] != DBNull.Value ?
                row["UserMail"].ToString() : string.Empty;
            userInfo.RegTime = Convert.ToDateTime(row["RegTime"]);
        }
    }
}
