﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YSWL.MALL.Model.SysManage;

namespace YSWL.MALL.Web.Admin.SNS.Photos
{
    public partial class ImageReGen : PageBaseAdmin
    {
        protected override int Act_PageLoad { get { return 593; } } //SNS_缩略图重新生成页
           YSWL.MALL.BLL.SysManage.TaskQueue taskBll = new BLL.SysManage.TaskQueue();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
             
            }
        }
       
    }
}