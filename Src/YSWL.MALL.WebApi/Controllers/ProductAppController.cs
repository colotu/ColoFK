using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YSWL.Json;
using YSWL.MALL.Model.Shop.Products;
using YSWL.MALL.ViewModel.Shop;
using YSWL.MALL.WebApi.Models;

namespace YSWL.MALL.WebApi.Controllers
{
    [RoutePrefix("v1.0")]
    public class ProductAppController : ApiControllerBase
    {
        private readonly YSWL.MALL.BLL.Shop.Products.BrandInfo _brandBll = new BLL.Shop.Products.BrandInfo();
        private readonly YSWL.MALL.BLL.Shop.Products.ProductInfo _productBll = new YSWL.MALL.BLL.Shop.Products.ProductInfo();
        private readonly YSWL.MALL.BLL.Shop.Products.ProductReviews _reviewsBll = new YSWL.MALL.BLL.Shop.Products.ProductReviews();
        private readonly YSWL.MALL.BLL.Shop.Products.SKUInfo _skuBll = new YSWL.MALL.BLL.Shop.Products.SKUInfo();
        private readonly YSWL.MALL.BLL.Shop.Sales.SalesRuleProduct _ruleProductBll = new BLL.Shop.Sales.SalesRuleProduct();

        /// <summary>
        /// MDM域名
        /// </summary>
        private readonly string _mdmPath = YSWL.Common.ConfigHelper.GetConfigString("MDM_Url");

        #region 商品基础信息

        /// <summary>
        /// 获取商品分类
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("product/category")]
        public ResponseResult ProductCategory(int cid = 0)
        {
            //List<YSWL.MALL.Model.Shop.Products.CategoryInfo> cateList = YSWL.MALL.BLL.Shop.Products.CategoryInfo.GetAvailableCateList();
            List<YSWL.MALL.Model.Shop.Products.CategoryInfo> cateList = YSWL.MALL.BLL.Shop.Products.CategoryInfo.GetAvaCateList();
            if (cateList == null)
            {
                return FailResult(ResponseCode.NotFound);
            }
            List<YSWL.MALL.Model.Shop.Products.CategoryInfo> categoryInfos = cateList.FindAll(c => c.ParentCategoryId == cid);

            JsonObject baseJson;
            JsonArray result = new JsonArray();
            foreach (CategoryInfo item in categoryInfos)
            {
                baseJson = new JsonObject();
                baseJson.Put("id", item.CategoryId);
                baseJson.Put("title", item.Name);
                baseJson.Put("haschild", item.HasChildren);
                baseJson.Put("description", item.Description);
                baseJson.Put("pic", item.ImageUrl);
                if (item.HasChildren)
                {
                    baseJson.Put("childlist", GetCategory(item.CategoryId, cateList));
                }
                result.Add(baseJson);
            }
            return SuccessResult(result);
        }

