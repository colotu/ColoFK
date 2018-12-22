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
using System.Collections;
using YSWL.Common;

namespace YSWL.MALL.Web.Admin.Shop.ShopCategories
{
    public partial class Add : PageBaseAdmin
    {
        protected override int Act_PageLoad { get { return 528; } } //Shop_商品分类管理_新增页
        private YSWL.MALL.BLL.Shop.Products.CategoryInfo bll = new YSWL.MALL.BLL.Shop.Products.CategoryInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserPrincipal.HasPermissionID(GetPermidByActID(Act_PageLoad)))
            {
                MessageBox.ShowAndBack(this, "您没有权限");
                return;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            btnCancle.Enabled = false;
            btnSave.Enabled = false;
            if (string.IsNullOrWhiteSpace(this.txtName.Text.Trim()))
            {
                btnCancle.Enabled = true;
                btnSave.Enabled = true;
                MessageBox.ShowFailTip(this, "分类名称不能为空，在1至60个字符之间");
                return;
            }
          
            this.Hidden_SelectName.Value = this.txtCategoryText.Text;
            Model.Shop.Products.CategoryInfo model = new Model.Shop.Products.CategoryInfo();
            model.Name = this.txtName.Text;
            model.Meta_Description = this.txtMeta_Description.Text;
            model.Meta_Keywords = this.txtMeta_Keywords.Text;
            model.Description = this.txtDescription.Text;
            model.Meta_Title = this.txtMeta_Title.Text;
            model.Status = chkStatus.Checked;
            if (!string.IsNullOrWhiteSpace(this.Hidden_SelectValue.Value))
            {
                model.ParentCategoryId = Globals.SafeInt(this.Hidden_SelectValue.Value, 0);
            }
            else
            {
                model.ParentCategoryId = 0;
            }
            if (bll.IsExisted(model.ParentCategoryId, model.Name))
            {
                btnCancle.Enabled = true;
                btnSave.Enabled = true;
                MessageBox.ShowFailTip(this, "该分类下已存在同名分类");
                return;
            }
            //待上传的图片名称
            string tempFile = string.Format("/"+MvcApplication.UploadFolder+"/Temp/{0}", DateTime.Now.ToString("yyyyMMdd"));

            string ImageFile = "/"+MvcApplication.UploadFolder+"/Shop/Images/Categories";
            ArrayList imageList = new ArrayList();
            if (!string.IsNullOrWhiteSpace(this.HiddenField_ICOPath.Value))
            {
                string imageUrl = string.Format(this.HiddenField_ICOPath.Value, "");
                imageList.Add(imageUrl.Replace(tempFile, ""));
                model.ImageUrl = imageUrl.Replace(tempFile, ImageFile);
            }
            else
            {
                model.ImageUrl = "/Content/themes/base/Shop/images/none.png";
            }
            model.AssociatedProductType = -1;
            model.RewriteName = this.txtRewriteName.Text;
            model.SKUPrefix = this.txtSKUPrefix.Text;
            model.HasChildren = false;
            if (bll.CreateCategory(model))
            {
                this.btnSave.Enabled = false;
                this.btnCancle.Enabled = false;

                if (!string.IsNullOrWhiteSpace(this.HiddenField_ICOPath.Value))
                {
                    //将图片从临时文件夹移动到正式的文件夹下
                    FileManage.MoveFile(Server.MapPath(tempFile), Server.MapPath(ImageFile), imageList);
                }
                if (chkIsAdd.Checked)
                {
                    btnCancle.Enabled = true;
                    btnSave.Enabled = true;
                    //清空缓存
                    Common.DataCache.DeleteCache("GetAllCateList-CateList");
                    Common.DataCache.DeleteCache("GetAvailableCateList-CateList");
                    MessageBox.ShowSuccessTip(this, "新增成功");
                    this.txtCategoryText.Text = this.Hidden_SelectName.Value;
                    this.HiddenField_ICOPath.Value = "";
                    this.txtDescription.Text = this.txtMeta_Description.Text = this.txtMeta_Title.Text = "";
                    this.txtName.Text = "";
                    this.txtSKUPrefix.Text = "";
                    this.txtRewriteName.Text = "";
                    this.txtMeta_Keywords.Text = "";
                }
                else
                {
                    //清空缓存
                    Common.DataCache.DeleteCache("GetAllCateList-CateList");
                    Common.DataCache.DeleteCache("GetAvailableCateList-CateList");
                    MessageBox.ShowSuccessTip(this, "新增成功!","list.aspx");
                }
            }
            else
            {
                this.btnSave.Enabled = false;
                this.btnCancle.Enabled = false;
                MessageBox.ShowSuccessTip(this, "新增失败！");
            }
        }

        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}