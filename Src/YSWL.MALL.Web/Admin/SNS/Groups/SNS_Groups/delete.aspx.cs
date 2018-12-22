using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YSWL.MALL.Web.Admin.SNS.Groups.SNS_Groups
{
    public partial class delete : PageBaseAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            			if (!Page.IsPostBack)
			{
				YSWL.MALL.BLL.Groups.SNS_Groups bll=new YSWL.MALL.BLL.Groups.SNS_Groups();
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int GroupID=(Convert.ToInt32(Request.Params["id"]));
					bll.Delete(GroupID);
					Response.Redirect("list.aspx");
				}
			}

        }
    }
}