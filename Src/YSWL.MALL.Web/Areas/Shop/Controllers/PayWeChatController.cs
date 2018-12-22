using System.Web.Mvc;
using YSWL.Components.Setting;
using YSWL.MALL.Web.Components.Setting.Shop;

namespace YSWL.MALL.Web.Areas.Shop.Controllers
{
    public class PayWeChatController : ShopControllerBase
    {
        BLL.Shop.Order.Orders orderManage = new BLL.Shop.Order.Orders();
        BLL.Shop.Order.OrderItems orderItemManage = new BLL.Shop.Order.OrderItems();

        #region Pay
        public ActionResult Pay(long id, string viewName = "Pay")
        {
            if (id < 1) return Redirect("/");
            
            Model.Shop.Order.OrderInfo orderInfo = orderManage.GetModel(id);

            if (orderInfo == null || orderInfo.BuyerID != currentUser.UserID || orderInfo.PaymentStatus != 0)
                return Redirect("/"); 

            ViewBag.OrderId = orderInfo.OrderId;
            //订单编号
            ViewBag.OrderCode = orderInfo.OrderCode;
            //收货人
            ViewBag.ShipName = orderInfo.ShipName;
            //项目数量
            //ViewBag.ItemsCount =orderItemManage.GetOrderItemCountByOrderId(orderId);
            //应付金额
            ViewBag.OrderAmount =  orderInfo.Amount;

            #region SEO 优化设置
            IPageSetting pageSetting = PageSetting.GetPageSetting("Home", Model.SysManage.ApplicationKeyType.Shop);
            ViewBag.Title = "微信支付";
            ViewBag.Keywords = pageSetting.Keywords;
            ViewBag.Description = pageSetting.Description;
            #endregion
            return View(viewName);
        }
        #endregion

        public ActionResult CheckPayment(long id)
        {
            YSWL.Payment.Model.IOrderInfo info = orderManage.GetModel(id);
            if (info == null) return Content("NULL");

            if (info.PaymentStatus == Payment.Model.PaymentStatus.Prepaid) return Content("PREPAID");

            return Content("NOTYET");
        }
    }
}

