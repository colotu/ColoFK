﻿/**  版本信息模板在安装目录下，可自行修改。
* NoReplyMsg.cs
*
* 功 能： N/A
* 类 名： NoReplyMsg
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/2/23 17:18:18   N/A    初版
*
* Copyright (c) 2012 YSWL Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
namespace YSWL.WeChat.IDAL.Core
{
	/// <summary>
	/// 接口层NoReplyMsg
	/// </summary>
	public interface INoReplyMsg
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(long MsgId);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		long Add(YSWL.WeChat.Model.Core.NoReplyMsg model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(YSWL.WeChat.Model.Core.NoReplyMsg model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(long MsgId);
		bool DeleteList(string MsgIdlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		YSWL.WeChat.Model.Core.NoReplyMsg GetModel(long MsgId);
		YSWL.WeChat.Model.Core.NoReplyMsg DataRowToModel(DataRow row);
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
        bool UpdateStatus(int msgId, int status);
        long AddMsg(YSWL.WeChat.Model.Core.RequestMsg msg);
        DataSet GetList(int top, int status,string userName, string startdate, string enddate, string keyword, string filedOrder);
		#endregion  MethodEx

       
    } 
}
