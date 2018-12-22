/**
* Vehicles.cs
*
* 功 能： N/A
* 类 名： Vehicles
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/5/4 14:35:11   N/A    初版
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
using YSWL.IDAL.ERP.Packing;
using YSWL.DBUtility;//Please add references
using MySql.Data.MySqlClient;
namespace YSWL.MySqlDAL.ERP.Packing
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
		return DbHelperMySQL.GetMaxID("VehicleId", "ERP_Vehicles"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int VehicleId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ERP_Vehicles");
			strSql.Append(" where VehicleId=?VehicleId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?VehicleId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = VehicleId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.Model.ERP.Packing.Vehicles model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ERP_Vehicles(");
			strSql.Append("VehicleName,BuyDate,BuyPrice,LPN,Color,DriverUserId,DriverUserName,EnableDate,DisableDate,EngineNum,StartMileage,EndMileage,PolicyCompany,RegDate,Specification,Type,VehicleLoad,Capacity,CreatedUserId,CreatedDate,UpdatedUserId,UpdatedDate,Status,Remarks)");
			strSql.Append(" values (");
			strSql.Append("?VehicleName,?BuyDate,?BuyPrice,?LPN,?Color,?DriverUserId,?DriverUserName,?EnableDate,?DisableDate,?EngineNum,?StartMileage,?EndMileage,?PolicyCompany,?RegDate,?Specification,?Type,?VehicleLoad,?Capacity,?CreatedUserId,?CreatedDate,?UpdatedUserId,?UpdatedDate,?Status,?Remarks)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?VehicleName", MySqlDbType.VarChar,50),
					new MySqlParameter("?BuyDate", MySqlDbType.DateTime),
					new MySqlParameter("?BuyPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?LPN", MySqlDbType.VarChar,80),
					new MySqlParameter("?Color", MySqlDbType.VarChar,60),
					new MySqlParameter("?DriverUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?DriverUserName", MySqlDbType.VarChar,60),
					new MySqlParameter("?EnableDate", MySqlDbType.DateTime),
					new MySqlParameter("?DisableDate", MySqlDbType.DateTime),
					new MySqlParameter("?EngineNum", MySqlDbType.VarChar,60),
					new MySqlParameter("?StartMileage", MySqlDbType.Decimal,9),
					new MySqlParameter("?EndMileage", MySqlDbType.Decimal,9),
					new MySqlParameter("?PolicyCompany", MySqlDbType.VarChar,60),
					new MySqlParameter("?RegDate", MySqlDbType.DateTime),
					new MySqlParameter("?Specification", MySqlDbType.VarChar,50),
					new MySqlParameter("?Type", MySqlDbType.Int16,2),
					new MySqlParameter("?VehicleLoad", MySqlDbType.Decimal,9),
					new MySqlParameter("?Capacity", MySqlDbType.Decimal,9),
					new MySqlParameter("?CreatedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?UpdatedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?UpdatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?Remarks", MySqlDbType.VarChar,100)};
			parameters[0].Value = model.VehicleName;
			parameters[1].Value = model.BuyDate;
			parameters[2].Value = model.BuyPrice;
			parameters[3].Value = model.LPN;
			parameters[4].Value = model.Color;
			parameters[5].Value = model.DriverUserId;
			parameters[6].Value = model.DriverUserName;
			parameters[7].Value = model.EnableDate;
			parameters[8].Value = model.DisableDate;
			parameters[9].Value = model.EngineNum;
			parameters[10].Value = model.StartMileage;
			parameters[11].Value = model.EndMileage;
			parameters[12].Value = model.PolicyCompany;
			parameters[13].Value = model.RegDate;
			parameters[14].Value = model.Specification;
			parameters[15].Value = model.Type;
			parameters[16].Value = model.VehicleLoad;
			parameters[17].Value = model.Capacity;
			parameters[18].Value = model.CreatedUserId;
			parameters[19].Value = model.CreatedDate;
			parameters[20].Value = model.UpdatedUserId;
			parameters[21].Value = model.UpdatedDate;
			parameters[22].Value = model.Status;
			parameters[23].Value = model.Remarks;

			object obj = DbHelperMySQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(YSWL.Model.ERP.Packing.Vehicles model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ERP_Vehicles set ");
			strSql.Append("VehicleName=?VehicleName,");
			strSql.Append("BuyDate=?BuyDate,");
			strSql.Append("BuyPrice=?BuyPrice,");
			strSql.Append("LPN=?LPN,");
			strSql.Append("Color=?Color,");
			strSql.Append("DriverUserId=?DriverUserId,");
			strSql.Append("DriverUserName=?DriverUserName,");
			strSql.Append("EnableDate=?EnableDate,");
			strSql.Append("DisableDate=?DisableDate,");
			strSql.Append("EngineNum=?EngineNum,");
			strSql.Append("StartMileage=?StartMileage,");
			strSql.Append("EndMileage=?EndMileage,");
			strSql.Append("PolicyCompany=?PolicyCompany,");
			strSql.Append("RegDate=?RegDate,");
			strSql.Append("Specification=?Specification,");
			strSql.Append("Type=?Type,");
			strSql.Append("VehicleLoad=?VehicleLoad,");
			strSql.Append("Capacity=?Capacity,");
			strSql.Append("CreatedUserId=?CreatedUserId,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("UpdatedUserId=?UpdatedUserId,");
			strSql.Append("UpdatedDate=?UpdatedDate,");
			strSql.Append("Status=?Status,");
			strSql.Append("Remarks=?Remarks");
			strSql.Append(" where VehicleId=?VehicleId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?VehicleName", MySqlDbType.VarChar,50),
					new MySqlParameter("?BuyDate", MySqlDbType.DateTime),
					new MySqlParameter("?BuyPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?LPN", MySqlDbType.VarChar,80),
					new MySqlParameter("?Color", MySqlDbType.VarChar,60),
					new MySqlParameter("?DriverUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?DriverUserName", MySqlDbType.VarChar,60),
					new MySqlParameter("?EnableDate", MySqlDbType.DateTime),
					new MySqlParameter("?DisableDate", MySqlDbType.DateTime),
					new MySqlParameter("?EngineNum", MySqlDbType.VarChar,60),
					new MySqlParameter("?StartMileage", MySqlDbType.Decimal,9),
					new MySqlParameter("?EndMileage", MySqlDbType.Decimal,9),
					new MySqlParameter("?PolicyCompany", MySqlDbType.VarChar,60),
					new MySqlParameter("?RegDate", MySqlDbType.DateTime),
					new MySqlParameter("?Specification", MySqlDbType.VarChar,50),
					new MySqlParameter("?Type", MySqlDbType.Int16,2),
					new MySqlParameter("?VehicleLoad", MySqlDbType.Decimal,9),
					new MySqlParameter("?Capacity", MySqlDbType.Decimal,9),
					new MySqlParameter("?CreatedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?UpdatedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?UpdatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?Remarks", MySqlDbType.VarChar,100),
					new MySqlParameter("?VehicleId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.VehicleName;
			parameters[1].Value = model.BuyDate;
			parameters[2].Value = model.BuyPrice;
			parameters[3].Value = model.LPN;
			parameters[4].Value = model.Color;
			parameters[5].Value = model.DriverUserId;
			parameters[6].Value = model.DriverUserName;
			parameters[7].Value = model.EnableDate;
			parameters[8].Value = model.DisableDate;
			parameters[9].Value = model.EngineNum;
			parameters[10].Value = model.StartMileage;
			parameters[11].Value = model.EndMileage;
			parameters[12].Value = model.PolicyCompany;
			parameters[13].Value = model.RegDate;
			parameters[14].Value = model.Specification;
			parameters[15].Value = model.Type;
			parameters[16].Value = model.VehicleLoad;
			parameters[17].Value = model.Capacity;
			parameters[18].Value = model.CreatedUserId;
			parameters[19].Value = model.CreatedDate;
			parameters[20].Value = model.UpdatedUserId;
			parameters[21].Value = model.UpdatedDate;
			parameters[22].Value = model.Status;
			parameters[23].Value = model.Remarks;
			parameters[24].Value = model.VehicleId;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
			strSql.Append(" where VehicleId=?VehicleId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?VehicleId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = VehicleId;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
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
		public YSWL.Model.ERP.Packing.Vehicles GetModel(int VehicleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  VehicleId,VehicleName,BuyDate,BuyPrice,LPN,Color,DriverUserId,DriverUserName,EnableDate,DisableDate,EngineNum,StartMileage,EndMileage,PolicyCompany,RegDate,Specification,Type,VehicleLoad,Capacity,CreatedUserId,CreatedDate,UpdatedUserId,UpdatedDate,Status,Remarks from ERP_Vehicles ");
            strSql.Append(" where VehicleId=?VehicleId LIMIT 1 ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?VehicleId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = VehicleId;

			YSWL.Model.ERP.Packing.Vehicles model=new YSWL.Model.ERP.Packing.Vehicles();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
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
		public YSWL.Model.ERP.Packing.Vehicles DataRowToModel(DataRow row)
		{
			YSWL.Model.ERP.Packing.Vehicles model=new YSWL.Model.ERP.Packing.Vehicles();
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
				if(row["DriverUserId"]!=null && row["DriverUserId"].ToString()!="")
				{
					model.DriverUserId=int.Parse(row["DriverUserId"].ToString());
				}
				if(row["DriverUserName"]!=null)
				{
					model.DriverUserName=row["DriverUserName"].ToString();
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
				if(row["Type"]!=null && row["Type"].ToString()!="")
				{
					model.Type=int.Parse(row["Type"].ToString());
				}
				if(row["VehicleLoad"]!=null && row["VehicleLoad"].ToString()!="")
				{
					model.VehicleLoad=decimal.Parse(row["VehicleLoad"].ToString());
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
			strSql.Append("select VehicleId,VehicleName,BuyDate,BuyPrice,LPN,Color,DriverUserId,DriverUserName,EnableDate,DisableDate,EngineNum,StartMileage,EndMileage,PolicyCompany,RegDate,Specification,Type,VehicleLoad,Capacity,CreatedUserId,CreatedDate,UpdatedUserId,UpdatedDate,Status,Remarks ");
			strSql.Append(" FROM ERP_Vehicles ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(" VehicleId,VehicleName,BuyDate,BuyPrice,LPN,Color,DriverUserId,DriverUserName,EnableDate,DisableDate,EngineNum,StartMileage,EndMileage,PolicyCompany,RegDate,Specification,Type,VehicleLoad,Capacity,CreatedUserId,CreatedDate,UpdatedUserId,UpdatedDate,Status,Remarks ");
			strSql.Append(" FROM ERP_Vehicles ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            if (Top > 0)
            {
                strSql.Append(" LIMIT " + Top.ToString());
            }
			return DbHelperMySQL.Query(strSql.ToString());
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
			object obj = DbHelperMySQL.GetSingle(strSql.ToString());
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
			strSql.Append("SELECT T.*  from ERP_Vehicles T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append(" order by T." + orderby);
            }
            else
            {
                strSql.Append(" order by T.VehicleId desc");
            }
            strSql.AppendFormat(" LIMIT {0} , {1}", startIndex - 1, endIndex - startIndex + 1);
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("?tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("?fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("?PageSize", MySqlDbType.Int32),
					new MySqlParameter("?PageIndex", MySqlDbType.Int32),
					new MySqlParameter("?IsReCount", MySqlDbType.Bit),
					new MySqlParameter("?OrderType", MySqlDbType.Bit),
					new MySqlParameter("?strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "ERP_Vehicles";
			parameters[1].Value = "VehicleId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListEx(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select VehicleId,VehicleName,BuyDate,BuyPrice,LPN,Color,DriverUserId,DriverUserName,EnableDate,DisableDate,EngineNum,StartMileage,EndMileage,PolicyCompany,RegDate,Specification,Type,VehicleLoad,Capacity,CreatedUserId,CreatedDate,UpdatedUserId,UpdatedDate,v.Status,Remarks,t.TypeName  FROM ERP_Vehicles  v inner join ERP_VehiclesType t on v.Type=t.Id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }
		#endregion  ExtensionMethod
	}
}

