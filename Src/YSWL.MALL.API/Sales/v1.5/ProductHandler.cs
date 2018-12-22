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
        private YSWL.MALL.BLL.Shop.Products.ProductInfo productManage = new YSWL.MALL.BLL.Shop.Products.ProductInfo();
        private YSWL.MALL.BLL.Shop.Products.SKUInfo skuBLL = new YSWL.MALL.BLL.Shop.Products.SKUInfo();
        private YSWL.MALL.BLL.Shop.Sales.SalesRuleProduct ruleProductBll = new BLL.Shop.Sales.SalesRuleProduct();

        #region 商品详情
        [JsonRpcMethod("ProductDetail1.5", Idempotent = false)]
        [JsonRpcHelp("商品详情")]
        public JsonObject ProductDetail1_5(int pId = -1, int userId = -1,int regionId = 0)
        {
            if (pId <= 0)
            {
                return new Result(ResultStatus.Failed, Result.FormatFailed(ERROR_CODE_ARGUMENT, ERROR_MSG_ARGUMENT));
            }
            YSWL.MALL.ViewModel.Shop.ProductModel model = new ProductModel();
            model.ProductInfo = productManage.GetModel(pId);
            if (model.ProductInfo == null)
            {
                return new Result(ResultStatus.Failed, Result.FormatFailed(ERROR_CODE_ARGUMENT, ERROR_MSG_ARGUMENT));
            }
            JsonArray jsonArray = new JsonArray();
            JsonObject json;
            JsonArray picArray = new JsonArray();
            YSWL.MALL.BLL.Shop.Products.ProductImage imageManage = new YSWL.MALL.BLL.Shop.Products.ProductImage();
            model.ProductImages = imageManage.ProductImagesList(pId);

            YSWL.MALL.ViewModel.Shop.ProductSKUModel productSKUModel = new YSWL.MALL.ViewModel.Shop.ProductSKUModel();
            #region 多分仓库存处理 （临时用默认收货地址处理）
            if (YSWL.MALL.BLL.Shop.Service.CommonHelper.OpenMultiDepot()) //是否开启多分仓
            {
                //获取用户默认收货地址
                //YSWL.MALL.BLL.Shop.Shipping.ShippingAddress addressBll = new YSWL.MALL.BLL.Shop.Shipping.ShippingAddress();
                //int regionId = addressBll.GetDefaultRegionId(userId);
                productSKUModel = skuBLL.GetProductSKUInfoByProductId(model.ProductInfo.ProductId, regionId, model.ProductInfo.SupplierId);
            }
            else
            {
                productSKUModel = skuBLL.GetProductSKUInfoByProductId(model.ProductInfo.ProductId);
            }
            #endregion 

           // YSWL.MALL.ViewModel.Shop.ProductSKUModel productSKUModel = skuBLL.GetProductSKUInfoByProductId(model.ProductInfo.ProductId);


            if (productSKUModel == null || productSKUModel.ListSKUInfos == null || productSKUModel.ListSKUInfos.Count < 1)
            {
                return new Result(ResultStatus.Success, null);
            }
            string salesprice = productSKUModel.ListSKUInfos[0].SalePrice.ToString("F");
            #region 远程加载数据图片
            if (YSWL.Components.MvcApplication.IsAutoConn)
            {
                model.ProductInfo.ThumbnailUrl1 = String.IsNullOrWhiteSpace(model.ProductInfo.ThumbnailUrl1) ? model.ProductInfo.ThumbnailUrl1 : model.ProductInfo.ThumbnailUrl1.Replace("/Upload/", mdmUrl + "/Upload/");

                model.ProductInfo.Description = String.IsNullOrWhiteSpace(model.ProductInfo.Description) ? model.ProductInfo.Description : model.ProductInfo.Description.Replace("/ueditor/net/upload/", mdmUrl + "/ueditor/net/upload/");
            }
            #endregion
            JsonObject attr;
            json = new JsonObject();
            json.Put("id", model.ProductInfo.ProductId);
            json.Put("name", model.ProductInfo.ProductName);
            json.Put("marketprice", ((Decimal)model.ProductInfo.MarketPrice).ToString("F"));
            json.Put("saleprice", salesprice);
            json.Put("xmltext", model.ProductInfo.Description);
            json.Put("leftTime", model.ProductInfo.ProSalesEndDate.ToString("yyyy年MM月dd日HH时mm分ss秒"));
            json.Put("pic", model.ProductInfo.ThumbnailUrl1);
            foreach (YSWL.MALL.Model.Shop.Products.ProductImage pro in model.ProductImages)
            {
                if (YSWL.Components.MvcApplication.IsAutoConn)
                {
                    picArray.Add(String.IsNullOrWhiteSpace(pro.ThumbnailUrl1) ? pro.ThumbnailUrl1 : pro.ThumbnailUrl1.Replace("/Upload/", mdmUrl + "/Upload/"));
                }
                else
                {
                    picArray.Add(pro.ThumbnailUrl1);
                }
            }
            json.Put("bigPic", picArray);
            // json.Put("commentCount", reviewsBLL.GetRecordCount("Status=1 and ProductId=" + pId));
            json.Put("sku", productSKUModel.ListSKUInfos[0].SKU);
            JsonArray skuArray = new JsonArray();
            foreach (KeyValuePair<YSWL.MALL.Model.Shop.Products.AttributeInfo, SortedSet<YSWL.MALL.Model.Shop.Products.SKUItem>>
attrSKUItem in productSKUModel.ListAttrSKUItems)
            {
                foreach (YSWL.MALL.Model.Shop.Products.SKUItem skuItem in attrSKUItem.Value)
                {
                    attr = new JsonObject();
                    attr.Put("id", skuItem.ValueId);
                    attr.Put("key", skuItem.AttributeName);
                    attr.Put("value", skuItem.ValueStr);
                    if (YSWL.Components.MvcApplication.IsAutoConn)
                    {
                        attr.Put("pic", String.IsNullOrWhiteSpace(skuItem.ImageUrl) ? skuItem.ImageUrl : skuItem.ImageUrl.Replace("/Upload/", mdmUrl + "/Upload/"));
                    }
                    else
                    {
                        attr.Put("pic", skuItem.ImageUrl);
                    }
                    skuArray.Add(attr);
                }
            }
            if (skuArray != null && skuArray.Length > 0)
            {
                json.Put("productProperty", skuArray);
            }

            //NO SKU ERROR
            if (productSKUModel.ListSKUInfos != null &&
                productSKUModel.ListSKUInfos.Count > 0 &&
                productSKUModel.ListSKUItems != null)
            {
                json.Put("hasSKU", true);
                json.Put("hasStock", true);
                //木有开启SKU的情况
                if (productSKUModel.ListSKUItems.Count == 0)
                {
                    json.Put("hasSKU", false);
                    //判断库存是否满足
                    json.Put("hasStock", true);

                    //是否开启警戒库存判断
                    bool IsOpenAlertStock =
                        YSWL.MALL.BLL.SysManage.ConfigSystem.GetBoolValueByCache("Shop_OpenAlertStock");
                    if (IsOpenAlertStock &&
                        productSKUModel.ListSKUInfos[0].Stock <= productSKUModel.ListSKUInfos[0].AlertStock)
                    {
                        json.Put("hasStock", false);
                    }

                    if (productSKUModel.ListSKUInfos[0].Stock < 1)
                    {
                        json.Put("hasStock", false);
                    }
                    else
                    {
                        json.Put("stockcount", productSKUModel.ListSKUInfos[0].Stock);
                    }
                }
            }
            SKUInfoToJson(json, productSKUModel.ListSKUInfos, userId, model.ProductInfo.SupplierId);
            // result.Put("product", json);


            #region 批发优惠列表  前台没有显示，所以暂时不返回
            // JsonArray salesRuleArray = new JsonArray();
            //if (model.ProductInfo.SupplierId <= 0)
            //{
            //    //批发规则  只有自营商品使用 
            //    YSWL.MALL.BLL.Shop.Sales.SalesRuleProduct ruleBll = new YSWL.MALL.BLL.Shop.Sales.SalesRuleProduct();
            //    YSWL.MALL.ViewModel.Shop.SalesModel saleRuleModel = ruleBll.GetSalesRuleByCache(pId, userId);
            //    if (saleRuleModel != null && saleRuleModel.SalesItems != null && saleRuleModel.SalesItems.Count > 0)
            //    {
            //        JsonObject salesRulejson;
            //        JsonArray userRankArray;
            //        //JsonObject userRankJson;
            //        foreach (var item in saleRuleModel.SalesItems)
            //        {
            //            salesRulejson = new JsonObject();
            //            salesRulejson.Put("ruleUnit", saleRuleModel.SalesRule.RuleUnit);//规则单位  0：个 1：元
            //            salesRulejson.Put("rateValue", item.RateValue);//优惠数值
            //            salesRulejson.Put("itemType", item.ItemType);//规则类型 0：打折 1：减价 2：固定价格
            //            salesRulejson.Put("unitValue", item.UnitValue);
            //            userRankArray = new JsonArray();
            //            if (item.UserRankList != null)
            //            {
            //                foreach (var rankItem in item.UserRankList)
            //                {
            //                    //userRankJson = new JsonObject();
            //                    userRankArray.Add(rankItem.Name);
            //                }
            //            }
            //            salesRulejson.Put("userRankList", userRankArray);
            //            salesRuleArray.Add(salesRulejson);
            //        }
            //    }
            //}
            //json.Put("salesRule", salesRuleArray);
            #endregion

            return new Result(ResultStatus.Success, json);
        }
        private YSWL.Json.JsonObject SKUInfoToJson(YSWL.Json.JsonObject json, List<YSWL.MALL.Model.Shop.Products.SKUInfo> list, int userId, int suppId)
        {
            if (list == null || list.Count < 1) return null;

            YSWL.Json.JsonObject jsonSKU = new YSWL.Json.JsonObject();
            long[] key;
            int index;
            #region 计算会员等级价格
            if (suppId <= 0)
            {
                list = ruleProductBll.GetRankSales(list, userId);
            }
            #endregion

            foreach (YSWL.MALL.Model.Shop.Products.SKUInfo item in list)
            {
                if (item.SkuItems == null || item.SkuItems.Count < 1) continue;

                //无库存SKU不提供给页面
                //是否开启警戒库存判断
                bool IsOpenAlertStock = YSWL.MALL.BLL.SysManage.ConfigSystem.GetBoolValueByCache("Shop_OpenAlertStock");
                if (IsOpenAlertStock && item.Stock <= item.AlertStock)
                {
                    continue;
                }
                if (item.Stock < 1)
                    continue;

                //组合SKU 的 ValueId
                key = new long[item.SkuItems.Count];
                index = 0;
                item.SkuItems.ForEach(xx => key[index++] = xx.ValueId);
                jsonSKU.Accumulate(string.Join(",", key), new
                {
                    sku = item.SKU,
                    count = item.Stock,
                    price = item.SalePrice,
                    rankprice = item.RankPrice
                });
            }

            //获取最小/最大价格
            list.Sort((x, y) => x.SalePrice.CompareTo(y.SalePrice));
            json.Put("defaultPrice", new
            {
                minPrice = list[0].SalePrice,
                maxPrice = list[list.Count - 1].SalePrice,
                minRankPrice = list[0].RankPrice,
                maxRankPrice = list[list.Count - 1].RankPrice
            });
            json.Put("skuData", jsonSKU);
            return json;
        }
        #endregion
 
 
    }
}
