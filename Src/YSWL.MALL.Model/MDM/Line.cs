/**  版本信息模板在安装目录下，可自行修改。
* Line.cs
*
* 功 能： N/A
* 类 名： Line
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/3/28 16:38:29   N/A    初版
*
* Copyright (c) 2012 YSWL Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace YSWL.MALL.Model.MDM
{
	/// <summary>
	/// Line:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Line
	{
		public Line()
		{}
		#region Model
		private int _lineid;
		private string _linename;
		private int _transporterid;
		private int _linetype;
		private int _startregionid;
		private string _startcontact;
		private string _startphone;
		private string _startaddress;
		private int _endregionid;
		private string _endcontact;
		private string _endphone;
		private string _endaddress;
		private int _minhour;
		private int _maxhour;
		private string _starthour;
		private DateTime _startdate;
		private DateTime _enddate;
		private decimal _mincost;
		private decimal _minpickfee;
		private decimal _minsendfee;
		private decimal _orderfee;
		private decimal _storagefee;
		private int _freedays;
		private int _status;
		private int _createuserid=-1;
		private string _createusername;
		private DateTime _createddate= DateTime.Now;
		private int _updateuserid;
		private string _updateusername;
		private DateTime? _updatedate;
		private string _remark;
		private int _driverid=0;
		/// <summary>
		/// 线路ID
		/// </summary>
		public int LineId
		{
			set{ _lineid=value;}
			get{return _lineid;}
		}
		/// <summary>
		/// 线路名称
		/// </summary>
		public string LineName
		{
			set{ _linename=value;}
			get{return _linename;}
		}
		/// <summary>
		/// 所属 承运商 默认为0：自营
		/// </summary>
		public int TransporterId
		{
			set{ _transporterid=value;}
			get{return _transporterid;}
		}
		/// <summary>
		/// 线路类型 
		/// </summary>
		public int LineType
		{
			set{ _linetype=value;}
			get{return _linetype;}
		}
		/// <summary>
		/// 起始地
		/// </summary>
		public int StartRegionId
		{
			set{ _startregionid=value;}
			get{return _startregionid;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string StartContact
		{
			set{ _startcontact=value;}
			get{return _startcontact;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string StartPhone
		{
			set{ _startphone=value;}
			get{return _startphone;}
		}
		/// <summary>
		/// 详细地址
		/// </summary>
		public string StartAddress
		{
			set{ _startaddress=value;}
			get{return _startaddress;}
		}
		/// <summary>
		/// 目的地
		/// </summary>
		public int EndRegionId
		{
			set{ _endregionid=value;}
			get{return _endregionid;}
		}
		/// <summary>
		/// 目的联系人
		/// </summary>
		public string EndContact
		{
			set{ _endcontact=value;}
			get{return _endcontact;}
		}
		/// <summary>
		/// 目的联系电话
		/// </summary>
		public string EndPhone
		{
			set{ _endphone=value;}
			get{return _endphone;}
		}
		/// <summary>
		/// 目的详细地址
		/// </summary>
		public string EndAddress
		{
			set{ _endaddress=value;}
			get{return _endaddress;}
		}
		/// <summary>
		/// 最小时限
		/// </summary>
		public int MinHour
		{
			set{ _minhour=value;}
			get{return _minhour;}
		}
		/// <summary>
		/// 最大时限
		/// </summary>
		public int MaxHour
		{
			set{ _maxhour=value;}
			get{return _maxhour;}
		}
		/// <summary>
		/// 发车时间
		/// </summary>
		public string StartHour
		{
			set{ _starthour=value;}
			get{return _starthour;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 最低费用
		/// </summary>
		public decimal MinCost
		{
			set{ _mincost=value;}
			get{return _mincost;}
		}
		/// <summary>
		/// 最低提货费
		/// </summary>
		public decimal MinPickFee
		{
			set{ _minpickfee=value;}
			get{return _minpickfee;}
		}
		/// <summary>
		/// 最低配送费
		/// </summary>
		public decimal MinSendFee
		{
			set{ _minsendfee=value;}
			get{return _minsendfee;}
		}
		/// <summary>
		/// 纸质订单费
		/// </summary>
		public decimal OrderFee
		{
			set{ _orderfee=value;}
			get{return _orderfee;}
		}
		/// <summary>
		/// 临时存储费
		/// </summary>
		public decimal StorageFee
		{
			set{ _storagefee=value;}
			get{return _storagefee;}
		}
		/// <summary>
		/// 免费天数
		/// </summary>
		public int FreeDays
		{
			set{ _freedays=value;}
			get{return _freedays;}
		}
		/// <summary>
		/// 状态：1:正常
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 创建ID
		/// </summary>
		public int CreateUserId
		{
			set{ _createuserid=value;}
			get{return _createuserid;}
		}
		/// <summary>
		/// 创建人 （真实姓名）
		/// </summary>
		public string CreateUserName
		{
			set{ _createusername=value;}
			get{return _createusername;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreatedDate
		{
			set{ _createddate=value;}
			get{return _createddate;}
		}
		/// <summary>
		/// 编辑用户
		/// </summary>
		public int UpdateUserId
		{
			set{ _updateuserid=value;}
			get{return _updateuserid;}
		}
		/// <summary>
		/// 编辑人名称
		/// </summary>
		public string UpdateUserName
		{
			set{ _updateusername=value;}
			get{return _updateusername;}
		}
		/// <summary>
		/// 编辑时间
		/// </summary>
		public DateTime? UpdateDate
		{
			set{ _updatedate=value;}
			get{return _updatedate;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 司机ID
		/// </summary>
		public int DriverId
		{
			set{ _driverid=value;}
			get{return _driverid;}
		}
		#endregion Model

	}
}

