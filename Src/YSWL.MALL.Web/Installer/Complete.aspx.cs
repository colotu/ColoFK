using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YSWL.Common;

namespace YSWL.Web.Installer
{
    public partial class Complete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Request.Params["type"]) || Request.Params["type"] != "complete")
            {
                Response.Redirect("/Installer/Step.aspx");
            }
           // HttpRuntime.UnloadAppDomain();
        }
    }
}