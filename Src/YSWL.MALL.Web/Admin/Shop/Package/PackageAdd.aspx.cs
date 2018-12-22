﻿/**
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
using YSWL.MALL.BLL.Shop.Package;
using YSWL.Common;
using YSWL.Accounts.Bus;
using YSWL.MALL.Web;

namespace YSWL.MALL.Web.Admin.Shop.Package
{
    public partial class PackageAdd : PageBaseAdmin
    {
        protected override int Act_PageLoad { get { return 452; } } //Shop_包装管理_新增页
        YSWL.MALL.BLL.Shop.Package.Package bll=new BLL.Shop.Package.Package();
        private int RestrictPhotoSize = 10240000;
        private string SavePath = "/"+MvcApplication.UploadFolder+"/Shop/Files/";
        private string BigImageSize = "800X800";
        private string SmallImageSize = "400X400";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategoryData();
                if (!UserPrincipal.HasPermissionID(GetPermidByActID(Act_AddData)))
                {
                    MessageBox.ShowFailTip(this,"您没有此权限");
                    return;
                }
               
            }
        }

        private void BindCategoryData()
        {
            YSWL.MALL.BLL.Shop.Package.PackageCategory catebll = new PackageCategory();
            DataSet ds = catebll.GetList("");
            if (!DataSetTools.DataSetIsNull(ds))
            {
                this.ddlCategory.DataSource = ds;
                this.ddlCategory.DataTextField = "Name";
                this.ddlCategory.DataValueField = "CategoryId";
                this.ddlCategory.DataBind();
            }
        }

        public void btnSave_Click(object sender, EventArgs e)
		{

            string FileName = uploadPhoto.PostedFile.FileName;
            if (!uploadPhoto.HasFile)
            {
                Common.MessageBox.ShowSuccessTip(this, "请上传文件");
                return;
            }
            int filelength = uploadPhoto.PostedFile.ContentLength;
            if (filelength > RestrictPhotoSize)
            {

                Common.MessageBox.ShowSuccessTip(this, "您上传的图片过大，请上传较小的文件");
                return;
            }

            string PhotoSavepath = Server.MapPath(SavePath) + FileName;
            uploadPhoto.PostedFile.SaveAs(PhotoSavepath);
            string ThumbPhotoUrl = "";
            string NormalPhotoUrl = "";
            if (
               !ImageCut(FileName, SavePath, SmallImageSize, BigImageSize, out ThumbPhotoUrl,
                         out NormalPhotoUrl))
            {
                Common.MessageBox.ShowSuccessTip(this, "出现异常，请重试");
                return;
            }
            string Name = this.txtName.Text.Trim();
            if (Name.Length == 0)
			{
                MessageBox.ShowServerBusyTip(this, "包装的名称不能为空！");
                return;
			}
            string Remark=this.txtRemark.Text.Trim();
            if (Remark.Length > 200)
            {
                MessageBox.ShowServerBusyTip(this, "备注不能超过200个字符！");
                return;
            }

            string Description = this.txtDescription.Text.Trim();
            if (Description.Length > 200)
            {
                MessageBox.ShowServerBusyTip(this, "描述不能超过200个字符！");
                return;
            }

            YSWL.MALL.Model.Shop.Package.Package model = new YSWL.MALL.Model.Shop.Package.Package();
			model.Name=Name;
            model.Remark = Remark;
            model.PhotoUrl = SavePath + FileName;
            model.Description = Description;
            model.ThumbPhotoUrl = ThumbPhotoUrl;
            model.NormalPhotoUrl = NormalPhotoUrl;
            model.CategoryId = Common.Globals.SafeInt(ddlCategory.SelectedValue, 0);
            int ID;
            if ((ID=bll.Add(model))> 0)
            {
                LogHelp.AddUserLog(CurrentUser.UserName, CurrentUser.UserType, "新增包装(id=" + ID + ")成功", this);
                MessageBox.ShowSuccessTip(this, Resources.Site.TooltipSaveOK, "PackageList.aspx");
                Response.Redirect("PackageList.aspx");
            }
            else
            {
                LogHelp.AddUserLog(CurrentUser.UserName, CurrentUser.UserType, "新增包装(id=" + ID + ")失败", this);
                MessageBox.ShowServerBusyTip(this, Resources.Site.TooltipSaveError);
            }

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("PackageList.aspx");
        }

        #region 图片裁剪相关

        /// <summary>
        /// 图片的裁剪
        /// </summary>
        /// <param name="imgname">图片的名字</param>
        /// <param name="uploadpath">存放的位置</param>
        /// <param name="SmallImageSize">小图的大小 长X宽的形式</param>
        /// <param name="BigImageSize">大图的大小 长X宽的形式</param>
        /// <param name="SmallImagePath">out 小图的保存的位置</param>
        /// <param name="BigImagePath">out 大图保存的位置</param>
        /// <returns></returns>
        private bool ImageCut(string imgname, string uploadpath, string SmallImageSize, string BigImageSize, out string SmallImagePath, out string BigImagePath)
        {
            try
            {

                //生成小图
                string SthumbImage = "S_" + imgname;
                string SthumbImagePath = HttpContext.Current.Server.MapPath(uploadpath + SthumbImage);
                int SWindthInt = 400;
                int SHeightInt = 400;
                if (SmallImageSize != null && SmallImageSize.Split('X').Length > 1)
                {
                    string[] Size = SmallImageSize.Split('X');
                    SWindthInt = Common.Globals.SafeInt(Size[0], 400);
                    SHeightInt = Common.Globals.SafeInt(Size[1], 400);

                }
                //TODO: 应使用Auto模式, 全部对应, TO:齐慧强  BEN ADD2012-12-22
                ImageTools.MakeThumbnail(HttpContext.Current.Server.MapPath(uploadpath + imgname), SthumbImagePath, SWindthInt, SHeightInt, MakeThumbnailMode.W);

                ///生成大图
                string BthumbImage = "B_" + imgname;
                string BthumbImagePath = HttpContext.Current.Server.MapPath(uploadpath + BthumbImage);

                int BWindthInt = 800;
                int BHeightInt = 800;
                if (BigImageSize != null && BigImageSize.Split('X').Length > 1)
                {
                    string[] Size = BigImageSize.Split('X');
                    BWindthInt = Common.Globals.SafeInt(Size[0], 800);
                    BHeightInt = Common.Globals.SafeInt(Size[1], 800);

                }
                ImageTools.MakeThumbnail(HttpContext.Current.Server.MapPath(uploadpath + imgname), BthumbImagePath, BWindthInt, BHeightInt, MakeThumbnailMode.W);
                SmallImagePath = uploadpath + SthumbImage;
                BigImagePath = uploadpath + BthumbImage;
                return true;

            }
            catch (Exception)
            {
                SmallImagePath = "";
                BigImagePath = "";
                return false;
            }


        } 
        #endregion

    }
}
