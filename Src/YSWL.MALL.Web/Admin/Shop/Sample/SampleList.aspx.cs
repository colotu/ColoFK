﻿/**
* List.cs
*
* 功 能： [N/A]
* 类 名： List.cs
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
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using YSWL.Common;
using YSWL.Web;

namespace  YSWL.Web.Admin.Shop.Sample
{
    public partial class SampleList : PageBaseAdmin
    {
        //int Act_ShowInvalid = -1; //查看失效数据行为

        private YSWL.BLL.Shop.Sample.Sample bll = new YSWL.BLL.Shop.Sample.Sample();
        protected override int Act_PageLoad { get { return 95; } } //社区管理_是否显示样本分类页面

        protected new int Act_DelData = 99;    //社区管理_样本分类_删除样本分类
        protected new int Act_UpdateData = 98;    //社区管理_样本分类_编辑样本分类
        protected new int Act_AddData = 97;    //社区管理_样本分类_新增样本分类
        protected new int Act_DeleteList = 96;    //社区管理_样本分类_批量删除样本分类

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!UserPrincipal.HasPermissionID(GetPermidByActID(Act_DeleteList)) && GetPermidByActID(Act_DeleteList) != -1)
                {
                    liDel.Visible = false;
                    btnDelete.Visible = false;
                }
                if (!UserPrincipal.HasPermissionID(GetPermidByActID(Act_AddData)) && GetPermidByActID(Act_AddData) != -1)
                {
                    AddLi.Visible = false;
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gridView.OnBind();
        }

        #region gridView

        public void BindData()
        {
            #region

            //if (!Context.User.Identity.IsAuthenticated)
            //{
            //    return;
            //}
            //AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name);
            //if (user.HasPermissionID(PermId_Modify))
            //{
            //    gridView.Columns[6].Visible = true;
            //}
            //if (user.HasPermissionID(PermId_Delete))
            //{
            //    gridView.Columns[7].Visible = true;
            //}
            StringBuilder sb=new StringBuilder();
           //if (!UserPrincipal.HasPermissionID(GetPermidByActID(Act_UpdateData)) && GetPermidByActID(Act_UpdateData) != -1)
           // {
           //     gridView.Columns[8].Visible = false;
           // }
           // if (!UserPrincipal.HasPermissionID(GetPermidByActID(Act_DelData)) && GetPermidByActID(Act_DelData) != -1)
           // {
           //     gridView.Columns[9].Visible = false;
           // }
            if (!string.IsNullOrEmpty(txtKeyword.Text))
            {
                sb.Append(" Tiltle like '%" + txtKeyword.Text + "%'");
            }

            #endregion gridView

            gridView.DataSetSource = bll.GetList(sb.ToString());
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            gridView.OnBind();
        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("style", "background:#FFF");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex % 2 == 0)
                {
                    e.Row.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#F4F4F4");
                }
                else
                {
                    e.Row.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFFF");
                }
            }
        }

        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = (int)gridView.DataKeys[e.RowIndex].Value;
            if (bll.Delete(ID))
            {
                MessageBox.ShowSuccessTip(this, Resources.Site.TooltipDelOK);
            }
            gridView.OnBind();
        }

        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "IsMenu")
            //{
            //    if (e.CommandArgument != null)
            //    {
            //        int Id = 0;
            //        string[] Args = e.CommandArgument.ToString().Split(new char[] { ',' });
            //        Id = Common.Globals.SafeInt(Args[0], 0);
            //        bool IsMenu = Common.Globals.SafeBool(Args[1], false);

            //        if (IsMenu)
            //        {
            //            bll.UpdateIsMenu(0, Id.ToString());
            //            gridView.OnBind();
            //        }
            //        else
            //        {
            //            bll.UpdateIsMenu(1, Id.ToString());
            //            gridView.OnBind();
            //        }
            //    }
            //}
            //if (e.CommandName == "MenuIsShow")
            //{
            //    if (e.CommandArgument != null)
            //    {
            //        int Id = 0;
            //        string[] Args = e.CommandArgument.ToString().Split(new char[] { ',' });
            //        Id = Common.Globals.SafeInt(Args[0], 0);
            //        bool MenuIsShow = Common.Globals.SafeBool(Args[1], false);

            //        if (MenuIsShow)
            //        {
            //            bll.UpdateMenuIsShow(0, Id.ToString());
            //            gridView.OnBind();
            //        }
            //        else
            //        {
            //            bll.UpdateMenuIsShow(1, Id.ToString());
            //            gridView.OnBind();
            //        }
            //    }
            //}
            //if (e.CommandName == "Status")
            //{
            //    if (e.CommandArgument != null)
            //    {
            //        int Id = 0;
            //        string[] Args = e.CommandArgument.ToString().Split(new char[] { ',' });
            //        Id = Common.Globals.SafeInt(Args[0], 0);
            //        int Status = Common.Globals.SafeInt(Args[1], 0);

            //        if (Status == 1)
            //        {
            //            bll.UpdateStatus(0, Id.ToString());
            //            gridView.OnBind();
            //        }
            //        else
            //        {
            //            bll.UpdateStatus(1, Id.ToString());
            //            gridView.OnBind();
            //        }
            //    }
            //}
        }

        private string GetSelIDlist()
        {
            string idlist = "";
            bool BxsChkd = false;
            for (int i = 0; i < gridView.Rows.Count; i++)
            {
                CheckBox ChkBxItem = (CheckBox)gridView.Rows[i].FindControl(gridView.CheckBoxID);
                if (ChkBxItem != null && ChkBxItem.Checked)
                {
                    BxsChkd = true;

                    //#warning 代码生成警告：请检查确认Cells的列索引是否正确
                    if (gridView.DataKeys[i].Value != null)
                    {
                        //idlist += gridView.Rows[i].Cells[1].Text + ",";
                        idlist += gridView.DataKeys[i].Value.ToString() + ",";
                    }
                }
            }
            if (BxsChkd)
            {
                idlist = idlist.Substring(0, idlist.LastIndexOf(","));
            }
            return idlist;
        }

        #endregion


        public string GetStatus(object target)
        {
            //状态 0：草稿 1：已发布
            string str = string.Empty;
            if (!StringPlus.IsNullOrEmpty(target))
            {
                switch (Globals.SafeInt(target.ToString(), -1))
                {
                    case 0:
                        str = "草稿";
                        break;

                    case 1:
                        str = "已发布";
                        break;
                    default:
                        break;
                }
            }
            return str;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string idlist = GetSelIDlist();
            if (idlist.Trim().Length == 0) return;
            if (bll.DeleteList(idlist))
            {
                LogHelp.AddUserLog(CurrentUser.UserName, CurrentUser.UserType, "批量删除样本(id=" + idlist + ")成功", this);
                MessageBox.ShowSuccessTip(this, Resources.Site.TooltipDelOK);
            }
            else
            {
                LogHelp.AddUserLog(CurrentUser.UserName, CurrentUser.UserType, "批量删除样本(id=" + idlist + ")失败", this);
            }
            gridView.OnBind();
        }
    }
}