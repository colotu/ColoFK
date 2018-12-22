/**  版本信息模板在安装目录下，可自行修改。
* GuestBook.cs
*
* 功 能： N/A
* 类 名： GuestBook
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/2 18:09:57   N/A    初版
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
using YSWL.MALL.IDAL.VPage;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.VPage
{
	/// <summary>
	/// 数据访问类:GuestBook
	/// </summary>
	public partial class GuestBook:IGuestBook
	{
		public GuestBook()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("GuestBookId", "VPage_GuestBook"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int GuestBookId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from VPage_GuestBook");
			strSql.Append(" where GuestBookId=?GuestBookId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?GuestBookId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = GuestBookId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.VPage.GuestBook model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into VPage_GuestBook(");
			strSql.Append("TargetId,TargetType,Title,Description,CreateNickName,CreateUserID,UserEmail,UserPhone,CreatedDate,ReplyDate,Privacy,ReplyContent,Status)");
			strSql.Append(" values (");
			strSql.Append("?TargetId,?TargetType,?Title,?Description,?CreateNickName,?CreateUserID,?UserEmail,?UserPhone,?CreatedDate,?ReplyDate,?Privacy,?ReplyContent,?Status)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TargetId", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetType", MySqlDbType.Int32,4),
					new MySqlParameter("?Title", MySqlDbType.VarChar,100),
					new MySqlParameter("?Description", MySqlDbType.VarChar,500),
					new MySqlParameter("?CreateNickName", MySqlDbType.VarChar,200),
					new MySqlParameter("?CreateUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?UserEmail", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserPhone", MySqlDbType.VarChar,20),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?ReplyDate", MySqlDbType.DateTime),
					new MySqlParameter("?Privacy", MySqlDbType.Int32,4),
					new MySqlParameter("?ReplyContent", MySqlDbType.VarChar,500),
					new MySqlParameter("?Status", MySqlDbType.Int32,4)};
			parameters[0].Value = model.TargetId;
			parameters[1].Value = model.TargetType;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.Description;
			parameters[4].Value = model.CreateNickName;
			parameters[5].Value = model.CreateUserID;
			parameters[6].Value = model.UserEmail;
			parameters[7].Value = model.UserPhone;
			parameters[8].Value = model.CreatedDate;
			parameters[9].Value = model.ReplyDate;
			parameters[10].Value = model.Privacy;
			parameters[11].Value = model.ReplyContent;
			parameters[12].Value = model.Status;

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
		public bool Update(YSWL.MALL.Model.VPage.GuestBook model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VPage_GuestBook set ");
			strSql.Append("TargetId=?TargetId,");
			strSql.Append("TargetType=?TargetType,");
			strSql.Append("Title=?Title,");
			strSql.Append("Description=?Description,");
			strSql.Append("CreateNickName=?CreateNickName,");
			strSql.Append("CreateUserID=?CreateUserID,");
			strSql.Append("UserEmail=?UserEmail,");
			strSql.Append("UserPhone=?UserPhone,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("ReplyDate=?ReplyDate,");
			strSql.Append("Privacy=?Privacy,");
			strSql.Append("ReplyContent=?ReplyContent,");
			strSql.Append("Status=?Status");
			strSql.Append(" where GuestBookId=?GuestBookId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TargetId", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetType", MySqlDbType.Int32,4),
					new MySqlParameter("?Title", MySqlDbType.VarChar,100),
					new MySqlParameter("?Description", MySqlDbType.VarChar,500),
					new MySqlParameter("?CreateNickName", MySqlDbType.VarChar,200),
					new MySqlParameter("?CreateUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?UserEmail", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserPhone", MySqlDbType.VarChar,20),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?ReplyDate", MySqlDbType.DateTime),
					new MySqlParameter("?Privacy", MySqlDbType.Int32,4),
					new MySqlParameter("?ReplyContent", MySqlDbType.VarChar,500),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?GuestBookId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.TargetId;
			parameters[1].Value = model.TargetType;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.Description;
			parameters[4].Value = model.CreateNickName;
			parameters[5].Value = model.CreateUserID;
			parameters[6].Value = model.UserEmail;
			parameters[7].Value = model.UserPhone;
			parameters[8].Value = model.CreatedDate;
			parameters[9].Value = model.ReplyDate;
			parameters[10].Value = model.Privacy;
			parameters[11].Value = model.ReplyContent;
			parameters[12].Value = model.Status;
			parameters[13].Value = model.GuestBookId;

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
		public bool Delete(int GuestBookId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VPage_GuestBook ");
			strSql.Append(" where GuestBookId=?GuestBookId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?GuestBookId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = GuestBookId;

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
		public bool DeleteList(string GuestBookIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VPage_GuestBook ");
			strSql.Append(" where GuestBookId in ("+GuestBookIdlist + ")  ");
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
		public YSWL.MALL.Model.VPage.GuestBook GetModel(int GuestBookId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select GuestBookId,TargetId,TargetType,Title,Description,CreateNickName,CreateUserID,UserEmail,UserPhone,CreatedDate,ReplyDate,Privacy,ReplyContent,Status from VPage_GuestBook ");
            strSql.Append(" where GuestBookId=?GuestBookId LIMIT 1 ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?GuestBookId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = GuestBookId;

			YSWL.MALL.Model.VPage.GuestBook model=new YSWL.MALL.Model.VPage.GuestBook();
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
		public YSWL.MALL.Model.VPage.GuestBook DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.VPage.GuestBook model=new YSWL.MALL.Model.VPage.GuestBook();
			if (row != null)
			{
				if(row["GuestBookId"]!=null && row["GuestBookId"].ToString()!="")
				{
					model.GuestBookId=int.Parse(row["GuestBookId"].ToString());
				}
				if(row["TargetId"]!=null && row["TargetId"].ToString()!="")
				{
					model.TargetId=int.Parse(row["TargetId"].ToString());
				}
				if(row["TargetType"]!=null && row["TargetType"].ToString()!="")
				{
					model.TargetType=int.Parse(row["TargetType"].ToString());
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["CreateNickName"]!=null)
				{
					model.CreateNickName=row["CreateNickName"].ToString();
				}
				if(row["CreateUserID"]!=null && row["CreateUserID"].ToString()!="")
				{
					model.CreateUserID=int.Parse(row["CreateUserID"].ToString());
				}
				if(row["UserEmail"]!=null)
				{
					model.UserEmail=row["UserEmail"].ToString();
				}
				if(row["UserPhone"]!=null)
				{
					model.UserPhone=row["UserPhone"].ToString();
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["ReplyDate"]!=null && row["ReplyDate"].ToString()!="")
				{
					model.ReplyDate=DateTime.Parse(row["ReplyDate"].ToString());
				}
				if(row["Privacy"]!=null && row["Privacy"].ToString()!="")
				{
					model.Privacy=int.Parse(row["Privacy"].ToString());
				}
				if(row["ReplyContent"]!=null)
				{
					model.ReplyContent=row["ReplyContent"].ToString();
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
			strSql.Append("select GuestBookId,TargetId,TargetType,Title,Description,CreateNickName,CreateUserID,UserEmail,UserPhone,CreatedDate,ReplyDate,Privacy,ReplyContent,Status ");
			strSql.Append(" FROM VPage_GuestBook ");
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
			
			strSql.Append(" GuestBookId,TargetId,TargetType,Title,Description,CreateNickName,CreateUserID,UserEmail,UserPhone,CreatedDate,ReplyDate,Privacy,ReplyContent,Status ");
			strSql.Append(" FROM VPage_GuestBook ");
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
			strSql.Append("select count(1) FROM VPage_GuestBook ");
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
				strSql.Append("order by T.GuestBookId desc");
			}
			strSql.Append(")AS Row, T.*  from VPage_GuestBook T ");
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
			parameters[0].Value = "VPage_GuestBook";
			parameters[1].Value = "GuestBookId";
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

