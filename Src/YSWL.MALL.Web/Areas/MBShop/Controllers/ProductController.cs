using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using YSWL.MALL.BLL.Shop.Sales;
using YSWL.Common;
using YSWL.Components.Setting;
using YSWL.Json;
using YSWL.MALL.Model.Shop.Products;
using YSWL.MALL.ViewModel.Shop;
using YSWL.MALL.Web.Components.Setting.Shop;
using Webdiyer.WebControls.Mvc;
using YSWL.MALL.Web.Areas.MBShop.Filter;

namespace YSWL.MALL.Web.Areas.MBShop.Controllers
{
    [LoginAuth]
    public class ProductController : MBShopControllerBaseLogin
    {
        //
        // GET: /Mobile/Product/
        protected BLL.Shop.Products.ProductInfo productManage = new BLL.Shop.Products.ProductInfo();
        protected BLL.Shop.Products.CategoryInfo categoryManage = new BLL.Shop.Products.CategoryInfo();
        protected BLL.Shop.Order.OrderItems itemBll = new BLL.Shop.Order.OrderItems();
        protected BLL.Shop.Products.SKUInfo skuBll = new BLL.Shop.Products.SKUInfo();
        protected BLL.Shop.Products.BrandInfo brandBll = new YSWL.MALL.BLL.Shop.Products.BrandInfo();
        protected BLL.Shop.Products.ProductReviews reviewsBll = new YSWL.MALL.BLL.Shop.Products.ProductReviews();
        protected BLL.Shop.Products.ProductConsults conBll = new YSWL.MALL.BLL.Shop.Products.ProductConsults();
        protected BLL.Shop.Products.AttributeInfo attributeManage = new YSWL.MALL.BLL.Shop.Products.AttributeInfo();
        private int _waterfallSize = Globals.SafeInt(BLL.SysManage.ConfigSystem.GetValueByCache("MBSHOP_WaterfallSize"), 32);
        protected BLL.Shop.Products.BrandInfo brandManage = new BLL.Shop.Products.BrandInfo();
        protected YSWL.MALL.BLL.Shop.PromoteSales.CountDown countBll = new BLL.Shop.PromoteSales.CountDown();
        protected YSWL.MALL.BLL.Shop.PromoteSales.GroupBuy groupBuyBll = new BLL.Shop.PromoteSales.GroupBuy();
        protected YSWL.MALL.BLL.Shop.Sales.SalesRuleProduct ruleProductBll = new SalesRuleProduct();
        #region  商品列表
        public ActionResult Index(int cid = 0, int brandid = 0, string attrvalues = "0", string mod = "hot", string price = "",
                                  int startIndex = 1, string viewName = "Index", string ajaxViewName = "_ProductList")
        {
            ViewBag.IsOpenSku = BLL.SysManage.ConfigSystem.GetBoolValueByCache("Shop_AddProduct_OpenSku");
            ProductListModel model = new ProductListModel();
            //model.CategoryList = categoryManage.MainCategoryList(null);
            YSWL.MALL.Model.Shop.Products.CategoryInfo categoryInfo = null;
            ViewBag.ParentId = 0;
            if (cid > 0)
            {
                List<YSWL.MALL.Model.Shop.Products.CategoryInfo> cateList = YSWL.MALL.BLL.Shop.Products.CategoryInfo.GetAvailableCateList();
                categoryInfo = cateList.FirstOrDefault(c => c.CategoryId == cid);
                if (categoryInfo != null)
                {
                    var path_arr = categoryInfo.Path.Split('|');
                    List<YSWL.MALL.Model.Shop.Products.CategoryInfo> categorysPath =
                        cateList.Where(c => path_arr.Contains(c.CategoryId.ToString())).OrderBy(c => c.Depth)
                                .ToList();
                    model.CategoryPathList = categorysPath;
                    model.CurrentCateName = categoryInfo.Name;
                    if (categoryInfo.ParentCategoryId != 0)
                    {
                        ViewBag.parentCateName = categoryManage.GetFullNameByCache(categoryInfo.ParentCategoryId);
                    }
                    ViewBag.ParentId = categoryInfo.ParentCategoryId;
                }
            }
            if (brandid > 0)//有品牌过来
            {
                Model.Shop.Products.BrandInfo brandInfo = brandBll.GetModelByCache(brandid);
                ViewBag.BrandName = brandInfo.BrandName;
            }
            model.CurrentCid = cid;
            model.CurrentMod = mod;
            // model.CurrentCateName = cname == "all" ? "全部" : cname;

            #region RouteDataParam
            string dataParam = "{";
            foreach (KeyValuePair<string, object> item in Request.RequestContext.RouteData.Values)
            {
                dataParam += item.Key + ":'" + item.Value + "',";
            }
            dataParam = dataParam.TrimEnd(',') + "}";
            ViewBag.DataParam = dataParam;
            #endregion

            //计算分页起始索引
            startIndex = startIndex > 1 ? startIndex + 1 : 1;
            //计算分页结束索引
            int endIndex = startIndex > 1 ? startIndex + _waterfallSize - 1 : _waterfallSize;
            int toalCount = productManage.GetProductsCountEx(cid, brandid, attrvalues, price);
            ViewBag.totalCount = toalCount.ToString();
            //瀑布流Index
            ViewBag.CurrentPageAjaxStartIndex = endIndex;
            ViewBag.CurrentPageAjaxEndIndex = toalCount;
            ViewBag.CurrentPageAjaxSize = _waterfallSize;

            model.ProductList = productManage.GetProductsListEx(cid, brandid, attrvalues, price, mod, startIndex, endIndex);

            #region 加载商品促销形式
            if (model.ProductList != null)
            {
                string mdmUrl = Common.ConfigHelper.GetConfigString("MDM_Url");
                foreach (var item in model.ProductList)
                {
                    //isOpenLogin
                    item.ruleType = (int)ruleProductBll.GetRuleType(item.ProductId, currentUser!=null?currentUser.UserID:-1);
                    #region 远程加载数据图片
                    if (MvcApplication.IsAutoConn)
                    {
                        item.ThumbnailUrl1 = String.IsNullOrWhiteSpace(item.ThumbnailUrl1)? item.ThumbnailUrl1: item.ThumbnailUrl1.Replace("/"+MvcApplication.UploadFolder+"/", mdmUrl + "/"+MvcApplication.UploadFolder+"/");
                        item.ImageUrl = String.IsNullOrWhiteSpace(item.ImageUrl) ? item.ImageUrl : item.ImageUrl.Replace("/"+MvcApplication.UploadFolder+"/", mdmUrl + "/"+MvcApplication.UploadFolder+"/");
                    }
                    #endregion
                }
            }
            #endregion


            ViewBag.IsMultiDepot = IsMultiDepot;//是否分仓
            #region SEO 优化设置
            IPageSetting pageSetting = PageSetting.GetCategorySetting(categoryInfo);
            //pageSetting.Replace(
            //    new[] { PageSetting.RKEY_CNAME, model.CurrentCateName }, 
            //    new[] { PageSetting.RKEY_CID, model.CurrentCid.ToString() }); //分类名称
            ViewBag.Title = pageSetting.Title;
            ViewBag.Keywords = pageSetting.Keywords;
            ViewBag.Description = pageSetting.Description;
            #endregion
            //检测Ajax请求, 进行无刷新分页
            if (Request.IsAjaxRequest())
                return PartialView(ajaxViewName, model);
            return View(viewName, model);
        }
        #endregion

