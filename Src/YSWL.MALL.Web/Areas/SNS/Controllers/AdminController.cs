using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YSWL.Components.Filters;

namespace YSWL.MALL.Web.Areas.SNS.Controllers
{
    [TokenAuthorize(AccountType.Admin)]
    public class AdminController : SNSControllerBase
    {

        //
        // GET: /SNS/Admin/
        public ActionResult Index()
        {
            return View();
        }

        #region 推荐到首页的操作
        public ActionResult AjaxRecommandOperation(FormCollection fm)
        {
            if (!UserPrincipal.HasPermissionID(GetPermidByActID(Act_ApproveList)))
            {
                return Content("No");
            }
            string type = fm["Type"];
            string TargetType = fm["TargetType"];
            int TargetId = Common.Globals.SafeInt(fm["TargetId"], 0);
            if (TargetId > 0 && !string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(TargetType))
            {
                if (TargetType == "product")
                {
                    YSWL.MALL.BLL.SNS.Products Productbll = new YSWL.MALL.BLL.SNS.Products();
                    if (Productbll.UpdateRecomend(TargetId, type == "recommand" ? (int)YSWL.MALL.Model.SNS.EnumHelper.RecommendType.Home : (int)YSWL.MALL.Model.SNS.EnumHelper.RecommendType.None))
                    {
                        return Content("Yes");
                    }
                }
                else
                {
                    YSWL.MALL.BLL.SNS.Photos Photobll = new YSWL.MALL.BLL.SNS.Photos();
                    if (Photobll.UpdateRecomend(TargetId, type == "recommand" ? (int)YSWL.MALL.Model.SNS.EnumHelper.RecommendType.Home : (int)YSWL.MALL.Model.SNS.EnumHelper.RecommendType.None))
                    {
                        return Content("Yes");
                    }
                }
            }
            return Content("No");
        } 
        #endregion

        #region 删除图片或者商品
        public ActionResult AjaxDeleteOperation(FormCollection fm)
        {
            if (!UserPrincipal.HasPermissionID(GetPermidByActID(Act_DeleteList)))
            {
                return Content("No");
            }
            string type = fm["Type"];
            string TargetType = fm["TargetType"];
            int TargetId = Common.Globals.SafeInt(fm["TargetId"], 0);
            if (TargetId > 0 &&!string.IsNullOrEmpty(TargetType))
            {
                if (TargetType == "product")
                {
                    YSWL.MALL.BLL.SNS.Products productBll = new YSWL.MALL.BLL.SNS.Products();
                    int result1;
                    productBll.DeleteListEx(TargetId.ToString(), out result1);
                    if (result1 == 1 )
                    {
                        return Content("Yes");
                    }
                }
                else
                {
                    YSWL.MALL.BLL.SNS.Photos photoBll = new YSWL.MALL.BLL.SNS.Photos();
                    int result2;
                    photoBll.DeleteListEx(TargetId.ToString(), out result2);
                    if (result2 == 1)
                    {
                        return Content("Yes");
                    }
                }
            }
            return Content("No");

        } 
        #endregion

    }
}
