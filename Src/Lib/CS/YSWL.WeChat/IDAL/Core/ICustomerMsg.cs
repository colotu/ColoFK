﻿/**  版本信息模板在安装目录下，可自行修改。
* CustomerMsg.cs
*
* 功 能： N/A
* 类 名： CustomerMsg
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/21 20:52:18   N/A    初版
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
	/// 接口层CustomerMsg
	/// </summary>
	public interface ICustomerMsg
	{
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(long MsgId);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        long Add(YSWL.WeChat.Model.Core.CustomerMsg model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(YSWL.WeChat.Model.Core.CustomerMsg model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(long MsgId);
        bool DeleteList(string MsgIdlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        YSWL.WeChat.Model.Core.CustomerMsg GetModel(long MsgId);
        YSWL.WeChat.Model.Core.CustomerMsg DataRowToModel(DataRow row);
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
        bool DeleteListEx(string ids);
        DataSet GetList(int top, string openId, string startdate, string enddate, string filedOrder);
		#endregion  MethodEx

    } 
}
