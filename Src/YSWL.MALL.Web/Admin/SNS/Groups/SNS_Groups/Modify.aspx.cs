using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using YSWL.MALL.BLL.SNS;
using YSWL.Common;

namespace YSWL.MALL.Web.Admin.SNS.Groups.SNS_Groups
{
    public partial class Modify : PageBaseAdmin
    {

        YSWL.MALL.BLL.Groups.SNS_Groups bll = new YSWL.MALL.BLL.Groups.SNS_Groups();
        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
                BindData();
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int GroupID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(GroupID);
				}
			    
			}
		}
			
	private void ShowInfo(int GroupID)
	{
		
		YSWL.MALL.Model.Groups.SNS_Groups model=bll.GetModel(GroupID);
		this.txtGroupName.Text=model.GroupName;
	    this.groupId.Value = GroupID.ToString();
		this.txtGroupDescription.Text=model.GroupDescription;
		this.txtGroupLogo.Value=model.GroupLogo;
		string tags=model.Tags;
        if (tags.Length > 0)
        {
            string[] tagList = tags.Split(',');
            for (int i = 0; i < tagList.Length; i++)
            {
                foreach (ListItem item in chkTagsList.Items)
                {
                    if (item.Text == tagList[i])
                    {
                        item.Selected = true;
                    }
                }
            }

        }
	}

		public void btnSave_Click(object sender, EventArgs e)
		{
       if (this.txtGroupName.Text.Trim().Length == 0)
            {
                MessageBox.ShowFailTip(this, "小组名称不能为空");
                return;
            }
            if (this.txtGroupDescription.Text.Trim().Length == 0)
            {
                MessageBox.ShowFailTip(this, "小组的简介不能为空");
                return;
            }
            if (this.txtGroupLogo.Value.Length == 0)
            {
                MessageBox.ShowFailTip(this, "小组的logo不能为空");
                return;
            }
		    int groupId =Globals.SafeInt(this.groupId.Value,0);
            string GroupName = this.txtGroupName.Text;
            string GroupDescription = this.txtGroupDescription.Text;
            string GroupLogo = this.txtGroupLogo.Value;
            string tags = null;
            foreach (ListItem item in chkTagsList.Items)
            {
                if (item.Selected)
                {
                    tags += "," + item.Text;
                }
            }
            YSWL.MALL.Model.Groups.SNS_Groups model = bll.GetModel(groupId);
            if (null != model)
            {
                model.GroupName = GroupName;
                model.GroupDescription = GroupDescription;
                model.GroupLogo = GroupLogo;
                model.Tags = string.IsNullOrWhiteSpace(tags) ? "" : tags.TrimStart(',');
            }
			bll.Update(model);
            MessageBox.ShowSuccessTip(this, "保存成功", "list.aspx");
		}


        public void BindData()
        {
            YSWL.MALL.BLL.SNS.GroupTags groupTagsBll = new GroupTags();
            DataSet ds = groupTagsBll.GetList(" Status=1");
            chkTagsList.DataSource = ds;
            chkTagsList.DataTextField = "TagName";
            chkTagsList.DataValueField = "TagID";
            chkTagsList.DataBind();
        }
        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
