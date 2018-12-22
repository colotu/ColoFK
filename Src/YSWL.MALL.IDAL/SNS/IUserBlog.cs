﻿/**
* UserBlog.cs
*
* 功 能： N/A
* 类 名： UserBlog
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/6/3 12:08:16   N/A    初版
*
* Copyright (c) 2012-2013 YS56 Corporation. All rights reserved.
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
	/// 接口层UserBlog
	/// </summary>
	public interface IUserBlog
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int BlogID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(YSWL.MALL.Model.SNS.UserBlog model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(YSWL.MALL.Model.SNS.UserBlog model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int BlogID);
		bool DeleteList(string BlogIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		YSWL.MALL.Model.SNS.UserBlog GetModel(int BlogID);
		YSWL.MALL.Model.SNS.UserBlog DataRowToModel(DataRow row);
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
	    bool UpdatePvCount(int id);

	    int GetPvCount(int id);

	    bool UpdateFavCount(int blogId);

	    bool UpdateCommentCount(int id);

        DataSet  GetActiveUser(int top);

	    bool DeleteEx(int BlogID);

	    bool UpdateStatusList(string ids, int Status);

	    bool UpdateRec(int id, int Rec);
	    bool UpdateRecList(string ids, int Rec);

	    bool DeleteListEx(string BlogIDs);

	    #endregion  MethodEx
	} 
}
