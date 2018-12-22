using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YSWL.Components.Handlers.API;
using YSWL.Json;
using YSWL.Json.RPC;
using YSWL.MALL.ViewModel.Shop;

namespace YSWL.MALL.API.Pos.v1
{
    public partial class PosHandler
    {
        public string mdmUrl = Common.ConfigHelper.GetConfigString("MDM_Url");
        private YSWL.MALL.BLL.Shop.Products.ProductInfo productManage = new YSWL.MALL.BLL.Shop.Products.ProductInfo();
        private YSWL.MALL.BLL.Shop.Products.SKUInfo skuBLL = new YSWL.MALL.BLL.Shop.Products.SKUInfo();
        private YSWL.MALL.BLL.Shop.Sales.SalesRuleProduct ruleProductBll = new BLL.Shop.Sales.SalesRuleProduct();

        private readonly YSWL.MALL.BLL.Shop.DisDepot.Depot disDepotBll = new YSWL.MALL.BLL.Shop.DisDepot.Depot();
        #region 商品分类
        [JsonRpcMethod("CategoryList", Idempotent = false)]
        [JsonRpcHelp("商品分类")]
        public JsonObject CategoryList(int Cid, int Top = 7)
        {
            List<YSWL.MALL.Model.Shop.Products.CategoryInfo> cateList = YSWL.MALL.BLL.Shop.Products.CategoryInfo.GetAvailableCateList();
            List<YSWL.MALL.Model.Shop.Products.CategoryInfo> categoryInfos = cateList.FindAll(c => c.ParentCategoryId == Cid);
            if (categoryInfos == null)
            {
                return new Result(ResultStatus.Success, null);
            }
            JsonObject baseJson;
            JsonArray result = new JsonArray();
            string imageUrl;//定义变量来接收  否则连续读取会出现url重复累加的情况
            foreach (Model.Shop.Products.CategoryInfo item in categoryInfos)
            {
                #region 远程加载数据图片
                if (YSWL.Components.MvcApplication.IsAutoConn)
                {
                    imageUrl = String.IsNullOrWhiteSpace(item.ImageUrl) ? item.ImageUrl : item.ImageUrl.Replace("/Upload/", mdmUrl + "/Upload/");
                }
                else
                {
                    imageUrl = item.ImageUrl;
                }
                #endregion

                baseJson = new JsonObject();
                baseJson.Put("id", item.CategoryId);
                baseJson.Put("title", item.Name);
                baseJson.Put("haschild", item.HasChildren);
                baseJson.Put("description", item.Description);
                baseJson.Put("pic", imageUrl);
                if (item.HasChildren == true)
                {
                    baseJson.Put("childlist", GetCategoryList(item.CategoryId, cateList));
                }
                result.Add(baseJson);
            }
            return new Result(ResultStatus.Success, result);
        }
        private JsonArray GetCategoryList(int parentId, List<YSWL.MALL.Model.Shop.Products.CategoryInfo> cateList)
        {
            JsonObject currjson;
            JsonArray array = new JsonArray();
            List<YSWL.MALL.Model.Shop.Products.CategoryInfo> categoryInfos = cateList.FindAll(info => info.ParentCategoryId == parentId);
            if (categoryInfos != null && categoryInfos.Count() > 0)
            {
                string imageUrl;//定义变量来接收  否则连续读取会出现url重复累加的情况
                foreach (YSWL.MALL.Model.Shop.Products.CategoryInfo item in categoryInfos)
                {
                    #region 远程加载数据图片
                    if (YSWL.Components.MvcApplication.IsAutoConn)
                    {
                        imageUrl = String.IsNullOrWhiteSpace(item.ImageUrl) ? item.ImageUrl : item.ImageUrl.Replace("/Upload/", mdmUrl + "/Upload/");
                    }
                    else
                    {
                        imageUrl = item.ImageUrl;
                    }
                    #endregion

                    currjson = new JsonObject();
                    currjson.Put("id", item.CategoryId);
                    currjson.Put("haschild", item.HasChildren);
                    currjson.Put("parentId", item.ParentCategoryId);
                    currjson.Put("title", item.Name);
                    currjson.Put("pic", imageUrl);
                    if (item.HasChildren == true)
                    {
                        currjson.Put("childlist", GetCategoryList(item.CategoryId, cateList));
                    }
                    array.Add(currjson);
                }
            }
            return array;
        }
        #endregion

