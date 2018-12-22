using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using YSWL.Common;

namespace YSWL.MALL.Web.Admin
{
    public partial class Logout : System.Web.UI.Page
    {
        string defaullogin = "/admin/login.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[YSWL.Common.Globals.SESSIONKEY_ADMIN] != null)
            {

                YSWL.Accounts.Bus.User currentUser = (YSWL.Accounts.Bus.User)Session[YSWL.Common.Globals.SESSIONKEY_ADMIN];
                #region  加上企业标识

                if (MvcApplication.IsAutoConn)
                {
                    long enterpriseId = Common.Globals.SafeLong(Session["YSWL_Auto_EnterpriseID"], 0);
                    //保存在session里面
                    if (enterpriseId == 0)
                    {
                        //获取cookie中的企业标识
                        string tag = Common.Cookies.getKeyCookie("YSWL_SAAS_EnterpriseID");
                        Response.Write("<script language='javascript'>window.top.location='/login/" + tag + "'</script>");
                        Response.End();
                        return; //企业标识丢失，重新登陆
                    }
                    Common.CallContextHelper.SetAutoTag(enterpriseId);
                    // defaullogin = "/login/" + Common.DEncrypt.DEncrypt.GetEncryptionStr(enterpriseId);
                    //跳转到SAAS登录页
                    defaullogin = Common.ConfigHelper.GetConfigString("SAASLoginUrl");
                    if (String.IsNullOrWhiteSpace(defaullogin))
                    {
                        defaullogin = "/login/" + Common.DEncrypt.DEncrypt.GetEncryptionStr(enterpriseId);
                    }
                    YSWL.AuthenticationManagerClient.ClientManager.SingCurrentOut();//远程处理SAAS退出
                }

                #endregion
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
            Session.Remove(Globals.SESSIONKEY_ADMIN);
            Session.Clear();
            Session.Abandon();
            Response.Clear();
            Response.Write("<script language='javascript'>window.top.location='" + defaullogin + "'</script>");
            Response.End();
        }
    }
}
