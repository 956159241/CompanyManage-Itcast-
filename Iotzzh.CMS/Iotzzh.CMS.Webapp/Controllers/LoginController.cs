using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Iotzzh.CMS.BLL;
using Iotzzh.CMS.Model;

namespace Iotzzh.CMS.Webapp.Controllers
{
    public class LoginController : Controller
    {
        //约定大于配置
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }
        //通过Ajax获取前台传入的数据
        public ActionResult UserLogin()
        { 
            //首先判断已给的验证处是否为空
            string validateCode = Session["code"] == null? string.Empty:
                Session["code"].ToString();
            //如果已给的验证码为空，提示！
            if (string.IsNullOrEmpty(validateCode))
            {
                return Content("no:验证码错误");
            }
            //此时的session已经赋值给了validateCode，所以可以清空了
            Session["code"] = null;
            //获取用户输入的验证码
            string txtCode = Request["vCode"];
            //判断，如果系统的验证码与用户输入的验证码不一致，则提示
            if (!validateCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
            {
                return Content("no:验证码错误");
            }
            string userName = Request["LoginCode"];
            string userPwd = Request ["LoginPwd"];
            UserInfoService userInfoService = new UserInfoService();
            UserInfo userInfo = userInfoService.GetUserInfo(userName,userPwd);
            if (userInfo != null)
            {
                Session["userInfo"] = userInfo;
                return Content("ok:登录成功!");
            }
            else 
            {
                return Content("no:登录失败！");
            }


        }
        //调用分装验证码的类
        public ActionResult ShowValidateCode()
        {
            Itcast.CMS.Common.ValidateCode validateCode = new Itcast.CMS.Common.ValidateCode();
            string code = validateCode.CreateValidateCode(4);//获取验证码.
            Session["code"] = code;//存入与用户输入进行校验
            byte[] buffer = validateCode.CreateValidateGraphic(code);
            return File(buffer, "image/jpeg");
        }
    }
}
