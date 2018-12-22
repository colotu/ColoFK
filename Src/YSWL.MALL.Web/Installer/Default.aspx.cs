/**
* Default.cs
*
* 功 能： 安装协议
* 类 名： Default
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/7/23 16:54:55  Administrator    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;

namespace YSWL.Web.Installer
{
    public partial class Default : System.Web.UI.Page
    {
        public string strTitle;
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (YSWL.Components.MvcApplication.ProductInfo)
            {
                case "YS56 SNS":
                    strTitle = "云商分享社区系统";
                    break;
                case "YS56 Mall":
                    strTitle = "云商商城系统";
                    break;
                case "YS56 V":
                    strTitle = "云商微信系统";
                    break;
                default:
                    strTitle = "云商.NET系统框架";
                    break;
            }

            if (YSWL.Components.MvcApplication.IsInstall)
            {
                Response.Redirect("/", true);
                return;
            }
        }

    }
}