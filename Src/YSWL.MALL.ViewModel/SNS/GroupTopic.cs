/**
* Photo.cs
*
* 功 能： [N/A]
* 类 名： Photo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/9/24 16:23:03  Ben    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace YSWL.MALL.ViewModel.SNS
{
    public class GroupTopicsEx
    {
        private YSWL.MALL.Model.SNS.GroupTopics groupTopics;
        private string support;
        public YSWL.MALL.Model.SNS.GroupTopics GroupTopic
        {
            get { return groupTopics; }
            set { groupTopics = value; }
        }
        public string Support
        {
            get { return support; }
            set { support = value; }
        }
    }
}