        #region 搜索商品列表
        [JsonRpcMethod("GetProductList", Idempotent = false)]
        [JsonRpcHelp("搜索商品列表")]
        public JsonObject GetProductList(int depotId=-1, int cid = 0, string keyword = "", string orderby = "hot",
                                        int? page = 1, int pageNum = 30)
        {

            if (pageNum == 0)
            {
                pageNum = 10;
            }
            if (String.IsNullOrEmpty(page.ToString()))
            {
                page = 1;
            }
            if (String.IsNullOrWhiteSpace(keyword)) {
                keyword="";
            }
            ProductListModel model = new ProductListModel();
            keyword = YSWL.Common.InjectionFilter.SqlFilter(keyword);
            if (cid > 0)
            {
                List<YSWL.MALL.Model.Shop.Products.CategoryInfo> cateList = YSWL.MALL.BLL.Shop.Products.CategoryInfo.GetAvailableCateList();
                YSWL.MALL.Model.Shop.Products.CategoryInfo categoryInfo =
                    cateList.FirstOrDefault(c => c.CategoryId == cid);
                if (categoryInfo != null)
                {
                    var path_arr = categoryInfo.Path.Split('|');
                    List<YSWL.MALL.Model.Shop.Products.CategoryInfo> categorysPath =
                        cateList.Where(c => path_arr.Contains(c.CategoryId.ToString())).OrderBy(c => c.Depth)
                                .ToList();
                    model.CategoryPathList = categorysPath;
                    model.CurrentCateName = categoryInfo.Name;
                }
            }
            model.CurrentCid = cid;
            model.CurrentMod = orderby;

            //重置页面索引
            page = page.HasValue && page.Value > 1 ? page.Value : 1;
            //计算分页起始索引
            int startIndex = page.Value > 1 ? (page.Value - 1) * pageNum + 1 : 0;
            //计算分页结束索引
            int endIndex = page.Value > 1 ? startIndex + pageNum - 1 : pageNum;
            YSWL.Json.JsonArray jsonArray = new JsonArray();
            JsonObject json;
            List<YSWL.MALL.Model.Shop.Products.ProductInfo> list;
            try
            {
                if (String.IsNullOrEmpty(orderby))
                {
                    orderby = "default";
                }
                list = productManage.GetSearchListEx(cid, 0, keyword, "0-0", orderby, startIndex, endIndex);
            }
            catch (Exception ex)
            {
                YSWL.MALL.BLL.SysManage.LogHelp.AddErrorLog(string.Format(HandlerBase.ERROR_MSG_LOG, Request.Headers[HandlerBase.REQUEST_HEADER_METHOD], ex.Message),
                   ex.StackTrace, (HttpRequest) Request);
                return new Result(ResultStatus.Error, ex.Message);
            }
            if (list == null)
            {
                return new Result(ResultStatus.Success, null);
            }
            List<Model.Shop.Products.SKUInfo> skulist;
            int stock;
            bool openAlertStock = YSWL.MALL.BLL.SysManage.ConfigSystem.GetBoolValueByCache("Shop_OpenAlertStock");
            foreach (YSWL.MALL.Model.Shop.Products.ProductInfo item in list)
            {
                skulist = skuBLL.GetProductSkuInfo(item.ProductId);//sku信息
                #region 远程加载数据图片
                if (YSWL.Components.MvcApplication.IsAutoConn)
                {
                    item.ThumbnailUrl1 = String.IsNullOrWhiteSpace(item.ThumbnailUrl1) ? item.ThumbnailUrl1 : item.ThumbnailUrl1.Replace("/Upload/", mdmUrl + "/Upload/");
                }
                #endregion
                json = new JsonObject();
                json.Put("id", item.ProductId);
                json.Put("name", item.ProductName);
                json.Put("pic", item.ThumbnailUrl1);
                json.Put("marketprice", item.MarketPrice.HasValue ? item.MarketPrice.Value.ToString("F") : "0.00");
                json.Put("saleprice", item.LowestSalePrice.ToString("F"));
                if (skulist != null && skulist.Count > 0)
                {
                    stock = 0;
                    if (openAlertStock) //开启警戒库存
                    {
                        skulist.ForEach(info => {
                            if (info.Stock > info.AlertStock)
                            {
                                stock += info.Stock;
                            }
                        });
                        json.Put("hasStock", stock > 0 ? true : false);
                    }
                    else
                    {
                        skulist.ForEach(info => {
                            stock += info.Stock;
                        });
                        json.Put("hasStock", stock > 0 ? true : false);
                    }
                }
                else
                {
                    json.Put("hasStock", false);
                }
                jsonArray.Add(json);
            }
            return new Result(ResultStatus.Success, jsonArray);
        }
        #endregion

