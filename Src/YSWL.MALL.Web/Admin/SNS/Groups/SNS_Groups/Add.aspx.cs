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
    public partial class Add : PageBaseAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                BindData();
            }
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			if(this.txtGroupName.Text.Trim().Length==0)
			{
				MessageBox.ShowFailTip(this,"小组名称不能为空");
			    return;
			}
			if(this.txtGroupDescription.Text.Trim().Length==0)
			{
                MessageBox.ShowFailTip(this, "小组的简介不能为空");
                return;
			}
            if (this.txtGroupLogo.Value.Length == 0)
			{
                MessageBox.ShowFailTip(this, "小组的logo不能为空");
                return;
			}
		
			string GroupName=this.txtGroupName.Text;
			string GroupDescription=this.txtGroupDescription.Text;
			int GroupUserCount=1;
        	int CreatedUserId =1;
			string CreatedNickName="";
			DateTime CreatedDate=DateTime.Now;
            string GroupLogo = this.txtGroupLogo.Value;
			string GroupLogoThumb="";
            string GroupBackground = "";
            string ApplyGroupReason = "";
			int IsRecommand=1;
            int TopicCount = 0;
			int TopicReplyCount=0;
			int Status=1;
			int Sequence=1;
			int Privacy=1;
        		    string tags = null;
                    foreach (ListItem item in chkTagsList.Items)
        		    {
                        if (item.Selected)
        		        {
        		            tags += "," + item.Text;
        		        }
        		    }
			//string Tags=this.txtTags.Text;

			YSWL.MALL.Model.Groups.SNS_Groups model=new YSWL.MALL.Model.Groups.SNS_Groups();
			model.GroupName=GroupName;
			model.GroupDescription=GroupDescription;
			model.GroupUserCount=GroupUserCount;
			model.CreatedUserId=CreatedUserId;
			model.CreatedNickName=CreatedNickName;
			model.CreatedDate=CreatedDate;
			model.GroupLogo=GroupLogo;
			model.GroupLogoThumb=GroupLogoThumb;
			model.GroupBackground=GroupBackground;
			model.ApplyGroupReason=ApplyGroupReason;
			model.IsRecommand=IsRecommand;
			model.TopicCount=TopicCount;
			model.TopicReplyCount=TopicReplyCount;
			model.Status=Status;
			model.Sequence=Sequence;
			model.Privacy=Privacy;
            model.Tags =string.IsNullOrWhiteSpace(tags)?"": tags.TrimStart(',');
			YSWL.MALL.BLL.Groups.SNS_Groups bll=new YSWL.MALL.BLL.Groups.SNS_Groups();
			bll.Add(model);
			//YSWL.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");
            MessageBox.ShowSuccessTip(this,"保存成功","list.aspx");
		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }

        public void BindData()
        {
            YSWL.MALL.BLL.SNS.GroupTags groupTagsBll=new GroupTags();
            DataSet ds = groupTagsBll.GetList(" Status=1");
            chkTagsList.DataSource = ds;
            chkTagsList.DataTextField = "TagName";
            chkTagsList.DataValueField = "TagID";
            chkTagsList.DataBind();
        }


    }
}