        #region  商品分类
        public ActionResult CategoryList(int parentId = 0, string viewName = "CategoryList")
        {
            List<YSWL.MALL.Model.Shop.Products.CategoryInfo> cateList = YSWL.MALL.BLL.Shop.Products.CategoryInfo.GetAvaCateList();
            List<YSWL.MALL.Model.Shop.Products.CategoryInfo> categoryInfos = cateList.Where(c => c.ParentCategoryId == parentId).OrderBy(c => c.DisplaySequence).ToList();
            YSWL.MALL.Model.Shop.Products.CategoryInfo parentInfo =
                cateList.FirstOrDefault(c => c.CategoryId == parentId);
            ViewBag.ParentId = -1;
            if (parentInfo != null)
            {
                ViewBag.CurrentName = parentInfo.Name;
                ViewBag.ParentId = parentInfo.ParentCategoryId;
            }
            #region 远程加载数据图片
            if (MvcApplication.IsAutoConn)
            {
                string mdmUrl = Common.ConfigHelper.GetConfigString("MDM_Url");
                foreach (var item in categoryInfos)
                {
                    item.ImageUrl = String.IsNullOrWhiteSpace(item.ImageUrl) ? item.ImageUrl : (item.ImageUrl.StartsWith(mdmUrl)? item.ImageUrl: item.ImageUrl.Replace("/"+MvcApplication.UploadFolder+"/", mdmUrl + "/"+MvcApplication.UploadFolder+"/"));
                }
            }
            #endregion 

            return View(viewName, categoryInfos);
        }
        #endregion

