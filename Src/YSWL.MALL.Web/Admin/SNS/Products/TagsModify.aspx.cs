/**
* Modify.cs
*
* 功 能： [N/A]
* 类 名： Modify.cs
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
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
using YSWL.Common;
using YSWL.Accounts.Bus;
namespace YSWL.MALL.Web.SNS.Tags
{
    public partial class Modify : PageBaseAdmin
    {
        protected override int Act_PageLoad { get { return 600; } } //SNS_商品标签管理_编辑页
        YSWL.MALL.BLL.SNS.Tags bll = new YSWL.MALL.BLL.SNS.Tags();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
                ShowInfo();
            }
        }

        public void BindData()
        {
            YSWL.MALL.BLL.SNS.TagType tagTypeBll = new BLL.SNS.TagType();
            this.dropTypeId.DataSource = tagTypeBll.GetAllListEX();
            this.dropTypeId.DataTextField = "Name";
            this.dropTypeId.DataValueField = "ID";
            this.dropTypeId.DataBind();
            this.dropTypeId.Items.Insert(0, new ListItem("--请选择--", ""));
        }

        protected int TagID
        {
            get
            {
                int id = 0;
                string strId = Request.Params["id"];
                if (!string.IsNullOrWhiteSpace(strId))
                {
                    id = Globals.SafeInt(strId, 0);
                }
                return id;
            }
        }

        private void ShowInfo()
        {
            YSWL.MALL.Model.SNS.Tags model = bll.GetModel(TagID);
            if (null != model)
            {
                this.lblTagID.Text = model.TagID.ToString();
                this.txtTagName.Text = model.TagName;
                this.dropTypeId.SelectedValue = model.TypeId.ToString();
                this.radlIsRecommand.SelectedValue= model.IsRecommand.ToString();
                this.radlStatus.SelectedValue = model.Status.ToString();
            }
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            string TagName = this.txtTagName.Text.Trim();
            if (TagName.Length == 0)
            {
                MessageBox.ShowServerBusyTip(this, "标签的名称不能为空");
                return;
            }

            YSWL.MALL.Model.SNS.Tags model = bll.GetModel(TagID);
            if (null != model)
            {
                model.TagID = TagID;
                model.TagName = TagName;
                model.TypeId = Globals.SafeInt(this.dropTypeId.SelectedValue, 0);
                model.IsRecommand = int.Parse(this.radlIsRecommand.SelectedValue);
                model.Status = Globals.SafeInt(this.radlStatus.SelectedValue, 0);

                if (bll.Update(model))
                {
                    LogHelp.AddUserLog(CurrentUser.UserName, CurrentUser.UserType, "修改商品标签(id="+model.TagID+")成功", this);
                    MessageBox.ShowSuccessTip(this, Resources.Site.TooltipUpdateOK, "Tagslist.aspx");
                }
                else
                {
                    LogHelp.AddUserLog(CurrentUser.UserName, CurrentUser.UserType, "修改商品标签(id=" + model.TagID + ")失败", this);
                    MessageBox.ShowSuccessTip(this, Resources.Site.TooltipUpdateError);
                }
            }

        }

        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tagslist.aspx");
        }
    }
}
