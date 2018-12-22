/**  
* salepackingbilldetail.cs
*
* 功 能： N/A
* 类 名： salepackingbilldetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/14 14:54:38   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using YSWL.IDAL.ERP.SalePackingBill;
using MySql.Data.MySqlClient;
using YSWL.IDAL;
using YSWL.DBUtility;//Please add references
namespace YSWL.MySqlDAL.ERP.SalePackingBill
{
	/// <summary>
	/// 数据访问类:salepackingbilldetail
	/// </summary>
    public partial class SalePackingBillDetail : ISalePackingBillDetail
	{
        public SalePackingBillDetail()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from salepackingbilldetail");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64)
			};
			parameters[0].Value = id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(YSWL.Model.ERP.SalePackingBill.SalePackingBillDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into salepackingbilldetail(");
			strSql.Append("billCode,money,orderBCode,ordinal,pieceQty,profit,scatteredQty,bill_id,orderBId,orderBType,billVolume,billWeight,outInMoney,receiveMoney,saleMoney)");
			strSql.Append(" values (");
			strSql.Append("?billCode,?money,?orderBCode,?ordinal,?pieceQty,?profit,?scatteredQty,?bill_id,?orderBId,?orderBType,?billVolume,?billWeight,?outInMoney,?receiveMoney,?saleMoney)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?billCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?money", MySqlDbType.Double),
					new MySqlParameter("?orderBCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?ordinal", MySqlDbType.Int32,11),
					new MySqlParameter("?pieceQty", MySqlDbType.Int32,11),
					new MySqlParameter("?profit", MySqlDbType.Double),
					new MySqlParameter("?scatteredQty", MySqlDbType.Int32,11),
					new MySqlParameter("?bill_id", MySqlDbType.Int64,20),
					new MySqlParameter("?orderBId", MySqlDbType.Int64,20),
					new MySqlParameter("?orderBType", MySqlDbType.VarChar,3),
					new MySqlParameter("?billVolume", MySqlDbType.Double),
					new MySqlParameter("?billWeight", MySqlDbType.Int32,11),
					new MySqlParameter("?outInMoney", MySqlDbType.Double),
					new MySqlParameter("?receiveMoney", MySqlDbType.Double),
					new MySqlParameter("?saleMoney", MySqlDbType.Double)};
			parameters[0].Value = model.billCode;
			parameters[1].Value = model.money;
			parameters[2].Value = model.orderBCode;
			parameters[3].Value = model.ordinal;
			parameters[4].Value = model.pieceQty;
			parameters[5].Value = model.profit;
			parameters[6].Value = model.scatteredQty;
			parameters[7].Value = model.bill_id;
			parameters[8].Value = model.orderBId;
			parameters[9].Value = model.orderBType;
			parameters[10].Value = model.billVolume;
			parameters[11].Value = model.billWeight;
			parameters[12].Value = model.outInMoney;
			parameters[13].Value = model.receiveMoney;
			parameters[14].Value = model.saleMoney;

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
		public bool Update(YSWL.Model.ERP.SalePackingBill.SalePackingBillDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update salepackingbilldetail set ");
			strSql.Append("billCode=?billCode,");
			strSql.Append("money=?money,");
			strSql.Append("orderBCode=?orderBCode,");
			strSql.Append("ordinal=?ordinal,");
			strSql.Append("pieceQty=?pieceQty,");
			strSql.Append("profit=?profit,");
			strSql.Append("scatteredQty=?scatteredQty,");
			strSql.Append("bill_id=?bill_id,");
			strSql.Append("orderBId=?orderBId,");
			strSql.Append("orderBType=?orderBType,");
			strSql.Append("billVolume=?billVolume,");
			strSql.Append("billWeight=?billWeight,");
			strSql.Append("outInMoney=?outInMoney,");
			strSql.Append("receiveMoney=?receiveMoney,");
			strSql.Append("saleMoney=?saleMoney");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?billCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?money", MySqlDbType.Double),
					new MySqlParameter("?orderBCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?ordinal", MySqlDbType.Int32,11),
					new MySqlParameter("?pieceQty", MySqlDbType.Int32,11),
					new MySqlParameter("?profit", MySqlDbType.Double),
					new MySqlParameter("?scatteredQty", MySqlDbType.Int32,11),
					new MySqlParameter("?bill_id", MySqlDbType.Int64,20),
					new MySqlParameter("?orderBId", MySqlDbType.Int64,20),
					new MySqlParameter("?orderBType", MySqlDbType.VarChar,3),
					new MySqlParameter("?billVolume", MySqlDbType.Double),
					new MySqlParameter("?billWeight", MySqlDbType.Int32,11),
					new MySqlParameter("?outInMoney", MySqlDbType.Double),
					new MySqlParameter("?receiveMoney", MySqlDbType.Double),
					new MySqlParameter("?saleMoney", MySqlDbType.Double),
					new MySqlParameter("?id", MySqlDbType.Int64,20)};
			parameters[0].Value = model.billCode;
			parameters[1].Value = model.money;
			parameters[2].Value = model.orderBCode;
			parameters[3].Value = model.ordinal;
			parameters[4].Value = model.pieceQty;
			parameters[5].Value = model.profit;
			parameters[6].Value = model.scatteredQty;
			parameters[7].Value = model.bill_id;
			parameters[8].Value = model.orderBId;
			parameters[9].Value = model.orderBType;
			parameters[10].Value = model.billVolume;
			parameters[11].Value = model.billWeight;
			parameters[12].Value = model.outInMoney;
			parameters[13].Value = model.receiveMoney;
			parameters[14].Value = model.saleMoney;
			parameters[15].Value = model.id;

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
		public bool Delete(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from salepackingbilldetail ");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64)
			};
			parameters[0].Value = id;

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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from salepackingbilldetail ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public YSWL.Model.ERP.SalePackingBill.SalePackingBillDetail GetModel(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,billCode,money,orderBCode,ordinal,pieceQty,profit,scatteredQty,bill_id,orderBId,orderBType,billVolume,billWeight,outInMoney,receiveMoney,saleMoney from salepackingbilldetail ");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64)
			};
			parameters[0].Value = id;
		 
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
		public YSWL.Model.ERP.SalePackingBill.SalePackingBillDetail DataRowToModel(DataRow row)
		{
			YSWL.Model.ERP.SalePackingBill.SalePackingBillDetail model=new YSWL.Model.ERP.SalePackingBill.SalePackingBillDetail();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=long.Parse(row["id"].ToString());
				}
				if(row["billCode"]!=null)
				{
					model.billCode=row["billCode"].ToString();
				}
					//model.money=row["money"].ToString();
				if(row["orderBCode"]!=null)
				{
					model.orderBCode=row["orderBCode"].ToString();
				}
				if(row["ordinal"]!=null && row["ordinal"].ToString()!="")
				{
					model.ordinal=int.Parse(row["ordinal"].ToString());
				}
				if(row["pieceQty"]!=null && row["pieceQty"].ToString()!="")
				{
					model.pieceQty=int.Parse(row["pieceQty"].ToString());
				}
					//model.profit=row["profit"].ToString();
				if(row["scatteredQty"]!=null && row["scatteredQty"].ToString()!="")
				{
					model.scatteredQty=int.Parse(row["scatteredQty"].ToString());
				}
				if(row["bill_id"]!=null && row["bill_id"].ToString()!="")
				{
					model.bill_id=long.Parse(row["bill_id"].ToString());
				}
				if(row["orderBId"]!=null && row["orderBId"].ToString()!="")
				{
					model.orderBId=long.Parse(row["orderBId"].ToString());
				}
				if(row["orderBType"]!=null)
				{
					model.orderBType=row["orderBType"].ToString();
				}
					//model.billVolume=row["billVolume"].ToString();
				if(row["billWeight"]!=null && row["billWeight"].ToString()!="")
				{
					model.billWeight=int.Parse(row["billWeight"].ToString());
				}
					//model.outInMoney=row["outInMoney"].ToString();
					//model.receiveMoney=row["receiveMoney"].ToString();
					//model.saleMoney=row["saleMoney"].ToString();
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,billCode,money,orderBCode,ordinal,pieceQty,profit,scatteredQty,bill_id,orderBId,orderBType,billVolume,billWeight,outInMoney,receiveMoney,saleMoney ");
			strSql.Append(" FROM salepackingbilldetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}
 
		#endregion  BasicMethod
		#region  ExtensionMethod
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM salepackingbilldetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
        ///  分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="skipsCount">跳过条数</param>
        /// <param name="pageSize">个数</param>
        /// <returns></returns>
        public DataSet GetListByPage(string strWhere, string orderby, int skipsCount, int pageSize)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select * from salepackingbilldetail ");
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                strSql.AppendFormat(" where {0} ", strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by " + orderby);
            }
            strSql.AppendFormat("  limit {0}, {1}  ", skipsCount , pageSize);
            return DbHelperMySQL.Query(strSql.ToString());
        }
        /// <summary>
        ///  获取装箱单数据列表
        /// </summary>
        /// <param name="id">装箱单id</param>
        /// <returns></returns>
        public DataSet GetPackDetailList(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select b.id id, b.ordinal ordinal  ,b.orderBCode orderBCode ,c.`name` name,b.pieceQty pieceQty,b.scatteredQty scatteredQty,d.makeDate makeDate,d.salesman salesman,b.money money,b.profit profit ,b.billWeight billWeight,b.billVolume billVolume,b.saleMoney saleMoney,b.outInMoney outInMoney,b.receiveMoney receiveMoney");
            strSql.Append(
                " from salepackingbilldetail b  INNER JOIN  saleorderbill d  on b.orderBCode=d.billCode INNER JOIN  enterpriseinfo c on  c.id=d.ent_id ");
            strSql.AppendFormat(" where b.bill_id='{0}' ",id);
            //strSql.Append(" from salepackingbilldetail b,enterpriseinfo c,saleorderbill d ");
            //strSql.AppendFormat(" where b.orderBCode=d.billCode and c.id=d.ent_id and b.bill_id='{0}' ", id);  //b.billcode='BZX00027701'
            strSql.Append("  ORDER BY b.ordinal ");
            return DbHelperMySQL.Query(strSql.ToString());
        }
        /// <summary>
        ///  分页获取数据列表
        /// </summary>
        /// <param name="id">装箱单id</param>
        /// <param name="skipsCount">跳过条数</param>
        /// <param name="pageSize">个数</param>
        /// <returns></returns>
        public DataSet GetPackDetailList(long  id, int skipsCount, int pageSize)
	    {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select b.ordinal ordinal  ,b.orderBCode orderBCode ,c.`name` name,b.pieceQty pieceQty,b.scatteredQty scatteredQty,d.makeDate makeDate,d.salesman salesman,b.money money,b.profit profit ");
            strSql.Append(
              " from salepackingbilldetail b  INNER JOIN  saleorderbill d  on b.orderBCode=d.billCode INNER JOIN  enterpriseinfo c on  c.id=d.ent_id ");
            strSql.AppendFormat(" where b.bill_id='{0}' ", id);
            //strSql.Append(" from salepackingbilldetail b,enterpriseinfo c,saleorderbill d ");
            //strSql.AppendFormat(" where b.orderBCode=d.billCode and c.id=d.ent_id and b.bill_id='{0}' ", id);  //b.billcode='BZX00027701'
            strSql.Append("  ORDER BY b.ordinal ");   
            strSql.AppendFormat("  limit {0}, {1}  ", skipsCount, pageSize);
            return DbHelperMySQL.Query(strSql.ToString());
	    }
        
 
        /// <summary>
        /// 获得装箱单数据汇总
        /// </summary>
        /// <param name="id">装箱单id</param>
        /// <returns></returns>
        public DataSet GetTotal(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  count(*) as toalCount , sum(money) as moneyTotal ,sum(pieceQty) as pieceQtyTotal , sum(scatteredQty) as scatQtyTotal,sum(profit) as profitTotal from salepackingbilldetail ");
            strSql.AppendFormat("   where  bill_id='{0}' ",id);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        ///  根据装箱单Id获取订单Ids
        /// </summary>
        /// <param name="id">装箱单id</param>
        /// <returns></returns>
        public DataSet GetIdsBySPBId(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderBId from salepackingbilldetail ");
            strSql.AppendFormat(" where  bill_id='{0}' ", id);
            return DbHelperMySQL.Query(strSql.ToString());           
        }
        #endregion  ExtensionMethod
	}
}

