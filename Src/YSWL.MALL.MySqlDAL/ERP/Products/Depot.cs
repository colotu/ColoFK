/**  版本信息模板在安装目录下，可自行修改。
* Depot.cs
*
* 功 能： N/A
* 类 名： Depot
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/22 16:10:56   N/A    初版
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
using YSWL.IDAL.ERP.Products;
using YSWL.DBUtility;//Please add references
using MySql.Data.MySqlClient;
namespace YSWL.MySqlDAL.ERP.Products
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
		return DbHelperMySQL.GetMaxID("DepotId", "ERP_Depot"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int DepotId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ERP_Depot");
			strSql.Append(" where DepotId=?DepotId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?DepotId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = DepotId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.Model.ERP.Products.Depot model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ERP_Depot(");
			strSql.Append("Name,Code,RegionId,Address,ContactName,Phone,Email,Status,HelpCode,CreatedDate,Latitude,Longitude,Type,Remark)");
			strSql.Append(" values (");
			strSql.Append("?Name,?Code,?RegionId,?Address,?ContactName,?Phone,?Email,?Status,?HelpCode,?CreatedDate,?Latitude,?Longitude,?Type,?Remark)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,200),
					new MySqlParameter("?Code", MySqlDbType.VarChar,50),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4),
					new MySqlParameter("?Address", MySqlDbType.VarChar,200),
					new MySqlParameter("?ContactName", MySqlDbType.VarChar,200),
					new MySqlParameter("?Phone", MySqlDbType.VarChar,200),
					new MySqlParameter("?Email", MySqlDbType.VarChar,200),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?HelpCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Latitude", MySqlDbType.Decimal,9),
					new MySqlParameter("?Longitude", MySqlDbType.Decimal,9),
					new MySqlParameter("?Type", MySqlDbType.Int32,4),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,-1)};
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
			parameters[13].Value = model.Remark;

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
		public bool Update(YSWL.Model.ERP.Products.Depot model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ERP_Depot set ");
			strSql.Append("Name=?Name,");
			strSql.Append("Code=?Code,");
			strSql.Append("RegionId=?RegionId,");
			strSql.Append("Address=?Address,");
			strSql.Append("ContactName=?ContactName,");
			strSql.Append("Phone=?Phone,");
			strSql.Append("Email=?Email,");
			strSql.Append("Status=?Status,");
			strSql.Append("HelpCode=?HelpCode,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("Latitude=?Latitude,");
			strSql.Append("Longitude=?Longitude,");
			strSql.Append("Type=?Type,");
			strSql.Append("Remark=?Remark");
			strSql.Append(" where DepotId=?DepotId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,200),
					new MySqlParameter("?Code", MySqlDbType.VarChar,50),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4),
					new MySqlParameter("?Address", MySqlDbType.VarChar,200),
					new MySqlParameter("?ContactName", MySqlDbType.VarChar,200),
					new MySqlParameter("?Phone", MySqlDbType.VarChar,200),
					new MySqlParameter("?Email", MySqlDbType.VarChar,200),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?HelpCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Latitude", MySqlDbType.Decimal,9),
					new MySqlParameter("?Longitude", MySqlDbType.Decimal,9),
					new MySqlParameter("?Type", MySqlDbType.Int32,4),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,-1),
					new MySqlParameter("?DepotId", MySqlDbType.Int32,4)};
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
			parameters[13].Value = model.Remark;
			parameters[14].Value = model.DepotId;

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
		public bool Delete(int DepotId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ERP_Depot ");
			strSql.Append(" where DepotId=?DepotId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?DepotId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = DepotId;

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
		public bool DeleteList(string DepotIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ERP_Depot ");
			strSql.Append(" where DepotId in ("+DepotIdlist + ")  ");
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
		public YSWL.Model.ERP.Products.Depot GetModel(int DepotId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  DepotId,Name,Code,RegionId,Address,ContactName,Phone,Email,Status,HelpCode,CreatedDate,Latitude,Longitude,Type,Remark from ERP_Depot ");
            strSql.Append(" where DepotId=?DepotId LIMIT 1 ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?DepotId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = DepotId;

			YSWL.Model.ERP.Products.Depot model=new YSWL.Model.ERP.Products.Depot();
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
		public YSWL.Model.ERP.Products.Depot DataRowToModel(DataRow row)
		{
			YSWL.Model.ERP.Products.Depot model=new YSWL.Model.ERP.Products.Depot();
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
			strSql.Append("select DepotId,Name,Code,RegionId,Address,ContactName,Phone,Email,Status,HelpCode,CreatedDate,Latitude,Longitude,Type,Remark ");
			strSql.Append(" FROM ERP_Depot ");
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
			
			strSql.Append(" DepotId,Name,Code,RegionId,Address,ContactName,Phone,Email,Status,HelpCode,CreatedDate,Latitude,Longitude,Type,Remark ");
			strSql.Append(" FROM ERP_Depot ");
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
			strSql.Append("select count(1) FROM ERP_Depot ");
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
			strSql.Append("SELECT T.*  from ERP_Depot T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.DepotId desc");
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
			parameters[0].Value = "ERP_Depot";
			parameters[1].Value = "DepotId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

