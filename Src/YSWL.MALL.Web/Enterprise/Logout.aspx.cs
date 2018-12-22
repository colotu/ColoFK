﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using YSWL.Common;

namespace YSWL.MALL.Web.Enterprise
{
    public partial class Logout : System.Web.UI.Page
    {
        protected readonly string DefaultLoginEnterprise = BLL.SysManage.ConfigSystem.GetValueByCache("DefaultLoginEnterprise");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Globals.SESSIONKEY_ENTERPRISE] != null)
            {
                YSWL.Accounts.Bus.User currentUser = (YSWL.Accounts.Bus.User)Session[Globals.SESSIONKEY_ENTERPRISE];
                LogHelp.AddUserLog(currentUser.UserName, currentUser.UserType, "退出系统", this);

                #region 更新最新的登录时间
                YSWL.MALL.BLL.Members.UsersExp uBll = new BLL.Members.UsersExp();
                Model.Members.UsersExpModel uModel = new Model.Members.UsersExpModel();
                uModel = uBll.GetUsersExpModel(currentUser.UserID);
                if (uModel != null)
                {
                    uModel.LastAccessIP = Request.UserHostAddress;
                    uModel.LastLoginTime = DateTime.Now;
                    uBll.Update(uModel);
                }
                #endregion

            }
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            Response.Clear();
            Response.Redirect(DefaultLoginEnterprise);
            //Response.Write("<script defer>window.location='" + defaullogin + "';</script>");
            Response.End();
        }
    }
}
