/**  版本信息模板在安装目录下，可自行修改。
* VideoClass.cs
*
* 功 能： N/A
* 类 名： VideoClass
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/2 18:10:05   N/A    初版
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
	/// 数据访问类:VideoClass
	/// </summary>
	public partial class VideoClass:IVideoClass
	{
		public VideoClass()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ClassId", "VPage_VideoClass"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ClassId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from VPage_VideoClass");
			strSql.Append(" where ClassId=?ClassId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ClassId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ClassId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.VPage.VideoClass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into VPage_VideoClass(");
			strSql.Append("TargetId,TargetType,ClassName,ParentId,Path,Depth,Sequence,Remark)");
			strSql.Append(" values (");
			strSql.Append("?TargetId,?TargetType,?ClassName,?ParentId,?Path,?Depth,?Sequence,?Remark)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TargetId", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetType", MySqlDbType.Int32,4),
					new MySqlParameter("?ClassName", MySqlDbType.VarChar,100),
					new MySqlParameter("?ParentId", MySqlDbType.Int32,4),
					new MySqlParameter("?Path", MySqlDbType.VarChar,1000),
					new MySqlParameter("?Depth", MySqlDbType.Int32,4),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,-1)};
			parameters[0].Value = model.TargetId;
			parameters[1].Value = model.TargetType;
			parameters[2].Value = model.ClassName;
			parameters[3].Value = model.ParentId;
			parameters[4].Value = model.Path;
			parameters[5].Value = model.Depth;
			parameters[6].Value = model.Sequence;
			parameters[7].Value = model.Remark;

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
		public bool Update(YSWL.MALL.Model.VPage.VideoClass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VPage_VideoClass set ");
			strSql.Append("TargetId=?TargetId,");
			strSql.Append("TargetType=?TargetType,");
			strSql.Append("ClassName=?ClassName,");
			strSql.Append("ParentId=?ParentId,");
			strSql.Append("Path=?Path,");
			strSql.Append("Depth=?Depth,");
			strSql.Append("Sequence=?Sequence,");
			strSql.Append("Remark=?Remark");
			strSql.Append(" where ClassId=?ClassId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TargetId", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetType", MySqlDbType.Int32,4),
					new MySqlParameter("?ClassName", MySqlDbType.VarChar,100),
					new MySqlParameter("?ParentId", MySqlDbType.Int32,4),
					new MySqlParameter("?Path", MySqlDbType.VarChar,1000),
					new MySqlParameter("?Depth", MySqlDbType.Int32,4),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,-1),
					new MySqlParameter("?ClassId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.TargetId;
			parameters[1].Value = model.TargetType;
			parameters[2].Value = model.ClassName;
			parameters[3].Value = model.ParentId;
			parameters[4].Value = model.Path;
			parameters[5].Value = model.Depth;
			parameters[6].Value = model.Sequence;
			parameters[7].Value = model.Remark;
			parameters[8].Value = model.ClassId;

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
		public bool Delete(int ClassId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VPage_VideoClass ");
			strSql.Append(" where ClassId=?ClassId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ClassId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ClassId;

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
		public bool DeleteList(string ClassIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VPage_VideoClass ");
			strSql.Append(" where ClassId in ("+ClassIdlist + ")  ");
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
		public YSWL.MALL.Model.VPage.VideoClass GetModel(int ClassId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ClassId,TargetId,TargetType,ClassName,ParentId,Path,Depth,Sequence,Remark from VPage_VideoClass ");
            strSql.Append(" where ClassId=?ClassId LIMIT 1 ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ClassId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ClassId;

			YSWL.MALL.Model.VPage.VideoClass model=new YSWL.MALL.Model.VPage.VideoClass();
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
		public YSWL.MALL.Model.VPage.VideoClass DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.VPage.VideoClass model=new YSWL.MALL.Model.VPage.VideoClass();
			if (row != null)
			{
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
				if(row["ClassName"]!=null)
				{
					model.ClassName=row["ClassName"].ToString();
				}
				if(row["ParentId"]!=null && row["ParentId"].ToString()!="")
				{
					model.ParentId=int.Parse(row["ParentId"].ToString());
				}
				if(row["Path"]!=null)
				{
					model.Path=row["Path"].ToString();
				}
				if(row["Depth"]!=null && row["Depth"].ToString()!="")
				{
					model.Depth=int.Parse(row["Depth"].ToString());
				}
				if(row["Sequence"]!=null && row["Sequence"].ToString()!="")
				{
					model.Sequence=int.Parse(row["Sequence"].ToString());
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
			strSql.Append("select ClassId,TargetId,TargetType,ClassName,ParentId,Path,Depth,Sequence,Remark ");
			strSql.Append(" FROM VPage_VideoClass ");
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
			
			strSql.Append(" ClassId,TargetId,TargetType,ClassName,ParentId,Path,Depth,Sequence,Remark ");
			strSql.Append(" FROM VPage_VideoClass ");
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
			strSql.Append("select count(1) FROM VPage_VideoClass ");
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
				strSql.Append("order by T.ClassId desc");
			}
			strSql.Append(")AS Row, T.*  from VPage_VideoClass T ");
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
			parameters[0].Value = "VPage_VideoClass";
			parameters[1].Value = "ClassId";
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