        #region Detail
        public ActionResult Detail(int ProductId = -1, string viewName = "Detail")
        {
            //是否开启分仓
            ViewBag.IsMultiDepot = IsMultiDepot;

            YSWL.MALL.ViewModel.Shop.ProductModel model = new ProductModel();
            model.ProductInfo = productManage.GetModel(ProductId);
            BLL.Shop.Products.ProductImage imageManage = new BLL.Shop.Products.ProductImage();
            model.ProductImages = imageManage.ProductImagesList(ProductId);

            #region 远程加载数据图片
            if (MvcApplication.IsAutoConn)
            {
                string mdmUrl = Common.ConfigHelper.GetConfigString("MDM_Url");
                if (model.ProductImages != null)
                {
                    foreach (var item in model.ProductImages)
                    {
                        item.ImageUrl = String.IsNullOrWhiteSpace(item.ImageUrl) ? item.ImageUrl : item.ImageUrl.Replace("/"+MvcApplication.UploadFolder+"/", mdmUrl + "/"+MvcApplication.UploadFolder+"/");
                        item.ThumbnailUrl1 = String.IsNullOrWhiteSpace(item.ThumbnailUrl1) ? item.ThumbnailUrl1 : item.ThumbnailUrl1.Replace("/"+MvcApplication.UploadFolder+"/", mdmUrl + "/"+MvcApplication.UploadFolder+"/");
                    }
                }
                if (model.ProductInfo != null)
                {
                    model.ProductInfo.ThumbnailUrl1 = String.IsNullOrWhiteSpace(model.ProductInfo.ThumbnailUrl1) ? model.ProductInfo.ThumbnailUrl1 : model.ProductInfo.ThumbnailUrl1.Replace("/"+MvcApplication.UploadFolder+"/", mdmUrl + "/"+MvcApplication.UploadFolder+"/");
                    model.ProductInfo.ImageUrl = String.IsNullOrWhiteSpace(model.ProductInfo.ImageUrl ) ? model.ProductInfo.ImageUrl  : model.ProductInfo.ImageUrl.Replace("/"+MvcApplication.UploadFolder+"/", mdmUrl + "/"+MvcApplication.UploadFolder+"/");
                }

            }
            #endregion

            model.ProductSkus = skuBll.GetProductSkuInfo(ProductId);

            BLL.Shop.Products.BrandInfo brandManage = new BLL.Shop.Products.BrandInfo();
            if (model.ProductInfo == null)
            {
                return RedirectToAction("Index", "Home");
            }

            #region 商品是否参与了促销活动，如团购和限时抢购
            //判断是否参与了促销活动
            YSWL.MALL.Model.Shop.PromoteSales.CountDown countDownModel = countBll.GetActModel(ProductId);
            if (countDownModel != null)
            {
                return RedirectToAction("ProSaleDetail", "Product", new { id = countDownModel.CountDownId });
            }
            //是否参与了团购 （此部分比较麻烦，由于与地区相关，且无法定位用户的地区， 暂不跳转）

            #endregion
            //一键显示会员价格
            if (currentUser != null && currentUser.UserType != "AA" && model.ProductInfo.SupplierId <= 0 && model.ProductSkus != null&&model.ProductSkus.Count>0)
            {
                model.ProductSkus[0].RankPrice = ruleProductBll.GetUserPrice(ProductId, model.ProductSkus[0].SalePrice, currentUser.UserID);
            }

            Model.Shop.Products.BrandInfo brandModel = brandManage.GetModelByCache(model.ProductInfo.BrandId);
            if (brandModel != null)
            {
                ViewBag.BrandName = brandModel.BrandName;
            }

            #region 分类导航

            BLL.Shop.Products.ProductCategories productCategoriesManage = new BLL.Shop.Products.ProductCategories();
            Model.Shop.Products.ProductCategories categoryModel = productCategoriesManage.GetModel(ProductId);
            if (categoryModel != null)
            {
                List<YSWL.MALL.Model.Shop.Products.CategoryInfo> AllCateList = YSWL.MALL.BLL.Shop.Products.CategoryInfo.GetAvailableCateList();
                var currentModel = AllCateList.FirstOrDefault(c => c.CategoryId == categoryModel.CategoryId);
                if (currentModel != null)
                {
                    var cateIds = currentModel.Path.Split('|');
                    List<Model.Shop.Products.CategoryInfo> list =
                        AllCateList.Where(c => cateIds.Contains(c.CategoryId.ToString())).OrderBy(c => c.Depth).ToList();
                    System.Text.StringBuilder sbPath = new System.Text.StringBuilder();
                    System.Text.StringBuilder CategoryStr = new System.Text.StringBuilder();
                    if (list != null && list.Count > 0)
                    {
                        foreach (var categoryInfo in list)
                        {
                            CategoryStr.AppendFormat("<a href='/Product/" + categoryInfo.CategoryId + "'>{0}</a> > ", categoryInfo.Name);
                        }
                    }
                    ViewBag.Cid = categoryModel.CategoryId;
                    ViewBag.PathInfo = sbPath.ToString();
                    ViewBag.CategoryStr = CategoryStr.ToString();
                }
            }



            #endregion 分类导航

            #region SEO设置
            PageSetting pageSetting = PageSetting.GetProductSetting(model.ProductInfo);
            ViewBag.Title = pageSetting.Title;
            ViewBag.Keywords = pageSetting.Keywords;
            ViewBag.Description = pageSetting.Description;

            #endregion SEO设置

            #region   推广信息

            ViewBag.Spread = false;
            string r = Request.Params["r"];
            if (!String.IsNullOrWhiteSpace(r))
            {
                int userId = Common.Globals.SafeInt(YSWL.Common.UrlOper.Base64Decrypt(r), 0);
                if (currentUser != null && userId == currentUser.UserID)
                {
                    ViewBag.Spread = true;
                }
            }

            #endregion

            ViewBag.ConsultCount = conBll.GetRecordCount("Status=1 and ProductId=" + ProductId);
            ViewBag.CommentCount = reviewsBll.GetRecordCount("Status=1 and ProductId=" + ProductId);
            ViewBag.IsMultiDepot = IsMultiDepot;

            return View(viewName, model);
        }
        /// <summary>
        /// 商品详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ProductDesc(int id)
        {
            YSWL.MALL.Model.Shop.Products.ProductInfo productInfo = productManage.GetModel(id);
            if (productInfo == null)
            {
                return RedirectToAction("Index", "Home");
            }

            #region SEO设置
            PageSetting pageSetting = PageSetting.GetProductSetting(productInfo);
            ViewBag.Title = pageSetting.Title;
            ViewBag.Keywords = pageSetting.Keywords;
            ViewBag.Description = pageSetting.Description;
            #endregion SEO设置

            if (MvcApplication.IsAutoConn)
            {
                string mdmUrl = Common.ConfigHelper.GetConfigString("MDM_Url");
                productInfo.Description = String.IsNullOrWhiteSpace(productInfo.Description) ? productInfo.Description : productInfo.Description.Replace("/ueditor/net/upload/", mdmUrl + "/ueditor/net/upload/");
            }
            return View(productInfo);
        }

