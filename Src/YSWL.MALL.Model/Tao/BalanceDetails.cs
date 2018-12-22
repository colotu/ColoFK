using System;
namespace YSWL.MALL.Model.Tao
{
	/// <summary>
	/// BalanceDetails:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BalanceDetails
	{
		public BalanceDetails()
		{}
		#region Model
		private long _journalnumber;
		private int _userid;
		private DateTime _tradedate;
		private int _tradetype;
		private decimal? _income;
		private decimal? _expenses;
		private decimal _balance;
		private int? _payer;
		private int? _payee;
		private string _remark;
		/// <summary>
		/// 流水号
		/// </summary>
		public long JournalNumber
		{
			set{ _journalnumber=value;}
			get{return _journalnumber;}
		}
		/// <summary>
		/// 用户ID
		/// </summary>
		public int UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 交易日期
		/// </summary>
		public DateTime TradeDate
		{
			set{ _tradedate=value;}
			get{return _tradedate;}
		}
		/// <summary>
		/// 交易类型
		/// </summary>
		public int TradeType
		{
			set{ _tradetype=value;}
			get{return _tradetype;}
		}
		/// <summary>
		/// 收入
		/// </summary>
		public decimal? Income
		{
			set{ _income=value;}
			get{return _income;}
		}
		/// <summary>
		/// 费用
		/// </summary>
		public decimal? Expenses
		{
			set{ _expenses=value;}
			get{return _expenses;}
		}
		/// <summary>
		/// 余额
		/// </summary>
		public decimal Balance
		{
			set{ _balance=value;}
			get{return _balance;}
		}
		/// <summary>
		/// 付款人
		/// </summary>
		public int? Payer
		{
			set{ _payer=value;}
			get{return _payer;}
		}
		/// <summary>
		/// 收款人
		/// </summary>
		public int? Payee
		{
			set{ _payee=value;}
			get{return _payee;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

