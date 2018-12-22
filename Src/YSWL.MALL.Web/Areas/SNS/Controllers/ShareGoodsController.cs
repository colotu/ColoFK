﻿using System.Collections.Generic;
using System.Web.Mvc;
using YSWL.MALL.Model.SysManage;
using YSWL.Components.Setting;
using YSWL.MALL.Web.Components.Setting.SNS;
using Webdiyer.WebControls.Mvc;
using System;

namespace YSWL.MALL.Web.Areas.SNS.Controllers
{
    public class ShareGoodsController : SNSControllerBase
    {
        private int _basePageSize = 6;
        private int _waterfallSize = 32;
        private int _waterfallDetailCount = 1;

        private YSWL.MALL.BLL.SNS.Photos bllPhotos = new YSWL.MALL.BLL.SNS.Photos();
        YSWL.MALL.BLL.SNS.Products productBll = new YSWL.MALL.BLL.SNS.Products();
        YSWL.MALL.BLL.SNS.Categories bllCategory = new YSWL.MALL.BLL.SNS.Categories();

        public ShareGoodsController()
        {
            this._basePageSize = FallInitDataSize;
            this._waterfallSize = FallDataSize;

        }

        //
        // GET: /SNS/ShareGoods/
        public ActionResult Index(string orderby, int? pageIndex)
        {
            MALL.ViewModel.SNS.PhotoList photoList = new MALL.ViewModel.SNS.PhotoList();

            int pageSize = _basePageSize + _waterfallSize;
            ViewBag.BasePageSize = _basePageSize;

            //重置页面索引
            pageIndex = pageIndex.HasValue && pageIndex.Value > 1 ? pageIndex.Value : 1;
            //计算分页起始索引
            int startIndex = pageIndex.Value > 1 ? (pageIndex.Value - 1) * pageSize + 1 : 1;
            //计算分页结束索引
            int endIndex = pageIndex.Value > 1 ? startIndex + _basePageSize - 1 : _basePageSize;
            int toalCount = 0;
            int categoryId=YSWL.MALL.BLL.SysManage.ConfigSystem.GetIntValueByCache("SNS_ShareGood_Category");
            //获取总条数
            if (categoryId ==-1)
            {
                categoryId = 178;
            }
            toalCount = bllPhotos.GetRecordCount("Status=1 and  CategoryId=" + categoryId);
            //瀑布流Index
            ViewBag.CurrentPageAjaxStartIndex = endIndex;
            int ajaxEndIndex = pageIndex.Value * pageSize;
            ViewBag.CurrentPageAjaxEndIndex = ajaxEndIndex > toalCount ? toalCount : ajaxEndIndex;

            #region SEO 优化设置
            IPageSetting pageSetting = PageSetting.GetPageSetting("PhotoList", ApplicationKeyType.SNS);
            ViewBag.Title = pageSetting.Title;
            ViewBag.Keywords = pageSetting.Keywords;
            ViewBag.Description = pageSetting.Description;
            #endregion

            if (toalCount < 1) return View(photoList);   //NO DATA

            switch (orderby)
            {
                case "hot":
                    orderby = "CommentCount desc";
                    break;
                case "popular":
                    orderby = "FavouriteCount desc";
                    break;
                default: //new
                    orderby = "";
                    break;
            }

            //分页获取数据
            photoList.PhotoPagedList = bllPhotos.GetCachePhotoListByPage(
                categoryId, orderby, startIndex, endIndex).ToPagedList(
                                                    pageIndex ?? 1,
                                                    pageSize);

            //检测Ajax请求, 进行无刷新分页
            if (Request.IsAjaxRequest())
                return PartialView("ShareGoodsList", photoList);
            photoList.ZuiInList = bllPhotos.GetZuiInListByCache(categoryId, 3);
           // photoList.ScrollList == bllPhotos.GetTopPhotoPostByType(9, (int)YSWL.MALL.Model.SNS.EnumHelper.PhotoType.ShareGoods);
            photoList.PhotoCategory = bllCategory.GetPhotoMenuCategoryList();


            #region 静态化路径
            string IsStatic = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("SNSIsStatic");
            foreach (var item in photoList.PhotoPagedList)
            {

                if (IsStatic != "true")
                {
                    item.StaticUrl = ViewBag.BasePath + (item.Type == (int)YSWL.MALL.Model.SNS.EnumHelper.ImageType.Product ? "Product/" : "Photo/") + "Detail/" + item.TargetId;
                }
                else
                {
                    string StaticUrl = "";
                    if (item.Type == (int)YSWL.MALL.Model.SNS.EnumHelper.ImageType.Product)
                    {
                        YSWL.MALL.Model.SNS.Products productModel = productBll.GetModelByCache(item.TargetId);
                        StaticUrl = (productModel != null && !String.IsNullOrWhiteSpace(productModel.StaticUrl)) ? productModel.StaticUrl : (ViewBag.BasePath + "Product/Detail/" + item.TargetId);
                    }
                    else
                    {
                        YSWL.MALL.Model.SNS.Photos photoModel = bllPhotos.GetModelByCache((int)item.TargetId);
                        StaticUrl = (photoModel != null && !String.IsNullOrWhiteSpace(photoModel.StaticUrl)) ? photoModel.StaticUrl : (ViewBag.BasePath + "Photo/Detail/" + item.TargetId);
                    }
                    item.StaticUrl = StaticUrl;
                }
            }

            foreach (var item in photoList.ZuiInList)
            {
                if (IsStatic != "true")
                {
                    item.StaticUrl = ViewBag.BasePath + "Photo/Detail/" + item.PhotoId;
                }
                else
                {
                     YSWL.MALL.Model.SNS.Photos photoModel = bllPhotos.GetModelByCache(item.PhotoId);
                     item.StaticUrl = (photoModel != null && !String.IsNullOrWhiteSpace(photoModel.StaticUrl)) ? photoModel.StaticUrl : (ViewBag.BasePath + "Photo/Detail/" + item.PhotoId);
                }
            }
            #endregion

            return View(photoList);
        }