        #endregion

        #region 关联商品
        public PartialViewResult ProductRelation(int id, int top = 12, string viewName = "_ProductRelation")
        {
            List<YSWL.MALL.Model.Shop.Products.ProductInfo> productList = productManage.RelatedProductsList(id, top);
            return PartialView(viewName, productList);
        }
        #endregion

        #region 商品SKU规格选择

        public ActionResult OptionSKU(long productId, int SuppId, string viewName = "_OptionSKU")
        {
            if (productId < 1) return new EmptyResult();
            ViewModel.Shop.ProductSKUModel productSKUModel = skuBll.GetProductSKUInfoByProductId(productId);
            //NO SKU ERROR
            if (productSKUModel == null) return new EmptyResult();
            //NO SKU ERROR
            if (productSKUModel.ListSKUInfos == null || productSKUModel.ListSKUInfos.Count < 1 ||
                productSKUModel.ListSKUItems == null)
                return new EmptyResult();

            #region 远程加载数据图片
            if (MvcApplication.IsAutoConn)
            {
                string mdmUrl = Common.ConfigHelper.GetConfigString("MDM_Url");
                foreach (var item in productSKUModel.ListSKUItems)
                {
                    item.ImageUrl = String.IsNullOrWhiteSpace(item.ImageUrl) ? item.ImageUrl : item.ImageUrl.Replace("/"+MvcApplication.UploadFolder+"/", mdmUrl + "/"+MvcApplication.UploadFolder+"/");
                }
            }
            #endregion

            ViewBag.HasSKU = true;

            //木有开启SKU的情况
            if (productSKUModel.ListSKUItems.Count == 0)
            {
                ViewBag.HasSKU = false;
                return View(viewName, productSKUModel);
            }

            ViewBag.SKUJson = SKUInfoToJson(productSKUModel.ListSKUInfos, SuppId).ToString();

            return View(viewName, productSKUModel);
        }
        protected Json.JsonObject SKUInfoToJson(List<Model.Shop.Products.SKUInfo> list, int SuppId)
        {
            if (list == null || list.Count < 1) return null;
            Json.JsonObject json = new Json.JsonObject();

            Json.JsonObject jsonSKU = new Json.JsonObject();
            long[] key;
            int index;

            #region 计算会员等级价格

            if (currentUser != null && currentUser.UserType != "AA" && SuppId <= 0)
            {
                list = ruleProductBll.GetRankSales(list, currentUser.UserID);
            }

            #endregion

            foreach (Model.Shop.Products.SKUInfo item in list)
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
            json.Put("Default", new
            {
                minPrice = list[0].SalePrice,
                maxPrice = list[list.Count - 1].SalePrice,
                minRankPrice = list[0].RankPrice,
                maxRankPrice = list[list.Count - 1].RankPrice,
            });
            json.Put("SKUDATA", jsonSKU);
            return json;
        }
        #endregion

