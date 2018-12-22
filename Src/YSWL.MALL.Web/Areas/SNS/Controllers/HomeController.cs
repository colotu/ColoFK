using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using YSWL.MALL.BLL.CMS;
using YSWL.MALL.BLL.SNS;
using YSWL.MALL.BLL.Settings;
using YSWL.Common;
using YSWL.Components.Setting;
using YSWL.Json;
using YSWL.Json.Conversion;
using YSWL.MALL.Model.SysManage;
using YSWL.MALL.Web.Components.Setting.SNS;
using Posts = YSWL.MALL.Model.SNS.Posts;
using UserAlbums = YSWL.MALL.BLL.SNS.UserAlbums;
using System.Net;


namespace YSWL.MALL.Web.Areas.SNS.Controllers
{
    public class HomeController : SNSControllerBase
    {
        #region 全局变量
        YSWL.MALL.BLL.SNS.Categories CateBll = new YSWL.MALL.BLL.SNS.Categories();
        YSWL.MALL.Model.SNS.ProductQuery ProQuery = new Model.SNS.ProductQuery();
        YSWL.MALL.BLL.SNS.Products ProductBll = new YSWL.MALL.BLL.SNS.Products();
        YSWL.MALL.BLL.SNS.Photos PhotoBll = new YSWL.MALL.BLL.SNS.Photos();
        YSWL.MALL.BLL.SNS.TagType TagTypeBll = new YSWL.MALL.BLL.SNS.TagType();
        YSWL.MALL.BLL.SNS.HotWords SearchBll = new YSWL.MALL.BLL.SNS.HotWords();
        YSWL.MALL.BLL.SNS.Comments ComBll = new YSWL.MALL.BLL.SNS.Comments();
        private YSWL.MALL.BLL.SNS.Groups bllGroups = new YSWL.MALL.BLL.SNS.Groups();
        #endregion

        #region 首页
        public ActionResult Index()
        {
            string IsStatic = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("SNSIsStatic");
            if (IsStatic == "true" && System.IO.File.Exists(Server.MapPath("/index.html")) && String.IsNullOrWhiteSpace(Request.Params["RequestType"]))
            {
                return File("/index.html", "text/html");
            }
            else
            {
            
                #region SEO 优化设置
                IPageSetting pageSetting = PageSetting.GetPageSetting("Home", ApplicationKeyType.SNS);
                ViewBag.Title = pageSetting.Title;
                ViewBag.Keywords = pageSetting.Keywords;
                ViewBag.Description = pageSetting.Description;
                #endregion
                return View("Index");
            }
        }
        #endregion

        #region 首页大类（如衣服）需要的数据
        [ChildActionOnly]
        //   [OutputCache(VaryByParam = "*", Duration = SNSAreaRegistration.OutputCacheDuration)]
        public PartialViewResult CategoryDetailPart(int topcid, string Name,int topcate=5,int top=12)
        {

            YSWL.MALL.BLL.SNS.Categories CateBll = new YSWL.MALL.BLL.SNS.Categories();
            List<YSWL.MALL.Model.SNS.Categories> list = CateBll.GetMenuByCategory();

            YSWL.MALL.ViewModel.SNS.ProductCategory Model = CateBll.GetCateListByParentIdEx(topcid);
            Model.TagsList = TagTypeBll.GetTagListByCid(topcid, topcate);
            YSWL.MALL.Model.SNS.ProductQuery Query = new YSWL.MALL.Model.SNS.ProductQuery();
            //下面表示通过逛宝贝过来的，其相应的类别都是默认的0
            Query.CategoryID = topcid;
            Query.IsTopCategory = true;
            Query.Order = "popular";
            string HomeGetValueType = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("HomeGetValueType");
            if (HomeGetValueType != null && HomeGetValueType == ((int)YSWL.MALL.Model.SNS.EnumHelper.RecommendType.Home).ToString())
            {
                Query.IsRecomend = (int)YSWL.MALL.Model.SNS.EnumHelper.RecommendType.Home;
            }
            Model.CurrentCateName = Name;
            //Model.ProductListWaterfall = ProductBll.GetProductByPage(Query, 1, top);
            //if (Model.ProductListWaterfall != null && Model.ProductListWaterfall.Count > 0)
            //{
            //    string IsStatic = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("SNSIsStatic");
            //    foreach (var item in Model.ProductListWaterfall)
            //    {
            //        if (IsStatic != "true")
            //        {
            //            item.StaticUrl = ViewBag.BasePath + "Product/Detail/" + item.ProductID;
            //        }
            //        else
            //        {
            //            item.StaticUrl = (String.IsNullOrWhiteSpace(item.StaticUrl) ? ViewBag.BasePath + "Product/Detail/" + item.ProductID : item.StaticUrl);
            //        }
            //    }
            //}
            return PartialView("CategoryDetailPart", Model);
        }
        #endregion

