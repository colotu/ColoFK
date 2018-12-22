using System;

namespace YSWL.MALL.Web.Controls
{
    public partial class copyright : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            if (!MvcApplication.IsAutoConn)
            {
                this.litCopyright.Text = BLL.SysManage.ConfigSystem.GetValueByCache("WebPowerBy");
                string webRecord = BLL.SysManage.ConfigSystem.GetValueByCache("WebRecord");
                if (!string.IsNullOrWhiteSpace(webRecord))
                {
                    this.LitWebRecord.Text = "<br />" + Server.HtmlEncode(webRecord);
                }
                this.LitWebRecord.Text += (
                    (!MvcApplication.IsAuthorize)
                        ? string.Format(
                            "<br /> Powered by <a href=\"http://www.ys56.com/\" target=\"_blank\" style=\"color: #333;\" >{0}</a> {1} © YSWL Inc.",
                            MvcApplication.ProductInfo, MvcApplication.Version)
                        : ""
                    );
            }
        }
    }
}