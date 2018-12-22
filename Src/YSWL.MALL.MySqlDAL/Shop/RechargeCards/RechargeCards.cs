/**  版本信息模板在安装目录下，可自行修改。
* RechargeCards.cs
*
* 功 能： N/A
* 类 名： RechargeCards
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/9/17 14:27:59   N/A    初版
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
using YSWL.MALL.IDAL.Shop;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Shop
{
	/// <summary>
	/// 数据访问类:RechargeCards
	/// </summary>
	public partial class RechargeCards:IRechargeCards
	{
		public RechargeCards()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ID", "Shop_RechargeCards"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Shop_RechargeCards");
			strSql.Append(" where ID=?ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ID;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.Shop.RechargeCards model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Shop_RechargeCards(");
			strSql.Append("Number,Password,Amount,CreatedUserId,CreatedDate,UsedUserId,UsedDate,Status,Remark)");
			strSql.Append(" values (");
			strSql.Append("?Number,?Password,?Amount,?CreatedUserId,?CreatedDate,?UsedUserId,?UsedDate,?Status,?Remark)");
			strSql.Append(";select last_insert_id()");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Number", MySqlDbType.VarChar,200),
					new MySqlParameter("?Password", MySqlDbType.VarChar,50),
					new MySqlParameter("?Amount", MySqlDbType.Decimal,8),
					new MySqlParameter("?CreatedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?UsedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?UsedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,200)};
			parameters[0].Value = model.Number;
			parameters[1].Value = model.Password;
			parameters[2].Value = model.Amount;
			parameters[3].Value = model.CreatedUserId;
			parameters[4].Value = model.CreatedDate;
			parameters[5].Value = model.UsedUserId;
			parameters[6].Value = model.UsedDate;
			parameters[7].Value = model.Status;
			parameters[8].Value = model.Remark;

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
		public bool Update(YSWL.MALL.Model.Shop.RechargeCards model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Shop_RechargeCards set ");
			strSql.Append("Number=?Number,");
			strSql.Append("Password=?Password,");
			strSql.Append("Amount=?Amount,");
			strSql.Append("CreatedUserId=?CreatedUserId,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("UsedUserId=?UsedUserId,");
			strSql.Append("UsedDate=?UsedDate,");
			strSql.Append("Status=?Status,");
			strSql.Append("Remark=?Remark");
			strSql.Append(" where ID=?ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Number", MySqlDbType.VarChar,200),
					new MySqlParameter("?Password", MySqlDbType.VarChar,50),
					new MySqlParameter("?Amount", MySqlDbType.Decimal,8),
					new MySqlParameter("?CreatedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?UsedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?UsedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,200),
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
			parameters[0].Value = model.Number;
			parameters[1].Value = model.Password;
			parameters[2].Value = model.Amount;
			parameters[3].Value = model.CreatedUserId;
			parameters[4].Value = model.CreatedDate;
			parameters[5].Value = model.UsedUserId;
			parameters[6].Value = model.UsedDate;
			parameters[7].Value = model.Status;
			parameters[8].Value = model.Remark;
			parameters[9].Value = model.ID;

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
			strSql.Append("delete from Shop_RechargeCards ");
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
			strSql.Append("delete from Shop_RechargeCards ");
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
		public YSWL.MALL.Model.Shop.RechargeCards GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Number,Password,Amount,CreatedUserId,CreatedDate,UsedUserId,UsedDate,Status,Remark from Shop_RechargeCards ");
			strSql.Append(" where ID=?ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ID;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Shop.RechargeCards model=new YSWL.MALL.Model.Shop.RechargeCards();
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
		public YSWL.MALL.Model.Shop.RechargeCards DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Shop.RechargeCards model=new YSWL.MALL.Model.Shop.RechargeCards();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["Number"]!=null)
				{
					model.Number=row["Number"].ToString();
				}
				if(row["Password"]!=null)
				{
					model.Password=row["Password"].ToString();
				}
				if(row["Amount"]!=null && row["Amount"].ToString()!="")
				{
					model.Amount=decimal.Parse(row["Amount"].ToString());
				}
				if(row["CreatedUserId"]!=null && row["CreatedUserId"].ToString()!="")
				{
					model.CreatedUserId=int.Parse(row["CreatedUserId"].ToString());
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["UsedUserId"]!=null && row["UsedUserId"].ToString()!="")
				{
					model.UsedUserId=int.Parse(row["UsedUserId"].ToString());
				}
				if(row["UsedDate"]!=null && row["UsedDate"].ToString()!="")
				{
					model.UsedDate=DateTime.Parse(row["UsedDate"].ToString());
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
			strSql.Append("select ID,Number,Password,Amount,CreatedUserId,CreatedDate,UsedUserId,UsedDate,Status,Remark ");
			strSql.Append(" FROM Shop_RechargeCards ");
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

			strSql.Append(" ID,Number,Password,Amount,CreatedUserId,CreatedDate,UsedUserId,UsedDate,Status,Remark ");
			strSql.Append(" FROM Shop_RechargeCards ");
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
			strSql.Append("select count(1) FROM Shop_RechargeCards ");
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
            strSql.Append("SELECT T.* from Shop_RechargeCards T ");
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
                strSql.Append(" order by T.ID desc");
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
			parameters[0].Value = "Shop_RechargeCards";
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
        public YSWL.MALL.Model.Shop.RechargeCards ExitEx(string number)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Shop_RechargeCards");
            strSql.Append(" where Number=?Num");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Num", MySqlDbType.VarChar,200)
			};
            parameters[0].Value =number;
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
		#endregion  ExtensionMethod
	}
}