        #region 商品详情

        #region 旧代码获取商品详情

        //        [JsonRpcMethod("ProductDetail", Idempotent = false)]
        //        [JsonRpcHelp("商品详情")]
        //        public JsonObject ProductDetail(int pId = -1, int userId = -1)
        //        {
        //            if (pId <= 0)
        //            {
        //                return new Result(ResultStatus.Failed, Result.FormatFailed(HandlerBase.ERROR_CODE_ARGUMENT, HandlerBase.ERROR_MSG_ARGUMENT));
        //            }
        //            YSWL.MALL.ViewModel.Shop.ProductModel model = new ProductModel();
        //            model.ProductInfo = productManage.GetModel(pId);
        //            if (model.ProductInfo == null)
        //            {
        //                return new Result(ResultStatus.Failed, Result.FormatFailed(HandlerBase.ERROR_CODE_ARGUMENT, HandlerBase.ERROR_MSG_ARGUMENT));
        //            }
        //            JsonArray jsonArray = new JsonArray();
        //            JsonObject json;
        //            JsonArray picArray = new JsonArray();
        //            YSWL.MALL.BLL.Shop.Products.ProductImage imageManage = new YSWL.MALL.BLL.Shop.Products.ProductImage();
        //            model.ProductImages = imageManage.ProductImagesList(pId);

        //            YSWL.MALL.ViewModel.Shop.ProductSKUModel productSKUModel = new YSWL.MALL.ViewModel.Shop.ProductSKUModel();
        //            #region 多分仓库存处理 （临时用默认收货地址处理）
        //            if (YSWL.MALL.BLL.Shop.Service.CommonHelper.OpenMultiDepot()) //是否开启多分仓
        //            {
        //                //获取用户默认收货地址
        //                YSWL.MALL.BLL.Shop.Shipping.ShippingAddress addressBll = new YSWL.MALL.BLL.Shop.Shipping.ShippingAddress();
        //                int regionId = addressBll.GetDefaultRegionId(userId);
        //                productSKUModel = skuBLL.GetProductSKUInfoByProductId(model.ProductInfo.ProductId, regionId, model.ProductInfo.SupplierId);
        //            }
        //            else
        //            {
        //                productSKUModel = skuBLL.GetProductSKUInfoByProductId(model.ProductInfo.ProductId);
        //            }
        //            #endregion 

        //           // YSWL.MALL.ViewModel.Shop.ProductSKUModel productSKUModel = skuBLL.GetProductSKUInfoByProductId(model.ProductInfo.ProductId);


        //            if (productSKUModel == null || productSKUModel.ListSKUInfos == null || productSKUModel.ListSKUInfos.Count < 1)
        //            {
        //                return new Result(ResultStatus.Success, null);
        //            }
        //            string salesprice = productSKUModel.ListSKUInfos[0].SalePrice.ToString("F");
        //            #region 远程加载数据图片
        //            if (YSWL.Components.MvcApplication.IsAutoConn)
        //            {
        //                model.ProductInfo.ThumbnailUrl1 = String.IsNullOrWhiteSpace(model.ProductInfo.ThumbnailUrl1) ? model.ProductInfo.ThumbnailUrl1 : model.ProductInfo.ThumbnailUrl1.Replace("/Upload/", mdmUrl + "/Upload/");

