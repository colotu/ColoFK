using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YSWL.Components.Setting;
using YSWL.MALL.Web.Components.Setting.CMS;
using Webdiyer.WebControls.Mvc;
using YSWL.Json;

namespace YSWL.MALL.Web.Areas.MB.Controllers
{
    public class ArticleController :MBControllerBase
    {
        //
        // GET: /Mobile/Article/
       
        private BLL.CMS.ContentClass classContBll = new BLL.CMS.ContentClass();
        private BLL.CMS.Content contBll = new BLL.CMS.Content();

        /// <summary>
        /// 文章内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// [OutputCache(Duration = 2000, VaryByParam = "id")]
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                int contentid = id.Value;
                Model.CMS.Content model = contBll.GetModelByCache(contentid);
                if (null != model)
                {
                    #region SEO 优化设置
                    IPageSetting pageSetting = PageSetting.GetArticleSetting(model);
                    ViewBag.Title = pageSetting.Title;
                    ViewBag.Keywords = pageSetting.Keywords;
                    ViewBag.Description = pageSetting.Description;
                    #endregion

                    int PreId = contBll.GetPrevID(contentid, model.ClassID);
                    int NextId = contBll.GetNextID(contentid, model.ClassID);
                    contBll.UpdatePV(contentid);//更新浏览量
                    ViewBag.AClassName = classContBll.GetAClassnameById(model.ClassID);//获得此文章所属的一级栏目的栏目名称
                    ViewBag.PreUrl = PreId > 0 ? ViewBag.BasePath+"Article/Details/" + PreId : "#";
                    ViewBag.NextUrl = NextId > 0 ? ViewBag.BasePath+"Article/Details/" + NextId : "#";
                }
                return View(model);
            }
          
            return RedirectToAction("ArticleList", "Article", "MB"); 
        }

        /// <summary>
        ///  文章列表
        /// </summary>
        /// <param name="classid">类别ID</param>
        /// <returns></returns>
        public ActionResult ArticleList(int? classid)
        {
            if (classid.HasValue)
            {
                Model.CMS.ContentClass contclassModel = classContBll.GetModelByCache(classid.Value);
                if (contclassModel!=null)
                {
                    #region SEO 优化设置
                    IPageSetting pageSetting = PageSetting.GetContentClassSetting(contclassModel);
                    ViewBag.Title = pageSetting.Title;
                    ViewBag.Keywords = pageSetting.Keywords;
                    ViewBag.Description = pageSetting.Description;
                    #endregion

                    List<Model.CMS.Content> contModel = contBll.GetModelList(classid.Value, 0);
                    return View(contModel);
                }  
            }
            return RedirectToAction("Index", "Home", "MShop");
        }

        public ActionResult Index()
        {
            BLL.SysManage.WebSiteSet webSiteSet = new BLL.SysManage.WebSiteSet(Model.SysManage.ApplicationKeyType.Shop);
            ViewBag.phone = webSiteSet.Company_Telephone;
            return View();
        }
        /// <summary>
        /// 赞
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public void Support(int id)
        {
            JsonObject json = new JsonObject();
            if (Request.Cookies["UsersSupports" + id] != null && Request.Cookies["UsersSupports" + id].Value == id.ToString())
            {
                json.Accumulate("STATUS", "NOTALLOW");
            }
            else
            {
                if (contBll.UpdateTotalSupport(id))
                {
                    Model.CMS.Content model = contBll.GetModel(id);
                    Model.CMS.Content modelCache = contBll.GetModelByCache(id);
                    if (model != null)
                    {
                        json.Accumulate("STATUS", "SUCC");
                        json.Accumulate("TotalSupport", model.TotalSupport);
                        modelCache.TotalSupport = model.TotalSupport;   //更新缓存

                        //写入Cookie,防止重复操作“赞”。
                        HttpCookie cookie = new HttpCookie("UsersSupports" + id);
                        cookie.Value = id.ToString();
                        cookie.Expires = DateTime.MaxValue;
                        Response.AppendCookie(cookie);
                    }
                    else
                    {
                        json.Accumulate("STATUS", "FAIL");
                    }
                }
                else
                {
                    json.Accumulate("STATUS", "FAIL");
                }
            }
            Response.Write(json.ToString());
        }
        public ActionResult List(int? pageIndex, int cid = 0, string ky = "", int pagesize = 10, string vName = "List", string ajaxVName = "_List")
        {
            ViewBag.Cid = cid;
            ViewBag.PCid = 0;
            if (cid > 0)
            {
                ViewBag.PCid = classContBll.GetClassIdById(cid);
            }
            //重置页面索引
            pageIndex = pageIndex.HasValue && pageIndex.Value > 1 ? pageIndex.Value : 1;

            //计算分页起始索引
            int startIndex = pageIndex.Value > 1 ? (pageIndex.Value - 1) * pagesize + 1 : 1;

            //计算分页结束索引
            int endIndex = pageIndex.Value * pagesize;

            int toalCount = contBll.GetRecordCount(cid, ky);
            ViewBag.PageSize = pagesize;
            #region DataParam
            ViewBag.DataParam = String.Format("{0}ky:'{1}',cid:'{2}'{3}", "{", ky, cid, "}");
            #endregion
            List<YSWL.MALL.Model.CMS.Content> list = contBll.GetList(cid, startIndex, endIndex, ky);
            PagedList<YSWL.MALL.Model.CMS.Content> ArticleList = null;
            if (list != null && list.Count > 0)
            {
                ArticleList = new PagedList<YSWL.MALL.Model.CMS.Content>(list, pageIndex ?? 1, pagesize, toalCount);
            }
            if (Request.IsAjaxRequest())
                return PartialView(ajaxVName, ArticleList);

            return View(vName, ArticleList);
        }

        public PartialViewResult ClassList(int Top=0,int pId=0, string viewName = "_ClassList")
        {
            Model.CMS.ContentClass classmodel;
            List<YSWL.MALL.Model.CMS.ContentClass> list = classContBll.GetModelList(Top, pId, out classmodel);
            if (classmodel != null)
            {
                ViewBag.AclassName = classmodel.ClassName;
                ViewBag.AclassId = classmodel.ClassID;
            }
            return PartialView(viewName, list);
        }
    }
}
