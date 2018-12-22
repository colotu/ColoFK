/**
* ShopHandler.cs
*
* 功 能： [N/A]
* 类 名： ShopHandler
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/5/27 13:12:07  Rock    初版
* V0.02  2012/6/14 20:09:05  Ben     1. 新增Json模式
* 　　　　　　　　　　　　　　　　　 2. 产品类型相关操作
* 　　　　　　　　　　　　　　　　　 3. 品牌json版相关操作
* 　　　　　　　　　　　　　　　　　 4. 属性/规格相关操作
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using YSWL.Json;
using YSWL.Common;

namespace YSWL.MALL.Web.Handlers.Shop
{
    public class SuppAreaHandler : IHttpHandler
    {
        public const string SHOP_KEY_STATUS = "STATUS";
        public const string SHOP_KEY_DATA = "DATA";

        public const string SHOP_STATUS_SUCCESS = "SUCCESS";
        public const string SHOP_STATUS_FAILED = "FAILED";
        public const string SHOP_STATUS_ERROR = "ERROR";

        #region IHttpHandler 成员

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //安全起见, 所有产品相关Ajax请求为POST模式
            string action = context.Request.Form["Action"];

            context.Response.Clear();
            context.Response.ContentType = "application/json";
            string msg = "";

            #region 加载企业ID
            if (MvcApplication.IsAutoConn)
            {
                string enterpriseStr = YSWL.Common.CallContextHelper.GetAutoTag();
                Common.CallContextHelper.SetAutoTag(Common.Globals.SafeLong(enterpriseStr, 0));
            }
            #endregion

            try
            {
                switch (action)
                {
                    #region 商品分类

                    case "GetChildNode":
                        GetChildNode(context);
                        break;

                    case "GetDepthNode":
                        GetDepthNode(context);
                        break;

                    case "GetParentNode":
                        GetParentNode(context);
                        break;
                    #endregion 商品分类
 
                    default:
                        break;
                }
                context.Response.Write(msg);
            }
            catch (Exception ex)
            {
                JsonObject json = new JsonObject();
                json.Put(SHOP_KEY_STATUS, SHOP_STATUS_ERROR);
                json.Put(SHOP_KEY_DATA, ex.Message);
                context.Response.Write(json.ToString());
            }
        }

        #endregion IHttpHandler 成员
 
         #region 商品分类

        private BLL.Shop.Supplier.SuppAreas suppAreasBll = new BLL.Shop.Supplier.SuppAreas();
 
        private void GetChildNode(HttpContext context)
        {
            string parentIdStr = Common.InjectionFilter.SqlFilter(context.Request.Params["ParentId"]);
            JsonObject json = new JsonObject();
            int parentId = Globals.SafeInt(parentIdStr, 0);
            DataSet ds = suppAreasBll.GetAreasByParentIdDs(parentId);
            if (ds.Tables[0].Rows.Count < 1)
            {
                json.Accumulate("STATUS", "NODATA");
                context.Response.Write(json.ToString());
                return;
            }
            json.Accumulate("STATUS", "OK");
            json.Accumulate(SHOP_KEY_DATA, ds.Tables[0]);
            context.Response.Write(json.ToString());
        }

        private void GetDepthNode(HttpContext context)
        {
            int nodeId = Globals.SafeInt(context.Request.Params["NodeId"], 0);
            JsonObject json = new JsonObject();
            List<YSWL.MALL.Model.Shop.Supplier.SuppAreas> list;
            if (nodeId > 0)
            {
                Model.Shop.Supplier.SuppAreas model = suppAreasBll.GetModel(nodeId);
                list = suppAreasBll.GetAreasByDepth(model.Depth);
            }
            else
            {
                list = suppAreasBll.GetAreasByDepth(1);
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
                    new object[] { info.AreaId, info.Name }
                    )));
            json.Accumulate("DATA", data);
            context.Response.Write(json.ToString());
        }

        private void GetParentNode(HttpContext context)
        {
            int ParentId = Globals.SafeInt(context.Request.Params["NodeId"], 0);
            JsonObject json = new JsonObject();
            DataSet ds = suppAreasBll.GetList("   Status=1  ");
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                Model.Shop.Supplier.SuppAreas model = suppAreasBll.GetModel(ParentId);
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
                                dsParent = dt.Select("ParentAreaId=0");
                            }
                            else
                            {
                                dsParent = dt.Select("ParentAreaId=" + strList[i - 1]);
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

        #endregion 商品分类

    }
}