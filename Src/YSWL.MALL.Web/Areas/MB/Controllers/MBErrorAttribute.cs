using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YSWL.MALL.Web.Areas.MB.Controllers
{
    public class MBErrorAttribute : FilterAttribute, IExceptionFilter
    {
        #region IExceptionFilter 成员

        public void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = new RedirectResult(MvcApplication.GetCurrentRoutePath(filterContext.Controller) + "Error");
        }

        #endregion

    }
}
