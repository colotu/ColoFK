/**
* VisiteLogs.cs
*
* 功 能： N/A
* 类 名： VisiteLogs
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/9/12 20:15:09   N/A    初版
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
	/// 数据访问类:VisiteLogs
	/// </summary>
	public partial class VisiteLogs:IVisiteLogs
	{
		public VisiteLogs()
		{}
		#region  BasicMethod

		

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.SNS.VisiteLogs model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SNS_VisiteLogs(");
			strSql.Append("FromUserID,FromNickName,ToUserID,ToNickName,VisitTimes,LastVisitTime)");
			strSql.Append(" values (");
			strSql.Append("?FromUserID,?FromNickName,?ToUserID,?ToNickName,?VisitTimes,?LastVisitTime)");
			strSql.Append(";select last_insert_id()");
			MySqlParameter[] parameters = {
					new MySqlParameter("?FromUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?FromNickName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ToUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?ToNickName", MySqlDbType.VarChar,50),
					new MySqlParameter("?VisitTimes", MySqlDbType.Int32,4),
					new MySqlParameter("?LastVisitTime", MySqlDbType.DateTime)};
			parameters[0].Value = model.FromUserID;
			parameters[1].Value = model.FromNickName;
			parameters[2].Value = model.ToUserID;
			parameters[3].Value = model.ToNickName;
			parameters[4].Value = model.VisitTimes;
			parameters[5].Value = model.LastVisitTime;

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
		public bool Update(YSWL.MALL.Model.SNS.VisiteLogs model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SNS_VisiteLogs set ");
			strSql.Append("FromUserID=?FromUserID,");
			strSql.Append("FromNickName=?FromNickName,");
			strSql.Append("ToUserID=?ToUserID,");
			strSql.Append("ToNickName=?ToNickName,");
			strSql.Append("VisitTimes=?VisitTimes,");
			strSql.Append("LastVisitTime=?LastVisitTime");
			strSql.Append(" where VisitID=?VisitID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?FromUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?FromNickName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ToUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?ToNickName", MySqlDbType.VarChar,50),
					new MySqlParameter("?VisitTimes", MySqlDbType.Int32,4),
					new MySqlParameter("?LastVisitTime", MySqlDbType.DateTime),
					new MySqlParameter("?VisitID", MySqlDbType.Int32,4)};
			parameters[0].Value = model.FromUserID;
			parameters[1].Value = model.FromNickName;
			parameters[2].Value = model.ToUserID;
			parameters[3].Value = model.ToNickName;
			parameters[4].Value = model.VisitTimes;
			parameters[5].Value = model.LastVisitTime;
			parameters[6].Value = model.VisitID;

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
		public bool Delete(int VisitID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SNS_VisiteLogs ");
			strSql.Append(" where VisitID=?VisitID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?VisitID", MySqlDbType.Int32,4)
			};
			parameters[0].Value = VisitID;

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
		public bool DeleteList(string VisitIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SNS_VisiteLogs ");
			strSql.Append(" where VisitID in ("+VisitIDlist + ")  ");
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
		public YSWL.MALL.Model.SNS.VisiteLogs GetModel(int VisitID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  VisitID,FromUserID,FromNickName,ToUserID,ToNickName,VisitTimes,LastVisitTime from SNS_VisiteLogs ");
			strSql.Append(" where VisitID=?VisitID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?VisitID", MySqlDbType.Int32,4)
			};
			parameters[0].Value = VisitID;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.SNS.VisiteLogs model=new YSWL.MALL.Model.SNS.VisiteLogs();
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
		public YSWL.MALL.Model.SNS.VisiteLogs DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.SNS.VisiteLogs model=new YSWL.MALL.Model.SNS.VisiteLogs();
			if (row != null)
			{
				if(row["VisitID"]!=null && row["VisitID"].ToString()!="")
				{
					model.VisitID=int.Parse(row["VisitID"].ToString());
				}
				if(row["FromUserID"]!=null && row["FromUserID"].ToString()!="")
				{
					model.FromUserID=int.Parse(row["FromUserID"].ToString());
				}
				if(row["FromNickName"]!=null)
				{
					model.FromNickName=row["FromNickName"].ToString();
				}
				if(row["ToUserID"]!=null && row["ToUserID"].ToString()!="")
				{
					model.ToUserID=int.Parse(row["ToUserID"].ToString());
				}
				if(row["ToNickName"]!=null)
				{
					model.ToNickName=row["ToNickName"].ToString();
				}
				if(row["VisitTimes"]!=null && row["VisitTimes"].ToString()!="")
				{
					model.VisitTimes=int.Parse(row["VisitTimes"].ToString());
				}
				if(row["LastVisitTime"]!=null && row["LastVisitTime"].ToString()!="")
				{
					model.LastVisitTime=DateTime.Parse(row["LastVisitTime"].ToString());
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
			strSql.Append("select VisitID,FromUserID,FromNickName,ToUserID,ToNickName,VisitTimes,LastVisitTime ");
			strSql.Append(" FROM SNS_VisiteLogs ");
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
			strSql.Append(" VisitID,FromUserID,FromNickName,ToUserID,ToNickName,VisitTimes,LastVisitTime ");
			strSql.Append(" FROM SNS_VisiteLogs ");
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
			strSql.Append("select count(1) FROM SNS_VisiteLogs ");
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
            strSql.Append("SELECT T.* from SNS_VisiteLogs T ");
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
                strSql.Append(" order by T.VisitID desc");
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
			parameters[0].Value = "SNS_VisiteLogs";
			parameters[1].Value = "VisitID";
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

