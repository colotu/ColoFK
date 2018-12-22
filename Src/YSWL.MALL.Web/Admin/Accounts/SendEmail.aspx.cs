using System;
using System.Web.UI;
using YSWL.Accounts.Bus;
using YSWL.MALL.BLL.SysManage;
using YSWL.Common;

namespace YSWL.MALL.Web.Admin.Accounts
{
    public partial class SendEmail : PageBaseAdmin
    {
        protected override int Act_PageLoad { get { return 164; } } //��վ����_�Ƿ���ʾ�ʼ�Ⱥ��ҳ��

        protected new int Act_UpdateData = 165;    //��վ����_�ʼ�Ⱥ��_�����ʼ�

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!UserPrincipal.HasPermissionID(GetPermidByActID(Act_UpdateData)) && GetPermidByActID(Act_UpdateData) != -1)
                {
                    btnNext.Visible = false;
                }
                if (!string.IsNullOrWhiteSpace(Request.Params["content"]))
                {
                    this.txtContent.Text = Server.UrlDecode(Request.Params["content"]);
                }

                if (!string.IsNullOrWhiteSpace(Request.Params["title"]))
                {
                    this.txtTitle.Text = Server.UrlDecode(Request.Params["title"]);
                }
            }
        }

        /// <summary>
        /// �������͵��ʼ��������
        /// </summary>
        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtTitle.Text))
            {
                YSWL.Common.MessageBox.ShowFailTip(this, Resources.SysManage.ErrorSubjectNotNull);
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtContent.Text))
            {
                YSWL.Common.MessageBox.ShowFailTip(this, Resources.SysManage.ErrorContentNotNull);
                return;
            }
         
            if (this.Multi.Checked)
            {
                //�����ʼ�����
                if (YSWL.Email.EmailManage.PushQueue(this.DropUserType.SelectedValue, "", this.txtTitle.Text, this.txtContent.Text, ""))
                {
                    YSWL.Common.MessageBox.ShowSuccessTip(this, Resources.SysManage.TooltipSentSuccessfully, "SendEmail.aspx");
                }
                else
                {
                    YSWL.Common.MessageBox.ShowFailTip(this, Resources.SysManage.TooltipSentFailed, "SendEmail.aspx");
                }
            }
            else
            {
                int userId = Common.Globals.SafeInt(txtUserId.Text, 0);
                User user = new YSWL.Accounts.Bus.User(userId);
                if (this.Single.Checked && String.IsNullOrWhiteSpace(user.UserName))
                {
                    YSWL.Common.MessageBox.ShowFailTip(this, Resources.SysManage.ErrorUserInexistence);
                    return;
                }
                //�����ʼ�����
                if (YSWL.Email.EmailManage.PushQueue("", user.UserName, this.txtTitle.Text, this.txtContent.Text, ""))
                {
                    YSWL.Common.MessageBox.ShowSuccessTip(this, Resources.SysManage.TooltipSentSuccessfully, "SendEmail.aspx");
                }
                else
                {
                    YSWL.Common.MessageBox.ShowFailTip(this, Resources.SysManage.TooltipSentFailed, "SendEmail.aspx");
                }
            }
        }

        /// <summary>
        /// ���Ͳ����ʼ�
        /// </summary>
        protected void btnTestSend_Click(object sender, EventArgs e)
        {
            Model.MailConfig site = new BLL.MailConfig().GetModel();
            if (site == null)
            {
                MessageBox.ShowServerBusyTip(this, "����û�н����ʼ�����,��������,3�����ת..", "/admin/Accounts/MailConfigInfo.aspx");
                return;
            }
            WebSiteSet webSet = new WebSiteSet(YSWL.MALL.Model.SysManage.ApplicationKeyType.CMS);
            string WebName = webSet.WebName;
            string content = string.Format(Resources.SysManage.EmailBodyTemplate, WebName);// EmailBodyTemplate
            YSWL.Email.Model.EmailQueue model = new Email.Model.EmailQueue();
            model.EmailTo = site.Mailaddress;
            model.EmailSubject = string.Format(Resources.SysManage.EmailSubjectTemplate, WebName);
            model.EmailFrom = site.Mailaddress;
            model.EmailBody = content;
            model.EmailPriority = 0;
            model.IsBodyHtml = false;
            model.NextTryTime = DateTime.Now;
            if (YSWL.Email.EmailManage.PushQueue(model))
            {
                MessageBox.ShowSuccessTip(this, Resources.SysManage.TooltipNoteToCheck);
            }
            else
            {
                MessageBox.ShowFailTip(this, Resources.SysManage.TooltipRetryAfter);
            }
        }
    }
}