﻿/**
* SearchWordLog.cs
*
* 功 能： N/A
* 类 名： SearchWordLog
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/9/12 20:14:54   N/A    初版
*
* Copyright (c) 2012-2013 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace YSWL.MALL.Model.SNS
{
	/// <summary>
	/// 搜索日志
	/// </summary>
	[Serializable]
	public partial class SearchWordLog
	{
		public SearchWordLog()
		{}
		#region Model
		private int _id;
		private string _searchword;
		private int _createduserid;
		private string _creatednickname;
		private DateTime _createddate;
		private int _status;
		/// <summary>
		/// 流水id
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 搜索词
		/// </summary>
		public string SearchWord
		{
			set{ _searchword=value;}
			get{return _searchword;}
		}
		/// <summary>
		/// 创建者id
		/// </summary>
		public int CreatedUserId
		{
			set{ _createduserid=value;}
			get{return _createduserid;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string CreatedNickName
		{
			set{ _creatednickname=value;}
			get{return _creatednickname;}
		}
		/// <summary>
		/// 日期
		/// </summary>
		public DateTime CreatedDate
		{
			set{ _createddate=value;}
			get{return _createddate;}
		}
		/// <summary>
        /// 状态 0:不可用 1：可用
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

