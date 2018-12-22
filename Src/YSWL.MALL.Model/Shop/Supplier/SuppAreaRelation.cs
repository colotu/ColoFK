/**  版本信息模板在安装目录下，可自行修改。
* SuppAreaRelation.cs
*
* 功 能： N/A
* 类 名： SuppAreaRelation
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/3/1 11:13:51   N/A    初版
*
* Copyright (c) 2012 YSWL Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace YSWL.MALL.Model.Shop.Supplier
{
	/// <summary>
	/// SuppAreaRelation:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SuppAreaRelation
	{
		public SuppAreaRelation()
		{}
		#region Model
		private int _areaid;
		private int _supplierid;
		private string _areapath;
		/// <summary>
		/// 
		/// </summary>
		public int AreaId
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SupplierId
		{
			set{ _supplierid=value;}
			get{return _supplierid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AreaPath
		{
			set{ _areapath=value;}
			get{return _areapath;}
		}
		#endregion Model

	}
}

