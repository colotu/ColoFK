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
* Copyright (c) 2012 YSWL Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
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
using YSWL.Common;
using YSWL.Accounts.Bus;
using YSWL.Web;

namespace  YSWL.Web.Admin.Shop.Sample
{
    public partial class PdfAdd4Sample : PageBaseAdmin
    {
        private int RestrictPdfSize = 10240000;
        private string SavePath = "/Upload/Shop/Files/";
        YSWL.BLL.Shop.Sample.SampleDetail bll = new YSWL.BLL.Shop.Sample.SampleDetail();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!UserPrincipal.HasPermissionID(GetPermidByActID(Act_AddData)))
                {
                    MessageBox.ShowFailTip(this,"您没有此权限");
                    return;
                }
                trRemote.Visible = false;
                BindCategoryData();

            }
        }
        public int Id
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

        private void BindCategoryData()
        {
            YSWL.BLL.Shop.Sample.Sample  sampleBll =new BLL.Shop.Sample.Sample();
            DataSet ds = sampleBll.GetList("");
            if (!DataSetTools.DataSetIsNull(ds))
            {
                this.ddrSampleList.DataSource = ds;
                this.ddrSampleList.DataTextField = "Tiltle";
                this.ddrSampleList.DataValueField = "SampleId";
                this.ddrSampleList.DataBind();
            }
            if (Id > 0)
            {
                this.ddrSampleList.SelectedValue = Id.ToString();
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
		{
            string Title = this.txtTitle.Text.Trim();
            if (Title.Length > 50)
			{
                MessageBox.ShowFailTip(this, "名称不能超过50个字符！");
                return;
			}
            string PDFUrl = "";
            #region PDF地址（包括两种 一种是远程的，一种是本地的）
            if (rdoType.SelectedValue == "1")
            {
                if (txtRemoteUrl.Text.Trim().Length <= 0)
                {
                    Common.MessageBox.ShowFailTip(this, "请填写您远程的文件PDF地址");
                    return;

                }
                PDFUrl = txtRemoteUrl.Text.Trim();

            }
            else
            {

                string imageFileName = uploadPDF.PostedFile.FileName;
                if (!uploadPDF.HasFile)
                {
                    Common.MessageBox.ShowSuccessTip(this, "请上传文件");
                    return;
                }
                int filelength = uploadPDF.PostedFile.ContentLength;
                if (filelength >RestrictPdfSize)
                {
                    Common.MessageBox.ShowSuccessTip(this, "您上传的PDF文件过大，请处理后在新增");
                    return;
                }
                PDFUrl = SavePath + imageFileName;
                uploadPDF.SaveAs(Server.MapPath(PDFUrl));
            }
          

            #endregion

            YSWL.Model.Shop.Sample.SampleDetail model = new YSWL.Model.Shop.Sample.SampleDetail();
            model.Title = Title;
            model.PdfUrl = PDFUrl;
            model.CreatedDate = DateTime.Now;
            model.SampleId = Common.Globals.SafeInt(ddrSampleList.SelectedValue, 0);
            model.Type = 1;
            int ID;
            if ((ID=bll.Add(model))> 0)
            {
                LogHelp.AddUserLog(CurrentUser.UserName, CurrentUser.UserType, "新增电子样本(id=" + ID + ")成功", this);
                MessageBox.ShowSuccessTip(this, Resources.Site.TooltipSaveOK);
                if (((Button) sender).ID == "btnSave")
                {
                    Response.Redirect("SampleList.aspx");
                }
                Response.Redirect("ImageAdd4Sample.aspx");
            }
            else
            {
                LogHelp.AddUserLog(CurrentUser.UserName, CurrentUser.UserType, "新增电子样本(id=" + ID + ")失败", this);
                MessageBox.ShowServerBusyTip(this, Resources.Site.TooltipSaveError);
            }
		}
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
        private bool ImageCut(string imgname, string uploadpath, string SmallImageSize, string BigImageSize,out string SmallImagePath,out string BigImagePath)
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

        protected void rdoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoType.SelectedValue == "0")
            {
                trRemote.Visible = false;
                trUploadPdf.Visible = true;

            }
            else
            {
                trUploadPdf.Visible = false;
                trRemote.Visible = true;
            }

        }

        protected void goback_Click(object sender, EventArgs e)
        {

            Response.Redirect("SampleList.aspx");
        }


    
    }
}
