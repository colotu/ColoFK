/**
* TrialReports.cs
*
* 功 能： N/A
* 类 名： TrialReports
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/5/22 18:12:41   N/A    初版
*
* Copyright (c) 2012-2013 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Shop.Trial;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Shop.Trial
{
	/// <summary>
	/// 数据访问类:TrialReports
	/// </summary>
	public partial class TrialReports:ITrialReports
	{
		public TrialReports()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ReportId", "Shop_TrialReports"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ReportId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Shop_TrialReports");
			strSql.Append(" where ReportId=?ReportId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ReportId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ReportId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.Shop.Trial.TrialReports model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Shop_TrialReports(");
			strSql.Append("Title,LinkUrl,ShortDescription,CreatedUserID,CreatedUserName,Description,ImageUrl,ThumbnailUrl)");
			strSql.Append(" values (");
			strSql.Append("?Title,?LinkUrl,?ShortDescription,?CreatedUserID,?CreatedUserName,?Description,?ImageUrl,?ThumbnailUrl)");
			strSql.Append(";select last_insert_id()");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Title", MySqlDbType.VarChar,200),
					new MySqlParameter("?LinkUrl", MySqlDbType.VarChar,500),
					new MySqlParameter("?ShortDescription", MySqlDbType.VarChar,2000),
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedUserName", MySqlDbType.VarChar,200),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("?ThumbnailUrl", MySqlDbType.VarChar,255)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.LinkUrl;
			parameters[2].Value = model.ShortDescription;
			parameters[3].Value = model.CreatedUserID;
			parameters[4].Value = model.CreatedUserName;
			parameters[5].Value = model.Description;
			parameters[6].Value = model.ImageUrl;
			parameters[7].Value = model.ThumbnailUrl;

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
		public bool Update(YSWL.MALL.Model.Shop.Trial.TrialReports model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Shop_TrialReports set ");
			strSql.Append("Title=?Title,");
			strSql.Append("LinkUrl=?LinkUrl,");
			strSql.Append("ShortDescription=?ShortDescription,");
			strSql.Append("CreatedUserID=?CreatedUserID,");
			strSql.Append("CreatedUserName=?CreatedUserName,");
			strSql.Append("Description=?Description,");
			strSql.Append("ImageUrl=?ImageUrl,");
			strSql.Append("ThumbnailUrl=?ThumbnailUrl");
			strSql.Append(" where ReportId=?ReportId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Title", MySqlDbType.VarChar,200),
					new MySqlParameter("?LinkUrl", MySqlDbType.VarChar,500),
					new MySqlParameter("?ShortDescription", MySqlDbType.VarChar,2000),
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedUserName", MySqlDbType.VarChar,200),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("?ThumbnailUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("?ReportId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.LinkUrl;
			parameters[2].Value = model.ShortDescription;
			parameters[3].Value = model.CreatedUserID;
			parameters[4].Value = model.CreatedUserName;
			parameters[5].Value = model.Description;
			parameters[6].Value = model.ImageUrl;
			parameters[7].Value = model.ThumbnailUrl;
			parameters[8].Value = model.ReportId;

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
		public bool Delete(int ReportId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_TrialReports ");
			strSql.Append(" where ReportId=?ReportId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ReportId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ReportId;

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
		public bool DeleteList(string ReportIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_TrialReports ");
			strSql.Append(" where ReportId in ("+ReportIdlist + ")  ");
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
		public YSWL.MALL.Model.Shop.Trial.TrialReports GetModel(int ReportId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ReportId,Title,LinkUrl,ShortDescription,CreatedUserID,CreatedUserName,Description,ImageUrl,ThumbnailUrl from Shop_TrialReports ");
			strSql.Append(" where ReportId=?ReportId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ReportId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ReportId;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Shop.Trial.TrialReports model=new YSWL.MALL.Model.Shop.Trial.TrialReports();
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
		public YSWL.MALL.Model.Shop.Trial.TrialReports DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Shop.Trial.TrialReports model=new YSWL.MALL.Model.Shop.Trial.TrialReports();
			if (row != null)
			{
				if(row["ReportId"]!=null && row["ReportId"].ToString()!="")
				{
					model.ReportId=int.Parse(row["ReportId"].ToString());
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["LinkUrl"]!=null)
				{
					model.LinkUrl=row["LinkUrl"].ToString();
				}
				if(row["ShortDescription"]!=null)
				{
					model.ShortDescription=row["ShortDescription"].ToString();
				}
				if(row["CreatedUserID"]!=null && row["CreatedUserID"].ToString()!="")
				{
					model.CreatedUserID=int.Parse(row["CreatedUserID"].ToString());
				}
				if(row["CreatedUserName"]!=null)
				{
					model.CreatedUserName=row["CreatedUserName"].ToString();
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ReportId,Title,LinkUrl,ShortDescription,CreatedUserID,CreatedUserName,Description,ImageUrl,ThumbnailUrl ");
			strSql.Append(" FROM Shop_TrialReports ");
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
			strSql.Append(" ReportId,Title,LinkUrl,ShortDescription,CreatedUserID,CreatedUserName,Description,ImageUrl,ThumbnailUrl ");
			strSql.Append(" FROM Shop_TrialReports ");
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
			strSql.Append("select count(1) FROM Shop_TrialReports ");
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
            strSql.Append("SELECT T.* from Shop_TrialReports T ");
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
                strSql.Append(" order by T.ReportId desc");
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
			parameters[0].Value = "Shop_TrialReports";
			parameters[1].Value = "ReportId";
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

