﻿using System;
using System.Web.UI;
using YSWL.Accounts.Bus;

namespace YSWL.MALL.Web.Admin.Members.MembershipManage
{
    public partial class ModifyRankScore : PageBaseAdmin
    {
        public string strid = "";

        private YSWL.MALL.BLL.Members.SiteMessage bll = new BLL.Members.SiteMessage();
        private YSWL.Accounts.Bus.UserType UserType = new YSWL.Accounts.Bus.UserType();
        protected override int Act_PageLoad { get { return 707; } } //用户管理_会员信息管理_修改成长值

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    strid = Request.Params["id"];
                    int ID = (Convert.ToInt32(strid));
                    ShowInfo(ID);
                }
            }
        }

        private void ShowInfo(int ID)
        {
            lblID.Text = ID.ToString();
            AccountsPrincipal user = new AccountsPrincipal(ID);
            User manage = new YSWL.Accounts.Bus.User(user);

            BLL.Members.UsersExp expBll = new BLL.Members.UsersExp();
            Model.Members.UsersExpModel model = expBll.GetUsersExpModel(ID);
            if (manage != null && model != null)
            {
                this.lblUserName.Text = manage.UserName;
                this.lblTrueName.Text = manage.TrueName;
                this.lblPhone.Text = manage.Phone;
                this.lblNickName.Text = manage.NickName;
                this.lblEmail.Text = manage.Email;
            }
            if (model != null)
            {
                this.lblRankScore.Text = model.RankScore.ToString();
            }
            txtRankScore.Text = string.Empty;
        }

        protected void btnRankScore_Click(object sender, EventArgs e)
        {
            int userId = Common.Globals.SafeInt(lblID.Text, -1);
            if (userId < 1)
            {
                YSWL.Common.MessageBox.ShowFailTip(this, "账户信息非法, 请联系系统管理员!");
                return;
            }

            int rankScore = Common.Globals.SafeInt(txtRankScore.Text, 0);
            if (rankScore == 0)
            {
                YSWL.Common.MessageBox.ShowFailTip(this, "充值成长值不正确, 请重新输入!");
                return;
            }
            BLL.Members.RankDetail rankDetailBll = new BLL.Members.RankDetail();
            if (rankDetailBll.AddScoreByAdmin(userId, Math.Abs(rankScore),"",(rankScore > 0 ?0 : 1)))
            {
                YSWL.Common.MessageBox.ShowSuccessTipScript(this, Resources.Site.TooltipOperateOK, "$(parent.document).find('[id$=btnSearch]').click();");
                ShowInfo(userId);
                return;
            }
            YSWL.Common.MessageBox.ShowFailTip(this, Resources.Site.TooltipOperateError);
        }
    }
}