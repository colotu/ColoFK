using System;
using System.Data;
using System.Collections.Generic;
using YSWL.Common;
using YSWL.MALL.Model.Tao;
using YSWL.MALL.DALFactory;
using YSWL.MALL.IDAL.Tao;
using YSWL.TaoBao;
using YSWL.TaoBao.Request;
using YSWL.TaoBao.Response;
namespace YSWL.MALL.BLL.Tao
{
	/// <summary>
	/// ShopCateSource
	/// </summary>
	public partial class ShopCateSource
	{
        private readonly IShopCateSource dal = DATao.CreateShopCateSource();
		public ShopCateSource()
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
        public bool Exists(int SourceCateId)
        {
            return dal.Exists(SourceCateId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(YSWL.MALL.Model.Tao.ShopCateSource model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(YSWL.MALL.Model.Tao.ShopCateSource model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int SourceCateId)
        {

            return dal.Delete(SourceCateId);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string SourceCateIdlist)
        {
            return dal.DeleteList(Common.Globals.SafeLongFilter(SourceCateIdlist,0) );
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Tao.ShopCateSource GetModel(int SourceCateId)
        {

            return dal.GetModel(SourceCateId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public YSWL.MALL.Model.Tao.ShopCateSource GetModelByCache(int SourceCateId)
        {

            string CacheKey = "ShopCateSourceModel-" + SourceCateId;
            object objModel = YSWL.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(SourceCateId);
                    if (objModel != null)
                    {
                      int ModelCache = Globals.SafeInt(BLL.SysManage.ConfigSystem.GetValueByCache("ModelCache"), 30);
                        YSWL.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (YSWL.MALL.Model.Tao.ShopCateSource)objModel;
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
        public List<YSWL.MALL.Model.Tao.ShopCateSource> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<YSWL.MALL.Model.Tao.ShopCateSource> DataTableToList(DataTable dt)
        {
            List<YSWL.MALL.Model.Tao.ShopCateSource> modelList = new List<YSWL.MALL.Model.Tao.ShopCateSource>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                YSWL.MALL.Model.Tao.ShopCateSource model;
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
		#region  ExtensionMethod
        public void GetSourceDate()
        {
            ITopClient client = BLL.SNS.TaoBaoConfig.GetTopClient();
            ShopcatsListGetRequest req = new ShopcatsListGetRequest();
            req.Fields = "cid,parent_cid,name,is_parent";
            ShopcatsListGetResponse response = client.Execute(req);
            if (response.ShopCats.Count > 0)
            {
                YSWL.MALL.Model.Tao.ShopCateSource source = null;
                foreach (var item in response.ShopCats)
                {
                    if (!Exists(Convert.ToInt32(item.Cid)))
                    {
                        source = new YSWL.MALL.Model.Tao.ShopCateSource();
                        source.Depth = 1;
                        source.Path = "";
                        source.IsParent = item.IsParent;
                        source.ParentId = Convert.ToInt32(item.ParentCid);
                        source.SourceName = item.Name;
                        source.Status = 1;
                        source.SourceCateId = Convert.ToInt32(item.Cid);
                        Add(source);
                    }
                }
            }
        }
        public bool UpdateStateList(string ids, int state)
        {
            return dal.UpdateStateList(ids, state);
        }
		#endregion  ExtensionMethod
	}
}

