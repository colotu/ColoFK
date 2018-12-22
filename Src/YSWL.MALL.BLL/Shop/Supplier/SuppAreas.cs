/**  版本信息模板在安装目录下，可自行修改。
* SuppAreas.cs
*
* 功 能： N/A
* 类 名： SuppAreas
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/28 10:06:27   N/A    初版
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
using YSWL.Common;
using YSWL.MALL.Model.Shop;
using YSWL.MALL.DALFactory;
using YSWL.MALL.IDAL.Shop;
using YSWL.MALL.IDAL.Shop.Supplier;
using YSWL.SAAS.BLL;
using System.Linq;

namespace YSWL.MALL.BLL.Shop.Supplier
{
	/// <summary>
	/// SuppAreas
	/// </summary>
	public partial class SuppAreas
	{
		private readonly ISuppAreas dal= DAShopSupplier.CreateSuppAreas();
        private static DataCacheCore dataCache = new DataCacheCore(new CacheOption
        {
            CacheType = SAASInfo.GetSystemBoolValue("RedisCacheUse") ? CacheType.Redis : CacheType.IIS,
            ReadWriteHosts = SAASInfo.GetSystemValue("RedisCacheReadWriteHosts"),
            ReadOnlyHosts = SAASInfo.GetSystemValue("RedisCacheReadOnlyHosts"),
            DefaultDb = 2
        });
        public SuppAreas()
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
		public bool Exists(int AreaId)
		{
			return dal.Exists(AreaId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(YSWL.MALL.Model.Shop.Supplier.SuppAreas model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(YSWL.MALL.Model.Shop.Supplier.SuppAreas model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int AreaId)
		{
			
			return dal.Delete(AreaId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string AreaIdlist )
		{
			return dal.DeleteList(YSWL.Common.Globals.SafeLongFilter(AreaIdlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public YSWL.MALL.Model.Shop.Supplier.SuppAreas GetModel(int AreaId)
		{
			
			return dal.GetModel(AreaId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public YSWL.MALL.Model.Shop.Supplier.SuppAreas GetModelByCache(int AreaId)
		{
			
			string CacheKey = "SuppAreasModel-" + AreaId;
			object objModel = dataCache.GetCache<YSWL.MALL.Model.Shop.Supplier.SuppAreas>(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(AreaId);
					if (objModel != null)
					{
						int ModelCache = YSWL.Common.ConfigHelper.GetConfigInt("ModelCache");
                        YSWL.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (YSWL.MALL.Model.Shop.Supplier.SuppAreas)objModel;
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
		public List<YSWL.MALL.Model.Shop.Supplier.SuppAreas> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<YSWL.MALL.Model.Shop.Supplier.SuppAreas> DataTableToList(DataTable dt)
		{
			List<YSWL.MALL.Model.Shop.Supplier.SuppAreas> modelList = new List<YSWL.MALL.Model.Shop.Supplier.SuppAreas>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				YSWL.MALL.Model.Shop.Supplier.SuppAreas model;
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
        /// 获得数据列表
        /// </summary>
        public static List<YSWL.MALL.Model.Shop.Supplier.SuppAreas> GetAllAreaList()
        {
            string CacheKey = "GetSuppAreasList-AreasList";
            List<YSWL.MALL.Model.Shop.Supplier.SuppAreas> objModel = dataCache.GetCache<List<YSWL.MALL.Model.Shop.Supplier.SuppAreas>>(CacheKey);
            if (objModel == null)
            {
                try
                {
                    YSWL.MALL.BLL.Shop.Supplier.SuppAreas areasBll = new BLL.Shop.Supplier.SuppAreas();
                    DataSet ds = areasBll.GetList(-1, "", " DisplaySequence");
                    objModel = areasBll.DataTableToList(ds.Tables[0]);
                    if (objModel != null)
                    {
                        int ModelCache = Globals.SafeInt(BLL.SysManage.ConfigSystem.GetValueByCache("ModelCache"), 30);
                        dataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return objModel;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<YSWL.MALL.Model.Shop.Supplier.SuppAreas> GetAvailableList()
        {
            string CacheKey = "GetAvailableSuppAreasList-AreasList";
            List<YSWL.MALL.Model.Shop.Supplier.SuppAreas> objModel = dataCache.GetCache<List<YSWL.MALL.Model.Shop.Supplier.SuppAreas>>(CacheKey);
            if (objModel == null)
            {
                try
                {
                    YSWL.MALL.BLL.Shop.Supplier.SuppAreas areasBll = new BLL.Shop.Supplier.SuppAreas();
                    DataSet ds = areasBll.GetList(-1, "  Status=1 ", " DisplaySequence");
                    objModel = areasBll.DataTableToList(ds.Tables[0]);
                    if (objModel != null)
                    {
                        int ModelCache = Globals.SafeInt(BLL.SysManage.ConfigSystem.GetValueByCache("ModelCache"), 30);
                        dataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch (Exception)
                {

                }
            }
            return objModel;
        }
        /// <summary>
        /// 同级下是否存在同名
        /// </summary>
        /// <param name="parentid"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsExisted(int parentId, string name, int areaId = 0)
        {
            return dal.IsExisted(parentId, name, areaId);
        }
        public bool CreateCategory(Model.Shop.Supplier.SuppAreas model)
        {
            Model.Shop.Supplier.SuppAreas parentModel = GetModel(model.ParentAreaId);
            if (parentModel != null)
            {
                model.Depth = parentModel.Depth + 1;
            }
            else
            {
                model.Depth = 1;
            }
            model.DisplaySequence = GetMaxSeqByCid(model.ParentAreaId) + 1;

            model.Path = "";
            model.AreaId = dal.Add(model);
            if (model.AreaId > 0)
            {
                //更新父分类 是否含有子集
                if (parentModel != null)
                {
                    UpdateHasChild(parentModel.AreaId);
                    model.Path = parentModel.Path + "|" + model.AreaId;
                }
                else
                {
                    model.Path = model.AreaId.ToString();
                }
                return dal.UpdatePath(model);
            }
            return false;
        }
        public int GetMaxSeqByCid(int parentId)
        {
            return dal.GetMaxSeqByCid(parentId);
        }
        //添加编辑时 更新HasChildren 字段
        public bool UpdateHasChild(int cid, int hasChild = 1)
        {
            return dal.UpdateHasChild(cid, hasChild);
        }
        public bool UpdateSeqByCid(int Seq, int Cid)
        {
            return dal.UpdateSeqByCid(Seq, Cid);
        }
        public bool UpdateStatus(bool Status, int Cid)
        {
            return dal.UpdateStatus(Status, Cid);
        }
        /// <summary>
        /// 删除
        /// </summary>
        public DataSet DeleteArea(int areaId, out int Result)
        {
            try
            {
                YSWL.MALL.Model.Shop.Supplier.SuppAreas infoModel = GetModel(areaId);
                DataSet ds = dal.DeleteArea(areaId, out Result);
                if (infoModel != null && infoModel.ParentAreaId > 0)
                {
                    int count = GetRecordCount("ParentAreaId =" + infoModel.ParentAreaId);
                    if (count == 0)
                    {
                        UpdateHasChild(infoModel.ParentAreaId, 0);
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 更新分类信息
        /// </summary>
        public bool UpdateArea(Model.Shop.Supplier.SuppAreas model)
        {
            YSWL.MALL.Model.Shop.Supplier.SuppAreas parentModel = GetModel(model.ParentAreaId);
            string path = model.Path;
            if (parentModel != null)
            {
                model.Depth = parentModel.Depth + 1;
                model.Path = parentModel.Path + "|" + model.AreaId;
            }
            else
            {
                model.Depth = 1;
                model.Path = model.AreaId.ToString();
            }
            if (UpdateEx(model))
            {
                //更新父分类 是否含有子集
                if (parentModel != null)
                {
                    UpdateHasChild(parentModel.AreaId);
                }
                // 需要循环更新该类别下的子分类
                List<YSWL.MALL.Model.Shop.Supplier.SuppAreas> ChildList =
                    GetModelList(" Path Like '" + path + "|%'").OrderBy(c => c.Depth).ToList();
                List<YSWL.MALL.Model.Shop.Supplier.SuppAreas> areaList = new List<Model.Shop.Supplier.SuppAreas>();
                areaList.Add(model);
                areaList.AddRange(ChildList);
                foreach (var item in ChildList)
                {
                    YSWL.MALL.Model.Shop.Supplier.SuppAreas parentItemInfo =
                        areaList.FirstOrDefault(c => c.AreaId == item.ParentAreaId);
                    if (parentItemInfo != null)
                    {
                        item.Depth = parentItemInfo.Depth + 1;
                        item.Path = parentItemInfo.Path + "|" + item.AreaId;
                    }
                    else
                    {
                        item.Depth = 1;
                        item.Path = item.AreaId.ToString();
                    }
                    UpdateDepthAndPath(item.AreaId, item.Depth, item.Path);
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateEx(YSWL.MALL.Model.Shop.Supplier.SuppAreas model)
        {
            return dal.UpdateEx(model);
        }
        public bool UpdateDepthAndPath(int areaId, int Depth, string Path)
        {
            return dal.UpdateDepthAndPath(areaId, Depth, Path);
        }
        public List<YSWL.MALL.Model.Shop.Supplier.SuppAreas> GetAreasByParentId(int parentAreaId, int Top = -1)
        {
            //ADD Cache
            DataSet ds = GetList(Top, " Status=1   and  ParentAreaId = " + parentAreaId, " DisplaySequence");
            return DataTableToList(ds.Tables[0]);
        }
        public DataSet GetAreasByParentIdDs(int parentAreaId)
        {
            //ADD Cache
            return dal.GetList("  Status=1  and   ParentAreaId = " + parentAreaId);
        }
        public List<YSWL.MALL.Model.Shop.Supplier.SuppAreas> GetAreasByDepth(int depth)
        {
            //ADD Cache
            return GetModelList(" Status=1   and  Depth = " + depth);
        }
        #endregion  ExtensionMethod
    }
}

