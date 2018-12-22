/**  版本信息模板在安装目录下，可自行修改。
* Services.cs
*
* 功 能： N/A
* 类 名： Services
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/1/2 17:36:20   N/A    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Appt;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Appt
{
	/// <summary>
	/// 数据访问类:Services
	/// </summary>
	public partial class Services:IServices
	{
		public Services()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ServiceId", "Appt_Services"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ServiceId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Appt_Services");
			strSql.Append(" where ServiceId=?ServiceId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ServiceId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ServiceId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.Appt.Services model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Appt_Services(");
			strSql.Append("Name,StartDate,EndDate,IsPay,ServiceType,RuleType,MaxCount,Summary,Description,ImageUrl,ThumbnailUrl,Remark)");
			strSql.Append(" values (");
			strSql.Append("?Name,?StartDate,?EndDate,?IsPay,?ServiceType,?RuleType,?MaxCount,?Summary,?Description,?ImageUrl,?ThumbnailUrl,?Remark)");
			strSql.Append(";select last_insert_id()");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,50),
					new MySqlParameter("?StartDate", MySqlDbType.DateTime),
					new MySqlParameter("?EndDate", MySqlDbType.DateTime),
					new MySqlParameter("?IsPay", MySqlDbType.Bit,1),
					new MySqlParameter("?ServiceType", MySqlDbType.Int16,2),
					new MySqlParameter("?RuleType", MySqlDbType.Int16,2),
					new MySqlParameter("?MaxCount", MySqlDbType.Int16,2),
					new MySqlParameter("?Summary", MySqlDbType.VarChar,200),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("?ThumbnailUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,100)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.StartDate;
			parameters[2].Value = model.EndDate;
			parameters[3].Value = model.IsPay;
			parameters[4].Value = model.ServiceType;
			parameters[5].Value = model.RuleType;
			parameters[6].Value = model.MaxCount;
			parameters[7].Value = model.Summary;
			parameters[8].Value = model.Description;
			parameters[9].Value = model.ImageUrl;
			parameters[10].Value = model.ThumbnailUrl;
			parameters[11].Value = model.Remark;

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
		public bool Update(YSWL.MALL.Model.Appt.Services model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Appt_Services set ");
			strSql.Append("Name=?Name,");
			strSql.Append("StartDate=?StartDate,");
			strSql.Append("EndDate=?EndDate,");
			strSql.Append("IsPay=?IsPay,");
			strSql.Append("ServiceType=?ServiceType,");
			strSql.Append("RuleType=?RuleType,");
			strSql.Append("MaxCount=?MaxCount,");
			strSql.Append("Summary=?Summary,");
			strSql.Append("Description=?Description,");
			strSql.Append("ImageUrl=?ImageUrl,");
			strSql.Append("ThumbnailUrl=?ThumbnailUrl,");
			strSql.Append("Remark=?Remark");
			strSql.Append(" where ServiceId=?ServiceId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,50),
					new MySqlParameter("?StartDate", MySqlDbType.DateTime),
					new MySqlParameter("?EndDate", MySqlDbType.DateTime),
					new MySqlParameter("?IsPay", MySqlDbType.Bit,1),
					new MySqlParameter("?ServiceType", MySqlDbType.Int16,2),
					new MySqlParameter("?RuleType", MySqlDbType.Int16,2),
					new MySqlParameter("?MaxCount", MySqlDbType.Int16,2),
					new MySqlParameter("?Summary", MySqlDbType.VarChar,200),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("?ThumbnailUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,100),
					new MySqlParameter("?ServiceId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.StartDate;
			parameters[2].Value = model.EndDate;
			parameters[3].Value = model.IsPay;
			parameters[4].Value = model.ServiceType;
			parameters[5].Value = model.RuleType;
			parameters[6].Value = model.MaxCount;
			parameters[7].Value = model.Summary;
			parameters[8].Value = model.Description;
			parameters[9].Value = model.ImageUrl;
			parameters[10].Value = model.ThumbnailUrl;
			parameters[11].Value = model.Remark;
			parameters[12].Value = model.ServiceId;

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
		public bool Delete(int ServiceId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Appt_Services ");
			strSql.Append(" where ServiceId=?ServiceId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ServiceId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ServiceId;

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
		public bool DeleteList(string ServiceIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Appt_Services ");
			strSql.Append(" where ServiceId in ("+ServiceIdlist + ")  ");
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
		public YSWL.MALL.Model.Appt.Services GetModel(int ServiceId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ServiceId,Name,StartDate,EndDate,IsPay,ServiceType,RuleType,MaxCount,Summary,Description,ImageUrl,ThumbnailUrl,Remark from Appt_Services ");
			strSql.Append(" where ServiceId=?ServiceId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ServiceId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ServiceId;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Appt.Services model=new YSWL.MALL.Model.Appt.Services();
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
		public YSWL.MALL.Model.Appt.Services DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Appt.Services model=new YSWL.MALL.Model.Appt.Services();
			if (row != null)
			{
				if(row["ServiceId"]!=null && row["ServiceId"].ToString()!="")
				{
					model.ServiceId=int.Parse(row["ServiceId"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["StartDate"]!=null && row["StartDate"].ToString()!="")
				{
					model.StartDate=DateTime.Parse(row["StartDate"].ToString());
				}
				if(row["EndDate"]!=null && row["EndDate"].ToString()!="")
				{
					model.EndDate=DateTime.Parse(row["EndDate"].ToString());
				}
				if(row["IsPay"]!=null && row["IsPay"].ToString()!="")
				{
					if((row["IsPay"].ToString()=="1")||(row["IsPay"].ToString().ToLower()=="true"))
					{
						model.IsPay=true;
					}
					else
					{
						model.IsPay=false;
					}
				}
				if(row["ServiceType"]!=null && row["ServiceType"].ToString()!="")
				{
					model.ServiceType=int.Parse(row["ServiceType"].ToString());
				}
				if(row["RuleType"]!=null && row["RuleType"].ToString()!="")
				{
					model.RuleType=int.Parse(row["RuleType"].ToString());
				}
				if(row["MaxCount"]!=null && row["MaxCount"].ToString()!="")
				{
					model.MaxCount=int.Parse(row["MaxCount"].ToString());
				}
				if(row["Summary"]!=null)
				{
					model.Summary=row["Summary"].ToString();
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["ImageUrl"]!=null)
				{
					model.ImageUrl=row["ImageUrl"].ToString();
				}
				if(row["ThumbnailUrl"]!=null)
				{
					model.ThumbnailUrl=row["ThumbnailUrl"].ToString();
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
			strSql.Append("select ServiceId,Name,StartDate,EndDate,IsPay,ServiceType,RuleType,MaxCount,Summary,Description,ImageUrl,ThumbnailUrl,Remark ");
			strSql.Append(" FROM Appt_Services ");
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
			
			strSql.Append(" ServiceId,Name,StartDate,EndDate,IsPay,ServiceType,RuleType,MaxCount,Summary,Description,ImageUrl,ThumbnailUrl,Remark ");
			strSql.Append(" FROM Appt_Services ");
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
			strSql.Append("select count(1) FROM Appt_Services ");
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT T.* from Appt_Services T ");
            if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (!string.IsNullOrWhiteSpace(orderby.Trim()))
            {
                strSql.Append(" order by T." + orderby);
            }
            else
            {
                strSql.Append(" order by T.ServiceId desc");
            }
            strSql.AppendFormat(" LIMIT {0},{1}", startIndex - 1, endIndex - startIndex + 1);
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
			parameters[0].Value = "Appt_Services";
			parameters[1].Value = "ServiceId";
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