        //                model.ProductInfo.Description = String.IsNullOrWhiteSpace(model.ProductInfo.Description) ? model.ProductInfo.Description : model.ProductInfo.Description.Replace("/ueditor/net/upload/", mdmUrl + "/ueditor/net/upload/");
        //            }
        //            #endregion
        //            JsonObject attr;
        //            json = new JsonObject();
        //            json.Put("id", model.ProductInfo.ProductId);
        //            json.Put("name", model.ProductInfo.ProductName);
        //            json.Put("marketprice", ((Decimal)model.ProductInfo.MarketPrice).ToString("F"));
        //            json.Put("saleprice", salesprice);
        //            json.Put("xmltext", model.ProductInfo.Description);
        //            json.Put("leftTime", model.ProductInfo.ProSalesEndDate.ToString("yyyy年MM月dd日HH时mm分ss秒"));
        //            json.Put("pic", model.ProductInfo.ThumbnailUrl1);
        //            foreach (YSWL.MALL.Model.Shop.Products.ProductImage pro in model.ProductImages)
        //            {
        //                if (YSWL.Components.MvcApplication.IsAutoConn)
        //                {
        //                    picArray.Add(String.IsNullOrWhiteSpace(pro.ThumbnailUrl1) ? pro.ThumbnailUrl1 : pro.ThumbnailUrl1.Replace("/Upload/", mdmUrl + "/Upload/"));
        //                }
        //                else
        //                {
        //                    picArray.Add(pro.ThumbnailUrl1);
        //                }
        //            }
        //            json.Put("bigPic", picArray);
        //            // json.Put("commentCount", reviewsBLL.GetRecordCount("Status=1 and ProductId=" + pId));
        //            json.Put("sku", productSKUModel.ListSKUInfos[0].SKU);
        //            JsonArray skuArray = new JsonArray();
        //            foreach (KeyValuePair<YSWL.MALL.Model.Shop.Products.AttributeInfo, SortedSet<YSWL.MALL.Model.Shop.Products.SKUItem>>
        //attrSKUItem in productSKUModel.ListAttrSKUItems)
        //            {
        //                foreach (YSWL.MALL.Model.Shop.Products.SKUItem skuItem in attrSKUItem.Value)
        //                {
        //                    attr = new JsonObject();
        //                    attr.Put("id", skuItem.ValueId);
        //                    attr.Put("key", skuItem.AttributeName);
        //                    attr.Put("value", skuItem.ValueStr);
        //                    if (YSWL.Components.MvcApplication.IsAutoConn)
        //                    {
        //                        attr.Put("pic", String.IsNullOrWhiteSpace(skuItem.ImageUrl) ? skuItem.ImageUrl : skuItem.ImageUrl.Replace("/Upload/", mdmUrl + "/Upload/"));
        //                    }
        //                    else
        //                    {
        //                        attr.Put("pic", skuItem.ImageUrl);
        //                    }
        //                    skuArray.Add(attr);
        //                }
        //            }
        //            if (skuArray != null && skuArray.Length > 0)
        //            {
        //                json.Put("productProperty", skuArray);
        //            }

        //            //NO SKU ERROR
        //            if (productSKUModel.ListSKUInfos != null &&
        //                productSKUModel.ListSKUInfos.Count > 0 &&
        //                productSKUModel.ListSKUItems != null)
        //            {
        //                json.Put("hasSKU", true);
        //                json.Put("hasStock", true);
        //                //木有开启SKU的情况
        //                if (productSKUModel.ListSKUItems.Count == 0)
        //                {
        //                    json.Put("hasSKU", false);
        //                    //判断库存是否满足
        //                    json.Put("hasStock", true);

        //                    //是否开启警戒库存判断
        //                    bool IsOpenAlertStock =
        //                        YSWL.MALL.BLL.SysManage.ConfigSystem.GetBoolValueByCache("Shop_OpenAlertStock");
        //                    if (IsOpenAlertStock &&
        //                        productSKUModel.ListSKUInfos[0].Stock <= productSKUModel.ListSKUInfos[0].AlertStock)
        //                    {
        //                        json.Put("hasStock", false);
        //                    }

        //                    if (productSKUModel.ListSKUInfos[0].Stock < 1)
        //                    {
        //                        json.Put("hasStock", false);
        //                    }
        //                    else
        //                    {
        //                        json.Put("stockcount", productSKUModel.ListSKUInfos[0].Stock);
        //                    }
        //                }
        //            }
        //            SKUInfoToJson(json, productSKUModel.ListSKUInfos, userId, model.ProductInfo.SupplierId);
        //            // result.Put("product", json);


