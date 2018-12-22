using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YSWL.Components.Setting;
using YSWL.MALL.Model.Shop.Products;
using YSWL.MALL.Model.SysManage;
using YSWL.MALL.ViewModel.Shop;
using YSWL.MALL.Web.Components.Setting.Shop;
using Webdiyer.WebControls.Mvc;
using YSWL.Web;


namespace YSWL.MALL.Web.Areas.BShop.Controllers
{
    public class SearchController : BShopControllerBase
    {
        //
        // GET: /Shop/Search/
                #region 全局变量

        private  BLL.Shop.Products.ProductInfo productManage = new BLL.Shop.Products.ProductInfo();
        private  BLL.Shop.Products.BrandInfo brandBll=new YSWL.MALL.BLL.Shop.Products.BrandInfo();
        private  BLL.Shop.Supplier.SupplierInfo suppBll = new BLL.Shop.Supplier.SupplierInfo();
        private YSWL.MALL.BLL.Shop.Favorite favoBll = new BLL.Shop.Favorite();
 
        #endregion

        public ActionResult Index(int cid = 0, int brandid = 0, string keyword = "", string mod = "default", string price = "0-0",
                                        int? pageIndex = 1, int pageSize = 20,
                                        string viewName = "Index", string ajaxViewName = "_ProductList")
        {
            ProductListModel model = new ProductListModel();
            keyword= YSWL.Common.InjectionFilter.SqlFilter(keyword);
            if (String.IsNullOrWhiteSpace(keyword))
            {
                return  RedirectToAction("Index", "Home");
            }
            //model.CategoryList = categoryManage.MainCategoryList(null);
            if (cid > 0)
            {
                List<YSWL.MALL.Model.Shop.Products.CategoryInfo> cateList = YSWL.MALL.BLL.Shop.Products.CategoryInfo.GetAvailableCateList();
                YSWL.MALL.Model.Shop.Products.CategoryInfo categoryInfo =
                    cateList.FirstOrDefault(c => c.CategoryId == cid);
                if (categoryInfo != null)
                {
                    List<YSWL.MALL.Model.Shop.Products.CategoryInfo> categorysPath =
                        cateList.Where(c => categoryInfo.Path.Contains(c.Path + "|") || c.Path == categoryInfo.Path)
                                .ToList();
                    model.CategoryPathList = categorysPath;
                }
            }
            model.CurrentCid = cid;
            model.CurrentMod = mod;
            //  model.CurrentCateName = cname == "all" ? "全部" : cname;
            #region RouteDataParam
            string dataParam = "{";
            foreach (KeyValuePair<string, object> item in Request.RequestContext.RouteData.Values)
            {
                dataParam += item.Key + ":'" + item.Value + "',";
            }
            dataParam = dataParam.TrimEnd(',') + "}";
            ViewBag.DataParam = dataParam;
            #endregion

            //重置页面索引
            pageIndex = pageIndex.HasValue && pageIndex.Value > 1 ? pageIndex.Value : 1;

            //计算分页起始索引
            int startIndex = pageIndex.Value > 1 ? (pageIndex.Value - 1) * pageSize + 1 : 1;
            //计算分页结束索引
            int endIndex = pageIndex.Value * pageSize;

            int toalCount = productManage.GetSearchCountEx(cid, brandid, keyword, price);
            ViewBag.ToalCount = toalCount;
            List<Model.Shop.Products.ProductInfo> list=productManage.GetSearchListEx(cid, brandid, keyword, price, mod, startIndex, endIndex);

            #region 是否静态化
            List<YSWL.MALL.Model.Shop.Products.ProductInfo> prolist = new List<Model.Shop.Products.ProductInfo>();
            string IsStatic = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("ShopProductStatic");
            string basepath = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.BShop);
            if (list != null)
            {
                foreach (var item in list)
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
            }
            #endregion


            #region SEO 优化设置


            IPageSetting pageSetting = PageSetting.GetPageSetting("Category", ApplicationKeyType.Shop);
            pageSetting.Replace(
                new[] { PageSetting.RKEY_CNAME, model.CurrentCateName }); //分类名称
            ViewBag.Title = pageSetting.Title;
            ViewBag.Keywords = pageSetting.Keywords;
            ViewBag.Description = pageSetting.Description;
            #endregion
            //获取总条数
            if (toalCount < 1) return View(viewName, model); //NO DATA

            //分页获取数据
            model.ProductPagedList = new PagedList<Model.Shop.Products.ProductInfo>(list, pageIndex ?? 1, pageSize, toalCount); 

            //检测Ajax请求, 进行无刷新分页
            if (Request.IsAjaxRequest())
                return PartialView(ajaxViewName, model);

            return View(viewName, model);
        }

