/**  版本信息模板在安装目录下，可自行修改。
* Video.cs
*
* 功 能： N/A
* 类 名： Video
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/2 18:10:02   N/A    初版
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
	/// 数据访问类:Video
	/// </summary>
	public partial class Video:IVideo
	{
		public Video()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("VideoId", "VPage_Video"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int VideoId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from VPage_Video");
			strSql.Append(" where VideoId=?VideoId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?VideoId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = VideoId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.VPage.Video model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into VPage_Video(");
			strSql.Append("TargetId,TargetType,Title,AlbumId,CreatedUserId,Description,CreatedDate,Sequence,VideoClassId,IsRecomend,ImageUrl,ThumbImageUrl,TotalTime,TotalComment,TotalFav,TotalUp,Reference,Tags,VideoUrl,UrlType,VideoFormat,Domain,Grade,PVCount,Attachment,Privacy,Status,Remark)");
			strSql.Append(" values (");
			strSql.Append("?TargetId,?TargetType,?Title,?AlbumId,?CreatedUserId,?Description,?CreatedDate,?Sequence,?VideoClassId,?IsRecomend,?ImageUrl,?ThumbImageUrl,?TotalTime,?TotalComment,?TotalFav,?TotalUp,?Reference,?Tags,?VideoUrl,?UrlType,?VideoFormat,?Domain,?Grade,?PVCount,?Attachment,?Privacy,?Status,?Remark)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TargetId", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetType", MySqlDbType.Int32,4),
					new MySqlParameter("?Title", MySqlDbType.VarChar,200),
					new MySqlParameter("?AlbumId", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?VideoClassId", MySqlDbType.Int32,4),
					new MySqlParameter("?IsRecomend", MySqlDbType.Bit,1),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?ThumbImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?TotalTime", MySqlDbType.Int32,4),
					new MySqlParameter("?TotalComment", MySqlDbType.Int32,4),
					new MySqlParameter("?TotalFav", MySqlDbType.Int32,4),
					new MySqlParameter("?TotalUp", MySqlDbType.Int32,4),
					new MySqlParameter("?Reference", MySqlDbType.Int32,4),
					new MySqlParameter("?Tags", MySqlDbType.VarChar,100),
					new MySqlParameter("?VideoUrl", MySqlDbType.VarChar,-1),
					new MySqlParameter("?UrlType", MySqlDbType.Int16,2),
					new MySqlParameter("?VideoFormat", MySqlDbType.VarChar,50),
					new MySqlParameter("?Domain", MySqlDbType.VarChar,50),
					new MySqlParameter("?Grade", MySqlDbType.Int32,4),
					new MySqlParameter("?PVCount", MySqlDbType.Int32,4),
					new MySqlParameter("?Attachment", MySqlDbType.VarChar,100),
					new MySqlParameter("?Privacy", MySqlDbType.Int16,2),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,300)};
			parameters[0].Value = model.TargetId;
			parameters[1].Value = model.TargetType;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.AlbumId;
			parameters[4].Value = model.CreatedUserId;
			parameters[5].Value = model.Description;
			parameters[6].Value = model.CreatedDate;
			parameters[7].Value = model.Sequence;
			parameters[8].Value = model.VideoClassId;
			parameters[9].Value = model.IsRecomend;
			parameters[10].Value = model.ImageUrl;
			parameters[11].Value = model.ThumbImageUrl;
			parameters[12].Value = model.TotalTime;
			parameters[13].Value = model.TotalComment;
			parameters[14].Value = model.TotalFav;
			parameters[15].Value = model.TotalUp;
			parameters[16].Value = model.Reference;
			parameters[17].Value = model.Tags;
			parameters[18].Value = model.VideoUrl;
			parameters[19].Value = model.UrlType;
			parameters[20].Value = model.VideoFormat;
			parameters[21].Value = model.Domain;
			parameters[22].Value = model.Grade;
			parameters[23].Value = model.PVCount;
			parameters[24].Value = model.Attachment;
			parameters[25].Value = model.Privacy;
			parameters[26].Value = model.Status;
			parameters[27].Value = model.Remark;

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
		public bool Update(YSWL.MALL.Model.VPage.Video model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VPage_Video set ");
			strSql.Append("TargetId=?TargetId,");
			strSql.Append("TargetType=?TargetType,");
			strSql.Append("Title=?Title,");
			strSql.Append("AlbumId=?AlbumId,");
			strSql.Append("CreatedUserId=?CreatedUserId,");
			strSql.Append("Description=?Description,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("Sequence=?Sequence,");
			strSql.Append("VideoClassId=?VideoClassId,");
			strSql.Append("IsRecomend=?IsRecomend,");
			strSql.Append("ImageUrl=?ImageUrl,");
			strSql.Append("ThumbImageUrl=?ThumbImageUrl,");
			strSql.Append("TotalTime=?TotalTime,");
			strSql.Append("TotalComment=?TotalComment,");
			strSql.Append("TotalFav=?TotalFav,");
			strSql.Append("TotalUp=?TotalUp,");
			strSql.Append("Reference=?Reference,");
			strSql.Append("Tags=?Tags,");
			strSql.Append("VideoUrl=?VideoUrl,");
			strSql.Append("UrlType=?UrlType,");
			strSql.Append("VideoFormat=?VideoFormat,");
			strSql.Append("Domain=?Domain,");
			strSql.Append("Grade=?Grade,");
			strSql.Append("PVCount=?PVCount,");
			strSql.Append("Attachment=?Attachment,");
			strSql.Append("Privacy=?Privacy,");
			strSql.Append("Status=?Status,");
			strSql.Append("Remark=?Remark");
			strSql.Append(" where VideoId=?VideoId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TargetId", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetType", MySqlDbType.Int32,4),
					new MySqlParameter("?Title", MySqlDbType.VarChar,200),
					new MySqlParameter("?AlbumId", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?VideoClassId", MySqlDbType.Int32,4),
					new MySqlParameter("?IsRecomend", MySqlDbType.Bit,1),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?ThumbImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?TotalTime", MySqlDbType.Int32,4),
					new MySqlParameter("?TotalComment", MySqlDbType.Int32,4),
					new MySqlParameter("?TotalFav", MySqlDbType.Int32,4),
					new MySqlParameter("?TotalUp", MySqlDbType.Int32,4),
					new MySqlParameter("?Reference", MySqlDbType.Int32,4),
					new MySqlParameter("?Tags", MySqlDbType.VarChar,100),
					new MySqlParameter("?VideoUrl", MySqlDbType.VarChar,-1),
					new MySqlParameter("?UrlType", MySqlDbType.Int16,2),
					new MySqlParameter("?VideoFormat", MySqlDbType.VarChar,50),
					new MySqlParameter("?Domain", MySqlDbType.VarChar,50),
					new MySqlParameter("?Grade", MySqlDbType.Int32,4),
					new MySqlParameter("?PVCount", MySqlDbType.Int32,4),
					new MySqlParameter("?Attachment", MySqlDbType.VarChar,100),
					new MySqlParameter("?Privacy", MySqlDbType.Int16,2),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,300),
					new MySqlParameter("?VideoId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.TargetId;
			parameters[1].Value = model.TargetType;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.AlbumId;
			parameters[4].Value = model.CreatedUserId;
			parameters[5].Value = model.Description;
			parameters[6].Value = model.CreatedDate;
			parameters[7].Value = model.Sequence;
			parameters[8].Value = model.VideoClassId;
			parameters[9].Value = model.IsRecomend;
			parameters[10].Value = model.ImageUrl;
			parameters[11].Value = model.ThumbImageUrl;
			parameters[12].Value = model.TotalTime;
			parameters[13].Value = model.TotalComment;
			parameters[14].Value = model.TotalFav;
			parameters[15].Value = model.TotalUp;
			parameters[16].Value = model.Reference;
			parameters[17].Value = model.Tags;
			parameters[18].Value = model.VideoUrl;
			parameters[19].Value = model.UrlType;
			parameters[20].Value = model.VideoFormat;
			parameters[21].Value = model.Domain;
			parameters[22].Value = model.Grade;
			parameters[23].Value = model.PVCount;
			parameters[24].Value = model.Attachment;
			parameters[25].Value = model.Privacy;
			parameters[26].Value = model.Status;
			parameters[27].Value = model.Remark;
			parameters[28].Value = model.VideoId;

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
		public bool Delete(int VideoId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VPage_Video ");
			strSql.Append(" where VideoId=?VideoId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?VideoId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = VideoId;

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
		public bool DeleteList(string VideoIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VPage_Video ");
			strSql.Append(" where VideoId in ("+VideoIdlist + ")  ");
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
		public YSWL.MALL.Model.VPage.Video GetModel(int VideoId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  VideoId,TargetId,TargetType,Title,AlbumId,CreatedUserId,Description,CreatedDate,Sequence,VideoClassId,IsRecomend,ImageUrl,ThumbImageUrl,TotalTime,TotalComment,TotalFav,TotalUp,Reference,Tags,VideoUrl,UrlType,VideoFormat,Domain,Grade,PVCount,Attachment,Privacy,Status,Remark from VPage_Video ");
            strSql.Append(" where VideoId=?VideoId LIMIT 1 ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?VideoId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = VideoId;

			YSWL.MALL.Model.VPage.Video model=new YSWL.MALL.Model.VPage.Video();
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
		public YSWL.MALL.Model.VPage.Video DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.VPage.Video model=new YSWL.MALL.Model.VPage.Video();
			if (row != null)
			{
				if(row["VideoId"]!=null && row["VideoId"].ToString()!="")
				{
					model.VideoId=int.Parse(row["VideoId"].ToString());
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
				if(row["AlbumId"]!=null && row["AlbumId"].ToString()!="")
				{
					model.AlbumId=int.Parse(row["AlbumId"].ToString());
				}
				if(row["CreatedUserId"]!=null && row["CreatedUserId"].ToString()!="")
				{
					model.CreatedUserId=int.Parse(row["CreatedUserId"].ToString());
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["Sequence"]!=null && row["Sequence"].ToString()!="")
				{
					model.Sequence=int.Parse(row["Sequence"].ToString());
				}
				if(row["VideoClassId"]!=null && row["VideoClassId"].ToString()!="")
				{
					model.VideoClassId=int.Parse(row["VideoClassId"].ToString());
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
				if(row["ImageUrl"]!=null)
				{
					model.ImageUrl=row["ImageUrl"].ToString();
				}
				if(row["ThumbImageUrl"]!=null)
				{
					model.ThumbImageUrl=row["ThumbImageUrl"].ToString();
				}
				if(row["TotalTime"]!=null && row["TotalTime"].ToString()!="")
				{
					model.TotalTime=int.Parse(row["TotalTime"].ToString());
				}
				if(row["TotalComment"]!=null && row["TotalComment"].ToString()!="")
				{
					model.TotalComment=int.Parse(row["TotalComment"].ToString());
				}
				if(row["TotalFav"]!=null && row["TotalFav"].ToString()!="")
				{
					model.TotalFav=int.Parse(row["TotalFav"].ToString());
				}
				if(row["TotalUp"]!=null && row["TotalUp"].ToString()!="")
				{
					model.TotalUp=int.Parse(row["TotalUp"].ToString());
				}
				if(row["Reference"]!=null && row["Reference"].ToString()!="")
				{
					model.Reference=int.Parse(row["Reference"].ToString());
				}
				if(row["Tags"]!=null)
				{
					model.Tags=row["Tags"].ToString();
				}
				if(row["VideoUrl"]!=null)
				{
					model.VideoUrl=row["VideoUrl"].ToString();
				}
				if(row["UrlType"]!=null && row["UrlType"].ToString()!="")
				{
					model.UrlType=int.Parse(row["UrlType"].ToString());
				}
				if(row["VideoFormat"]!=null)
				{
					model.VideoFormat=row["VideoFormat"].ToString();
				}
				if(row["Domain"]!=null)
				{
					model.Domain=row["Domain"].ToString();
				}
				if(row["Grade"]!=null && row["Grade"].ToString()!="")
				{
					model.Grade=int.Parse(row["Grade"].ToString());
				}
				if(row["PVCount"]!=null && row["PVCount"].ToString()!="")
				{
					model.PVCount=int.Parse(row["PVCount"].ToString());
				}
				if(row["Attachment"]!=null)
				{
					model.Attachment=row["Attachment"].ToString();
				}
				if(row["Privacy"]!=null && row["Privacy"].ToString()!="")
				{
					model.Privacy=int.Parse(row["Privacy"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
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
			strSql.Append("select VideoId,TargetId,TargetType,Title,AlbumId,CreatedUserId,Description,CreatedDate,Sequence,VideoClassId,IsRecomend,ImageUrl,ThumbImageUrl,TotalTime,TotalComment,TotalFav,TotalUp,Reference,Tags,VideoUrl,UrlType,VideoFormat,Domain,Grade,PVCount,Attachment,Privacy,Status,Remark ");
			strSql.Append(" FROM VPage_Video ");
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
			
			strSql.Append(" VideoId,TargetId,TargetType,Title,AlbumId,CreatedUserId,Description,CreatedDate,Sequence,VideoClassId,IsRecomend,ImageUrl,ThumbImageUrl,TotalTime,TotalComment,TotalFav,TotalUp,Reference,Tags,VideoUrl,UrlType,VideoFormat,Domain,Grade,PVCount,Attachment,Privacy,Status,Remark ");
			strSql.Append(" FROM VPage_Video ");
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
			strSql.Append("select count(1) FROM VPage_Video ");
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
				strSql.Append("order by T.VideoId desc");
			}
			strSql.Append(")AS Row, T.*  from VPage_Video T ");
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
			parameters[0].Value = "VPage_Video";
			parameters[1].Value = "VideoId";
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

