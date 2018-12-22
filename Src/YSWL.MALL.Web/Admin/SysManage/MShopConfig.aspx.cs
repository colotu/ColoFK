﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YSWL.Common;
using YSWL.MALL.Model.SysManage;
using System.Collections;

namespace YSWL.MALL.Web.Admin.SysManage
{
    public partial class MShopConfig : PageBaseAdmin
    {
        protected override int Act_PageLoad { get { return 160; } } //网站管理_是否显示网站设置页面
        protected new int Act_UpdateData = 161;    //网站管理_网站设置_编辑网站信息
        public string SeoSetting = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!UserPrincipal.HasPermissionID(GetPermidByActID(Act_UpdateData)) && GetPermidByActID(Act_UpdateData) != -1)
                {
                    btnSave.Visible = false;
                }
                BoundData();
            }

        }


        private void BoundData()
        {
            this.txtMShopName.Text = BLL.SysManage.ConfigSystem.GetValueByCache("WeChat_MShop_Name");
            string MShopLogo = BLL.SysManage.ConfigSystem.GetValueByCache("WeChat_MShop_Logo");
            if (!string.IsNullOrWhiteSpace(MShopLogo))
            {
                this.imgLogo.ImageUrl = MShopLogo;
            }
            this.txtMShopTel.Text = BLL.SysManage.ConfigSystem.GetValueByCache("WeChat_MShop_Phone");
            this.txtMShopQRAd.Text = BLL.SysManage.ConfigSystem.GetValueByCache("WeChat_MShop_QRAd");
            this.txtMShopReply.Text = BLL.SysManage.ConfigSystem.GetValueByCache("WeChat_MShop_Reply");
            this.txtMShopTel.Text = BLL.SysManage.ConfigSystem.GetValueByCache("WeChat_MShop_Phone");

            //是否开启 发票项
            chbInvoiceInfoItem.Checked = BLL.SysManage.ConfigSystem.GetBoolValueByCache("IsOpenInvoicesItem");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.SysManage.ConfigSystem.Modify("WeChat_MShop_Name", Globals.HtmlEncode(this.txtMShopName.Text), "微商城名称", ApplicationKeyType.System);
                string tempFile = string.Format("/"+MvcApplication.UploadFolder+"/Temp/{0}", DateTime.Now.ToString("yyyyMMdd"));
                string ImageFile = "/"+MvcApplication.UploadFolder+"/WebSiteLogo";
                ArrayList imageList = new ArrayList();
                if (!string.IsNullOrWhiteSpace(this.hfs_ICOPath.Value))
                {
                    string imageUrl = string.Format(this.hfs_ICOPath.Value, "");
                    imageList.Add(imageUrl.Replace(tempFile, ""));
                    string logoPath = imageUrl.Replace(tempFile, ImageFile);
                    BLL.SysManage.ConfigSystem.Modify("WeChat_MShop_Logo", logoPath, "微商城Logo", ApplicationKeyType.System);
                }
                BLL.SysManage.ConfigSystem.Modify("WeChat_MShop_Phone", this.txtMShopTel.Text, "微商城号码", ApplicationKeyType.System);
                BLL.SysManage.ConfigSystem.Modify("WeChat_MShop_QRAd", this.txtMShopQRAd.Text, "微信推广营销语", ApplicationKeyType.System);
                BLL.SysManage.ConfigSystem.Modify("WeChat_MShop_Reply", this.txtMShopReply.Text, "微信推广二维码菜单回复", ApplicationKeyType.System);
                BLL.SysManage.ConfigSystem.Modify("IsOpenInvoicesItem", chbInvoiceInfoItem.Checked.ToString(), "是否开启发票项", ApplicationKeyType.System);

                Cache.Remove("ConfigSystemHashList_" + ApplicationKeyType.System);//清除网站设置的缓存文件
                Cache.Remove("ConfigSystemHashList");

                this.btnSave.Enabled = false;
                Common.FileManage.MoveFile(Server.MapPath(tempFile), Server.MapPath(ImageFile), imageList);

                YSWL.Common.MessageBox.ShowSuccessTip(this, Resources.Site.TooltipUpdateOK, "MShopConfig.aspx");
            }
            catch (Exception)
            {
                YSWL.Common.MessageBox.ShowFailTip(this, Resources.Site.TooltipTryAgainLater, "MShopConfig.aspx");
            }
        }



    }
}