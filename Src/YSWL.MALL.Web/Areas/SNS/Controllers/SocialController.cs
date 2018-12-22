using System.Web.Mvc;
using YSWL.MALL.Web.Controllers;

namespace YSWL.MALL.Web.Areas.SNS.Controllers
{
    public class SocialController : SocialControllerBase
    {
        public override ActionResult RedirectToUserBind( )
        {
            return RedirectToAction("UserBind", "UserCenter", new { area = "SNS" });
        }
        public override ActionResult RedirectToHome( )
        {
            return RedirectToAction("Posts", "Profile", new {area = "SNS"});
        }
    }
}