        #region 首页分类数据
        [ChildActionOnly]
        //   [OutputCache(VaryByParam = "*", Duration = SNSAreaRegistration.OutputCacheDuration)]
        public PartialViewResult MenuCategory(int Top = -1, string ViewName = "MenuCategory")
        {
            YSWL.MALL.BLL.SNS.Categories CateBll = new YSWL.MALL.BLL.SNS.Categories();
            List<YSWL.MALL.Model.SNS.Categories> list = CateBll.GetMenuByCategory(Top);
            return PartialView(ViewName, list);
        }


        #endregion

#region 首页标签数据
        //   [OutputCache(VaryByParam = "*", Duration = SNSAreaRegistration.OutputCacheDuration)]
        public PartialViewResult TagsList(int Cid, int Top = -1, string ViewName = "TagsList")
        {
            List<YSWL.MALL.ViewModel.SNS.CType> TagsList = TagTypeBll.GetTagListByCid(Cid, Top);
            ViewBag.CurrentCid = Cid;
            return PartialView(ViewName, TagsList);
        }
#endregion


        #region 搭配和晒货
        [ChildActionOnly]
        // [OutputCache(VaryByParam = "none", Duration = SNSAreaRegistration.OutputCacheDuration)]
        public PartialViewResult PhotoPart(int Top = 12, int Type = -1, string ViewName = "PhotoPart")
        {
            YSWL.MALL.BLL.SNS.Photos PhotoBll = new YSWL.MALL.BLL.SNS.Photos();
            List<YSWL.MALL.Model.SNS.Photos> PhotoList = PhotoBll.GetTopPhotoList(Top, Type);
            if (PhotoList != null && PhotoList.Count > 0)
            {
                string IsStatic = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("SNSIsStatic");
                foreach (var item in PhotoList)
                {
                    if (IsStatic != "true")
                    {
                        item.StaticUrl = ViewBag.BasePath + "Photo/Detail/" + item.PhotoID;
                    }
                    else
                    {
                        item.StaticUrl = (String.IsNullOrWhiteSpace(item.StaticUrl) ? ViewBag.BasePath + "Photo/Detail/" + item.PhotoID : item.StaticUrl);
                    }
                }
            }
            return PartialView(ViewName, PhotoList);

        }
        #endregion

        #region 首页的人气专辑
        [ChildActionOnly]

        //[OutputCache(VaryByParam = "none", Duration = SNSAreaRegistration.OutputCacheDuration)]
        public PartialViewResult AlbumPart(int Top =4)
        {
            YSWL.MALL.BLL.SNS.UserAlbums bllAlbums = new YSWL.MALL.BLL.SNS.UserAlbums();
            List<MALL.ViewModel.SNS.AlbumIndex> model = bllAlbums.GetListForIndex(0, Top, (int)YSWL.MALL.Model.SNS.EnumHelper.RecommendType.Home, UserAlbumDetailType);
            return PartialView("AlbumPart", model);
        }
        #endregion

        #region 商品
        [OutputCache(VaryByParam = "none", Duration = SNSAreaRegistration.OutputCacheDuration)]
        public PartialViewResult MoreProductPart()
        {
            List<YSWL.MALL.ViewModel.SNS.ProductCategory> list = CateBll.GetChildByMenu();
            return PartialView(list);
        }
        #endregion

        public ActionResult ScrollPost(string ViewName="ScrollPost",int top=10,YSWL.MALL.Model.SNS.EnumHelper.PostContentType PostType=YSWL.MALL.Model.SNS.EnumHelper.PostContentType.Product )
        {
            YSWL.MALL.BLL.SNS.Posts postBll = new YSWL.MALL.BLL.SNS.Posts();
            List<YSWL.MALL.Model.SNS.Posts> list = postBll.GetScrollPost(top, PostType);
            return View(ViewName,list);
        }

