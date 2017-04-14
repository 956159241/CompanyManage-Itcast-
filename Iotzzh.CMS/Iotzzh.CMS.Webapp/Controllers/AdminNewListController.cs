using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Iotzzh.CMS.Model;
using System.IO;

namespace Iotzzh.CMS.Webapp.Controllers
{
    public class AdminNewListController : Controller
    {
        BLL.NewInfoService NewInfoService = new BLL.NewInfoService();
        #region 分页列表
        public ActionResult Index()
        {
            int pageIndex = Request["pageIndex"] != null ? int.Parse(Request["pageIndex"]) : 1;
            int pageSize = 5;
            int pageCount = NewInfoService.GetPageCount(pageSize);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            List<NewInfo> list = NewInfoService.GetPageList(pageIndex, pageSize);//获取分页的数据
            ViewData["list"] = list;
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageCount"] = pageCount;
            return View();
        }

        #endregion
        #region 获取详细信息
        public ActionResult GetNewInfoModel()
        {
            int id = int.Parse(Request["id"]);
            NewInfo newInfo = NewInfoService.GetModel(id);
            //把数据序列化
            return Json(newInfo,JsonRequestBehavior.AllowGet);
        }

        #endregion
        #region 删除信息
        public ActionResult DeleteNewInfo()
        {
            int id = int.Parse(Request["id"]);
            if (NewInfoService.DeleteInfo(id))
            {
                return Content("ok");
            }
            else
            {
                return Content("Error");
            }
        }
        #endregion
        #region 展示添加信息的页面
        public ActionResult ShowAddInfo()
        {
            return View();
        }
        #endregion
        #region 文件上传
        public ActionResult FileUpload()
        {
            HttpPostedFileBase postFile = Request.Files["fileUp"];
            if (postFile == null)
            {
                return Content("no:请选择上传文件");
            }
            else
            {
                string fileName = Path.GetFileName(postFile.FileName);//文件名
                string fileExt = Path.GetExtension(fileName);//文件的扩展名
                if (fileExt == ".jpg")
                {
                    string dir = "/ImagePath" + DateTime.Now.Year + "/" +
                        DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
                    Directory.CreateDirectory(Path.GetDirectoryName(Request.MapPath(dir)));//创建文件夹
                    string newfileName = Guid.NewGuid().ToString();//新的文件名
                    string fullDir = dir + newfileName + fileExt;//完整的路径
                    postFile.SaveAs(Request.MapPath(fullDir));//保存文件
                    return Content("ok:" + fullDir);
                }
                else
                {
                    return Content("no:文件格式错误");
                }
            }
        }
        #endregion
    }
}
