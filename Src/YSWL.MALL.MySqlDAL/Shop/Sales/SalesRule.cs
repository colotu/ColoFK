/**
* SalesRule.cs
*
* 功 能： N/A
* 类 名： SalesRule
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/6/8 18:54:56   N/A    初版
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
using YSWL.MALL.IDAL.Shop.Sales;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Shop.Sales
{
	/// <summary>
	/// 数据访问类:SalesRule
	/// </summary>
	public partial class SalesRule:ISalesRule
	{
		public SalesRule()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("RuleId", "Shop_SalesRule"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RuleId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Shop_SalesRule");
			strSql.Append(" where RuleId=?RuleId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?RuleId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = RuleId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.Shop.Sales.SalesRule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Shop_SalesRule(");
			strSql.Append("RuleName,RuleMode,RuleUnit,Status,CreatedDate,CreatedUserID)");
			strSql.Append(" values (");
			strSql.Append("?RuleName,?RuleMode,?RuleUnit,?Status,?CreatedDate,?CreatedUserID)");
			strSql.Append(";select last_insert_id()");
			MySqlParameter[] parameters = {
					new MySqlParameter("?RuleName", MySqlDbType.VarChar,200),
					new MySqlParameter("?RuleMode", MySqlDbType.Int32,4),
					new MySqlParameter("?RuleUnit", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4)};
			parameters[0].Value = model.RuleName;
			parameters[1].Value = model.RuleMode;
			parameters[2].Value = model.RuleUnit;
			parameters[3].Value = model.Status;
			parameters[4].Value = model.CreatedDate;
			parameters[5].Value = model.CreatedUserID;

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
		public bool Update(YSWL.MALL.Model.Shop.Sales.SalesRule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Shop_SalesRule set ");
			strSql.Append("RuleName=?RuleName,");
			strSql.Append("RuleMode=?RuleMode,");
			strSql.Append("RuleUnit=?RuleUnit,");
			strSql.Append("Status=?Status,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("CreatedUserID=?CreatedUserID");
			strSql.Append(" where RuleId=?RuleId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?RuleName", MySqlDbType.VarChar,200),
					new MySqlParameter("?RuleMode", MySqlDbType.Int32,4),
					new MySqlParameter("?RuleUnit", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?RuleId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.RuleName;
			parameters[1].Value = model.RuleMode;
			parameters[2].Value = model.RuleUnit;
			parameters[3].Value = model.Status;
			parameters[4].Value = model.CreatedDate;
			parameters[5].Value = model.CreatedUserID;
			parameters[6].Value = model.RuleId;

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
		public bool Delete(int RuleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_SalesRule ");
			strSql.Append(" where RuleId=?RuleId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?RuleId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = RuleId;

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
		public bool DeleteList(string RuleIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_SalesRule ");
			strSql.Append(" where RuleId in ("+RuleIdlist + ")  ");
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
		public YSWL.MALL.Model.Shop.Sales.SalesRule GetModel(int RuleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select RuleId,RuleName,RuleMode,RuleUnit,Status,CreatedDate,CreatedUserID from Shop_SalesRule ");
			strSql.Append(" where RuleId=?RuleId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?RuleId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = RuleId;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Shop.Sales.SalesRule model=new YSWL.MALL.Model.Shop.Sales.SalesRule();
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
		public YSWL.MALL.Model.Shop.Sales.SalesRule DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Shop.Sales.SalesRule model=new YSWL.MALL.Model.Shop.Sales.SalesRule();
			if (row != null)
			{
				if(row["RuleId"]!=null && row["RuleId"].ToString()!="")
				{
					model.RuleId=int.Parse(row["RuleId"].ToString());
				}
				if(row["RuleName"]!=null)
				{
					model.RuleName=row["RuleName"].ToString();
				}
				if(row["RuleMode"]!=null && row["RuleMode"].ToString()!="")
				{
					model.RuleMode=int.Parse(row["RuleMode"].ToString());
				}
				if(row["RuleUnit"]!=null && row["RuleUnit"].ToString()!="")
				{
					model.RuleUnit=int.Parse(row["RuleUnit"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["CreatedUserID"]!=null && row["CreatedUserID"].ToString()!="")
				{
					model.CreatedUserID=int.Parse(row["CreatedUserID"].ToString());
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
			strSql.Append("select RuleId,RuleName,RuleMode,RuleUnit,Status,CreatedDate,CreatedUserID ");
			strSql.Append(" FROM Shop_SalesRule ");
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

			strSql.Append(" RuleId,RuleName,RuleMode,RuleUnit,Status,CreatedDate,CreatedUserID ");
			strSql.Append(" FROM Shop_SalesRule ");
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
			strSql.Append("select count(1) FROM Shop_SalesRule ");
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
            strSql.Append("SELECT T.* from Shop_SalesRule T ");
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
                strSql.Append(" order by T.RuleId desc");
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
			parameters[0].Value = "Shop_SalesRule";
			parameters[1].Value = "RuleId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

	    public bool DeleteEx(int RuleId)
	    {
            List<CommandInfo> sqllist = new List<CommandInfo>();

            //删除规则表数据
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Shop_SalesRule ");
            strSql.Append(" where RuleId=?RuleId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RuleId", MySqlDbType.Int32,4)};
            parameters[0].Value = RuleId;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            //删除规则项表数据
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete Shop_SalesItem ");
            strSql2.Append(" where RuleId=?RuleId ");
            MySqlParameter[] parameters2 = {
					new MySqlParameter("?RuleId", MySqlDbType.Int32,4)};
            parameters2[0].Value = RuleId;
            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            //删除用户等级中间表数据
            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("delete Shop_SalesUserRank ");
            strSql3.Append(" where  RuleId=?RuleId ");
            MySqlParameter[] parameters3 = {
					new MySqlParameter("?RuleId", MySqlDbType.Int32,4)};
            parameters3[0].Value = RuleId;
            cmd = new CommandInfo(strSql3.ToString(), parameters3);
            sqllist.Add(cmd);

            //删除商品规则中间表数据
            StringBuilder strSql4 = new StringBuilder();
            strSql4.Append("delete Shop_SalesRuleProduct ");
            strSql4.Append(" where  RuleId=?RuleId ");
            MySqlParameter[] parameters4 = {
					new MySqlParameter("?RuleId", MySqlDbType.Int32,4)};
            parameters4[0].Value = RuleId;
            cmd = new CommandInfo(strSql4.ToString(), parameters4);
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


        public bool DeleteListEx(string RuleIdlist)
	    {
            List<CommandInfo> sqllist = new List<CommandInfo>();

            //删除规则表数据
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_SalesRule ");
            strSql.Append(" where RuleId in (" + RuleIdlist + ") ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RuleIdt", MySqlDbType.Int32,4)};
            parameters[0].Value = 1;
            CommandInfo cmd = new CommandInfo(strSql.ToString(),parameters);
            sqllist.Add(cmd);

            //删除规则项表数据
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete Shop_SalesItem ");
            strSql2.Append(" where RuleId in (" + RuleIdlist + ") ");
            cmd = new CommandInfo(strSql2.ToString(), parameters);
            sqllist.Add(cmd);

            //删除用户等级中间表数据
            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("delete Shop_SalesUserRank ");
            strSql3.Append(" where RuleId in (" + RuleIdlist + ") ");
            cmd = new CommandInfo(strSql3.ToString(), parameters);
            sqllist.Add(cmd);

            //删除商品规则中间表数据
            StringBuilder strSql4 = new StringBuilder();
            strSql4.Append("delete Shop_SalesRuleProduct ");
            strSql4.Append(" where RuleId in (" + RuleIdlist + ") ");
            cmd = new CommandInfo(strSql4.ToString(), parameters);
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


        public bool UpdateStatus(int RuleId, int Status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_SalesRule set ");
            strSql.Append("Status=?Status");
            strSql.Append(" where RuleId=?RuleId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?RuleId", MySqlDbType.Int32,4)};
            parameters[0].Value = Status;
            parameters[1].Value = RuleId;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
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

