/**
* UserFavAlbum.cs
*
* 功 能： N/A
* 类 名： UserFavAlbum
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/9/12 20:15:03   N/A    初版
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
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.SNS
{
	/// <summary>
	/// 数据访问类:UserFavAlbum
	/// </summary>
	public partial class UserFavAlbum:IUserFavAlbum
	{
		public UserFavAlbum()
		{}
		#region  BasicMethod

		

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AlbumID,int UserID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SNS_UserFavAlbum");
			strSql.Append(" where AlbumID=?AlbumID and UserID=?UserID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumID", MySqlDbType.Int32,4),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)			};
			parameters[0].Value = AlbumID;
			parameters[1].Value = UserID;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.SNS.UserFavAlbum model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SNS_UserFavAlbum(");
			strSql.Append("AlbumID,UserID,Tags,CreatedDate)");
			strSql.Append(" values (");
			strSql.Append("?AlbumID,?UserID,?Tags,?CreatedDate)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumID", MySqlDbType.Int32,4),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?Tags", MySqlDbType.VarChar,100),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime)};
			parameters[0].Value = model.AlbumID;
			parameters[1].Value = model.UserID;
			parameters[2].Value = model.Tags;
			parameters[3].Value = model.CreatedDate;

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
		public bool Update(YSWL.MALL.Model.SNS.UserFavAlbum model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SNS_UserFavAlbum set ");
			strSql.Append("Tags=?Tags,");
			strSql.Append("CreatedDate=?CreatedDate");
			strSql.Append(" where ID=?ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Tags", MySqlDbType.VarChar,100),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?ID", MySqlDbType.Int32,4),
					new MySqlParameter("?AlbumID", MySqlDbType.Int32,4),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)};
			parameters[0].Value = model.Tags;
			parameters[1].Value = model.CreatedDate;
			parameters[2].Value = model.ID;
			parameters[3].Value = model.AlbumID;
			parameters[4].Value = model.UserID;

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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SNS_UserFavAlbum ");
			strSql.Append(" where ID=?ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ID;

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
		public bool Delete(int AlbumID,int UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SNS_UserFavAlbum ");
			strSql.Append(" where AlbumID=?AlbumID and UserID=?UserID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumID", MySqlDbType.Int32,4),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)			};
			parameters[0].Value = AlbumID;
			parameters[1].Value = UserID;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SNS_UserFavAlbum ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public YSWL.MALL.Model.SNS.UserFavAlbum GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,AlbumID,UserID,Tags,CreatedDate from SNS_UserFavAlbum ");
            strSql.Append(" where ID=?ID LIMIT 1  ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ID;

			YSWL.MALL.Model.SNS.UserFavAlbum model=new YSWL.MALL.Model.SNS.UserFavAlbum();
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
		public YSWL.MALL.Model.SNS.UserFavAlbum DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.SNS.UserFavAlbum model=new YSWL.MALL.Model.SNS.UserFavAlbum();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["AlbumID"]!=null && row["AlbumID"].ToString()!="")
				{
					model.AlbumID=int.Parse(row["AlbumID"].ToString());
				}
				if(row["UserID"]!=null && row["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(row["UserID"].ToString());
				}
				if(row["Tags"]!=null)
				{
					model.Tags=row["Tags"].ToString();
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
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
			strSql.Append("select ID,AlbumID,UserID,Tags,CreatedDate ");
			strSql.Append(" FROM SNS_UserFavAlbum ");
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
			
			strSql.Append(" ID,AlbumID,UserID,Tags,CreatedDate ");
			strSql.Append(" FROM SNS_UserFavAlbum ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by " + filedOrder);
            }
            else
            {
                strSql.Append(" order by ID desc");
            }
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
			strSql.Append("select count(1) FROM SNS_UserFavAlbum ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from SNS_UserFavAlbum T ");
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
			parameters[0].Value = "SNS_UserFavAlbum";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        #region  收藏专辑

        public int FavAlbum(int AlbumId, int UserId)
        {
          
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SNS_UserFavAlbum(");
            strSql.Append("AlbumID,UserID,CreatedDate)");
            strSql.Append(" values (");
            strSql.Append("?AlbumID,?UserID,?CreatedDate)");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumID", MySqlDbType.Int32,4),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime)};
            parameters[0].Value = AlbumId;
            parameters[1].Value = UserId;
            parameters[2].Value = DateTime.Now;
          
            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);
            StringBuilder strSql2;
            strSql2 = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("update SNS_UserAlbums set ");
            strSql1.Append("FavouriteCount=FavouriteCount+1 ");
            strSql1.Append(" where AlbumID=?AlbumID");
            MySqlParameter[] parameters1 = {
					new MySqlParameter("?AlbumID", MySqlDbType.Int32,4)};
            parameters1[0].Value = AlbumId;
            cmd = new CommandInfo(strSql1.ToString(), parameters1);
            sqllist.Add(cmd);
            return DbHelperMySQL.ExecuteSqlTran(sqllist);
             

        } 
        #endregion

        #region 取消收藏专辑

        public int UnFavAlbum(int AlbumId, int UserId)
        {
            //转发的时候除过转发的内容以外，还应该直接转发动态的id和原始动态id，对他们的转发次数分别加1
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SNS_UserFavAlbum ");
            strSql.Append(" where AlbumID=?AlbumID AND UserID=?UserID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumID", MySqlDbType.Int32,4),
                    new MySqlParameter("?UserID",MySqlDbType.Int32,4)
			};
            parameters[0].Value = AlbumId;
            parameters[1].Value = UserId;
            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);
            StringBuilder strSql2;
            strSql2 = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("update SNS_UserAlbums set ");
            strSql1.Append("FavouriteCount=FavouriteCount-1 ");
            strSql1.Append(" where AlbumID=?AlbumID");
            MySqlParameter[] parameters1 = {
					new MySqlParameter("?AlbumID", MySqlDbType.Int32,4)};
            parameters[0].Value = AlbumId;
            cmd = new CommandInfo(strSql1.ToString(), parameters1);
            sqllist.Add(cmd);
          return   DbHelperMySQL.ExecuteSqlTran(sqllist);
         
        }
        #endregion

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetListEx(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            
            strSql.Append(" SELECT SNSFA.*,SNSUA.AlbumName,AU.NickName ");
            strSql.Append(" FROM SNS_UserFavAlbum SNSFA ");
            strSql.Append(" LEFT JOIN SNS_UserAlbums SNSUA ON SNSUA.AlbumID=SNSFA.AlbumID ");
            strSql.Append(" LEFT JOIN Accounts_Users AU ON AU.UserID=SNSFA.UserID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by " + filedOrder);
            }
            else
            {
                strSql.Append(" order by ID desc");
            }
            if (Top > 0)
            {
                strSql.Append(" LIMIT " + Top.ToString());
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

  
		#endregion  ExtensionMethod
	}
}

