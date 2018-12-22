/**  版本信息模板在安装目录下，可自行修改。
* SuppAreas.cs
*
* 功 能： N/A
* 类 名： SuppAreas
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/28 10:06:27   N/A    初版
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
	/// SuppAreas:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SuppAreas
	{
		public SuppAreas()
		{}
		#region Model
		private int _areaid;
		private int _displaysequence;
		private string _name;
		private string _meta_title;
		private string _meta_description;
		private string _meta_keywords;
		private string _description;
		private int _parentareaid=0;
		private int _depth;
		private string _path;
		private string _rewritename;
		private string _skuprefix;
		private int? _associatedproducttype;
		private string _imageurl;
		private string _notes1;
		private string _notes2;
		private string _notes3;
		private string _notes4;
		private string _notes5;
		private string _theme;
		private bool _haschildren= false;
		private string _seourl;
		private string _seoimagealt;
		private string _seoimagetitle;
		private bool _status= true;
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
		public int DisplaySequence
		{
			set{ _displaysequence=value;}
			get{return _displaysequence;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Meta_Title
		{
			set{ _meta_title=value;}
			get{return _meta_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Meta_Description
		{
			set{ _meta_description=value;}
			get{return _meta_description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Meta_Keywords
		{
			set{ _meta_keywords=value;}
			get{return _meta_keywords;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ParentAreaId
		{
			set{ _parentareaid=value;}
			get{return _parentareaid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Depth
		{
			set{ _depth=value;}
			get{return _depth;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Path
		{
			set{ _path=value;}
			get{return _path;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RewriteName
		{
			set{ _rewritename=value;}
			get{return _rewritename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SKUPrefix
		{
			set{ _skuprefix=value;}
			get{return _skuprefix;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AssociatedProductType
		{
			set{ _associatedproducttype=value;}
			get{return _associatedproducttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ImageUrl
		{
			set{ _imageurl=value;}
			get{return _imageurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Notes1
		{
			set{ _notes1=value;}
			get{return _notes1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Notes2
		{
			set{ _notes2=value;}
			get{return _notes2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Notes3
		{
			set{ _notes3=value;}
			get{return _notes3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Notes4
		{
			set{ _notes4=value;}
			get{return _notes4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Notes5
		{
			set{ _notes5=value;}
			get{return _notes5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Theme
		{
			set{ _theme=value;}
			get{return _theme;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool HasChildren
		{
			set{ _haschildren=value;}
			get{return _haschildren;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SeoUrl
		{
			set{ _seourl=value;}
			get{return _seourl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SeoImageAlt
		{
			set{ _seoimagealt=value;}
			get{return _seoimagealt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SeoImageTitle
		{
			set{ _seoimagetitle=value;}
			get{return _seoimagetitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

