using System;
namespace YSWL.MALL.Model.Tao
{
	/// <summary>
	/// CategorySource:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CategorySource
	{
		public CategorySource()
		{}
        #region Model
        private long _sourcecid;
        private string _name;
        private string _description;
        private int _parentid;
        private string _path;
        private int _depth;
        private int _sequence;
        private bool _haschildren;
        private int _createduserid;
        private DateTime _createddate;
        private int _status;
        private int? _taocategoryid;
        /// <summary>
        /// 
        /// </summary>
        public long SourceCId
        {
            set { _sourcecid = value; }
            get { return _sourcecid; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 父级id
        /// </summary>
        public int ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 路径
        /// </summary>
        public string Path
        {
            set { _path = value; }
            get { return _path; }
        }
        /// <summary>
        /// 深度
        /// </summary>
        public int Depth
        {
            set { _depth = value; }
            get { return _depth; }
        }
        /// <summary>
        /// 顺序
        /// </summary>
        public int Sequence
        {
            set { _sequence = value; }
            get { return _sequence; }
        }
        /// <summary>
        /// 是否有子级
        /// </summary>
        public bool HasChildren
        {
            set { _haschildren = value; }
            get { return _haschildren; }
        }
        /// <summary>
        /// 创建者用户名
        /// </summary>
        public int CreatedUserID
        {
            set { _createduserid = value; }
            get { return _createduserid; }
        }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime CreatedDate
        {
            set { _createddate = value; }
            get { return _createddate; }
        }
        /// <summary>
        /// 状态 0:不可用 1：可用
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 对应本网站淘宝分类
        /// </summary>
        public int? TaoCategoryId
        {
            set { _taocategoryid = value; }
            get { return _taocategoryid; }
        }
        #endregion Model

	}
}

