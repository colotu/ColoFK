﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using YSWL.Accounts.Bus;
using YSWL.Common;
using YSWL.MALL.Web.Components;

namespace YSWL.MALL.Web.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        private string returnUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 是否开启 获取企业标识

                string tag = Request.Params["tag"];
                returnUrl = Request.Params["s"];
                if (MvcApplication.IsAutoConn)
                {
                    returnUrl = Common.ConfigHelper.GetConfigString("SAASLoginUrl");
                    if (String.IsNullOrWhiteSpace(tag))
                    {
                        Response.Write("<script language='javascript'>window.top.location='" + returnUrl + "'</script>");
                        return;
                    }
                    long enterpriseId = YSWL.Common.DEncrypt.DEncrypt.ConvertToNumber(tag);
                    if (enterpriseId <= 0)
                    {
                        Response.Write("<script language='javascript'>window.top.location='" + returnUrl + "'</script>");
                        return;
                    }
                    Session["YSWL_Auto_EnterpriseID"] = enterpriseId; //保存在session里面
                    Common.CallContextHelper.SetAutoTag(enterpriseId);
                    if (!YSWL.SAAS.BLL.SAASInfo.IsDBExists())
                    {
                        Response.Write("<script language='javascript'>window.top.location='" + returnUrl + "'</script>");
                        return;
                    }
                }

                #endregion

                if (String.IsNullOrWhiteSpace(returnUrl))
                {
                    return;
                }

                #region 模拟登录

                string userName = YSWL.AuthenticationManagerClient.ClientManager.CheckUser();
                if (String.IsNullOrWhiteSpace(userName))
                {
                    Response.Write("<script language='javascript'>window.top.location='" + returnUrl + "'</script>");
                    return;
                }
                User currentUser = new User(userName);//获取系统相关的用户信息
                string allowUserType = Common.ConfigHelper.GetConfigString("UserType");
                List<String> UserTypeList = new List<string> { "AA" }; //允许后台登录的用户类型
                if (!String.IsNullOrWhiteSpace(allowUserType))
                {
                    UserTypeList.AddRange(allowUserType.Split(','));
                }
                if (!UserTypeList.Contains(currentUser.UserType))
                {
                    Response.Write("<script language='javascript'>window.top.location='" + returnUrl + "'</script>");
                    return;
                }
                if (!currentUser.Activity)
                {
                    Response.Write("<script language='javascript'>window.top.location='" + returnUrl + "'</script>");
                    return;
                }
                FormsAuthentication.SetAuthCookie(currentUser.UserName, false);
                Session[YSWL.Common.Globals.SESSIONKEY_ADMIN] = currentUser;
                Session["Style"] = currentUser.Style;
                //log
                LogHelp.AddUserLog(currentUser.UserName, currentUser.UserType, "登录成功", this);
                Response.Redirect("/admin/main.htm");

                #endregion

                Page.Title = MvcApplication.SiteName + "-系统登录" + ((!MvcApplication.IsAuthorize)
                    ? YSWL.Common.DEncrypt.Hex16.Decode("0050006F0077006500720065006400200062007900204E915546672A6765")
                    : "");

                if (Session[Globals.SESSIONKEY_ADMIN] != null)
                {
                    Response.Redirect("main.htm");
                }


                if (YSWL.Common.ConfigHelper.GetConfigBool("LocalTest"))
                {
                    AccountsPrincipal newUser = AccountsPrincipal.ValidateLogin("admin", "1");
                    currentUser = new YSWL.Accounts.Bus.User(newUser);
                    Context.User = newUser;
                    FormsAuthentication.SetAuthCookie(currentUser.UserName, false);
                    Session[YSWL.Common.Globals.SESSIONKEY_ADMIN] = currentUser;
                    Session["Style"] = currentUser.Style;

                    //选择语言
                    Session["language"] = "zh-CN";
                    HttpCookie mCookie = new HttpCookie("language");
                    mCookie.Value = "zh-CN";
                    mCookie.Expires = DateTime.MaxValue;
                    Response.AppendCookie(mCookie);
                    YSWL.Common.MessageBox.ShowSuccessTip(this, "自动登录成功, 正在为您跳转..", "main.htm");
                }
            }
        }

        public void btnLogin_Click(object sender, EventArgs e)
        {
            if ((Session["PassErrorCountAdmin"] != null) && (Session["PassErrorCountAdmin"].ToString() != ""))
            {
                int PassErroeCount = Convert.ToInt32(Session["PassErrorCountAdmin"]);
                if (PassErroeCount > 3)
                {
                    txtUsername.Enabled = false;
                    txtPass.Enabled = false;
                    btnLogin.Enabled = false;
                    this.lblMsg.Text = "对不起，你已经登录错误三次，系统锁定，请联系管理员！";
                    return;
                }
            }
            if ((Session["CheckCode"] != null) && (Session["CheckCode"].ToString() != ""))
            {
                if (Session["CheckCode"].ToString().ToLower() != this.CheckCode.Value.ToLower())
                {
                    this.lblMsg.Text = "验证码错误!";
                    Session["CheckCode"] = null;
                    return;
                }
                else
                {
                    Session["CheckCode"] = null;
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            #region

            string userName = YSWL.Common.PageValidate.InputText(txtUsername.Text.Trim(), 30);
            string Password = YSWL.Common.PageValidate.InputText(txtPass.Text.Trim(), 30);
            AccountsPrincipal userPrincipal = AccountsPrincipal.ValidateLogin(userName, Password);
            if (userPrincipal != null)
            {
                User currentUser = new YSWL.Accounts.Bus.User(userPrincipal);
                if (currentUser.UserType != "AA")
                {
                    this.lblMsg.Text = "您非管理员用户或者业务员，您没有权限登录后台系统！";
                    return;
                }
                Context.User = userPrincipal;
                if (((SiteIdentity)User.Identity).TestPassword(Password) == 0)
                {
                    try
                    {
                        this.lblMsg.Text = "密码错误！";
                        LogHelp.AddUserLog(userName, "", lblMsg.Text, this);
                    }
                    catch
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
                else
                {
                    if (!currentUser.Activity)
                    {
                        YSWL.Common.MessageBox.ShowSuccessTip(this, "对不起，该帐号已被冻结，请联系管理员！");
                        return;
                    }

                    #region 单用户登录模式

                    //单用户登录模式
                    //SingleLogin slogin = new SingleLogin();

                    ////if (slogin.IsLogin(currentUser.UserID))
                    ////{
                    ////    YSWL.Common.MessageBox.ShowSuccessTip(this, "对不起，你的帐号已经登录！");
                    ////    return;
                    ////}
                    //slogin.UserLogin(currentUser.UserID);

                    #endregion 单用户登录模式

                    FormsAuthentication.SetAuthCookie(userName, false);

                    Session[YSWL.Common.Globals.SESSIONKEY_ADMIN] = currentUser;
                    Session["Style"] = currentUser.Style;

                    //log
                    LogHelp.AddUserLog(currentUser.UserName, currentUser.UserType, "登录成功", this);


                    if (Session["returnPage"] != null)
                    {
                        string returnpage = Session["returnPage"].ToString();
                        Session["returnPage"] = null;
                        Response.Redirect(returnpage);
                    }
                    else
                    {
                        Response.Redirect("main.htm");
                    }
                }
            }
            else
            {
                this.lblMsg.Text = "登录失败，请确认用户名或密码是否正确。";
                if ((Session["PassErrorCountAdmin"] != null) && (Session["PassErrorCountAdmin"].ToString() != ""))
                {
                    int PassErroeCount = Convert.ToInt32(Session["PassErrorCountAdmin"]);
                    Session["PassErrorCountAdmin"] = PassErroeCount + 1;
                }
                else
                {
                    Session["PassErrorCountAdmin"] = 1;
                }

                //log
                LogHelp.AddUserLog(userName, "", "登录失败!", this);
            }

            #endregion
        }
    }
}