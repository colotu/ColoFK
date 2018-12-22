/**
* PostsTopics.cs
*
* 功 能： N/A
* 类 名： PostsTopics
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/9/12 20:14:48   N/A    初版
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
	/// 数据访问类:PostsTopics
	/// </summary>
	public partial class PostsTopics:IPostsTopics
	{
		public PostsTopics()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Title)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SNS_PostsTopics");
			strSql.Append(" where Title=?Title ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Title", MySqlDbType.VarChar,200)			
                                        };
			parameters[0].Value = Title;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(YSWL.MALL.Model.SNS.PostsTopics model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SNS_PostsTopics(");
			strSql.Append("Title,Description,CreatedUserID,CreatedNickName,CreatedDate,TopicsCount,IsRecommend,Sequence,Tags)");
			strSql.Append(" values (");
			strSql.Append("?Title,?Description,?CreatedUserID,?CreatedNickName,?CreatedDate,?TopicsCount,?IsRecommend,?Sequence,?Tags)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Title", MySqlDbType.VarChar,200),
					new MySqlParameter("?Description", MySqlDbType.VarChar),
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedNickName", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?TopicsCount", MySqlDbType.Int32,4),
					new MySqlParameter("?IsRecommend", MySqlDbType.Bit,1),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Tags", MySqlDbType.VarChar,100)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Description;
			parameters[2].Value = model.CreatedUserID;
			parameters[3].Value = model.CreatedNickName;
			parameters[4].Value = model.CreatedDate;
			parameters[5].Value = model.TopicsCount;
			parameters[6].Value = model.IsRecommend;
			parameters[7].Value = model.Sequence;
			parameters[8].Value = model.Tags;

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
		public bool Update(YSWL.MALL.Model.SNS.PostsTopics model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SNS_PostsTopics set ");
			strSql.Append("Description=?Description,");
			strSql.Append("CreatedUserID=?CreatedUserID,");
			strSql.Append("CreatedNickName=?CreatedNickName,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("TopicsCount=?TopicsCount,");
			strSql.Append("IsRecommend=?IsRecommend,");
			strSql.Append("Sequence=?Sequence,");
			strSql.Append("Tags=?Tags");
			strSql.Append(" where Title=?Title ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Description", MySqlDbType.VarChar),
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedNickName", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?TopicsCount", MySqlDbType.Int32,4),
					new MySqlParameter("?IsRecommend", MySqlDbType.Bit,1),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Tags", MySqlDbType.VarChar,100),
					new MySqlParameter("?Title", MySqlDbType.VarChar,200)};
			parameters[0].Value = model.Description;
			parameters[1].Value = model.CreatedUserID;
			parameters[2].Value = model.CreatedNickName;
			parameters[3].Value = model.CreatedDate;
			parameters[4].Value = model.TopicsCount;
			parameters[5].Value = model.IsRecommend;
			parameters[6].Value = model.Sequence;
			parameters[7].Value = model.Tags;
			parameters[8].Value = model.Title;

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
		public bool Delete(string Title)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SNS_PostsTopics ");
			strSql.Append(" where Title=?Title ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Title", MySqlDbType.VarChar,200)			};
			parameters[0].Value = Title;

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
		public bool DeleteList(string Titlelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SNS_PostsTopics ");
			strSql.Append(" where Title in ("+Titlelist + ")  ");
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
		public YSWL.MALL.Model.SNS.PostsTopics GetModel(string Title)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Title,Description,CreatedUserID,CreatedNickName,CreatedDate,TopicsCount,IsRecommend,Sequence,Tags from SNS_PostsTopics ");
            strSql.Append(" where Title=?Title  LIMIT 1 ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Title", MySqlDbType.VarChar,200)			};
			parameters[0].Value = Title;

			YSWL.MALL.Model.SNS.PostsTopics model=new YSWL.MALL.Model.SNS.PostsTopics();
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
		public YSWL.MALL.Model.SNS.PostsTopics DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.SNS.PostsTopics model=new YSWL.MALL.Model.SNS.PostsTopics();
			if (row != null)
			{
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["CreatedUserID"]!=null && row["CreatedUserID"].ToString()!="")
				{
					model.CreatedUserID=int.Parse(row["CreatedUserID"].ToString());
				}
				if(row["CreatedNickName"]!=null)
				{
					model.CreatedNickName=row["CreatedNickName"].ToString();
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["TopicsCount"]!=null && row["TopicsCount"].ToString()!="")
				{
					model.TopicsCount=int.Parse(row["TopicsCount"].ToString());
				}
				if(row["IsRecommend"]!=null && row["IsRecommend"].ToString()!="")
				{
					if((row["IsRecommend"].ToString()=="1")||(row["IsRecommend"].ToString().ToLower()=="true"))
					{
						model.IsRecommend=true;
					}
					else
					{
						model.IsRecommend=false;
					}
				}
				if(row["Sequence"]!=null && row["Sequence"].ToString()!="")
				{
					model.Sequence=int.Parse(row["Sequence"].ToString());
				}
				if(row["Tags"]!=null)
				{
					model.Tags=row["Tags"].ToString();
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
			strSql.Append("select Title,Description,CreatedUserID,CreatedNickName,CreatedDate,TopicsCount,IsRecommend,Sequence,Tags ");
			strSql.Append(" FROM SNS_PostsTopics ");
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
			
			strSql.Append(" Title,Description,CreatedUserID,CreatedNickName,CreatedDate,TopicsCount,IsRecommend,Sequence,Tags ");
			strSql.Append(" FROM SNS_PostsTopics ");
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
			strSql.Append("select count(1) FROM SNS_PostsTopics ");
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
				strSql.Append("order by T.Title desc");
			}
			strSql.Append(")AS Row, T.*  from SNS_PostsTopics T ");
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
			parameters[0].Value = "SNS_PostsTopics";
			parameters[1].Value = "Title";
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

