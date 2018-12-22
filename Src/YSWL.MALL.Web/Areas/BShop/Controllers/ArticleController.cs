using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;
using YSWL.Components.Setting;
using YSWL.Json;
using YSWL.MALL.Web.Components.Setting.CMS;

namespace YSWL.MALL.Web.Areas.BShop.Controllers
{
    public class ArticleController : BShopControllerBase
    {
        //
        // GET: /Shop/Common/
        BLL.CMS.Content contentBll = new BLL.CMS.Content();
        BLL.CMS.ContentClass contentclassBll = new BLL.CMS.ContentClass();

       #region 文章 
        /// <summary>
        /// 文章内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       /// [OutputCache(Duration = 2000, VaryByParam = "id")]
        public ActionResult Details(int? id,string vName= "Details")
        { 
            if (id.HasValue)
            {
                int contentid = id.Value;
                Model.CMS.Content model = contentBll.GetModelByCache(contentid);
                if (null != model)
                {
                    #region SEO 优化设置
                    //IPageSetting pageSetting = PageSetting.GetPageSetting("CMS", Model.SysManage.ApplicationKeyType.CMS);
                    //pageSetting.Replace(
                    //    new[] { PageSetting.RKEY_CNAME, model.Title },   //文章标题
                    //    new[] { PageSetting.RKEY_CID, model.ContentID.ToString() });   //文章ID
                    IPageSetting pageSetting = PageSetting.GetArticleSetting(model);
                    ViewBag.Title = pageSetting.Title;
                    ViewBag.Keywords = pageSetting.Keywords;
                    ViewBag.Description = pageSetting.Description;
                    #endregion
                    model.PvCount= contentBll.UpdatePV(contentid);//更新浏览量
                    ViewBag.AClassName = contentclassBll.GetAClassnameById(model.ClassID);//获得此文章所属的一级栏目的栏目名称
                    return View(vName,model);
                }
            }
            return Redirect(MvcApplication.GetCurrentRoutePath(ControllerContext)+"Home");
        }

        public PartialViewResult LeftMenu(int classid, string viewName = "_LeftMenu")
        {
            Model.CMS.ContentClass classmodel;
            List<YSWL.MALL.Model.CMS.ContentClass> list = contentclassBll.GetModelList(classid, out  classmodel);
            if (classmodel != null)
            {
                ViewBag.AclassName = classmodel.ClassName;
                ViewBag.AclassId = classmodel.ClassID;
            }         
            return PartialView(viewName,list);
        }
        //文章列表
        public PartialViewResult ContentTitleList(int classid, string viewName = "_ContentTitleList")
        {
            List<YSWL.MALL.Model.CMS.Content> list = contentBll.GetModelList(classid, 0);
            return PartialView(viewName, list);
        }
        #endregion


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
                if (contentBll.UpdateTotalSupport(id))
                {
                    Model.CMS.Content model = contentBll.GetModel(id);
                    Model.CMS.Content modelCache = contentBll.GetModelByCache(id);
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

        public ActionResult List(int? pageIndex, int cid=0,string ky="", int pagesize = 10,string vName= "List",string ajaxVName= "_List")
        {
            ViewBag.PCid = 0;
            if (cid > 0) {
                ViewBag.PCid = contentclassBll.GetClassIdById(cid);
            }
//重置页面索引
pageIndex = pageIndex.HasValue && pageIndex.Value > 1 ? pageIndex.Value : 1;

            //计算分页起始索引
            int startIndex = pageIndex.Value > 1 ? (pageIndex.Value - 1) * pagesize + 1 : 1;

            //计算分页结束索引
            int endIndex = pageIndex.Value * pagesize;

            int toalCount = contentBll.GetRecordCount(cid, ky);    
            List<YSWL.MALL.Model.CMS.Content> list = contentBll.GetList(cid, startIndex, endIndex, ky);
            PagedList<YSWL.MALL.Model.CMS.Content> ArticleList = null;
            if (list != null && list.Count > 0)
            {
                ArticleList = new PagedList<YSWL.MALL.Model.CMS.Content>(list, pageIndex ?? 1, pagesize, toalCount);
            }
            if (Request.IsAjaxRequest())
                return PartialView(ajaxVName, ArticleList);

            return View(vName,ArticleList);
        }
    }
}
