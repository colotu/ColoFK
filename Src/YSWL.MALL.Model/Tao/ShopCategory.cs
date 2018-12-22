using System;
namespace YSWL.MALL.Model.Tao
{
	/// <summary>
	/// ShopCategory:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ShopCategory
	{
		public ShopCategory()
		{}
		#region Model
		private int _shopcateid;
		private string _name;
		private int _parentid;
		private string _path;
		private int _depth;
		private int _sequence;
		private bool _haschildren;
		private int _status;
		/// <summary>
		/// 店铺分类ID
		/// </summary>
		public int ShopCateId
		{
			set{ _shopcateid=value;}
			get{return _shopcateid;}
		}
		/// <summary>
		/// 分类名称
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 父级id
		/// </summary>
		public int ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
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
		/// 顺序
		/// </summary>
		public int Sequence
		{
			set{ _sequence=value;}
			get{return _sequence;}
		}
		/// <summary>
		/// 是否有子级
		/// </summary>
		public bool HasChildren
		{
			set{ _haschildren=value;}
			get{return _haschildren;}
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

