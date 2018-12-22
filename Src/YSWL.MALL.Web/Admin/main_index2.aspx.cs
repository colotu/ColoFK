using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YSWL.Json;
using YSWL.MALL.ViewModel;

namespace YSWL.MALL.Web.Admin
{
    public partial class main_index2 : PageBaseAdmin
    {
        public string CurrentUserName = string.Empty;
        public string GetDateTime = string.Empty;

        private BLL.Shop.Products.ProductInfo _productInfoBll = new BLL.Shop.Products.ProductInfo();
        private YSWL.MALL.BLL.Shop.Favorite _favorBll = new BLL.Shop.Favorite();
        private YSWL.MALL.BLL.Shop.Order.OrderItems _orderItems = new BLL.Shop.Order.OrderItems();

      

        protected void Page_Load(object sender, EventArgs e)
        {

            

            if (!string.IsNullOrWhiteSpace(this.Request.Form["Callback"]) && (this.Request.Form["Callback"] == "true"))
            {
                this.Controls.Clear();
                this.DoCallback();
            }
            if (!IsPostBack)
            {

                
            }

            this.amountNoDate.Visible = false;
            this.countNoDate.Visible = false;

            RepeaterAmount.DataSource = GetCount();
            RepeaterAmount.DataBind();
            RepeaterCount.DataSource = GetAmount();
            RepeaterCount.DataBind();
        }

        private void DoCallback()
        {
            string action = this.Request.Form["Action"];
            this.Response.Clear();
            this.Response.ContentType = "application/json";
            string writeText = string.Empty;

            switch (action)
            {
                case "GetDate":
                    writeText = GetDate();
                    break;
            }
            this.Response.Write(writeText);
            this.Response.End();
        }

        private string GetDate()
        {
            JsonObject json = new JsonObject();
            json.Put("STATUS", "SUCCESS");
            json.Put("ALL", _productInfoBll.GetProductCount(-1));
            json.Put("SALE", _productInfoBll.GetProductCount(1));
            json.Put("UNSALE", _productInfoBll.GetProductCount(0));
            json.Put("FAVOR", _favorBll.FavProductCount());
            return json.ToString();
        }

        /// <summary>
        /// 获取销售数量
        /// </summary>
        public List<SaleData> GetCount()
        {
             var  count = _orderItems.GetSaleResult();
            List<SaleData> listCount = new List<SaleData>();

            if (count != null && count.Count > 0)
            {
                int Count = count[0].Count;
                for (int i = 0; i < count.Count; i++)
                {
                    SaleData tModerl = new SaleData();
                    tModerl.Amount = count[i].Amount;
                    tModerl.Count = count[i].Count;
                    tModerl.Name = count[i].Name;
                    if (Count > 0)
                    {
                        tModerl.Width = YSWL.Common.Globals.SafeDecimal(count[i].Count, 0)/Count*100 + "%";
                    }
                    else
                    {
                        tModerl.Width = 0 + "%";
                    }
                    tModerl.Sequence = i + 1;
                    listCount.Add(tModerl);
                }
            }
            else
            {
                this.countNoDate.Visible = true;
            }
            return listCount;

        }

        /// <summary>
        /// 获取销售数量
        /// </summary>
        public List<SaleData> GetAmount()
        {
            var monut = _orderItems.GetSaleAmountResult();
            List<SaleData> listMonut = new List<SaleData>();

            if (monut != null && monut.Count > 0)
            {
                decimal maxAmount = monut[0].Amount;
                for (int i = 0; i < monut.Count; i++)
                {
                    SaleData tModerl = new SaleData();
                    tModerl.Amount = monut[i].Amount;
                    tModerl.Count = monut[i].Count;
                    tModerl.Name = monut[i].Name;
                    if (maxAmount > 0)
                    {
                        tModerl.Width = monut[i].Amount/maxAmount*100 + "%";
                    }
                    else
                    {
                        tModerl.Width = 0 + "%";
                    }
                    tModerl.Sequence = i + 1;
                    listMonut.Add(tModerl);
                }
            }
            else
            {
                this.amountNoDate.Visible = true;
            }
            return listMonut;

        }
    }
}