        #region 图片采集分享接口
        public ActionResult ShareImage()
        {
            string pic = "";
            YSWL.MALL.ViewModel.SNS.CollectImages collectImages = new MALL.ViewModel.SNS.CollectImages();
            if (CurrentUser != null)
            {
                YSWL.MALL.BLL.SNS.UserAlbums bllAlbums = new UserAlbums();
                collectImages.AlbumList = bllAlbums.GetUserAblumsByUserID(currentUser.UserID);
            }
            if (!String.IsNullOrWhiteSpace(Request.QueryString["pics[]"]))
            {
                var pics = Request.QueryString.GetValues("pics[]");
                int i = 0;
                foreach (var item in pics)
                {
                    if (i == 0)
                    {
                        pic = "?pics[]=" + item;
                    }
                    else
                    {
                        pic = pic + "&pics[]=" + item;
                    }
                    YSWL.MALL.ViewModel.SNS.ImageMessage image = new MALL.ViewModel.SNS.ImageMessage();
                    if (item.IndexOf("----") > 0)
                    {
                        image.ImageUrl = item.Substring(0, item.IndexOf("----"));
                        image.ImageAlt = item.Substring(item.IndexOf("----") + 4);
                    }
                    else
                    {
                        image.ImageUrl = item;
                        image.ImageAlt = "";
                    }

                    collectImages.ImageList.Add(image);
                    i++;
                }
            }
            //先写入session
            Session["ReturnUrl"] = ViewBag.BasePath + "Home/ShareImage" + pic + "&type=img";
            #region SEO 优化设置
            IPageSetting pageSetting = PageSetting.GetPageSetting("Base", ApplicationKeyType.SNS);
            ViewBag.Title = pageSetting.Title;
            ViewBag.Keywords = pageSetting.Keywords;
            ViewBag.Description = pageSetting.Description;
            #endregion
            return View(collectImages);
        }
        [HttpPost]
        public ActionResult AjaxAddImage(FormCollection Fm)
        {
            bool isSuccess = true;
            YSWL.MALL.BLL.SNS.Posts postBll = new YSWL.MALL.BLL.SNS.Posts();
            YSWL.MALL.Model.SNS.Posts PostsModel = new Posts();
            string jsonList = Fm["List"];
            if (string.IsNullOrWhiteSpace(jsonList))
            {
                return Json(new { Data = false });
            }
            int count = 0;
            JsonArray jsonArray = JsonConvert.Import<JsonArray>(jsonList);
            foreach (JsonObject jsonObject in jsonArray)
            {
                string CollectImageUrl = jsonObject["ImageUrl"].ToString();
                //如果这个地址的图片不存在就返回
                //if (String.IsNullOrWhiteSpace(CollectImageUrl) || !CollectImageUrl.StartsWith("http") ||
                //  !System.IO.File.Exists(CollectImageUrl))
                //{
                //    continue;
                //}

                if (String.IsNullOrWhiteSpace(CollectImageUrl) || !CollectImageUrl.StartsWith("http") ||
                    !IsExist(CollectImageUrl))
                {
                    continue;
                }
                count++;
                string ShareDes = Common.InjectionFilter.Filter(jsonObject["ShareDec"].ToString());
                //int ImageType = 0;
                int AlbumId = Common.Globals.SafeInt(jsonObject["AlbumId"].ToString(), 0);
                PostsModel.Description = ShareDes;
                PostsModel.CreatedDate = DateTime.Now;
                PostsModel.CreatedNickName = currentUser.NickName;
                PostsModel.CreatedUserID = currentUser.UserID;
                PostsModel.Type = (int)Model.SNS.EnumHelper.PostContentType.Photo;
                PostsModel.UserIP = Request.UserHostAddress;
                //先下载图片 存储结构分两种情况。一种是本地的情况。一种是又拍云的情况
                string StoreWay = BLL.SysManage.ConfigSystem.GetValueByCache("SNS_ImageStoreWay");
                string ImageUrl = "";
                string imagename = CreateIDCode() + ".jpg";
                using (System.Net.WebClient mywebclient = new System.Net.WebClient())
                {

                    if (StoreWay != "1")//本地的情况
                    {
                        string savePath = "/"+MvcApplication.UploadFolder+"/SNS/Images/Photos/" + DateTime.Now.ToString("yyyyMMdd") + "/";
                        string thumbSavePath = "/"+MvcApplication.UploadFolder+"/SNS/Images/PhotosThumbs/" + DateTime.Now.ToString("yyyyMMdd") + "/";
                        if (!Directory.Exists(Server.MapPath(savePath)))
                            Directory.CreateDirectory(Server.MapPath(savePath));

                        if (!Directory.Exists(Server.MapPath(thumbSavePath)))
                            Directory.CreateDirectory(Server.MapPath(thumbSavePath));
                        ImageUrl = savePath + imagename; ;
                        mywebclient.DownloadFile(CollectImageUrl, Server.MapPath(ImageUrl));
                    }
                    else//拍云的情况
                    {
                        byte[] buffer = mywebclient.DownloadData(CollectImageUrl);
                        if (buffer == null || buffer.Length == 0)
                            isSuccess = false;
                        string FileName = CreateIDCode() + ".jpg";
                        if (YSWL.MALL.BLL.SysManage.UpYunManager.UploadExecute(buffer, FileName, ApplicationKeyType.SNS, out ImageUrl))
                        {
                            //执行添加图片的方法
                            // photoModel.PhotoName
                            PostsModel.ImageUrl = ImageUrl + "|" + ImageUrl;
                            PostsModel = postBll.AddPost(PostsModel, AlbumId, -1, 0);
                        }
                    }
                }
                if (StoreWay != "1") //本地的情况
                {
                    string ThumbImageUrl = "";

                    MakeThumbnail(imagename, out ThumbImageUrl);
                    PostsModel.ImageUrl = ImageUrl + "|" + ThumbImageUrl;
                    PostsModel = postBll.AddPost(PostsModel, AlbumId, -1, 0);
                }
            }
            if(count<=0){
                return Json(new { Data = false });
            }
            if (isSuccess)
            {
                return Json(new { Data = true });
            }
            return Json(new { Data = false });
        }