        #region 商品分类
        public PartialViewResult ProductCategory(int Cid, string viewName = "_ProductCategory", int Top = -1)
        {
            List<YSWL.MALL.Model.Shop.Products.CategoryInfo> cateList = YSWL.MALL.BLL.Shop.Products.CategoryInfo.GetAvailableCateList();
            YSWL.MALL.Model.Shop.Products.CategoryInfo categoryInfo =
                cateList.FirstOrDefault(c => c.CategoryId == Cid);
            ViewBag.CateName = categoryInfo != null ? categoryInfo.Name : "全部分类";
            ViewBag.Cid = Cid;
            List<YSWL.MALL.Model.Shop.Products.CategoryInfo> categoryInfos = new List<CategoryInfo>();
            if (categoryInfo != null && !categoryInfo.HasChildren)
            {
                YSWL.MALL.Model.Shop.Products.CategoryInfo ParentcategoryInfo =
              cateList.FirstOrDefault(c => c.CategoryId == categoryInfo.ParentCategoryId);
                if (ParentcategoryInfo != null)
                {
                    ViewBag.CateName = ParentcategoryInfo.Name;
                    ViewBag.Cid = ParentcategoryInfo.CategoryId;
                }
                categoryInfos = cateList.Where(c => c.ParentCategoryId == categoryInfo.ParentCategoryId).ToList();
            }
            else
            {
                categoryInfos = cateList.Where(c => c.ParentCategoryId == Cid).ToList();
            }

            return PartialView(viewName, categoryInfos);
        }
        #endregion

        #region 品牌
        public PartialViewResult BrandList(int Cid = 0, int productType = 0, int top = 10, string viewName = "_BrandList")
        {
            List<YSWL.MALL.Model.Shop.Products.BrandInfo> brandInfos =
                new List<YSWL.MALL.Model.Shop.Products.BrandInfo>();
            if (Cid > 0)
            {
                brandInfos = brandBll.GetBrandsByCateId(Cid, true, top).Distinct().ToList();
            }
            else
            {
                brandInfos = brandBll.GetModelListByProductTypeId(productType, top).Distinct().ToList();
            }
            return PartialView(viewName, brandInfos);
        }
        #endregion

        /// <summary>
        /// 搜索店铺
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="viewName"></param>
        /// <returns></returns>
        public PartialViewResult Store(string keyword = "", string viewName = "_Store")
        {
            Model.Shop.Supplier.SupplierInfo suppModel = suppBll.GetModelByShopName(Common.InjectionFilter.SqlFilter(keyword));
            return PartialView(viewName, suppModel);
        }

        // GET: PC/Search
        /// <summary>
        /// 搜索店铺
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="viewName"></param>
        /// <returns></returns>
        public ActionResult StoreList(string keyword = "", int areaid = 0,string mod="", int pageIndex = 1, int pageSize = 10, string vName = "StoreList", string ajaxVName = "_StoreList")
        { 
            keyword = YSWL.Common.InjectionFilter.SqlFilter(keyword);
            if (String.IsNullOrWhiteSpace(keyword))
            {
                return RedirectToAction("Index", "Home");
            }
            YSWL.MALL.ViewModel.Shop.SupplierModel model = new SupplierModel();            
            if (areaid > 0)
            {
                List<YSWL.MALL.Model.Shop.Supplier.SuppAreas> areaList= YSWL.MALL.BLL.Shop.Supplier.SuppAreas.GetAvailableList();
                YSWL.MALL.Model.Shop.Supplier.SuppAreas areaModel = areaList.FirstOrDefault(c => c.AreaId == areaid);
                if (areaModel != null)
                {
                    var path_arr = areaModel.Path.Split('|');
                    List<YSWL.MALL.Model.Shop.Supplier.SuppAreas> pathList =
                        areaList.Where(c => path_arr.Contains(c.AreaId.ToString())).OrderBy(c => c.Depth).ToList();
                    model.AreaPathList = pathList;
                    model.CurrentAreaModel = areaModel;
                }
            }

            pageSize = pageSize > 0 ? pageSize : 10;
            //计算分页起始索引
            int startIndex = pageIndex > 1 ? (pageIndex - 1) * pageSize + 1 : 1;
            //计算分页结束索引
            int endIndex = pageIndex > 1 ? startIndex + pageSize - 1 : pageSize;
            int toalCount = suppBll.GetRecordCount(keyword, areaid);
            ViewBag.TotalCount = toalCount;

            //获取总条数
            if (toalCount < 1)
            {
                //NO DATA
                //检测Ajax请求, 进行无刷新分页
                if (Request.IsAjaxRequest())
                    return PartialView(ajaxVName, model);
                return View(vName, model);
            }

            //获取分页数据
            List<YSWL.MALL.Model.Shop.Supplier.SupplierInfo> list = suppBll.GetListByPage(keyword, areaid, mod, startIndex, endIndex);
            if (list == null || list.Count == 0)
            {
                //检测Ajax请求, 进行无刷新分页
                if (Request.IsAjaxRequest())
                    return PartialView(ajaxVName, model);
                return View(vName, model);
            }
            //if (CurrentUser != null) {
            //    foreach (var item in list)
            //    {
            //        item.IsFavorited = favoBll.Exists(item.SupplierId, currentUser.UserID, 2);
            //    }
            //}     
            model.PageList = new PagedList<YSWL.MALL.Model.Shop.Supplier.SupplierInfo>(list, pageIndex, pageSize, toalCount);
            
            //检测Ajax请求, 进行无刷新分页
            if (Request.IsAjaxRequest())
                return PartialView(ajaxVName, model);

            return View(vName, model);
        }
    }
}
