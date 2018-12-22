/**  版本信息模板在安装目录下，可自行修改。
* Depot.cs
*
* 功 能： N/A
* 类 名： Depot
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/3/28 11:34:27   N/A    初版
*
* Copyright (c) 2012 YSWL Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.MDM;
using YSWL.DBUtility;//Please add references
namespace YSWL.MALL.SQLServerDAL.MDM
{
	/// <summary>
	/// 数据访问类:Depot
	/// </summary>
	public partial class Depot:IDepot
	{
		public Depot()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DBHelper.DefaultDBHelper.GetMaxID("DepotId", "WMS_Depot"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int DepotId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WMS_Depot");
			strSql.Append(" where DepotId=@DepotId");
			SqlParameter[] parameters = {
					new SqlParameter("@DepotId", SqlDbType.Int,4)
			};
			parameters[0].Value = DepotId;

			return DBHelper.DefaultDBHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.MDM.Depot model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WMS_Depot(");
			strSql.Append("Name,Code,RegionId,Address,ContactName,Phone,Email,Status,HelpCode,CreatedDate,Latitude,Longitude,Type,DepotAttr,Remark)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Code,@RegionId,@Address,@ContactName,@Phone,@Email,@Status,@HelpCode,@CreatedDate,@Latitude,@Longitude,@Type,@DepotAttr,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,200),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@RegionId", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@ContactName", SqlDbType.NVarChar,200),
					new SqlParameter("@Phone", SqlDbType.NVarChar,200),
					new SqlParameter("@Email", SqlDbType.NVarChar,200),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@HelpCode", SqlDbType.NVarChar,50),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@Latitude", SqlDbType.Decimal,9),
					new SqlParameter("@Longitude", SqlDbType.Decimal,9),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@DepotAttr", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,-1)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Code;
			parameters[2].Value = model.RegionId;
			parameters[3].Value = model.Address;
			parameters[4].Value = model.ContactName;
			parameters[5].Value = model.Phone;
			parameters[6].Value = model.Email;
			parameters[7].Value = model.Status;
			parameters[8].Value = model.HelpCode;
			parameters[9].Value = model.CreatedDate;
			parameters[10].Value = model.Latitude;
			parameters[11].Value = model.Longitude;
			parameters[12].Value = model.Type;
			parameters[13].Value = model.DepotAttr;
			parameters[14].Value = model.Remark;

			object obj = DBHelper.DefaultDBHelper.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(YSWL.MALL.Model.MDM.Depot model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WMS_Depot set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Code=@Code,");
			strSql.Append("RegionId=@RegionId,");
			strSql.Append("Address=@Address,");
			strSql.Append("ContactName=@ContactName,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("Email=@Email,");
			strSql.Append("Status=@Status,");
			strSql.Append("HelpCode=@HelpCode,");
			strSql.Append("CreatedDate=@CreatedDate,");
			strSql.Append("Latitude=@Latitude,");
			strSql.Append("Longitude=@Longitude,");
			strSql.Append("Type=@Type,");
			strSql.Append("DepotAttr=@DepotAttr,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where DepotId=@DepotId");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,200),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@RegionId", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@ContactName", SqlDbType.NVarChar,200),
					new SqlParameter("@Phone", SqlDbType.NVarChar,200),
					new SqlParameter("@Email", SqlDbType.NVarChar,200),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@HelpCode", SqlDbType.NVarChar,50),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@Latitude", SqlDbType.Decimal,9),
					new SqlParameter("@Longitude", SqlDbType.Decimal,9),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@DepotAttr", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@DepotId", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Code;
			parameters[2].Value = model.RegionId;
			parameters[3].Value = model.Address;
			parameters[4].Value = model.ContactName;
			parameters[5].Value = model.Phone;
			parameters[6].Value = model.Email;
			parameters[7].Value = model.Status;
			parameters[8].Value = model.HelpCode;
			parameters[9].Value = model.CreatedDate;
			parameters[10].Value = model.Latitude;
			parameters[11].Value = model.Longitude;
			parameters[12].Value = model.Type;
			parameters[13].Value = model.DepotAttr;
			parameters[14].Value = model.Remark;
			parameters[15].Value = model.DepotId;

			int rows=DBHelper.DefaultDBHelper.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int DepotId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WMS_Depot ");
			strSql.Append(" where DepotId=@DepotId");
			SqlParameter[] parameters = {
					new SqlParameter("@DepotId", SqlDbType.Int,4)
			};
			parameters[0].Value = DepotId;

			int rows=DBHelper.DefaultDBHelper.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string DepotIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WMS_Depot ");
			strSql.Append(" where DepotId in ("+DepotIdlist + ")  ");
			int rows=DBHelper.DefaultDBHelper.ExecuteSql(strSql.ToString());
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
		public YSWL.MALL.Model.MDM.Depot GetModel(int DepotId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DepotId,Name,Code,RegionId,Address,ContactName,Phone,Email,Status,HelpCode,CreatedDate,Latitude,Longitude,Type,DepotAttr,Remark from WMS_Depot ");
			strSql.Append(" where DepotId=@DepotId");
			SqlParameter[] parameters = {
					new SqlParameter("@DepotId", SqlDbType.Int,4)
			};
			parameters[0].Value = DepotId;

			YSWL.MALL.Model.MDM.Depot model=new YSWL.MALL.Model.MDM.Depot();
			DataSet ds=DBHelper.DefaultDBHelper.Query(strSql.ToString(),parameters);
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
		public YSWL.MALL.Model.MDM.Depot DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.MDM.Depot model=new YSWL.MALL.Model.MDM.Depot();
			if (row != null)
			{
				if(row["DepotId"]!=null && row["DepotId"].ToString()!="")
				{
					model.DepotId=int.Parse(row["DepotId"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Code"]!=null)
				{
					model.Code=row["Code"].ToString();
				}
				if(row["RegionId"]!=null && row["RegionId"].ToString()!="")
				{
					model.RegionId=int.Parse(row["RegionId"].ToString());
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["ContactName"]!=null)
				{
					model.ContactName=row["ContactName"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["HelpCode"]!=null)
				{
					model.HelpCode=row["HelpCode"].ToString();
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["Latitude"]!=null && row["Latitude"].ToString()!="")
				{
					model.Latitude=decimal.Parse(row["Latitude"].ToString());
				}
				if(row["Longitude"]!=null && row["Longitude"].ToString()!="")
				{
					model.Longitude=decimal.Parse(row["Longitude"].ToString());
				}
				if(row["Type"]!=null && row["Type"].ToString()!="")
				{
					model.Type=int.Parse(row["Type"].ToString());
				}
				if(row["DepotAttr"]!=null && row["DepotAttr"].ToString()!="")
				{
					model.DepotAttr=int.Parse(row["DepotAttr"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
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
			strSql.Append("select DepotId,Name,Code,RegionId,Address,ContactName,Phone,Email,Status,HelpCode,CreatedDate,Latitude,Longitude,Type,DepotAttr,Remark ");
			strSql.Append(" FROM WMS_Depot ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DBHelper.DefaultDBHelper.Query(strSql.ToString());
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
			strSql.Append(" DepotId,Name,Code,RegionId,Address,ContactName,Phone,Email,Status,HelpCode,CreatedDate,Latitude,Longitude,Type,DepotAttr,Remark ");
			strSql.Append(" FROM WMS_Depot ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DBHelper.DefaultDBHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM WMS_Depot ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DBHelper.DefaultDBHelper.GetSingle(strSql.ToString());
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
				strSql.Append("order by T.DepotId desc");
			}
			strSql.Append(")AS Row, T.*  from WMS_Depot T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DBHelper.DefaultDBHelper.Query(strSql.ToString());
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
			parameters[0].Value = "WMS_Depot";
			parameters[1].Value = "DepotId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DBHelper.DefaultDBHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