        /// <summary>
        /// 形成时间戳，组成图片名字
        /// </summary>
        /// <returns></returns>
        public string CreateIDCode()
        {
            DateTime Time1 = DateTime.Now.ToUniversalTime();
            DateTime Time2 = Convert.ToDateTime("1970-01-01");
            TimeSpan span = Time1 - Time2;   //span就是两个日期之间的差额   
            string t = span.TotalMilliseconds.ToString("0");
            return t;
        }

        public void MakeThumbnail(string imgname, out string thumbImagePath)
        {
            string savePath = "/"+MvcApplication.UploadFolder+"/SNS/Images/Photos/" + DateTime.Now.ToString("yyyyMMdd") + "/";
            string saveThumbsPath = "/"+MvcApplication.UploadFolder+"/SNS/Images/PhotosThumbs/" + DateTime.Now.ToString("yyyyMMdd") + "/";
            List<YSWL.MALL.Model.Ms.ThumbnailSize> thumSizeList = YSWL.MALL.BLL.Ms.ThumbnailSize.GetThumSizeList(Model.Ms.EnumHelper.AreaType.SNS);
            if (thumSizeList != null && thumSizeList.Count > 0)
            {
                foreach (var thumbnailSize in thumSizeList)
                {
                    ImageTools.MakeThumbnail(Server.MapPath(savePath + imgname), Server.MapPath(saveThumbsPath + thumbnailSize.ThumName + imgname), thumbnailSize.ThumWidth, thumbnailSize.ThumHeight, MakeThumbnailMode.W);
                }
            }
            thumbImagePath = saveThumbsPath + "{0}" + imgname;
        }


        public ActionResult CollectionJS()
        {
            ViewBag.HostName = Common.Globals.DomainFullName;
            #region SEO 优化设置
            IPageSetting pageSetting = PageSetting.GetPageSetting("Base", ApplicationKeyType.SNS);
            ViewBag.Title = pageSetting.Title;
            ViewBag.Keywords = pageSetting.Keywords;
            ViewBag.Description = pageSetting.Description;
            #endregion
            return View();
        }

