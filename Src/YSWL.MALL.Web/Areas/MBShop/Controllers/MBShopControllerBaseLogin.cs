using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using YSWL.Accounts.Bus;
using YSWL.Common;

namespace YSWL.MALL.Web.Areas.MBShop.Controllers
{
    [MBShopError]
    public class MBShopControllerBaseLogin: YSWL.MALL.Web.Controllers.ControllerBase
    {
        //
        // GET: /Mobile/MobileControllerBase/
        #region UserName
        public string UserOpen
        {
            get
            {
                if (Session["WeChat_UserName"] != null)
                {
                    return Session["WeChat_UserName"].ToString();
                }
                return String.Empty;
            }
        }
        #endregion

        #region  OpenId
        public string OpenId
        {
            get
            {
                if (Session["WeChat_OpenId"] != null)
                {
                    return Session["WeChat_OpenId"].ToString();
                }
                return String.Empty;
            }
        }



        #endregion

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
        protected override bool InitializeComponent(ActionExecutingContext filterContext)
        {
            if (MvcApplication.IsAutoConn)//如果是SAAS 自动化链接
            {
                long enterpriseId = Common.Globals.SafeLong(Common.CallContextHelper.GetClearTag(), 0);
                if (enterpriseId <= 0)
                {
                    string returnUrl = Common.ConfigHelper.GetConfigString("SAASLoginUrl");
                    filterContext.Result = Redirect(returnUrl);
                    return false;
                }
            }

            //判断是否开启登陆验证
            bool isOpenLogin= YSWL.MALL.BLL.SysManage.ConfigSystem.GetBoolValueByCache("MBShop_IsOpenLogin");//是否开启登陆认证
            if (!HttpContext.User.Identity.IsAuthenticated && !isOpenLogin) return true;
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = RedirectToLogin(filterContext);
             
                return false;
            }
            try
            {
                userPrincipal = new AccountsPrincipal(HttpContext.User.Identity.Name);
            }
            catch (System.Security.Principal.IdentityNotMappedException)
            {
                //用户在DB中不存在 退出
                System.Web.Security.FormsAuthentication.SignOut();
                Session.Remove(Globals.SESSIONKEY_USER);
                Session.Clear();
                Session.Abandon();
                filterContext.Result = RedirectToLogin(filterContext);
                 
                return false;
            }
            if (Session[Globals.SESSIONKEY_USER] == null)
            {
                currentUser = new YSWL.Accounts.Bus.User(userPrincipal);
                Session[Globals.SESSIONKEY_USER] = currentUser;
                Session["Style"] = currentUser.Style;
            }
            else
            {
                currentUser = (YSWL.Accounts.Bus.User)Session[Globals.SESSIONKEY_USER];
                Session["Style"] = currentUser.Style;
            }

            if (CurrentUser == null || CurrentUser.UserType == "AA")
            {
                filterContext.Result = RedirectToLogin(filterContext);
                
                return false;
            }
            return true;
        }
        public ActionResult RedirectToLogin(ActionExecutingContext filterContext)
        {

                bool IsAutoLogin = Common.Globals.SafeBool(YSWL.WeChat.BLL.Core.Config.GetValueByCache("WeChat_AutoLogin", -1, "AA"), false);
                string rawurl = Request.RawUrl;
                #region  自动登陆
                bool IsNeedBind = YSWL.MALL.BLL.SysManage.ConfigSystem.GetBoolValueByCache("SyStem_WeChat_UserBind");
                YSWL.WeChat.BLL.Core.User wUserBll = new WeChat.BLL.Core.User();
                if (String.IsNullOrWhiteSpace(OpenId) || String.IsNullOrWhiteSpace(UserOpen))
                {
                    return Redirect(ViewBag.BasePath + "a/l/?returnUrl=" + Server.UrlEncode(rawurl));
                }
                YSWL.WeChat.Model.Core.User wUserModel = wUserBll.GetUser(OpenId, UserOpen);
                if (IsNeedBind)
                {
                    if (wUserModel.UserId <= 0)
                    {
                        return Redirect(ViewBag.BasePath + "a/l/?returnUrl=" + Server.UrlEncode(rawurl));
                    }
                    AccountsPrincipal userPrincipal = new AccountsPrincipal(wUserModel.UserId);
                    currentUser = new YSWL.Accounts.Bus.User(userPrincipal);
                    if (!currentUser.Activity)
                    {
                        return Redirect(ViewBag.BasePath + "a/l/?returnUrl=" + Server.UrlEncode(rawurl));
                    }
                    HttpContext.User = userPrincipal;
                    Session[YSWL.Common.Globals.SESSIONKEY_USER] = currentUser;
                    FormsAuthentication.SetAuthCookie(currentUser.UserName, true);
                    BLL.Shop.Products.ShoppingCartHelper.LoadShoppingCart(currentUser.UserID);//加载购物车
                    return String.IsNullOrWhiteSpace(rawurl) ? Redirect(ViewBag.BasePath + "u") : Redirect(rawurl);
                }
                if (IsAutoLogin)
                {
                    string AutoLoginUrl = "/MShop/Account/RegBind?returnUrl=" + Server.UrlEncode(rawurl);
                    if (wUserModel.UserId <= 0)
                    {
                        return Redirect(AutoLoginUrl);
                    }
                    AccountsPrincipal userPrincipal = new AccountsPrincipal(wUserModel.UserId);
                    User currentUser = new YSWL.Accounts.Bus.User(userPrincipal);
                    if (!currentUser.Activity)
                    {
                        return Redirect(AutoLoginUrl);
                    }
                    HttpContext.User = userPrincipal;
                    Session[YSWL.Common.Globals.SESSIONKEY_USER] = currentUser;
                    FormsAuthentication.SetAuthCookie(currentUser.UserName, true);
                    BLL.Shop.Products.ShoppingCartHelper.LoadShoppingCart(currentUser.UserID);//加载购物车
                    return String.IsNullOrWhiteSpace(rawurl) ? Redirect(ViewBag.BasePath + "u") : Redirect(rawurl);
                }
                #endregion

                return Redirect(ViewBag.BasePath + "a/l/?returnUrl=" + Server.UrlEncode(rawurl));
        }
    }
}