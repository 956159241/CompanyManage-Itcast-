using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iotzzh.CMS.Model;

namespace Iotzzh.CMS.BLL
{
    
    public class NewInfoService
    {
        DAL.NewInfoDal NewInfoDal = new DAL.NewInfoDal();
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex">当前页码值</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <returns></returns>
        public List<NewInfo> GetPageList(int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            List<NewInfo> list = NewInfoDal.GetPageList(start,end);
            return list;
        }
        /// <summary>
        /// 获取总的页数
        /// </summary>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public int GetPageCount(int pageSize)
        {
            int recordCount = NewInfoDal.GetRecordCount();
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount/pageSize));
            return pageCount;
        }
        /// <summary>
        /// 通过web层传来的id，通过使用dal层的方法，返回结果
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NewInfo GetModel(int id)
        {
            return NewInfoDal.GetModel(id);
        }

        public bool DeleteInfo(int id)
        {
            return NewInfoDal.DeleteInfo(id) > 0;      
        }

      }
}
