/**
* List.cs
*
* 功 能： N/A
* 类 名： List
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01						   N/A    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

using System;
using System.Collections;
using System.Web.UI;
using YSWL.Common;

namespace YSWL.MALL.Web.Admin.SNS.PostSetting
{
    public partial class Setting : PageBaseAdmin
    {
        private YSWL.MALL.BLL.SNS.Posts bll = new YSWL.MALL.BLL.SNS.Posts();
        protected int type = -1;
        private YSWL.MALL.Model.SNS.PostsSet model = new Model.SNS.PostsSet();

        protected override int Act_PageLoad { get { return 114; } } //运营管理_是否显示分享设置页面

        protected new int Act_UpdateData = 115;    //运营管理_分享设置_编辑分享设置信息

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //是否有编辑信息的权限
                if (!UserPrincipal.HasPermissionID(GetPermidByActID(Act_UpdateData)) && GetPermidByActID(Act_UpdateData) != -1)
                {
                    btnSave.Visible = false;
                }
                YSWL.MALL.Model.SNS.PostsSet model = YSWL.MALL.BLL.SNS.ConfigSystem.GetPostSetByCache();
                cbx_Narmal_Audio.Checked = model._Narmal_Audio;
                cbx_Narmal_Pricture.Checked = model._Narmal_Pricture;
                cbx_Narmal_Video.Checked = model._Narmal_Video;
                cbx_Picture.Checked = model._Picture;
                cbx_Product.Checked = model._Product;
                chk_CustomPro.Checked = model.CustomProduct;
                cbx_PostType_EachOther.Checked = model._PostType_EachOther;
                cbx_PostType_Fellow.Checked = model._PostType_Fellow;
                cbx_PostType_ReferMe.Checked = model._PostType_ReferMe;
                cbx_PostType_User.Checked = model._PostType_User;
                cbx_PostType_All.Checked = model._PostType_All;
                chk_Blog.Checked = model._Blog;
                chk_TaoProduct.Checked = model.TaoProduct;

                ///下面是默认的审核

                #region 审核状态的初始化

                string check_word = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("chk_check_word");
                chk_check_audio.Checked = check_word != null && Common.Globals.SafeInt(check_word, 0) == 1;

                string check_audio = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("SNS_check_audio");
                chk_check_audio.Checked = check_audio != null && Common.Globals.SafeInt(check_audio, 0) == 1;

                string check_video = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("SNS_check_video");
                chk_check_video.Checked = check_video != null && Common.Globals.SafeInt(check_video, 0) == 1;

                string check_photo = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("SNS_check_photo");
                chk_check_photo.Checked = check_photo != null && Common.Globals.SafeInt(check_photo, 0) == 1;

                string check_picture = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("SNS_check_picture");
                cbx_check_picture.Checked = check_picture != null && Common.Globals.SafeInt(check_picture, 0) == 1;

                string check_product = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("SNS_check_product");
                cbx_check_product.Checked = check_product != null && Common.Globals.SafeInt(check_product, 0) == 1;


                #endregion 审核状态的初始化

                chk_OpenComment.Checked = YSWL.MALL.BLL.SysManage.ConfigSystem.GetBoolValueByCache("SNS_Open_Comment");
                chk_OpenPost.Checked = YSWL.MALL.BLL.SysManage.ConfigSystem.GetBoolValueByCache("SNS_Open_Post");

                txtBanTopicTime.Text = BLL.SysManage.ConfigSystem.GetValueByCache("SNS_BAN_TOPIC_TIME");
                txtBanTopicCount.Text = BLL.SysManage.ConfigSystem.GetValueByCache("SNS_BAN_TOPIC_COUNT");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            model._Narmal_Audio = cbx_Narmal_Audio.Checked;
            model._Narmal_Pricture = cbx_Narmal_Pricture.Checked;
            model._Narmal_Video = cbx_Narmal_Video.Checked;
            model._Picture = cbx_Picture.Checked;
            model._Product = cbx_Product.Checked;
            model._PostType_EachOther = cbx_PostType_EachOther.Checked;
            model._PostType_Fellow = cbx_PostType_Fellow.Checked;
            model._PostType_ReferMe = cbx_PostType_ReferMe.Checked;
            model._PostType_User = cbx_PostType_User.Checked;
            model._PostType_All = cbx_PostType_All.Checked;
            model._Blog = chk_Blog.Checked;
            model.CustomProduct = chk_CustomPro.Checked;
            model.TaoProduct = chk_TaoProduct.Checked;

            #region 审核状态的处理

            UpdateKey("SNS_check_word", chk_check_word.Checked == true ? "1" : "0", "上传文字的审核状态");


            UpdateKey("SNS_check_audio", chk_check_audio.Checked == true ? "1" : "0", "上传音频的审核状态");


            if (YSWL.MALL.BLL.SysManage.ConfigSystem.Exists("SNS_check_video"))
            {
                YSWL.MALL.BLL.SysManage.ConfigSystem.Update("SNS_check_video", chk_check_video.Checked == true ? "1" : "0", Model.SysManage.ApplicationKeyType.SNS);
            }
            else
            {
                YSWL.MALL.BLL.SysManage.ConfigSystem.Add("SNS_check_video", chk_check_video.Checked == true ? "1" : "0", "上传视频的审核状态", Model.SysManage.ApplicationKeyType.SNS);
            }


            if (YSWL.MALL.BLL.SysManage.ConfigSystem.Exists("SNS_check_photo"))
            {
                YSWL.MALL.BLL.SysManage.ConfigSystem.Update("SNS_check_photo", chk_check_photo.Checked == true ? "1" : "0", Model.SysManage.ApplicationKeyType.SNS);
                YSWL.Common.DataCache.DeleteCache("SNS_check_photo");
            }
            else
            {
                YSWL.MALL.BLL.SysManage.ConfigSystem.Add("SNS_check_photo", chk_check_photo.Checked == true ? "1" : "0", "上传图片的审核状态", Model.SysManage.ApplicationKeyType.SNS);
            }


            if (YSWL.MALL.BLL.SysManage.ConfigSystem.Exists("SNS_check_picture"))
            {
                YSWL.MALL.BLL.SysManage.ConfigSystem.Update("SNS_check_picture", cbx_check_picture.Checked == true ? "1" : "0", Model.SysManage.ApplicationKeyType.SNS);
                YSWL.Common.DataCache.DeleteCache("SNS_check_picture");
            }
            else
            {
                YSWL.MALL.BLL.SysManage.ConfigSystem.Add("SNS_check_picture", cbx_check_picture.Checked == true ? "1" : "0", "分享照片的审核状态", Model.SysManage.ApplicationKeyType.SNS);
            }

            if (YSWL.MALL.BLL.SysManage.ConfigSystem.Exists("SNS_check_product"))
            {
                YSWL.MALL.BLL.SysManage.ConfigSystem.Update("SNS_check_product", cbx_check_product.Checked == true ? "1" : "0", Model.SysManage.ApplicationKeyType.SNS);
                YSWL.Common.DataCache.DeleteCache("SNS_check_product");
            }
            else
            {
                YSWL.MALL.BLL.SysManage.ConfigSystem.Add("SNS_check_product", cbx_check_product.Checked == true ? "1" : "0", "分享照片的审核状态", Model.SysManage.ApplicationKeyType.SNS);
            }

            #endregion 审核状态的处理

            UpdateKey("SNS_Open_Comment", chk_OpenComment.Checked.ToString(), "是否启用社区的评论功能");


            UpdateKey("SNS_Open_Post", chk_OpenPost.Checked.ToString(), "是否启用社区的发表动态功能");


            UpdateKey("SNS_BAN_TOPIC_TIME", txtBanTopicTime.Text, "SNS连续发帖时长(分钟)");
            BLL.SysManage.ConfigSystem.ClearCacheByKey("SNS_BAN_TOPIC_TIME");

            UpdateKey("SNS_BAN_TOPIC_COUNT", txtBanTopicCount.Text, "SNS连续发帖禁用数");
            BLL.SysManage.ConfigSystem.ClearCacheByKey("SNS_BAN_TOPIC_COUNT");

            YSWL.MALL.BLL.SNS.ConfigSystem.UpdatePostSet(model);
            LogHelp.AddUserLog(CurrentUser.UserName, CurrentUser.UserType, "全局更新动态默认审核状态成功", this);
            MessageBox.ShowSuccessTip(this, "保存成功");
        }

        public bool UpdateKey(string keyName, string value, string desc)
        {
            return BLL.SysManage.ConfigSystem.Modify(keyName, value, desc, Model.SysManage.ApplicationKeyType.SNS);
        }
    }
}