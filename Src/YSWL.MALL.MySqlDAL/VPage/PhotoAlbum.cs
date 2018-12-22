/**  版本信息模板在安装目录下，可自行修改。
* PhotoAlbum.cs
*
* 功 能： N/A
* 类 名： PhotoAlbum
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/2 18:09:59   N/A    初版
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
	/// 数据访问类:PhotoAlbum
	/// </summary>
	public partial class PhotoAlbum:IPhotoAlbum
	{
		public PhotoAlbum()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("AlbumId", "VPage_PhotoAlbum"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AlbumId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from VPage_PhotoAlbum");
			strSql.Append(" where AlbumId=?AlbumId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = AlbumId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.VPage.PhotoAlbum model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into VPage_PhotoAlbum(");
			strSql.Append("TargetId,TargetType,AlbumName,CoverPhotoId,Status,CreatedUserId,CreatedDate,Sequence,Privacy,Description)");
			strSql.Append(" values (");
			strSql.Append("?TargetId,?TargetType,?AlbumName,?CoverPhotoId,?Status,?CreatedUserId,?CreatedDate,?Sequence,?Privacy,?Description)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TargetId", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetType", MySqlDbType.Int32,4),
					new MySqlParameter("?AlbumName", MySqlDbType.VarChar,200),
					new MySqlParameter("?CoverPhotoId", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?CreatedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Privacy", MySqlDbType.Int16,2),
					new MySqlParameter("?Description", MySqlDbType.Text)};
			parameters[0].Value = model.TargetId;
			parameters[1].Value = model.TargetType;
			parameters[2].Value = model.AlbumName;
			parameters[3].Value = model.CoverPhotoId;
			parameters[4].Value = model.Status;
			parameters[5].Value = model.CreatedUserId;
			parameters[6].Value = model.CreatedDate;
			parameters[7].Value = model.Sequence;
			parameters[8].Value = model.Privacy;
			parameters[9].Value = model.Description;

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
		public bool Update(YSWL.MALL.Model.VPage.PhotoAlbum model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VPage_PhotoAlbum set ");
			strSql.Append("TargetId=?TargetId,");
			strSql.Append("TargetType=?TargetType,");
			strSql.Append("AlbumName=?AlbumName,");
			strSql.Append("CoverPhotoId=?CoverPhotoId,");
			strSql.Append("Status=?Status,");
			strSql.Append("CreatedUserId=?CreatedUserId,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("Sequence=?Sequence,");
			strSql.Append("Privacy=?Privacy,");
			strSql.Append("Description=?Description");
			strSql.Append(" where AlbumId=?AlbumId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TargetId", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetType", MySqlDbType.Int32,4),
					new MySqlParameter("?AlbumName", MySqlDbType.VarChar,200),
					new MySqlParameter("?CoverPhotoId", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?CreatedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Privacy", MySqlDbType.Int16,2),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?AlbumId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.TargetId;
			parameters[1].Value = model.TargetType;
			parameters[2].Value = model.AlbumName;
			parameters[3].Value = model.CoverPhotoId;
			parameters[4].Value = model.Status;
			parameters[5].Value = model.CreatedUserId;
			parameters[6].Value = model.CreatedDate;
			parameters[7].Value = model.Sequence;
			parameters[8].Value = model.Privacy;
			parameters[9].Value = model.Description;
			parameters[10].Value = model.AlbumId;

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
		public bool Delete(int AlbumId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VPage_PhotoAlbum ");
			strSql.Append(" where AlbumId=?AlbumId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = AlbumId;

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
		public bool DeleteList(string AlbumIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VPage_PhotoAlbum ");
			strSql.Append(" where AlbumId in ("+AlbumIdlist + ")  ");
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
		public YSWL.MALL.Model.VPage.PhotoAlbum GetModel(int AlbumId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AlbumId,TargetId,TargetType,AlbumName,CoverPhotoId,Status,CreatedUserId,CreatedDate,Sequence,Privacy,Description from VPage_PhotoAlbum ");
            strSql.Append(" where AlbumId=?AlbumId LIMIT 1 ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = AlbumId;

			YSWL.MALL.Model.VPage.PhotoAlbum model=new YSWL.MALL.Model.VPage.PhotoAlbum();
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
		public YSWL.MALL.Model.VPage.PhotoAlbum DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.VPage.PhotoAlbum model=new YSWL.MALL.Model.VPage.PhotoAlbum();
			if (row != null)
			{
				if(row["AlbumId"]!=null && row["AlbumId"].ToString()!="")
				{
					model.AlbumId=int.Parse(row["AlbumId"].ToString());
				}
				if(row["TargetId"]!=null && row["TargetId"].ToString()!="")
				{
					model.TargetId=int.Parse(row["TargetId"].ToString());
				}
				if(row["TargetType"]!=null && row["TargetType"].ToString()!="")
				{
					model.TargetType=int.Parse(row["TargetType"].ToString());
				}
				if(row["AlbumName"]!=null)
				{
					model.AlbumName=row["AlbumName"].ToString();
				}
				if(row["CoverPhotoId"]!=null && row["CoverPhotoId"].ToString()!="")
				{
					model.CoverPhotoId=int.Parse(row["CoverPhotoId"].ToString());
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
				if(row["Sequence"]!=null && row["Sequence"].ToString()!="")
				{
					model.Sequence=int.Parse(row["Sequence"].ToString());
				}
				if(row["Privacy"]!=null && row["Privacy"].ToString()!="")
				{
					model.Privacy=int.Parse(row["Privacy"].ToString());
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
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
			strSql.Append("select AlbumId,TargetId,TargetType,AlbumName,CoverPhotoId,Status,CreatedUserId,CreatedDate,Sequence,Privacy,Description ");
			strSql.Append(" FROM VPage_PhotoAlbum ");
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
			
			strSql.Append(" AlbumId,TargetId,TargetType,AlbumName,CoverPhotoId,Status,CreatedUserId,CreatedDate,Sequence,Privacy,Description ");
			strSql.Append(" FROM VPage_PhotoAlbum ");
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
			strSql.Append("select count(1) FROM VPage_PhotoAlbum ");
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
				strSql.Append("order by T.AlbumId desc");
			}
			strSql.Append(")AS Row, T.*  from VPage_PhotoAlbum T ");
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
			parameters[0].Value = "VPage_PhotoAlbum";
			parameters[1].Value = "AlbumId";
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

