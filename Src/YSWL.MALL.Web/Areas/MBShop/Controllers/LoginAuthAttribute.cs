using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace YSWL.MALL.Web.Areas.MBShop.Filter
{
    /// <summary>
    /// 判断是否需要登录访问
    /// </summary>
    public class LoginAuthAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ////bool isOpenLogin = YSWL.MALL.BLL.SysManage.ConfigSystem.GetBoolValueByCache("MBShop_IsOpenLogin");//是否开启登陆认证
            //bool isOpenLogin = false;
            //if (isOpenLogin)
            //{
            //    string rawurl = filterContext.HttpContext.Request.RawUrl;
            //    filterContext.Result = new RedirectResult($"/a/l/?returnUrl={filterContext.HttpContext.Server.UrlEncode(rawurl)}");
            //}
            base.OnActionExecuting(filterContext);
        }
    }
}
