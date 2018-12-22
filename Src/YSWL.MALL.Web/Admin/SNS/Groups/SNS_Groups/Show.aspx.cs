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
namespace YSWL.MALL.Web.Admin.SNS.Groups.SNS_Groups
{
    public partial class Show : PageBaseAdmin
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int GroupID=(Convert.ToInt32(strid));
					ShowInfo(GroupID);
				}
			}
		}
		
	private void ShowInfo(int GroupID)
	{
		YSWL.MALL.BLL.Groups.SNS_Groups bll=new YSWL.MALL.BLL.Groups.SNS_Groups();
		YSWL.MALL.Model.Groups.SNS_Groups model=bll.GetModel(GroupID);
		this.lblGroupID.Text=model.GroupID.ToString();
		this.lblGroupName.Text=model.GroupName;
		this.lblGroupDescription.Text=model.GroupDescription;
		this.lblGroupUserCount.Text=model.GroupUserCount.ToString();
		this.lblCreatedUserId.Text=model.CreatedUserId.ToString();
		this.lblCreatedNickName.Text=model.CreatedNickName;
		this.lblCreatedDate.Text=model.CreatedDate.ToString();
		this.lblGroupLogo.Text=model.GroupLogo;
		this.lblGroupLogoThumb.Text=model.GroupLogoThumb;
		this.lblGroupBackground.Text=model.GroupBackground;
		this.lblApplyGroupReason.Text=model.ApplyGroupReason;
		this.lblIsRecommand.Text=model.IsRecommand.ToString();
		this.lblTopicCount.Text=model.TopicCount.ToString();
		this.lblTopicReplyCount.Text=model.TopicReplyCount.ToString();
		this.lblStatus.Text=model.Status.ToString();
		this.lblSequence.Text=model.Sequence.ToString();
		this.lblPrivacy.Text=model.Privacy.ToString();
		this.lblTags.Text=model.Tags;

	}


    }
}