        //            #region 批发优惠列表  前台没有显示，所以暂时不返回
        //            // JsonArray salesRuleArray = new JsonArray();
        //            //if (model.ProductInfo.SupplierId <= 0)
        //            //{
        //            //    //批发规则  只有自营商品使用 
        //            //    YSWL.MALL.BLL.Shop.Sales.SalesRuleProduct ruleBll = new YSWL.MALL.BLL.Shop.Sales.SalesRuleProduct();
        //            //    YSWL.MALL.ViewModel.Shop.SalesModel saleRuleModel = ruleBll.GetSalesRuleByCache(pId, userId);
        //            //    if (saleRuleModel != null && saleRuleModel.SalesItems != null && saleRuleModel.SalesItems.Count > 0)
        //            //    {
        //            //        JsonObject salesRulejson;
        //            //        JsonArray userRankArray;
        //            //        //JsonObject userRankJson;
        //            //        foreach (var item in saleRuleModel.SalesItems)
        //            //        {
        //            //            salesRulejson = new JsonObject();
        //            //            salesRulejson.Put("ruleUnit", saleRuleModel.SalesRule.RuleUnit);//规则单位  0：个 1：元
        //            //            salesRulejson.Put("rateValue", item.RateValue);//优惠数值
        //            //            salesRulejson.Put("itemType", item.ItemType);//规则类型 0：打折 1：减价 2：固定价格
        //            //            salesRulejson.Put("unitValue", item.UnitValue);
        //            //            userRankArray = new JsonArray();
        //            //            if (item.UserRankList != null)
        //            //            {
        //            //                foreach (var rankItem in item.UserRankList)
        //            //                {
        //            //                    //userRankJson = new JsonObject();
        //            //                    userRankArray.Add(rankItem.Name);
        //            //                }
        //            //            }
        //            //            salesRulejson.Put("userRankList", userRankArray);
        //            //            salesRuleArray.Add(salesRulejson);
        //            //        }
        //            //    }
        //            //}
        //            //json.Put("salesRule", salesRuleArray);
        //            #endregion

        //            return new Result(ResultStatus.Success, json);
        //        }

        #endregion

        [JsonRpcMethod("ProductDetailByPid", Idempotent = false)]
        [JsonRpcHelp("商品详情")]
        public JsonObject ProductDetailByPid(int depotId = -1, int pId = -1)
        {
            if (pId <= 0)
            {
                return new Result(ResultStatus.Failed, Result.FormatFailed(HandlerBase.ERROR_CODE_ARGUMENT, HandlerBase.ERROR_MSG_ARGUMENT));
            }
            YSWL.MALL.ViewModel.Shop.ProductModel model = new ProductModel();
            model.ProductInfo = productManage.GetModel(pId);
            if (model.ProductInfo == null)
            {
                return new Result(ResultStatus.Failed, Result.FormatFailed(HandlerBase.ERROR_CODE_ARGUMENT, HandlerBase.ERROR_MSG_ARGUMENT));
            }
            JsonArray jsonArray = new JsonArray();
            JsonObject json;
            JsonArray picArray = new JsonArray();
            YSWL.MALL.BLL.Shop.Products.ProductImage imageManage = new YSWL.MALL.BLL.Shop.Products.ProductImage();
            model.ProductImages = imageManage.ProductImagesList(pId);

            YSWL.MALL.ViewModel.Shop.ProductSKUModel productSKUModel = new YSWL.MALL.ViewModel.Shop.ProductSKUModel();

            YSWL.MALL.BLL.Shop.Shipping.ShippingAddress addressBll = new YSWL.MALL.BLL.Shop.Shipping.ShippingAddress();

            productSKUModel = skuBLL.GetProductSKUInfoByProductIdAndDepotId(model.ProductInfo.ProductId, depotId, model.ProductInfo.SupplierId);
           
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
                json.Put("hasStock", productSKUModel.ListSKUInfos.Any(i=>i.Stock>0));
                //json.Put("hasStock",true);
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
            SKUInfoToJson(json, productSKUModel.ListSKUInfos, -1, model.ProductInfo.SupplierId);
            // result.Put("product", json);

            return new Result(ResultStatus.Success, json);
        }

