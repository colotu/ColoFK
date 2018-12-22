/** 
* Vehicles.cs
*
* 功 能： N/A
* 类 名： Vehicles
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/22 0:36:54   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.IDAL.ERP.Vehicle;
using YSWL.DBUtility;//Please add references
namespace YSWL.SQLServerDAL.ERP.Vehicle
{
	/// <summary>
	/// 数据访问类:Vehicles
	/// </summary>
	public partial class Vehicles:IVehicles
	{
		public Vehicles()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("VehicleId", "ERP_Vehicles"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int VehicleId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ERP_Vehicles");
			strSql.Append(" where VehicleId=@VehicleId");
			SqlParameter[] parameters = {
					new SqlParameter("@VehicleId", SqlDbType.Int,4)
			};
			parameters[0].Value = VehicleId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.Model.ERP.Vehicle.Vehicles model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ERP_Vehicles(");
			strSql.Append("VehicleName,BuyDate,BuyPrice,LPN,Color,DriverId,DriverName,EnableDate,DisableDate,EngineNum,StartMileage,EndMileage,PolicyCompany,RegDate,Specification,Type,Load,Capacity,CreatedUserId,CreatedDate,UpdatedUserId,UpdatedDate,Status,Remarks)");
			strSql.Append(" values (");
			strSql.Append("@VehicleName,@BuyDate,@BuyPrice,@LPN,@Color,@DriverId,@DriverName,@EnableDate,@DisableDate,@EngineNum,@StartMileage,@EndMileage,@PolicyCompany,@RegDate,@Specification,@Type,@Load,@Capacity,@CreatedUserId,@CreatedDate,@UpdatedUserId,@UpdatedDate,@Status,@Remarks)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@VehicleName", SqlDbType.VarChar,50),
					new SqlParameter("@BuyDate", SqlDbType.DateTime),
					new SqlParameter("@BuyPrice", SqlDbType.Money,8),
					new SqlParameter("@LPN", SqlDbType.VarChar,80),
					new SqlParameter("@Color", SqlDbType.VarChar,60),
					new SqlParameter("@DriverId", SqlDbType.Int,4),
					new SqlParameter("@DriverName", SqlDbType.VarChar,60),
					new SqlParameter("@EnableDate", SqlDbType.DateTime),
					new SqlParameter("@DisableDate", SqlDbType.DateTime),
					new SqlParameter("@EngineNum", SqlDbType.VarChar,60),
					new SqlParameter("@StartMileage", SqlDbType.Decimal,9),
					new SqlParameter("@EndMileage", SqlDbType.Decimal,9),
					new SqlParameter("@PolicyCompany", SqlDbType.VarChar,60),
					new SqlParameter("@RegDate", SqlDbType.DateTime),
					new SqlParameter("@Specification", SqlDbType.VarChar,50),
					new SqlParameter("@Type", SqlDbType.VarChar,50),
					new SqlParameter("@Load", SqlDbType.Decimal,9),
					new SqlParameter("@Capacity", SqlDbType.Decimal,9),
					new SqlParameter("@CreatedUserId", SqlDbType.Int,4),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@UpdatedUserId", SqlDbType.Int,4),
					new SqlParameter("@UpdatedDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@Remarks", SqlDbType.VarChar,100)};
			parameters[0].Value = model.VehicleName;
			parameters[1].Value = model.BuyDate;
			parameters[2].Value = model.BuyPrice;
			parameters[3].Value = model.LPN;
			parameters[4].Value = model.Color;
			parameters[5].Value = model.DriverId;
			parameters[6].Value = model.DriverName;
			parameters[7].Value = model.EnableDate;
			parameters[8].Value = model.DisableDate;
			parameters[9].Value = model.EngineNum;
			parameters[10].Value = model.StartMileage;
			parameters[11].Value = model.EndMileage;
			parameters[12].Value = model.PolicyCompany;
			parameters[13].Value = model.RegDate;
			parameters[14].Value = model.Specification;
			parameters[15].Value = model.Type;
			parameters[16].Value = model.Load;
			parameters[17].Value = model.Capacity;
			parameters[18].Value = model.CreatedUserId;
			parameters[19].Value = model.CreatedDate;
			parameters[20].Value = model.UpdatedUserId;
			parameters[21].Value = model.UpdatedDate;
			parameters[22].Value = model.Status;
			parameters[23].Value = model.Remarks;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(YSWL.Model.ERP.Vehicle.Vehicles model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ERP_Vehicles set ");
			strSql.Append("VehicleName=@VehicleName,");
			strSql.Append("BuyDate=@BuyDate,");
			strSql.Append("BuyPrice=@BuyPrice,");
			strSql.Append("LPN=@LPN,");
			strSql.Append("Color=@Color,");
			strSql.Append("DriverId=@DriverId,");
			strSql.Append("DriverName=@DriverName,");
			strSql.Append("EnableDate=@EnableDate,");
			strSql.Append("DisableDate=@DisableDate,");
			strSql.Append("EngineNum=@EngineNum,");
			strSql.Append("StartMileage=@StartMileage,");
			strSql.Append("EndMileage=@EndMileage,");
			strSql.Append("PolicyCompany=@PolicyCompany,");
			strSql.Append("RegDate=@RegDate,");
			strSql.Append("Specification=@Specification,");
			strSql.Append("Type=@Type,");
			strSql.Append("Load=@Load,");
			strSql.Append("Capacity=@Capacity,");
			strSql.Append("CreatedUserId=@CreatedUserId,");
			strSql.Append("CreatedDate=@CreatedDate,");
			strSql.Append("UpdatedUserId=@UpdatedUserId,");
			strSql.Append("UpdatedDate=@UpdatedDate,");
			strSql.Append("Status=@Status,");
			strSql.Append("Remarks=@Remarks");
			strSql.Append(" where VehicleId=@VehicleId");
			SqlParameter[] parameters = {
					new SqlParameter("@VehicleName", SqlDbType.VarChar,50),
					new SqlParameter("@BuyDate", SqlDbType.DateTime),
					new SqlParameter("@BuyPrice", SqlDbType.Money,8),
					new SqlParameter("@LPN", SqlDbType.VarChar,80),
					new SqlParameter("@Color", SqlDbType.VarChar,60),
					new SqlParameter("@DriverId", SqlDbType.Int,4),
					new SqlParameter("@DriverName", SqlDbType.VarChar,60),
					new SqlParameter("@EnableDate", SqlDbType.DateTime),
					new SqlParameter("@DisableDate", SqlDbType.DateTime),
					new SqlParameter("@EngineNum", SqlDbType.VarChar,60),
					new SqlParameter("@StartMileage", SqlDbType.Decimal,9),
					new SqlParameter("@EndMileage", SqlDbType.Decimal,9),
					new SqlParameter("@PolicyCompany", SqlDbType.VarChar,60),
					new SqlParameter("@RegDate", SqlDbType.DateTime),
					new SqlParameter("@Specification", SqlDbType.VarChar,50),
					new SqlParameter("@Type", SqlDbType.VarChar,50),
					new SqlParameter("@Load", SqlDbType.Decimal,9),
					new SqlParameter("@Capacity", SqlDbType.Decimal,9),
					new SqlParameter("@CreatedUserId", SqlDbType.Int,4),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@UpdatedUserId", SqlDbType.Int,4),
					new SqlParameter("@UpdatedDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@Remarks", SqlDbType.VarChar,100),
					new SqlParameter("@VehicleId", SqlDbType.Int,4)};
			parameters[0].Value = model.VehicleName;
			parameters[1].Value = model.BuyDate;
			parameters[2].Value = model.BuyPrice;
			parameters[3].Value = model.LPN;
			parameters[4].Value = model.Color;
			parameters[5].Value = model.DriverId;
			parameters[6].Value = model.DriverName;
			parameters[7].Value = model.EnableDate;
			parameters[8].Value = model.DisableDate;
			parameters[9].Value = model.EngineNum;
			parameters[10].Value = model.StartMileage;
			parameters[11].Value = model.EndMileage;
			parameters[12].Value = model.PolicyCompany;
			parameters[13].Value = model.RegDate;
			parameters[14].Value = model.Specification;
			parameters[15].Value = model.Type;
			parameters[16].Value = model.Load;
			parameters[17].Value = model.Capacity;
			parameters[18].Value = model.CreatedUserId;
			parameters[19].Value = model.CreatedDate;
			parameters[20].Value = model.UpdatedUserId;
			parameters[21].Value = model.UpdatedDate;
			parameters[22].Value = model.Status;
			parameters[23].Value = model.Remarks;
			parameters[24].Value = model.VehicleId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int VehicleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ERP_Vehicles ");
			strSql.Append(" where VehicleId=@VehicleId");
			SqlParameter[] parameters = {
					new SqlParameter("@VehicleId", SqlDbType.Int,4)
			};
			parameters[0].Value = VehicleId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string VehicleIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ERP_Vehicles ");
			strSql.Append(" where VehicleId in ("+VehicleIdlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public YSWL.Model.ERP.Vehicle.Vehicles GetModel(int VehicleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 VehicleId,VehicleName,BuyDate,BuyPrice,LPN,Color,DriverId,DriverName,EnableDate,DisableDate,EngineNum,StartMileage,EndMileage,PolicyCompany,RegDate,Specification,Type,Load,Capacity,CreatedUserId,CreatedDate,UpdatedUserId,UpdatedDate,Status,Remarks from ERP_Vehicles ");
			strSql.Append(" where VehicleId=@VehicleId");
			SqlParameter[] parameters = {
					new SqlParameter("@VehicleId", SqlDbType.Int,4)
			};
			parameters[0].Value = VehicleId;

			YSWL.Model.ERP.Vehicle.Vehicles model=new YSWL.Model.ERP.Vehicle.Vehicles();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public YSWL.Model.ERP.Vehicle.Vehicles DataRowToModel(DataRow row)
		{
			YSWL.Model.ERP.Vehicle.Vehicles model=new YSWL.Model.ERP.Vehicle.Vehicles();
			if (row != null)
			{
				if(row["VehicleId"]!=null && row["VehicleId"].ToString()!="")
				{
					model.VehicleId=int.Parse(row["VehicleId"].ToString());
				}
				if(row["VehicleName"]!=null)
				{
					model.VehicleName=row["VehicleName"].ToString();
				}
				if(row["BuyDate"]!=null && row["BuyDate"].ToString()!="")
				{
					model.BuyDate=DateTime.Parse(row["BuyDate"].ToString());
				}
				if(row["BuyPrice"]!=null && row["BuyPrice"].ToString()!="")
				{
					model.BuyPrice=decimal.Parse(row["BuyPrice"].ToString());
				}
				if(row["LPN"]!=null)
				{
					model.LPN=row["LPN"].ToString();
				}
				if(row["Color"]!=null)
				{
					model.Color=row["Color"].ToString();
				}
				if(row["DriverId"]!=null && row["DriverId"].ToString()!="")
				{
					model.DriverId=int.Parse(row["DriverId"].ToString());
				}
				if(row["DriverName"]!=null)
				{
					model.DriverName=row["DriverName"].ToString();
				}
				if(row["EnableDate"]!=null && row["EnableDate"].ToString()!="")
				{
					model.EnableDate=DateTime.Parse(row["EnableDate"].ToString());
				}
				if(row["DisableDate"]!=null && row["DisableDate"].ToString()!="")
				{
					model.DisableDate=DateTime.Parse(row["DisableDate"].ToString());
				}
				if(row["EngineNum"]!=null)
				{
					model.EngineNum=row["EngineNum"].ToString();
				}
				if(row["StartMileage"]!=null && row["StartMileage"].ToString()!="")
				{
					model.StartMileage=decimal.Parse(row["StartMileage"].ToString());
				}
				if(row["EndMileage"]!=null && row["EndMileage"].ToString()!="")
				{
					model.EndMileage=decimal.Parse(row["EndMileage"].ToString());
				}
				if(row["PolicyCompany"]!=null)
				{
					model.PolicyCompany=row["PolicyCompany"].ToString();
				}
				if(row["RegDate"]!=null && row["RegDate"].ToString()!="")
				{
					model.RegDate=DateTime.Parse(row["RegDate"].ToString());
				}
				if(row["Specification"]!=null)
				{
					model.Specification=row["Specification"].ToString();
				}
				if(row["Type"]!=null)
				{
					model.Type=row["Type"].ToString();
				}
				if(row["Load"]!=null && row["Load"].ToString()!="")
				{
					model.Load=decimal.Parse(row["Load"].ToString());
				}
				if(row["Capacity"]!=null && row["Capacity"].ToString()!="")
				{
					model.Capacity=decimal.Parse(row["Capacity"].ToString());
				}
				if(row["CreatedUserId"]!=null && row["CreatedUserId"].ToString()!="")
				{
					model.CreatedUserId=int.Parse(row["CreatedUserId"].ToString());
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["UpdatedUserId"]!=null && row["UpdatedUserId"].ToString()!="")
				{
					model.UpdatedUserId=int.Parse(row["UpdatedUserId"].ToString());
				}
				if(row["UpdatedDate"]!=null && row["UpdatedDate"].ToString()!="")
				{
					model.UpdatedDate=DateTime.Parse(row["UpdatedDate"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["Remarks"]!=null)
				{
					model.Remarks=row["Remarks"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select VehicleId,VehicleName,BuyDate,BuyPrice,LPN,Color,DriverId,DriverName,EnableDate,DisableDate,EngineNum,StartMileage,EndMileage,PolicyCompany,RegDate,Specification,Type,Load,Capacity,CreatedUserId,CreatedDate,UpdatedUserId,UpdatedDate,Status,Remarks ");
			strSql.Append(" FROM ERP_Vehicles ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" VehicleId,VehicleName,BuyDate,BuyPrice,LPN,Color,DriverId,DriverName,EnableDate,DisableDate,EngineNum,StartMileage,EndMileage,PolicyCompany,RegDate,Specification,Type,Load,Capacity,CreatedUserId,CreatedDate,UpdatedUserId,UpdatedDate,Status,Remarks ");
			strSql.Append(" FROM ERP_Vehicles ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM ERP_Vehicles ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.VehicleId desc");
			}
			strSql.Append(")AS Row, T.*  from ERP_Vehicles T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "ERP_Vehicles";
			parameters[1].Value = "VehicleId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

