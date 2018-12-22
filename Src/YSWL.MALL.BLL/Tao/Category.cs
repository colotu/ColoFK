using System;
using System.Data;
using System.Collections.Generic;
using System.Threading;
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
	/// Category
	/// </summary>
	public partial class Category
	{
        private readonly ICategory dal = DATao.CreateCategory();
		public Category()
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
        public bool Exists(int CategoryId)
        {
            return dal.Exists(CategoryId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(YSWL.MALL.Model.Tao.Category model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(YSWL.MALL.Model.Tao.Category model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int CategoryId)
        {

            return dal.Delete(CategoryId);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string CategoryIdlist)
        {
            return dal.DeleteList(Common.Globals.SafeLongFilter(CategoryIdlist,0) );
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Tao.Category GetModel(int CategoryId)
        {

            return dal.GetModel(CategoryId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public YSWL.MALL.Model.Tao.Category GetModelByCache(int CategoryId)
        {

            string CacheKey = "CategoryModel-" + CategoryId;
            object objModel = YSWL.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(CategoryId);
                    if (objModel != null)
                    {
                      int ModelCache = Globals.SafeInt(BLL.SysManage.ConfigSystem.GetValueByCache("ModelCache"), 30);
                        YSWL.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (YSWL.MALL.Model.Tao.Category)objModel;
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
        public List<YSWL.MALL.Model.Tao.Category> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<YSWL.MALL.Model.Tao.Category> DataTableToList(DataTable dt)
        {
            List<YSWL.MALL.Model.Tao.Category> modelList = new List<YSWL.MALL.Model.Tao.Category>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                YSWL.MALL.Model.Tao.Category model;
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
        #region ExtensionMethod

        ///// <summary>
        ///// 对商品的类别进行全部更新或初始化
        ///// </summary>
        //public void ResetCategory()
        //{
        //    CategoryLoop(0L, "", 0);
        //}

        /////<summary>
        /////获取淘宝的全部分类，采用递归调用的方式,(初始化或更新某一个类别),管理员操作
        ////</summary>
        ////<param name="CategoryId">类别的名称 如果是初始化类别，则是0L</param>
        ////<param name="Path">路径，如果是初始化则为""</param>
        ////<param name="Depth">深度，如果是初始化则为0</param>
        //public void CategoryLoop(long CategoryId, string Path, int Depth)
        //{
        //    string TaoBaoAppkey = SysManage.ConfigSystem.GetValue("OpenAPI_TaoBaoAppkey");
        //    string TaobaoAppsecret = SysManage.ConfigSystem.GetValue("OpenAPI_TaobaoAppsecret");
        //    string TaobaoApiUrl = SysManage.ConfigSystem.GetValue("OpenAPI_TaobaoApiUrl");
        //    YSWL.MALL.Model.Tao.Category CateModel = new Model.Tao.Category();
        //    ITopClient client = new DefaultTopClient(TaobaoApiUrl, TaoBaoAppkey, TaobaoAppsecret);
        //    ItemcatsGetRequest req = new ItemcatsGetRequest();
        //    req.Fields = "cid,parent_cid,name,is_parent";
        //    req.ParentCid = CategoryId;
        //    ItemcatsGetResponse response = client.Execute(req);
        //    if (response.ItemCats.Count > 0)
        //    {
        //        foreach (var item in response.ItemCats)
        //        {
        //            CateModel.CategoryId = Common.Globals.SafeInt(item.Cid.ToString(), 0);

        //            // 存在则删除
        //            if (Exists(item.Name))
        //            {
        //                Delete(CateModel.CategoryId);
        //            }
        //            else
        //            {
        //                CateModel.ParentID = Common.Globals.SafeInt(item.ParentCid.ToString(), 0);
        //                if (string.IsNullOrEmpty(Path))
        //                {
        //                    CateModel.Path = item.Cid.ToString();
        //                }
        //                else
        //                {
        //                    CateModel.Path = Path + "|" + item.Cid.ToString();
        //                }
        //                CateModel.Depth = Depth + 1;
        //                CateModel.CreatedDate = DateTime.Now;
        //                CateModel.CreatedUserID = 1;
        //                CateModel.Description = "暂无描述";
        //                CateModel.HasChildren = item.IsParent;
        //                CateModel.IsMenu = false;
        //                CateModel.MenuIsShow = false;
        //                CateModel.MenuSequence = 0;
        //                CateModel.Name = item.Name;
        //                CateModel.Status = 1;
        //                CateModel.Type = 0;
        //                Add(CateModel);

        //                ///测试阶段，淘宝的限制是没分钟400次访问
        //                Thread primaryThread = Thread.CurrentThread;
        //                Thread.Sleep(500);

        //                //下面是递归调用和相应的出口（没有子集的情况下，直接返回）
        //                if (item.IsParent)
        //                {
        //                    CategoryLoop(item.Cid, CateModel.Path, CateModel.Depth);
        //                }
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 递归调用插入类别表当中的数据
        ///// </summary>
        ///// <param name="CategoryId"></param>
        ///// <returns></returns>
        //public bool AddCategoryByLoop(int CategoryId)
        //{
        //}

        public List<YSWL.MALL.Model.Tao.Category> GetChildrenListById(int Cid)
        {
            return GetModelList("Depth=3 AND Path LIKE '" + Cid + "|%' ");
        }

        /// <summary>
        /// 得到最顶级的栏目名称
        /// </summary>
        /// <returns></returns>
        public List<YSWL.MALL.Model.Tao.Category> GetMenuByCategory()
        {
            return GetModelList("ParentID=0 and IsMenu=1 and  Type=0");
        }

        #region 获取商品分类（For逛宝贝和商品类别页面）含缓存

        /// <summary>
        /// 获取一个分类下面的子分类和子分类的分类
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        //public YSWL.MALL.ViewModel.Tao.ProductCategory GetCateListByParentId(int ParentID)
        //{
        //    YSWL.MALL.ViewModel.Tao.ProductCategory ParentList = new ViewModel.Tao.ProductCategory();
        //    if (ParentID == 0)
        //    {
        //        return ParentList;
        //    }
        //    YSWL.MALL.Model.Tao.Category ParentModel = GetModel(ParentID);
        //    ParentList.CurrentCateName = ParentModel == null ? "暂无" : ParentModel.Name;
        //    ParentList.CurrentCid = ParentID;
        //    List<YSWL.MALL.Model.Tao.Category> list = GetModelList("ParentID=" + ParentID + "");
        //    foreach (YSWL.MALL.Model.Tao.Category items in list)
        //    {
        //        YSWL.MALL.ViewModel.Tao.SonCategory SonList = new ViewModel.Tao.SonCategory();
        //        SonList.ParentModel = items;
        //        SonList.Grandson = GetModelList("ParentID=" + items.CategoryId + "");
        //        ParentList.SonList.Add(SonList);
        //    }
        //    return ParentList;
        //}

        /// <summary>
        /// 缓存获取一个分类下面的子分类和子分类的分类
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        //public YSWL.MALL.ViewModel.Tao.ProductCategory GetCacheCateListByParentId(int ParentID)
        //{
        //    string CacheKey = "CacheCateList-" + ParentID;
        //    object objModel = YSWL.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = GetCateListByParentId(ParentID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Globals.SafeInt(BLL.SysManage.ConfigSystem.GetValueByCache("ModelCache"), 30);
        //                YSWL.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (YSWL.MALL.ViewModel.Tao.ProductCategory)objModel;
        //}

        #endregion 获取商品分类（For逛宝贝和商品类别页面）含缓存

        #region 获取商品分类（For首页）含缓存

        /// <summary>
        /// For首页获取一个分类下面的子分类和子分类的分类
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        //public YSWL.MALL.ViewModel.Tao.ProductCategory GetCateListByParentIdEx(int ParentID)
        //{
        //    YSWL.MALL.ViewModel.Tao.ProductCategory ParentList = new ViewModel.Tao.ProductCategory();
        //    if (ParentID == 0)
        //    {
        //        return ParentList;
        //    }
        //    YSWL.MALL.Model.Tao.Category ParentModel = GetModel(ParentID);
        //    ParentList.CurrentCateName = (ParentModel == null ? "暂无" : ParentModel.Name);
        //    ParentList.CurrentCid = ParentID;
        //    List<YSWL.MALL.Model.Tao.Category> list = GetModelList("ParentID=" + ParentID + "");
        //    foreach (YSWL.MALL.Model.Tao.Category items in list)
        //    {
        //        YSWL.MALL.ViewModel.Tao.SonCategory SonList = new ViewModel.Tao.SonCategory();
        //        SonList.ParentModel = items;
        //        SonList.Grandson = DataTableToList(GetListByPage("ParentID=" + items.CategoryId + "", "", 1, 5).Tables[0]);
        //        ParentList.SonList.Add(SonList);
        //    }
        //    return ParentList;
        //}

        /// <summary>
        /// For首页缓存获取一个分类下面的子分类和子分类的分类
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        //public YSWL.MALL.ViewModel.Tao.ProductCategory GetCacheCateListByParentIdEx(int ParentID)
        //{
        //    string CacheKey = "CacheCateListEx-" + ParentID;
        //    object objModel = YSWL.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = GetCateListByParentIdEx(ParentID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Globals.SafeInt(BLL.SysManage.ConfigSystem.GetValueByCache("ModelCache"), 30);
        //                YSWL.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (YSWL.MALL.ViewModel.Tao.ProductCategory)objModel;
        //}

        #endregion 获取商品分类（For首页）含缓存

        #region 顶级分类的下面子分类

        //public List<YSWL.MALL.ViewModel.Tao.ProductCategory> GetChildByMenu()
        //{
        //    List<YSWL.MALL.Model.Tao.Category> TopList = GetMenuByCategory();
        //    List<YSWL.MALL.ViewModel.Tao.ProductCategory> ResultList = new List<ViewModel.Tao.ProductCategory>();
        //    foreach (YSWL.MALL.Model.Tao.Category item in TopList)
        //    {
        //        YSWL.MALL.ViewModel.Tao.ProductCategory ParentList = new ViewModel.Tao.ProductCategory();
        //        ParentList.ParentModel = item;
        //        List<YSWL.MALL.Model.Tao.Category> list = GetChildrenListById(item.CategoryId);
        //        ParentList.ChildList = list.Take(10).ToList();
        //        ResultList.Add(ParentList);
        //    }
        //    return ResultList;
        //}

        #endregion 顶级分类的下面子分类

        /// <summary>
        /// 根据类别的id获取其最顶级的父级的名称（后期要家缓存）
        /// </summary>
        /// <param name="Cid"></param>
        public string GetTopNameByCid(int Cid)
        {
            YSWL.MALL.Model.Tao.Category Cmodel = new Model.Tao.Category();
            Cmodel = GetModel(Cid);
            if (Cmodel.ParentID == 0 || Cmodel.Depth == 1)
            {
                return Cmodel == null ? "暂无分类" : Cmodel.Name;
            }
            else
            {
                string[] ids = Cmodel.Path.Split('|');
                if (ids.Length > 0)
                {
                    Cmodel = GetModel(Common.Globals.SafeInt(ids[0], 0));
                    return Cmodel == null ? "暂无分类" : Cmodel.Name;
                }
                return "暂无分类";
            }
        }

        /// <summary>
        /// 根据类别的id获取其最顶级的父级的id（后期要家缓存）
        /// </summary>
        /// <param name="Cid"></param>
        public int GetTopCidByChildCid(int Cid)
        {
            YSWL.MALL.Model.Tao.Category Cmodel = new Model.Tao.Category();
            Cmodel = GetModel(Cid);
            if (Cmodel == null || Cmodel.ParentID == 0 || Cmodel.Depth == 1)
            {
                return Cid;
            }
            else
            {
                string[] ids = Cmodel.Path.Split('|');
                if (ids.Length > 0)
                {
                    return Common.Globals.SafeInt(ids[0], 0);
                }
                return 0;
            }
        }

        /// <summary>
        /// 根据类别的名称获取其最顶级的父级的名称（后期要家缓存）
        /// </summary>
        /// <param name="Cid"></param>
        public string GetTopNameByCid(string Name)
        {
            YSWL.MALL.Model.Tao.Category Cmodel = new Model.Tao.Category();
            Cmodel = GetModel(Name);
            if (Cmodel.ParentID == 0 || Cmodel.Depth == 1)
            {
                return Cmodel == null ? "暂无分类" : Cmodel.Name;
            }
            else
            {
                string[] ids = Cmodel.Path.Split('|');
                if (ids.Length > 0)
                {
                    Cmodel = GetModel(Common.Globals.SafeInt(ids[0], 0));
                    return Cmodel == null ? "暂无分类" : Cmodel.Name;
                }
                return "暂无分类";
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Tao.Category GetModel(string Name)
        {
            List<YSWL.MALL.Model.Tao.Category> list = GetModelList("Name='" + Common.InjectionFilter.SqlFilter(Name) + "'");
            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }

        #endregion ExtensionMethod

        #region 扩展方法

        /// <summary>
        /// 判断分类下是否存在礼品
        /// </summary>

        public List<YSWL.MALL.Model.Tao.Category> GetCategoryByDepth(int depth)
        {
            //ADD Cache
            return GetModelList("Depth = " + depth  );
        }

        public DataSet GetCategorysByParentId(int parentCategoryId)
        {
            //ADD Cache
            return GetList("ParentID = " + parentCategoryId);
        }

        public List<YSWL.MALL.Model.Tao.Category> GetListByParentId(int parentCategoryId)
        {
            //ADD Cache
            return GetModelList("ParentID = " + parentCategoryId);
        }

        /// <summary>
        /// 添加分类（更新树形结构）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddCategory(YSWL.MALL.Model.Tao.Category model)
        {
            return dal.AddCategory(model);
        }

        /// <summary>
        /// 更新分类(更新树形结构)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateCategory(YSWL.MALL.Model.Tao.Category model)
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

        ///// <summary>
        ///// 对分类信息进行排序
        ///// </summary>
        //public bool SwapSequence(int CategoryId, Model.Shop.Products.SwapSequenceIndex zIndex)
        //{
        //    return dal.SwapSequence(CategoryId, zIndex);
        //}

        /// <summary>
        /// 对分类进行排序
        /// </summary>


        public bool UpdateSourceCate(int CategoryId, int TaoBaoCateId, bool IsLoop)
        {
            return dal.UpdateSourceCate(CategoryId, TaoBaoCateId, IsLoop);
        }
        public bool UpdateSourceCateList(string ids, int TaoBaoCateId, bool IsLoop)
        {
            return dal.UpdateSourceCateList(ids, TaoBaoCateId, IsLoop);
        }
        #endregion 扩展方法
	}
}

