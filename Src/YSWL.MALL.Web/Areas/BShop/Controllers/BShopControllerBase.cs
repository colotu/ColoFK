﻿
using System.Web.Mvc;
using YSWL.MALL.Model.SysManage;

namespace YSWL.MALL.Web.Areas.BShop.Controllers
{
    /// <summary>
    /// Shop网站前台基类
    /// </summary>
    [BShopError]
    public class BShopControllerBase : YSWL.MALL.Web.Controllers.ControllerBase
    {
        //TODO: 性能损耗警告,每次访问页面都加载了以下数据 BEN ADD 2013-03-12
        public int FallDataSize = 20;
        public int PostDataSize = 15;
        public int CommentDataSize = 5;
        public int FallInitDataSize = 5;

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            //FallDataSize = Common.Globals.SafeInt(YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("SNS_FallDataSize", ApplicationKeyType.SNS), 20);
            //PostDataSize = Common.Globals.SafeInt(YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("SNS_PostDataSize", ApplicationKeyType.SNS), 15);
            //CommentDataSize = Common.Globals.SafeInt(YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("SNS_CommentDataSize", ApplicationKeyType.SNS), 5);
            //FallInitDataSize = Common.Globals.SafeInt(YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("SNS_FallInitDataSize", ApplicationKeyType.SNS), 5);
        }
        #region 覆盖父类的  ViewResult View 方法 用于ViewName动态判空
        protected new ViewResult View(string viewName, object model)
        {
            return !string.IsNullOrWhiteSpace(viewName) ? base.View(viewName, model) : View(model);
        }

        protected new ViewResult View(string viewName)
        {
            return !string.IsNullOrWhiteSpace(viewName) ? base.View(viewName) : View();
        }
        #endregion
    }
}
