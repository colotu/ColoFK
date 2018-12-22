using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using YSWL.MALL.Model.SysManage;
using YSWL.Web;

namespace YSWL.MALL.Web.Admin.SNS.Setting
{
    public partial class SNSToStatic : PageBaseAdmin
    {
        protected override int Act_PageLoad { get { return 613; } } //SNS_静态化页
        YSWL.MALL.BLL.SysManage.TaskQueue taskBll = new BLL.SysManage.TaskQueue();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //产品静态化
                this.txtTaskCount.Value = taskBll.GetRecordCount(" type=" + (int)YSWL.MALL.Model.SysManage.EnumHelper.TaskQueueType.SNSProduct).ToString();
                this.txtTaskReCount.Text = taskBll.GetRecordCount(" type=" + (int)YSWL.MALL.Model.SysManage.EnumHelper.TaskQueueType.SNSProduct + " and Status=0").ToString();

                YSWL.MALL.Model.SysManage.TaskQueue taskModel = taskBll.GetLastModel((int)YSWL.MALL.Model.SysManage.EnumHelper.TaskQueueType.SNSProduct);

                if (taskModel != null)
                {
                    this.txtTaskDate.Text = taskModel.RunDate.Value.ToString("yyyy-MM-dd");
                    this.txtTaskId.Text = (taskModel.ID + 1).ToString();
                }
                else
                {
                    this.txtTaskDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    this.txtTaskId.Text = "1";
                }
                //图片静态化
                this.txtTaskCount_C.Value = taskBll.GetRecordCount(" type=" + (int)YSWL.MALL.Model.SysManage.EnumHelper.TaskQueueType.SNSPhoto).ToString();
                this.txtTaskReCount_C.Text = taskBll.GetRecordCount(" type=" + (int)YSWL.MALL.Model.SysManage.EnumHelper.TaskQueueType.SNSPhoto + " and Status=0").ToString();
                YSWL.MALL.Model.SysManage.TaskQueue taskModel_C = taskBll.GetLastModel((int)YSWL.MALL.Model.SysManage.EnumHelper.TaskQueueType.SNSPhoto);
                if (taskModel_C != null)
                {
                    this.txtTaskDate_C.Text = taskModel_C.RunDate.Value.ToString("yyyy-MM-dd");
                    this.txtTaskId_C.Text = (taskModel_C.ID + 1).ToString();
                }
                else
                {
                    this.txtTaskDate_C.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    this.txtTaskId_C.Text = "1";
                }
                string value = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValue("SNSIsStatic");
                this.radlStatus.SelectedValue = value;
                this.txtIsStatic.Value = value;
            }
        }
        protected void radlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDictionaryEnumerator de = HttpContext.Current.Cache.GetEnumerator();
            ArrayList listCache = new ArrayList();
            while (de.MoveNext())
            {
                listCache.Add(de.Key.ToString());
            }
            foreach (string key in listCache)
            {
                HttpContext.Current.Cache.Remove(key);
            }
            string value = this.radlStatus.SelectedValue;
            if (YSWL.MALL.BLL.SysManage.ConfigSystem.Exists("SNSIsStatic"))
            {
                YSWL.MALL.BLL.SysManage.ConfigSystem.Update("SNSIsStatic", value, "是否静态化，true表示静态化，false表示不需要静态化");
            }
            else
            {
                YSWL.MALL.BLL.SysManage.ConfigSystem.Add("SNSIsStatic", value, "是否静态化，true表示静态化，false表示不需要静态化", ApplicationKeyType.System);
            }
            Response.Redirect("SNSToStatic.aspx");
        }

        #region 首页静态化

        protected void btnIndex_Click(object sender, EventArgs e)
        {
            string requestindexUrl = "";
            string requestgroupUrl = "";
            string requestalbumUrl = "";
            bool isSuccess = true;
            if (ckIndex.Checked)
            {
                if (MvcApplication.MainAreaRoute == AreaRoute.SNS)
                {
                    requestindexUrl = "/Home/Index?RequestType=1";
                    requestgroupUrl = "/Group/Index";
                    requestalbumUrl = "/Album/Index";
                }
                else
                {
                    requestindexUrl = "/SNS/Home/Index?RequestType=1";
                    requestgroupUrl = "/SNS/Group/Index";
                    requestalbumUrl = "/SNS/Album/Index";
                }
                if (!YSWL.MALL.BLL.CMS.GenerateHtml.HttpToStatic(requestindexUrl, "/index.html"))
                {
                    isSuccess = false;
                }
                if (!YSWL.MALL.BLL.CMS.GenerateHtml.HttpToStatic(requestgroupUrl, "/group.html"))
                {
                    isSuccess = false;
                }
                if (!YSWL.MALL.BLL.CMS.GenerateHtml.HttpToStatic(requestalbumUrl, "/album.html"))
                {
                    isSuccess = false;
                }
                if (isSuccess)
                {
                    YSWL.Common.MessageBox.ShowSuccessTip(this, "静态生成成功", "SNSToStatic.aspx");
                }
                else
                {
                    YSWL.Common.MessageBox.ShowSuccessTip(this, "静态生成失败，请重试", "SNSToStatic.aspx");
                }
            }
        }
        #endregion

    }
}
