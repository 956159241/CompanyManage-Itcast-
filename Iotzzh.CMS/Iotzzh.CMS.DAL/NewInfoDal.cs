using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iotzzh.CMS.Model;
using System.Data.SqlClient;
using System.Data;

namespace Iotzzh.CMS.DAL
{
    public class NewInfoDal
    {
        //定义一个集合,一个获取分页的方法，由BLL（业务逻辑）层传入start和end
        public List<NewInfo> GetPageList(int start, int end)
        {
            string sql = "select * from (select row_number() over (order by id) as" + 
                " num,* from News ) as t where t.num >=@start and t.num <= @end";
            SqlParameter[] pars = {
                                    new SqlParameter("@start",SqlDbType.Int),
                                    new SqlParameter("@end",SqlDbType.Int)
                                 };
            pars[0].Value = start;
            pars[1].Value = end;
            //进行查询
            DataTable da = SqlHelper.GetTable(sql,CommandType.Text,pars);
            //声明集合
            List<NewInfo> list = null;
            if (da.Rows.Count > 0)
            { 
                //把datatable里的数据放到list里返回就可以了
                list = new List<NewInfo>();
                NewInfo newInfo = null;
                //遍历所有的行
                foreach (DataRow row in da.Rows)
                {
                    newInfo = new NewInfo();
                    //加载一下
                    LoadEntity(row,newInfo);
                    //把newInfo放到list集合里面
                    list.Add(newInfo);


                }
            }
            return list;
        }
        public void LoadEntity(DataRow row, NewInfo newInfo)
        {
            newInfo.Id = Convert.ToInt32(row["Id"]);
            newInfo.Author = row["Author"] != DBNull.Value ? 
                    row["Author"].ToString() : string.Empty;
            newInfo.Title = row["Title"] != DBNull.Value ?
                    row["Title"].ToString() : string.Empty;
            newInfo.Msg = row["Msg"] != DBNull.Value ?
                    row["Msg"].ToString() : string.Empty;
            newInfo.SubDateTime = Convert.ToDateTime(row["SubDateTime"]);
            newInfo.ImagePath = row["ImagePath"] != DBNull.Value ?
                    row["ImagePath"].ToString() : string.Empty;
        }
        /// <summary>
        /// 获取总的记录数
        /// </summary>
        /// <returns></returns>
        public int GetRecordCount()
        {
            string sql = "select count(*) from News";
            return Convert.ToInt32(SqlHelper.ExecuteScalare(sql,CommandType.Text));
        }
        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NewInfo GetModel(int id)
        {
            string sql = "select * from News where id = @id";
            SqlParameter[] pars = { 
                                    new SqlParameter("@id",SqlDbType.Int)
                                  };
            pars[0].Value = id;
            DataTable da = SqlHelper.GetTable(sql,CommandType.Text,pars);
            NewInfo newInfo = null;
            if (da.Rows.Count > 0)
            {
                newInfo = new NewInfo();
                LoadEntity(da.Rows[0], newInfo);
            }
            return newInfo;
        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteInfo(int id)
        {
            string sql = "delete from News where id = @id";
            return SqlHelper.ExecuteNonquery(sql,CommandType.Text,new SqlParameter("@id",id));
        }
    }
}
