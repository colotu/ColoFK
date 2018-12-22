using System;
namespace YSWL.MALL.Model.Tao
{
	/// <summary>
	/// Report:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Report
	{
		public Report()
		{}
		#region Model
		private int _reportid;
		private int _userid;
		private int _tradeno;
		private decimal _realpayfee;
		private string _commissionrate;
		private decimal _commission;
		private decimal _rebate;
		private DateTime _paytime;
		private decimal _payprice;
		private int _productid;
		private string _productname;
		private int? _productnum;
		private string _shopname;
		private string _sellername;
		private int? _categoryid;
		private string _categoryname;
		private int _status;
		/// <summary>
		/// 
		/// </summary>
		public int ReportId
		{
			set{ _reportid=value;}
			get{return _reportid;}
		}
		/// <summary>
		/// 购买用户ID
		/// </summary>
		public int UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 淘宝交易号
		/// </summary>
		public int TradeNo
		{
			set{ _tradeno=value;}
			get{return _tradeno;}
		}
		/// <summary>
		/// 实际支付金额
		/// </summary>
		public decimal RealPayFee
		{
			set{ _realpayfee=value;}
			get{return _realpayfee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CommissionRate
		{
			set{ _commissionrate=value;}
			get{return _commissionrate;}
		}
		/// <summary>
		/// 获得的佣金
		/// </summary>
		public decimal Commission
		{
			set{ _commission=value;}
			get{return _commission;}
		}
		/// <summary>
		/// 返利价格 注：返利价格为 佣金*返利比例 （网站管理员配置）
		/// </summary>
		public decimal Rebate
		{
			set{ _rebate=value;}
			get{return _rebate;}
		}
		/// <summary>
		/// 成交时间
		/// </summary>
		public DateTime PayTime
		{
			set{ _paytime=value;}
			get{return _paytime;}
		}
		/// <summary>
		/// 成交价格
		/// </summary>
		public decimal PayPrice
		{
			set{ _payprice=value;}
			get{return _payprice;}
		}
		/// <summary>
		/// 商品ID
		/// </summary>
		public int ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 商品标题
		/// </summary>
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
		/// 商品成交数量
		/// </summary>
		public int? ProductNum
		{
			set{ _productnum=value;}
			get{return _productnum;}
		}
		/// <summary>
		/// 店铺名称
		/// </summary>
		public string ShopName
		{
			set{ _shopname=value;}
			get{return _shopname;}
		}
		/// <summary>
		/// 卖家昵称
		/// </summary>
		public string SellerName
		{
			set{ _sellername=value;}
			get{return _sellername;}
		}
		/// <summary>
		/// 所属分类ID 注：这对应的是淘宝的分类
		/// </summary>
		public int? CategoryId
		{
			set{ _categoryid=value;}
			get{return _categoryid;}
		}
		/// <summary>
		/// 所购买商品的类目名称
		/// </summary>
		public string CategoryName
		{
			set{ _categoryname=value;}
			get{return _categoryname;}
		}
		/// <summary>
		/// 状态 0：未处理 1：已处理 （预留字段）
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model
        #region 扩展属性
        private string _username;
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        #endregion
    }
}

