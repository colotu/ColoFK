using System;
using System.Data;
namespace YSWL.MALL.IDAL.Tao
{
	/// <summary>
	/// 接口层Category
	/// </summary>
	public interface ICategory
	{
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int CategoryId);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(YSWL.MALL.Model.Tao.Category model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(YSWL.MALL.Model.Tao.Category model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int CategoryId);
        bool DeleteList(string CategoryIdlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        YSWL.MALL.Model.Tao.Category GetModel(int CategoryId);
        YSWL.MALL.Model.Tao.Category DataRowToModel(DataRow row);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        int GetRecordCount(string strWhere);
        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region 扩展方法

        /// <summary>
        /// 添加分类（）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddCategory(YSWL.MALL.Model.Tao.Category model);

        /// <summary>
        /// 修改分类（）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateCategory(YSWL.MALL.Model.Tao.Category model);

        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="IsOrder"></param>
        /// <returns></returns>
        DataSet GetCategoryList(string strWhere);

        /// <summary>
        /// 删除分类信息
        /// </summary>
        bool DeleteCategory(int categoryId);

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <param name="zIndex"></param>
        /// <returns></returns>
        //  bool SwapSequence(int CategoryId, Model.Shop.Products.SwapSequenceIndex zIndex);


        /// <summary>
        /// 对分类进行排序
        /// </summary>
       // bool SwapCategorySequence(int CategoryId, Model.Tao.EnumHelper.SwapSequenceIndex zIndex);
        bool UpdateSourceCate(int CategoryId, int TaoBaoCateId, bool IsLoop);
        bool UpdateSourceCateList(string ids, int TaoBaoCateId, bool IsLoop);
        #endregion 扩展方法
	} 
}
