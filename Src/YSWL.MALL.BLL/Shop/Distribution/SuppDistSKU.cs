﻿/**  版本信息模板在安装目录下，可自行修改。
* SuppDistSKU.cs
*
* 功 能： N/A
* 类 名： SuppDistSKU
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/1/26 18:31:56   N/A    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using YSWL.Common;
using YSWL.MALL.Model.Shop.Distribution;
using YSWL.MALL.DALFactory;
using YSWL.MALL.IDAL.Shop.Distribution;
namespace YSWL.MALL.BLL.Shop.Distribution
{
	/// <summary>
	/// SuppDistSKU
	/// </summary>
	public partial class SuppDistSKU
	{
        private readonly ISuppDistSKU dal = DAShopDist.CreateSuppDistSKU();
		public SuppDistSKU()
		{}
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int suppId ,string SKU)
        {
            return dal.Exists( suppId,SKU);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(int supplierId, YSWL.MALL.Model.Shop.Distribution.SuppDistSKU model)
        {
            return dal.Add(supplierId,model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(int supplierId, YSWL.MALL.Model.Shop.Distribution.SuppDistSKU model)
        {
            return dal.Update(supplierId,model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int suppId, string SKU)
        {
            return dal.Delete(suppId,SKU);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList( int suppId ,string SKUlist)
        {
            return dal.DeleteList(suppId, Common.Globals.SafeLongFilter(SKUlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Shop.Distribution.SuppDistSKU GetModel(int suppId,string SKU)
        {

            return dal.GetModel(suppId,SKU);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public YSWL.MALL.Model.Shop.Distribution.SuppDistSKU GetModelByCache(int suppId,string SKU)
        {

            string CacheKey = "SuppDistSKUModel-" + SKU+suppId;
            object objModel = YSWL.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(suppId,SKU);
                    if (objModel != null)
                    {
                        int ModelCache = YSWL.Common.ConfigHelper.GetConfigInt("CacheTime");
                        YSWL.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (YSWL.MALL.Model.Shop.Distribution.SuppDistSKU)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int suppId,string strWhere)
        {
            return dal.GetList(suppId,strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int suppId,int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(suppId,Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<YSWL.MALL.Model.Shop.Distribution.SuppDistSKU> GetModelList(int supplierId, string strWhere)
        {
            DataSet ds = dal.GetList(supplierId,strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<YSWL.MALL.Model.Shop.Distribution.SuppDistSKU> DataTableToList(DataTable dt)
        {
            List<YSWL.MALL.Model.Shop.Distribution.SuppDistSKU> modelList = new List<YSWL.MALL.Model.Shop.Distribution.SuppDistSKU>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                YSWL.MALL.Model.Shop.Distribution.SuppDistSKU model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList(int suppId)
        {
            return GetList(suppId,"");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(int suppId,string strWhere)
        {
            return dal.GetRecordCount(suppId,strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(int suppId,string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(suppId,strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
		#region  ExtensionMethod
        /// <summary>
        /// 是否有库存
        /// </summary>
        /// <param name="suppId"></param>
        /// <param name="sku"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public bool HasStock(int suppId, string sku,int sum)
        {
            if (suppId == 0 || String.IsNullOrWhiteSpace(sku))
            {
                return false;
            }
            YSWL.MALL.Model.Shop.Distribution.SuppDistSKU distSkuModel = GetModel(suppId, sku);
            return distSkuModel == null ? false : distSkuModel.Stock > sum;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteEx(int suppId, string SKU)
        {
            YSWL.MALL.Model.Shop.Distribution.SuppDistSKU skuInfo = GetModel(suppId, SKU);
            return skuInfo == null ? false : dal.DeleteEx(suppId, skuInfo);
        }
		#endregion  ExtensionMethod
	}
}

