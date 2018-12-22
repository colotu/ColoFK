﻿/**  版本信息模板在安装目录下，可自行修改。
* Depot.cs
*
* 功 能： N/A
* 类 名： Depot
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/3/28 11:34:27   N/A    初版
*
* Copyright (c) 2012 YSWL Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using YSWL.Common;
using YSWL.MALL.Model.MDM;
using YSWL.MALL.DALFactory;
using YSWL.MALL.IDAL.MDM;
namespace YSWL.MALL.BLL.MDM
{
	/// <summary>
	/// Depot
	/// </summary>
	public partial class Depot
	{
		private readonly IDepot dal=DAMDM.CreateDepot();
		public Depot()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int DepotId)
		{
			return dal.Exists(DepotId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(YSWL.MALL.Model.MDM.Depot model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(YSWL.MALL.Model.MDM.Depot model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int DepotId)
		{
			
			return dal.Delete(DepotId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string DepotIdlist )
		{
			return dal.DeleteList(YSWL.Common.Globals.SafeLongFilter(DepotIdlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public YSWL.MALL.Model.MDM.Depot GetModel(int DepotId)
		{
			
			return dal.GetModel(DepotId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public YSWL.MALL.Model.MDM.Depot GetModelByCache(int DepotId)
		{
			
			string CacheKey = "DepotModel-" + DepotId;
			object objModel = YSWL.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(DepotId);
					if (objModel != null)
					{
						int ModelCache = YSWL.Common.ConfigHelper.GetConfigInt("ModelCache");
						YSWL.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (YSWL.MALL.Model.MDM.Depot)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<YSWL.MALL.Model.MDM.Depot> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<YSWL.MALL.Model.MDM.Depot> DataTableToList(DataTable dt)
		{
			List<YSWL.MALL.Model.MDM.Depot> modelList = new List<YSWL.MALL.Model.MDM.Depot>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				YSWL.MALL.Model.MDM.Depot model;
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
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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
        /// 获取所有的仓库
        /// </summary>
        /// <returns></returns>
        public static List<YSWL.MALL.Model.MDM.Depot> GetAllDepots()
        {
            string CacheKey = "GetAllDepots-Depot";
            object objModel = YSWL.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    YSWL.MALL.BLL.MDM.Depot bll = new Depot();
                    objModel = bll.GetModelList("");
                    if (objModel != null)
                    {
                        int ModelCache = YSWL.Common.ConfigHelper.GetConfigInt("ModelCache");
                        YSWL.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (List<YSWL.MALL.Model.MDM.Depot>)objModel;
        }
        /// <summary>
        /// 获取可用的仓库列表
        /// </summary>
        /// <returns></returns>
	    public static List<YSWL.MALL.Model.MDM.Depot> GetAvaDepots()
        {
            List<YSWL.MALL.Model.MDM.Depot> allList = GetAllDepots();
            if (allList == null || allList.Count == 0)
            {
                return null;
            }
            return allList.Where(c => c.Status == 1).ToList();
        }
        /// <summary>
        /// 获取仓库信息
        /// </summary>
        /// <param name="depotId"></param>
        /// <returns></returns>
	    public static YSWL.MALL.Model.MDM.Depot GetDepotInfo(int depotId)
        {
            List<YSWL.MALL.Model.MDM.Depot> allList = GetAllDepots();
            if (allList == null || allList.Count == 0)
            {
                return null;
            }
            return allList.Find(c => c.DepotId == depotId);
        }


        #endregion  ExtensionMethod
    }
}

