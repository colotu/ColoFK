﻿/**
* Area.cs
*
* 功 能： N/A
* 类 名： Area
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/9/17 19:52:38   N/A    初版
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
using YSWL.MALL.IDAL.SysManage;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.SysManage
{
	/// <summary>
	/// 数据访问类:Area
	/// </summary>
    public partial class ConfigArea : IConfigArea
	{
		public ConfigArea()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string AreaName)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SA_Config_Area");
			strSql.Append(" where AreaName=?AreaName ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?AreaName", MySqlDbType.VarChar,50)			};
			parameters[0].Value = AreaName;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(YSWL.MALL.Model.SysManage.ConfigArea model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SA_Config_Area(");
			strSql.Append("AreaName,Status)");
			strSql.Append(" values (");
			strSql.Append("?AreaName,?Status)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?AreaName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Status", MySqlDbType.Int16,2)};
			parameters[0].Value = model.AreaName;
			parameters[1].Value = model.Status;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(YSWL.MALL.Model.SysManage.ConfigArea model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SA_Config_Area set ");
			strSql.Append("Status=?Status");
			strSql.Append(" where AreaName=?AreaName ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?AreaName", MySqlDbType.VarChar,50)};
			parameters[0].Value = model.Status;
			parameters[1].Value = model.AreaName;

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
		public bool Delete(string AreaName)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SA_Config_Area ");
			strSql.Append(" where AreaName=?AreaName ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?AreaName", MySqlDbType.VarChar,50)			};
			parameters[0].Value = AreaName;

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
		public bool DeleteList(string AreaNamelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SA_Config_Area ");
			strSql.Append(" where AreaName in ("+AreaNamelist + ")  ");
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
		public YSWL.MALL.Model.SysManage.ConfigArea GetModel(string AreaName)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AreaName,Status from SA_Config_Area ");
			strSql.Append(" where AreaName=?AreaName ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?AreaName", MySqlDbType.VarChar,50)			};
			parameters[0].Value = AreaName;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.SysManage.ConfigArea model=new YSWL.MALL.Model.SysManage.ConfigArea();
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
		public YSWL.MALL.Model.SysManage.ConfigArea DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.SysManage.ConfigArea model=new YSWL.MALL.Model.SysManage.ConfigArea();
			if (row != null)
			{
				if(row["AreaName"]!=null)
				{
					model.AreaName=row["AreaName"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
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
			strSql.Append("select AreaName,Status ");
			strSql.Append(" FROM SA_Config_Area ");
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
			strSql.Append(" AreaName,Status ");
			strSql.Append(" FROM SA_Config_Area ");
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
			strSql.Append("select count(1) FROM SA_Config_Area ");
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
            strSql.Append("SELECT T.* from SA_Config_Area T ");
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
                strSql.Append(" order by T.AreaName desc");
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
			parameters[0].Value = "SA_Config_Area";
			parameters[1].Value = "AreaName";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

	    public bool UpdateList(string areas, int status)
	    {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SA_Config_Area set ");
            strSql.Append("Status=?Status");
            strSql.Append(" where AreaName in (" + areas + ")  ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Status", MySqlDbType.Int16,2)
                                        };
            parameters[0].Value = status;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
	    }

	    #endregion  ExtensionMethod
	}
}

