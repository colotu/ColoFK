/**  版本信息模板在安装目录下，可自行修改。
* saleorderbill.cs
*
* 功 能： N/A
* 类 名： saleorderbill
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/15 11:30:17   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using YSWL.IDAL.ERP.Order;
using YSWL.Model.ERP.Products;
using MySql.Data.MySqlClient;
using YSWL.IDAL;
using YSWL.DBUtility;//Please add references
namespace YSWL.MySqlDAL.CDP.Order
{
	/// <summary>
	/// 数据访问类:saleorderbill
	/// </summary>
	public partial class SaleOrderBill:ISaleOrderBill
	{
        public SaleOrderBill()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from saleorderbill");
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
		public bool Add(YSWL.Model.ERP.Order.SaleOrderBill model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into saleorderbill(");
			strSql.Append("RBillCode,RBillId,backFlag,billCode,billMoney,billType,blProxy,chequeNum,contractNum,deliver,deliverCount,driver,exhibitDate,flowFlag,invoiceNum,lockName,makeDate,makeType,oldBillCode,oldBillId,operator,orderType,outInMoney,prizeBillId,remarks,salesman,trafficNum,vehCode,ent_id,sys_dep_id,blPrint,returnCause,packingDetail_id,kokura_id,makeTime,netOrder_id,deliverPerCount,blBorrow,borrowStatus,prizeBillCode,saleMoney,srcFlag,orderId,orderCode,lastPreReceiveBalance,lastPreReceiveValidBalance,lastReceivable,lastpromiseReceivable,settlementType,billVolume,billWeight,receiveMoney,returnOrderBillCode,returnOrderBillId,returnStoreBillCode,returnStoreBillId,operator_id,salesman_id)");
			strSql.Append(" values (");
			strSql.Append("?RBillCode,?RBillId,?backFlag,?billCode,?billMoney,?billType,?blProxy,?chequeNum,?contractNum,?deliver,?deliverCount,?driver,?exhibitDate,?flowFlag,?invoiceNum,?lockName,?makeDate,?makeType,?oldBillCode,?oldBillId,?operator,?orderType,?outInMoney,?prizeBillId,?remarks,?salesman,?trafficNum,?vehCode,?ent_id,?sys_dep_id,?blPrint,?returnCause,?packingDetail_id,?kokura_id,?makeTime,?netOrder_id,?deliverPerCount,?blBorrow,?borrowStatus,?prizeBillCode,?saleMoney,?srcFlag,?orderId,?orderCode,?lastPreReceiveBalance,?lastPreReceiveValidBalance,?lastReceivable,?lastpromiseReceivable,?settlementType,?billVolume,?billWeight,?receiveMoney,?returnOrderBillCode,?returnOrderBillId,?returnStoreBillCode,?returnStoreBillId,?operator_id,?salesman_id)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?RBillCode", MySqlDbType.VarChar,255),
					new MySqlParameter("?RBillId", MySqlDbType.Int64,20),
					new MySqlParameter("?backFlag", MySqlDbType.Bit),
					new MySqlParameter("?billCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?billMoney", MySqlDbType.Double),
					new MySqlParameter("?billType", MySqlDbType.VarChar,3),
					new MySqlParameter("?blProxy", MySqlDbType.Bit),
					new MySqlParameter("?chequeNum", MySqlDbType.VarChar,80),
					new MySqlParameter("?contractNum", MySqlDbType.VarChar,80),
					new MySqlParameter("?deliver", MySqlDbType.VarChar,100),
					new MySqlParameter("?deliverCount", MySqlDbType.Int32,11),
					new MySqlParameter("?driver", MySqlDbType.VarChar,30),
					new MySqlParameter("?exhibitDate", MySqlDbType.Date),
					new MySqlParameter("?flowFlag", MySqlDbType.Int32,11),
					new MySqlParameter("?invoiceNum", MySqlDbType.VarChar,80),
					new MySqlParameter("?lockName", MySqlDbType.VarChar,30),
					new MySqlParameter("?makeDate", MySqlDbType.Date),
					new MySqlParameter("?makeType", MySqlDbType.Bit),
					new MySqlParameter("?oldBillCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?oldBillId", MySqlDbType.Int64,20),
					new MySqlParameter("?operator", MySqlDbType.VarChar,30),
					new MySqlParameter("?orderType", MySqlDbType.Int32,11),
					new MySqlParameter("?outInMoney", MySqlDbType.Double),
					new MySqlParameter("?prizeBillId", MySqlDbType.Int64,20),
					new MySqlParameter("?remarks", MySqlDbType.VarChar,80),
					new MySqlParameter("?salesman", MySqlDbType.VarChar,30),
					new MySqlParameter("?trafficNum", MySqlDbType.VarChar,80),
					new MySqlParameter("?vehCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?ent_id", MySqlDbType.Int64,20),
					new MySqlParameter("?sys_dep_id", MySqlDbType.Int64,20),
					new MySqlParameter("?blPrint", MySqlDbType.Bit),
					new MySqlParameter("?returnCause", MySqlDbType.VarChar,100),
					new MySqlParameter("?packingDetail_id", MySqlDbType.Int64,20),
					new MySqlParameter("?kokura_id", MySqlDbType.Int64,20),
					new MySqlParameter("?makeTime", MySqlDbType.Time),
					new MySqlParameter("?netOrder_id", MySqlDbType.Int64,20),
					new MySqlParameter("?deliverPerCount", MySqlDbType.Int32,11),
					new MySqlParameter("?blBorrow", MySqlDbType.Bit),
					new MySqlParameter("?borrowStatus", MySqlDbType.Int32,11),
					new MySqlParameter("?prizeBillCode", MySqlDbType.VarChar,255),
					new MySqlParameter("?saleMoney", MySqlDbType.Double),
					new MySqlParameter("?srcFlag", MySqlDbType.Int32,11),
					new MySqlParameter("?orderId", MySqlDbType.Int64,20),
					new MySqlParameter("?orderCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?lastPreReceiveBalance", MySqlDbType.Double),
					new MySqlParameter("?lastPreReceiveValidBalance", MySqlDbType.Double),
					new MySqlParameter("?lastReceivable", MySqlDbType.Double),
					new MySqlParameter("?lastpromiseReceivable", MySqlDbType.Double),
					new MySqlParameter("?settlementType", MySqlDbType.Int32,11),
					new MySqlParameter("?billVolume", MySqlDbType.Double),
					new MySqlParameter("?billWeight", MySqlDbType.Int32,11),
					new MySqlParameter("?receiveMoney", MySqlDbType.Double),
					new MySqlParameter("?returnOrderBillCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?returnOrderBillId", MySqlDbType.Int64,20),
					new MySqlParameter("?returnStoreBillCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?returnStoreBillId", MySqlDbType.Int64,20),
					new MySqlParameter("?operator_id", MySqlDbType.Int64,20),
					new MySqlParameter("?salesman_id", MySqlDbType.Int64,20)};
			parameters[0].Value = model.RBillCode;
			parameters[1].Value = model.RBillId;
			parameters[2].Value = model.backFlag;
			parameters[3].Value = model.billCode;
			parameters[4].Value = model.billMoney;
			parameters[5].Value = model.billType;
			parameters[6].Value = model.blProxy;
			parameters[7].Value = model.chequeNum;
			parameters[8].Value = model.contractNum;
			parameters[9].Value = model.deliver;
			parameters[10].Value = model.deliverCount;
			parameters[11].Value = model.driver;
			parameters[12].Value = model.exhibitDate;
			parameters[13].Value = model.flowFlag;
			parameters[14].Value = model.invoiceNum;
			parameters[15].Value = model.lockName;
			parameters[16].Value = model.makeDate;
			parameters[17].Value = model.makeType;
			parameters[18].Value = model.oldBillCode;
			parameters[19].Value = model.oldBillId;
			parameters[20].Value = model.operators;
			parameters[21].Value = model.orderType;
			parameters[22].Value = model.outInMoney;
			parameters[23].Value = model.prizeBillId;
			parameters[24].Value = model.remarks;
			parameters[25].Value = model.salesman;
			parameters[26].Value = model.trafficNum;
			parameters[27].Value = model.vehCode;
			parameters[28].Value = model.ent_id;
			parameters[29].Value = model.sys_dep_id;
			parameters[30].Value = model.blPrint;
			parameters[31].Value = model.returnCause;
			parameters[32].Value = model.packingDetail_id;
			parameters[33].Value = model.kokura_id;
			parameters[34].Value = model.makeTime;
			parameters[35].Value = model.netOrder_id;
			parameters[36].Value = model.deliverPerCount;
			parameters[37].Value = model.blBorrow;
			parameters[38].Value = model.borrowStatus;
			parameters[39].Value = model.prizeBillCode;
			parameters[40].Value = model.saleMoney;
			parameters[41].Value = model.srcFlag;
			parameters[42].Value = model.orderId;
			parameters[43].Value = model.orderCode;
			parameters[44].Value = model.lastPreReceiveBalance;
			parameters[45].Value = model.lastPreReceiveValidBalance;
			parameters[46].Value = model.lastReceivable;
			parameters[47].Value = model.lastpromiseReceivable;
			parameters[48].Value = model.settlementType;
			parameters[49].Value = model.billVolume;
			parameters[50].Value = model.billWeight;
			parameters[51].Value = model.receiveMoney;
			parameters[52].Value = model.returnOrderBillCode;
			parameters[53].Value = model.returnOrderBillId;
			parameters[54].Value = model.returnStoreBillCode;
			parameters[55].Value = model.returnStoreBillId;
			parameters[56].Value = model.operator_id;
			parameters[57].Value = model.salesman_id;

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
		public bool Update(YSWL.Model.ERP.Order.SaleOrderBill model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update saleorderbill set ");
			strSql.Append("RBillCode=?RBillCode,");
			strSql.Append("RBillId=?RBillId,");
			strSql.Append("backFlag=?backFlag,");
			strSql.Append("billCode=?billCode,");
			strSql.Append("billMoney=?billMoney,");
			strSql.Append("billType=?billType,");
			strSql.Append("blProxy=?blProxy,");
			strSql.Append("chequeNum=?chequeNum,");
			strSql.Append("contractNum=?contractNum,");
			strSql.Append("deliver=?deliver,");
			strSql.Append("deliverCount=?deliverCount,");
			strSql.Append("driver=?driver,");
			strSql.Append("exhibitDate=?exhibitDate,");
			strSql.Append("flowFlag=?flowFlag,");
			strSql.Append("invoiceNum=?invoiceNum,");
			strSql.Append("lockName=?lockName,");
			strSql.Append("makeDate=?makeDate,");
			strSql.Append("makeType=?makeType,");
			strSql.Append("oldBillCode=?oldBillCode,");
			strSql.Append("oldBillId=?oldBillId,");
			strSql.Append("operator=?operator,");
			strSql.Append("orderType=?orderType,");
			strSql.Append("outInMoney=?outInMoney,");
			strSql.Append("prizeBillId=?prizeBillId,");
			strSql.Append("remarks=?remarks,");
			strSql.Append("salesman=?salesman,");
			strSql.Append("trafficNum=?trafficNum,");
			strSql.Append("vehCode=?vehCode,");
			strSql.Append("ent_id=?ent_id,");
			strSql.Append("sys_dep_id=?sys_dep_id,");
			strSql.Append("blPrint=?blPrint,");
			strSql.Append("returnCause=?returnCause,");
			strSql.Append("packingDetail_id=?packingDetail_id,");
			strSql.Append("kokura_id=?kokura_id,");
			strSql.Append("makeTime=?makeTime,");
			strSql.Append("netOrder_id=?netOrder_id,");
			strSql.Append("deliverPerCount=?deliverPerCount,");
			strSql.Append("blBorrow=?blBorrow,");
			strSql.Append("borrowStatus=?borrowStatus,");
			strSql.Append("prizeBillCode=?prizeBillCode,");
			strSql.Append("saleMoney=?saleMoney,");
			strSql.Append("srcFlag=?srcFlag,");
			strSql.Append("orderId=?orderId,");
			strSql.Append("orderCode=?orderCode,");
			strSql.Append("lastPreReceiveBalance=?lastPreReceiveBalance,");
			strSql.Append("lastPreReceiveValidBalance=?lastPreReceiveValidBalance,");
			strSql.Append("lastReceivable=?lastReceivable,");
			strSql.Append("lastpromiseReceivable=?lastpromiseReceivable,");
			strSql.Append("settlementType=?settlementType,");
			strSql.Append("billVolume=?billVolume,");
			strSql.Append("billWeight=?billWeight,");
			strSql.Append("receiveMoney=?receiveMoney,");
			strSql.Append("returnOrderBillCode=?returnOrderBillCode,");
			strSql.Append("returnOrderBillId=?returnOrderBillId,");
			strSql.Append("returnStoreBillCode=?returnStoreBillCode,");
			strSql.Append("returnStoreBillId=?returnStoreBillId,");
			strSql.Append("operator_id=?operator_id,");
			strSql.Append("salesman_id=?salesman_id");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?RBillCode", MySqlDbType.VarChar,255),
					new MySqlParameter("?RBillId", MySqlDbType.Int64,20),
					new MySqlParameter("?backFlag", MySqlDbType.Bit),
					new MySqlParameter("?billCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?billMoney", MySqlDbType.Double),
					new MySqlParameter("?billType", MySqlDbType.VarChar,3),
					new MySqlParameter("?blProxy", MySqlDbType.Bit),
					new MySqlParameter("?chequeNum", MySqlDbType.VarChar,80),
					new MySqlParameter("?contractNum", MySqlDbType.VarChar,80),
					new MySqlParameter("?deliver", MySqlDbType.VarChar,100),
					new MySqlParameter("?deliverCount", MySqlDbType.Int32,11),
					new MySqlParameter("?driver", MySqlDbType.VarChar,30),
					new MySqlParameter("?exhibitDate", MySqlDbType.Date),
					new MySqlParameter("?flowFlag", MySqlDbType.Int32,11),
					new MySqlParameter("?invoiceNum", MySqlDbType.VarChar,80),
					new MySqlParameter("?lockName", MySqlDbType.VarChar,30),
					new MySqlParameter("?makeDate", MySqlDbType.Date),
					new MySqlParameter("?makeType", MySqlDbType.Bit),
					new MySqlParameter("?oldBillCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?oldBillId", MySqlDbType.Int64,20),
					new MySqlParameter("?operator", MySqlDbType.VarChar,30),
					new MySqlParameter("?orderType", MySqlDbType.Int32,11),
					new MySqlParameter("?outInMoney", MySqlDbType.Double),
					new MySqlParameter("?prizeBillId", MySqlDbType.Int64,20),
					new MySqlParameter("?remarks", MySqlDbType.VarChar,80),
					new MySqlParameter("?salesman", MySqlDbType.VarChar,30),
					new MySqlParameter("?trafficNum", MySqlDbType.VarChar,80),
					new MySqlParameter("?vehCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?ent_id", MySqlDbType.Int64,20),
					new MySqlParameter("?sys_dep_id", MySqlDbType.Int64,20),
					new MySqlParameter("?blPrint", MySqlDbType.Bit),
					new MySqlParameter("?returnCause", MySqlDbType.VarChar,100),
					new MySqlParameter("?packingDetail_id", MySqlDbType.Int64,20),
					new MySqlParameter("?kokura_id", MySqlDbType.Int64,20),
					new MySqlParameter("?makeTime", MySqlDbType.Time),
					new MySqlParameter("?netOrder_id", MySqlDbType.Int64,20),
					new MySqlParameter("?deliverPerCount", MySqlDbType.Int32,11),
					new MySqlParameter("?blBorrow", MySqlDbType.Bit),
					new MySqlParameter("?borrowStatus", MySqlDbType.Int32,11),
					new MySqlParameter("?prizeBillCode", MySqlDbType.VarChar,255),
					new MySqlParameter("?saleMoney", MySqlDbType.Double),
					new MySqlParameter("?srcFlag", MySqlDbType.Int32,11),
					new MySqlParameter("?orderId", MySqlDbType.Int64,20),
					new MySqlParameter("?orderCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?lastPreReceiveBalance", MySqlDbType.Double),
					new MySqlParameter("?lastPreReceiveValidBalance", MySqlDbType.Double),
					new MySqlParameter("?lastReceivable", MySqlDbType.Double),
					new MySqlParameter("?lastpromiseReceivable", MySqlDbType.Double),
					new MySqlParameter("?settlementType", MySqlDbType.Int32,11),
					new MySqlParameter("?billVolume", MySqlDbType.Double),
					new MySqlParameter("?billWeight", MySqlDbType.Int32,11),
					new MySqlParameter("?receiveMoney", MySqlDbType.Double),
					new MySqlParameter("?returnOrderBillCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?returnOrderBillId", MySqlDbType.Int64,20),
					new MySqlParameter("?returnStoreBillCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?returnStoreBillId", MySqlDbType.Int64,20),
					new MySqlParameter("?operator_id", MySqlDbType.Int64,20),
					new MySqlParameter("?salesman_id", MySqlDbType.Int64,20),
					new MySqlParameter("?id", MySqlDbType.Int64,20)};
			parameters[0].Value = model.RBillCode;
			parameters[1].Value = model.RBillId;
			parameters[2].Value = model.backFlag;
			parameters[3].Value = model.billCode;
			parameters[4].Value = model.billMoney;
			parameters[5].Value = model.billType;
			parameters[6].Value = model.blProxy;
			parameters[7].Value = model.chequeNum;
			parameters[8].Value = model.contractNum;
			parameters[9].Value = model.deliver;
			parameters[10].Value = model.deliverCount;
			parameters[11].Value = model.driver;
			parameters[12].Value = model.exhibitDate;
			parameters[13].Value = model.flowFlag;
			parameters[14].Value = model.invoiceNum;
			parameters[15].Value = model.lockName;
			parameters[16].Value = model.makeDate;
			parameters[17].Value = model.makeType;
			parameters[18].Value = model.oldBillCode;
			parameters[19].Value = model.oldBillId;
			parameters[20].Value = model.operators;
			parameters[21].Value = model.orderType;
			parameters[22].Value = model.outInMoney;
			parameters[23].Value = model.prizeBillId;
			parameters[24].Value = model.remarks;
			parameters[25].Value = model.salesman;
			parameters[26].Value = model.trafficNum;
			parameters[27].Value = model.vehCode;
			parameters[28].Value = model.ent_id;
			parameters[29].Value = model.sys_dep_id;
			parameters[30].Value = model.blPrint;
			parameters[31].Value = model.returnCause;
			parameters[32].Value = model.packingDetail_id;
			parameters[33].Value = model.kokura_id;
			parameters[34].Value = model.makeTime;
			parameters[35].Value = model.netOrder_id;
			parameters[36].Value = model.deliverPerCount;
			parameters[37].Value = model.blBorrow;
			parameters[38].Value = model.borrowStatus;
			parameters[39].Value = model.prizeBillCode;
			parameters[40].Value = model.saleMoney;
			parameters[41].Value = model.srcFlag;
			parameters[42].Value = model.orderId;
			parameters[43].Value = model.orderCode;
			parameters[44].Value = model.lastPreReceiveBalance;
			parameters[45].Value = model.lastPreReceiveValidBalance;
			parameters[46].Value = model.lastReceivable;
			parameters[47].Value = model.lastpromiseReceivable;
			parameters[48].Value = model.settlementType;
			parameters[49].Value = model.billVolume;
			parameters[50].Value = model.billWeight;
			parameters[51].Value = model.receiveMoney;
			parameters[52].Value = model.returnOrderBillCode;
			parameters[53].Value = model.returnOrderBillId;
			parameters[54].Value = model.returnStoreBillCode;
			parameters[55].Value = model.returnStoreBillId;
			parameters[56].Value = model.operator_id;
			parameters[57].Value = model.salesman_id;
			parameters[58].Value = model.id;

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
			strSql.Append("delete from saleorderbill ");
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
			strSql.Append("delete from saleorderbill ");
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
		public YSWL.Model.ERP.Order.SaleOrderBill GetModel(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,RBillCode,RBillId,backFlag,billCode,billMoney,billType,blProxy,chequeNum,contractNum,deliver,deliverCount,driver,exhibitDate,flowFlag,invoiceNum,lockName,makeDate,makeType,oldBillCode,oldBillId,operator,orderType,outInMoney,prizeBillId,remarks,salesman,trafficNum,vehCode,ent_id,sys_dep_id,blPrint,returnCause,packingDetail_id,kokura_id,makeTime,netOrder_id,deliverPerCount,blBorrow,borrowStatus,prizeBillCode,saleMoney,srcFlag,orderId,orderCode,lastPreReceiveBalance,lastPreReceiveValidBalance,lastReceivable,lastpromiseReceivable,settlementType,billVolume,billWeight,receiveMoney,returnOrderBillCode,returnOrderBillId,returnStoreBillCode,returnStoreBillId,operator_id,salesman_id from saleorderbill ");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64)
			};
			parameters[0].Value = id;

			YSWL.Model.ERP.Order.SaleOrderBill model=new YSWL.Model.ERP.Order.SaleOrderBill();
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
		public YSWL.Model.ERP.Order.SaleOrderBill DataRowToModel(DataRow row)
		{
			YSWL.Model.ERP.Order.SaleOrderBill model=new YSWL.Model.ERP.Order.SaleOrderBill();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=long.Parse(row["id"].ToString());
				}
				if(row["RBillCode"]!=null)
				{
					model.RBillCode=row["RBillCode"].ToString();
				}
				if(row["RBillId"]!=null && row["RBillId"].ToString()!="")
				{
					model.RBillId=long.Parse(row["RBillId"].ToString());
				}
				if(row["backFlag"]!=null && row["backFlag"].ToString()!="")
				{
					if((row["backFlag"].ToString()=="1")||(row["backFlag"].ToString().ToLower()=="true"))
					{
						model.backFlag=true;
					}
					else
					{
						model.backFlag=false;
					}
				}
				if(row["billCode"]!=null)
				{
					model.billCode=row["billCode"].ToString();
				}
					//model.billMoney=row["billMoney"].ToString();
				if(row["billType"]!=null)
				{
					model.billType=row["billType"].ToString();
				}
				if(row["blProxy"]!=null && row["blProxy"].ToString()!="")
				{
					if((row["blProxy"].ToString()=="1")||(row["blProxy"].ToString().ToLower()=="true"))
					{
						model.blProxy=true;
					}
					else
					{
						model.blProxy=false;
					}
				}
				if(row["chequeNum"]!=null)
				{
					model.chequeNum=row["chequeNum"].ToString();
				}
				if(row["contractNum"]!=null)
				{
					model.contractNum=row["contractNum"].ToString();
				}
				if(row["deliver"]!=null)
				{
					model.deliver=row["deliver"].ToString();
				}
				if(row["deliverCount"]!=null && row["deliverCount"].ToString()!="")
				{
					model.deliverCount=int.Parse(row["deliverCount"].ToString());
				}
				if(row["driver"]!=null)
				{
					model.driver=row["driver"].ToString();
				}
				if(row["exhibitDate"]!=null && row["exhibitDate"].ToString()!="")
				{
					model.exhibitDate=DateTime.Parse(row["exhibitDate"].ToString());
				}
				if(row["flowFlag"]!=null && row["flowFlag"].ToString()!="")
				{
					model.flowFlag=int.Parse(row["flowFlag"].ToString());
				}
				if(row["invoiceNum"]!=null)
				{
					model.invoiceNum=row["invoiceNum"].ToString();
				}
				if(row["lockName"]!=null)
				{
					model.lockName=row["lockName"].ToString();
				}
				if(row["makeDate"]!=null && row["makeDate"].ToString()!="")
				{
					model.makeDate=DateTime.Parse(row["makeDate"].ToString());
				}
				if(row["makeType"]!=null && row["makeType"].ToString()!="")
				{
					if((row["makeType"].ToString()=="1")||(row["makeType"].ToString().ToLower()=="true"))
					{
						model.makeType=true;
					}
					else
					{
						model.makeType=false;
					}
				}
				if(row["oldBillCode"]!=null)
				{
					model.oldBillCode=row["oldBillCode"].ToString();
				}
				if(row["oldBillId"]!=null && row["oldBillId"].ToString()!="")
				{
					model.oldBillId=long.Parse(row["oldBillId"].ToString());
				}
				if(row["operator"]!=null)
				{
					model.operators=row["operator"].ToString();
				}
				if(row["orderType"]!=null && row["orderType"].ToString()!="")
				{
					model.orderType=int.Parse(row["orderType"].ToString());
				}
					//model.outInMoney=row["outInMoney"].ToString();
				if(row["prizeBillId"]!=null && row["prizeBillId"].ToString()!="")
				{
					model.prizeBillId=long.Parse(row["prizeBillId"].ToString());
				}
				if(row["remarks"]!=null)
				{
					model.remarks=row["remarks"].ToString();
				}
				if(row["salesman"]!=null)
				{
					model.salesman=row["salesman"].ToString();
				}
				if(row["trafficNum"]!=null)
				{
					model.trafficNum=row["trafficNum"].ToString();
				}
				if(row["vehCode"]!=null)
				{
					model.vehCode=row["vehCode"].ToString();
				}
				if(row["ent_id"]!=null && row["ent_id"].ToString()!="")
				{
					model.ent_id=long.Parse(row["ent_id"].ToString());
				}
				if(row["sys_dep_id"]!=null && row["sys_dep_id"].ToString()!="")
				{
					model.sys_dep_id=long.Parse(row["sys_dep_id"].ToString());
				}
				if(row["blPrint"]!=null && row["blPrint"].ToString()!="")
				{
					if((row["blPrint"].ToString()=="1")||(row["blPrint"].ToString().ToLower()=="true"))
					{
						model.blPrint=true;
					}
					else
					{
						model.blPrint=false;
					}
				}
				if(row["returnCause"]!=null)
				{
					model.returnCause=row["returnCause"].ToString();
				}
				if(row["packingDetail_id"]!=null && row["packingDetail_id"].ToString()!="")
				{
					model.packingDetail_id=long.Parse(row["packingDetail_id"].ToString());
				}
				if(row["kokura_id"]!=null && row["kokura_id"].ToString()!="")
				{
					model.kokura_id=long.Parse(row["kokura_id"].ToString());
				}
				if(row["makeTime"]!=null && row["makeTime"].ToString()!="")
				{
					model.makeTime=DateTime.Parse(row["makeTime"].ToString());
				}
				if(row["netOrder_id"]!=null && row["netOrder_id"].ToString()!="")
				{
					model.netOrder_id=long.Parse(row["netOrder_id"].ToString());
				}
				if(row["deliverPerCount"]!=null && row["deliverPerCount"].ToString()!="")
				{
					model.deliverPerCount=int.Parse(row["deliverPerCount"].ToString());
				}
				if(row["blBorrow"]!=null && row["blBorrow"].ToString()!="")
				{
					if((row["blBorrow"].ToString()=="1")||(row["blBorrow"].ToString().ToLower()=="true"))
					{
						model.blBorrow=true;
					}
					else
					{
						model.blBorrow=false;
					}
				}
				if(row["borrowStatus"]!=null && row["borrowStatus"].ToString()!="")
				{
					model.borrowStatus=int.Parse(row["borrowStatus"].ToString());
				}
				if(row["prizeBillCode"]!=null)
				{
					model.prizeBillCode=row["prizeBillCode"].ToString();
				}
					//model.saleMoney=row["saleMoney"].ToString();
				if(row["srcFlag"]!=null && row["srcFlag"].ToString()!="")
				{
					model.srcFlag=int.Parse(row["srcFlag"].ToString());
				}
				if(row["orderId"]!=null && row["orderId"].ToString()!="")
				{
					model.orderId=long.Parse(row["orderId"].ToString());
				}
				if(row["orderCode"]!=null)
				{
					model.orderCode=row["orderCode"].ToString();
				}
					//model.lastPreReceiveBalance=row["lastPreReceiveBalance"].ToString();
					//model.lastPreReceiveValidBalance=row["lastPreReceiveValidBalance"].ToString();
					//model.lastReceivable=row["lastReceivable"].ToString();
					//model.lastpromiseReceivable=row["lastpromiseReceivable"].ToString();
				if(row["settlementType"]!=null && row["settlementType"].ToString()!="")
				{
					model.settlementType=int.Parse(row["settlementType"].ToString());
				}
					//model.billVolume=row["billVolume"].ToString();
				if(row["billWeight"]!=null && row["billWeight"].ToString()!="")
				{
					model.billWeight=int.Parse(row["billWeight"].ToString());
				}
					//model.receiveMoney=row["receiveMoney"].ToString();
				if(row["returnOrderBillCode"]!=null)
				{
					model.returnOrderBillCode=row["returnOrderBillCode"].ToString();
				}
				if(row["returnOrderBillId"]!=null && row["returnOrderBillId"].ToString()!="")
				{
					model.returnOrderBillId=long.Parse(row["returnOrderBillId"].ToString());
				}
				if(row["returnStoreBillCode"]!=null)
				{
					model.returnStoreBillCode=row["returnStoreBillCode"].ToString();
				}
				if(row["returnStoreBillId"]!=null && row["returnStoreBillId"].ToString()!="")
				{
					model.returnStoreBillId=long.Parse(row["returnStoreBillId"].ToString());
				}
				if(row["operator_id"]!=null && row["operator_id"].ToString()!="")
				{
					model.operator_id=long.Parse(row["operator_id"].ToString());
				}
				if(row["salesman_id"]!=null && row["salesman_id"].ToString()!="")
				{
					model.salesman_id=long.Parse(row["salesman_id"].ToString());
				}
                //if (row["name"] != null && row["name"].ToString() != "")
                //{
                //    model.Kuroomname = row["name"].ToString();
                //}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select b.id,RBillCode,RBillId,backFlag,billCode,billMoney,billType,blProxy,chequeNum,contractNum,deliver,deliverCount,driver,exhibitDate,flowFlag,invoiceNum,lockName,makeDate,makeType,oldBillCode,oldBillId,operator,orderType,outInMoney,prizeBillId,remarks,salesman,trafficNum,vehCode,ent_id,sys_dep_id,blPrint,returnCause,packingDetail_id,kokura_id,makeTime,netOrder_id,deliverPerCount,blBorrow,borrowStatus,prizeBillCode,saleMoney,srcFlag,orderId,orderCode,lastPreReceiveBalance,lastPreReceiveValidBalance,lastReceivable,lastpromiseReceivable,settlementType,billVolume,billWeight,receiveMoney,returnOrderBillCode,returnOrderBillId,returnStoreBillCode,returnStoreBillId,operator_id,salesman_id ");
            strSql.Append(" FROM saleorderbill  b");
			if(strWhere.Trim()!="")
			{
                strSql.AppendFormat(" where   {0}", strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM saleorderbill ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from saleorderbill T ");
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
			parameters[0].Value = "saleorderbill";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod



		#region  ExtensionMethod
        public DataSet GetProducts(string billCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.ordinal,b.code,b.name,c.name as cName,b.specification,a.pieceQty,a.saleType,a.scatteredQty,a.piecePrice,a.money,b.barCode from saleorderbilldetail a,goods b,store c ");
            strSql.Append(" where a.goods_id=b.id and a.store_id=c.id  ");
            strSql.Append(string.Format("and a.billCode='{0}'  ", billCode));
            strSql.Append("ORDER BY a.ordinal asc");
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public List<YSWL.Model.ERP.Products.CustomerSaleProduct> GetProductList(DataTable dt)
        {
            List<YSWL.Model.ERP.Products.CustomerSaleProduct> modelList = new
                List<YSWL.Model.ERP.Products.CustomerSaleProduct>();
            if (null == dt)
            {
                return null;
            }
            YSWL.Model.ERP.Products.CustomerSaleProduct model;
       for (int i = 0; i < dt.Rows.Count; i++)
       {
          model=new CustomerSaleProduct();
           if (dt.Rows[i]["ordinal"] != null && dt.Rows[i]["ordinal"].ToString() != "")
           {
               model.Id = int.Parse(dt.Rows[i]["ordinal"].ToString());
           }
           if (dt.Rows[i]["code"] != null && dt.Rows[i]["code"].ToString() != "")
           {
               model.ProductCode = dt.Rows[i]["code"].ToString();
           }
           if (dt.Rows[i]["name"] != null && dt.Rows[i]["name"].ToString() != "")
           {
               model.ProductName = dt.Rows[i]["name"].ToString();
           }
           if (dt.Rows[i]["cName"] != null && dt.Rows[i]["cName"].ToString() != "")
           {
               model.StoreName = dt.Rows[i]["cName"].ToString();
           }
           if (dt.Rows[i]["specification"] != null && dt.Rows[i]["specification"].ToString() != "")
           {
               model.ProductSec = dt.Rows[i]["specification"].ToString();
           }
           if (dt.Rows[i]["pieceQty"] != null && dt.Rows[i]["pieceQty"].ToString() != "")
           {
               model.PieceQty = int.Parse(dt.Rows[i]["pieceQty"].ToString());
           }
           if (dt.Rows[i]["scatteredQty"] != null && dt.Rows[i]["scatteredQty"].ToString() != "")
           {
               model.ScatteredQty = int.Parse(dt.Rows[i]["scatteredQty"].ToString());
           }
           if (dt.Rows[i]["piecePrice"] != null && dt.Rows[i]["piecePrice"].ToString() != "")
           {
               model.PiecePrice = decimal.Parse(dt.Rows[i]["piecePrice"].ToString());
           }
           if (dt.Rows[i]["money"] != null && dt.Rows[i]["money"].ToString() != "")
           {
               model.ProductAmount = decimal.Parse(dt.Rows[i]["money"].ToString());
           }
           if (dt.Rows[i]["barCode"] != null && dt.Rows[i]["barCode"].ToString() != "")
           {
               model.BarCode = dt.Rows[i]["barCode"].ToString();
           }
           if (dt.Rows[i]["saleType"] != null && dt.Rows[i]["saleType"].ToString() != "")
           {
               model.SaleType = int.Parse(dt.Rows[i]["saleType"].ToString());
           }
           modelList.Add(model);
       }
            return modelList;
        }
        /// <summary>
        /// 获取订单总数
        /// </summary>
        /// <param name="billCode"></param>
        /// <returns></returns>
	    public int GetOrderCount(string billCode)
	    {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from saleorderbilldetail a,goods b,store c ");
            strSql.Append(" where a.goods_id=b.id and a.store_id=c.id  ");
            strSql.Append(string.Format("and a.billCode='{0}'  ", billCode));
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

        public bool UpdatePrint(string billCode, bool isPrint = true)
	    {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update saleorderbill set ");
            strSql.Append("blPrint=?blPrint");
            strSql.Append(" where billCode=?billCode");
            MySqlParameter[] parameters = {
					new MySqlParameter("?billCode", MySqlDbType.String),
					new MySqlParameter("?blPrint", MySqlDbType.Bit)};
            parameters[0].Value = billCode;
            parameters[1].Value = isPrint;

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


        public bool UpdatePrintList(string billCodes, bool isPrint = true)
	    {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update saleorderbill set ");
            strSql.Append("blPrint=?blPrint");
            strSql.Append(" where billCode in (" + billCodes + ")  ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?blPrint", MySqlDbType.Bit)};
            parameters[0].Value = isPrint;

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

       public int GetRecordCount(string strWhere, string billCode)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select count(1) FROM saleorderbill ");
           strSql.Append(" where billcode=?billcode");
           if (!string.IsNullOrWhiteSpace(strWhere))
           {
               strSql.Append(" and   " + strWhere);
           }
           MySqlParameter[] parameters = {
					new MySqlParameter("?billcode", MySqlDbType.String)
			};
           parameters[0].Value = billCode;
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

        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
       public DataSet GetOrderList(string strWhere)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select b.id,b.billCode,b.makeDate,b.salesman,b.billVolume,b.billWeight,b.outInMoney,b.saleMoney,b.receiveMoney,c.name,c.address,sum(d.pieceQty) pieceQty,sum(d.scatteredQty) scatteredQty,sum(d.money) money,sum(d.profit) profit");
           strSql.Append(" from saleorderbill b INNER JOIN  enterpriseinfo c on  c.id=b.ent_id INNER JOIN saleorderbilldetail d on d.billCode=b.billCode ");
           if (!string.IsNullOrWhiteSpace(strWhere))
           {
               strSql.AppendFormat(" where {0} ", strWhere);
           }
           strSql.Append(" GROUP BY b.id,b.billCode,b.makeDate,b.salesman,b.billVolume,b.billWeight,b.outInMoney,b.saleMoney,b.receiveMoney,c.name,c.address ");
           return DbHelperMySQL.Query(strSql.ToString());
       }



       /// <summary>
       /// 得到一个对象实体(扩展方法)
       /// </summary>
       public YSWL.Model.ERP.Order.SaleOrderBill DataRowToModelEx(DataRow row)
       {
           YSWL.Model.ERP.Order.SaleOrderBill model = new YSWL.Model.ERP.Order.SaleOrderBill();
           if (row != null)
           {
               if (row["id"] != null && row["id"].ToString() != "")
               {
                   model.id = long.Parse(row["id"].ToString());
               }
               if (row["RBillCode"] != null)
               {
                   model.RBillCode = row["RBillCode"].ToString();
               }
               if (row["RBillId"] != null && row["RBillId"].ToString() != "")
               {
                   model.RBillId = long.Parse(row["RBillId"].ToString());
               }
               if (row["backFlag"] != null && row["backFlag"].ToString() != "")
               {
                   if ((row["backFlag"].ToString() == "1") || (row["backFlag"].ToString().ToLower() == "true"))
                   {
                       model.backFlag = true;
                   }
                   else
                   {
                       model.backFlag = false;
                   }
               }
               if (row["billCode"] != null)
               {
                   model.billCode = row["billCode"].ToString();
               }
               //model.billMoney=row["billMoney"].ToString();
               if (row["billType"] != null)
               {
                   model.billType = row["billType"].ToString();
               }
               if (row["blProxy"] != null && row["blProxy"].ToString() != "")
               {
                   if ((row["blProxy"].ToString() == "1") || (row["blProxy"].ToString().ToLower() == "true"))
                   {
                       model.blProxy = true;
                   }
                   else
                   {
                       model.blProxy = false;
                   }
               }
               if (row["chequeNum"] != null)
               {
                   model.chequeNum = row["chequeNum"].ToString();
               }
               if (row["contractNum"] != null)
               {
                   model.contractNum = row["contractNum"].ToString();
               }
               if (row["deliver"] != null)
               {
                   model.deliver = row["deliver"].ToString();
               }
               if (row["deliverCount"] != null && row["deliverCount"].ToString() != "")
               {
                   model.deliverCount = int.Parse(row["deliverCount"].ToString());
               }
               if (row["driver"] != null)
               {
                   model.driver = row["driver"].ToString();
               }
               if (row["exhibitDate"] != null && row["exhibitDate"].ToString() != "")
               {
                   model.exhibitDate = DateTime.Parse(row["exhibitDate"].ToString());
               }
               if (row["flowFlag"] != null && row["flowFlag"].ToString() != "")
               {
                   model.flowFlag = int.Parse(row["flowFlag"].ToString());
               }
               if (row["invoiceNum"] != null)
               {
                   model.invoiceNum = row["invoiceNum"].ToString();
               }
               if (row["lockName"] != null)
               {
                   model.lockName = row["lockName"].ToString();
               }
               if (row["makeDate"] != null && row["makeDate"].ToString() != "")
               {
                   model.makeDate = DateTime.Parse(row["makeDate"].ToString());
               }
               if (row["makeType"] != null && row["makeType"].ToString() != "")
               {
                   if ((row["makeType"].ToString() == "1") || (row["makeType"].ToString().ToLower() == "true"))
                   {
                       model.makeType = true;
                   }
                   else
                   {
                       model.makeType = false;
                   }
               }
               if (row["oldBillCode"] != null)
               {
                   model.oldBillCode = row["oldBillCode"].ToString();
               }
               if (row["oldBillId"] != null && row["oldBillId"].ToString() != "")
               {
                   model.oldBillId = long.Parse(row["oldBillId"].ToString());
               }
               if (row["operator"] != null)
               {
                   model.operators = row["operator"].ToString();
               }
               if (row["orderType"] != null && row["orderType"].ToString() != "")
               {
                   model.orderType = int.Parse(row["orderType"].ToString());
               }
               //model.outInMoney=row["outInMoney"].ToString();
               if (row["prizeBillId"] != null && row["prizeBillId"].ToString() != "")
               {
                   model.prizeBillId = long.Parse(row["prizeBillId"].ToString());
               }
               if (row["remarks"] != null)
               {
                   model.remarks = row["remarks"].ToString();
               }
               if (row["salesman"] != null)
               {
                   model.salesman = row["salesman"].ToString();
               }
               if (row["trafficNum"] != null)
               {
                   model.trafficNum = row["trafficNum"].ToString();
               }
               if (row["vehCode"] != null)
               {
                   model.vehCode = row["vehCode"].ToString();
               }
               if (row["ent_id"] != null && row["ent_id"].ToString() != "")
               {
                   model.ent_id = long.Parse(row["ent_id"].ToString());
               }
               if (row["sys_dep_id"] != null && row["sys_dep_id"].ToString() != "")
               {
                   model.sys_dep_id = long.Parse(row["sys_dep_id"].ToString());
               }
               if (row["blPrint"] != null && row["blPrint"].ToString() != "")
               {
                   if ((row["blPrint"].ToString() == "1") || (row["blPrint"].ToString().ToLower() == "true"))
                   {
                       model.blPrint = true;
                   }
                   else
                   {
                       model.blPrint = false;
                   }
               }
               if (row["returnCause"] != null)
               {
                   model.returnCause = row["returnCause"].ToString();
               }
               if (row["packingDetail_id"] != null && row["packingDetail_id"].ToString() != "")
               {
                   model.packingDetail_id = long.Parse(row["packingDetail_id"].ToString());
               }
               if (row["kokura_id"] != null && row["kokura_id"].ToString() != "")
               {
                   model.kokura_id = long.Parse(row["kokura_id"].ToString());
               }
               if (row["makeTime"] != null && row["makeTime"].ToString() != "")
               {
                   model.makeTime = DateTime.Parse(row["makeTime"].ToString());
               }
               if (row["netOrder_id"] != null && row["netOrder_id"].ToString() != "")
               {
                   model.netOrder_id = long.Parse(row["netOrder_id"].ToString());
               }
               if (row["deliverPerCount"] != null && row["deliverPerCount"].ToString() != "")
               {
                   model.deliverPerCount = int.Parse(row["deliverPerCount"].ToString());
               }
               if (row["blBorrow"] != null && row["blBorrow"].ToString() != "")
               {
                   if ((row["blBorrow"].ToString() == "1") || (row["blBorrow"].ToString().ToLower() == "true"))
                   {
                       model.blBorrow = true;
                   }
                   else
                   {
                       model.blBorrow = false;
                   }
               }
               if (row["borrowStatus"] != null && row["borrowStatus"].ToString() != "")
               {
                   model.borrowStatus = int.Parse(row["borrowStatus"].ToString());
               }
               if (row["prizeBillCode"] != null)
               {
                   model.prizeBillCode = row["prizeBillCode"].ToString();
               }
               //model.saleMoney=row["saleMoney"].ToString();
               if (row["srcFlag"] != null && row["srcFlag"].ToString() != "")
               {
                   model.srcFlag = int.Parse(row["srcFlag"].ToString());
               }
               if (row["orderId"] != null && row["orderId"].ToString() != "")
               {
                   model.orderId = long.Parse(row["orderId"].ToString());
               }
               if (row["orderCode"] != null)
               {
                   model.orderCode = row["orderCode"].ToString();
               }
               //model.lastPreReceiveBalance=row["lastPreReceiveBalance"].ToString();
               //model.lastPreReceiveValidBalance=row["lastPreReceiveValidBalance"].ToString();
               //model.lastReceivable=row["lastReceivable"].ToString();
               //model.lastpromiseReceivable=row["lastpromiseReceivable"].ToString();
               if (row["settlementType"] != null && row["settlementType"].ToString() != "")
               {
                   model.settlementType = int.Parse(row["settlementType"].ToString());
               }
               //model.billVolume=row["billVolume"].ToString();
               if (row["billWeight"] != null && row["billWeight"].ToString() != "")
               {
                   model.billWeight = int.Parse(row["billWeight"].ToString());
               }
               //model.receiveMoney=row["receiveMoney"].ToString();
               if (row["returnOrderBillCode"] != null)
               {
                   model.returnOrderBillCode = row["returnOrderBillCode"].ToString();
               }
               if (row["returnOrderBillId"] != null && row["returnOrderBillId"].ToString() != "")
               {
                   model.returnOrderBillId = long.Parse(row["returnOrderBillId"].ToString());
               }
               if (row["returnStoreBillCode"] != null)
               {
                   model.returnStoreBillCode = row["returnStoreBillCode"].ToString();
               }
               if (row["returnStoreBillId"] != null && row["returnStoreBillId"].ToString() != "")
               {
                   model.returnStoreBillId = long.Parse(row["returnStoreBillId"].ToString());
               }
               if (row["operator_id"] != null && row["operator_id"].ToString() != "")
               {
                   model.operator_id = long.Parse(row["operator_id"].ToString());
               }
               if (row["salesman_id"] != null && row["salesman_id"].ToString() != "")
               {
                   model.salesman_id = long.Parse(row["salesman_id"].ToString());
               }
               if (row["name"] != null && row["name"].ToString() != "")
               {
                   model.Kuroomname = row["name"].ToString();
               }
           }
           return model;
       }



       /// <summary>
       /// 获得数据列表（扩展方法）
       /// </summary>
       public DataSet GetListEx(string strWhere)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select b.id,RBillCode,RBillId,backFlag,billCode,billMoney,billType,blProxy,chequeNum,contractNum,deliver,deliverCount,driver,exhibitDate,flowFlag,invoiceNum,lockName,makeDate,makeType,oldBillCode,oldBillId,operator,orderType,outInMoney,prizeBillId,remarks,salesman,trafficNum,vehCode,ent_id,sys_dep_id,blPrint,returnCause,packingDetail_id,kokura_id,makeTime,netOrder_id,deliverPerCount,blBorrow,borrowStatus,prizeBillCode,saleMoney,srcFlag,orderId,orderCode,lastPreReceiveBalance,lastPreReceiveValidBalance,lastReceivable,lastpromiseReceivable,settlementType,billVolume,billWeight,receiveMoney,returnOrderBillCode,returnOrderBillId,returnStoreBillCode,returnStoreBillId,operator_id,salesman_id,`name` ");
           strSql.Append(" FROM saleorderbill  b,kokura k");
           if (strWhere.Trim() != "")
           {
               strSql.AppendFormat(" where  (b.kokura_id=k.id and {0})", strWhere);
           }
           else
           {
               strSql.Append(" where  b.kokura_id=k.id ");
           }
           return DbHelperMySQL.Query(strSql.ToString());
       }


      public bool FinishOrder(string billCode)
      {
          object codeNum;//billCode数字部分
          string codeBill;//拼接完成之后的billCode
          object ordinal;
          if (string.IsNullOrWhiteSpace(billCode)) return false;
          using (MySqlConnection mySqlConnection = DbHelperMySQL.GetConnection)
          {
              if (mySqlConnection.State == ConnectionState.Closed)
              {
                  mySqlConnection.Open();
              }
              using (MySqlTransaction transaction=mySqlConnection.BeginTransaction())
              {
                  try
                  {
                      string addOrdinal = "update docmaxbh   set ordinal=ordinal+1 where typeCode='Z' or  typeCode='BYS'";
                      DbHelperMySQL.GetSingle4Trans(new CommandInfo(addOrdinal, null), transaction);//Ordinal增加

                      string getbillCodeSql = "select ordinal from docmaxbh where typeCode='BYS'";
                      codeNum = DbHelperMySQL.GetSingle4Trans(new CommandInfo(getbillCodeSql, null), transaction);
                      //billCode=BZX+8位数
                      codeBill = "BYS" + codeNum.ToString().PadLeft(8, '0');


                      string getOrdinal = "select ordinal from docmaxbh where typeCode='Z' ";
                      ordinal = DbHelperMySQL.GetSingle4Trans(new CommandInfo(getOrdinal, null), transaction);

                      #region insert to table prereceivebill
                      StringBuilder stringBuilder = new StringBuilder();
                      stringBuilder.Append(
                          "INSERT into prereceivebill (billCode,billType,flowFlag,operator,preDate,preReceiveMoney,salesman,ent_id,kokura_id,sys_dep_Id)");
                      stringBuilder.AppendFormat("   select  '{0}','BYS',0,`operator`,DATE(NOW()),`saleMoney`,`salesman`,ent_id,kokura_id,5 from saleorderbill b where b.billCode='{1}'", codeBill, billCode);
                      stringBuilder.Append(";select last_insert_id()");
                  object obj=DbHelperMySQL.GetSingle4Trans(new CommandInfo(stringBuilder.ToString(), null), transaction);
                      stringBuilder.Clear();
                      #endregion

                      #region insert into table prereceivedetail
                      stringBuilder.Append(
                  "insert into prereceivedetail (billCode,billType,ordinal,preReceiveMoney,rates,remarks,bill_id,poc_id)");
                      stringBuilder.AppendFormat("   select  '{0}','BYS',1,saleMoney,100,'POS机刷卡',{1} ,10  from saleorderbill b where b.billCode='{2}';", codeBill, obj, billCode);
                      DbHelperMySQL.GetSingle4Trans(new CommandInfo(stringBuilder.ToString(), null), transaction);
                      stringBuilder.Clear();
                      #endregion

                      #region insert into table curprereceiveaccount
                      stringBuilder.Append(
                          " insert into curprereceiveaccount (billCode,buzDate,forwardNum,macDate,month,operator,ordinal,preFinalMoney,preReceiVableBalance,preReceiveMoney,ent_id,remarks,salesman,year,kokura_id,sys_dep_id)");
                      stringBuilder.AppendFormat(
                          "   select  '{0}' ,makeDate,'JZH00000001', DATE(NOW()),MONTH(now()),operator,{1},saleMoney", codeBill, ordinal);
                      stringBuilder.AppendFormat(",(select preReceivableBalance from curprereceiveaccount where ent_id=(select ent_id from saleorderbill where billCode='{0}') ORDER BY id desc LIMIT 1)-saleMoney",billCode);
                      stringBuilder.Append(
                          ",0,ent_id,'POS机刷卡',salesman,YEAR(NOW()),kokura_id,5  from saleorderbill");
                      stringBuilder.AppendFormat(" where billCode='{0}' ", billCode);
                      DbHelperMySQL.GetSingle4Trans(new CommandInfo(stringBuilder.ToString(), null), transaction);
                      stringBuilder.Clear(); 
                      #endregion

                      transaction.Commit();
                  }
                  catch (MySqlException )
                  {
                      transaction.Rollback();
                      return false;
                  }
               
              }
              return true;
          }
      }



	    #endregion  ExtensionMethod
      public int GetOrderCount(string startDate, string endDate, int flag)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.AppendFormat("select  count(1) from saleorderbill b where b.returnDate>='{0}' and   b.returnDate <'{1}' ", startDate, endDate);
          if (flag > 0)
          {
              strSql.AppendFormat(" and  backFlag={0}", flag);
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
      /// 获取订单总数
      /// </summary>
      /// <param name="startDate"></param>
      /// <param name="endDate"></param>
      /// <returns></returns>
      public int GetTotalCount(string startDate, string endDate)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("SELECT  COUNT(1) FROM    salepackingbilldetail D ");
          strSql.AppendFormat("WHERE   EXISTS ( SELECT * FROM   salepackingbill B  WHERE  packingDate >= '{0}' and  packingDate<'{1}' AND D.bill_id = B.id ) ", startDate, endDate);
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


	}
}