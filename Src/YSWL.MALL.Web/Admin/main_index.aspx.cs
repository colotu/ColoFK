/**
* main_index.cs
*
* 功 能： 管理员后台
* 类 名： main_index
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/5/24 15:21:18  Rock    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSWL.MALL.Web.Admin
{
    public partial class main_index : PageBaseAdmin
    {
        public string CurrentUserName = string.Empty;
        public string GetDateTime = string.Empty;

        //private BLL.Members.UsersExp uBll = new BLL.Members.UsersExp();
        //private Model.Members.UsersExpModel uModel = new Model.Members.UsersExpModel();
        private YSWL.MALL.BLL.Shop.Order.Orders oBll = new BLL.Shop.Order.Orders();
        private YSWL.MALL.BLL.Shop.Products.ProductInfo pBll = new BLL.Shop.Products.ProductInfo();
        DateTime today = System.DateTime.Now.Date;//一天开始

        DateTime  now = System.DateTime.Now;
        DateTime weekday = System.DateTime.Now.AddDays(-7);
        DateTime monday = System.DateTime.Now.AddDays(1 - System.DateTime.Now.Day);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet dtDay= oBll.GetOrderCountAmount(today, now);
                DataSet dtWeek= oBll.GetOrderCountAmount(weekday, now);
                DataSet dtMon = oBll.GetOrderCountAmount(monday, now);
                this.lblOrderToday.Text = Common.Globals.SafeString(dtDay.Tables[0].Rows[0]["OrderCount"], "0");
                this.lblOrderWeek.Text = Common.Globals.SafeString(dtWeek.Tables[0].Rows[0]["OrderCount"], "0");
                this.lblOrderMon.Text = Common.Globals.SafeString(dtMon.Tables[0].Rows[0]["OrderCount"], "0");

                //this.lblSaleToday.Text = Common.Globals.SafeDecimal(dtDay.Tables[0].Rows[0]["TotalAmount"],0).ToString("f");
                //if (string.IsNullOrWhiteSpace(this.lblSaleToday.Text))
                //{
                //    this.lblSaleToday.Text = "0.00";
                //}

                this.lblSaleWeek.Text = Common.Globals.SafeDecimal(dtWeek.Tables[0].Rows[0]["TotalAmount"],0).ToString("f");
                if (string.IsNullOrWhiteSpace(this.lblSaleWeek.Text))
                {
                    this.lblSaleWeek.Text = "0.00";
                }

                this.lblSaleMon.Text = Common.Globals.SafeDecimal(dtMon.Tables[0].Rows[0]["TotalAmount"],0).ToString("f");
                if (string.IsNullOrWhiteSpace(this.lblSaleWeek.Text))
                {
                    this.lblSaleWeek.Text = "0.00";
                }
                


                //待付款 待发货,待收货
                int id = CurrentUser.UserID;
                this.lblUnPayOrder.Text = Common.Globals.SafeString(oBll.GetUnPaidCounts(id), "0");
                this.lblUnfilledOrder.Text = Common.Globals.SafeString(oBll.GetUnShippingCounts(), "0");
                this.lblShippedOrder.Text = Common.Globals.SafeString(oBll.GetUnReceipt(), "0");
                //上架 下架
                this.lblItemUpshelf.Text = Common.Globals.SafeString(pBll.GetRecordCount(1), "0");
                this.lblItemDownshelf.Text = Common.Globals.SafeString(pBll.GetRecordCount(0), "0");
                
                List<ViewModel.Order.OrderPriceCount> model = oBll.StatOrderAmount(weekday, now);
                if (model != null)
                {
                    BindJson(model);
                }
              

                DataSet Topds= oBll.StatBuyerOrderCountAmount(10, weekday, now);
                ShowTop(Topds);

            }
        }

        private void BindJson(List<ViewModel.Order.OrderPriceCount> model)
        {
            this.createdDate.Value = "";
            this.amount.Value = "";



            //List<YSWL.MALL.ViewModel.OMS.OrderStat> feeList = new List<ViewModel.OMS.OrderStat>();
            ////把dataset转换成list
            //YSWL.MALL.ViewModel.OMS.OrderStat model = null;
            //DataTable dt = ds.Tables[0];
            //foreach (DataRow dr in dt.Rows)
            //{
            //    model = new YSWL.MALL.ViewModel.OMS.OrderStat();
            //    model.Amount = YSWL.Common.Globals.SafeDecimal(dr["Total"], 0);
            //    model.CreatedDate = dr["Date"].ToString();
            //    feeList.Add(model);
            //}

            ViewModel.Order.OrderPriceCount feeList = null;
            for (int i = -6; i < 1; i++)
            {
                string dateStr = DateTime.Now.AddDays(i).ToString("yyyy/MM/dd");
                if (!model.Exists(c => c.DateStr == dateStr))
                {
                    feeList = new ViewModel.Order.OrderPriceCount();
                    feeList.DateStr = dateStr;
                    feeList.Price = 0;
                    model.Add(feeList);
                }

            }
            
            model = model.OrderBy(c => c.DateStr).ToList();

            this.createdDate.Value = String.Join(",", model.Select(c => c.DateStr));
            this.amount.Value = String.Join(",", model.Select(c => c.Price));
        }

        private void ShowTop(DataSet ds)
        {

            StringBuilder jsonsb = new StringBuilder();
            
            //jsonsb.Append("{\"\":[");
            jsonsb.Append("[");
            YSWL.Json.JsonObject jsons = new Json.JsonObject();
            DataTable dt = ds.Tables[0];
            foreach(DataRow dr in dt.Rows)
            {
                YSWL.Json.JsonObject json = new Json.JsonObject();
                int userId = Convert.ToInt32(dr["BuyerID"]);
                string TotalAmount = Convert.ToInt32(dr["TotalAmount"]).ToString("f");
                string orderCount = dr["orderCount"].ToString();
                string BuyerName = dr["BuyerName"].ToString();
                string GetUnPaidAmount= oBll.GetUnPaidAmount(userId).ToString("f");
                string GetPaidAmount= oBll.GetPaidAmount(userId).ToString("f");
                jsonsb.Append("{");
                jsonsb.AppendFormat("\"TotalAmount\":\"{0}\",\"orderCount\":\"{1}\",\"BuyerName\":\"{2}\",\"GetUnPaidAmount\":\"{3}\",\"GetPaidAmount\":\"{4}\"", TotalAmount, orderCount, BuyerName, GetUnPaidAmount, GetPaidAmount);
                jsonsb.Append("},");
            }
            string jsop= jsonsb.ToString().Substring(0, jsonsb.ToString().Length - 1);
            //jsop =jsop + "]}";
            jsop = jsop + "]";


            this.hidAllDepotStatsJson.Value = jsop;
        }
    }
}