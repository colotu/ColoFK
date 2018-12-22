/**  版本信息模板在安装目录下，可自行修改。
* salestorebill.cs
*
* 功 能： N/A
* 类 名： salestorebill
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/14 17:52:55   N/A    初版
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
	/// 数据访问类:salestorebill
	/// </summary>
	public partial class SaleStoreBill:ISaleStoreBill
	{
		public SaleStoreBill()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from salestorebill");
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
		public bool Add(YSWL.Model.ERP.SalePackingBill.SaleStoreBill  model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into salestorebill(");
			strSql.Append("billCode,billMoney,billType,blProxy,chequeNum,contractNum,deliver,driver,flowFlag,invoiceNum,killMoney,lockName,oldBillCode,operator,outInMoney,receiveMoney,remainMoney,remarks,salesman,storeDate,trafficNum,vehCode,ent_id,saleOrderBill_id,sys_dep_id,kokura_id,storeTime,saleMoney,RBillCode,RBillId,prizeBillCode,prizeBillId,returnCause,lastPreReceiveValidBalance,lastpromiseReceivable,settlementType,returnStoreBillCode,returnStoreBillId,operator_id,salesman_id)");
			strSql.Append(" values (");
			strSql.Append("?billCode,?billMoney,?billType,?blProxy,?chequeNum,?contractNum,?deliver,?driver,?flowFlag,?invoiceNum,?killMoney,?lockName,?oldBillCode,?operator,?outInMoney,?receiveMoney,?remainMoney,?remarks,?salesman,?storeDate,?trafficNum,?vehCode,?ent_id,?saleOrderBill_id,?sys_dep_id,?kokura_id,?storeTime,?saleMoney,?RBillCode,?RBillId,?prizeBillCode,?prizeBillId,?returnCause,?lastPreReceiveValidBalance,?lastpromiseReceivable,?settlementType,?returnStoreBillCode,?returnStoreBillId,?operator_id,?salesman_id)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?billCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?billMoney", MySqlDbType.Double),
					new MySqlParameter("?billType", MySqlDbType.VarChar,3),
					new MySqlParameter("?blProxy", MySqlDbType.Bit),
					new MySqlParameter("?chequeNum", MySqlDbType.VarChar,80),
					new MySqlParameter("?contractNum", MySqlDbType.VarChar,80),
					new MySqlParameter("?deliver", MySqlDbType.VarChar,255),
					new MySqlParameter("?driver", MySqlDbType.VarChar,100),
					new MySqlParameter("?flowFlag", MySqlDbType.Int32,11),
					new MySqlParameter("?invoiceNum", MySqlDbType.VarChar,80),
					new MySqlParameter("?killMoney", MySqlDbType.Double),
					new MySqlParameter("?lockName", MySqlDbType.VarChar,30),
					new MySqlParameter("?oldBillCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?operator", MySqlDbType.VarChar,30),
					new MySqlParameter("?outInMoney", MySqlDbType.Double),
					new MySqlParameter("?receiveMoney", MySqlDbType.Double),
					new MySqlParameter("?remainMoney", MySqlDbType.Double),
					new MySqlParameter("?remarks", MySqlDbType.VarChar,80),
					new MySqlParameter("?salesman", MySqlDbType.VarChar,30),
					new MySqlParameter("?storeDate", MySqlDbType.Date),
					new MySqlParameter("?trafficNum", MySqlDbType.VarChar,80),
					new MySqlParameter("?vehCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?ent_id", MySqlDbType.Int64,20),
					new MySqlParameter("?saleOrderBill_id", MySqlDbType.Int64,20),
					new MySqlParameter("?sys_dep_id", MySqlDbType.Int64,20),
					new MySqlParameter("?kokura_id", MySqlDbType.Int64,20),
					new MySqlParameter("?storeTime", MySqlDbType.Time),
					new MySqlParameter("?saleMoney", MySqlDbType.Double),
					new MySqlParameter("?RBillCode", MySqlDbType.VarChar,255),
					new MySqlParameter("?RBillId", MySqlDbType.Int64,20),
					new MySqlParameter("?prizeBillCode", MySqlDbType.VarChar,255),
					new MySqlParameter("?prizeBillId", MySqlDbType.Int64,20),
					new MySqlParameter("?returnCause", MySqlDbType.VarChar,100),
					new MySqlParameter("?lastPreReceiveValidBalance", MySqlDbType.Double),
					new MySqlParameter("?lastpromiseReceivable", MySqlDbType.Double),
					new MySqlParameter("?settlementType", MySqlDbType.Int32,11),
					new MySqlParameter("?returnStoreBillCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?returnStoreBillId", MySqlDbType.Int64,20),
					new MySqlParameter("?operator_id", MySqlDbType.Int64,20),
					new MySqlParameter("?salesman_id", MySqlDbType.Int64,20)};
			parameters[0].Value = model.billCode;
			parameters[1].Value = model.billMoney;
			parameters[2].Value = model.billType;
			parameters[3].Value = model.blProxy;
			parameters[4].Value = model.chequeNum;
			parameters[5].Value = model.contractNum;
			parameters[6].Value = model.deliver;
			parameters[7].Value = model.driver;
			parameters[8].Value = model.flowFlag;
			parameters[9].Value = model.invoiceNum;
			parameters[10].Value = model.killMoney;
			parameters[11].Value = model.lockName;
			parameters[12].Value = model.oldBillCode;
			parameters[13].Value = model.operators;
			parameters[14].Value = model.outInMoney;
			parameters[15].Value = model.receiveMoney;
			parameters[16].Value = model.remainMoney;
			parameters[17].Value = model.remarks;
			parameters[18].Value = model.salesman;
			parameters[19].Value = model.storeDate;
			parameters[20].Value = model.trafficNum;
			parameters[21].Value = model.vehCode;
			parameters[22].Value = model.ent_id;
			parameters[23].Value = model.saleOrderBill_id;
			parameters[24].Value = model.sys_dep_id;
			parameters[25].Value = model.kokura_id;
			parameters[26].Value = model.storeTime;
			parameters[27].Value = model.saleMoney;
			parameters[28].Value = model.RBillCode;
			parameters[29].Value = model.RBillId;
			parameters[30].Value = model.prizeBillCode;
			parameters[31].Value = model.prizeBillId;
			parameters[32].Value = model.returnCause;
			parameters[33].Value = model.lastPreReceiveValidBalance;
			parameters[34].Value = model.lastpromiseReceivable;
			parameters[35].Value = model.settlementType;
			parameters[36].Value = model.returnStoreBillCode;
			parameters[37].Value = model.returnStoreBillId;
			parameters[38].Value = model.operator_id;
			parameters[39].Value = model.salesman_id;

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
		public bool Update(YSWL.Model.ERP.SalePackingBill.SaleStoreBill model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update salestorebill set ");
			strSql.Append("billCode=?billCode,");
			strSql.Append("billMoney=?billMoney,");
			strSql.Append("billType=?billType,");
			strSql.Append("blProxy=?blProxy,");
			strSql.Append("chequeNum=?chequeNum,");
			strSql.Append("contractNum=?contractNum,");
			strSql.Append("deliver=?deliver,");
			strSql.Append("driver=?driver,");
			strSql.Append("flowFlag=?flowFlag,");
			strSql.Append("invoiceNum=?invoiceNum,");
			strSql.Append("killMoney=?killMoney,");
			strSql.Append("lockName=?lockName,");
			strSql.Append("oldBillCode=?oldBillCode,");
			strSql.Append("operator=?operator,");
			strSql.Append("outInMoney=?outInMoney,");
			strSql.Append("receiveMoney=?receiveMoney,");
			strSql.Append("remainMoney=?remainMoney,");
			strSql.Append("remarks=?remarks,");
			strSql.Append("salesman=?salesman,");
			strSql.Append("storeDate=?storeDate,");
			strSql.Append("trafficNum=?trafficNum,");
			strSql.Append("vehCode=?vehCode,");
			strSql.Append("ent_id=?ent_id,");
			strSql.Append("saleOrderBill_id=?saleOrderBill_id,");
			strSql.Append("sys_dep_id=?sys_dep_id,");
			strSql.Append("kokura_id=?kokura_id,");
			strSql.Append("storeTime=?storeTime,");
			strSql.Append("saleMoney=?saleMoney,");
			strSql.Append("RBillCode=?RBillCode,");
			strSql.Append("RBillId=?RBillId,");
			strSql.Append("prizeBillCode=?prizeBillCode,");
			strSql.Append("prizeBillId=?prizeBillId,");
			strSql.Append("returnCause=?returnCause,");
			strSql.Append("lastPreReceiveValidBalance=?lastPreReceiveValidBalance,");
			strSql.Append("lastpromiseReceivable=?lastpromiseReceivable,");
			strSql.Append("settlementType=?settlementType,");
			strSql.Append("returnStoreBillCode=?returnStoreBillCode,");
			strSql.Append("returnStoreBillId=?returnStoreBillId,");
			strSql.Append("operator_id=?operator_id,");
			strSql.Append("salesman_id=?salesman_id");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?billCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?billMoney", MySqlDbType.Double),
					new MySqlParameter("?billType", MySqlDbType.VarChar,3),
					new MySqlParameter("?blProxy", MySqlDbType.Bit),
					new MySqlParameter("?chequeNum", MySqlDbType.VarChar,80),
					new MySqlParameter("?contractNum", MySqlDbType.VarChar,80),
					new MySqlParameter("?deliver", MySqlDbType.VarChar,255),
					new MySqlParameter("?driver", MySqlDbType.VarChar,100),
					new MySqlParameter("?flowFlag", MySqlDbType.Int32,11),
					new MySqlParameter("?invoiceNum", MySqlDbType.VarChar,80),
					new MySqlParameter("?killMoney", MySqlDbType.Double),
					new MySqlParameter("?lockName", MySqlDbType.VarChar,30),
					new MySqlParameter("?oldBillCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?operator", MySqlDbType.VarChar,30),
					new MySqlParameter("?outInMoney", MySqlDbType.Double),
					new MySqlParameter("?receiveMoney", MySqlDbType.Double),
					new MySqlParameter("?remainMoney", MySqlDbType.Double),
					new MySqlParameter("?remarks", MySqlDbType.VarChar,80),
					new MySqlParameter("?salesman", MySqlDbType.VarChar,30),
					new MySqlParameter("?storeDate", MySqlDbType.Date),
					new MySqlParameter("?trafficNum", MySqlDbType.VarChar,80),
					new MySqlParameter("?vehCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?ent_id", MySqlDbType.Int64,20),
					new MySqlParameter("?saleOrderBill_id", MySqlDbType.Int64,20),
					new MySqlParameter("?sys_dep_id", MySqlDbType.Int64,20),
					new MySqlParameter("?kokura_id", MySqlDbType.Int64,20),
					new MySqlParameter("?storeTime", MySqlDbType.Time),
					new MySqlParameter("?saleMoney", MySqlDbType.Double),
					new MySqlParameter("?RBillCode", MySqlDbType.VarChar,255),
					new MySqlParameter("?RBillId", MySqlDbType.Int64,20),
					new MySqlParameter("?prizeBillCode", MySqlDbType.VarChar,255),
					new MySqlParameter("?prizeBillId", MySqlDbType.Int64,20),
					new MySqlParameter("?returnCause", MySqlDbType.VarChar,100),
					new MySqlParameter("?lastPreReceiveValidBalance", MySqlDbType.Double),
					new MySqlParameter("?lastpromiseReceivable", MySqlDbType.Double),
					new MySqlParameter("?settlementType", MySqlDbType.Int32,11),
					new MySqlParameter("?returnStoreBillCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?returnStoreBillId", MySqlDbType.Int64,20),
					new MySqlParameter("?operator_id", MySqlDbType.Int64,20),
					new MySqlParameter("?salesman_id", MySqlDbType.Int64,20),
					new MySqlParameter("?id", MySqlDbType.Int64,20)};
			parameters[0].Value = model.billCode;
			parameters[1].Value = model.billMoney;
			parameters[2].Value = model.billType;
			parameters[3].Value = model.blProxy;
			parameters[4].Value = model.chequeNum;
			parameters[5].Value = model.contractNum;
			parameters[6].Value = model.deliver;
			parameters[7].Value = model.driver;
			parameters[8].Value = model.flowFlag;
			parameters[9].Value = model.invoiceNum;
			parameters[10].Value = model.killMoney;
			parameters[11].Value = model.lockName;
			parameters[12].Value = model.oldBillCode;
			parameters[13].Value = model.operators;
			parameters[14].Value = model.outInMoney;
			parameters[15].Value = model.receiveMoney;
			parameters[16].Value = model.remainMoney;
			parameters[17].Value = model.remarks;
			parameters[18].Value = model.salesman;
			parameters[19].Value = model.storeDate;
			parameters[20].Value = model.trafficNum;
			parameters[21].Value = model.vehCode;
			parameters[22].Value = model.ent_id;
			parameters[23].Value = model.saleOrderBill_id;
			parameters[24].Value = model.sys_dep_id;
			parameters[25].Value = model.kokura_id;
			parameters[26].Value = model.storeTime;
			parameters[27].Value = model.saleMoney;
			parameters[28].Value = model.RBillCode;
			parameters[29].Value = model.RBillId;
			parameters[30].Value = model.prizeBillCode;
			parameters[31].Value = model.prizeBillId;
			parameters[32].Value = model.returnCause;
			parameters[33].Value = model.lastPreReceiveValidBalance;
			parameters[34].Value = model.lastpromiseReceivable;
			parameters[35].Value = model.settlementType;
			parameters[36].Value = model.returnStoreBillCode;
			parameters[37].Value = model.returnStoreBillId;
			parameters[38].Value = model.operator_id;
			parameters[39].Value = model.salesman_id;
			parameters[40].Value = model.id;

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
			strSql.Append("delete from salestorebill ");
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
			strSql.Append("delete from salestorebill ");
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
		public YSWL.Model.ERP.SalePackingBill.SaleStoreBill GetModel(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,billCode,billMoney,billType,blProxy,chequeNum,contractNum,deliver,driver,flowFlag,invoiceNum,killMoney,lockName,oldBillCode,operator,outInMoney,receiveMoney,remainMoney,remarks,salesman,storeDate,trafficNum,vehCode,ent_id,saleOrderBill_id,sys_dep_id,kokura_id,storeTime,saleMoney,RBillCode,RBillId,prizeBillCode,prizeBillId,returnCause,lastPreReceiveValidBalance,lastpromiseReceivable,settlementType,returnStoreBillCode,returnStoreBillId,operator_id,salesman_id from salestorebill ");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64)
			};
			parameters[0].Value = id;

            YSWL.Model.ERP.SalePackingBill.SaleStoreBill model = new YSWL.Model.ERP.SalePackingBill.SaleStoreBill();
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
		public YSWL.Model.ERP.SalePackingBill.SaleStoreBill DataRowToModel(DataRow row)
		{
			YSWL.Model.ERP.SalePackingBill.SaleStoreBill model=new YSWL.Model.ERP.SalePackingBill.SaleStoreBill();
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
				if(row["driver"]!=null)
				{
					model.driver=row["driver"].ToString();
				}
				if(row["flowFlag"]!=null && row["flowFlag"].ToString()!="")
				{
					model.flowFlag=int.Parse(row["flowFlag"].ToString());
				}
				if(row["invoiceNum"]!=null)
				{
					model.invoiceNum=row["invoiceNum"].ToString();
				}
					//model.killMoney=row["killMoney"].ToString();
				if(row["lockName"]!=null)
				{
					model.lockName=row["lockName"].ToString();
				}
				if(row["oldBillCode"]!=null)
				{
					model.oldBillCode=row["oldBillCode"].ToString();
				}
				if(row["operator"]!=null)
				{
					model.operators=row["operator"].ToString();
				}
					//model.outInMoney=row["outInMoney"].ToString();
					//model.receiveMoney=row["receiveMoney"].ToString();
					//model.remainMoney=row["remainMoney"].ToString();
				if(row["remarks"]!=null)
				{
					model.remarks=row["remarks"].ToString();
				}
				if(row["salesman"]!=null)
				{
					model.salesman=row["salesman"].ToString();
				}
				if(row["storeDate"]!=null && row["storeDate"].ToString()!="")
				{
					model.storeDate=DateTime.Parse(row["storeDate"].ToString());
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
				if(row["saleOrderBill_id"]!=null && row["saleOrderBill_id"].ToString()!="")
				{
					model.saleOrderBill_id=long.Parse(row["saleOrderBill_id"].ToString());
				}
				if(row["sys_dep_id"]!=null && row["sys_dep_id"].ToString()!="")
				{
					model.sys_dep_id=long.Parse(row["sys_dep_id"].ToString());
				}
				if(row["kokura_id"]!=null && row["kokura_id"].ToString()!="")
				{
					model.kokura_id=long.Parse(row["kokura_id"].ToString());
				}
				if(row["storeTime"]!=null && row["storeTime"].ToString()!="")
				{
					model.storeTime=DateTime.Parse(row["storeTime"].ToString());
				}
					//model.saleMoney=row["saleMoney"].ToString();
				if(row["RBillCode"]!=null)
				{
					model.RBillCode=row["RBillCode"].ToString();
				}
				if(row["RBillId"]!=null && row["RBillId"].ToString()!="")
				{
					model.RBillId=long.Parse(row["RBillId"].ToString());
				}
				if(row["prizeBillCode"]!=null)
				{
					model.prizeBillCode=row["prizeBillCode"].ToString();
				}
				if(row["prizeBillId"]!=null && row["prizeBillId"].ToString()!="")
				{
					model.prizeBillId=long.Parse(row["prizeBillId"].ToString());
				}
				if(row["returnCause"]!=null)
				{
					model.returnCause=row["returnCause"].ToString();
				}
					//model.lastPreReceiveValidBalance=row["lastPreReceiveValidBalance"].ToString();
					//model.lastpromiseReceivable=row["lastpromiseReceivable"].ToString();
				if(row["settlementType"]!=null && row["settlementType"].ToString()!="")
				{
					model.settlementType=int.Parse(row["settlementType"].ToString());
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,billCode,billMoney,billType,blProxy,chequeNum,contractNum,deliver,driver,flowFlag,invoiceNum,killMoney,lockName,oldBillCode,operator,outInMoney,receiveMoney,remainMoney,remarks,salesman,storeDate,trafficNum,vehCode,ent_id,saleOrderBill_id,sys_dep_id,kokura_id,storeTime,saleMoney,RBillCode,RBillId,prizeBillCode,prizeBillId,returnCause,lastPreReceiveValidBalance,lastpromiseReceivable,settlementType,returnStoreBillCode,returnStoreBillId,operator_id,salesman_id ");
			strSql.Append(" FROM salestorebill ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM salestorebill ");
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
			strSql.Append(")AS Row, T.*  from salestorebill T ");
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
			parameters[0].Value = "salestorebill";
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

		#endregion  ExtensionMethod


   


      
    }
}

