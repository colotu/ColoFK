/**
* ShippingPayment.cs
*
* 功 能： N/A
* 类 名： ShippingPayment
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/4/27 10:24:45   N/A    初版
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
using YSWL.MALL.IDAL.Shop.Shipping;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Shop.Shipping
{
	/// <summary>
	/// 数据访问类:ShippingPayment
	/// </summary>
	public partial class ShippingPayment:IShippingPayment
	{
		public ShippingPayment()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ShippingModeId", "Shop_ShippingPayment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ShippingModeId,int PaymentModeId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Shop_ShippingPayment");
			strSql.Append(" where ShippingModeId=?ShippingModeId and PaymentModeId=?PaymentModeId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ShippingModeId", MySqlDbType.Int32,4),
					new MySqlParameter("?PaymentModeId", MySqlDbType.Int32,4)			};
			parameters[0].Value = ShippingModeId;
			parameters[1].Value = PaymentModeId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(YSWL.MALL.Model.Shop.Shipping.ShippingPayment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Shop_ShippingPayment(");
			strSql.Append("ShippingModeId,PaymentModeId)");
			strSql.Append(" values (");
			strSql.Append("?ShippingModeId,?PaymentModeId)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ShippingModeId", MySqlDbType.Int32,4),
					new MySqlParameter("?PaymentModeId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.ShippingModeId;
			parameters[1].Value = model.PaymentModeId;

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
		public bool Update(YSWL.MALL.Model.Shop.Shipping.ShippingPayment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Shop_ShippingPayment set ");
			strSql.Append("ShippingModeId=?ShippingModeId,");
			strSql.Append("PaymentModeId=?PaymentModeId");
			strSql.Append(" where ShippingModeId=?ShippingModeId and PaymentModeId=?PaymentModeId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ShippingModeId", MySqlDbType.Int32,4),
					new MySqlParameter("?PaymentModeId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.ShippingModeId;
			parameters[1].Value = model.PaymentModeId;

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
		public bool Delete(int ShippingModeId,int PaymentModeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_ShippingPayment ");
			strSql.Append(" where ShippingModeId=?ShippingModeId and PaymentModeId=?PaymentModeId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ShippingModeId", MySqlDbType.Int32,4),
					new MySqlParameter("?PaymentModeId", MySqlDbType.Int32,4)			};
			parameters[0].Value = ShippingModeId;
			parameters[1].Value = PaymentModeId;

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
		/// 得到一个对象实体
		/// </summary>
		public YSWL.MALL.Model.Shop.Shipping.ShippingPayment GetModel(int ShippingModeId,int PaymentModeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ShippingModeId,PaymentModeId from Shop_ShippingPayment ");
			strSql.Append(" where ShippingModeId=?ShippingModeId and PaymentModeId=?PaymentModeId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ShippingModeId", MySqlDbType.Int32,4),
					new MySqlParameter("?PaymentModeId", MySqlDbType.Int32,4)			};
			parameters[0].Value = ShippingModeId;
			parameters[1].Value = PaymentModeId;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Shop.Shipping.ShippingPayment model=new YSWL.MALL.Model.Shop.Shipping.ShippingPayment();
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
		public YSWL.MALL.Model.Shop.Shipping.ShippingPayment DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Shop.Shipping.ShippingPayment model=new YSWL.MALL.Model.Shop.Shipping.ShippingPayment();
			if (row != null)
			{
				if(row["ShippingModeId"]!=null && row["ShippingModeId"].ToString()!="")
				{
					model.ShippingModeId=int.Parse(row["ShippingModeId"].ToString());
				}
				if(row["PaymentModeId"]!=null && row["PaymentModeId"].ToString()!="")
				{
					model.PaymentModeId=int.Parse(row["PaymentModeId"].ToString());
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
			strSql.Append("select ShippingModeId,PaymentModeId ");
			strSql.Append(" FROM Shop_ShippingPayment ");
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

			strSql.Append(" ShippingModeId,PaymentModeId ");
			strSql.Append(" FROM Shop_ShippingPayment ");
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
			strSql.Append("select count(1) FROM Shop_ShippingPayment ");
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
            strSql.Append("SELECT T.* from Shop_ShippingPayment T ");
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
                strSql.Append(" order by T.PaymentModeId desc");
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
			parameters[0].Value = "Shop_ShippingPayment";
			parameters[1].Value = "PaymentModeId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

	    public bool Delete(int modeId)
	    {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_ShippingPayment ");
            strSql.Append(" where ShippingModeId=?ShippingModeId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ShippingModeId", MySqlDbType.Int32,4)		};
            parameters[0].Value = modeId;

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