        [HttpPost]
       // [OutputCache(VaryByParam = "*", Duration = SNSAreaRegistration.OutputCacheDuration)]
        public ActionResult ShareGoodsWaterfall(string orderby, int startIndex)
        {
            MALL.ViewModel.SNS.PhotoList photoList = new MALL.ViewModel.SNS.PhotoList();
            ViewBag.BasePageSize = _basePageSize;

            //重置分页起始索引
            startIndex = startIndex > 1 ? startIndex + 1 : 1;
            //计算分页结束索引
            int endIndex = startIndex > 1 ? startIndex + _waterfallDetailCount - 1 : _waterfallDetailCount;
            int toalCount = 0;

            //获取总条数
             int categoryId=YSWL.MALL.BLL.SysManage.ConfigSystem.GetIntValueByCache("SNS_ShareGood_Category");
            if (categoryId == -1)
            {
                categoryId = 178;
            }
             toalCount = bllPhotos.GetRecordCount("Status=1 and  CategoryId=" + categoryId);
            if (toalCount < 1) return new EmptyResult();   //NO DATA

            switch (orderby)
            {
                case "hot":
                    orderby = "CommentCount desc";
                    break;
                case "popular":
                    orderby = "FavouriteCount desc";
                    break;
                default:
                    orderby = "";
                    break;
            }
            //分页获取数据
            photoList.PhotoListWaterfall = bllPhotos.GetCachePhotoListByPage(
               categoryId, orderby, startIndex, endIndex);

            #region 静态化路径
            string IsStatic = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("SNSIsStatic");
            foreach (var item in photoList.PhotoListWaterfall)
            {
                if (IsStatic != "true")
                {
                    item.StaticUrl = ViewBag.BasePath +  (item.Type == (int)YSWL.MALL.Model.SNS.EnumHelper.ImageType.Product ? "Product/" : "Photo/") +"Detail/" + item.TargetId;
                }
                else
                {
                    string StaticUrl = "";
                    if (item.Type == (int)YSWL.MALL.Model.SNS.EnumHelper.ImageType.Product)
                    {
                        YSWL.MALL.Model.SNS.Products productModel = productBll.GetModelByCache(item.TargetId);
                        StaticUrl = (productModel != null && !String.IsNullOrWhiteSpace(productModel.StaticUrl)) ? productModel.StaticUrl : (ViewBag.BasePath + "Product/Detail/" + item.TargetId);
                    }
                    else
                    {
                        YSWL.MALL.Model.SNS.Photos photoModel = bllPhotos.GetModelByCache((int)item.TargetId);
                        StaticUrl = (photoModel != null && !String.IsNullOrWhiteSpace(photoModel.StaticUrl)) ? photoModel.StaticUrl : (ViewBag.BasePath + "Photo/Detail/" + item.TargetId);
                    }
                    item.StaticUrl = StaticUrl;
                }
            }
            #endregion

            return View(CurrentThemeViewPath + "Photo/PhotoListWaterfall.cshtml", photoList);

        }

        public ActionResult ScrollShareGoods()
        {
            int categoryId = YSWL.MALL.BLL.SysManage.ConfigSystem.GetIntValueByCache("SNS_ShareGood_Category");
            //获取总条数
            if (categoryId == -1)
            {
                categoryId = 178;
            }
            List<YSWL.MALL.Model.SNS.Photos> list = bllPhotos.GetTopPhotoPostByType(9, categoryId);

            #region 静态化路径
            if (list != null && list.Count > 0)
            {
                string IsStatic = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("SNSIsStatic");
                foreach (var item in list)
                {
                    if (IsStatic != "true")
                    {
                        item.StaticUrl = ViewBag.BasePath + "Photo/Detail/" + item.PhotoID;
                    }
                    else
                    {
                        YSWL.MALL.Model.SNS.Photos photoModel = bllPhotos.GetModelByCache(item.PhotoID);
                        item.StaticUrl = (photoModel != null && !String.IsNullOrWhiteSpace(photoModel.StaticUrl)) ? photoModel.StaticUrl : (ViewBag.BasePath + "Photo/Detail/" + item.PhotoID);
                    }
                }
            }
            #endregion

            return View(list);
        }
    }
}
