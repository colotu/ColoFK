using System;
namespace YSWL.MALL.Model.Tao
{
	/// <summary>
	/// Product:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Product
	{
		public Product()
		{}
        #region Model
        private long _productid;
        private string _productname;
        private string _productdescription;
        private decimal _price;
        private int? _categoryid;
        private string _imageurl;
        private string _sellernick;
        private long _sellerscore;
        private string _clickurl;
        private string _shopurl;
        private decimal? _couponrate;
        private decimal? _couponprice;
        private DateTime? _couponstarttime;
        private DateTime? _couponendtime;
        private decimal? _commissionrate;
        private decimal _commission;
        private decimal _rebate;
        private int? _commissionnum;
        private decimal? _commissionvolume;
        private long? _volume;
        private string _shoptype;
        private int? _recomend = 0;
        private int _status;
        private int _sequence = 0;
        private int _skipcount = 0;
        private string _tags;
        private DateTime _createddate;
        /// <summary>
        /// 商品ID
        /// </summary>
        public long ProductID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 产品的名称
        /// </summary>
        public string ProductName
        {
            set { _productname = value; }
            get { return _productname; }
        }
        /// <summary>
        /// 产品的描述
        /// </summary>
        public string ProductDescription
        {
            set { _productdescription = value; }
            get { return _productdescription; }
        }
        /// <summary>
        /// 产品的价格
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 产品所属的分类
        /// </summary>
        public int? CategoryID
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }
        /// <summary>
        /// 产品图片
        /// </summary>
        public string ImageUrl
        {
            set { _imageurl = value; }
            get { return _imageurl; }
        }
        /// <summary>
        /// 卖家昵称
        /// </summary>
        public string SellerNick
        {
            set { _sellernick = value; }
            get { return _sellernick; }
        }
        /// <summary>
        /// 买家信用等级
        /// </summary>
        public long SellerScore
        {
            set { _sellerscore = value; }
            get { return _sellerscore; }
        }
        /// <summary>
        /// 商品推广点击URL
        /// </summary>
        public string ClickUrl
        {
            set { _clickurl = value; }
            get { return _clickurl; }
        }
        /// <summary>
        /// 商品所在店铺的推广点击url
        /// </summary>
        public string ShopUrl
        {
            set { _shopurl = value; }
            get { return _shopurl; }
        }
        /// <summary>
        /// 折扣比率
        /// </summary>
        public decimal? CouponRate
        {
            set { _couponrate = value; }
            get { return _couponrate; }
        }
        /// <summary>
        /// 折扣价格
        /// </summary>
        public decimal? CouponPrice
        {
            set { _couponprice = value; }
            get { return _couponprice; }
        }
        /// <summary>
        /// 折扣开始时间
        /// </summary>
        public DateTime? CouponStartTime
        {
            set { _couponstarttime = value; }
            get { return _couponstarttime; }
        }
        /// <summary>
        /// 折扣结束时间
        /// </summary>
        public DateTime? CouponEndTime
        {
            set { _couponendtime = value; }
            get { return _couponendtime; }
        }
        /// <summary>
        /// 佣金比例
        /// </summary>
        public decimal? CommissionRate
        {
            set { _commissionrate = value; }
            get { return _commissionrate; }
        }
        /// <summary>
        /// 淘宝客佣金
        /// </summary>
        public decimal Commission
        {
            set { _commission = value; }
            get { return _commission; }
        }
        /// <summary>
        /// 返利价格 注：返利价格为 佣金*返利比例 （网站管理员配置）
        /// </summary>
        public decimal Rebate
        {
            set { _rebate = value; }
            get { return _rebate; }
        }
        /// <summary>
        /// 累计成交量.注：返回的数据是30天内累计推广量
        /// </summary>
        public int? CommissionNum
        {
            set { _commissionnum = value; }
            get { return _commissionnum; }
        }
        /// <summary>
        /// 累计总支出佣金量
        /// </summary>
        public decimal? CommissionVolume
        {
            set { _commissionvolume = value; }
            get { return _commissionvolume; }
        }
        /// <summary>
        /// 30天内交易量
        /// </summary>
        public long? Volume
        {
            set { _volume = value; }
            get { return _volume; }
        }
        /// <summary>
        /// 店铺类型:B(商城),C(集市)
        /// </summary>
        public string ShopType
        {
            set { _shoptype = value; }
            get { return _shoptype; }
        }
        /// <summary>
        /// 是否推荐（预留字段）1 推荐到首页
        /// </summary>
        public int? Recomend
        {
            set { _recomend = value; }
            get { return _recomend; }
        }
        /// <summary>
        /// 状态 0:未审核 1：已审核  2：审核未通过 3：分类未明确 4：分类已明确
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
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
        /// 跳转到商品内容网站的次数如taobao(后加的)
        /// </summary>
        public int SkipCount
        {
            set { _skipcount = value; }
            get { return _skipcount; }
        }
        /// <summary>
        /// 标签
        /// </summary>
        public string Tags
        {
            set { _tags = value; }
            get { return _tags; }
        }
        /// <summary>
        /// 添加日期
        /// </summary>
        public DateTime CreatedDate
        {
            set { _createddate = value; }
            get { return _createddate; }
        }
        #endregion Model

	}
}

