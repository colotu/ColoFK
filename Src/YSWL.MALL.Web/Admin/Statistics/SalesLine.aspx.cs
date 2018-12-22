﻿/**
* SalesLine.cs
*
* 功 能： [N/A]
* 类 名： SalesLine.cs
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  
*
* Copyright (c) 2013 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YSWL.Common;
using YSWL.OAuth.Json;
using System.Data;

namespace YSWL.MALL.Web.Admin.Statistics
{
    public partial class SalesLine : PageBaseAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                if (!IsPostBack)
                {
                    this.txtTo.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    this.txtFrom.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM-dd");
                }
            }
        }

        #region gridView

        protected void btnReStatistic_Click(object sender, EventArgs e)
        {
            gridView.OnBind();
        }

        public void BindData()
        {

            DateTime startDate = Common.Globals.SafeDateTime(this.txtFrom.Text, DateTime.Now.AddDays(-6)).Date;
            DateTime endDate = Common.Globals.SafeDateTime(this.txtTo.Text, DateTime.Now).Date.AddDays(1).AddSeconds(-1);

            //Reset Time
            startDate = startDate.Date;
            endDate = endDate.Date.AddDays(1).AddSeconds(-1);
            Model.Shop.Order.StatisticMode mode = (Model.Shop.Order.StatisticMode)Globals.SafeInt(rdoMode.SelectedValue, 0);
            DataSet ds = BLL.Shop.Order.OrderManage.StatSales(mode, startDate, endDate);

            BindJson(ds, mode);
            this.gridView.DataSetSource = ds;
        }


        private void BindJson(DataSet ds, Model.Shop.Order.StatisticMode mode)
        {
            this.hfCategory.Value = "";
            this.hfDayCount.Value = "";
            this.hfPrice.Value = "";
            
            string  format;
            switch (mode)
            {
                case Model.Shop.Order.StatisticMode.Day:
                    format = "yyyy-MM-dd";
                    break;
                case Model.Shop.Order.StatisticMode.Month:
                    format = "yyyy-MM";
                    break;
                case Model.Shop.Order.StatisticMode.Year:
                    format = "yyyy";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("mode");
            }

            List<YSWL.MALL.ViewModel.Order.OrderPriceCount> orderList = new List<YSWL.MALL.ViewModel.Order.OrderPriceCount>();
            this.hfCategory.Value = "";
            this.hfDayCount.Value = "";
            this.hfPrice.Value = "";
            //把dataset转换成list
            YSWL.MALL.ViewModel.Order.OrderPriceCount model = null;
            DataTable dt = ds.Tables[0];
            dt.Columns.Add(new DataColumn("DateFormat", typeof(string)));
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["GeneratedDate"] == null)
                {
                    continue;
                }
                model = new ViewModel.Order.OrderPriceCount();
                model.DateStr = Convert.ToDateTime(dr["GeneratedDate"].ToString()).ToString(format);
                model.Count = Common.Globals.SafeInt(dr["ToalQuantity"], 0);
                model.Price = Common.Globals.SafeDecimal(dr["ToalPrice"], 0);
                orderList.Add(model);
                dr["DateFormat"] = model.DateStr;
            }

            this.hfCategory.Value = String.Join(",", orderList.Select(c => c.DateStr));
            this.hfDayCount.Value = String.Join(",", orderList.Select(c => c.Count));
            this.hfPrice.Value = String.Join(",", orderList.Select(c => c.Price));
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

        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        #endregion

    }
}