        #region 商品评论
        public ActionResult Comments(int id, int pageIndex = 1, string viewName = "Comments")
        {
            int _pageSize = 15;

            //计算分页起始索引
            int startIndex = pageIndex > 1 ? (pageIndex - 1) * _pageSize + 1 : 1;
            ViewBag.ProductName = productManage.GetProductName(id);
            //计算分页结束索引
            int endIndex = pageIndex * _pageSize;
            int totalCount = 0;

            //获取总条数
            totalCount = reviewsBll.GetRecordCount("Status=1 and ProductId=" + id);
            ViewBag.TotalCount = totalCount;
            if (totalCount == 0)
            {
                return View(viewName);//NO DATA
            }
            List<YSWL.MALL.Model.Shop.Products.ProductReviews> productReviewses = reviewsBll.GetReviewsByPage(id, " CreatedDate desc", startIndex, endIndex);

            PagedList<YSWL.MALL.Model.Shop.Products.ProductReviews> lists = new PagedList<YSWL.MALL.Model.Shop.Products.ProductReviews>(productReviewses, pageIndex, _pageSize, totalCount);
            //检测Ajax请求, 进行无刷新分页
            if (Request.IsAjaxRequest())
                return View(viewName, lists);
            return View(viewName, lists);
        }
        #endregion

