using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using YSWL.Accounts.Bus;
using YSWL.MALL.BLL.Shop.Products;
using YSWL.MALL.BLL.SysManage;
using YSWL.Components.Handlers.API;
using YSWL.Json;
using YSWL.Json.RPC;
using YSWL.MALL.Model.Shop.Order;
using YSWL.MALL.Model.Shop.Products;
using YSWL.Common;
using SKUInfo = YSWL.MALL.Model.Shop.Products.SKUInfo;
using YSWL.MALL.BLL.Shop.Shipping;
using YSWL.MALL.BLL.Shop.Sales;
using YSWL.MALL.BLL.Shop.Order;
using YSWL.MALL.BLL.Ms;
using YSWL.MALL.ViewModel.Shop;

namespace YSWL.MALL.API.Sales.v1_5
{
    public partial class SalesHandler
    {
        private readonly Orders _orderManage = new Orders();
        private YSWL.MALL.BLL.Ms.Regions regionsBLL = new Regions();
        private YSWL.MALL.BLL.Shop.Shipping.ShippingAddress _addressManage = new YSWL.MALL.BLL.Shop.Shipping.ShippingAddress();
        private YSWL.MALL.BLL.Shop.Coupon.CouponInfo couponBLL = new BLL.Shop.Coupon.CouponInfo();
        private YSWL.MALL.BLL.Shop.Shipping.ShippingType _shippingTypeManage = new YSWL.MALL.BLL.Shop.Shipping.ShippingType();
        private YSWL.MALL.BLL.Shop.Shipping.ShippingRegionGroups _shippingRegionManage = new YSWL.MALL.BLL.Shop.Shipping.ShippingRegionGroups();
        private YSWL.MALL.BLL.Shop.PromoteSales.GroupBuy groupBuyBll = new YSWL.MALL.BLL.Shop.PromoteSales.GroupBuy();
        private YSWL.MALL.BLL.Shop.Order.OrderAction actionBLL = new YSWL.MALL.BLL.Shop.Order.OrderAction();
        private YSWL.MALL.BLL.Shop.Activity.ActivityInfo activInfoBll = new BLL.Shop.Activity.ActivityInfo();

