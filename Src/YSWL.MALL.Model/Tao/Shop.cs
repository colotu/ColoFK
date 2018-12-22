using System;
namespace YSWL.MALL.Model.Tao
{
	/// <summary>
	/// Shop:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Shop
	{
		public Shop()
		{}
        #region Model
        private long _shopid;
        private int _categoryid;
        private string _shopname;
        private string _shoplogo;
        private string _sellernick;
        private string _clickurl;
        private string _commissionrate;
        private string _sellercredit;
        private string _totalauction;
        private long _auctioncount;
        private int _recomend;
        private int _status;
        private string _imageurl;
        /// <summary>
        /// 
        /// </summary>
        public long ShopId
        {
            set { _shopid = value; }
            get { return _shopid; }
        }
        /// <summary>
        /// 店铺分类ID
        /// </summary>
        public int CategoryId
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }
        /// <summary>
        /// 店铺名字
        /// </summary>
        public string ShopName
        {
            set { _shopname = value; }
            get { return _shopname; }
        }
        /// <summary>
        /// 店铺LOGO
        /// </summary>
        public string ShopLogo
        {
            set { _shoplogo = value; }
            get { return _shoplogo; }
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
        /// 店铺推广URL
        /// </summary>
        public string ClickUrl
        {
            set { _clickurl = value; }
            get { return _clickurl; }
        }
        /// <summary>
        /// 淘宝客店铺佣金比率
        /// </summary>
        public string CommissionRate
        {
            set { _commissionrate = value; }
            get { return _commissionrate; }
        }
        /// <summary>
        /// 店铺掌柜信用等级
        /// </summary>
        public string SellerCredit
        {
            set { _sellercredit = value; }
            get { return _sellercredit; }
        }
        /// <summary>
        /// 累计推广量
        /// </summary>
        public string TotalAuction
        {
            set { _totalauction = value; }
            get { return _totalauction; }
        }
        /// <summary>
        /// 店铺内商品总数
        /// </summary>
        public long AuctionCount
        {
            set { _auctioncount = value; }
            get { return _auctioncount; }
        }
        /// <summary>
        /// 推荐 0：不推荐 1：推荐到首页 2：推荐到频道
        /// </summary>
        public int Recomend
        {
            set { _recomend = value; }
            get { return _recomend; }
        }
        /// <summary>
        /// 状态 0： 不显示，1：显示
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 店铺的推广图片
        /// </summary>
        public string ImageUrl
        {
            set { _imageurl = value; }
            get { return _imageurl; }
        }
        #endregion Model
        #region 扩展属性
        private YSWL.MALL.Model.Tao.Product _product1;
        private YSWL.MALL.Model.Tao.Product _product2;
        public YSWL.MALL.Model.Tao.Product Product1
        {
            set { _product1 = value; }
            get { return _product1; }
        }

        public YSWL.MALL.Model.Tao.Product Product2
        {
            set { _product2 = value; }
            get { return _product2; }
        }
        #endregion
    }
}

