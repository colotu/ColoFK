using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using YSWL.Accounts.Bus;
using YSWL.Common;
using YSWL.MALL.ViewModel.Shop;

namespace YSWL.MALL.Web.Areas.MBShop.Controllers
{
    public class APPController: Controller
    {
        #region 登录
        public ActionResult Login()
        {
            //处理访问来源
            string agent = Request.Headers["User-Agent"];
            string isYS56 = Request.Params["tag"];
            if (!String.IsNullOrWhiteSpace(isYS56) && isYS56 == "ys56")
            {
                return View();
            }

            if (String.IsNullOrWhiteSpace(agent) || !agent.ToLower().Contains("ys56"))
            {
                return Redirect("/404.html");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (MvcApplication.IsAutoConn)
                {
                    YSWL.MALL.BLL.Members.Users userBll = new YSWL.MALL.BLL.Members.Users();
               
                    YSWL.MALL.ViewModel.SAAS.UserInfo SAUserInfo = userBll.GetSAUserInfo(model.UserName, model.Password, 1);
                    if (SAUserInfo == null)
                    {
                        ModelState.AddModelError("Message", "用户名或密码不正确, 请重新输入!");
                        return View(model);
                    }
                    YSWL.Common.CallContextHelper.SetAutoTag(SAUserInfo.EnterpriseId);
                }

                AccountsPrincipal userPrincipal = AccountsPrincipal.ValidateLogin(model.UserName, model.Password);
                if (userPrincipal == null)
                {
                    ModelState.AddModelError("Message", "用户名或密码不正确, 请重新输入!");
                    return View(model);
                }
                User currentUser = new YSWL.Accounts.Bus.User(userPrincipal);
                if (!currentUser.Activity)
                {
                    ModelState.AddModelError("Message", "对不起，该帐号已被冻结或未激活，请联系管理员！");
                    return View(model);
                }
                HttpContext.User = userPrincipal;
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                Session[YSWL.Common.Globals.SESSIONKEY_USER] = currentUser;
                //登录成功加积分
                YSWL.MALL.BLL.Members.PointsDetail pointBll = new BLL.Members.PointsDetail();

                int pointers = pointBll.AddPoints(1, currentUser.UserID, "登录操作");
                int rankScore = BLL.Members.RankDetail.AddScore(1, currentUser.UserID, "登录操作");
                BLL.Shop.Products.ShoppingCartHelper.LoadShoppingCart(currentUser.UserID);

              bool IsMultiDepot= YSWL.MALL.BLL.Shop.Service.CommonHelper.OpenMultiDepot();

                #region 开启分仓时  设置配送地区
                if (IsMultiDepot) //开启了分仓  设置配送地区
                {
                    BLL.Shop.Shipping.ShippingAddress _addressManage = new BLL.Shop.Shipping.ShippingAddress();
                    List<YSWL.MALL.Model.Shop.Shipping.ShippingAddress> listAddress = _addressManage.GetModelList(0, " UserId=" + currentUser.UserID, "IsDefault desc ");

                    //用户从未设置
                    if (listAddress == null || listAddress.Count < 1)
                    {
                        SetRegionId(0);
                    }
                    else
                    {
                        SetRegionId(listAddress[0].RegionId);
                    }
                }
                #endregion

                returnUrl = Server.UrlDecode(returnUrl);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return Redirect("/");
                }
            }
            return View(model);
        }
        /// <summary>
        /// 设置配送地区Id
        /// </summary>
        public bool SetRegionId(int regionId)
        {
            BLL.Ms.Regions regsBll = new BLL.Ms.Regions();
            Common.Cookies.setKeyCookie("deliveryareas_regionname", regsBll.GetRegionFullName(regionId), 1440);
            return Common.Cookies.setKeyCookie("deliveryareas_regionId", regionId.ToString(), 1440);
        }

        #endregion
    }

}