        /// <summary>
        /// 判断远程文件是否存在
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        private static bool IsExist(string uri)
        {
            HttpWebRequest req = null;
            HttpWebResponse res = null;
            try
            {
                req = (HttpWebRequest)WebRequest.Create(uri);
                res = (HttpWebResponse)req.GetResponse();
                return (res.ContentType.Contains("image/") && res.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                return false;
            }
            finally
            {
                if (res != null)
                {
                    res.Close();
                    res = null;
                }
                if (req != null)
                {
                    req.Abort();
                    req = null;
                }
            }
        }
        #endregion

        #region 试用

        public PartialViewResult UseTry()
        {
            return PartialView("UseTry");
        }

        #endregion

        #region 小组
        public PartialViewResult GroupPart(int Top = 4, string ViewName = "GroupPart")
        {
            //精选小组
          List<YSWL.MALL.Model.SNS.Groups> ProGroupList = bllGroups.GetTopList(Top, "IsRecommand=2", "TopicCount desc");
          return PartialView(ViewName, ProGroupList);
        }
        #endregion

        #region 首页推荐的商品列表
        public PartialViewResult ProductList(int Cid = 0, int Top = 12, string ViewName = "ProductList")
        {
            YSWL.MALL.Model.SNS.ProductQuery Query = new YSWL.MALL.Model.SNS.ProductQuery();
            //下面表示通过逛宝贝过来的，其相应的类别都是默认的0
            Query.CategoryID = Cid;
            Query.IsTopCategory = true;
            Query.Order = "popular";
            string HomeGetValueType = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("HomeGetValueType");
            if (HomeGetValueType != null && HomeGetValueType == ((int)YSWL.MALL.Model.SNS.EnumHelper.RecommendType.Home).ToString())
            {
                Query.IsRecomend = (int)YSWL.MALL.Model.SNS.EnumHelper.RecommendType.Home;
            }
            List<YSWL.MALL.Model.SNS.Products> ProductList = ProductBll.GetProductByPage(Query, 1, Top);
            if (ProductList != null && ProductList.Count > 0)
            {
                string IsStatic = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("SNSIsStatic");
                foreach (var item in ProductList)
                {
                    if (IsStatic != "true")
                    {
                        item.StaticUrl = ViewBag.BasePath + "Product/Detail/" + item.ProductID;
                    }
                    else
                    {
                        item.StaticUrl = (String.IsNullOrWhiteSpace(item.StaticUrl) ? ViewBag.BasePath + "Product/Detail/" + item.ProductID : item.StaticUrl);
                    }
                }
            }
            return PartialView(ViewName, ProductList);
        }
        #endregion

        #region 首页达人推荐
        public PartialViewResult StarRec(int StarType = 0, int Top = 4, string ViewName = "StarRec")
        {
            YSWL.MALL.BLL.SNS.StarRank starRankBll = new YSWL.MALL.BLL.SNS.StarRank();
            List<YSWL.MALL.ViewModel.SNS.StarRank> StarRankList = starRankBll.GetStarRankList(StarType, Top);//该类型下的达人总排行
          return PartialView(ViewName, StarRankList);
        }
        #endregion

        #region  推荐的主题
        //获取推荐的主题
        public PartialViewResult GroupTopic(int Top = 12, string ViewName = "_GroupTopic")
        {
           YSWL.MALL.BLL.SNS.GroupTopics topicBll=new GroupTopics();
         List<YSWL.MALL.Model.SNS.GroupTopics> topicList=   topicBll.GetRecTopics(Top);
         return PartialView(ViewName, topicList);
        }
        #endregion 

        #region  用户发的文章
        public PartialViewResult UserBlog(int Top = 8, string ViewName = "_UserBlog")
        {
            YSWL.MALL.BLL.SNS.UserBlog blogBll = new UserBlog();
            List<YSWL.MALL.Model.SNS.UserBlog> blogs = blogBll.GetRecBlogList(Top);
            return PartialView(ViewName, blogs);
        }
        #endregion 

        #region  CMS部分

        public PartialViewResult CMSArticle(int ClassId=0,YSWL.MALL.Model.CMS.EnumHelper.ContentRec Rec=YSWL.MALL.Model.CMS.EnumHelper.ContentRec.Recomend, int Top = 6, string ViewName = "_CMSArticle")
        {
            YSWL.MALL.BLL.CMS.Content contentBll=new Content();
            List<YSWL.MALL.Model.CMS.Content> contents = contentBll.GetRecList(ClassId, Rec, Top,true);
            return PartialView(ViewName, contents);
        }

        public PartialViewResult HotComment(int ClassId = 0, int Top = 10, string comType="day", string ViewName = "_HotComment")
        {
            YSWL.MALL.BLL.CMS.Content contentBll = new Content();
            List<YSWL.MALL.Model.CMS.Content> contents = contentBll.GetHotCom(comType, Top);
            return PartialView(ViewName, contents);
        }
        #endregion

        #region 首页广告位
        public PartialViewResult IndexAd(int id = 38, string ViewName = "_IndexAd")
        {
            YSWL.MALL.BLL.Settings.Advertisement bll = new Advertisement();
            List<YSWL.MALL.Model.Settings.Advertisement> list = bll.GetListByAidCache(id);
            return PartialView(ViewName, list);
        }

        public PartialViewResult IndexUser(string ViewName = "_IndexUser")
        {
            return PartialView(ViewName, currentUser);
        }
        #endregion
    }
}
