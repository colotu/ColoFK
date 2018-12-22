using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YSWL.MALL.BLL.Settings;
using YSWL.MALL.BLL.Shop.Products;
using YSWL.MALL.Model.Shop.Products;
using YSWL.MALL.Model.SysManage;
using YSWL.MALL.Web.Areas.MBShop.Filter;
using YSWL.MALL.Web.Components.Setting.Shop;
using YSWL.Web;
using CategoryInfo = YSWL.MALL.Model.Shop.Products.CategoryInfo;

namespace YSWL.MALL.Web.Areas.MBShop.Controllers
{
    [LoginAuth]
    public class PartialController : MBShopControllerBaseLogin
    {
        //
        // GET: /Mobile/Partial/
        private BLL.Shop.Supplier.SupplierInfo supplierBll = new BLL.Shop.Supplier.SupplierInfo();
        private BLL.Shop.Activity.ActivityInfo activInfoBll = new BLL.Shop.Activity.ActivityInfo();
        protected BLL.Shop.Products.SKUInfo skuBll = new BLL.Shop.Products.SKUInfo();
        protected YSWL.MALL.BLL.Shop.Sales.SalesRuleProduct ruleProductBll = new BLL.Shop.Sales.SalesRuleProduct();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Footer(string viewName = "_Footer")
        {

            if (currentUser!=null)
            {
                ViewBag.usernickname = currentUser.NickName;//用户已登录
            }
            //是否开启微信自动登录
            ViewBag.IsAutoLogin = Common.Globals.SafeBool(WeChat.BLL.Core.Config.GetValueByCache("WeChat_AutoLogin", -1, "AA"), false);
            ViewBag.IsHideMenu = Common.Globals.SafeBool(WeChat.BLL.Core.Config.GetValueByCache("WeChat_HideMenu", -1, "AA"), false);
            return PartialView(viewName);
        }

        public PartialViewResult Header(string viewName = "_Header")
        {
            ViewBag.Name = BLL.SysManage.ConfigSystem.GetValueByCache("Opertors_Name", ApplicationKeyType.Shop);
            ViewBag.MShopName = BLL.SysManage.ConfigSystem.GetValueByCache("WeChat_MBShop_Name");
            ViewBag.MShopLogo = BLL.SysManage.ConfigSystem.GetValueByCache("WeChat_MBhop_Index_Logo");
            return PartialView(viewName);
        }
        #region 广告位
        public PartialViewResult AdDetail(int id, string ViewName = "_IndexAd")
        {
            YSWL.MALL.BLL.Settings.Advertisement bll = new Advertisement();
            List<YSWL.MALL.Model.Settings.Advertisement> list = bll.GetListByAidCache(id);
            return PartialView(ViewName, list);
        }

        /// <summary>
        /// 小广告
        /// </summary>
        /// <param name="AdvPositionId"></param>
        /// <returns></returns>
        public PartialViewResult AD(int AdvPositionId, string viewName = "_AD")
        {
            BLL.Settings.Advertisement bllAdvertisement = new Advertisement();
            Model.Settings.Advertisement model = bllAdvertisement.GetModelByAdvPositionId(AdvPositionId);
            return PartialView(viewName, model);
        }
        #endregion

        #region 菜单导航
        public PartialViewResult Navigation(string viewName = "_Navigation")
        {
            return PartialView(viewName);
        }
        #endregion 
 

        #region 推荐商品
        public PartialViewResult ProductRec(ProductRecType Type = ProductRecType.Recommend, int Cid = 0, int Top = 5, string ViewName = "_ProductRec")
        {
            ViewBag.IsMultiDepot = IsMultiDepot;//是否分仓
            YSWL.MALL.BLL.Shop.Products.ProductInfo productBll = new YSWL.MALL.BLL.Shop.Products.ProductInfo();
            List<YSWL.MALL.Model.Shop.Products.ProductInfo> productList = productBll.GetProductRecList(Type, Cid, Top);
            List<YSWL.MALL.Model.Shop.Products.ProductInfo> prolist = new List<Model.Shop.Products.ProductInfo>();
            #region 是否静态化
            string IsStatic = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("ShopProductStatic");
            string basepath = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.Shop);
            if (productList != null)
            {
                foreach (var item in productList)
                {
                    if (IsStatic == "1")
                    {
                        item.SeoUrl = PageSetting.GetProStaticUrl(Convert.ToInt32(item.ProductId.ToString())).Replace("//", "/");
                    }
                    else if (IsStatic == "2")
                    {
                        item.SeoUrl = basepath + "Product-" + item.ProductId + ".html";
                    }
                    else
                    {
                        item.SeoUrl = basepath + "Product/Detail/" + item.ProductId;
                    }
                    prolist.Add(item);
                }
                return PartialView(ViewName, prolist);
            }
            else
            {
                return PartialView(ViewName, productList);
            }

            #endregion

        }
        #endregion

        public PartialViewResult CategoryList(int Cid = 0, int Top = 10, string ViewName = "_CategoryList")
        {
            List<YSWL.MALL.Model.Shop.Products.CategoryInfo> cateList = YSWL.MALL.BLL.Shop.Products.CategoryInfo.GetAvailableCateList();
            List<YSWL.MALL.Model.Shop.Products.CategoryInfo> parentList = cateList.Where(c => c.Depth == 1).OrderBy(c=>c.DisplaySequence).ToList();
            List<YSWL.MALL.Model.Shop.Products.CategoryInfo> categoryInfos=new List<CategoryInfo>();//= cateList.Where(c => c.ParentCategoryId == Cid).ToList();
            if (parentList.Count > 0)
            {
                List<YSWL.MALL.Model.Shop.Products.CategoryInfo> sonList;
                foreach (var item in parentList)
                {
                    sonList = cateList.Where(c => c.ParentCategoryId == item.CategoryId).OrderBy(c=>c.DisplaySequence).ToList();
                    categoryInfos.Add(item);
                    categoryInfos.AddRange(sonList);
                }
            }
            return PartialView(ViewName, categoryInfos);
        }

        #region  商品分类
        public PartialViewResult CateList(int parentId = 0, string viewName = "_CateList")
        {
            List<YSWL.MALL.Model.Shop.Products.CategoryInfo> cateList = YSWL.MALL.BLL.Shop.Products.CategoryInfo.GetAvailableCateList();
            List<YSWL.MALL.Model.Shop.Products.CategoryInfo> categoryInfos = cateList.Where(c => c.ParentCategoryId == parentId).OrderBy(c => c.DisplaySequence).ToList();
            YSWL.MALL.Model.Shop.Products.CategoryInfo parentInfo =
                cateList.FirstOrDefault(c => c.CategoryId == parentId);
            ViewBag.ParentId = -1;
            if (parentInfo != null)
            {
                ViewBag.CurrentName = parentInfo.Name;
                ViewBag.ParentId = parentInfo.ParentCategoryId;
            }
            return PartialView(viewName, categoryInfos);
        }
        #endregion 
 
        #region 商品SKU规格选择

        public ActionResult OptionSKU(long productId, int SuppId=0, string viewName = "_OptionSKU")
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
        public static bool IsOpenMultiDepot()
        {
            return YSWL.MALL.BLL.Shop.Service.CommonHelper.OpenMultiDepot(); 
        }

    }
}
