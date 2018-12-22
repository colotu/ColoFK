using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YSWL.MALL.Web.Areas.SNS.Controllers
{
    /// <summary>
    ///  SNS用户中心基类（需要权限验证和用户登录才能访问）
    /// </summary>
    [SNSError]
    public class SNSUserControllerBase : YSWL.MALL.Web.Controllers.ControllerBaseUser
    {
        /// <summary>
        /// 重写父类的登录跳转, 指向SNS登录
        /// </summary>
        public override ActionResult RedirectToLogin(ActionExecutingContext filterContext)
        {
            return Redirect(ViewBag.BasePath + "Account/Login");
            //if (MvcApplication.MainAreaRoute == AreaRoute.SNS)
            //{
            //    //SNS 主域
            //    return Redirect(ViewBag.BasePath + "Account/Login");
            //}
            //return Redirect("/SNS/Account/Login");
        }

      

    }
}
