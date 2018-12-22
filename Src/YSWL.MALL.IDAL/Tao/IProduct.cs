using System;
using System.Data;
namespace YSWL.MALL.IDAL.Tao
{
	/// <summary>
	/// 接口层Product
	/// </summary>
	public interface IProduct
	{
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(long ProductID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(YSWL.MALL.Model.Tao.Product model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(YSWL.MALL.Model.Tao.Product model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(long ProductID);
        bool DeleteList(string ProductIDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        YSWL.MALL.Model.Tao.Product GetModel(long ProductID);
        YSWL.MALL.Model.Tao.Product DataRowToModel(DataRow row);
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
		#region  MethodEx
        int GetRecordCountEx(string strWhere, int CateId);

        DataSet GetListEx(string strWhere, int CateId);

        DataSet GetListByPageEx(string strWhere, int CateId, string orderby, int startIndex, int endIndex);

        /// <summary>
        /// 删除一条数据（事务删除）
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        bool DeleteEX(int ProductID);

        /// <summary>
        /// 批量删除数据（事务删除）
        /// </summary>
        /// <param name="ProductIds"></param>
        /// <returns></returns>
        bool DeleteListEX(string ProductIds);

        bool UpdateCateList(string ProductIds, int CateId);

        bool UpdateEX(int ProductId, int CateId);

        bool UpdateRecomendList(string ProductIds, int Recomend);

        bool UpdateRecomend(int ProductId, int Recomend);

        bool UpdateStatus(int ProductId, int Status);

		#endregion  MethodEx
	} 
}