        #region 商品咨询
        public ActionResult Consults(int id, int pageIndex = 1, string viewName = "Consults")
        {

            int _pageSize = 4;
            ViewBag.ProductName = productManage.GetProductName(id);
            //计算分页起始索引
            int startIndex = pageIndex > 1 ? (pageIndex - 1) * _pageSize + 1 : 1;

            //计算分页结束索引
            int endIndex = pageIndex * _pageSize;
            int totalCount = 0;

            //获取总条数
            totalCount = conBll.GetRecordCount("Status=1 and ProductId=" + id);
            ViewBag.TotalCount = totalCount;
            if (totalCount == 0)
            {
                return PartialView(viewName);//NO DATA
            }
            List<YSWL.MALL.Model.Shop.Products.ProductConsults> productConsults = conBll.GetConsultationsByPage(id, " CreatedDate desc", startIndex, endIndex);

            PagedList<YSWL.MALL.Model.Shop.Products.ProductConsults> lists = new PagedList<YSWL.MALL.Model.Shop.Products.ProductConsults>(productConsults, pageIndex, _pageSize, totalCount);
            //检测Ajax请求, 进行无刷新分页
            if (Request.IsAjaxRequest())
                return PartialView(viewName, lists);
            return PartialView(viewName, lists);
        }
        #endregion

        #region 条件筛选
        public ActionResult Filter(int id = 0)
        {
            #region SEO 优化设置
            ViewBag.Title = "商品筛选";
            #endregion
            return View();
        }
        #endregion

        #region 商品扩展属性
        public ActionResult OptionAttr(long productId, string viewName = "_OptionAttr")
        {
            if (productId < 1) return new EmptyResult();
            List<YSWL.MALL.Model.Shop.Products.AttributeInfo> model = attributeManage.GetAttributeInfoListByProductId(productId);
            return View(viewName, model);
        }
        #endregion

        #region 得到推荐商品数据
        public ActionResult ProductList(int Cid = 0, YSWL.MALL.Model.Shop.Products.ProductRecType RecType = ProductRecType.IndexRec, int pageIndex = 1, int pageSize = 15, string viewName = "Index", string ajaxViewName = "_ProductList")
        {
            List<YSWL.MALL.Model.Shop.Products.CategoryInfo> cateList = YSWL.MALL.BLL.Shop.Products.CategoryInfo.GetAvailableCateList();
            ProductListModel model = new ProductListModel();
            YSWL.MALL.Model.Shop.Products.CategoryInfo categoryInfo = cateList.FirstOrDefault(c => c.CategoryId == Cid);
            if (categoryInfo != null)
            {
                ViewBag.CategoryName = categoryInfo.Name;
            }
            ViewBag.RecType = RecType;
            int toalCount = productManage.GetProductRecCount(RecType, Cid);
            ViewBag.totalCount = toalCount.ToString();

            int startIndex = pageIndex > 1 ? (pageIndex - 1) * pageSize : 1;
            List<YSWL.MALL.Model.Shop.Products.ProductInfo> productList = productManage.GetProductRecList(RecType, Cid, -1);
            List<YSWL.MALL.Model.Shop.Products.ProductInfo> list = productList.Skip(startIndex).Take(pageSize).ToList();
            //分页获取数据
            model.ProductPagedList = list.ToPagedList(
                pageIndex,
                pageSize);
            if (Request.IsAjaxRequest())
                return PartialView(ajaxViewName, model);

            return View(viewName, model);
        }
        #endregion

        #region  批发规则
        public PartialViewResult WholeSale(int pId, int suppId, string viewName = "_WholeSale")
        {
            //批发规则  只有自营商品使用 
            if (suppId > 0)
            {
                return null;
            }
            YSWL.MALL.BLL.Shop.Sales.SalesRuleProduct ruleBll = new YSWL.MALL.BLL.Shop.Sales.SalesRuleProduct();
            //isOpenLogin
            if (currentUser != null)
            {
                return PartialView(viewName, ruleBll.GetSalesRuleByCache(pId, CurrentUser.UserID));
            }
            return PartialView(viewName);
        }
        #endregion


