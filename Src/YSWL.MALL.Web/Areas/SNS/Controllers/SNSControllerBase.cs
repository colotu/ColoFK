
using System.Web.Mvc;
using YSWL.MALL.Model.SysManage;

namespace YSWL.MALL.Web.Areas.SNS.Controllers
{
    /// <summary>
    /// SNS网站前台基类
    /// </summary>
    [SNSError]
    public class SNSControllerBase : YSWL.MALL.Web.Controllers.ControllerBase
    {
        //TODO: 性能损耗警告,每次访问页面都加载了以下数据 BEN ADD 2013-03-12
        public int FallDataSize = 20;
        public int PostDataSize = 15;
        public int CommentDataSize = 5;
        public int FallInitDataSize = 5;

        private YSWL.MALL.BLL.SNS.TaoBaoConfig _taoBaoConfig = null;
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            //FallDataSize = Common.Globals.SafeInt(YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("SNS_FallDataSize", ApplicationKeyType.SNS), 20);
            //PostDataSize = Common.Globals.SafeInt(YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("SNS_PostDataSize", ApplicationKeyType.SNS), 15);
            //CommentDataSize = Common.Globals.SafeInt(YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("SNS_CommentDataSize", ApplicationKeyType.SNS), 5);
            //FallInitDataSize = Common.Globals.SafeInt(YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("SNS_FallInitDataSize", ApplicationKeyType.SNS), 5);
            _taoBaoConfig =new YSWL.MALL.BLL.SNS.TaoBaoConfig(ApplicationKeyType.OpenAPI);
        }
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (MvcApplication.IsInstall && !filterContext.IsChildAction)
            {
                ViewBag.TaoBaoAppkey = _taoBaoConfig.TaoBaoAppkey;
            }
            base.OnResultExecuting(filterContext);
        }
    }
}
