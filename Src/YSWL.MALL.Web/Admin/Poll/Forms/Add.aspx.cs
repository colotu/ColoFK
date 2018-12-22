using System;
namespace YSWL.MALL.Web.Forms
{
    public partial class Add : PageBaseAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Master.TabTitle = "��Ϣ����������ϸ��д������Ϣ";
        }
        protected override int Act_PageLoad { get { return 354; } } //�ͷ�����_�ʾ����_����ҳ
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtName.Text))
            {
                YSWL.Common.MessageBox.ShowFailTip(this, Resources.Poll.ErrorFormsNameNull);
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtDescription.Text))
            {
                YSWL.Common.MessageBox.ShowFailTip(this, Resources.Poll.ErrorFormsExplainNull);
                return;
            }
            string Name = this.txtName.Text;
            string Description = this.txtDescription.Text;

            YSWL.MALL.Model.Poll.Forms model = new YSWL.MALL.Model.Poll.Forms();
            model.Name = Name;
            model.Description = Description;

            YSWL.MALL.BLL.Poll.Forms bll = new YSWL.MALL.BLL.Poll.Forms();
            int id = bll.Add(model);
            if (id > 0)
            {
                Response.Redirect("../Topics/Index.aspx?fid=" + id.ToString());
            }
            else
            {
                YSWL.Common.MessageBox.ShowFailTip(this, "����ʧ�ܣ�");
            }
        }

    }
}