        #region Ajax 获取库存
        /// <summary>
        /// 根据商品ID获取分仓仓库库存
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="regionId"></param>
        /// <param name="suppId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetSKUInfos(long productId, int suppId = 0)
        {
            if (productId < 1) return new EmptyResult();
            ViewModel.Shop.ProductSKUModel productSKUModel =
                YSWL.MALL.BLL.Shop.Products.StockHelper.GetProductSKUInfo(productId, GetRegionId, suppId);
            //NO SKU ERROR
            if (productSKUModel == null) return new EmptyResult();
            //NO SKU ERROR
            if (productSKUModel.ListSKUInfos == null || productSKUModel.ListSKUInfos.Count < 1 ||
                productSKUModel.ListSKUItems == null)
                return new EmptyResult();

            ViewBag.HasSKU = true;

            //木有开启SKU的情况  Ajax 返回空js停止处理
            if (productSKUModel.ListSKUItems.Count == 0) return new EmptyResult();

            //DONE: 生成JsonSKU数据结构
            return Content(SKUInfoToJson(productSKUModel.ListSKUInfos, suppId).ToString());
        }
        /// <summary>
        /// 获取SKU库存
        /// </summary>
        /// <param name="sku"></param>
        /// <param name="regionId"></param>
        /// <param name="suppId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetSKUStock(string sku, int suppId = 0)
        {
            int stock = YSWL.MALL.BLL.Shop.Products.StockHelper.GetSkuStockByCache(sku, GetRegionId, suppId);
            return Content(stock.ToString());
        }
        #endregion

        #region 增加浏览量
        /// <summary>
        /// 增加浏览量
        /// </summary>
        /// <param name="Fm"></param>
        [HttpPost]
        public void GetPvCount(FormCollection Fm)
        {
            long pId = Globals.SafeLong(Fm["pId"], 0);
            JsonObject json = new JsonObject();
            if (pId <= 0)
            {
                json.Accumulate("STATUS", "Fail");
                json.Accumulate("DATA", 0);
                Response.Write(json.ToString());
                return;
            }

            long count = productManage.UpdatePV(pId);
            json.Accumulate("STATUS", "SUCCESS");
            json.Accumulate("DATA", count);
            Response.Write(json.ToString());
        }
        #endregion


        #region 获取参与批发规则的商品
        public ActionResult SalesRuleP(int startIndex = 1, string viewName = "SalesRuleP", string ajaxViewName = "")
        {
            ViewBag.IsMultiDepot = IsMultiDepot;//是否分仓
            bool isAjax = Request.IsAjaxRequest();
            //计算分页起始索引
            startIndex = startIndex > 1 ? startIndex + 1 : 1;
            //计算分页结束索引
            int endIndex = startIndex > 1 ? startIndex + _waterfallSize - 1 : _waterfallSize;
            if (!isAjax)//非ajax请求
            {
                //总条数
                //isOpenLogin
                int toalCount = currentUser!=null?productManage.GetSalesRuleProdCount(CurrentUser.UserID):0;
                //瀑布流Index
                ViewBag.CurrentPageAjaxStartIndex = endIndex;
                ViewBag.CurrentPageAjaxEndIndex = toalCount;
                ViewBag.CurrentPageAjaxSize = _waterfallSize;
            }

            List<Model.Shop.Products.ProductInfo> list = new List<ProductInfo>();
            //isOpenLogin
            if (currentUser != null)
            {
                list = productManage.GetSalesRuleProductsList(startIndex, endIndex, CurrentUser.UserID);
                #region 加载商品促销形式
                if (list != null)
                {
                    string mdmUrl = Common.ConfigHelper.GetConfigString("MDM_Url");
                    foreach (var item in list)
                    {
                        item.ruleType = (int)ruleProductBll.GetRuleType(item.ProductId, currentUser.UserID);
                        #region 远程加载数据图片
                        if (MvcApplication.IsAutoConn)
                        {
                            item.ThumbnailUrl1 = String.IsNullOrWhiteSpace(item.ThumbnailUrl1) ? item.ThumbnailUrl1 : item.ThumbnailUrl1.Replace("/"+MvcApplication.UploadFolder+"/", mdmUrl + "/"+MvcApplication.UploadFolder+"/");
                            item.ImageUrl = String.IsNullOrWhiteSpace(item.ImageUrl) ? item.ImageUrl : item.ImageUrl.Replace("/"+MvcApplication.UploadFolder+"/", mdmUrl + "/"+MvcApplication.UploadFolder+"/");
                        }
                        #endregion
                    }
                }
                #endregion
            }

            //检测Ajax请求
            if (isAjax)
            {
                return PartialView(ajaxViewName, list);
            }
            return View(viewName, list);
        }
        #endregion




    }
}
