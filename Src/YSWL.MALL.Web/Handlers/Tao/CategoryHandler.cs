using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YSWL.Json;
using YSWL.Common;
using System.Data;

namespace YSWL.MALL.Web.Handlers.Tao
{
    public class CategoryHandler : HandlerBase
    {
        #region IHttpHandler 成员

        public override bool IsReusable
        {
            get { return false; }
        }
        public List<YSWL.MALL.Model.Tao.Category> CategoryList;  
        public override void ProcessRequest(HttpContext context)
        {
            //安全起见, 所有产品相关Ajax请求为POST模式
            string action = context.Request.Form["Action"];

            context.Response.Clear();
            context.Response.ContentType = "application/json";

            try
            {
                switch (action)
                {
                    #region 网站商品分类

                    case "GetTaoChildNode":
                        GetTaoChildNode(context);
                        break;

                    case "GetTaoDepthNode":
                        GetTaoDepthNode(context);
                        break;

                    case "GetTaoParentNode":
                        GetTaoParentNode(context);
                        break;

                    case "IsExistedTaoCate":
                        IsExistedTaoCate(context);
                        break;
                    case "GetTaoProductNodes":
                        GetTaoProductNodes(context);
                        break;
                    case "SetCategory":
                        SetCategory(context);
                        break;
                    #endregion 网站商品分类

                    #region 淘宝商品分类

                    case "GetTaoBaoChildNode":
                        GetTaoBaoChildNode(context);
                        break;

                    case "GetTaoBaoDepthNode":
                        GetTaoBaoDepthNode(context);
                        break;

                    case "GetTaoBaoParentNode":
                        GetTaoBaoParentNode(context);
                        break;

                    case "IsExistedTaoBaoCate":
                        IsExistedTaoBaoCate(context);
                        break;

                    #endregion 淘宝商品分类


                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                JsonObject json = new JsonObject();
                json.Put(KEY_STATUS, STATUS_ERROR);
                json.Put(KEY_DATA, ex);
                context.Response.Write(json.ToString());
            }
        }

        #endregion IHttpHandler 成员

        #region 网站商品分类

        private YSWL.MALL.BLL.Tao.Category TaoCateBll = new BLL.Tao.Category();
        private YSWL.MALL.BLL.Tao.Product ProductBll = new BLL.Tao.Product();
        private void IsExistedTaoCate(HttpContext context)
        {
            string CategoryIdStr = context.Request.Params["CategoryId"];
            int cateId = Globals.SafeInt(CategoryIdStr, -2);
            JsonObject json = new JsonObject();
            if (TaoCateBll.Exists(cateId))
            {
                json.Put(KEY_STATUS, STATUS_SUCCESS);
            }
            else
            {
                json.Put(KEY_STATUS, STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }

        private void GetTaoChildNode(HttpContext context)
        {
            string parentIdStr = context.Request.Params["ParentId"];
            JsonObject json = new JsonObject();
            int parentId = Globals.SafeInt(parentIdStr, 0);
            DataSet ds = TaoCateBll.GetCategorysByParentId(parentId);
            if (ds.Tables[0].Rows.Count < 1)
            {
                json.Accumulate("STATUS", "NODATA");
                context.Response.Write(json.ToString());
                return;
            }
            json.Accumulate("STATUS", "OK");
            json.Accumulate(KEY_DATA, ds.Tables[0]);
            context.Response.Write(json.ToString());
        }

        private void GetTaoDepthNode(HttpContext context)
        {
            int nodeId = Globals.SafeInt(context.Request.Params["NodeId"], 0);
            JsonObject json = new JsonObject();
            List<YSWL.MALL.Model.Tao.Category> list;
            if (nodeId > 0)
            {
                YSWL.MALL.Model.Tao.Category model = TaoCateBll.GetModel(nodeId);
                list = TaoCateBll.GetCategoryByDepth(model.Depth);
            }
            else
            {
                list = TaoCateBll.GetCategoryByDepth(1);
            }
            if (list.Count < 1)
            {
                json.Accumulate("STATUS", "NODATA");
                context.Response.Write(json.ToString());
                return;
            }
            json.Accumulate("STATUS", "OK");
            JsonArray data = new JsonArray();
            list.ForEach(info => data.Add(
                new JsonObject(
                   new string[] { "ClassID", "ClassName" },
                    new object[] { info.CategoryId, info.Name }
                    )));
            json.Accumulate("DATA", data);
            context.Response.Write(json.ToString());
        }

        private void GetTaoParentNode(HttpContext context)
        {
            int ParentId = Globals.SafeInt(context.Request.Params["NodeId"], 0);
            JsonObject json = new JsonObject();
            DataSet ds = TaoCateBll.GetList("");
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                YSWL.MALL.Model.Tao.Category model = TaoCateBll.GetModel(ParentId);
                if (model != null)
                {
                    string[] strList = model.Path.TrimEnd('|').Split('|');
                    string strClassID = string.Empty;
                    if (strList.Length > 0)
                    {
                        List<DataRow[]> list = new List<DataRow[]>();
                        for (int i = 0; i <= strList.Length; i++)
                        {
                            DataRow[] dsParent = null;
                            if (i == 0)
                            {
                                dsParent = dt.Select("ParentID=0");
                            }
                            else
                            {
                                dsParent = dt.Select("ParentID=" + strList[i-1]);
                            }
                            if (dsParent.Length > 0)
                            {
                                list.Add(dsParent);
                            }
                        }
                        json.Accumulate("STATUS", "OK");
                        json.Accumulate("DATA", list);
                        json.Accumulate("PARENT", strList);
                    }
                    else
                    {
                        json.Accumulate("STATUS", "NODATA");
                        context.Response.Write(json.ToString());
                        return;
                    }
                }
            }

            context.Response.Write(json.ToString());
        }

        private void GetTaoProductNodes(HttpContext context)
        {
            int nodeId = Globals.SafeInt(context.Request.Params["NodeId"], 0);
            JsonObject json = new JsonObject();
            CategoryList = new List<Model.Tao.Category>();
            //首先获取顶级的分类
            List<YSWL.MALL.Model.Tao.Category> parentlist = TaoCateBll.GetCategoryByDepth(1);

            if (parentlist.Count < 1)
            {
                json.Accumulate("STATUS", "NODATA");
                context.Response.Write(json.ToString());
                return;
            }
            //构造树形结构
            foreach (var item in parentlist)
            {
                item.Name = "╋" + item.Name;
                CategoryList.Add(item);
                string blank = "├";
                BindNode(item.CategoryId, blank);
            }
            json.Accumulate("STATUS", "OK");
            JsonArray data = new JsonArray();
            CategoryList.ForEach(info => data.Add(
                new JsonObject(
                    new string[] { "ClassID", "ClassName" },
                    new object[] { info.CategoryId, info.Name }
                    )));
            json.Accumulate("DATA", data);
            context.Response.Write(json.ToString());
        }
        //构造节点
        private void BindNode(int parentid, string blank)
        {
            List<YSWL.MALL.Model.Tao.Category> list = TaoCateBll.GetListByParentId(parentid);

            foreach (var item in list)
            {
                //string permissionid=r["PermissionID"].ToString();
                item.Name = blank + "『" + item.Name + "』";
                string blank2 = blank + "─";
                CategoryList.Add(item);
                BindNode(item.CategoryId, blank2);
            }
        }

        private void SetCategory(HttpContext context)
        {
            int ProductId = Globals.SafeInt(context.Request.Params["ProductID"], 0);
            int CategoryId = Globals.SafeInt(context.Request.Params["CategoryID"], 0);
            JsonObject json = new JsonObject();
            if (ProductId > 0 && CategoryId > 0)
            {
                if (ProductBll.UpdateEX(ProductId, CategoryId))
                {
                    json.Accumulate("STATUS", "OK");
                }
            }
            context.Response.Write(json.ToString());
        }
        #endregion 网站商品分类

        #region 淘宝商品分类

        private YSWL.MALL.BLL.Tao.CategorySource taoBaoCateBll = new BLL.Tao.CategorySource();

        private void IsExistedTaoBaoCate(HttpContext context)
        {
            string CategoryIdStr = context.Request.Params["CategoryId"];
            int cateId = Globals.SafeInt(CategoryIdStr, -2);
            JsonObject json = new JsonObject();
            if (taoBaoCateBll.Exists(cateId))
            {
                json.Put(KEY_STATUS, STATUS_SUCCESS);
            }
            else
            {
                json.Put(KEY_STATUS, STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }

        private void GetTaoBaoChildNode(HttpContext context)
        {
            string parentIdStr = context.Request.Params["ParentId"];
            JsonObject json = new JsonObject();
            int parentId = Globals.SafeInt(parentIdStr, 0);
            DataSet ds = taoBaoCateBll.GetCategorysByParentId(parentId);
            if (ds.Tables[0].Rows.Count < 1)
            {
                json.Accumulate("STATUS", "NODATA");
                context.Response.Write(json.ToString());
                return;
            }
            json.Accumulate("STATUS", "OK");
            json.Accumulate(KEY_DATA, ds.Tables[0]);
            context.Response.Write(json.ToString());
        }

        private void GetTaoBaoDepthNode(HttpContext context)
        {
            int nodeId = Globals.SafeInt(context.Request.Params["NodeId"], 0);
            JsonObject json = new JsonObject();
            List<YSWL.MALL.Model.Tao.CategorySource> list;
            if (nodeId > 0)
            {
                YSWL.MALL.Model.Tao.CategorySource model = taoBaoCateBll.GetModel(nodeId);
                list = taoBaoCateBll.GetCategorysByDepth(model.Depth);
            }
            else
            {
                list = taoBaoCateBll.GetCategorysByDepth(1);
            }
            if (list.Count < 1)
            {
                json.Accumulate("STATUS", "NODATA");
                context.Response.Write(json.ToString());
                return;
            }
            json.Accumulate("STATUS", "OK");
            JsonArray data = new JsonArray();
            list.ForEach(info => data.Add(
                new JsonObject(
                    new string[] { "ClassID", "ClassName" },
                    new object[] { info.SourceCId, info.Name }
                    )));
            json.Accumulate("DATA", data);
            context.Response.Write(json.ToString());
        }

        private void GetTaoBaoParentNode(HttpContext context)
        {
            int ParentId = Globals.SafeInt(context.Request.Params["NodeId"], 0);
            JsonObject json = new JsonObject();
            DataSet ds = taoBaoCateBll.GetList("");
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                YSWL.MALL.Model.Tao.CategorySource model = taoBaoCateBll.GetModel(ParentId);
                if (model != null)
                {
                    string[] strList = model.Path.TrimEnd('|').Split('|');
                    string strClassID = string.Empty;
                    if (strList.Length > 0)
                    {
                        List<DataRow[]> list = new List<DataRow[]>();
                        for (int i = 0; i <= strList.Length; i++)
                        {
                            DataRow[] dsParent = null;
                            if (i == 0)
                            {
                                dsParent = dt.Select("ParentId=0");
                            }
                            else
                            {
                                dsParent = dt.Select("ParentId=" + strList[i-1]);
                            }
                            if (dsParent.Length > 0)
                            {
                                list.Add(dsParent);
                            }
                        }
                        json.Accumulate("STATUS", "OK");
                        json.Accumulate("DATA", list);
                        json.Accumulate("PARENT", strList);
                    }
                    else
                    {
                        json.Accumulate("STATUS", "NODATA");
                        context.Response.Write(json.ToString());
                        return;
                    }
                }
            }

            context.Response.Write(json.ToString());
        }

        #endregion 淘宝商品分类

        
    }
}
