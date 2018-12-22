﻿/**
* ProductUploadImgHandler.cs
*
* 功 能： 产品上传图片
* 类 名： ProductUploadImgHandler
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/7/1 19:52:00    Ben    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System.Drawing;
using System.Web;
using YSWL.Common;
using YSWL.MALL.Model.Settings;

namespace YSWL.MALL.Web.Ajax_Handle
{
    public class ProductUploadImgHandler : UploadImageHandlerBase
    {
        private string filePath = "/UploadFolder/Images/ProductImages/";

        protected ProductUploadImgHandler()
        {
            base.makeThumbnailMode = MakeThumbnailMode.Cut;
        }

        protected override Size GetThumbImageSize()
        {
            return YSWL.Common.StringPlus.SplitToSize(
                BLL.SysManage.ConfigSystem.GetValueByCache(SettingConstant.PRODUCT_NORMAL_SIZE_KEY),
                '|', SettingConstant.ProductThumbSize.Width, SettingConstant.ProductThumbSize.Height);
        }

        protected override Size GetNormalImageSize()
        {
            return YSWL.Common.StringPlus.SplitToSize(
                BLL.SysManage.ConfigSystem.GetValueByCache(SettingConstant.PRODUCT_NORMAL_SIZE_KEY),
                '|', SettingConstant.ProductNormalSize.Width, SettingConstant.ProductNormalSize.Height);
        }

        protected override string GetUploadPath(HttpContext context)
        {
            return HttpContext.Current.Server.MapPath(filePath) + "\\";
        }

        protected override void ProcessSub(HttpContext context, string fileName)
        {
            context.Response.Write("1|" + filePath + "{0}" + fileName);
        }
    }
}