        [JsonRpcMethod("ProductDetailBySku", Idempotent = false)]
        [JsonRpcHelp("商品详情")]
        public JsonObject ProductDetailBySku(int depotId = -1, string sku="")
        {
            if (string.IsNullOrEmpty(sku))
            {
                return new Result(ResultStatus.Failed, Result.FormatFailed(HandlerBase.ERROR_CODE_ARGUMENT, HandlerBase.ERROR_MSG_ARGUMENT));
            }
            YSWL.MALL.ViewModel.Shop.ProductModel model = new ProductModel();
            Model.Shop.Products.ProductInfo info = productManage.GetModelBySku(sku);
            model.ProductInfo = info;
            if (model.ProductInfo == null)
            {
                return new Result(ResultStatus.Failed, Result.FormatFailed(HandlerBase.ERROR_CODE_ARGUMENT, HandlerBase.ERROR_MSG_ARGUMENT));
            }
            JsonArray jsonArray = new JsonArray();
            JsonObject json;
            JsonArray picArray = new JsonArray();
            YSWL.MALL.BLL.Shop.Products.ProductImage imageManage = new YSWL.MALL.BLL.Shop.Products.ProductImage();
            model.ProductImages = imageManage.ProductImagesList(info.ProductId);

            YSWL.MALL.ViewModel.Shop.ProductSKUModel productSKUModel = new YSWL.MALL.ViewModel.Shop.ProductSKUModel();

            YSWL.MALL.BLL.Shop.Shipping.ShippingAddress addressBll = new YSWL.MALL.BLL.Shop.Shipping.ShippingAddress();

            productSKUModel = skuBLL.GetProductSKUInfoByProductIdAndDepotId(info.ProductId, depotId, model.ProductInfo.SupplierId);

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
                //json.Put("hasStock", true);
                json.Put("hasStock", productSKUModel.ListSKUInfos.Any(i => i.Stock > 0));
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
            SKUInfoToJsonBySku(json, productSKUModel.ListSKUInfos, -1, model.ProductInfo.SupplierId,sku);
            // result.Put("product", json);

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
                //if (item.Stock < 1)
                //    continue;

                //组合SKU 的 ValueId
                key = new long[item.SkuItems.Count];
                index = 0;
                item.SkuItems.ForEach(xx => key[index++] = xx.ValueId);
                jsonSKU.Accumulate(string.Join(",", key), new
                {
                    sku = item.SKU,
                    count = item.Stock>0?item.Stock:0,
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

        private YSWL.Json.JsonObject SKUInfoToJsonBySku(YSWL.Json.JsonObject json, List<YSWL.MALL.Model.Shop.Products.SKUInfo> list, int userId, int suppId,string sku)
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
                if (item.SKU.Trim() != sku.Trim()) continue;

                //无库存SKU不提供给页面
                //是否开启警戒库存判断
                bool IsOpenAlertStock = YSWL.MALL.BLL.SysManage.ConfigSystem.GetBoolValueByCache("Shop_OpenAlertStock");
                if (IsOpenAlertStock && item.Stock <= item.AlertStock)
                {
                    continue;
                }
                //if (item.Stock < 1)
                //    continue;

                //组合SKU 的 ValueId
                key = new long[item.SkuItems.Count];
                index = 0;
                item.SkuItems.ForEach(xx => key[index++] = xx.ValueId);
                jsonSKU.Accumulate(string.Join(",", key), new
                {
                    sku = item.SKU,
                    count = item.Stock>0?item.Stock:0,
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


        #region 获取仓库列表

        [JsonRpcMethod("GetDepotList", Idempotent = false)]
        [JsonRpcHelp("获取仓库列表")]
        public JsonObject GetDepotList()
        {
            List<Model.Shop.DisDepot.Depot> depotList = disDepotBll.GetModelList("Status=1");
            JsonArray array = new JsonArray();
            JsonObject obj = null;
            foreach (Model.Shop.DisDepot.Depot item in depotList)
            {
                obj = new JsonObject
                {
                    { "id",item.DepotId},
                    { "name",item.Name }
                };
                array.Put(obj);
            }
            return new Result(ResultStatus.Success, array);
        }
        #endregion
    }
}