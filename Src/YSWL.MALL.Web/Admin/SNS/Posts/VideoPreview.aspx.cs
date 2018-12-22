﻿/**
* VideoPreview.cs
*
* 功 能： 视频预览功能
* 类 名： VideoPreview
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/5/27 14:37:51  蒋海滨    初版
* V0.02  2012年6月8日 18:45:39  孙鹏    提示信息修改、using引用移除
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using YSWL.Common;

namespace YSWL.MALL.Web.Admin.SNS.PostsVideo
{
    public partial class VideoPreview : PageBaseAdmin
    {
        public string localVideoUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                ShowInfo();
            }
        }

        public int PostID
        {
            get
            {
                int id = 0;
                string strid = Request.Params["id"];
                if (!string.IsNullOrWhiteSpace(strid) && PageValidate.IsNumber(strid))
                {
                    id = int.Parse(strid);
                }
                return id;
            }
        }

        private void ShowInfo()
        {
            YSWL.MALL.BLL.SNS.Posts bll = new YSWL.MALL.BLL.SNS.Posts();
            YSWL.MALL.Model.SNS.Posts model = bll.GetModel(PostID);
            if (null != model)
            {
                localVideoUrl = model.VideoUrl;
            }
        }
    }
}