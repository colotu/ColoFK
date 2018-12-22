/**  版本信息模板在安装目录下，可自行修改。
* Article.cs
*
* 功 能： N/A
* 类 名： Article
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/2 18:09:51   N/A    初版
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
	/// 数据访问类:Article
	/// </summary>
	public partial class Article:IArticle
	{
		public Article()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ArticleId", "VPage_Article"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ArticleId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from VPage_Article");
			strSql.Append(" where ArticleId=?ArticleId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ArticleId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ArticleId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.VPage.Article model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into VPage_Article(");
			strSql.Append("CategoryId,TargetId,TargetType,Title,SubTitle,Summary,Description,ImageUrl,ThumbImageUrl,CreatedUserId,CreatedDate,LastEditUserId,LastEditDate,LinkUrl,Status,Sequence,IsRecomend,IsHot,IsColor,IsTop,Comments,PvCount,Supports,Favs,Keywords,Remark)");
			strSql.Append(" values (");
			strSql.Append("?CategoryId,?TargetId,?TargetType,?Title,?SubTitle,?Summary,?Description,?ImageUrl,?ThumbImageUrl,?CreatedUserId,?CreatedDate,?LastEditUserId,?LastEditDate,?LinkUrl,?Status,?Sequence,?IsRecomend,?IsHot,?IsColor,?IsTop,?Comments,?PvCount,?Supports,?Favs,?Keywords,?Remark)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetId", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetType", MySqlDbType.Int32,4),
					new MySqlParameter("?Title", MySqlDbType.VarChar,50),
					new MySqlParameter("?SubTitle", MySqlDbType.VarChar,255),
					new MySqlParameter("?Summary", MySqlDbType.Text),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?ThumbImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?CreatedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?LastEditUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?LastEditDate", MySqlDbType.DateTime),
					new MySqlParameter("?LinkUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?IsRecomend", MySqlDbType.Bit,1),
					new MySqlParameter("?IsHot", MySqlDbType.Bit,1),
					new MySqlParameter("?IsColor", MySqlDbType.Bit,1),
					new MySqlParameter("?IsTop", MySqlDbType.Bit,1),
					new MySqlParameter("?Comments", MySqlDbType.Int32,4),
					new MySqlParameter("?PvCount", MySqlDbType.Int32,4),
					new MySqlParameter("?Supports", MySqlDbType.Int32,4),
					new MySqlParameter("?Favs", MySqlDbType.Int32,4),
					new MySqlParameter("?Keywords", MySqlDbType.VarChar,200),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,200)};
			parameters[0].Value = model.CategoryId;
			parameters[1].Value = model.TargetId;
			parameters[2].Value = model.TargetType;
			parameters[3].Value = model.Title;
			parameters[4].Value = model.SubTitle;
			parameters[5].Value = model.Summary;
			parameters[6].Value = model.Description;
			parameters[7].Value = model.ImageUrl;
			parameters[8].Value = model.ThumbImageUrl;
			parameters[9].Value = model.CreatedUserId;
			parameters[10].Value = model.CreatedDate;
			parameters[11].Value = model.LastEditUserId;
			parameters[12].Value = model.LastEditDate;
			parameters[13].Value = model.LinkUrl;
			parameters[14].Value = model.Status;
			parameters[15].Value = model.Sequence;
			parameters[16].Value = model.IsRecomend;
			parameters[17].Value = model.IsHot;
			parameters[18].Value = model.IsColor;
			parameters[19].Value = model.IsTop;
			parameters[20].Value = model.Comments;
			parameters[21].Value = model.PvCount;
			parameters[22].Value = model.Supports;
			parameters[23].Value = model.Favs;
			parameters[24].Value = model.Keywords;
			parameters[25].Value = model.Remark;

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
		public bool Update(YSWL.MALL.Model.VPage.Article model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VPage_Article set ");
			strSql.Append("CategoryId=?CategoryId,");
			strSql.Append("TargetId=?TargetId,");
			strSql.Append("TargetType=?TargetType,");
			strSql.Append("Title=?Title,");
			strSql.Append("SubTitle=?SubTitle,");
			strSql.Append("Summary=?Summary,");
			strSql.Append("Description=?Description,");
			strSql.Append("ImageUrl=?ImageUrl,");
			strSql.Append("ThumbImageUrl=?ThumbImageUrl,");
			strSql.Append("CreatedUserId=?CreatedUserId,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("LastEditUserId=?LastEditUserId,");
			strSql.Append("LastEditDate=?LastEditDate,");
			strSql.Append("LinkUrl=?LinkUrl,");
			strSql.Append("Status=?Status,");
			strSql.Append("Sequence=?Sequence,");
			strSql.Append("IsRecomend=?IsRecomend,");
			strSql.Append("IsHot=?IsHot,");
			strSql.Append("IsColor=?IsColor,");
			strSql.Append("IsTop=?IsTop,");
			strSql.Append("Comments=?Comments,");
			strSql.Append("PvCount=?PvCount,");
			strSql.Append("Supports=?Supports,");
			strSql.Append("Favs=?Favs,");
			strSql.Append("Keywords=?Keywords,");
			strSql.Append("Remark=?Remark");
			strSql.Append(" where ArticleId=?ArticleId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetId", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetType", MySqlDbType.Int32,4),
					new MySqlParameter("?Title", MySqlDbType.VarChar,50),
					new MySqlParameter("?SubTitle", MySqlDbType.VarChar,255),
					new MySqlParameter("?Summary", MySqlDbType.Text),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?ThumbImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?CreatedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?LastEditUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?LastEditDate", MySqlDbType.DateTime),
					new MySqlParameter("?LinkUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?IsRecomend", MySqlDbType.Bit,1),
					new MySqlParameter("?IsHot", MySqlDbType.Bit,1),
					new MySqlParameter("?IsColor", MySqlDbType.Bit,1),
					new MySqlParameter("?IsTop", MySqlDbType.Bit,1),
					new MySqlParameter("?Comments", MySqlDbType.Int32,4),
					new MySqlParameter("?PvCount", MySqlDbType.Int32,4),
					new MySqlParameter("?Supports", MySqlDbType.Int32,4),
					new MySqlParameter("?Favs", MySqlDbType.Int32,4),
					new MySqlParameter("?Keywords", MySqlDbType.VarChar,200),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,200),
					new MySqlParameter("?ArticleId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.CategoryId;
			parameters[1].Value = model.TargetId;
			parameters[2].Value = model.TargetType;
			parameters[3].Value = model.Title;
			parameters[4].Value = model.SubTitle;
			parameters[5].Value = model.Summary;
			parameters[6].Value = model.Description;
			parameters[7].Value = model.ImageUrl;
			parameters[8].Value = model.ThumbImageUrl;
			parameters[9].Value = model.CreatedUserId;
			parameters[10].Value = model.CreatedDate;
			parameters[11].Value = model.LastEditUserId;
			parameters[12].Value = model.LastEditDate;
			parameters[13].Value = model.LinkUrl;
			parameters[14].Value = model.Status;
			parameters[15].Value = model.Sequence;
			parameters[16].Value = model.IsRecomend;
			parameters[17].Value = model.IsHot;
			parameters[18].Value = model.IsColor;
			parameters[19].Value = model.IsTop;
			parameters[20].Value = model.Comments;
			parameters[21].Value = model.PvCount;
			parameters[22].Value = model.Supports;
			parameters[23].Value = model.Favs;
			parameters[24].Value = model.Keywords;
			parameters[25].Value = model.Remark;
			parameters[26].Value = model.ArticleId;

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
		public bool Delete(int ArticleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VPage_Article ");
			strSql.Append(" where ArticleId=?ArticleId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ArticleId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ArticleId;

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
		public bool DeleteList(string ArticleIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VPage_Article ");
			strSql.Append(" where ArticleId in ("+ArticleIdlist + ")  ");
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
		public YSWL.MALL.Model.VPage.Article GetModel(int ArticleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ArticleId,CategoryId,TargetId,TargetType,Title,SubTitle,Summary,Description,ImageUrl,ThumbImageUrl,CreatedUserId,CreatedDate,LastEditUserId,LastEditDate,LinkUrl,Status,Sequence,IsRecomend,IsHot,IsColor,IsTop,Comments,PvCount,Supports,Favs,Keywords,Remark from VPage_Article ");
            strSql.Append(" where ArticleId=?ArticleId LIMIT 1 ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ArticleId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ArticleId;

			YSWL.MALL.Model.VPage.Article model=new YSWL.MALL.Model.VPage.Article();
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
		public YSWL.MALL.Model.VPage.Article DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.VPage.Article model=new YSWL.MALL.Model.VPage.Article();
			if (row != null)
			{
				if(row["ArticleId"]!=null && row["ArticleId"].ToString()!="")
				{
					model.ArticleId=int.Parse(row["ArticleId"].ToString());
				}
				if(row["CategoryId"]!=null && row["CategoryId"].ToString()!="")
				{
					model.CategoryId=int.Parse(row["CategoryId"].ToString());
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
				if(row["SubTitle"]!=null)
				{
					model.SubTitle=row["SubTitle"].ToString();
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
				if(row["ThumbImageUrl"]!=null)
				{
					model.ThumbImageUrl=row["ThumbImageUrl"].ToString();
				}
				if(row["CreatedUserId"]!=null && row["CreatedUserId"].ToString()!="")
				{
					model.CreatedUserId=int.Parse(row["CreatedUserId"].ToString());
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["LastEditUserId"]!=null && row["LastEditUserId"].ToString()!="")
				{
					model.LastEditUserId=int.Parse(row["LastEditUserId"].ToString());
				}
				if(row["LastEditDate"]!=null && row["LastEditDate"].ToString()!="")
				{
					model.LastEditDate=DateTime.Parse(row["LastEditDate"].ToString());
				}
				if(row["LinkUrl"]!=null)
				{
					model.LinkUrl=row["LinkUrl"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["Sequence"]!=null && row["Sequence"].ToString()!="")
				{
					model.Sequence=int.Parse(row["Sequence"].ToString());
				}
				if(row["IsRecomend"]!=null && row["IsRecomend"].ToString()!="")
				{
					if((row["IsRecomend"].ToString()=="1")||(row["IsRecomend"].ToString().ToLower()=="true"))
					{
						model.IsRecomend=true;
					}
					else
					{
						model.IsRecomend=false;
					}
				}
				if(row["IsHot"]!=null && row["IsHot"].ToString()!="")
				{
					if((row["IsHot"].ToString()=="1")||(row["IsHot"].ToString().ToLower()=="true"))
					{
						model.IsHot=true;
					}
					else
					{
						model.IsHot=false;
					}
				}
				if(row["IsColor"]!=null && row["IsColor"].ToString()!="")
				{
					if((row["IsColor"].ToString()=="1")||(row["IsColor"].ToString().ToLower()=="true"))
					{
						model.IsColor=true;
					}
					else
					{
						model.IsColor=false;
					}
				}
				if(row["IsTop"]!=null && row["IsTop"].ToString()!="")
				{
					if((row["IsTop"].ToString()=="1")||(row["IsTop"].ToString().ToLower()=="true"))
					{
						model.IsTop=true;
					}
					else
					{
						model.IsTop=false;
					}
				}
				if(row["Comments"]!=null && row["Comments"].ToString()!="")
				{
					model.Comments=int.Parse(row["Comments"].ToString());
				}
				if(row["PvCount"]!=null && row["PvCount"].ToString()!="")
				{
					model.PvCount=int.Parse(row["PvCount"].ToString());
				}
				if(row["Supports"]!=null && row["Supports"].ToString()!="")
				{
					model.Supports=int.Parse(row["Supports"].ToString());
				}
				if(row["Favs"]!=null && row["Favs"].ToString()!="")
				{
					model.Favs=int.Parse(row["Favs"].ToString());
				}
				if(row["Keywords"]!=null)
				{
					model.Keywords=row["Keywords"].ToString();
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
			strSql.Append("select ArticleId,CategoryId,TargetId,TargetType,Title,SubTitle,Summary,Description,ImageUrl,ThumbImageUrl,CreatedUserId,CreatedDate,LastEditUserId,LastEditDate,LinkUrl,Status,Sequence,IsRecomend,IsHot,IsColor,IsTop,Comments,PvCount,Supports,Favs,Keywords,Remark ");
			strSql.Append(" FROM VPage_Article ");
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
			
			strSql.Append(" ArticleId,CategoryId,TargetId,TargetType,Title,SubTitle,Summary,Description,ImageUrl,ThumbImageUrl,CreatedUserId,CreatedDate,LastEditUserId,LastEditDate,LinkUrl,Status,Sequence,IsRecomend,IsHot,IsColor,IsTop,Comments,PvCount,Supports,Favs,Keywords,Remark ");
			strSql.Append(" FROM VPage_Article ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            if (Top > 0)
            {
                strSql.Append(" LIMIT 1  " + Top.ToString());
            }
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM VPage_Article ");
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
				strSql.Append("order by T.ArticleId desc");
			}
			strSql.Append(")AS Row, T.*  from VPage_Article T ");
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
			parameters[0].Value = "VPage_Article";
			parameters[1].Value = "ArticleId";
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

