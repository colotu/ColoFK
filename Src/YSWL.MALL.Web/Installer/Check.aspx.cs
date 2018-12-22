using System;
using System.IO;

namespace YSWL.Web.Installer
{
    public partial class Check : System.Web.UI.Page
    {
        private const string IMAGEOK = "/Installer/images/ok.gif";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                if (YSWL.Components.MvcApplication.IsInstall)
                {
                    Response.Redirect("/", true);
                    return;
                }
                if (!String.IsNullOrWhiteSpace(Request.Params["type"]) && Request.Params["type"] == "accepted")
                {
                    Session["Install"] = "Accepted";
                    // this.pnlDown.Visible = false;
                }
                else if (Session["Install"] == null)
                {
                    Response.Redirect("/Installer/Default.aspx");
                }
                StartCheck();
                // this.pnlDown.Visible = false;
            }
        }
        private void StartCheck()
        {
            bool IsCheckPass = true;
            //if (CheckEnvironment.CheckSqlServerVersion())
            //{
            //    this.imgSqlVersion.ImageUrl = IMAGEOK;
            //}
            //else
            //{
            //    IsCheckPass = false;
            //}
            if (
                //主版本号> 4 兼容未来版本
                Environment.Version.Major > 4 ||

                //次版本号> 4.0 兼容未来版本
                (Environment.Version.Major == 4 && Environment.Version.Minor > 0) ||

                //内部版本号>= 4.0.30319 最低版本
                (Environment.Version.Major == 4 &&
                    Environment.Version.Minor == 0 &&
                    Environment.Version.Build >= 30319)
                )
            {
                this.imgNetVersion.ImageUrl = IMAGEOK;
            }
            else
            {
                IsCheckPass = false;
            }
            //TODO: 检测是否是集成模式
            //TODO: 检测数据库类型和版本是否正确
            if (CheckEnvironment.DoCheckFileSystem("/Upload"))
            {
                this.imgUpload.ImageUrl = IMAGEOK;
            }
            else
            {
                IsCheckPass = false;
            }
            if (CheckEnvironment.DoCheckFileSystem("/"+YSWL.Components.MvcApplication.UploadFolder+"/Temp"))
            {
                this.imgTemp.ImageUrl = IMAGEOK;
            }
            else
            {
                IsCheckPass = false;
            }
            if (CheckEnvironment.DoCheckFileSystem("/"+YSWL.Components.MvcApplication.UploadFolder+"/User"))
            {
                this.imgUser.ImageUrl = IMAGEOK;
            }
            else
            {
                IsCheckPass = false;
            }
            if (CheckEnvironment.DoCheckFileSystem("/"+YSWL.Components.MvcApplication.UploadFolder+"/User/Gravatar"))
            {
                this.imgGravatar.ImageUrl = IMAGEOK;
            }
            else
            {
                IsCheckPass = false;
            }
            if (CheckEnvironment.DoCheckFileSystem("/Scripts"))
            {
                this.imgScripts.ImageUrl = IMAGEOK;
            }
            else
            {
                IsCheckPass = false;
            }
            if (CheckEnvironment.DoCheckFileSystem("/Content"))
            {
                this.imgContent.ImageUrl = IMAGEOK;
            }
            else
            {
                IsCheckPass = false;
            }
            if (CheckEnvironment.DoCheckFileSystem("/Admin"))
            {
                this.imgAdmin.ImageUrl = IMAGEOK;
            }
            else
            {
                IsCheckPass = false;
            }
            System.IO.FileInfo configFile = new FileInfo(Server.MapPath("/Web.config"));
            configFile.Refresh();
            if (!configFile.IsReadOnly)
            {
                this.imgConfig.ImageUrl = IMAGEOK;
            }
            else
            {
                IsCheckPass = false;
            }
            this.IsChechPass.Value = IsCheckPass.ToString();
            if (IsCheckPass)
            {
                this.btnCheck.Visible = false;
                Session["Install"] = "Checked";
            }
        }
        /// <summary>
        /// 重新检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCheck_Click(object sender, EventArgs e)
        {
            StartCheck();
        }
    }
}