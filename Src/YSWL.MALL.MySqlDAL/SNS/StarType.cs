/**
* StarType.cs
*
* 功 能： N/A
* 类 名： StarType
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/9/12 20:14:57   N/A    初版
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
using YSWL.MALL.IDAL.SNS;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.SNS
{
	/// <summary>
	/// 数据访问类:StarType
	/// </summary>
	public partial class StarType:IStarType
	{
		public StarType()
		{}
		#region  BasicMethod

		
		/// <summary>
		/// 是否存在该名称
		/// </summary>
        public bool Exists(string TypeName)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SNS_StarType");
            strSql.Append(" where TypeName=?TypeName");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TypeName", MySqlDbType.VarChar,100)
			};
            parameters[0].Value = TypeName;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.SNS.StarType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SNS_StarType(");
			strSql.Append("TypeName,CheckRule,Remark,Status)");
			strSql.Append(" values (");
			strSql.Append("?TypeName,?CheckRule,?Remark,?Status)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TypeName", MySqlDbType.VarChar,100),
					new MySqlParameter("?CheckRule", MySqlDbType.VarChar,50),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,200),
					new MySqlParameter("?Status", MySqlDbType.Int32,4)};
			parameters[0].Value = model.TypeName;
			parameters[1].Value = model.CheckRule;
			parameters[2].Value = model.Remark;
			parameters[3].Value = model.Status;

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
		public bool Update(YSWL.MALL.Model.SNS.StarType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SNS_StarType set ");
			strSql.Append("TypeName=?TypeName,");
			strSql.Append("CheckRule=?CheckRule,");
			strSql.Append("Remark=?Remark,");
			strSql.Append("Status=?Status");
			strSql.Append(" where TypeID=?TypeID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TypeName", MySqlDbType.VarChar,100),
					new MySqlParameter("?CheckRule", MySqlDbType.VarChar,50),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,200),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?TypeID", MySqlDbType.Int32,4)};
			parameters[0].Value = model.TypeName;
			parameters[1].Value = model.CheckRule;
			parameters[2].Value = model.Remark;
			parameters[3].Value = model.Status;
			parameters[4].Value = model.TypeID;

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
		public bool Delete(int TypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SNS_StarType ");
			strSql.Append(" where TypeID=?TypeID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TypeID", MySqlDbType.Int32,4)
			};
			parameters[0].Value = TypeID;

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
		public bool DeleteList(string TypeIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SNS_StarType ");
			strSql.Append(" where TypeID in ("+TypeIDlist + ")  ");
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
		public YSWL.MALL.Model.SNS.StarType GetModel(int TypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select TypeID,TypeName,CheckRule,Remark,Status from SNS_StarType ");
            strSql.Append(" where TypeID=?TypeID LIMIT 1 ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TypeID", MySqlDbType.Int32,4)
			};
			parameters[0].Value = TypeID;

			YSWL.MALL.Model.SNS.StarType model=new YSWL.MALL.Model.SNS.StarType();
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
		public YSWL.MALL.Model.SNS.StarType DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.SNS.StarType model=new YSWL.MALL.Model.SNS.StarType();
			if (row != null)
			{
				if(row["TypeID"]!=null && row["TypeID"].ToString()!="")
				{
					model.TypeID=int.Parse(row["TypeID"].ToString());
				}
				if(row["TypeName"]!=null)
				{
					model.TypeName=row["TypeName"].ToString();
				}
				if(row["CheckRule"]!=null)
				{
					model.CheckRule=row["CheckRule"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
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
			strSql.Append("select TypeID,TypeName,CheckRule,Remark,Status ");
			strSql.Append(" FROM SNS_StarType ");
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
			
			strSql.Append(" TypeID,TypeName,CheckRule,Remark,Status ");
			strSql.Append(" FROM SNS_StarType ");
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
			strSql.Append("select count(1) FROM SNS_StarType ");
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
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.TypeID desc");
			}
			strSql.Append(")AS Row, T.*  from SNS_StarType T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
			parameters[0].Value = "SNS_StarType";
			parameters[1].Value = "TypeID";
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

