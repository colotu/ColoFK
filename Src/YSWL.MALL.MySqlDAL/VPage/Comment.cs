/**  版本信息模板在安装目录下，可自行修改。
* Comment.cs
*
* 功 能： N/A
* 类 名： Comment
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/2 18:09:54   N/A    初版
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
	/// 数据访问类:Comment
	/// </summary>
	public partial class Comment:IComment
	{
		public Comment()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("CommentId", "VPage_Comment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CommentId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from VPage_Comment");
			strSql.Append(" where CommentId=?CommentId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CommentId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = CommentId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.VPage.Comment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into VPage_Comment(");
			strSql.Append("TargetId,TargetType,ParentId,ContentId,Description,CreatedDate,CreatedUserId,CreatedNickName,ReplyCount,Type,Status,IsRead)");
			strSql.Append(" values (");
			strSql.Append("?TargetId,?TargetType,?ParentId,?ContentId,?Description,?CreatedDate,?CreatedUserId,?CreatedNickName,?ReplyCount,?Type,?Status,?IsRead)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TargetId", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetType", MySqlDbType.Int32,4),
					new MySqlParameter("?ParentId", MySqlDbType.Int32,4),
					new MySqlParameter("?ContentId", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedNickName", MySqlDbType.VarChar,200),
					new MySqlParameter("?ReplyCount", MySqlDbType.Int32,4),
					new MySqlParameter("?Type", MySqlDbType.Int16,2),
					new MySqlParameter("?Status", MySqlDbType.Bit,1),
					new MySqlParameter("?IsRead", MySqlDbType.Bit,1)};
			parameters[0].Value = model.TargetId;
			parameters[1].Value = model.TargetType;
			parameters[2].Value = model.ParentId;
			parameters[3].Value = model.ContentId;
			parameters[4].Value = model.Description;
			parameters[5].Value = model.CreatedDate;
			parameters[6].Value = model.CreatedUserId;
			parameters[7].Value = model.CreatedNickName;
			parameters[8].Value = model.ReplyCount;
			parameters[9].Value = model.Type;
			parameters[10].Value = model.Status;
			parameters[11].Value = model.IsRead;

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
		public bool Update(YSWL.MALL.Model.VPage.Comment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VPage_Comment set ");
			strSql.Append("TargetId=?TargetId,");
			strSql.Append("TargetType=?TargetType,");
			strSql.Append("ParentId=?ParentId,");
			strSql.Append("ContentId=?ContentId,");
			strSql.Append("Description=?Description,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("CreatedUserId=?CreatedUserId,");
			strSql.Append("CreatedNickName=?CreatedNickName,");
			strSql.Append("ReplyCount=?ReplyCount,");
			strSql.Append("Type=?Type,");
			strSql.Append("Status=?Status,");
			strSql.Append("IsRead=?IsRead");
			strSql.Append(" where CommentId=?CommentId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TargetId", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetType", MySqlDbType.Int32,4),
					new MySqlParameter("?ParentId", MySqlDbType.Int32,4),
					new MySqlParameter("?ContentId", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedNickName", MySqlDbType.VarChar,200),
					new MySqlParameter("?ReplyCount", MySqlDbType.Int32,4),
					new MySqlParameter("?Type", MySqlDbType.Int16,2),
					new MySqlParameter("?Status", MySqlDbType.Bit,1),
					new MySqlParameter("?IsRead", MySqlDbType.Bit,1),
					new MySqlParameter("?CommentId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.TargetId;
			parameters[1].Value = model.TargetType;
			parameters[2].Value = model.ParentId;
			parameters[3].Value = model.ContentId;
			parameters[4].Value = model.Description;
			parameters[5].Value = model.CreatedDate;
			parameters[6].Value = model.CreatedUserId;
			parameters[7].Value = model.CreatedNickName;
			parameters[8].Value = model.ReplyCount;
			parameters[9].Value = model.Type;
			parameters[10].Value = model.Status;
			parameters[11].Value = model.IsRead;
			parameters[12].Value = model.CommentId;

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
		public bool Delete(int CommentId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VPage_Comment ");
			strSql.Append(" where CommentId=?CommentId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CommentId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = CommentId;

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
		public bool DeleteList(string CommentIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VPage_Comment ");
			strSql.Append(" where CommentId in ("+CommentIdlist + ")  ");
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
		public YSWL.MALL.Model.VPage.Comment GetModel(int CommentId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CommentId,TargetId,TargetType,ParentId,ContentId,Description,CreatedDate,CreatedUserId,CreatedNickName,ReplyCount,Type,Status,IsRead from VPage_Comment ");
            strSql.Append(" where CommentId=?CommentId LIMIT 1 ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CommentId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = CommentId;

			YSWL.MALL.Model.VPage.Comment model=new YSWL.MALL.Model.VPage.Comment();
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
		public YSWL.MALL.Model.VPage.Comment DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.VPage.Comment model=new YSWL.MALL.Model.VPage.Comment();
			if (row != null)
			{
				if(row["CommentId"]!=null && row["CommentId"].ToString()!="")
				{
					model.CommentId=int.Parse(row["CommentId"].ToString());
				}
				if(row["TargetId"]!=null && row["TargetId"].ToString()!="")
				{
					model.TargetId=int.Parse(row["TargetId"].ToString());
				}
				if(row["TargetType"]!=null && row["TargetType"].ToString()!="")
				{
					model.TargetType=int.Parse(row["TargetType"].ToString());
				}
				if(row["ParentId"]!=null && row["ParentId"].ToString()!="")
				{
					model.ParentId=int.Parse(row["ParentId"].ToString());
				}
				if(row["ContentId"]!=null && row["ContentId"].ToString()!="")
				{
					model.ContentId=int.Parse(row["ContentId"].ToString());
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["CreatedUserId"]!=null && row["CreatedUserId"].ToString()!="")
				{
					model.CreatedUserId=int.Parse(row["CreatedUserId"].ToString());
				}
				if(row["CreatedNickName"]!=null)
				{
					model.CreatedNickName=row["CreatedNickName"].ToString();
				}
				if(row["ReplyCount"]!=null && row["ReplyCount"].ToString()!="")
				{
					model.ReplyCount=int.Parse(row["ReplyCount"].ToString());
				}
				if(row["Type"]!=null && row["Type"].ToString()!="")
				{
					model.Type=int.Parse(row["Type"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					if((row["Status"].ToString()=="1")||(row["Status"].ToString().ToLower()=="true"))
					{
						model.Status=true;
					}
					else
					{
						model.Status=false;
					}
				}
				if(row["IsRead"]!=null && row["IsRead"].ToString()!="")
				{
					if((row["IsRead"].ToString()=="1")||(row["IsRead"].ToString().ToLower()=="true"))
					{
						model.IsRead=true;
					}
					else
					{
						model.IsRead=false;
					}
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
			strSql.Append("select CommentId,TargetId,TargetType,ParentId,ContentId,Description,CreatedDate,CreatedUserId,CreatedNickName,ReplyCount,Type,Status,IsRead ");
			strSql.Append(" FROM VPage_Comment ");
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
			
			strSql.Append(" CommentId,TargetId,TargetType,ParentId,ContentId,Description,CreatedDate,CreatedUserId,CreatedNickName,ReplyCount,Type,Status,IsRead ");
			strSql.Append(" FROM VPage_Comment ");
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
			strSql.Append("select count(1) FROM VPage_Comment ");
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
				strSql.Append("order by T.CommentId desc");
			}
			strSql.Append(")AS Row, T.*  from VPage_Comment T ");
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
			parameters[0].Value = "VPage_Comment";
			parameters[1].Value = "CommentId";
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