        #region 获取购物车列表
        [JsonRpcMethod("GetCartList1.5", Idempotent = false)]
        [JsonRpcHelp("获取购物车列表")]  //这个接口后期需要拆分
        public JsonObject GetCartList1_5(JsonArray productList, int userId,int regionId)
        {
            if (productList == null)
            {
                return new Result(ResultStatus.Failed, null);
            }

            JsonObject result = new JsonObject();
            JsonArray array = new JsonArray();
            JsonObject json;
            ShoppingCartInfo shoppingCartInfo;
            try
            {
                shoppingCartInfo = GetCart(productList, userId, regionId);
            }
            catch (ArgumentNullException)
            {
                return new Result(ResultStatus.Failed, "PROSALEEXPIRED");
            }
            if (shoppingCartInfo == null ||
                shoppingCartInfo.Items == null ||
                shoppingCartInfo.Items.Count < 1)
            {
                return new Result(ResultStatus.Failed, "NOSHOPPINGCARTINFO");
            }
            bool openAlertStock = YSWL.MALL.BLL.SysManage.ConfigSystem.GetBoolValueByCache("Shop_OpenAlertStock");
            foreach (var item in shoppingCartInfo.Items)
            {
                json = new JsonObject();
                json.Put("id", item.ProductId);
                json.Put("name", item.Name);
                json.Put("number", item.Quantity);
                #region 远程加载数据图片
                if (YSWL.Components.MvcApplication.IsAutoConn)
                {
                    json.Put("pic", String.IsNullOrWhiteSpace(item.ThumbnailsUrl) ? item.ThumbnailsUrl : item.ThumbnailsUrl.Replace("/Upload/", mdmUrl + "/Upload/"));
                }
                else
                {
                    json.Put("pic", item.ThumbnailsUrl);
                }
                #endregion

                json.Put("marketprice", item.MarketPrice.ToString("F"));
                json.Put("saleprice", item.SellPrice.ToString("F"));
                json.Put("adjustedPrice", item.AdjustedPrice.ToString("F"));
                json.Put("sku", item.SKU);
                json.Put("limitQty", item.RestrictionCount);//限购数量
                if (openAlertStock) //开启警戒库存
                {
                    if (item.Stock > item.AlertStock)
                    {
                        json.Put("hasStock", true);
                        json.Put("stockcount", item.Stock);
                    }
                    else
                    {
                        json.Put("hasStock", false);
                    }
                }
                else
                {
                    if (item.Stock > 0)
                    {
                        json.Put("hasStock", true);
                        json.Put("stockcount", item.Stock);
                    }
                    else
                    {
                        json.Put("hasStock", false);
                    }
                }
                json.Put("saleStatus", item.SaleStatus);//商品上下架状态
                json.Put("saleDes", item.SaleDes);//优惠信息
                array.Add(json);
            }
            result.Put("productList", array);
            result.Put("totalRate", shoppingCartInfo.TotalRate);//总价优惠
            result.Put("totalSellPrice", shoppingCartInfo.TotalSellPrice);//优惠前价格
            result.Put("totalAdjustedPrice", shoppingCartInfo.TotalAdjustedPrice);//调整后价格

            return new Result(ResultStatus.Success, result);
        }
        #endregion
        private ShoppingCartInfo GetCart(JsonArray jsonSku, int userId,int regionId)
        {
            //是否对接多仓，处理逻辑
            bool IsMultiDepot = YSWL.MALL.BLL.Shop.Service.CommonHelper.OpenMultiDepot();
            ShoppingCartInfo shoppingCartInfo = new ShoppingCartInfo();
            JsonObject skuItem;
            if (null != jsonSku && jsonSku.Length > 0)
            {
                for (int i = 0; i < jsonSku.Length; i++)
                {
                    skuItem = jsonSku.GetObject(i);
                    string sku = skuItem["sku"].ToString();
                    int count = Globals.SafeInt(skuItem["number"].ToString(), 1);
                    YSWL.MALL.Model.Shop.Products.SKUInfo skuInfo = skuBLL.GetModelBySKU(sku);
                    if (skuInfo == null) continue; //异常数据
                    YSWL.MALL.Model.Shop.Products.ProductInfo productInfo = productManage.GetModel(skuInfo.ProductId);
                    if (productInfo == null) continue; //异常数据
                    YSWL.MALL.Model.Shop.Products.ShoppingCartItem itemInfo = new ShoppingCartItem();
                    itemInfo.MarketPrice = productInfo.MarketPrice.HasValue ? productInfo.MarketPrice.Value : 0;
                    itemInfo.Name = productInfo.ProductName;
                    itemInfo.Quantity = count;
                    itemInfo.SellPrice = skuInfo.SalePrice;
                    itemInfo.AdjustedPrice = skuInfo.SalePrice;
                    itemInfo.SKU = skuInfo.SKU;     
                    itemInfo.Stock = IsMultiDepot ? YSWL.MALL.BLL.Shop.Products.StockHelper.GetSkuStockByCache(sku, regionId, productInfo.SupplierId) : skuInfo.Stock;
                    itemInfo.AlertStock = skuInfo.AlertStock;
                    itemInfo.ProductId = skuInfo.ProductId;
                    itemInfo.UserId = userId;
                    itemInfo.BrandId = productInfo.BrandId;
                    itemInfo.SaleStatus = productInfo.SaleStatus;
                    //DONE: 根据SkuId 获取SKUItem值和图片数据 BEN 2013-06-30
                    //List<YSWL.MALL.Model.Shop.Products.SKUItem> listSkuItems = skuBLL.GetSKUItemsBySkuId(skuInfo.SkuId);
                    //if (listSkuItems != null && listSkuItems.Count > 0)
                    //{
                    //    itemInfo.SkuValues = new string[listSkuItems.Count];
                    //    int index = 0;
                    //    listSkuItems.ForEach(xx =>
                    //    {
                    //        itemInfo.SkuValues[index++] = xx.ValueStr;
                    //        if (!string.IsNullOrWhiteSpace(xx.ImageUrl))
                    //        {
                    //            itemInfo.SkuImageUrl = xx.ImageUrl;
                    //        }
                    //    });
                    //}
                    itemInfo.ThumbnailsUrl = productInfo.ThumbnailUrl1;
                    itemInfo.CostPrice = skuInfo.CostPrice.HasValue ? skuInfo.CostPrice.Value : 0;
                    itemInfo.Weight = skuInfo.Weight.HasValue ? skuInfo.Weight.Value : 0;
                    itemInfo.Points = (int)(productInfo.Points.HasValue ? productInfo.Points.Value : 0);
                    itemInfo.SupplierId = productInfo.SupplierId;
                    itemInfo.RestrictionCount = productInfo.RestrictionCount;
                    shoppingCartInfo.Items.Add(itemInfo);
                }
                #region 批销优惠
                try
                {
                    YSWL.MALL.BLL.Shop.Sales.SalesRuleProduct salesRule =
                        new YSWL.MALL.BLL.Shop.Sales.SalesRuleProduct();
                    shoppingCartInfo = salesRule.GetWholeSale(shoppingCartInfo);
                }
                catch (System.Exception ex)
                {
                    throw new Exception("获取批销优惠异常,位置：" + ex.StackTrace);
                }
                #endregion
                return shoppingCartInfo;
            }
            return null;
        }
 
    }
}
