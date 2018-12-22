/**
* Tags.cs
*
* 功 能： N/A
* 类 名： Tags
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/9/12 20:14:58   N/A    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
namespace YSWL.MALL.IDAL.SNS
{
	/// <summary>
	/// 接口层具体标签表
	/// </summary>
	public interface ITags
	{
		#region  成员方法
		
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        bool Exists(int TypeId, string TagName);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(YSWL.MALL.Model.SNS.Tags model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(YSWL.MALL.Model.SNS.Tags model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int TagID);
		bool DeleteList(string TagIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		YSWL.MALL.Model.SNS.Tags GetModel(int TagID);
		YSWL.MALL.Model.SNS.Tags DataRowToModel(DataRow row);
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
        DataSet GetHotTags(int top);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
		#region  MethodEx
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetListEx(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool UpdateIsRecommand(int IsRecommand, string IdList);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool UpdateStatus(int Status, string IdList);
		#endregion  MethodEx
	} 
}
