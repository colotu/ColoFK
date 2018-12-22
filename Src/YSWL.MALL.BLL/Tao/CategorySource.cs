using System;
using System.Data;
using System.Collections.Generic;
using YSWL.Common;
using YSWL.MALL.Model.Tao;
using YSWL.MALL.DALFactory;
using YSWL.MALL.IDAL.Tao;
namespace YSWL.MALL.BLL.Tao
{
	/// <summary>
	/// CategorySource
	/// </summary>
	public partial class CategorySource
	{
        private readonly ICategorySource dal = DATao.CreateCategorySource();
		public CategorySource()
		{}
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long SourceCId)
        {
            return dal.Exists(SourceCId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(YSWL.MALL.Model.Tao.CategorySource model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(YSWL.MALL.Model.Tao.CategorySource model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long SourceCId)
        {

            return dal.Delete(SourceCId);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string SourceCIdlist)
        {
            return dal.DeleteList(Common.Globals.SafeLongFilter(SourceCIdlist,0) );
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Tao.CategorySource GetModel(long SourceCId)
        {

            return dal.GetModel(SourceCId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public YSWL.MALL.Model.Tao.CategorySource GetModelByCache(long SourceCId)
        {

            string CacheKey = "CategorySourceModel-" + SourceCId;
            object objModel = YSWL.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(SourceCId);
                    if (objModel != null)
                    {
                      int ModelCache = Globals.SafeInt(BLL.SysManage.ConfigSystem.GetValueByCache("ModelCache"), 30);
                        YSWL.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (YSWL.MALL.Model.Tao.CategorySource)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<YSWL.MALL.Model.Tao.CategorySource> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<YSWL.MALL.Model.Tao.CategorySource> DataTableToList(DataTable dt)
        {
            List<YSWL.MALL.Model.Tao.CategorySource> modelList = new List<YSWL.MALL.Model.Tao.CategorySource>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                YSWL.MALL.Model.Tao.CategorySource model;
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region 扩展方法
        /// <summary>

        public List<YSWL.MALL.Model.Tao.CategorySource> GetCategorysByDepth(int depth)
        {
            //ADD Cache
            return GetModelList("Depth = " + depth);
        }

        public DataSet GetCategorysByParentId(int parentCategoryId)
        {
            //ADD Cache
            return GetList("ParentID = " + parentCategoryId);
        }
        /// <summary>
        /// 添加分类（更新树形结构）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddCategory(YSWL.MALL.Model.Tao.CategorySource model)
        {
            return dal.AddCategory(model);
        }
        /// <summary>
        /// 更新分类(更新树形结构)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateCategory(YSWL.MALL.Model.Tao.CategorySource model)
        {
            return dal.UpdateCategory(model);
        }
        /// <summary>
        /// 根据条件获取分类列表（是否排序）
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="IsOrder"></param>
        /// <returns></returns>
        public DataSet GetCategoryList(string strWhere)
        {
            return dal.GetCategoryList(strWhere);
        }

        /// <summary>
        /// 删除分类信息
        /// </summary>
        public bool DeleteCategory(int categoryId)
        {
            return dal.DeleteCategory(categoryId);
        }
        /// <summary>
        /// 对应淘宝分类ID
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <param name="SNSCateId"></param>
        /// <returns></returns>
        public bool UpdateTaoCate(int CategoryId, int CateId, bool IsLoop)
        {
            return dal.UpdateTaoCate(CategoryId, CateId, IsLoop);
        }
        /// <summary>
        ///批量 对应淘宝分类ID
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <param name="SNSCateId"></param>
        /// <returns></returns>
        public bool UpdateTaoCateList(string ids, int CateId, bool IsLoop)
        {
            return dal.UpdateTaoCateList(ids, CateId, IsLoop);
        }

        ///// <summary>
        ///// 对分类信息进行排序
        ///// </summary>
        //public bool SwapSequence(int CategoryId, Model.Shop.Products.SwapSequenceIndex zIndex)
        //{
        //    return dal.SwapSequence(CategoryId, zIndex);
        //}
        #endregion
	}
}

