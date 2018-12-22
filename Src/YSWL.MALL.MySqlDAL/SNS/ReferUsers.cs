/**
* ReferUsers.cs
*
* 功 能： N/A
* 类 名： ReferUsers
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/9/12 20:14:51   N/A    初版
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
	/// 数据访问类:ReferUsers
	/// </summary>
	public partial class ReferUsers:IReferUsers
	{
		public ReferUsers()
		{}
		#region  BasicMethod

		

		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.SNS.ReferUsers model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SNS_ReferUsers(");
			strSql.Append("TagetID,Type,ReferUserID,ReferNickName,CreatedDate,IsRead)");
			strSql.Append(" values (");
			strSql.Append("?TagetID,?Type,?ReferUserID,?ReferNickName,?CreatedDate,?IsRead)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TagetID", MySqlDbType.Int32,4),
					new MySqlParameter("?Type", MySqlDbType.Int32,4),
					new MySqlParameter("?ReferUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?ReferNickName", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?IsRead", MySqlDbType.Bit,1)};
			parameters[0].Value = model.TagetID;
			parameters[1].Value = model.Type;
			parameters[2].Value = model.ReferUserID;
			parameters[3].Value = model.ReferNickName;
			parameters[4].Value = model.CreatedDate;
			parameters[5].Value = model.IsRead;

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
		public bool Update(YSWL.MALL.Model.SNS.ReferUsers model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SNS_ReferUsers set ");
			strSql.Append("TagetID=?TagetID,");
			strSql.Append("Type=?Type,");
			strSql.Append("ReferUserID=?ReferUserID,");
			strSql.Append("ReferNickName=?ReferNickName,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("IsRead=?IsRead");
			strSql.Append(" where ID=?ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TagetID", MySqlDbType.Int32,4),
					new MySqlParameter("?Type", MySqlDbType.Int32,4),
					new MySqlParameter("?ReferUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?ReferNickName", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?IsRead", MySqlDbType.Bit,1),
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
			parameters[0].Value = model.TagetID;
			parameters[1].Value = model.Type;
			parameters[2].Value = model.ReferUserID;
			parameters[3].Value = model.ReferNickName;
			parameters[4].Value = model.CreatedDate;
			parameters[5].Value = model.IsRead;
			parameters[6].Value = model.ID;

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
			strSql.Append("delete from SNS_ReferUsers ");
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SNS_ReferUsers ");
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
		public YSWL.MALL.Model.SNS.ReferUsers GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,TagetID,Type,ReferUserID,ReferNickName,CreatedDate,IsRead from SNS_ReferUsers ");
            strSql.Append(" where ID=?ID LIMIT 1 ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ID;

			YSWL.MALL.Model.SNS.ReferUsers model=new YSWL.MALL.Model.SNS.ReferUsers();
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
		public YSWL.MALL.Model.SNS.ReferUsers DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.SNS.ReferUsers model=new YSWL.MALL.Model.SNS.ReferUsers();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["TagetID"]!=null && row["TagetID"].ToString()!="")
				{
					model.TagetID=int.Parse(row["TagetID"].ToString());
				}
				if(row["Type"]!=null && row["Type"].ToString()!="")
				{
					model.Type=int.Parse(row["Type"].ToString());
				}
				if(row["ReferUserID"]!=null && row["ReferUserID"].ToString()!="")
				{
					model.ReferUserID=int.Parse(row["ReferUserID"].ToString());
				}
				if(row["ReferNickName"]!=null)
				{
					model.ReferNickName=row["ReferNickName"].ToString();
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["IsRead"]!=null && row["IsRead"].ToString()!="")
				{
					if((row["IsRead"].ToString()=="1")||(row["IsRead"].ToString().ToLower()=="true"))
					{
						model.IsRead=true;
					}
					else
					{
						model.IsRead=false;
					}
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
			strSql.Append("select ID,TagetID,Type,ReferUserID,ReferNickName,CreatedDate,IsRead ");
			strSql.Append(" FROM SNS_ReferUsers ");
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
			
			strSql.Append(" ID,TagetID,Type,ReferUserID,ReferNickName,CreatedDate,IsRead ");
			strSql.Append(" FROM SNS_ReferUsers ");
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
			strSql.Append("select count(1) FROM SNS_ReferUsers ");
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
			strSql.Append(")AS Row, T.*  from SNS_ReferUsers T ");
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
			parameters[0].Value = "SNS_ReferUsers";
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
        /// <summary>
        /// 更新状态为已经知道
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public bool UpdateReferStateToRead(int UserID, int Type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SNS_ReferUsers set ");
            strSql.Append("IsRead='True'");
            strSql.Append(" where ReferUserID="+UserID+" and Type="+Type+"");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetReferNotReadCountByType(int UserId,int Type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM SNS_ReferUsers ");
            if (UserId>0)
            {
                strSql.Append("where ReferUserID="+UserId+" and Type="+Type+" and IsRead='False'");
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
		#endregion  ExtensionMethod
	}
}

