/**
* WeiBoTaskMsg.cs
*
* 功 能： N/A
* 类 名： WeiBoTaskMsg
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/8/22 20:27:24   N/A    初版
*
* Copyright (c) 2012-2013 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Ms;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Ms
{
	/// <summary>
	/// 数据访问类:WeiBoTaskMsg
	/// </summary>
	public partial class WeiBoTaskMsg:IWeiBoTaskMsg
	{
		public WeiBoTaskMsg()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("WeiBoTaskId", "Ms_WeiBoTaskMsg"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int WeiBoTaskId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Ms_WeiBoTaskMsg");
			strSql.Append(" where WeiBoTaskId=?WeiBoTaskId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?WeiBoTaskId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = WeiBoTaskId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.Ms.WeiBoTaskMsg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Ms_WeiBoTaskMsg(");
			strSql.Append("WeiboMsg,ImageUrl,CreateDate,PublishDate)");
			strSql.Append(" values (");
			strSql.Append("?WeiboMsg,?ImageUrl,?CreateDate,?PublishDate)");
			strSql.Append(";select last_insert_id()");
			MySqlParameter[] parameters = {
					new MySqlParameter("?WeiboMsg", MySqlDbType.VarChar,200),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,300),
					new MySqlParameter("?CreateDate", MySqlDbType.DateTime),
					new MySqlParameter("?PublishDate", MySqlDbType.DateTime)};
			parameters[0].Value = model.WeiboMsg;
			parameters[1].Value = model.ImageUrl;
			parameters[2].Value = model.CreateDate;
			parameters[3].Value = model.PublishDate;

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
		public bool Update(YSWL.MALL.Model.Ms.WeiBoTaskMsg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Ms_WeiBoTaskMsg set ");
			strSql.Append("WeiboMsg=?WeiboMsg,");
			strSql.Append("ImageUrl=?ImageUrl,");
			strSql.Append("CreateDate=?CreateDate,");
			strSql.Append("PublishDate=?PublishDate");
			strSql.Append(" where WeiBoTaskId=?WeiBoTaskId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?WeiboMsg", MySqlDbType.VarChar,200),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,300),
					new MySqlParameter("?CreateDate", MySqlDbType.DateTime),
					new MySqlParameter("?PublishDate", MySqlDbType.DateTime),
					new MySqlParameter("?WeiBoTaskId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.WeiboMsg;
			parameters[1].Value = model.ImageUrl;
			parameters[2].Value = model.CreateDate;
			parameters[3].Value = model.PublishDate;
			parameters[4].Value = model.WeiBoTaskId;

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
		public bool Delete(int WeiBoTaskId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ms_WeiBoTaskMsg ");
			strSql.Append(" where WeiBoTaskId=?WeiBoTaskId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?WeiBoTaskId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = WeiBoTaskId;

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
		public bool DeleteList(string WeiBoTaskIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ms_WeiBoTaskMsg ");
			strSql.Append(" where WeiBoTaskId in ("+WeiBoTaskIdlist + ")  ");
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
		public YSWL.MALL.Model.Ms.WeiBoTaskMsg GetModel(int WeiBoTaskId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  WeiBoTaskId,WeiboMsg,ImageUrl,CreateDate,PublishDate from Ms_WeiBoTaskMsg ");
			strSql.Append(" where WeiBoTaskId=?WeiBoTaskId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?WeiBoTaskId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = WeiBoTaskId;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Ms.WeiBoTaskMsg model=new YSWL.MALL.Model.Ms.WeiBoTaskMsg();
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
		public YSWL.MALL.Model.Ms.WeiBoTaskMsg DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Ms.WeiBoTaskMsg model=new YSWL.MALL.Model.Ms.WeiBoTaskMsg();
			if (row != null)
			{
				if(row["WeiBoTaskId"]!=null && row["WeiBoTaskId"].ToString()!="")
				{
					model.WeiBoTaskId=int.Parse(row["WeiBoTaskId"].ToString());
				}
				if(row["WeiboMsg"]!=null)
				{
					model.WeiboMsg=row["WeiboMsg"].ToString();
				}
				if(row["ImageUrl"]!=null)
				{
					model.ImageUrl=row["ImageUrl"].ToString();
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(row["CreateDate"].ToString());
				}
				if(row["PublishDate"]!=null && row["PublishDate"].ToString()!="")
				{
					model.PublishDate=DateTime.Parse(row["PublishDate"].ToString());
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
			strSql.Append("select WeiBoTaskId,WeiboMsg,ImageUrl,CreateDate,PublishDate ");
			strSql.Append(" FROM Ms_WeiBoTaskMsg ");
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
			
			strSql.Append(" WeiBoTaskId,WeiboMsg,ImageUrl,CreateDate,PublishDate ");
			strSql.Append(" FROM Ms_WeiBoTaskMsg ");
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
			strSql.Append("select count(1) FROM Ms_WeiBoTaskMsg ");
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT T.* from Ms_WeiBoTaskMsg T ");
            if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (!string.IsNullOrWhiteSpace(orderby.Trim()))
            {
                strSql.Append(" order by T." + orderby);
            }
            else
            {
                strSql.Append(" order by T.WeiBoTaskId desc");
            }
            strSql.AppendFormat(" LIMIT {0},{1}", startIndex - 1, endIndex - startIndex + 1);
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
			parameters[0].Value = "Ms_WeiBoTaskMsg";
			parameters[1].Value = "WeiBoTaskId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

	    public int AddEx(YSWL.MALL.Model.Ms.WeiBoMsg model)
	    {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Ms_WeiBoTaskMsg(");
            strSql.Append("WeiboMsg,ImageUrl,CreateDate,PublishDate)");
            strSql.Append(" values (");
            strSql.Append("?WeiboMsg,?ImageUrl,?CreateDate,?PublishDate)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?WeiboMsg", MySqlDbType.VarChar,200),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,300),
					new MySqlParameter("?CreateDate", MySqlDbType.DateTime),
					new MySqlParameter("?PublishDate", MySqlDbType.DateTime)};
            parameters[0].Value = model.WeiboMsg;
            parameters[1].Value = model.ImageUrl;
            parameters[2].Value = model.CreateDate;
            parameters[3].Value = model.PublishDate;

            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
	    }


	    public bool RunTask(YSWL.MALL.Model.Ms.WeiBoTaskMsg model)
	    {
            //事务处理
            List<CommandInfo> sqllist = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Ms_WeiBoMsg(");
            strSql.Append("WeiboMsg,ImageUrl,CreateDate,PublishDate)");
            strSql.Append(" values (");
            strSql.Append("?WeiboMsg,?ImageUrl,?CreateDate,?PublishDate)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?WeiboMsg", MySqlDbType.VarChar,200),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,300),
					new MySqlParameter("?CreateDate", MySqlDbType.DateTime),
					new MySqlParameter("?PublishDate", MySqlDbType.DateTime)};
            parameters[0].Value = model.WeiboMsg;
            parameters[1].Value = model.ImageUrl;
            parameters[2].Value = model.CreateDate;
            parameters[3].Value = model.PublishDate;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            //删除指令
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("delete from Ms_WeiBoTaskMsg ");
            strSql1.Append(" where WeiBoTaskId=?WeiBoTaskId  ");
            MySqlParameter[] parameters2 = {
					new MySqlParameter("?WeiBoTaskId", MySqlDbType.Int32,4),
                                         };
            parameters2[0].Value = model.WeiBoTaskId;
            CommandInfo cmd1 = new CommandInfo(strSql1.ToString(), parameters2);
            sqllist.Add(cmd1);

            return DbHelperMySQL.ExecuteSqlTran(sqllist) > 0 ? true : false;
	    }

	    #endregion  ExtensionMethod
	}
}

