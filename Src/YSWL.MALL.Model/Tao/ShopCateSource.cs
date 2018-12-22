using System;
namespace YSWL.MALL.Model.Tao
{
	/// <summary>
	/// ShopCateSource:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ShopCateSource
	{
		public ShopCateSource()
		{}
		#region Model
		private int _sourcecateid;
		private int _parentid;
		private string _sourcename;
		private bool _isparent;
		private string _path;
		private int _depth;
		private int? _shopcateid;
		private int _status;
		/// <summary>
		/// 
		/// </summary>
		public int SourceCateId
		{
			set{ _sourcecateid=value;}
			get{return _sourcecateid;}
		}
		/// <summary>
		/// 父分类Id 注：此类目指前台类目，值等于0：表示此类目为一级类目，值不等于0：表示此类目有父类目
		/// </summary>
		public int ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 分类名称
		/// </summary>
		public string SourceName
		{
			set{ _sourcename=value;}
			get{return _sourcename;}
		}
		/// <summary>
		/// 该类目是否为父类目。即：该类目是否还有子类目
		/// </summary>
		public bool IsParent
		{
			set{ _isparent=value;}
			get{return _isparent;}
		}
		/// <summary>
		/// 路径
		/// </summary>
		public string Path
		{
			set{ _path=value;}
			get{return _path;}
		}
		/// <summary>
		/// 深度
		/// </summary>
		public int Depth
		{
			set{ _depth=value;}
			get{return _depth;}
		}
		/// <summary>
		/// 对应本网站店铺分类
		/// </summary>
		public int? ShopCateId
		{
			set{ _shopcateid=value;}
			get{return _shopcateid;}
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

