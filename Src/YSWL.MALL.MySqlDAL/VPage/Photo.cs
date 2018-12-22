/**  版本信息模板在安装目录下，可自行修改。
* Photo.cs
*
* 功 能： N/A
* 类 名： Photo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/2 18:09:58   N/A    初版
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
	/// 数据访问类:Photo
	/// </summary>
	public partial class Photo:IPhoto
	{
		public Photo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("PhotoId", "VPage_Photo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PhotoId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from VPage_Photo");
			strSql.Append(" where PhotoId=?PhotoId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?PhotoId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = PhotoId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.VPage.Photo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into VPage_Photo(");
			strSql.Append("AlbumId,ClassId,TargetId,TargetType,PhotoName,ImageUrl,ThumbImageUrl,Description,Sequence,Status,CreatedUserId,CreatedDate,Recomend,PVCount,Comments,Favourites,Tags)");
			strSql.Append(" values (");
			strSql.Append("?AlbumId,?ClassId,?TargetId,?TargetType,?PhotoName,?ImageUrl,?ThumbImageUrl,?Description,?Sequence,?Status,?CreatedUserId,?CreatedDate,?Recomend,?PVCount,?Comments,?Favourites,?Tags)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumId", MySqlDbType.Int32,4),
					new MySqlParameter("?ClassId", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetId", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetType", MySqlDbType.Int32,4),
					new MySqlParameter("?PhotoName", MySqlDbType.VarChar,200),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?ThumbImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?Description", MySqlDbType.VarChar,500),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?CreatedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Recomend", MySqlDbType.Int32,4),
					new MySqlParameter("?PVCount", MySqlDbType.Int32,4),
					new MySqlParameter("?Comments", MySqlDbType.Int32,4),
					new MySqlParameter("?Favourites", MySqlDbType.Int32,4),
					new MySqlParameter("?Tags", MySqlDbType.VarChar,200)};
			parameters[0].Value = model.AlbumId;
			parameters[1].Value = model.ClassId;
			parameters[2].Value = model.TargetId;
			parameters[3].Value = model.TargetType;
			parameters[4].Value = model.PhotoName;
			parameters[5].Value = model.ImageUrl;
			parameters[6].Value = model.ThumbImageUrl;
			parameters[7].Value = model.Description;
			parameters[8].Value = model.Sequence;
			parameters[9].Value = model.Status;
			parameters[10].Value = model.CreatedUserId;
			parameters[11].Value = model.CreatedDate;
			parameters[12].Value = model.Recomend;
			parameters[13].Value = model.PVCount;
			parameters[14].Value = model.Comments;
			parameters[15].Value = model.Favourites;
			parameters[16].Value = model.Tags;

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
		public bool Update(YSWL.MALL.Model.VPage.Photo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VPage_Photo set ");
			strSql.Append("AlbumId=?AlbumId,");
			strSql.Append("ClassId=?ClassId,");
			strSql.Append("TargetId=?TargetId,");
			strSql.Append("TargetType=?TargetType,");
			strSql.Append("PhotoName=?PhotoName,");
			strSql.Append("ImageUrl=?ImageUrl,");
			strSql.Append("ThumbImageUrl=?ThumbImageUrl,");
			strSql.Append("Description=?Description,");
			strSql.Append("Sequence=?Sequence,");
			strSql.Append("Status=?Status,");
			strSql.Append("CreatedUserId=?CreatedUserId,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("Recomend=?Recomend,");
			strSql.Append("PVCount=?PVCount,");
			strSql.Append("Comments=?Comments,");
			strSql.Append("Favourites=?Favourites,");
			strSql.Append("Tags=?Tags");
			strSql.Append(" where PhotoId=?PhotoId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumId", MySqlDbType.Int32,4),
					new MySqlParameter("?ClassId", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetId", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetType", MySqlDbType.Int32,4),
					new MySqlParameter("?PhotoName", MySqlDbType.VarChar,200),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?ThumbImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?Description", MySqlDbType.VarChar,500),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?CreatedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Recomend", MySqlDbType.Int32,4),
					new MySqlParameter("?PVCount", MySqlDbType.Int32,4),
					new MySqlParameter("?Comments", MySqlDbType.Int32,4),
					new MySqlParameter("?Favourites", MySqlDbType.Int32,4),
					new MySqlParameter("?Tags", MySqlDbType.VarChar,200),
					new MySqlParameter("?PhotoId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.AlbumId;
			parameters[1].Value = model.ClassId;
			parameters[2].Value = model.TargetId;
			parameters[3].Value = model.TargetType;
			parameters[4].Value = model.PhotoName;
			parameters[5].Value = model.ImageUrl;
			parameters[6].Value = model.ThumbImageUrl;
			parameters[7].Value = model.Description;
			parameters[8].Value = model.Sequence;
			parameters[9].Value = model.Status;
			parameters[10].Value = model.CreatedUserId;
			parameters[11].Value = model.CreatedDate;
			parameters[12].Value = model.Recomend;
			parameters[13].Value = model.PVCount;
			parameters[14].Value = model.Comments;
			parameters[15].Value = model.Favourites;
			parameters[16].Value = model.Tags;
			parameters[17].Value = model.PhotoId;

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
		public bool Delete(int PhotoId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VPage_Photo ");
			strSql.Append(" where PhotoId=?PhotoId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?PhotoId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = PhotoId;

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
		public bool DeleteList(string PhotoIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VPage_Photo ");
			strSql.Append(" where PhotoId in ("+PhotoIdlist + ")  ");
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
		public YSWL.MALL.Model.VPage.Photo GetModel(int PhotoId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  PhotoId,AlbumId,ClassId,TargetId,TargetType,PhotoName,ImageUrl,ThumbImageUrl,Description,Sequence,Status,CreatedUserId,CreatedDate,Recomend,PVCount,Comments,Favourites,Tags from VPage_Photo ");
            strSql.Append(" where PhotoId=?PhotoId LIMIT 1 ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?PhotoId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = PhotoId;

			YSWL.MALL.Model.VPage.Photo model=new YSWL.MALL.Model.VPage.Photo();
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
		public YSWL.MALL.Model.VPage.Photo DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.VPage.Photo model=new YSWL.MALL.Model.VPage.Photo();
			if (row != null)
			{
				if(row["PhotoId"]!=null && row["PhotoId"].ToString()!="")
				{
					model.PhotoId=int.Parse(row["PhotoId"].ToString());
				}
				if(row["AlbumId"]!=null && row["AlbumId"].ToString()!="")
				{
					model.AlbumId=int.Parse(row["AlbumId"].ToString());
				}
				if(row["ClassId"]!=null && row["ClassId"].ToString()!="")
				{
					model.ClassId=int.Parse(row["ClassId"].ToString());
				}
				if(row["TargetId"]!=null && row["TargetId"].ToString()!="")
				{
					model.TargetId=int.Parse(row["TargetId"].ToString());
				}
				if(row["TargetType"]!=null && row["TargetType"].ToString()!="")
				{
					model.TargetType=int.Parse(row["TargetType"].ToString());
				}
				if(row["PhotoName"]!=null)
				{
					model.PhotoName=row["PhotoName"].ToString();
				}
				if(row["ImageUrl"]!=null)
				{
					model.ImageUrl=row["ImageUrl"].ToString();
				}
				if(row["ThumbImageUrl"]!=null)
				{
					model.ThumbImageUrl=row["ThumbImageUrl"].ToString();
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["Sequence"]!=null && row["Sequence"].ToString()!="")
				{
					model.Sequence=int.Parse(row["Sequence"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["CreatedUserId"]!=null && row["CreatedUserId"].ToString()!="")
				{
					model.CreatedUserId=int.Parse(row["CreatedUserId"].ToString());
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["Recomend"]!=null && row["Recomend"].ToString()!="")
				{
					model.Recomend=int.Parse(row["Recomend"].ToString());
				}
				if(row["PVCount"]!=null && row["PVCount"].ToString()!="")
				{
					model.PVCount=int.Parse(row["PVCount"].ToString());
				}
				if(row["Comments"]!=null && row["Comments"].ToString()!="")
				{
					model.Comments=int.Parse(row["Comments"].ToString());
				}
				if(row["Favourites"]!=null && row["Favourites"].ToString()!="")
				{
					model.Favourites=int.Parse(row["Favourites"].ToString());
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
			strSql.Append("select PhotoId,AlbumId,ClassId,TargetId,TargetType,PhotoName,ImageUrl,ThumbImageUrl,Description,Sequence,Status,CreatedUserId,CreatedDate,Recomend,PVCount,Comments,Favourites,Tags ");
			strSql.Append(" FROM VPage_Photo ");
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
			
			strSql.Append(" PhotoId,AlbumId,ClassId,TargetId,TargetType,PhotoName,ImageUrl,ThumbImageUrl,Description,Sequence,Status,CreatedUserId,CreatedDate,Recomend,PVCount,Comments,Favourites,Tags ");
			strSql.Append(" FROM VPage_Photo ");
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
			strSql.Append("select count(1) FROM VPage_Photo ");
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
				strSql.Append("order by T.PhotoId desc");
			}
			strSql.Append(")AS Row, T.*  from VPage_Photo T ");
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
			parameters[0].Value = "VPage_Photo";
			parameters[1].Value = "PhotoId";
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