        /// <summary>
        /// 获取商品品牌
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("product/brand")]
        public ResponseResult ProductBrand(string name = null)
        {
            string whereStr = string.Empty;
            if (!string.IsNullOrEmpty(name))
            {
                whereStr = $" BrandName like '%{name}%'";
            }
            List<YSWL.MALL.Model.Shop.Products.BrandInfo> listBrands = _brandBll.GetBrandList(whereStr, -1);
            JsonObject json;
            List<JsonObject> jsObjectList = new List<JsonObject>();
            foreach (var item in listBrands)
            {
                json = new JsonObject();
                json.Put("id", item.BrandId);
                json.Put("name", item.BrandName);
                json.Put("pic", item.Logo);
                jsObjectList.Add(json);
            }
            return SuccessResult(jsObjectList);
        }

        #endregion

        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("product/list")]
        public ResponseResult ProductList(int cid = 0, int brandid = 0, string keyword = "", string orderby = "hot", string price = "0-0", int? SaleStatus = null,string sku=null,
                                        int? page = 1, int pageNum = 10)
        {
            if (pageNum == 0)
            {
                pageNum = 10;
            }
            if (string.IsNullOrEmpty(page.ToString()))
            {
                page = 1;
            }
            ProductListModel model = new ProductListModel();
            keyword = YSWL.Common.InjectionFilter.SqlFilter(keyword) ?? "";
            if (cid > 0)
            {
                List<YSWL.MALL.Model.Shop.Products.CategoryInfo> cateList = YSWL.MALL.BLL.Shop.Products.CategoryInfo.GetAvailableCateList();
                YSWL.MALL.Model.Shop.Products.CategoryInfo categoryInfo =
                    cateList.FirstOrDefault(c => c.CategoryId == cid);
                if (categoryInfo != null)
                {
                    var pathArr = categoryInfo.Path.Split('|');
                    List<YSWL.MALL.Model.Shop.Products.CategoryInfo> categorysPath =
                        cateList.Where(c => pathArr.Contains(c.CategoryId.ToString())).OrderBy(c => c.Depth)
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
            int toalCount = _productBll.GetSearchCountExApp(cid, brandid, keyword, price, SaleStatus: SaleStatus);
            JsonObject result = new JsonObject();
            YSWL.Json.JsonArray jsonArray = new JsonArray();
            JsonObject json;
            //ViewBag.TotalCount = toalCount;
            result.Put("list_count", toalCount);
            List<YSWL.MALL.Model.Shop.Products.ProductInfo> list;
            try
            {
                if (String.IsNullOrEmpty(orderby))
                {
                    orderby = "default";
                }

                list = _productBll.GetSearchListExApp(cid, brandid, keyword, price, orderby, startIndex, endIndex, SaleStatus: SaleStatus);
            }
            catch (Exception ex)
            {
                YSWL.MALL.BLL.SysManage.LogHelp.AddErrorLog($"获取商品列表失败：{ex.Message}", ex.StackTrace);
                return ErrorResult(ResponseCode.InternalServerError, "获取数据异常");
            }
            //获取总条数
            if (toalCount < 1)
            {
                result.Put("productlist", null);
                return SuccessResult(result);
            }
            if (list == null)
            {
                result.Put("productlist", null);
                return SuccessResult(result);
            }
            foreach (YSWL.MALL.Model.Shop.Products.ProductInfo item in list)
            {
                json = new JsonObject();
                json.Put("id", item.ProductId);
                json.Put("name", item.ProductName);
                json.Put("pic", $"{_mdmPath}{item.ThumbnailUrl1}");
                json.Put("marketprice", item.MarketPrice.HasValue ? item.MarketPrice.Value.ToString("F") : "0.00");
                json.Put("saleprice", item.LowestSalePrice.ToString("F"));
                json.Put("brand", item.BrandName);
                json.Put("code", item.ProductCode);
                json.Put("commentCount", _reviewsBll.GetRecordCount("Status=1 and ProductId=" + item.ProductId));
                json.Put("hasSKU",item.HasSKU);
                json.Put("saleType", item.SaleStatus);
                json.Put("saleTypeStr", item.SaleStatus == 1 ? "正常" : item.SaleStatus == 0 ? "下架" : "删除");
                jsonArray.Add(json);
            }
            result.Put("productlist", jsonArray);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据仓库获取商品列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("product/getlist")]
        public ResponseResult GetProductList(int depotId = -1, int cid = 0, string keyword = "", string orderby = "hot",int saleType=-1,string sku=null,
                                        int? page = 1, int pageNum = 30)
        {
            if (pageNum == 0)
            {
                pageNum = 10;
            }
            if (!page.HasValue)
            {
                page = 1;
            }
            if (String.IsNullOrWhiteSpace(keyword))
            {
                keyword = "";
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
                    var pathArr = categoryInfo.Path.Split('|');
                    List<YSWL.MALL.Model.Shop.Products.CategoryInfo> categorysPath =
                        cateList.Where(c => pathArr.Contains(c.CategoryId.ToString())).OrderBy(c => c.Depth)
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
                list = _productBll.GetSearchListEx(cid, 0, keyword,"0-0", saleType, orderby, startIndex, endIndex,sku:sku);
            }
            catch (Exception ex)
            {
                Log.LogHelper.AddWarnLog(ex.Message, ex.StackTrace);
                YSWL.MALL.BLL.SysManage.LogHelp.AddErrorLog(ex.Message, ex.StackTrace);
                return ErrorResult(ResponseCode.ExecuteError);
            }
            if (list == null)
            {
                return SuccessResult(new string[] { });
            }
            List<Model.Shop.Products.SKUInfo> skulist;
            int stock;
            bool openAlertStock = YSWL.MALL.BLL.SysManage.ConfigSystem.GetBoolValueByCache("Shop_OpenAlertStock");
            foreach (YSWL.MALL.Model.Shop.Products.ProductInfo item in list)
            {
                skulist = _skuBll.GetProductSkuInfo(item.ProductId);//sku信息
                #region 远程加载数据图片
                if (WebApiApplication.IsAutoConn)
                {
                    item.ThumbnailUrl1 = string.IsNullOrWhiteSpace(item.ThumbnailUrl1) ? "" : item.ThumbnailUrl1;
                }
                #endregion
                json = new JsonObject();
                json.Put("id", item.ProductId);
                json.Put("name", item.ProductName);
                json.Put("pic", $"{_mdmPath?.Trim('/')}{string.Format(item.ThumbnailUrl1 ?? "", "T115X115_")}");
                json.Put("code", item.ProductCode);
                json.Put("marketprice", item.MarketPrice.HasValue ? item.MarketPrice.Value.ToString("F") : "0.00");
                json.Put("saleprice", item.LowestSalePrice.ToString("F"));
                json.Put("saleType", item.SaleStatus);
                json.Put("saleTypeStr", item.SaleStatus == 1 ? "正常" : item.SaleStatus == 0 ? "下架" : "删除");
                if (skulist != null && skulist.Count > 0)
                {
                    stock = 0;
                    if (openAlertStock) //开启警戒库存
                    {
                        skulist.ForEach(info =>
                        {
                            if (info.Stock > info.AlertStock)
                            {
                                stock += info.Stock;
                            }
                        });
                        json.Put("hasStock", stock > 0);
                    }
                    else
                    {
                        skulist.ForEach(info =>
                        {
                            stock += info.Stock;
                        });
                        json.Put("hasStock", stock > 0);
                    }
                }
                else
                {
                    json.Put("hasStock", false);
                }
                jsonArray.Add(json);
            }
            return SuccessResult(jsonArray);
        }

        /// <summary>
        /// 获取商品详情
        /// </summary>
        /// <param name="depotId"></param>
        /// <param name="sku"></param>
        /// <param name="pId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("product/detail")]
        public ResponseResult ProductDetailByPid(int depotId = -1, string sku = null, int pId = -1)
        {
            if (pId <= 0 && string.IsNullOrEmpty(sku))
            {
                return FailResult(ResponseCode.ParamError);
            }
            Model.Shop.Products.ProductInfo info = !string.IsNullOrEmpty(sku)
                ? _productBll.GetModelBySku(sku)
                : _productBll.GetModel(pId);
            YSWL.MALL.ViewModel.Shop.ProductModel model = new ProductModel
            {
                ProductInfo = info
            };
            if (model.ProductInfo == null)
            {
                return FailResult(ResponseCode.NotFound);
            }
            JsonArray jsonArray = new JsonArray();
            JsonObject json;
            JsonArray picArray = new JsonArray();
            YSWL.MALL.BLL.Shop.Products.ProductImage imageManage = new YSWL.MALL.BLL.Shop.Products.ProductImage();
            model.ProductImages = imageManage.ProductImagesList(info.ProductId);

            var productSkuModel = _skuBll.GetProductSKUInfoByProductIdAndDepotId(model.ProductInfo.ProductId, depotId, model.ProductInfo.SupplierId);

            if (productSkuModel?.ListSKUInfos == null || productSkuModel.ListSKUInfos.Count < 1)
            {
                return SuccessResult(new { });
            }
            string salesprice = productSkuModel.ListSKUInfos[0].SalePrice.ToString("F");
            #region 远程加载数据图片
            if (WebApiApplication.IsAutoConn)
            {
                model.ProductInfo.ThumbnailUrl1 = String.IsNullOrWhiteSpace(model.ProductInfo.ThumbnailUrl1) ? "" : model.ProductInfo.ThumbnailUrl1;

                model.ProductInfo.Description = String.IsNullOrWhiteSpace(model.ProductInfo.Description) ? "" : model.ProductInfo.Description;
            }
            #endregion
            JsonObject attr;
            json = new JsonObject();
            json.Put("id", model.ProductInfo.ProductId);
            json.Put("name", model.ProductInfo.ProductName);
            if (model.ProductInfo.MarketPrice != null)
                json.Put("marketprice", ((decimal)model.ProductInfo.MarketPrice).ToString("F"));
            json.Put("saleprice", salesprice);
            json.Put("xmltext", model.ProductInfo.Description);
            json.Put("saleType", model.ProductInfo.SaleStatus);
            json.Put("saleTypeStr", model.ProductInfo.SaleStatus == 1 ? "正常" : model.ProductInfo.SaleStatus == 0 ? "下架" : "删除");
            json.Put("leftTime", model.ProductInfo.ProSalesEndDate.ToString("yyyy年MM月dd日HH时mm分ss秒"));
            //json.Put("pic", model.ProductInfo.ThumbnailUrl1);
            json.Put("pic", $"{_mdmPath?.Trim('/')}{string.Format(model.ProductInfo.ThumbnailUrl1 ?? "", "T115X115_")}");
            foreach (YSWL.MALL.Model.Shop.Products.ProductImage pro in model.ProductImages)
            {
                if (WebApiApplication.IsAutoConn)
                {
                    picArray.Add(string.IsNullOrWhiteSpace(pro.ThumbnailUrl1) ? "" : pro.ThumbnailUrl1);
                }
                else
                {
                    picArray.Add(pro.ThumbnailUrl1);
                }
            }
            json.Put("bigPic", picArray);
            // json.Put("commentCount", reviewsBLL.GetRecordCount("Status=1 and ProductId=" + pId));
            json.Put("sku", productSkuModel.ListSKUInfos[0].SKU);
            JsonArray skuArray = new JsonArray();
            foreach (KeyValuePair<YSWL.MALL.Model.Shop.Products.AttributeInfo, SortedSet<YSWL.MALL.Model.Shop.Products.SKUItem>>
attrSkuItem in productSkuModel.ListAttrSKUItems)
            {
                foreach (YSWL.MALL.Model.Shop.Products.SKUItem skuItem in attrSkuItem.Value)
                {
                    attr = new JsonObject();
                    attr.Put("id", skuItem.ValueId);
                    attr.Put("key", skuItem.AttributeName);
                    attr.Put("value", skuItem.ValueStr);
                    if (WebApiApplication.IsAutoConn)
                    {
                        attr.Put("pic", _mdmPath?.TrimEnd('/') + (string.IsNullOrWhiteSpace(skuItem.ImageUrl) ? "" : skuItem.ImageUrl));
                    }
                    else
                    {
                        attr.Put("pic", _mdmPath?.TrimEnd('/') + skuItem.ImageUrl);
                    }
                    skuArray.Add(attr);
                }
            }
            if (skuArray.Length > 0)
            {
                json.Put("productProperty", skuArray);
            }

            //NO SKU ERROR
            if (productSkuModel.ListSKUInfos != null &&
                productSkuModel.ListSKUInfos.Count > 0 &&
                productSkuModel.ListSKUItems != null)
            {
                json.Put("hasSKU", true);
                json.Put("hasStock", productSkuModel.ListSKUInfos.Any(i => i.Stock > 0));
                //json.Put("hasStock",true);
                //木有开启SKU的情况
                if (productSkuModel.ListSKUItems.Count == 0)
                {
                    json.Put("hasSKU", false);
                    //判断库存是否满足
                    json.Put("hasStock", true);

                    //是否开启警戒库存判断
                    bool isOpenAlertStock =
                        YSWL.MALL.BLL.SysManage.ConfigSystem.GetBoolValueByCache("Shop_OpenAlertStock");
                    if (isOpenAlertStock &&
                        productSkuModel.ListSKUInfos[0].Stock <= productSkuModel.ListSKUInfos[0].AlertStock)
                    {
                        json.Put("hasStock", false);
                    }

                    if (productSkuModel.ListSKUInfos[0].Stock < 1)
                    {
                        json.Put("hasStock", false);
                    }
                    else
                    {
                        json.Put("stockcount", productSkuModel.ListSKUInfos[0].Stock);
                    }
                }
            }
            SkuInfoToJson(json, productSkuModel.ListSKUInfos, -1, model.ProductInfo.SupplierId);

            return SuccessResult(json);
        }

        /// <summary>
        /// 设置商品上下架
        /// </summary>
        /// <param name="status"></param>
        /// <param name="ids">1,2,3,4</param>
        /// <returns></returns>
        [HttpGet]
        [Route("product/salestatus")]
        public ResponseResult UpdateSaleStatus(int status = 1, string ids = null)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return FailResult(ResponseCode.ParamError);
            }
            var saleStatus = status == 1 ? YSWL.MALL.Model.Shop.Products.ProductSaleStatus.OnSale : YSWL.MALL.Model.Shop.Products.ProductSaleStatus.InStock;
            bool isSuccess = _productBll.UpdateList(ids, saleStatus);
            return isSuccess ? SuccessResult("执行成功") : FailResult(ResponseCode.ExecuteError);
        }

        #region 私有方法

        private JsonArray GetCategory(int parentId, List<YSWL.MALL.Model.Shop.Products.CategoryInfo> cateList)
        {
            JsonObject currjson;
            JsonArray array = new JsonArray();
            List<YSWL.MALL.Model.Shop.Products.CategoryInfo> categoryInfos = cateList.FindAll(info => info.ParentCategoryId == parentId);
            if (categoryInfos.Any())
            {
                foreach (YSWL.MALL.Model.Shop.Products.CategoryInfo item in categoryInfos)
                {
                    currjson = new JsonObject();
                    currjson.Put("id", item.CategoryId);
                    currjson.Put("haschild", item.HasChildren);
                    currjson.Put("parentId", item.ParentCategoryId);
                    currjson.Put("title", item.Name);
                    currjson.Put("pic", item.ImageUrl);
                    if (item.HasChildren)
                    {
                        currjson.Put("childlist", GetCategory(item.CategoryId, cateList));
                    }
                    array.Add(currjson);
                }
            }
            return array;
        }

        private YSWL.Json.JsonObject SkuInfoToJson(YSWL.Json.JsonObject json, List<YSWL.MALL.Model.Shop.Products.SKUInfo> list, int userId, int suppId)
        {
            if (list == null || list.Count < 1) return null;

            YSWL.Json.JsonObject jsonSku = new YSWL.Json.JsonObject();
            long[] key;
            int index;
            #region 计算会员等级价格
            if (suppId <= 0)
            {
                list = _ruleProductBll.GetRankSales(list, userId);
            }
            #endregion

            foreach (YSWL.MALL.Model.Shop.Products.SKUInfo item in list)
            {
                if (item.SkuItems == null || item.SkuItems.Count < 1) continue;

                //无库存SKU不提供给页面
                //是否开启警戒库存判断
                bool isOpenAlertStock = YSWL.MALL.BLL.SysManage.ConfigSystem.GetBoolValueByCache("Shop_OpenAlertStock");
                if (isOpenAlertStock && item.Stock <= item.AlertStock)
                {
                    continue;
                }
                //if (item.Stock < 1)
                //    continue;

                //组合SKU 的 ValueId
                key = new long[item.SkuItems.Count];
                index = 0;
                item.SkuItems.ForEach(xx => key[index++] = xx.ValueId);
                jsonSku.Accumulate(string.Join(",", key), new
                {
                    sku = item.SKU,
                    count = item.Stock > 0 ? item.Stock : 0,
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
            json.Put("skuData", jsonSku);
            return json;
        }

        #endregion
    }
}