/**  版本信息模板在安装目录下，可自行修改。
* UserCard.cs
*
* 功 能： N/A
* 类 名： UserCard
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/17 19:10:22   N/A    初版
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
using YSWL.MALL.IDAL.Members;
using YSWL.DBUtility;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Members
{
	/// <summary>
	/// 数据访问类:UserCard
	/// </summary>
	public partial class UserCard:IUserCard
	{
		public UserCard()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CardCode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Accounts_UserCard");
			strSql.Append(" where CardCode=?CardCode ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CardCode", MySqlDbType.VarChar,50)			};
			parameters[0].Value = CardCode;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(YSWL.MALL.Model.Members.UserCard model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Accounts_UserCard(");
			strSql.Append("CardCode,CardPwd,CardValue,UserId,Status,Type,EndDate,CreatedDate,Remark)");
			strSql.Append(" values (");
			strSql.Append("?CardCode,?CardPwd,?CardValue,?UserId,?Status,?Type,?EndDate,?CreatedDate,?Remark)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CardCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?CardPwd", MySqlDbType.VarChar,50),
					new MySqlParameter("?CardValue", MySqlDbType.Decimal,9),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?Type", MySqlDbType.Int32,4),
					new MySqlParameter("?EndDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,-1)};
			parameters[0].Value = model.CardCode;
			parameters[1].Value = model.CardPwd;
			parameters[2].Value = model.CardValue;
			parameters[3].Value = model.UserId;
			parameters[4].Value = model.Status;
			parameters[5].Value = model.Type;
			parameters[6].Value = model.EndDate;
			parameters[7].Value = model.CreatedDate;
			parameters[8].Value = model.Remark;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(YSWL.MALL.Model.Members.UserCard model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Accounts_UserCard set ");
			strSql.Append("CardPwd=?CardPwd,");
			strSql.Append("CardValue=?CardValue,");
			strSql.Append("UserId=?UserId,");
			strSql.Append("Status=?Status,");
			strSql.Append("Type=?Type,");
			strSql.Append("EndDate=?EndDate,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("Remark=?Remark");
			strSql.Append(" where CardCode=?CardCode ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CardPwd", MySqlDbType.VarChar,50),
					new MySqlParameter("?CardValue", MySqlDbType.Decimal,9),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?Type", MySqlDbType.Int32,4),
					new MySqlParameter("?EndDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,-1),
					new MySqlParameter("?CardCode", MySqlDbType.VarChar,50)};
			parameters[0].Value = model.CardPwd;
			parameters[1].Value = model.CardValue;
			parameters[2].Value = model.UserId;
			parameters[3].Value = model.Status;
			parameters[4].Value = model.Type;
			parameters[5].Value = model.EndDate;
			parameters[6].Value = model.CreatedDate;
			parameters[7].Value = model.Remark;
			parameters[8].Value = model.CardCode;

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
		public bool Delete(string CardCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Accounts_UserCard ");
			strSql.Append(" where CardCode=?CardCode ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CardCode", MySqlDbType.VarChar,50)			};
			parameters[0].Value = CardCode;

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
		public bool DeleteList(string CardCodelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Accounts_UserCard ");
			strSql.Append(" where CardCode in ('"+CardCodelist + "')  ");
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
		public YSWL.MALL.Model.Members.UserCard GetModel(string CardCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CardCode,CardPwd,CardValue,UserId,Status,Type,EndDate,CreatedDate,Remark from Accounts_UserCard ");
			strSql.Append(" where CardCode=?CardCode ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CardCode", MySqlDbType.VarChar,50)			};
			parameters[0].Value = CardCode;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Members.UserCard model=new YSWL.MALL.Model.Members.UserCard();
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
		public YSWL.MALL.Model.Members.UserCard DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Members.UserCard model=new YSWL.MALL.Model.Members.UserCard();
			if (row != null)
			{
				if(row["CardCode"]!=null)
				{
					model.CardCode=row["CardCode"].ToString();
				}
				if(row["CardPwd"]!=null)
				{
					model.CardPwd=row["CardPwd"].ToString();
				}
				if(row["CardValue"]!=null && row["CardValue"].ToString()!="")
				{
					model.CardValue=decimal.Parse(row["CardValue"].ToString());
				}
				if(row["UserId"]!=null && row["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(row["UserId"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["Type"]!=null && row["Type"].ToString()!="")
				{
					model.Type=int.Parse(row["Type"].ToString());
				}
				if(row["EndDate"]!=null && row["EndDate"].ToString()!="")
				{
					model.EndDate=DateTime.Parse(row["EndDate"].ToString());
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
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
			strSql.Append("select CardCode,CardPwd,CardValue,UserId,Status,Type,EndDate,CreatedDate,Remark ");
			strSql.Append(" FROM Accounts_UserCard ");
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
			
			strSql.Append(" CardCode,CardPwd,CardValue,UserId,Status,Type,EndDate,CreatedDate,Remark ");
			strSql.Append(" FROM Accounts_UserCard ");
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
			strSql.Append("select count(1) FROM Accounts_UserCard ");
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
            strSql.Append("SELECT T.* from Accounts_UserCard T ");
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
                strSql.Append(" order by T.CardCode desc");
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
			parameters[0].Value = "Accounts_UserCard";
			parameters[1].Value = "CardCode";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
       public bool AddCard(YSWL.MALL.Model.Members.UserCard model)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_UserCard(");
            strSql.Append("CardCode,CardPwd,CardValue,UserId,Status,Type,EndDate,CreatedDate,Remark)");
            strSql.Append(" values (");
            strSql.Append("?CardCode,?CardPwd,?CardValue,?UserId,?Status,?Type,?EndDate,?CreatedDate,?Remark)");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CardCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?CardPwd", MySqlDbType.VarChar,50),
					new MySqlParameter("?CardValue", MySqlDbType.Decimal,9),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?Type", MySqlDbType.Int32,4),
					new MySqlParameter("?EndDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,-1)};
            parameters[0].Value = model.CardCode;
            parameters[1].Value = model.CardPwd;
            parameters[2].Value = model.CardValue;
            parameters[3].Value = model.UserId;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.Type;
            parameters[6].Value = model.EndDate;
            parameters[7].Value = model.CreatedDate;
            parameters[8].Value = model.Remark;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("Update Accounts_UsersExp set  UserCardCode=?UserCardCode,UserCardType=?UserCardType");
            strSql2.Append(" where UserID=?UserID");
            MySqlParameter[] parameters2 = {
					new MySqlParameter("?UserCardCode", MySqlDbType.VarChar,50),
                    	new MySqlParameter("?UserCardType", MySqlDbType.Int16),
                        	new MySqlParameter("?UserID", MySqlDbType.Int32)
                                         };
            parameters2[0].Value = model.CardCode;
            parameters2[1].Value = model.Type;
            parameters2[2].Value = model.UserId;
            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            

            int rowsAffected = DbHelperMySQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       public bool DeleteEx(string CardCode)
       {
           List<CommandInfo> sqllist = new List<CommandInfo>();
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from Accounts_UserCard ");
           strSql.Append(" where CardCode=?CardCode ");
           MySqlParameter[] parameters = {
					new MySqlParameter("?CardCode", MySqlDbType.VarChar,50)			};
           parameters[0].Value = CardCode;
           CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
           sqllist.Add(cmd);

           StringBuilder strSql2 = new StringBuilder();
           strSql2.Append("Update Accounts_UsersExp set  UserCardCode='',UserCardType=-1");
           strSql2.Append(" where UserCardCode=?CardCode");
           MySqlParameter[] parameters2 = {
				new MySqlParameter("?CardCode", MySqlDbType.VarChar,50)			};
           parameters2[0].Value = CardCode;
           cmd = new CommandInfo(strSql2.ToString(), parameters2);
           sqllist.Add(cmd);

           int rowsAffected = DbHelperMySQL.ExecuteSqlTran(sqllist);
           if (rowsAffected > 0)
           {
               return true;
           }
           else
           {
               return false;
           }
       }
		#endregion  ExtensionMethod
	}
}

