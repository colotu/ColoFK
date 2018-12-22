/**
* Add.cs
*
* 功 能： [N/A]
* 类 名： Add.cs
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
using YSWL.Common;

namespace YSWL.MALL.Web.Admin.SNS.GradeConfig
{
    [Obsolete]
    public partial class Add : PageBaseAdmin
    {
        protected override int Act_PageLoad { get { return 576; } } //SNS_会员等级管理_新增页
        protected void Page_Load(object sender, EventArgs e)
        {

          
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.btnCancle.Enabled = false;
            this.btnSave.Enabled = false;
            if (string.IsNullOrWhiteSpace(this.txtGradeName.Text))
            {
                this.btnCancle.Enabled = true;
                this.btnSave.Enabled = true;
                MessageBox.ShowFailTip(this, "请输入等级名称！");
                return;
            }
            if (Globals.SafeInt(this.txtGradeName.Text,0)>20)
            {
                this.btnCancle.Enabled = true;
                this.btnSave.Enabled = true;
                MessageBox.ShowFailTip(this, "请输入0-20之间正确的等级名称！");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtMinRange.Text))
            {
                this.btnCancle.Enabled = true;
                this.btnSave.Enabled = true;
                MessageBox.ShowFailTip(this, "请输入等级积分下限！");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtGradeName.Text))
            {
                this.btnCancle.Enabled = true;
                this.btnSave.Enabled = true;
                MessageBox.ShowFailTip(this, "请输入等级积分上限！");
                return;
            }

            string GradeName = this.txtGradeName.Text;
            int MinRange = int.Parse(this.txtMinRange.Text);
            int MaxRange = int.Parse(this.txtMaxRange.Text);

            YSWL.MALL.Model.SNS.GradeConfig model = new YSWL.MALL.Model.SNS.GradeConfig();
            model.GradeName = GradeName;
            model.MinRange = MinRange;
            model.MaxRange = MaxRange;

            YSWL.MALL.BLL.SNS.GradeConfig bll = new YSWL.MALL.BLL.SNS.GradeConfig();
            int ID;
            if ((ID=bll.Add(model) )> 0)
            {
                  YSWL.Common.MessageBox.ShowSuccessTip(this, "保存成功！", "Gradelist.aspx");
                   LogHelp.AddUserLog(CurrentUser.UserName, CurrentUser.UserType, "新增用户等级(GradeID="+ID+")成功", this);
            }
            else
            {
                this.btnCancle.Enabled = true;
                this.btnSave.Enabled = true;
                YSWL.Common.MessageBox.ShowFailTip(this, "系统忙，请稍后再试！");
                LogHelp.AddUserLog(CurrentUser.UserName, CurrentUser.UserType, "新增用户等级失败", this);
            }
        }

        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("Gradelist.aspx");
        }
    }
}