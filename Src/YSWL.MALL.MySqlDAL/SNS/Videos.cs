/**
* Videos.cs
*
* 功 能： N/A
* 类 名： Videos
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/9/12 20:15:08   N/A    初版
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
	/// 数据访问类:Videos
	/// </summary>
	public partial class Videos:IVideos
	{
		public Videos()
		{}
		#region  BasicMethod

		

		


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.SNS.Videos model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SNS_Videos(");
			strSql.Append("VideoName,VideoUrl,Type,Description,Status,CreatedUserID,CreatedNickName,CreatedDate,CategoryId,PVCount,ThumbImageUrl,NormalImageUrl,Sequence,IsRecomend,ForwardedCount,CommentCount,FavouriteCount,OwnerVideoId,Tags)");
			strSql.Append(" values (");
			strSql.Append("?VideoName,?VideoUrl,?Type,?Description,?Status,?CreatedUserID,?CreatedNickName,?CreatedDate,?CategoryId,?PVCount,?ThumbImageUrl,?NormalImageUrl,?Sequence,?IsRecomend,?ForwardedCount,?CommentCount,?FavouriteCount,?OwnerVideoId,?Tags)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?VideoName", MySqlDbType.VarChar,200),
					new MySqlParameter("?VideoUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?Type", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.VarChar,500),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedNickName", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?PVCount", MySqlDbType.Int32,4),
					new MySqlParameter("?ThumbImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?NormalImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?IsRecomend", MySqlDbType.Int32,4),
					new MySqlParameter("?ForwardedCount", MySqlDbType.Int32,4),
					new MySqlParameter("?CommentCount", MySqlDbType.Int32,4),
					new MySqlParameter("?FavouriteCount", MySqlDbType.Int32,4),
					new MySqlParameter("?OwnerVideoId", MySqlDbType.Int32,4),
					new MySqlParameter("?Tags", MySqlDbType.VarChar,100)};
			parameters[0].Value = model.VideoName;
			parameters[1].Value = model.VideoUrl;
			parameters[2].Value = model.Type;
			parameters[3].Value = model.Description;
			parameters[4].Value = model.Status;
			parameters[5].Value = model.CreatedUserID;
			parameters[6].Value = model.CreatedNickName;
			parameters[7].Value = model.CreatedDate;
			parameters[8].Value = model.CategoryId;
			parameters[9].Value = model.PVCount;
			parameters[10].Value = model.ThumbImageUrl;
			parameters[11].Value = model.NormalImageUrl;
			parameters[12].Value = model.Sequence;
			parameters[13].Value = model.IsRecomend;
			parameters[14].Value = model.ForwardedCount;
			parameters[15].Value = model.CommentCount;
			parameters[16].Value = model.FavouriteCount;
			parameters[17].Value = model.OwnerVideoId;
			parameters[18].Value = model.Tags;

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
		public bool Update(YSWL.MALL.Model.SNS.Videos model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SNS_Videos set ");
			strSql.Append("VideoName=?VideoName,");
			strSql.Append("VideoUrl=?VideoUrl,");
			strSql.Append("Type=?Type,");
			strSql.Append("Description=?Description,");
			strSql.Append("Status=?Status,");
			strSql.Append("CreatedUserID=?CreatedUserID,");
			strSql.Append("CreatedNickName=?CreatedNickName,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("CategoryId=?CategoryId,");
			strSql.Append("PVCount=?PVCount,");
			strSql.Append("ThumbImageUrl=?ThumbImageUrl,");
			strSql.Append("NormalImageUrl=?NormalImageUrl,");
			strSql.Append("Sequence=?Sequence,");
			strSql.Append("IsRecomend=?IsRecomend,");
			strSql.Append("ForwardedCount=?ForwardedCount,");
			strSql.Append("CommentCount=?CommentCount,");
			strSql.Append("FavouriteCount=?FavouriteCount,");
			strSql.Append("OwnerVideoId=?OwnerVideoId,");
			strSql.Append("Tags=?Tags");
			strSql.Append(" where VideoID=?VideoID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?VideoName", MySqlDbType.VarChar,200),
					new MySqlParameter("?VideoUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?Type", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.VarChar,500),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedNickName", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?PVCount", MySqlDbType.Int32,4),
					new MySqlParameter("?ThumbImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?NormalImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?IsRecomend", MySqlDbType.Int32,4),
					new MySqlParameter("?ForwardedCount", MySqlDbType.Int32,4),
					new MySqlParameter("?CommentCount", MySqlDbType.Int32,4),
					new MySqlParameter("?FavouriteCount", MySqlDbType.Int32,4),
					new MySqlParameter("?OwnerVideoId", MySqlDbType.Int32,4),
					new MySqlParameter("?Tags", MySqlDbType.VarChar,100),
					new MySqlParameter("?VideoID", MySqlDbType.Int32,4)};
			parameters[0].Value = model.VideoName;
			parameters[1].Value = model.VideoUrl;
			parameters[2].Value = model.Type;
			parameters[3].Value = model.Description;
			parameters[4].Value = model.Status;
			parameters[5].Value = model.CreatedUserID;
			parameters[6].Value = model.CreatedNickName;
			parameters[7].Value = model.CreatedDate;
			parameters[8].Value = model.CategoryId;
			parameters[9].Value = model.PVCount;
			parameters[10].Value = model.ThumbImageUrl;
			parameters[11].Value = model.NormalImageUrl;
			parameters[12].Value = model.Sequence;
			parameters[13].Value = model.IsRecomend;
			parameters[14].Value = model.ForwardedCount;
			parameters[15].Value = model.CommentCount;
			parameters[16].Value = model.FavouriteCount;
			parameters[17].Value = model.OwnerVideoId;
			parameters[18].Value = model.Tags;
			parameters[19].Value = model.VideoID;

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
		public bool Delete(int VideoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SNS_Videos ");
			strSql.Append(" where VideoID=?VideoID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?VideoID", MySqlDbType.Int32,4)
			};
			parameters[0].Value = VideoID;

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
		public bool DeleteList(string VideoIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SNS_Videos ");
			strSql.Append(" where VideoID in ("+VideoIDlist + ")  ");
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
		public YSWL.MALL.Model.SNS.Videos GetModel(int VideoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select VideoID,VideoName,VideoUrl,Type,Description,Status,CreatedUserID,CreatedNickName,CreatedDate,CategoryId,PVCount,ThumbImageUrl,NormalImageUrl,Sequence,IsRecomend,ForwardedCount,CommentCount,FavouriteCount,OwnerVideoId,Tags from SNS_Videos ");
            strSql.Append(" where VideoID=?VideoID LIMIT 1");
			MySqlParameter[] parameters = {
					new MySqlParameter("?VideoID", MySqlDbType.Int32,4)
			};
			parameters[0].Value = VideoID;

			YSWL.MALL.Model.SNS.Videos model=new YSWL.MALL.Model.SNS.Videos();
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
		public YSWL.MALL.Model.SNS.Videos DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.SNS.Videos model=new YSWL.MALL.Model.SNS.Videos();
			if (row != null)
			{
				if(row["VideoID"]!=null && row["VideoID"].ToString()!="")
				{
					model.VideoID=int.Parse(row["VideoID"].ToString());
				}
				if(row["VideoName"]!=null)
				{
					model.VideoName=row["VideoName"].ToString();
				}
				if(row["VideoUrl"]!=null)
				{
					model.VideoUrl=row["VideoUrl"].ToString();
				}
				if(row["Type"]!=null && row["Type"].ToString()!="")
				{
					model.Type=int.Parse(row["Type"].ToString());
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
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
				if(row["CategoryId"]!=null && row["CategoryId"].ToString()!="")
				{
					model.CategoryId=int.Parse(row["CategoryId"].ToString());
				}
				if(row["PVCount"]!=null && row["PVCount"].ToString()!="")
				{
					model.PVCount=int.Parse(row["PVCount"].ToString());
				}
				if(row["ThumbImageUrl"]!=null)
				{
					model.ThumbImageUrl=row["ThumbImageUrl"].ToString();
				}
				if(row["NormalImageUrl"]!=null)
				{
					model.NormalImageUrl=row["NormalImageUrl"].ToString();
				}
				if(row["Sequence"]!=null && row["Sequence"].ToString()!="")
				{
					model.Sequence=int.Parse(row["Sequence"].ToString());
				}
				if(row["IsRecomend"]!=null && row["IsRecomend"].ToString()!="")
				{
					model.IsRecomend=int.Parse(row["IsRecomend"].ToString());
				}
				if(row["ForwardedCount"]!=null && row["ForwardedCount"].ToString()!="")
				{
					model.ForwardedCount=int.Parse(row["ForwardedCount"].ToString());
				}
				if(row["CommentCount"]!=null && row["CommentCount"].ToString()!="")
				{
					model.CommentCount=int.Parse(row["CommentCount"].ToString());
				}
				if(row["FavouriteCount"]!=null && row["FavouriteCount"].ToString()!="")
				{
					model.FavouriteCount=int.Parse(row["FavouriteCount"].ToString());
				}
				if(row["OwnerVideoId"]!=null && row["OwnerVideoId"].ToString()!="")
				{
					model.OwnerVideoId=int.Parse(row["OwnerVideoId"].ToString());
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
			strSql.Append("select VideoID,VideoName,VideoUrl,Type,Description,Status,CreatedUserID,CreatedNickName,CreatedDate,CategoryId,PVCount,ThumbImageUrl,NormalImageUrl,Sequence,IsRecomend,ForwardedCount,CommentCount,FavouriteCount,OwnerVideoId,Tags ");
			strSql.Append(" FROM SNS_Videos ");
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
			strSql.Append(" VideoID,VideoName,VideoUrl,Type,Description,Status,CreatedUserID,CreatedNickName,CreatedDate,CategoryId,PVCount,ThumbImageUrl,NormalImageUrl,Sequence,IsRecomend,ForwardedCount,CommentCount,FavouriteCount,OwnerVideoId,Tags ");
			strSql.Append(" FROM SNS_Videos ");
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
			strSql.Append("select count(1) FROM SNS_Videos ");
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
				strSql.Append("order by T.VideoID desc");
			}
			strSql.Append(")AS Row, T.*  from SNS_Videos T ");
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
			parameters[0].Value = "SNS_Videos";
			parameters[1].Value = "VideoID";
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

