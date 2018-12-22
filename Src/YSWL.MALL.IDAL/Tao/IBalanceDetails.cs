using System;
using System.Data;
namespace YSWL.MALL.IDAL.Tao
{
	/// <summary>
	/// 接口层BalanceDetails
	/// </summary>
	public interface IBalanceDetails
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(long JournalNumber);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		long Add(YSWL.MALL.Model.Tao.BalanceDetails model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(YSWL.MALL.Model.Tao.BalanceDetails model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(long JournalNumber);
		bool DeleteList(string JournalNumberlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		YSWL.MALL.Model.Tao.BalanceDetails GetModel(long JournalNumber);
		YSWL.MALL.Model.Tao.BalanceDetails DataRowToModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		int GetRecordCount(string strWhere);
		DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
		#region  MethodEx

		#endregion  MethodEx
	} 
}
